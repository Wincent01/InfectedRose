namespace InfectedRose.Database.Concepts.Tables
{
    public class BuffParametersTable

    {
        public BuffParametersTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int BuffID
        {
            get => (int) Column["BuffID"].Value;

            set => Column["BuffID"].Value = value;
        }

        public string ParameterName
        {
            get => (string) Column["ParameterName"].Value;

            set => Column["ParameterName"].Value = value;
        }

        public float NumberValue
        {
            get => (float) Column["NumberValue"].Value;

            set => Column["NumberValue"].Value = value;
        }

        public string StringValue
        {
            get => (string) Column["StringValue"].Value;

            set => Column["StringValue"].Value = value;
        }

        public int EffectID
        {
            get => (int) Column["EffectID"].Value;

            set => Column["EffectID"].Value = value;
        }
    }
}