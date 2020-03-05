using System;
using InfectedRose.Database.Fdb;

namespace InfectedRose.Database.Sql
{
    public static class DataTypeExtensions
    {
        public static string SqlTypeSegment(this DataType @this)
        {
            return @this switch
            {
                DataType.Nothing => "NULL",
                DataType.Unknown2 => "INTEGER",
                DataType.Unknown1 => "INTEGER",
                DataType.Integer => "INTEGER",
                DataType.Boolean => "INTEGER",
                DataType.Bigint => "INTEGER",
                DataType.Float => "REAL",
                DataType.Text => "TEXT",
                DataType.Varchar => "TEXT",
                _ => throw new ArgumentOutOfRangeException(nameof(@this), @this, null)
            };
        }
    }
}