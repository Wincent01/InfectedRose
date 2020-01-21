namespace InfectedRose.Database.Concepts.Tables
{
    public class WhatsCoolItemSpotlightTable

    {
        public WhatsCoolItemSpotlightTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public int itemID
        {
            get => (int) Column["itemID"].Value;

            set => Column["itemID"].Value = value;
        }

        public bool localize
        {
            get => (bool) Column["localize"].Value;

            set => Column["localize"].Value = value;
        }

        public string gate_version
        {
            get => (string) Column["gate_version"].Value;

            set => Column["gate_version"].Value = value;
        }

        public int locStatus
        {
            get => (int) Column["locStatus"].Value;

            set => Column["locStatus"].Value = value;
        }
    }
}