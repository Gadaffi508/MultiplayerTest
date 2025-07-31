using System.Net;
using System.Net.Sockets;
using UnityEngine;

namespace Mirror
{
    public class SafeTelepathyTransport : TelepathyTransport
    {
        public override void ServerStart()
        {
            if (IsPortInUse(port))
            {
                Debug.LogError($"❌ SafeTelepathyTransport: Port {port} is already in use. Server will NOT start.");
                return;
            }

            base.ServerStart();
        }

        private bool IsPortInUse(int port)
        {
            try
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Blocking = false;
                socket.Bind(new IPEndPoint(IPAddress.Loopback, port));
                socket.Close();
                return false;
            }
            catch (SocketException)
            {
                return true;
            }
        }
        
        private bool IsPortReallyFree(int port)
        {
            try
            {
                Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, false);
                sock.Bind(new IPEndPoint(IPAddress.Loopback, port));
                sock.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}