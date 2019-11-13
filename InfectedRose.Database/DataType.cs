namespace InfectedRose.Database
{
    public enum DataType : uint
    {
        Nothing, // can’t remember if those are just skipped/ignored or even showed up
        Integer,
        Unknown1, // never used?
        Float,
        Text, // called STRING in MSSQL?
        Boolean,
        Bigint, // or DATETIME?
        Unknown2, // never used?
        Varchar // called TEXT in MSSQL?
    }
}