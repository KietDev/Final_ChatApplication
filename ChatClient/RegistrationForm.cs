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

        IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        int port = 8181;

        string receiveData(Socket clientSocket)
        {
            byte[] buffer = new byte[clientSocket.ReceiveBufferSize];
            int bytesReceived = clientSocket.Receive(buffer);
            string data = Encoding.ASCII.GetString(buffer, 0, bytesReceived);
            return data;
        }

        void sendData(Socket clientSocket, string data)
        {
            byte[] buffer;
            buffer = Encoding.ASCII.GetBytes(data);
            clientSocket.Send(buffer);
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            // Kiểm tra người dùng xác thực đúng mật khẩu hay không
            if(PasswordTbox.Text != ConfirmPasswordTbox.Text)
            {
                MessageBox.Show("Confirm password not match Password!");
                ConfirmPasswordTbox.Text = "";
                return;
            }

            // Tạo một đối tượng Socket
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Kết nối đến máy chủ
            clientSocket.Connect(ipAddress, port);

            // Tạo một đối tượng User để gửi đến server
            User user = new User()
            {
                Username = UsernameTbox.Text,
                Password = PasswordTbox.Text,
                DisplayName = DisplayNameTbox.Text,
                Email = EmailTbox.Text,
            };

            // Gửi Form đăng kí đến server

            string userData = "0x001|" + JsonConvert.SerializeObject(user);
            sendData(clientSocket, userData);

            // Nhận phản hồi đã đăng kí thành công hay không từ server
            string response = receiveData(clientSocket);
            if (response == "0x001")
            {
                MessageBox.Show("Register Successfull!");
                LoginForm login_form = new LoginForm();
                this.Close();
                login_form.Show();
            } else if (response == "0x006") {
                MessageBox.Show("Username exist!");
                UsernameTbox.Text = "";
            } else
            {
                MessageBox.Show("Register Unseccessfull!");
            }
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
        }
    }
}
