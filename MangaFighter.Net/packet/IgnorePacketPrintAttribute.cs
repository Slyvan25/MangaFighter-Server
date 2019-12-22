using System;

namespace MangaFighter.Net.Packet
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple=true)]
    public sealed class IgnorePacketPrintAttribute : Attribute{}
}