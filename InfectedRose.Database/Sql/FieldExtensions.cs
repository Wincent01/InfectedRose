using System.Text;

namespace InfectedRose.Database.Sql
{
    internal static class FieldExtensions
    {
        internal static string ValuesSegment(this Field @this)
        {
            var builder = new StringBuilder();

            var value = @this.Value;

            switch (value)
            {
                case string str:
                    str = str.Replace("'", "''");

                    builder.Append($"'{str}'");
                    break;
                case null:
                    builder.Append("NULL");
                    break;
                default:
                    builder.Append(value);
                    break;
            }

            return builder.ToString();
        }

        internal static string ConditionSegment(this Field @this, bool set = false)
        {
            var builder = new StringBuilder();

            var value = ValuesSegment(@this);

            builder.Append(!set ? $"{@this.Name} {(value == "NULL" ? "IS" : "=")} {value}" : $"{@this.Name} = {value}");

            return builder.ToString();
        }

        internal static string SetSegment(this Field @this)
        {
            return $"SET {ConditionSegment(@this, true)}";
        }

        internal static string UpdateSegment(this Field @this, string where)
        {
            var builder = new StringBuilder();

            builder.Append(@this.Table.UpdateSegment());

            builder.Append($" {SetSegment(@this)} ");

            builder.Append(where);

            return builder.ToString();
        }

        internal static string SqlUpdate(this Field @this, string where)
        {
            var builder = new StringBuilder();

            builder.Append(UpdateSegment(@this, where));

            builder.Append(";");

            return builder.ToString();
        }
    }
}