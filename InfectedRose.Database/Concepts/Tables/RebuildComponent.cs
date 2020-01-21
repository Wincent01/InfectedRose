namespace InfectedRose.Database.Concepts.Tables
{
    public class RebuildComponentTable

    {
        public RebuildComponentTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public float reset_time
        {
            get => (float) Column["reset_time"].Value;

            set => Column["reset_time"].Value = value;
        }

        public float complete_time
        {
            get => (float) Column["complete_time"].Value;

            set => Column["complete_time"].Value = value;
        }

        public int take_imagination
        {
            get => (int) Column["take_imagination"].Value;

            set => Column["take_imagination"].Value = value;
        }

        public bool interruptible
        {
            get => (bool) Column["interruptible"].Value;

            set => Column["interruptible"].Value = value;
        }

        public bool self_activator
        {
            get => (bool) Column["self_activator"].Value;

            set => Column["self_activator"].Value = value;
        }

        public string custom_modules
        {
            get => (string) Column["custom_modules"].Value;

            set => Column["custom_modules"].Value = value;
        }

        public int activityID
        {
            get => (int) Column["activityID"].Value;

            set => Column["activityID"].Value = value;
        }

        public int post_imagination_cost
        {
            get => (int) Column["post_imagination_cost"].Value;

            set => Column["post_imagination_cost"].Value = value;
        }

        public float time_before_smash
        {
            get => (float) Column["time_before_smash"].Value;

            set => Column["time_before_smash"].Value = value;
        }
    }
}