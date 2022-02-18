using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using InfectedRose.Database.Fdb;

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
        public XmlColumns Columns { get; set; }
        
        [XmlElement("rows")]
        public XmlRows Rows { get; set; }
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
    }
}