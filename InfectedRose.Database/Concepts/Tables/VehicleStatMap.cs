namespace InfectedRose.Database.Concepts.Tables
{
    public class VehicleStatMapTable

    {
        public VehicleStatMapTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public string ModuleStat
        {
            get => (string) Column["ModuleStat"].Value;

            set => Column["ModuleStat"].Value = value;
        }

        public string HavokStat
        {
            get => (string) Column["HavokStat"].Value;

            set => Column["HavokStat"].Value = value;
        }

        public float HavokChangePerModuleStat
        {
            get => (float) Column["HavokChangePerModuleStat"].Value;

            set => Column["HavokChangePerModuleStat"].Value = value;
        }
    }
}