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
using System.Threading;

namespace ChatClient
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        // Thiết lập địa chỉ Ip và Port để kết nối đến server
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

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            RegistrationForm regForm = new RegistrationForm();
            this.Hide();
            regForm.Show();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng có để trống Username hay Password
            if(UsernameTbox.Text == "" || PasswordTbox.Text == "")
            {
                MessageBox.Show("Please fill Username and Password!");
                UsernameTbox.Text = "";
                PasswordTbox.Text = "";
                return;
            }

            // Tạo một đối tượng Socket
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Kết nối đến máy chủ
            clientSocket.Connect(ipAddress, port);

            // Gửi tín hiệu cho server biết đây là xác thực
            string formLogin ="0x000|Username=" + UsernameTbox.Text + "/Password=" + PasswordTbox.Text;
            sendData(clientSocket, formLogin);


            // Nhận phản hồi từ server
            string data = receiveData(clientSocket);
            string response = data.Substring(0, 5);
            string name = data.Substring(5, data.Length - 5);

            if (response == "0x000")
            {
                MessageBox.Show("Login Successfully!");
                ChatApplication chat = new ChatApplication(clientSocket, UsernameTbox.Text, name);
                chat.Show();
                this.Hide();
            } else if(response == "0x003")
            {
                MessageBox.Show("Username not exist!");
                clientSocket.Close();

            }
            else if(response == "0x004")
             {
                MessageBox.Show("Password is wrong!");
                clientSocket.Close();

            }
        }
    }
}
