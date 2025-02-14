using System;
using System.Net;
using System.Net.Sockets;

namespace ChatServer
{
    internal class Program
    {
        private static List<TcpClient> clients = new List<TcpClient>(); // danh sách client
        private static TcpListener server; // server

        static void Main(string[] args)
        {
            server = new TcpListener(IPAddress.Any, 5000); // tạo server
            server.Start(); // bat dau server
            Console.WriteLine("Server LAN started on port 5000");
            while (true) // vòng lặp vô hạn để chấp nhận client
            {
                TcpClient client = server.AcceptTcpClient(); // chấp nhận client
                clients.Add(client); // thêm client vào danh sách
                Thread thread = new Thread(HandleClient); // tạo một thread để xử lý client
                thread.Start(client); // bắt đầu thread
            }
        }

        private static void HandleClient(object? obj)
        {
            TcpClient client = (TcpClient)obj; // ép kiểu obj về TcpClient
            NetworkStream stream = client.GetStream();// lấy stream từ client
            byte[] buffer = new byte[1024]; // buffer để đọc dữ liệu
            while (true)
            {
                try
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length); // đọc dữ liệu từ client
                    if (bytesRead == 0)
                    {
                        break;
                    }
                    foreach (TcpClient c in clients)
                    {
                        NetworkStream s = c.GetStream(); // lấy stream từ client
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