namespace InfectedRose.Terrain.Editing
{
    public class TerrainSettings
    {
        /// <summary>
        ///     Size of the terrain in chunks. Both in the X and Z axis.
        /// </summary>
        public int Size { get; set; } = 1;

        /// <summary>
        ///     Size of the individual terrain chunks. Both in the X and Z axis.
        /// </summary>
        public int ChunkSize { get; set; } = 65;

        /// <summary>
        ///     The default height of the terrain.
        /// </summary>
        public float DefaultHeight { get; set; } = 200;

        /// <summary>
        ///     How far the chunks are spaced from each other.
        /// </summary>
        public float ChunkSpacing { get; set; } = 204.8f;
    }
}