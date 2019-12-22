using System;
using System.IO;
using System.Linq;
using System.Text;

namespace MangaFighter.Net.Packet
{
    public class PacketReader : APacket
    {
        private readonly BinaryReader _binReader;
        
        // Creates a new instance of the PacketReader
        public PacketReader(Span<byte> arrayOfBytes) : this(arrayOfBytes.ToArray())
        {}
        
    }
}