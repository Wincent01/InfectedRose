namespace InfectedRose.Database.Generic
{
    public static class ColumnExtensions
    {
        public static T Value<T>(this Column @this, string id)
        {
            return (T) @this[id].Value;
        }
    }
}