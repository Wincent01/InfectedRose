namespace InfectedRose.Database.Concepts.Tables
{
    public class WhatsCoolNewsAndTipsTable

    {
        public WhatsCoolNewsAndTipsTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public int iconID
        {
            get => (int) Column["iconID"].Value;

            set => Column["iconID"].Value = value;
        }

        public int type
        {
            get => (int) Column["type"].Value;

            set => Column["type"].Value = value;
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