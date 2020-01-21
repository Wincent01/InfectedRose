namespace InfectedRose.Database.Concepts.Tables
{
    public class TamingBuildPuzzlesTable

    {
        public TamingBuildPuzzlesTable(Column column)

        {
            Column = column;
        }

        public Column Column { get; }

        public int id
        {
            get => (int) Column["id"].Value;

            set => Column["id"].Value = value;
        }

        public int PuzzleModelLot
        {
            get => (int) Column["PuzzleModelLot"].Value;

            set => Column["PuzzleModelLot"].Value = value;
        }

        public int NPCLot
        {
            get => (int) Column["NPCLot"].Value;

            set => Column["NPCLot"].Value = value;
        }

        public string ValidPiecesLXF
        {
            get => (string) Column["ValidPiecesLXF"].Value;

            set => Column["ValidPiecesLXF"].Value = value;
        }

        public string InvalidPiecesLXF
        {
            get => (string) Column["InvalidPiecesLXF"].Value;

            set => Column["InvalidPiecesLXF"].Value = value;
        }

        public int Difficulty
        {
            get => (int) Column["Difficulty"].Value;

            set => Column["Difficulty"].Value = value;
        }

        public int Timelimit
        {
            get => (int) Column["Timelimit"].Value;

            set => Column["Timelimit"].Value = value;
        }

        public int NumValidPieces
        {
            get => (int) Column["NumValidPieces"].Value;

            set => Column["NumValidPieces"].Value = value;
        }

        public int TotalNumPieces
        {
            get => (int) Column["TotalNumPieces"].Value;

            set => Column["TotalNumPieces"].Value = value;
        }

        public string ModelName
        {
            get => (string) Column["ModelName"].Value;

            set => Column["ModelName"].Value = value;
        }

        public string FullModelLXF
        {
            get => (string) Column["FullModelLXF"].Value;

            set => Column["FullModelLXF"].Value = value;
        }

        public float Duration
        {
            get => (float) Column["Duration"].Value;

            set => Column["Duration"].Value = value;
        }

        public int imagCostPerBuild
        {
            get => (int) Column["imagCostPerBuild"].Value;

            set => Column["imagCostPerBuild"].Value = value;
        }
    }
}