using System.Text;

namespace InfectedRose.Database.Sql
{
    internal static class ColumnExtensions
    {
        internal static string WhereSegment(this Column @this)
        {
            var builder = new StringBuilder("WHERE ");

            foreach (var field in @this)
            {
                builder.Append(field.ConditionSegment());

                builder.Append(" AND ");
            }

            if (builder.Length >= 5) builder.Length -= 5;

            return builder.ToString();
        }

        internal static string ValuesSegment(this Column @this)
        {
            var builder = new StringBuilder("VALUES (");

            foreach (var field in @this) builder.Append($"{field.ValuesSegment()}, ");

            if (builder.Length >= 2) builder.Length -= 2;

            builder.Append(")");

            return builder.ToString();
        }

        internal static string SqlInsert(this Column @this)
        {
            var builder = new StringBuilder();

            builder.Append(@this.Table.InsertSegment());

            builder.Append($" {ValuesSegment(@this)};");

            return builder.ToString();
        }

        internal static string SqlDelete(this Column @this)
        {
            var builder = new StringBuilder();

            builder.Append(@this.Table.DeleteSegment());

            builder.Append($" {WhereSegment(@this)};");

            return builder.ToString();
        }
    }
}