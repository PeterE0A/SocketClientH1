using System.Net;
using System.Net.Sockets;

namespace SocketClientH1
{
    internal class SocketClient
    {
        public SocketClient()
        {
            //IPAddress serverIp = GetServerIpAddress();
            IPAddress serverIp = IPAddress.Parse("192.168.2.3");

            IPEndPoint endPoint = new IPEndPoint(serverIp, 11000);

            while (true) StartClient(GetMessage(), endPoint);
        }

        private void StartClient(string msg, IPEndPoint endPoint)
        {
            Socket sender = new(
                endPoint.AddressFamily,
                SocketType.Stream,
                ProtocolType.Tcp);

            sender.Connect(endPoint);

            byte[] byteArray = System.Text.Encoding.ASCII.GetBytes(msg);
            sender.Send(byteArray);
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }

        private string GetMessage()
        {
            Console.Write("Input message: ");
            return Console.ReadLine() + "<EOM>";
        }

        private IPAddress GetServerIpAddress()
        {

            IPAddress iP = IPAddress.Parse("192.168.2.3");
            do
            {
                Console.Write("Input server IP: ");
            }
            while (!IPAddress.TryParse(Console.ReadLine(), out iP));
            return iP;
        }
    }
}
