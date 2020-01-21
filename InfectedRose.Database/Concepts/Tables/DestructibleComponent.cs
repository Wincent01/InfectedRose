namespace InfectedRose.Database.Concepts.Tables
{
    public class DestructibleComponentTable

    {
        public DestructibleComponentTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public int faction
        {
            get => (int) Column["faction"].Value;

            set => Column["faction"].Value = value;
        }

        public string factionList
        {
            get => (string) Column["factionList"].Value;

            set => Column["factionList"].Value = value;
        }

        public int life
        {
            get => (int) Column["life"].Value;

            set => Column["life"].Value = value;
        }

        public int imagination
        {
            get => (int) Column["imagination"].Value;

            set => Column["imagination"].Value = value;
        }

        public int LootMatrixIndex
        {
            get => (int) Column["LootMatrixIndex"].Value;

            set => Column["LootMatrixIndex"].Value = value;
        }

        public int CurrencyIndex
        {
            get => (int) Column["CurrencyIndex"].Value;

            set => Column["CurrencyIndex"].Value = value;
        }

        public int level
        {
            get => (int) Column["level"].Value;

            set => Column["level"].Value = value;
        }

        public float armor
        {
            get => (float) Column["armor"].Value;

            set => Column["armor"].Value = value;
        }

        public int death_behavior
        {
            get => (int) Column["death_behavior"].Value;

            set => Column["death_behavior"].Value = value;
        }

        public bool isnpc
        {
            get => (bool) Column["isnpc"].Value;

            set => Column["isnpc"].Value = value;
        }

        public int attack_priority
        {
            get => (int) Column["attack_priority"].Value;

            set => Column["attack_priority"].Value = value;
        }

        public bool isSmashable
        {
            get => (bool) Column["isSmashable"].Value;

            set => Column["isSmashable"].Value = value;
        }

        public int difficultyLevel
        {
            get => (int) Column["difficultyLevel"].Value;

            set => Column["difficultyLevel"].Value = value;
        }
    }
}