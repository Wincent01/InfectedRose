using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using InfectedRose.Database.Fdb;
using Microsoft.Data.Sqlite;

namespace InfectedRose.Database.Sql
{
    public static class AccessDatabaseExtensions
    {
        public static async Task LoadSqlAsync(this AccessDatabase @this, string connectionString)
        {
            await using var connection = new SqliteConnection(connectionString);

            await connection.OpenAsync();

            foreach (var table in @this)
            {
                table.Clear();

                await using (var query = new SqliteCommand("SELECT * FROM ?", connection))
                {
                    query.Parameters.Add(table.Name);

                    await using var reader = await query.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        var entry = table.Create();

                        foreach (var field in entry)
                        {
                            entry[field.Name].Value = field.Type switch
                            {
                                DataType.Nothing => (object) reader.GetInt32(field.Index),
                                DataType.Integer => reader.GetInt32(field.Index),
                                DataType.Unknown1 => reader.GetInt32(field.Index),
                                DataType.Unknown2 => reader.GetInt32(field.Index),
                                DataType.Float => reader.GetFloat(field.Index),
                                DataType.Text => reader.GetString(field.Index),
                                DataType.Varchar => reader.GetString(field.Index),
                                DataType.Boolean => reader.GetBoolean(field.Index),
                                DataType.Bigint => reader.GetInt64(field.Index),
                                _ => throw new ArgumentOutOfRangeException()
                            };
                        }
                    }
                }

                table.Recalculate();
            }

            await connection.CloseAsync();
        }

        public static async Task ExportSqlAsync(this AccessDatabase @this, string connectionString)
        {
            await using var connection = new SqliteConnection(connectionString);

            await connection.OpenAsync();

            foreach (var table in @this)
            {
                Console.WriteLine($"Writing: {table.Name} x {table.Count}");
                
                await using (var query = new SqliteCommand(table.TableSegment(), connection))
                {
                    await query.ExecuteNonQueryAsync();
                }

                var rows = new StringBuilder();
                
                foreach (var row in table)
                {
                    rows.AppendLine(row.SqlInsert());
                }

                await using (var query = new SqliteCommand(rows.ToString(), connection))
                {
                    await query.ExecuteNonQueryAsync();
                }

                Console.WriteLine($"Wrote: {table.Name}");
            }

            await connection.CloseAsync();
        }
    }
}