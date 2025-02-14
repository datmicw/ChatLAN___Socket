using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ChatLAN___Socket
{
    public partial class Chat : Form
    {
        private TcpClient client; // client
        private NetworkStream stream; // stream để gửi và nhận dữ liệu
        private Thread receiveThread; // thread để nhận dữ liệu

        public Chat()
        {
            InitializeComponent();
        }

        private void Chat_Load(object sender, EventArgs e)
        {
            try
            {
                client = new TcpClient("192.168.1.5", 5000); // kết nối đến server
                stream = client.GetStream(); // lấy stream từ client

                receiveThread = new Thread(ReceiveMessages); // tạo thread để nhận dữ liệu
                receiveThread.IsBackground = true; // đặt thread chạy ngầm
                receiveThread.Start(); // bắt đầu thread
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            try
            {
                if (client == null || !client.Connected)
                {
                    MessageBox.Show("Chưa kết nối đến server!");
                    return;
                }

                string message = txt_enterMessage.Text;
                byte[] bytes = Encoding.UTF8.GetBytes(message);     // chuyển tin nhắn sang dạng byte
                stream.Write(bytes, 0, bytes.Length);               // gửi tin nhắn

                ltb_showMessage.Items.Add("Tôi: " + message);
                txt_enterMessage.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi tin nhắn: " + ex.Message);
            }
        }

        private void ReceiveMessages()
        {
            byte[] buffer = new byte[1024];
            while (client != null && client.Connected)
            {
                try
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length); // đọc dữ liệu từ server
                    if (bytesRead == 0) break; // server đóng kết nối, thoát vòng lặp

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead); // chuyển byte sang chuỗi
                    Invoke(new Action(() =>
                    {
                        ltb_showMessage.Items.Add("Người khác: " + message);
                    }));
                }
                catch (Exception ex)
                {
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show("Lỗi nhận tin nhắn: " + ex.Message);
                    }));
                    break;
                }
            }
        }

        private void Chat_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // đóng tất cả kết nối
                stream?.Close();
                client?.Close();
                receiveThread?.Abort();
            }
            catch { }
        }
    }
}
