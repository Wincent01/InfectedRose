namespace InfectedRose.Database.Concepts.Tables
{
    public class RewardCodesTable

    {
        public RewardCodesTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public string code
        {
            get => (string) Column["code"].Value;

            set => Column["code"].Value = value;
        }

        public int attachmentLOT
        {
            get => (int) Column["attachmentLOT"].Value;

            set => Column["attachmentLOT"].Value = value;
        }

        public int locStatus
        {
            get => (int) Column["locStatus"].Value;

            set => Column["locStatus"].Value = value;
        }

        public string gate_version
        {
            get => (string) Column["gate_version"].Value;

            set => Column["gate_version"].Value = value;
        }
    }
}