

using Grpc.Core;

namespace SocketClientH1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new Client("localhost", 11000);
            client.Start();

        }
    }
}