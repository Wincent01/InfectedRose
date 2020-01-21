namespace InfectedRose.Database.Concepts
{
    public class LwoComponent
    {
        internal LwoComponent()
        {
        }

        public LwoComponent(ComponentId id)
        {
            Id = id;
        }

        public ComponentId Id { get; internal set; }

        public AccessDatabase Database { get; internal set; }

        public Column Row { get; internal set; }

        public Column Entry { get; internal set; }

        public static bool operator ==(LwoComponent component, LwoComponent other)
        {
            return component?.Id == other?.Id && component?.Row?.Key == other?.Row?.Key &&
                   component?.Entry?.Key == other?.Entry?.Key;
        }

        public static bool operator !=(LwoComponent component, LwoComponent other)
        {
            return !(component == other);
        }
    }
}