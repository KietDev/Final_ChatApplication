
namespace ChatClient
{
    partial class RegistrationForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.UsernameTbox = new System.Windows.Forms.TextBox();
            this.PasswordTbox = new System.Windows.Forms.TextBox();
            this.DisplayNameTbox = new System.Windows.Forms.TextBox();
            this.ConfirmPasswordTbox = new System.Windows.Forms.TextBox();
            this.EmailTbox = new System.Windows.Forms.TextBox();
            this.RegistrationButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(653, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(653, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(653, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Display Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(653, 358);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Email:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(652, 283);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Confirm Password:";
            // 
            // UsernameTbox
            // 
            this.UsernameTbox.Location = new System.Drawing.Point(842, 64);
            this.UsernameTbox.Name = "UsernameTbox";
            this.UsernameTbox.Size = new System.Drawing.Size(150, 31);
            this.UsernameTbox.TabIndex = 5;
            // 
            // PasswordTbox
            // 
            this.PasswordTbox.Location = new System.Drawing.Point(842, 133);
            this.PasswordTbox.Name = "PasswordTbox";
            this.PasswordTbox.Size = new System.Drawing.Size(150, 31);
            this.PasswordTbox.TabIndex = 6;
            // 
            // DisplayNameTbox
            // 
            this.DisplayNameTbox.Location = new System.Drawing.Point(842, 206);
            this.DisplayNameTbox.Name = "DisplayNameTbox";
            this.DisplayNameTbox.Size = new System.Drawing.Size(150, 31);
            this.DisplayNameTbox.TabIndex = 7;
            // 
            // ConfirmPasswordTbox
            // 
            this.ConfirmPasswordTbox.Location = new System.Drawing.Point(842, 277);
            this.ConfirmPasswordTbox.Name = "ConfirmPasswordTbox";
            this.ConfirmPasswordTbox.Size = new System.Drawing.Size(150, 31);
            this.ConfirmPasswordTbox.TabIndex = 8;
            // 
            // EmailTbox
            // 
            this.EmailTbox.Location = new System.Drawing.Point(842, 352);
            this.EmailTbox.Name = "EmailTbox";
            this.EmailTbox.Size = new System.Drawing.Size(150, 31);
            this.EmailTbox.TabIndex = 9;
            // 
            // RegistrationButton
            // 
            this.RegistrationButton.Location = new System.Drawing.Point(781, 453);
            this.RegistrationButton.Name = "RegistrationButton";
            this.RegistrationButton.Size = new System.Drawing.Size(112, 34);
            this.RegistrationButton.TabIndex = 10;
            this.RegistrationButton.Text = "Register";
            this.RegistrationButton.UseVisualStyleBackColor = true;
            this.RegistrationButton.Click += new System.EventHandler(this.RegistrationButton_Click);
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 744);
            this.Controls.Add(this.RegistrationButton);
            this.Controls.Add(this.EmailTbox);
            this.Controls.Add(this.ConfirmPasswordTbox);
            this.Controls.Add(this.DisplayNameTbox);
            this.Controls.Add(this.PasswordTbox);
            this.Controls.Add(this.UsernameTbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RegistrationForm";
            this.Text = "RegistrationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox UsernameTbox;
        private System.Windows.Forms.TextBox PasswordTbox;
        private System.Windows.Forms.TextBox DisplayNameTbox;
        private System.Windows.Forms.TextBox ConfirmPasswordTbox;
        private System.Windows.Forms.TextBox EmailTbox;
        private System.Windows.Forms.Button RegistrationButton;
    }
}