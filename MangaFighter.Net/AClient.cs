using System;
using System.Net.Sockets;
using MangaFighter.Net.Packet;
using MangaFighter.Common.Utils;

namespace MangaFighter.Net
{
    public abstract class AClient
    {
        public ushort Version {get;}
        public byte SubVersion {get;}
        public byte ServerType {get;}
        public bool PrintPackets {get;}
        public string Host {get; set;}
        public ushort Port {get; set;}
        public ClientSocket Socket {get; set;}
        public bool Connected {get; set;}
        public DateTime LastPing {get; set;} = DateTime.UtcNow;
        public string Key {get; set;}
        // public abstract ILogger _logger {get; set} - ive written my own logging script.

        protected AClient(Socket session, ushort version, byte servertype, ulong? easkey, bool printPackets, bool toClient)
        {
            Version = version;
            SubVersion = SubVersion;
            ServerType = servertype;
            PrintPackets = PrintPackets;
            Socket = new ClientSocket(session, this, version, easkey, toClient);
            Host = Socket.Host;
            Port = Socket.Port;
            Connected = true;
        }

        public virtual void Disconnected() => Connected = false;

        public virtual void Send(PacketWriter packet)
        {
            var packetData = packet.ToArray();
            if (PrintPackets)
            {
                Log.Info($"Sending [{packet.Header}] {packetData.ByteArrayToString()}")
            }

            Socket?.Send(packetData);
        }
        public void Send(byte[] packet)
        {
            if (PrintPackets)
            {
                Log.Info($"Sending: {packet.ByteArrayToString()}");
            }

            Socket?.Send(packet);
        }
        public virtual void Terminate(string message = null)
        {
            Log.Info($"Disconnecting Client - {Key}. Reason: {message}");
            Socket?.Disconnect();
        }

        // sends a handshake and checks the client version - Needs a rewrite for compatability with the old qpang client
        public void SendHandshake()
        {
            if (Socket == null)
            {
                return;
            }

            var sIv = Functions.RandomUInt();
            var rIv = Functions.RandomUInt();
            Socket.Cipher.SetVectors(sIv, rIv);

            var writer = new PacketWriter();
            writer.WriteUShort(0x0E);
            writer.WriteUShort(Version);
            writer.WriteString(SubVersion.ToString());
            writer.WriteUInt(rIv);
            writer.WriteUInt(sIv);
            writer.WriteByte(ServerType);
            Socket.SendRawPacket(writer.ToArray());
        }

        public void Dispose() => Socket?.Dispose();
    }
}