using System.Linq;

namespace InfectedRose.Database.Concepts
{
    public static class AccessDatabaseExtensions
    {
        public static LwoObject LoadObject(this AccessDatabase @this, int lot)
        {
            var row = @this["Objects"].FirstOrDefault(r => r.Key == lot);

            return row == default ? default : new LwoObject(row);
        }

        public static LwoObject NewObject(this AccessDatabase @this)
        {
            var row = @this["Objects"].Create();

            return LoadObject(@this, row.Key);
        }
    }
}