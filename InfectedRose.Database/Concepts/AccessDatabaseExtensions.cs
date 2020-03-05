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

        public static LwoObject NewObject(this AccessDatabase @this, int id = -1)
        {
            var table = @this["Objects"];
            
            if (id == -1)
            {
                id = table.ClaimKey(1);
            }
            
            var row = table.Create(id);

            return LoadObject(@this, row.Key);
        }

        public static LwoObject CopyObject(this AccessDatabase @this, int lot, int id = -1)
        {
            var source = @this.LoadObject(lot);

            var destination = @this.NewObject(id);

            foreach (var column in source.Row)
            {
                if (column.Name == "id") continue;
                
                destination.Row[column.Name].Value = column.Value;
                destination.Row[column.Name].Type = column.Type;
            }
            
            foreach (var component in source)
            {
                var destinationComponent = new LwoComponent(component.Id);

                destination.Add(destinationComponent);

                var sourceRow = component.Row;

                if (sourceRow == default) continue;

                var destinationRow = destinationComponent.Row;
                
                foreach (var column in sourceRow)
                {
                    if (column.Name == "id") continue;

                    destinationRow[column.Name].Value = column.Value;
                    destinationRow[column.Name].Type = column.Type;
                }
            }

            return destination;
        }
    }
}