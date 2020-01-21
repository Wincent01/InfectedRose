namespace InfectedRose.Database.Concepts.Tables
{
    public class AnimationsTable

    {
        public AnimationsTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int animationGroupID
        {
            get => (int) Column["animationGroupID"].Value;

            set => Column["animationGroupID"].Value = value;
        }

        public string animation_type
        {
            get => (string) Column["animation_type"].Value;

            set => Column["animation_type"].Value = value;
        }

        public string animation_name
        {
            get => (string) Column["animation_name"].Value;

            set => Column["animation_name"].Value = value;
        }

        public float chance_to_play
        {
            get => (float) Column["chance_to_play"].Value;

            set => Column["chance_to_play"].Value = value;
        }

        public int min_loops
        {
            get => (int) Column["min_loops"].Value;

            set => Column["min_loops"].Value = value;
        }

        public int max_loops
        {
            get => (int) Column["max_loops"].Value;

            set => Column["max_loops"].Value = value;
        }

        public float animation_length
        {
            get => (float) Column["animation_length"].Value;

            set => Column["animation_length"].Value = value;
        }

        public bool hideEquip
        {
            get => (bool) Column["hideEquip"].Value;

            set => Column["hideEquip"].Value = value;
        }

        public bool ignoreUpperBody
        {
            get => (bool) Column["ignoreUpperBody"].Value;

            set => Column["ignoreUpperBody"].Value = value;
        }

        public bool restartable
        {
            get => (bool) Column["restartable"].Value;

            set => Column["restartable"].Value = value;
        }

        public string face_animation_name
        {
            get => (string) Column["face_animation_name"].Value;

            set => Column["face_animation_name"].Value = value;
        }

        public float priority
        {
            get => (float) Column["priority"].Value;

            set => Column["priority"].Value = value;
        }

        public float blendTime
        {
            get => (float) Column["blendTime"].Value;

            set => Column["blendTime"].Value = value;
        }
    }
}