namespace InfectedRose.Database.Generic
{
    public static class ColumnExtensions
    {
        public static T Value<T>(this Row @this, string id)
        {
            return (T) @this[id].Value;
        }
    }
}