using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace InfectedRose.Database.Generic
{
    public static class TableExtensions
    {
        public static TypedTable<T> Typed<T>(this AccessDatabase @this) where T : class
        {
            var type = typeof(T);

            var attribute = type.GetCustomAttribute<TableAttribute>();

            var id = attribute?.Name ?? type.Name;

            var table = @this[id];
            
            return new TypedTable<T>(table.Info, table.Data);
        }
    }
}