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
using Newtonsoft.Json;
using System.IO;
using System.Drawing.Imaging;

namespace ChatClient
{
    public partial class ChatApplication : Form
    {
        private Socket clientSocket;
        private string username;
        private string display_name;
        private Dictionary<string, string> users = new Dictionary<string, string>();
        public ChatApplication(Socket clientSocket, string username, string display_name)
        {
            InitializeComponent();
            this.clientSocket = clientSocket;
            this.username = username;
            DisplayName.Text = display_name;
            this.display_name = display_name;
        }

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

        void sendImage(Socket clientSocket, Image image)
        {
            var ms = new MemoryStream();
            Bitmap bmp = new Bitmap(image);
            bmp.Save(ms, ImageFormat.Png);
            byte[] buffer = ms.ToArray();
            clientSocket.Send(buffer);
        }

        string findDisplayName(string username)
        {
            foreach(KeyValuePair<string, string> user in users)
            {
                if(user.Key == username)
                {
                    return user.Value;
                }
            }
            return "";
        }

        Image receiveImage(Socket clientSocket)
        {
            Image image;
            byte[] buffer = new byte[clientSocket.ReceiveBufferSize];
            int bytesReceived = clientSocket.Receive(buffer);
            using (MemoryStream ms = new MemoryStream(buffer))
            {
                image = Image.FromStream(ms);
            }
            //ImageConverter convertData = new ImageConverter();
            //Image image = (Image)convertData.ConvertFrom(buffer);
            return image;
        }

        public void updateChatApp()
        {
            while (true)
            {
                string data = receiveData(clientSocket);
                string[] input = data.Split('|');
                if (input[0] == "0x005")
                {
                    string[] datanew = input[1].Split(',');
                    int lendata = datanew.Length;
                    for(int i = 0; i < lendata; i++)
                    {
                        if(datanew[i] == "")
                        {
                            continue;
                        }
                        string[] text = datanew[i].Split('/');
                        users.Add(text[0], text[1]);
                        listUser.Invoke(new Action(() =>
                        {
                            ListViewItem item = new ListViewItem(text[1]);
                            listUser.Items.Add(item);
                        }));
                        toUser.Invoke(new Action(() =>
                        {
                            toUser.Items.Add(text[1]);
                        }));
                    }
                    
                }
                else if (input[0] == "0x008")
                {
                    Message mess = JsonConvert.DeserializeObject<Message>(input[1]);
                    ChatRoom.Invoke(new Action(() =>
                    {
                        if(mess.Receiver == "public")
                        {
                            string name = findDisplayName(mess.Sender);
                            ChatRoom.AppendText("n[Public] from " + name + ": " + mess.Text);
                            ChatRoom.AppendText("\n" + mess.DateSend);
                        } else
                        {
                            string name = findDisplayName(mess.Sender);
                            ChatRoom.AppendText("\n[Private] from " + name + ": " + mess.Text);
                            ChatRoom.AppendText("\n" + mess.DateSend);
                        }
                        //ChatRoom.AppendText("\n" + mess.DateSend + "| " + mess.Text);
                        //ListViewItem item = new ListViewItem(mess.DateSend + "| " + mess.Text);
                        //ChatRoom.Items.Add(item);
                    }));
                }
                else if (input[0] == "0x009")
                {
                    string[] datanew = input[1].Split('/');
                    listUser.Invoke(new Action(() =>
                    {
                        ListViewItem item = listUser.FindItemWithText(datanew[1]);
                        listUser.Items.Remove(item);
                    }));
                    toUser.Invoke(new Action(() =>
                    {
                        int index = toUser.FindString(datanew[1]);
                        toUser.Items.RemoveAt(index);
                    }));
                    users.Remove(datanew[0]);
                }
                else if (input[0] == "0x010")
                {
                    clientSocket.Close();
                    return;
                } else if(input[0] == "0x011")
                {
                    string[] dt = input[1].Split(',');
                    Image image = receiveImage(clientSocket);
                    
                    ChatRoom.Invoke(new Action(() =>
                    {
                        if(dt[1] == "public")
                        {
                            Clipboard.SetImage(image);
                            ChatRoom.AppendText("\n[Public] from " + dt[0] + ": ");
                            ChatRoom.Paste();
                            ChatRoom.AppendText("\n" + dt[2]);

                        } else
                        {
                            Clipboard.SetImage(image);
                            ChatRoom.AppendText("\n[Private] from " + dt[1] + ": ");
                            ChatRoom.Paste();
                            ChatRoom.AppendText("\n" + dt[2]);
                        }
                        //Clipboard.SetImage(image);
                        //ChatRoom.AppendText("\n");
                        //ChatRoom.AppendText(dt[1] + "| " + dt[0] + ": ");
                    }));
                } else if(input[0] == "0x012")
                {
                    string[] dt = input[1].Split(',');
                    //byte[] buffer = new byte[clientSocket.ReceiveBufferSize];
                    //int bytesReceived = clientSocket.Receive(buffer);
                    //byte[] buffer = new byte[1024];
                    byte[] buffer = new byte[clientSocket.ReceiveBufferSize];
                    string filepath = "C:\\Users\\FShop\\Documents\\FileChatApp\\" + dt[2];
                    using (FileStream stream = new FileStream(filepath, FileMode.Create))
                    {
                        int bytesRead = 0;
                        //do
                        //{
                            bytesRead = clientSocket.Receive(buffer);
                            stream.Write(buffer, 0, bytesRead);
                        //}
                        //while (bytesRead > 0);
                    }
                    ChatRoom.Invoke(new Action(() =>
                    {
                        ChatRoom.AppendText("\n");
                        ChatRoom.AppendText(dt[1] + "| " + dt[0] + ": " + dt[2]);
                    }));
                    
                } else if(input[0] == "0x014")
                {
                    Message[] messes = new Message[input.Length - 1];
                    int index = 0;
                    for(int i = 1; i < input.Length; i++)
                    {
                        messes[index] = JsonConvert.DeserializeObject<Message>(input[i]);
                        index++;
                    }
                    
                    listHistory.Invoke(new Action(() =>
                    {
                        for (int i = 0; i < messes.Length; i++)
                        {
                            string[] value = { messes[i].Sender, messes[i].Receiver, messes[i].Text, messes[i].DateSend };
                            ListViewItem item = new ListViewItem(value);
                            listHistory.Items.Add(item);
                        }
                    }));
                }
            }
        }

