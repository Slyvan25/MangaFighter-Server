using System;
using System.Net;
using System.Net.Sockets;
using System.IO.Pipelines;

namespace MangaFighter.Net
{
    public class ClientSocket
    {
        private readonly Socket _socket;
        private readonly Pipe _pipe;
        private readonly AClient client;
        private bool _disposed;
        private readonly bool _ToClient;

        private IPEndPoint EndPoint {get;}
        
    }
}