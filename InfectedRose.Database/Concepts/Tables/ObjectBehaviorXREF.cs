namespace InfectedRose.Database.Concepts.Tables
{
    public class ObjectBehaviorXREFTable

    {
        public ObjectBehaviorXREFTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int LOT
        {
            get => (int) Column["LOT"].Value;

            set => Column["LOT"].Value = value;
        }

        public long behaviorID1
        {
            get => (long) Column["behaviorID1"].Value;

            set => Column["behaviorID1"].Value = value;
        }

        public long behaviorID2
        {
            get => (long) Column["behaviorID2"].Value;

            set => Column["behaviorID2"].Value = value;
        }

        public long behaviorID3
        {
            get => (long) Column["behaviorID3"].Value;

            set => Column["behaviorID3"].Value = value;
        }

        public long behaviorID4
        {
            get => (long) Column["behaviorID4"].Value;

            set => Column["behaviorID4"].Value = value;
        }

        public long behaviorID5
        {
            get => (long) Column["behaviorID5"].Value;

            set => Column["behaviorID5"].Value = value;
        }

        public int type
        {
            get => (int) Column["type"].Value;

            set => Column["type"].Value = value;
        }
    }
}