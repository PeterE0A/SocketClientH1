using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Reflection.PortableExecutable;
using System;


namespace SocketClientH1
{
    internal class Client
    {
        private TcpClient client;
        private StreamReader reader;
        private StreamWriter writer;

        public Client(string hostname, int port)
        {
            client = new TcpClient(hostname, port);
            reader = new StreamReader(client.GetStream());
            writer = new StreamWriter(client.GetStream());
        }

        public void Start()
        {
            Console.WriteLine("Connected to server.");
            Console.WriteLine("Waiting for game to start...");

            while (true)
            {
                var message = reader.ReadLine();
                if (message.StartsWith("Welcome"))
                {
                    Console.WriteLine(message);
                    break;
                }
            }

            while (true)
            {
                Console.Write("Enter your move (rock, paper, or scissors): ");
                var move = Console.ReadLine();
                writer.WriteLine(move);
                writer.Flush();

                var response1 = reader.ReadLine();
                var response2 = reader.ReadLine();
                var result = reader.ReadLine();

                Console.WriteLine(response1);
                Console.WriteLine(response2);
                Console.WriteLine(result);
            }
        }
    }


}


