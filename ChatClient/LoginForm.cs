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

        // Tạo một đối tượng Socket
        Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        
        // Thiết lập địa chỉ Ip và Port để kết nối đến server
        IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        int port = 8181;

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
                MessageBox.Show("Error! Fill Username and Password!");
                UsernameTbox.Text = "";
                PasswordTbox.Text = "";
                return;
            }

            // Kết nối đến máy chủ
            clientSocket.Connect(ipAddress, port);

            // Gửi tín hiệu cho server biết đây là xác thực
            byte[] dataByte;
            string signal = "Flag=1";
            dataByte = Encoding.ASCII.GetBytes(signal);
            clientSocket.Send(dataByte);
            Thread.Sleep(1000);
            // Gửi form đăng nhập lên server để xác thực
            string formLogin ="Username=" + UsernameTbox.Text + ",Password=" + PasswordTbox.Text;
            dataByte = Encoding.ASCII.GetBytes(formLogin);
            clientSocket.Send(dataByte);

            // Nhận phản hồi từ server
            while (clientSocket.Connected && !clientSocket.Poll(0, SelectMode.SelectRead))
            {
                byte[] buffer = new byte[1024];
                int bytesReceived = clientSocket.Receive(buffer);
                string response = Encoding.ASCII.GetString(buffer, 0, bytesReceived);

                if (response == "Authenticated")
                {
                    MessageBox.Show("Success!");
                    return;
                }
            }

            MessageBox.Show("Username or Password wrong!");
            clientSocket.Close();


        }
    }
}
