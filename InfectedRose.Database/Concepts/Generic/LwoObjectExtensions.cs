using System;

namespace InfectedRose.Database.Concepts.Generic
{
    public static class LwoObjectExtensions
    {
        public static T GetComponent<T>(this LwoObject @this) where T : class
        {
            var name = typeof(T).Name;
            
            foreach (var component in @this)
            {
                if (component.Row?.Table?.Name == default) continue;
                
                if ($"{component.Row.Table.Name}Table" != name) continue;

                var instance = Activator.CreateInstance(typeof(T), component.Row) as T;

                return instance;
            }

            return default;
        }
    }
}