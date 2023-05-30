using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Newtonsoft.Json;
using System.Threading;

namespace ChatClient
{
    public partial class RegistrationForm : Form
    {


        public RegistrationForm()
        {
            InitializeComponent();
        }

        // Tạo một đối tượng Socket
        Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        int port = 8181;

        // Chuyển đổi đối tượng sang mảng byte
        public byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            // Kiểm tra người dùng xác thực đúng mật khẩu hay không
            if(PasswordTbox.Text != ConfirmPasswordTbox.Text)
            {
                MessageBox.Show("Error! Confirm password not equal Password!");
                ConfirmPasswordTbox.Text = "";
                return;
            }

            // Kết nối đến máy chủ
            clientSocket.Connect(ipAddress, port);

            // Tạo một đối tượng User để gửi đến server
            User user = new User()
            {
                Username = UsernameTbox.Text,
                Password = PasswordTbox.Text,
                DisplayName = DisplayNameTbox.Text,
                Email = EmailTbox.Text,
                Id = 0
            };

            // Gửi tín hiệu cho server biết đây là đăng kí
            byte[] dataByte;
            string signal = "Flag=2";
            dataByte = Encoding.ASCII.GetBytes(signal);
            clientSocket.Send(dataByte);

            // Gửi Form đăng kí đến server
            byte[] userData = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(user));
            clientSocket.Send(userData);




            // Nhận phản hồi đã đăng kí thành công hay không từ server
            byte[] buffer = new byte[clientSocket.ReceiveBufferSize];
            int bytesReceived = clientSocket.Receive(buffer);
            string response = Encoding.ASCII.GetString(buffer, 0, bytesReceived);
            if(response == "Success")
            {
                MessageBox.Show("Register Successfull!");
            } else
            {
                MessageBox.Show("Register Unseccessfull!");
            }
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
        }
    }
}
