
namespace Angelplayer_Client
{
    partial class Form1
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
            this.txt_host = new System.Windows.Forms.TextBox();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.lbl_host = new System.Windows.Forms.Label();
            this.lbl_port = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_ip = new System.Windows.Forms.Label();
            this.lbl_device_name = new System.Windows.Forms.Label();
            this.lbl_mac = new System.Windows.Forms.Label();
            this.timer_send = new System.Windows.Forms.Timer(this.components);
            this.txt_cid = new System.Windows.Forms.TextBox();
            this.lbl_cid = new System.Windows.Forms.Label();
            this.lbl_user_name = new System.Windows.Forms.Label();
            this.lbl_os_version = new System.Windows.Forms.Label();
            this.timer_reconnect = new System.Windows.Forms.Timer(this.components);
            this.btn_unlock = new System.Windows.Forms.Button();
            this.txt_passwd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_host
            // 
            this.txt_host.Location = new System.Drawing.Point(70, 159);
            this.txt_host.Margin = new System.Windows.Forms.Padding(2);
            this.txt_host.Name = "txt_host";
            this.txt_host.Size = new System.Drawing.Size(76, 20);
            this.txt_host.TabIndex = 1;
            this.txt_host.Text = "127.0.0.1";
            // 
            // txt_port
            // 
            this.txt_port.Location = new System.Drawing.Point(70, 184);
            this.txt_port.Margin = new System.Windows.Forms.Padding(2);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(76, 20);
            this.txt_port.TabIndex = 2;
            this.txt_port.Text = "7779";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(86, 207);
            this.btn_save.Margin = new System.Windows.Forms.Padding(2);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(59, 30);
            this.btn_save.TabIndex = 3;
            this.btn_save.Text = "save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // lbl_host
            // 
            this.lbl_host.AutoSize = true;
            this.lbl_host.Location = new System.Drawing.Point(35, 162);
            this.lbl_host.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_host.Name = "lbl_host";
            this.lbl_host.Size = new System.Drawing.Size(32, 13);
            this.lbl_host.TabIndex = 4;
            this.lbl_host.Text = "Host:";
            // 
            // lbl_port
            // 
            this.lbl_port.AutoSize = true;
            this.lbl_port.Location = new System.Drawing.Point(35, 187);
            this.lbl_port.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_port.Name = "lbl_port";
            this.lbl_port.Size = new System.Drawing.Size(29, 13);
            this.lbl_port.TabIndex = 5;
            this.lbl_port.Text = "Port:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 258);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "AngelPlayer Control System ver. 0.1b";
            // 
            // lbl_ip
            // 
            this.lbl_ip.AutoSize = true;
            this.lbl_ip.Location = new System.Drawing.Point(9, 6);
            this.lbl_ip.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_ip.Name = "lbl_ip";
            this.lbl_ip.Size = new System.Drawing.Size(31, 13);
            this.lbl_ip.TabIndex = 7;
            this.lbl_ip.Text = "lbl_ip";
            // 
            // lbl_device_name
            // 
            this.lbl_device_name.AutoSize = true;
            this.lbl_device_name.Location = new System.Drawing.Point(9, 72);
            this.lbl_device_name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_device_name.Name = "lbl_device_name";
            this.lbl_device_name.Size = new System.Drawing.Size(87, 13);
            this.lbl_device_name.TabIndex = 8;
            this.lbl_device_name.Text = "lbl_device_name";
            // 
            // lbl_mac
            // 
            this.lbl_mac.AutoSize = true;
            this.lbl_mac.Location = new System.Drawing.Point(9, 28);
            this.lbl_mac.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_mac.Name = "lbl_mac";
            this.lbl_mac.Size = new System.Drawing.Size(43, 13);
            this.lbl_mac.TabIndex = 9;
            this.lbl_mac.Text = "lbl_mac";
            // 
            // timer_send
            // 
            this.timer_send.Interval = 10000;
            this.timer_send.Tick += new System.EventHandler(this.timer_send_Tick);
            // 
            // txt_cid
            // 
            this.txt_cid.Location = new System.Drawing.Point(70, 136);
            this.txt_cid.Margin = new System.Windows.Forms.Padding(2);
            this.txt_cid.Name = "txt_cid";
            this.txt_cid.Size = new System.Drawing.Size(76, 20);
            this.txt_cid.TabIndex = 10;
            // 
            // lbl_cid
            // 
            this.lbl_cid.AutoSize = true;
            this.lbl_cid.Location = new System.Drawing.Point(9, 139);
            this.lbl_cid.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_cid.Name = "lbl_cid";
            this.lbl_cid.Size = new System.Drawing.Size(59, 13);
            this.lbl_cid.TabIndex = 11;
            this.lbl_cid.Text = "Custom ID:";
            // 
            // lbl_user_name
            // 
            this.lbl_user_name.AutoSize = true;
            this.lbl_user_name.Location = new System.Drawing.Point(9, 50);
            this.lbl_user_name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_user_name.Name = "lbl_user_name";
            this.lbl_user_name.Size = new System.Drawing.Size(75, 13);
            this.lbl_user_name.TabIndex = 12;
            this.lbl_user_name.Text = "lbl_user_name";
            // 
            // lbl_os_version
            // 
            this.lbl_os_version.AutoSize = true;
            this.lbl_os_version.Location = new System.Drawing.Point(9, 93);
            this.lbl_os_version.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_os_version.Name = "lbl_os_version";
            this.lbl_os_version.Size = new System.Drawing.Size(74, 13);
            this.lbl_os_version.TabIndex = 13;
            this.lbl_os_version.Text = "lbl_os_version";
            // 
            // timer_reconnect
            // 
            this.timer_reconnect.Interval = 1000;
            this.timer_reconnect.Tick += new System.EventHandler(this.timer_reconnect_Tick);
            // 
            // btn_unlock
            // 
            this.btn_unlock.Location = new System.Drawing.Point(9, 207);
            this.btn_unlock.Margin = new System.Windows.Forms.Padding(2);
            this.btn_unlock.Name = "btn_unlock";
            this.btn_unlock.Size = new System.Drawing.Size(59, 30);
            this.btn_unlock.TabIndex = 14;
            this.btn_unlock.Text = "unlock";
            this.btn_unlock.UseVisualStyleBackColor = true;
            this.btn_unlock.Click += new System.EventHandler(this.btn_unlock_Click);
            // 
            // txt_passwd
            // 
            this.txt_passwd.Location = new System.Drawing.Point(149, 184);
            this.txt_passwd.Margin = new System.Windows.Forms.Padding(2);
            this.txt_passwd.Name = "txt_passwd";
            this.txt_passwd.Size = new System.Drawing.Size(76, 20);
            this.txt_passwd.TabIndex = 15;
            this.txt_passwd.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 276);
            this.Controls.Add(this.txt_passwd);
            this.Controls.Add(this.btn_unlock);
            this.Controls.Add(this.lbl_os_version);
            this.Controls.Add(this.lbl_user_name);
            this.Controls.Add(this.lbl_cid);
            this.Controls.Add(this.txt_cid);
            this.Controls.Add(this.lbl_mac);
            this.Controls.Add(this.lbl_device_name);
            this.Controls.Add(this.lbl_ip);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_port);
            this.Controls.Add(this.lbl_host);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.txt_port);
            this.Controls.Add(this.txt_host);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Angelplayer_Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_host;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label lbl_host;
        private System.Windows.Forms.Label lbl_port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_ip;
        private System.Windows.Forms.Label lbl_device_name;
        private System.Windows.Forms.Label lbl_mac;
        private System.Windows.Forms.Timer timer_send;
        private System.Windows.Forms.TextBox txt_cid;
        private System.Windows.Forms.Label lbl_cid;
        private System.Windows.Forms.Label lbl_user_name;
        private System.Windows.Forms.Label lbl_os_version;
        private System.Windows.Forms.Timer timer_reconnect;
        private System.Windows.Forms.Button btn_unlock;
        private System.Windows.Forms.TextBox txt_passwd;
    }
}

