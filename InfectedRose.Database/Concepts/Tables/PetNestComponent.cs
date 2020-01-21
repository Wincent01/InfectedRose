namespace InfectedRose.Database.Concepts.Tables
{
    public class PetNestComponentTable

    {
        public PetNestComponentTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public int ElementalType
        {
            get => (int) Column["ElementalType"].Value;

            set => Column["ElementalType"].Value = value;
        }
    }
}