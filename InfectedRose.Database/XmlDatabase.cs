using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using InfectedRose.Database.Fdb;
using Microsoft.Data.Sqlite;

namespace InfectedRose.Interface
{
    [XmlRoot("column")]
    public class XmlColumn
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        
        [XmlAttribute("type")]
        public string XmlType { get; set; }

        [XmlIgnore]
        public DataType Type
        {
            get
            {
                switch (XmlType)
                {
                    case "tinyint":
                    case "smallint":
                    case "int":
                        return DataType.Integer;
                    case "char":
                    case "nchar":
                    case "varchar":
                    case "nvarchar":
                    case "datetime":
                    case "smalldatetime":
                    case "image":
                    case "text":
                    case "xml":
                    case "varbinary":
                        return DataType.Text;
                    case "float":
                    case "real":
                        return DataType.Float;
                    case "bit":
                        return DataType.Boolean;
                    case "bigint":
                        return DataType.Bigint;
                    default:
                        throw new Exception($"Unknown type {XmlType}!");
                }
            }
            set
            {
                switch (value)
                {
                    case DataType.Integer:
                        XmlType = "int";
                        break;
                    case DataType.Nothing:
                    case DataType.Text:
                        XmlType = "text";
                        break;
                    case DataType.Varchar:
                        XmlType = "varchar";
                        break;
                    case DataType.Float:
                        XmlType = "float";
                        break;
                    case DataType.Boolean:
                        XmlType = "bit";
                        break;
                    case DataType.Bigint:
                        XmlType = "bigint";
                        break;
                    default:
                        throw new Exception($"Unknown type {value}!");
                }
            }
        }
    }
    
    public class XmlColumns
    {
        [XmlElement("column")]
        public List<XmlColumn> Columns { get; set; } = new List<XmlColumn>();
    }
    
    public class XmlRows
    {
        [XmlElement("row")]
        public List<XmlRow> Rows { get; set; } = new List<XmlRow>();
    }

    [XmlRoot("table")]
    public class XmlTable
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        
        [XmlElement("columns")]
        public XmlColumns Columns { get; set; } = new XmlColumns();
        
        [XmlElement("rows")]
        public XmlRows Rows { get; set; } = new XmlRows();
    }

    public class DynamicAttributes : IXmlSerializable
    {
        public Dictionary<string, object> Attributes { get; }

        public DynamicAttributes()
        {
            Attributes = new Dictionary<string, object>();
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            if (reader.HasAttributes)
            {
                while (reader.MoveToNextAttribute())
                {
                    var key = reader.LocalName;
                    var value = reader.Value;

                    Attributes.Add(key, value);
                }

                reader.MoveToElement();
            }

            reader.ReadStartElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            foreach (var (key, value) in Attributes)
            {
                writer.WriteStartAttribute(key);

                writer.WriteValue(value);

                writer.WriteEndAttribute();
            }
        }
    }

    [XmlRoot("row")]
    public class XmlRow : DynamicAttributes
    {
    }

    [XmlRoot("database")]
    public class XmlDatabase
    {
        [XmlElement("table")]
        public List<XmlTable> Tables { get; set; } = new List<XmlTable>();

        private static string DataTypeToSqlType(DataType value)
        {
            string columnType;

            switch (value)
            {
                case DataType.Integer:
                    columnType = "INT32";
                    break;
                case DataType.Float:
                    columnType = "REAL";
                    break;
                case DataType.Text:
                    columnType = "TEXT_4";
                    break;
                case DataType.Boolean:
                    columnType = "INT_BOOL";
                    break;
                case DataType.Bigint:
                    columnType = "INTEGER";
                    break;
                case DataType.Varchar:
                    columnType = "TEXT_4";
                    break;
                default:
                    columnType = "TEXT_4";
                    break;
            }

            return columnType;
        }

        private static DataType SqlTypeToDataType(string value)
        {
            switch (value)
            {
                case "INT32":
                    return DataType.Integer;
                case "REAL":
                    return DataType.Float;
                case "TEXT_4":
                    return DataType.Text;
                case "INT_BOOL":
                    return DataType.Boolean;
                case "INTEGER":
                    return DataType.Bigint;
                default:
                    return DataType.Varchar;
            }
        }

        public static XmlDatabase LoadSql(SqliteConnection connection)
        {
            var tables = new List<XmlTable>();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT name FROM sqlite_master WHERE type = 'table'";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tableName = reader.GetString(0);

                        var table = new XmlTable
                        {
                            Name = tableName
                        };

                        tables.Add(table);
                    }
                }
            }

            foreach (var table in tables)
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"PRAGMA table_info('{table.Name}')";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var name = reader.GetString(1);
                            var type = reader.GetString(2);
                            
                            var column = new XmlColumn
                            {
                                Name = name,
                                Type = SqlTypeToDataType(type)
                            };

                            table.Columns.Columns.Add(column);
                        }
                    }
                }

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT * FROM {table.Name}";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var row = new XmlRow();

                            for (var i = 0; i < reader.FieldCount; i++)
                            {
                                if (reader.IsDBNull(i))
                                {
                                    continue;
                                }
                                
                                var value = reader.GetValue(i);

                                row.Attributes.Add(table.Columns.Columns[i].Name, value);
                            }

                            table.Rows.Rows.Add(row);
                        }
                    }
                }
            }

            return new XmlDatabase
            {
                Tables = tables
            };
        }
    }
}