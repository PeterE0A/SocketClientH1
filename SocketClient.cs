using System.Net;
using System.Net.Sockets;

namespace SocketClientH1
{
    internal class SocketClient
    {
        public SocketClient()
        {
            IPAddress serverIp = GetServerIpAddress();
            IPEndPoint endPoint = new IPEndPoint(serverIp, 11000);
            StartClient(endPoint);
        }

        private void StartClient(IPEndPoint endPoint)
        {
            Socket sender = new(
                endPoint.AddressFamily,
                SocketType.Stream,
                ProtocolType.Tcp);

            sender.Connect(endPoint);

            string msg = GetMessage();
            byte[] byteArray = System.Text.Encoding.ASCII.GetBytes(msg);
            sender.Send(byteArray);
        }

        private string GetMessage()
        {
            Console.Write("Input message: ");
            return Console.ReadLine() + "<EOM>";
        }

        private IPAddress GetServerIpAddress()
        {
            
            IPAddress? iP = null;
            do
            {
                Console.Write("Input server IP: ");
            }
            while (!IPAddress.TryParse(Console.ReadLine(), out iP));
            return iP;
        }
    }
}
