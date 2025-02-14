using System;
using System.Net;
using System.Net.Sockets;

namespace ChatServer
{
    internal class Program
    {
        private static List<TcpClient> clients = new List<TcpClient>();
        private static TcpListener server;

        static void Main(string[] args)
        {
            server = new TcpListener(IPAddress.Any, 5000);
            server.Start();
            Console.WriteLine("Server LAN started on port 5000");
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                clients.Add(client);
                Thread thread = new Thread(HandleClient);
                thread.Start(client);
            }
        }

        private static void HandleClient(object? obj)
        {
            TcpClient client = (TcpClient)obj;
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            while (true)
            {
                try
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                    {
                        break;
                    }
                    foreach (TcpClient c in clients)
                    {
                        NetworkStream s = c.GetStream();
                        s.Write(buffer, 0, bytesRead);
                    }
                }
                catch (Exception e)
                {
                    clients.Remove(client);
                    client.Close();
                    break;
                }
            }
        }
    }
}