using System;

namespace MangaFighter.Net.Packet
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class PacketHandlerAttribute : Attribute
    {
        public PacketHandlerAttribute(OperationCode header)
        {
            Header = header;
        }

        public OperationCode Header {get;}
    }
}