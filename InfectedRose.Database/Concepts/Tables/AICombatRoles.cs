namespace InfectedRose.Database.Concepts.Tables
{
    public class AICombatRolesTable

    {
        public AICombatRolesTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public int preferredRole
        {
            get => (int) Column["preferredRole"].Value;

            set => Column["preferredRole"].Value = value;
        }

        public float specifiedMinRangeNOUSE
        {
            get => (float) Column["specifiedMinRangeNOUSE"].Value;

            set => Column["specifiedMinRangeNOUSE"].Value = value;
        }

        public float specifiedMaxRangeNOUSE
        {
            get => (float) Column["specifiedMaxRangeNOUSE"].Value;

            set => Column["specifiedMaxRangeNOUSE"].Value = value;
        }

        public float specificMinRange
        {
            get => (float) Column["specificMinRange"].Value;

            set => Column["specificMinRange"].Value = value;
        }

        public float specificMaxRange
        {
            get => (float) Column["specificMaxRange"].Value;

            set => Column["specificMaxRange"].Value = value;
        }
    }
}