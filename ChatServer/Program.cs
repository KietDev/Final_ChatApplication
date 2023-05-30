using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace ChatServer
{
    class Program
    {
        static void Main(string[] args)
        {
            startServer();
        }

        // Khởi động server
        static void startServer()
        {
            // Cấu hình để kết nối với realtime database Firebase
            IFirebaseConfig ifc = new FirebaseConfig()
            {
                AuthSecret = "OW9ry0nAgG5IqWqpFPU3e37W6Z75C9i3IdDy5QZ7",
                BasePath = "https://chatapplication-95820-default-rtdb.firebaseio.com/"
            };
            IFirebaseClient client;
            client = new FireSharp.FirebaseClient(ifc);

            // Tạo đối tượng socket để lắng nghe
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Thiết lập địa chỉ Ip và Port
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            int port = 8181;

            listener.Bind(new IPEndPoint(ipAddress, port));
            listener.Listen(-1);
            Console.WriteLine("Server is running!");

            // Chấp nhận các kết nối từ phía client
            while(true)
            {
                Socket handler = listener.Accept();
                Console.Write("New Client Conncect!");

                Thread thread = new Thread(() => handlerClient(ref handler, client));
                thread.Start();
            }
        }

        static bool handlerLogin(Socket handler, IFirebaseClient client)
        {
            // Nhận form login từ client
            byte[] data = new byte[1024];
            int bytes = handler.Receive(data);
            string response = Encoding.ASCII.GetString(data, 0, bytes);

            string username = "", password = "";

            // Tách Username, Password trong form login
            string[] strs = response.Split(',');
            foreach(string str in strs)
            {
                string[] strSplit = str.Split('=');
                if(str[0] == 'U')
                {
                    username = strSplit[1];
                } else
                {
                    password = strSplit[1];
                }
            }

            // Truy vấn Username trên database
            FirebaseResponse res = client.Get(@"Users/" + username);
            User user = res.ResultAs<User>();

            // Kiểm tra username có tồn tại hay không
            if(user == null)
            {
                return false;
            }

            // Kiểm tra password
            if(password == user.Password)
            {
                byte[] dataSend;
                dataSend = Encoding.ASCII.GetBytes("Authenticated");
                handler.Send(dataSend);
                return true;
            }
            return false;
        }

        static void handlerRegister(Socket handler, IFirebaseClient client)
        {
            // Nhận form đăng kí từ client
            byte[] data = new byte[handler.ReceiveBufferSize];
            int bytes = handler.Receive(data);
            string response = Encoding.ASCII.GetString(data, 0, bytes);

            // Lưu đối tượng nhận được vào đối tượng user
            string dataJson = Encoding.ASCII.GetString(data);
            User user = JsonConvert.DeserializeObject<User>(response);

            // Đẩy dữ liệu lên database
            SetResponse set = client.Set(@"Users/" + user.Username, user);

            // Phản hồi xác nhận cho client
            byte[] dataSend;
            dataSend = Encoding.ASCII.GetBytes("Success");
            handler.Send(dataSend);
        }

        static void handlerClient(ref Socket handler, IFirebaseClient client)
        {
            while (true)
            {
                byte[] buffer = new byte[handler.ReceiveBufferSize];
                int bytesReceived = handler.Receive(buffer);
                string response = Encoding.ASCII.GetString(buffer, 0, bytesReceived);
                if (response == "Flag=1")
                {
                    bool check = handlerLogin(handler, client);
                    if(check == false)
                    {
                        handler.Close();
                        break;
                    }
                } else if(response == "Flag=2")
                {
                    handlerRegister(handler, client);
                    handler.Close();
                    break;
                }
            }
            handler.Close();
        }
    }
}
