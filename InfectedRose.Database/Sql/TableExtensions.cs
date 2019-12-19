using System.Text;

namespace InfectedRose.Database.Sql
{
    internal static class TableExtensions
    {
        internal static string UpdateSegment(this Table @this)
        {
            var builder = new StringBuilder();

            builder.Append($"UPDATE {@this.Name}");

            return builder.ToString();
        }

        internal static string InsertSegment(this Table @this)
        {
            var builder = new StringBuilder();

            builder.Append($"INSERT INTO {@this.Name} (");

            foreach (var info in @this.TableInfo)
            {
                builder.Append($"{info.Name}, ");
            }

            if (builder.Length >= 2)
            {
                builder.Length -= 2;
            }

            builder.Append(")");

            return builder.ToString();
        }
    }
}