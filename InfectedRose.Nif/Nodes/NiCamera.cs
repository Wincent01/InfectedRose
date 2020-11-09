using RakDotNet.IO;

namespace InfectedRose.Nif
{
    public class NiCamera : NiAvObject
    {
        public ushort CameraFlags { get; set; }

        public float FrustumLeft { get; set; }

        public float FrustumRight { get; set; }

        public float FrustumTop { get; set; }

        public float FrustumBottom { get; set; }

        public float FrustumNear { get; set; }

        public float FrustumFar { get; set; }

        public bool UseOrthographicProjection { get; set; }

        public float ViewportLeft { get; set; }

        public float ViewportRight { get; set; }

        public float ViewportTop { get; set; }

        public float ViewportBottom { get; set; }

        public float LODAdjust { get; set; }

        public NiRef<NiAvObject> Scene { get; set; }

        public uint ScreenPolygonsCount { get; set; }

        public uint ScreenTexturesCount { get; set; }

        public override void Serialize(BitWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(BitReader reader)
        {
            base.Deserialize(reader);

            CameraFlags = reader.Read<ushort>();

            FrustumLeft = reader.Read<float>();
            FrustumRight = reader.Read<float>();
            FrustumTop = reader.Read<float>();
            FrustumBottom = reader.Read<float>();
            FrustumNear = reader.Read<float>();
            FrustumFar = reader.Read<float>();

            UseOrthographicProjection = reader.Read<byte>() != 0;

            ViewportLeft = reader.Read<float>();
            ViewportRight = reader.Read<float>();
            ViewportTop = reader.Read<float>();
            ViewportBottom = reader.Read<float>();

            LODAdjust = reader.Read<float>();

            Scene = reader.Read<NiRef<NiAvObject>>(File);

            ScreenPolygonsCount = reader.Read<uint>();
            ScreenTexturesCount = reader.Read<uint>();
        }
    }
}