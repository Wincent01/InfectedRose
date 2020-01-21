namespace InfectedRose.Database.Concepts.Tables
{
    public class PetAbilitiesTable

    {
        public PetAbilitiesTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public string AbilityName
        {
            get => (string) Column["AbilityName"].Value;

            set => Column["AbilityName"].Value = value;
        }

        public int ImaginationCost
        {
            get => (int) Column["ImaginationCost"].Value;

            set => Column["ImaginationCost"].Value = value;
        }

        public int locStatus
        {
            get => (int) Column["locStatus"].Value;

            set => Column["locStatus"].Value = value;
        }
    }
}