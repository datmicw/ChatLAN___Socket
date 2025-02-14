using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ChatLAN___Socket
{
    public partial class Chat : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private Thread receiveThread;

        public Chat()
        {
            InitializeComponent();
        }

        private void Chat_Load(object sender, EventArgs e)
        {
            try
            {
                client = new TcpClient("192.168.1.5", 5000);
                stream = client.GetStream();

                receiveThread = new Thread(ReceiveMessages);
                receiveThread.IsBackground = true;
                receiveThread.Start();
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
                byte[] bytes = Encoding.UTF8.GetBytes(message);
                stream.Write(bytes, 0, bytes.Length);

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
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break; // server đóng kết nối, thoát vòng lặp

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
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
                stream?.Close();
                client?.Close();
                receiveThread?.Abort();
            }
            catch { }
        }
    }
}
