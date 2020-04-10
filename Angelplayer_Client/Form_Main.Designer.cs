
namespace Angelplayer_Client
{
    partial class Form_main
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
            this.lbl_version = new System.Windows.Forms.Label();
            this.lbl_ip = new System.Windows.Forms.Label();
            this.lbl_device_name = new System.Windows.Forms.Label();
            this.lbl_mac = new System.Windows.Forms.Label();
            this.timer_hide = new System.Windows.Forms.Timer(this.components);
            this.txt_cid = new System.Windows.Forms.TextBox();
            this.lbl_cid = new System.Windows.Forms.Label();
            this.lbl_user_name = new System.Windows.Forms.Label();
            this.lbl_os_version = new System.Windows.Forms.Label();
            this.timer_reconnect = new System.Windows.Forms.Timer(this.components);
            this.txt_passwd = new System.Windows.Forms.TextBox();
            this.lbl_cpu = new System.Windows.Forms.Label();
            this.lbl_mem = new System.Windows.Forms.Label();
            this.notifyIcon2 = new System.Windows.Forms.NotifyIcon(this.components);
            this.lbl_mac1 = new System.Windows.Forms.Label();
            this.SettingPanel = new System.Windows.Forms.Panel();
            this.SettingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_host
            // 
            this.txt_host.Location = new System.Drawing.Point(74, 41);
            this.txt_host.Margin = new System.Windows.Forms.Padding(2);
            this.txt_host.Name = "txt_host";
            this.txt_host.Size = new System.Drawing.Size(76, 22);
            this.txt_host.TabIndex = 1;
            this.txt_host.Text = "aisu-alter.nctu.me";
            // 
            // txt_port
            // 
            this.txt_port.Location = new System.Drawing.Point(74, 70);
            this.txt_port.Margin = new System.Windows.Forms.Padding(2);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(76, 22);
            this.txt_port.TabIndex = 2;
            this.txt_port.Text = "7779";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(92, 290);
            this.btn_save.Margin = new System.Windows.Forms.Padding(2);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(59, 28);
            this.btn_save.TabIndex = 3;
            this.btn_save.Text = "unlock";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // lbl_host
            // 
            this.lbl_host.AutoSize = true;
            this.lbl_host.Location = new System.Drawing.Point(38, 47);
            this.lbl_host.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_host.Name = "lbl_host";
            this.lbl_host.Size = new System.Drawing.Size(29, 12);
            this.lbl_host.TabIndex = 4;
            this.lbl_host.Text = "Host:";
            // 
            // lbl_port
            // 
            this.lbl_port.AutoSize = true;
            this.lbl_port.Location = new System.Drawing.Point(38, 77);
            this.lbl_port.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_port.Name = "lbl_port";
            this.lbl_port.Size = new System.Drawing.Size(27, 12);
            this.lbl_port.TabIndex = 5;
            this.lbl_port.Text = "Port:";
            // 
            // lbl_version
            // 
            this.lbl_version.AutoSize = true;
            this.lbl_version.Location = new System.Drawing.Point(284, 323);
            this.lbl_version.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_version.Name = "lbl_version";
            this.lbl_version.Size = new System.Drawing.Size(182, 12);
            this.lbl_version.TabIndex = 6;
            this.lbl_version.Text = "AngelPlayer Control System ver. 0.1b";
            // 
            // lbl_ip
            // 
            this.lbl_ip.AutoSize = true;
            this.lbl_ip.Location = new System.Drawing.Point(9, 6);
            this.lbl_ip.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_ip.Name = "lbl_ip";
            this.lbl_ip.Size = new System.Drawing.Size(32, 12);
            this.lbl_ip.TabIndex = 7;
            this.lbl_ip.Text = "lbl_ip";
            // 
            // lbl_device_name
            // 
            this.lbl_device_name.AutoSize = true;
            this.lbl_device_name.Location = new System.Drawing.Point(9, 66);
            this.lbl_device_name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_device_name.Name = "lbl_device_name";
            this.lbl_device_name.Size = new System.Drawing.Size(84, 12);
            this.lbl_device_name.TabIndex = 8;
            this.lbl_device_name.Text = "lbl_device_name";
            // 
            // lbl_mac
            // 
            this.lbl_mac.AutoSize = true;
            this.lbl_mac.Location = new System.Drawing.Point(81, 26);
            this.lbl_mac.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_mac.Name = "lbl_mac";
            this.lbl_mac.Size = new System.Drawing.Size(24, 12);
            this.lbl_mac.TabIndex = 9;
            this.lbl_mac.Text = "N/A";
            // 
            // timer_hide
            // 
            this.timer_hide.Interval = 1;
            // 
            // txt_cid
            // 
            this.txt_cid.Location = new System.Drawing.Point(75, 8);
            this.txt_cid.Margin = new System.Windows.Forms.Padding(2);
            this.txt_cid.Name = "txt_cid";
            this.txt_cid.Size = new System.Drawing.Size(76, 22);
            this.txt_cid.TabIndex = 10;
            // 
            // lbl_cid
            // 
            this.lbl_cid.AutoSize = true;
            this.lbl_cid.Location = new System.Drawing.Point(11, 15);
            this.lbl_cid.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_cid.Name = "lbl_cid";
            this.lbl_cid.Size = new System.Drawing.Size(59, 12);
            this.lbl_cid.TabIndex = 11;
            this.lbl_cid.Text = "Custom ID:";
            // 
            // lbl_user_name
            // 
            this.lbl_user_name.AutoSize = true;
            this.lbl_user_name.Location = new System.Drawing.Point(9, 46);
            this.lbl_user_name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_user_name.Name = "lbl_user_name";
            this.lbl_user_name.Size = new System.Drawing.Size(73, 12);
            this.lbl_user_name.TabIndex = 12;
            this.lbl_user_name.Text = "lbl_user_name";
            // 
            // lbl_os_version
            // 
            this.lbl_os_version.AutoSize = true;
            this.lbl_os_version.Location = new System.Drawing.Point(9, 86);
            this.lbl_os_version.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_os_version.Name = "lbl_os_version";
            this.lbl_os_version.Size = new System.Drawing.Size(73, 12);
            this.lbl_os_version.TabIndex = 13;
            this.lbl_os_version.Text = "lbl_os_version";
            // 
            // timer_reconnect
            // 
            this.timer_reconnect.Interval = 5000;
            // 
            // txt_passwd
            // 
            this.txt_passwd.Location = new System.Drawing.Point(74, 104);
            this.txt_passwd.Margin = new System.Windows.Forms.Padding(2);
            this.txt_passwd.Name = "txt_passwd";
            this.txt_passwd.Size = new System.Drawing.Size(76, 22);
            this.txt_passwd.TabIndex = 15;
            this.txt_passwd.Visible = false;
            // 
            // lbl_cpu
            // 
            this.lbl_cpu.AutoSize = true;
            this.lbl_cpu.Location = new System.Drawing.Point(9, 103);
            this.lbl_cpu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_cpu.Name = "lbl_cpu";
            this.lbl_cpu.Size = new System.Drawing.Size(40, 12);
            this.lbl_cpu.TabIndex = 16;
            this.lbl_cpu.Text = "lbl_cpu";
            // 
            // lbl_mem
            // 
            this.lbl_mem.AutoSize = true;
            this.lbl_mem.Location = new System.Drawing.Point(9, 124);
            this.lbl_mem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_mem.Name = "lbl_mem";
            this.lbl_mem.Size = new System.Drawing.Size(46, 12);
            this.lbl_mem.TabIndex = 17;
            this.lbl_mem.Text = "lbl_mem";
            // 
            // notifyIcon2
            // 
            this.notifyIcon2.Text = "notifyIcon2";
            this.notifyIcon2.Visible = true;
            // 
            // lbl_mac1
            // 
            this.lbl_mac1.AutoSize = true;
            this.lbl_mac1.Location = new System.Drawing.Point(8, 26);
            this.lbl_mac1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_mac1.Name = "lbl_mac1";
            this.lbl_mac1.Size = new System.Drawing.Size(74, 12);
            this.lbl_mac1.TabIndex = 18;
            this.lbl_mac1.Text = "MAC Address:";
            // 
            // SettingPanel
            // 
            this.SettingPanel.Controls.Add(this.lbl_cid);
            this.SettingPanel.Controls.Add(this.txt_host);
            this.SettingPanel.Controls.Add(this.txt_port);
            this.SettingPanel.Controls.Add(this.lbl_host);
            this.SettingPanel.Controls.Add(this.txt_passwd);
            this.SettingPanel.Controls.Add(this.lbl_port);
            this.SettingPanel.Controls.Add(this.txt_cid);
            this.SettingPanel.Location = new System.Drawing.Point(1, 151);
            this.SettingPanel.Name = "SettingPanel";
            this.SettingPanel.Size = new System.Drawing.Size(182, 134);
            this.SettingPanel.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 343);
            this.Controls.Add(this.SettingPanel);
            this.Controls.Add(this.lbl_mac1);
            this.Controls.Add(this.lbl_mem);
            this.Controls.Add(this.lbl_cpu);
            this.Controls.Add(this.lbl_os_version);
            this.Controls.Add(this.lbl_user_name);
            this.Controls.Add(this.lbl_mac);
            this.Controls.Add(this.lbl_device_name);
            this.Controls.Add(this.lbl_ip);
            this.Controls.Add(this.lbl_version);
            this.Controls.Add(this.btn_save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Angelplayer_Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.SettingPanel.ResumeLayout(false);
            this.SettingPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_host;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label lbl_host;
        private System.Windows.Forms.Label lbl_port;
        private System.Windows.Forms.Label lbl_version;
        private System.Windows.Forms.Label lbl_ip;
        private System.Windows.Forms.Label lbl_device_name;
        private System.Windows.Forms.Label lbl_mac;
        private System.Windows.Forms.Timer timer_hide;
        private System.Windows.Forms.TextBox txt_cid;
        private System.Windows.Forms.Label lbl_cid;
        private System.Windows.Forms.Label lbl_user_name;
        private System.Windows.Forms.Label lbl_os_version;
        private System.Windows.Forms.Timer timer_reconnect;
        private System.Windows.Forms.TextBox txt_passwd;
        private System.Windows.Forms.Label lbl_cpu;
        private System.Windows.Forms.Label lbl_mem;
        private System.Windows.Forms.NotifyIcon notifyIcon2;
        private System.Windows.Forms.Label lbl_mac1;
        private System.Windows.Forms.Panel SettingPanel;
    }
}

