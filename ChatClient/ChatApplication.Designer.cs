
namespace ChatClient
{
    partial class ChatApplication
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            ""}, 0, System.Drawing.Color.Empty, System.Drawing.Color.White, new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point));
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("", 1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("", 2);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("", 3);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("", 4);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("", 5);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatApplication));
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("Change password");
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("History");
            this.listUser = new System.Windows.Forms.ListView();
            this.NameDisplay = new System.Windows.Forms.Label();
            this.MessageBox = new System.Windows.Forms.TextBox();
            this.ButtonSend = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toUser = new System.Windows.Forms.ListBox();
            this.checkPrivate = new System.Windows.Forms.RadioButton();
            this.checkPublic = new System.Windows.Forms.RadioButton();
            this.listEmoji = new System.Windows.Forms.ListView();
            this.imageIcon = new System.Windows.Forms.ImageList(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonSetting = new System.Windows.Forms.Button();
            this.LogOut = new System.Windows.Forms.Button();
            this.DisplayName = new System.Windows.Forms.Label();
            this.panelHistory = new System.Windows.Forms.Panel();
            this.listHistory = new System.Windows.Forms.ListView();
            this.Sender = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonEmoji = new System.Windows.Forms.Button();
            this.ChatRoom = new System.Windows.Forms.RichTextBox();
            this.listSetting = new System.Windows.Forms.ListView();
            this.panelResetPassword = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textNewPassword = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panelHistory.SuspendLayout();
            this.panelResetPassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // listUser
            // 
            this.listUser.HideSelection = false;
            this.listUser.Location = new System.Drawing.Point(1, 77);
            this.listUser.Name = "listUser";
            this.listUser.Size = new System.Drawing.Size(414, 429);
            this.listUser.TabIndex = 0;
            this.listUser.UseCompatibleStateImageBehavior = false;
            this.listUser.View = System.Windows.Forms.View.List;
            this.listUser.SelectedIndexChanged += new System.EventHandler(this.listUser_SelectedIndexChanged);
            // 
            // NameDisplay
            // 
            this.NameDisplay.AutoSize = true;
            this.NameDisplay.Location = new System.Drawing.Point(3, 0);
            this.NameDisplay.Name = "NameDisplay";
            this.NameDisplay.Size = new System.Drawing.Size(93, 25);
            this.NameDisplay.TabIndex = 1;
            this.NameDisplay.Text = "User Hello";
            // 
            // MessageBox
            // 
            this.MessageBox.Location = new System.Drawing.Point(421, 692);
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.Size = new System.Drawing.Size(625, 31);
            this.MessageBox.TabIndex = 4;
            // 
            // ButtonSend
            // 
            this.ButtonSend.Location = new System.Drawing.Point(1123, 689);
            this.ButtonSend.Name = "ButtonSend";
            this.ButtonSend.Size = new System.Drawing.Size(123, 34);
            this.ButtonSend.TabIndex = 5;
            this.ButtonSend.Text = "Send";
            this.ButtonSend.UseVisualStyleBackColor = true;
            this.ButtonSend.Click += new System.EventHandler(this.ButtonSend_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(414, 80);
            this.panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(48, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Connected";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(1, 502);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(414, 95);
            this.panel2.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(133, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 54);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mode";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.progressBar1);
            this.panel3.Controls.Add(this.toUser);
            this.panel3.Controls.Add(this.checkPrivate);
            this.panel3.Controls.Add(this.checkPublic);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Location = new System.Drawing.Point(1, 603);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(414, 144);
            this.panel3.TabIndex = 8;
            // 
            // toUser
            // 
            this.toUser.FormattingEnabled = true;
            this.toUser.ItemHeight = 25;
            this.toUser.Location = new System.Drawing.Point(172, 86);
            this.toUser.Name = "toUser";
            this.toUser.Size = new System.Drawing.Size(131, 29);
            this.toUser.TabIndex = 13;
            this.toUser.SelectedIndexChanged += new System.EventHandler(this.toUser_SelectedIndexChanged);
            // 
            // checkPrivate
            // 
            this.checkPrivate.AutoSize = true;
            this.checkPrivate.Location = new System.Drawing.Point(23, 88);
            this.checkPrivate.Name = "checkPrivate";
            this.checkPrivate.Size = new System.Drawing.Size(90, 29);
            this.checkPrivate.TabIndex = 12;
            this.checkPrivate.TabStop = true;
            this.checkPrivate.Text = "Private";
            this.checkPrivate.UseVisualStyleBackColor = true;
            // 
            // checkPublic
            // 
            this.checkPublic.AutoSize = true;
            this.checkPublic.Location = new System.Drawing.Point(23, 37);
            this.checkPublic.Name = "checkPublic";
            this.checkPublic.Size = new System.Drawing.Size(84, 29);
            this.checkPublic.TabIndex = 11;
            this.checkPublic.TabStop = true;
            this.checkPublic.Text = "Public";
            this.checkPublic.UseVisualStyleBackColor = true;
            // 
            // listEmoji
            // 
            this.listEmoji.BackColor = System.Drawing.Color.White;
            this.listEmoji.HideSelection = false;
            this.listEmoji.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6});
            this.listEmoji.LabelEdit = true;
            this.listEmoji.LargeImageList = this.imageIcon;
            this.listEmoji.Location = new System.Drawing.Point(790, 535);
            this.listEmoji.Name = "listEmoji";
            this.listEmoji.Size = new System.Drawing.Size(317, 151);
            this.listEmoji.SmallImageList = this.imageIcon;
            this.listEmoji.TabIndex = 12;
            this.listEmoji.UseCompatibleStateImageBehavior = false;
            this.listEmoji.Visible = false;
            this.listEmoji.SelectedIndexChanged += new System.EventHandler(this.listEmoji_SelectedIndexChanged);
            // 
            // imageIcon
            // 
            this.imageIcon.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageIcon.ImageStream")));
            this.imageIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.imageIcon.Images.SetKeyName(0, "grinning.png");
            this.imageIcon.Images.SetKeyName(1, "heart_eyes.png");
            this.imageIcon.Images.SetKeyName(2, "laughing.png");
            this.imageIcon.Images.SetKeyName(3, "open_mouth.png");
            this.imageIcon.Images.SetKeyName(4, "sob.png");
            this.imageIcon.Images.SetKeyName(5, "star-struck.png");
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel4.Controls.Add(this.buttonSetting);
            this.panel4.Controls.Add(this.LogOut);
            this.panel4.Controls.Add(this.DisplayName);
            this.panel4.Location = new System.Drawing.Point(421, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(836, 80);
            this.panel4.TabIndex = 9;
            // 
            // buttonSetting
            // 
            this.buttonSetting.Location = new System.Drawing.Point(599, 26);
            this.buttonSetting.Name = "buttonSetting";
            this.buttonSetting.Size = new System.Drawing.Size(97, 35);
            this.buttonSetting.TabIndex = 15;
            this.buttonSetting.Text = "Setting";
            this.buttonSetting.UseVisualStyleBackColor = true;
            this.buttonSetting.Click += new System.EventHandler(this.buttonSetting_Click);
            // 
            // LogOut
            // 
            this.LogOut.Location = new System.Drawing.Point(702, 26);
            this.LogOut.Name = "LogOut";
            this.LogOut.Size = new System.Drawing.Size(112, 34);
            this.LogOut.TabIndex = 15;
            this.LogOut.Text = "Log out";
            this.LogOut.UseVisualStyleBackColor = true;
            this.LogOut.Click += new System.EventHandler(this.LogOut_Click);
            // 
            // DisplayName
            // 
            this.DisplayName.AutoSize = true;
            this.DisplayName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DisplayName.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DisplayName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DisplayName.Location = new System.Drawing.Point(32, 19);
            this.DisplayName.Name = "DisplayName";
            this.DisplayName.Size = new System.Drawing.Size(158, 41);
            this.DisplayName.TabIndex = 14;
            this.DisplayName.Text = "Username";
            // 
            // panelHistory
            // 
            this.panelHistory.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panelHistory.Controls.Add(this.listHistory);
            this.panelHistory.Controls.Add(this.label4);
            this.panelHistory.Location = new System.Drawing.Point(432, 157);
            this.panelHistory.Name = "panelHistory";
            this.panelHistory.Size = new System.Drawing.Size(825, 430);
            this.panelHistory.TabIndex = 3;
            this.panelHistory.Visible = false;
            // 
            // listHistory
            // 
            this.listHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Sender,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listHistory.HideSelection = false;
            this.listHistory.Location = new System.Drawing.Point(14, 50);
            this.listHistory.Name = "listHistory";
            this.listHistory.Size = new System.Drawing.Size(800, 354);
            this.listHistory.TabIndex = 1;
            this.listHistory.UseCompatibleStateImageBehavior = false;
            this.listHistory.View = System.Windows.Forms.View.Details;
            // 
            // Sender
            // 
            this.Sender.Text = "Sender";
            this.Sender.Width = 160;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Receiver";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Content";
            this.columnHeader2.Width = 300;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Date";
            this.columnHeader3.Width = 190;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(385, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "History";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(172, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 34);
            this.button1.TabIndex = 10;
            this.button1.Text = "Add File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonEmoji
            // 
            this.buttonEmoji.Location = new System.Drawing.Point(1069, 692);
            this.buttonEmoji.Name = "buttonEmoji";
            this.buttonEmoji.Size = new System.Drawing.Size(38, 34);
            this.buttonEmoji.TabIndex = 11;
            this.buttonEmoji.Text = "😊";
            this.buttonEmoji.UseVisualStyleBackColor = true;
            this.buttonEmoji.Click += new System.EventHandler(this.buttonEmoji_Click);
            // 
            // ChatRoom
            // 
            this.ChatRoom.Location = new System.Drawing.Point(421, 77);
            this.ChatRoom.Name = "ChatRoom";
            this.ChatRoom.Size = new System.Drawing.Size(836, 597);
            this.ChatRoom.TabIndex = 14;
            this.ChatRoom.Text = "";
            // 
            // listSetting
            // 
            this.listSetting.HideSelection = false;
            this.listSetting.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem7,
            listViewItem8});
            this.listSetting.Location = new System.Drawing.Point(1020, 66);
            this.listSetting.Name = "listSetting";
            this.listSetting.Size = new System.Drawing.Size(168, 85);
            this.listSetting.TabIndex = 16;
            this.listSetting.UseCompatibleStateImageBehavior = false;
            this.listSetting.View = System.Windows.Forms.View.List;
            this.listSetting.Visible = false;
            this.listSetting.SelectedIndexChanged += new System.EventHandler(this.listSetting_SelectedIndexChanged);
            // 
            // panelResetPassword
            // 
            this.panelResetPassword.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelResetPassword.Controls.Add(this.label3);
            this.panelResetPassword.Controls.Add(this.button2);
            this.panelResetPassword.Controls.Add(this.textNewPassword);
            this.panelResetPassword.Location = new System.Drawing.Point(714, 86);
            this.panelResetPassword.Name = "panelResetPassword";
            this.panelResetPassword.Size = new System.Drawing.Size(300, 156);
            this.panelResetPassword.TabIndex = 17;
            this.panelResetPassword.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "New password";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(76, 100);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 34);
            this.button2.TabIndex = 1;
            this.button2.Text = "Reset Password";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textNewPassword
            // 
            this.textNewPassword.Location = new System.Drawing.Point(27, 50);
            this.textNewPassword.Name = "textNewPassword";
            this.textNewPassword.Size = new System.Drawing.Size(249, 31);
            this.textNewPassword.TabIndex = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(265, 44);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(112, 22);
            this.progressBar1.TabIndex = 18;
            // 
            // ChatApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 744);
            this.Controls.Add(this.panelHistory);
            this.Controls.Add(this.panelResetPassword);
            this.Controls.Add(this.listSetting);
            this.Controls.Add(this.listEmoji);
            this.Controls.Add(this.ChatRoom);
            this.Controls.Add(this.buttonEmoji);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ButtonSend);
            this.Controls.Add(this.MessageBox);
            this.Controls.Add(this.listUser);
            this.Name = "ChatApplication";
            this.Text = "ChatApplication";
            this.Load += new System.EventHandler(this.ChatApplication_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panelHistory.ResumeLayout(false);
            this.panelHistory.PerformLayout();
            this.panelResetPassword.ResumeLayout(false);
            this.panelResetPassword.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listUser;
        private System.Windows.Forms.Label NameDisplay;
        private System.Windows.Forms.TextBox MessageBox;
        private System.Windows.Forms.Button ButtonSend;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListBox toUser;
        private System.Windows.Forms.RadioButton checkPrivate;
        private System.Windows.Forms.RadioButton checkPublic;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button LogOut;
        private System.Windows.Forms.Label DisplayName;
        private System.Windows.Forms.Button buttonEmoji;
        private System.Windows.Forms.ListView listEmoji;
        private System.Windows.Forms.RichTextBox ChatRoom;
        private System.Windows.Forms.ImageList imageIcon;
        private System.Windows.Forms.Button buttonSetting;
        private System.Windows.Forms.ListView listSetting;
        private System.Windows.Forms.Panel panelResetPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textNewPassword;
        private System.Windows.Forms.Panel panelHistory;
        private System.Windows.Forms.ListView listHistory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader Sender;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}