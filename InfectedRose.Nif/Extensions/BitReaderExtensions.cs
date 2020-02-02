using System;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
    public static class BitReaderExtensions
    {
        public static T Read<T>(this BitReader @this, NiFile file) where T : NiObject
        {
            var instance = Activator.CreateInstance<T>();

            instance.File = file;
            
            instance.Deserialize(@this);

            return instance;
        }
    }
}