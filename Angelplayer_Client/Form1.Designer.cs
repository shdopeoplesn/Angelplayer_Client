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
            this.button1 = new System.Windows.Forms.Button();
            this.txt_host = new System.Windows.Forms.TextBox();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.lbl_host = new System.Windows.Forms.Label();
            this.lbl_port = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_ip = new System.Windows.Forms.Label();
            this.lbl_device_name = new System.Windows.Forms.Label();
            this.lbl_mac = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(434, 414);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_host
            // 
            this.txt_host.Location = new System.Drawing.Point(59, 421);
            this.txt_host.Name = "txt_host";
            this.txt_host.Size = new System.Drawing.Size(100, 22);
            this.txt_host.TabIndex = 1;
            // 
            // txt_port
            // 
            this.txt_port.Location = new System.Drawing.Point(219, 424);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(100, 22);
            this.txt_port.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(339, 415);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 37);
            this.button2.TabIndex = 3;
            this.button2.Text = "connect";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbl_host
            // 
            this.lbl_host.AutoSize = true;
            this.lbl_host.Location = new System.Drawing.Point(12, 424);
            this.lbl_host.Name = "lbl_host";
            this.lbl_host.Size = new System.Drawing.Size(41, 17);
            this.lbl_host.TabIndex = 4;
            this.lbl_host.Text = "Host:";
            // 
            // lbl_port
            // 
            this.lbl_port.AutoSize = true;
            this.lbl_port.Location = new System.Drawing.Point(172, 424);
            this.lbl_port.Name = "lbl_port";
            this.lbl_port.Size = new System.Drawing.Size(38, 17);
            this.lbl_port.TabIndex = 5;
            this.lbl_port.Text = "Port:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(545, 424);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "AngelPlayer Control System ver. 0.1b";
            // 
            // lbl_ip
            // 
            this.lbl_ip.AutoSize = true;
            this.lbl_ip.Location = new System.Drawing.Point(12, 35);
            this.lbl_ip.Name = "lbl_ip";
            this.lbl_ip.Size = new System.Drawing.Size(41, 17);
            this.lbl_ip.TabIndex = 7;
            this.lbl_ip.Text = "lbl_ip";
            // 
            // lbl_device_name
            // 
            this.lbl_device_name.AutoSize = true;
            this.lbl_device_name.Location = new System.Drawing.Point(12, 9);
            this.lbl_device_name.Name = "lbl_device_name";
            this.lbl_device_name.Size = new System.Drawing.Size(114, 17);
            this.lbl_device_name.TabIndex = 8;
            this.lbl_device_name.Text = "lbl_device_name";
            // 
            // lbl_mac
            // 
            this.lbl_mac.AutoSize = true;
            this.lbl_mac.Location = new System.Drawing.Point(12, 61);
            this.lbl_mac.Name = "lbl_mac";
            this.lbl_mac.Size = new System.Drawing.Size(56, 17);
            this.lbl_mac.TabIndex = 9;
            this.lbl_mac.Text = "lbl_mac";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 459);
            this.Controls.Add(this.lbl_mac);
            this.Controls.Add(this.lbl_device_name);
            this.Controls.Add(this.lbl_ip);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_port);
            this.Controls.Add(this.lbl_host);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txt_port);
            this.Controls.Add(this.txt_host);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Angelplayer_Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_host;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbl_host;
        private System.Windows.Forms.Label lbl_port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_ip;
        private System.Windows.Forms.Label lbl_device_name;
        private System.Windows.Forms.Label lbl_mac;
    }
}

