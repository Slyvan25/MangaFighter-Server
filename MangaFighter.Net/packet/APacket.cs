using System;
using System.IO;

namespace MangaFighter.Net.Packet
{
    public abstract class APacket : IDisposable
    {
        protected MemoryStream buffer;
        public void Dispose() => Buffer?.Close();
        public byte[] ToArray() => Buffer.ToArray();
        public string PacketToString() => ToArray.ByteArrayToString();
    }
}