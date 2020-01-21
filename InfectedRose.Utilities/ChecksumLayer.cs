namespace InfectedRose.Utilities
{
    internal struct ChecksumLayer
    {
        internal uint Id { get; set; }

        internal uint Layer { get; set; }

        internal uint Revision { get; set; }

        internal void Apply(ref uint value, ref uint total)
        {
            foreach (var reference in new[] {Id, Layer, Revision})
            {
                value += reference >> 16; // Apply reference

                total += value; // Add to total

                value += reference & ushort.MaxValue; // Make ushort

                total += value; // Add to total
            }
        }
    }
}