        private void ChatApplication_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(updateChatApp));
            thread.Start();
        }

        

        private void listUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView ls = sender as ListView;

            if (ls.SelectedItems.Count > 0)
            {
                ListViewItem item_selected = ls.SelectedItems[0];
                string selected = item_selected.Text;
                
                NameDisplay.Text = selected;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        string receiver = "public";

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            string data = MessageBox.Text;
            if(data == "" || receiver == "")
            {
                return;
            }

            if(checkPrivate.Checked == false && checkPublic.Checked == false)
            {
                System.Windows.Forms.MessageBox.Show("chon Mode!");
                return;
            }

            if (checkPrivate.Checked == true)
            {
                if(check == 0)
                {
                    System.Windows.Forms.MessageBox.Show("Chua chon nguoi de gui");
                    return;
                }
                string usrname_receiver = "";
                foreach (KeyValuePair<string, string> user in users)
                {
                    if (user.Value == receiver)
                    {
                        usrname_receiver = user.Key;
                        break;
                    }
                }

                DateTime now = DateTime.Now;
                string date = now.ToString("dd/MM/yyyy HH:mm:ss");

                Message mess = new Message()
                {
                    Sender = username,
                    Receiver = usrname_receiver,
                    DateSend = date,
                    Text = data
                };

                ChatRoom.AppendText("\n[Private] to "+ receiver + ": " + mess.Text);
                ChatRoom.AppendText("\n" + mess.DateSend);
                //ListViewItem item = new ListViewItem(mess.DateSend + "| " + mess.Text);
                //ChatRoom.Items.Add(item);

                string messData = "0x007|" + JsonConvert.SerializeObject(mess);
                sendData(clientSocket, messData);
            } else if(checkPublic.Checked == true)
            {
                DateTime now = DateTime.Now;
                string date = now.ToString("dd/MM/yyyy HH:mm:ss");

                Message mess = new Message()
                {
                    Sender = username,
                    Receiver = "public",
                    DateSend = date,
                    Text = data
                };

                ChatRoom.AppendText("\n[Public] to all user: " + mess.Text);
                ChatRoom.AppendText("\n" + mess.DateSend);

                //ListViewItem item = new ListViewItem(mess.DateSend + "| " + mess.Text);
                //ChatRoom.Items.Add(item);

                string messData = "0x007|" + JsonConvert.SerializeObject(mess);
                sendData(clientSocket, messData);
            }
        }

        int check = 0;

        private void toUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox ls = sender as ListBox;
            if(ls.SelectedIndex != -1)
            {
                check = 1;
                string test = ls.SelectedItem.ToString();
                System.Windows.Forms.MessageBox.Show(test);
                receiver = test;
            }
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            sendData(clientSocket, "0x009|" + username + "/" + display_name);
            LoginForm login = new LoginForm();
            login.Show();
            this.Dispose();

        }

        int count = 0;

        private void buttonEmoji_Click(object sender, EventArgs e)
        {
            if (count == 0)
            {
                count = 1;
                listEmoji.Show();
            }
            else
            {
                count = 0;
                listEmoji.Hide();
            }
        }

        private void listEmoji_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView ls = sender as ListView;

            if (ls.SelectedItems.Count > 0)
            {
                int imageKey = ls.SelectedItems[0].ImageIndex;
                Image image = ls.LargeImageList.Images[imageKey];
                //Clipboard.SetImage(image);
                //ChatRoom.AppendText("\n");
                //ChatRoom.Paste();

                DateTime now = DateTime.Now;
                string date = now.ToString("dd/MM/yyyy HH:mm:ss");

                if (checkPublic.Checked == true)
                {
                    ChatRoom.AppendText("\n[Public] to all user: ");
                    Clipboard.SetImage(image);
                    ChatRoom.Paste();
                    ChatRoom.AppendText("\n" + date);
                    sendData(clientSocket, "0x011|public," + date);
                    Thread.Sleep(1000);
                } else if(checkPrivate.Checked == true)
                {
                    if(check == 0)
                    {
                        System.Windows.Forms.MessageBox.Show("Chua chon nguoi de gui");
                        return;
                    }
                    
                    foreach (KeyValuePair<string, string> ct in users)
                    {
                        if(ct.Value == receiver)
                        {
                            ChatRoom.AppendText("\n[Private] to " + receiver + ": ");
                            Clipboard.SetImage(image);
                            ChatRoom.Paste();
                            ChatRoom.AppendText("\n" + date);
                            sendData(clientSocket, "0x011|" + ct.Key + "," + ct.Value + "," + date);
                            break;
                        }
                    }
                    Thread.Sleep(1000);
                }
                sendImage(clientSocket, image);
                listEmoji.Hide();
                count = 0;
                ls.SelectedItems.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Khởi tạo OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Thiết lập các thuộc tính cho OpenFileDialog
            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Filter = "All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            // Lấy danh sách các tệp đang được chọn
            string[] selectedFiles = { "0" };

            // Mở hộp thoại chọn tệp và xử lý kết quả
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFiles = openFileDialog.FileNames;
                string[] name_file = selectedFiles[0].Split("\\");

                // Xử lý các tệp đã chọn ở đây
                System.Windows.Forms.MessageBox.Show(name_file[name_file.Length - 1]);
            }
            //return;

            foreach(string file in selectedFiles) {
                string[] name_file = file.Split("\\");
                DateTime now = DateTime.Now;
                string date = now.ToString("dd/MM/yyyy HH:mm:ss");

                if (checkPublic.Checked == true)
                {
                    sendData(clientSocket, "0x012|public," + date + "," + name_file[name_file.Length - 1]);
                    Thread.Sleep(1000);
                }
                else if (checkPrivate.Checked == true)
                {
                    if (check == 0)
                    {
                        System.Windows.Forms.MessageBox.Show("Chua chon nguoi de gui");
                        return;
                    }
                    foreach (KeyValuePair<string, string> ct in users)
                    {
                        if (ct.Value == receiver)
                        {
                            sendData(clientSocket, "0x012|" + ct.Key + "," + ct.Value + "," + date + "," + name_file[name_file.Length - 1]);
                            break;
                        }
                    }
                    Thread.Sleep(1000);
                }
                byte[] fileData = File.ReadAllBytes(file);
                clientSocket.Send(fileData);
                ChatRoom.AppendText("\nYou send file");
                //byte[] buffer = new byte[1024];
                //using (FileStream stream = new FileStream(file, FileMode.Open))
                //{
                //    int bytesRead = 0;
                //    do
                //    {
                //        bytesRead = stream.Read(buffer, 0, buffer.Length);
                //        clientSocket.Send(buffer, bytesRead, SocketFlags.None);
                //    }
                //    while (bytesRead > 0);
                //}
            }
        }

        int count1 = 0;
        private void buttonSetting_Click(object sender, EventArgs e)
        {
            if(count1 == 0)
            {
                listSetting.Show();
                count1 = 1;
            } else
            {
                listSetting.Hide();
                count1 = 0;

            }
        }

        int countSetting = 0;
        int countHistory = 0;

        private void listSetting_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView ls = sender as ListView;
            if (ls.SelectedItems.Count > 0)
            {
                string option = ls.SelectedItems[0].Text;
                //System.Windows.Forms.MessageBox.Show(option);
                if(option == "Change password")
                {
                    if (countSetting == 0)
                    {
                        countSetting = 1;
                        panelResetPassword.Show();
                    } else
                    {
                        countSetting = 0;
                        panelResetPassword.Hide();
                        return;
                    }
                    ls.SelectedItems.Clear();
                } else
                {
                    if(countHistory == 0)
                    {
                        countHistory = 1;
                        panelHistory.Show();
                        sendData(clientSocket, "0x014|" + username);
                    } else
                    {
                        countHistory = 0;
                        panelHistory.Hide();
                        return;
                    }
                    ls.SelectedItems.Clear();
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string new_password = textNewPassword.Text;
            if(new_password == "")
            {
                System.Windows.Forms.MessageBox.Show("Please enter new password!");
                return;
            }

            sendData(clientSocket, "0x013|" + username + "/" + new_password);
            System.Windows.Forms.MessageBox.Show("Reset Password Success!");
            panelResetPassword.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
