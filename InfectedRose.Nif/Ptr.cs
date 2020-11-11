namespace InfectedRose.Nif
{
    public struct Ptr<T> where T : NiObject
    {
        public int Index;

        public T Get(NiFile file)
        {
            if (Index == -1)
            {
                return default;
            }

            return file.Blocks[Index] as T;
        }
    }
}