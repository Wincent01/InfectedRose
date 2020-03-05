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

            foreach (var info in @this.TableInfo) builder.Append($"{info.Name}, ");

            if (builder.Length >= 2) builder.Length -= 2;

            builder.Append(")");

            return builder.ToString();
        }

        internal static string DeleteSegment(this Table @this)
        {
            var builder = new StringBuilder();

            builder.Append($"DELETE FROM {@this.Name}");

            return builder.ToString();
        }

        internal static string TableSegment(this Table @this)
        {
            var builder = new StringBuilder();

            builder.Append($"CREATE TABLE {@this.Name} (");

            foreach (var info in @this.TableInfo)
            {
                builder.Append($"{info.Name} {info.Type.SqlTypeSegment()},");
            }

            if (builder.ToString().EndsWith(","))
                builder.Length--;

            builder.Append(");");

            return builder.ToString();
        }
    }
}