using Microsoft.VisualBasic;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;
using static Angelplayer_Client.Encrypt;

namespace Angelplayer_Client
{
    public partial class Form_main : Form
    {
        DataCenter DataCenter;
        WS ws = new WS();
        //declare NotifyIcon to make application show in right-down toolbox
        public NotifyIcon notifyIcon1;
        public ContextMenu contextMenu1 = new ContextMenu();

        //version
        public const string LOCAL_VERSION = "0.3.0";
        //data save
        private const string FILE_NAME = "saves.dat";
        private const string FILE_KEY = "tachibana_kanade_maji_tenshi";

        private string adminPW = "root";

        //End self process When system logoff/shutdown/reboot
        private const int WM_QUERYENDSESSION = 0x11;

        public Form_main()
        {
            InitializeComponent();
            //build NotifyIcon
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            //TODO: 路徑確認
            this.notifyIcon1.Icon = new Icon("SSS.ico");

#if DEBUG
            contextMenu1.MenuItems.Add("E&xit", new EventHandler(MenuItem_Exit_Click));
            notifyIcon1.ContextMenu = contextMenu1;
#endif
            this.notifyIcon1.Text = "Angelplayer Control System";
            this.notifyIcon1.MouseDoubleClick += new MouseEventHandler(this.notifyIcon1_MouseDoubleClick);


            DataCenter = new DataCenter();
        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            //windows logoff/shutdown/reboot detected.
            if (m.Msg == WM_QUERYENDSESSION)
            {
                //MessageBox.Show("this is a logoff, shutdown, or reboot");
                Process.GetCurrentProcess().Kill();
            }
            // If this is WM_QUERYENDSESSION, the closing event should be  
            // raised in the base WndProc.  
            base.WndProc(ref m);

        } //WndProc
        //Form UI Initilize
        public void InitUI()
        {
            //if save.dat exist
            if (File.Exists(FILE_NAME))
            {
                string saves = DataFileRead();

                //get saved data and put to textbox
                string[] data = saves.Split(',');
                txt_host.Text = data[0];
                txt_port.Text = data[1];
                txt_cid.Text = data[2];
                txt_passwd.Text = data[3];



                InfoIsLock = true;
                btn_save.Enabled = true;

                //disable all of textbox
                SettingPanel.Enabled = false;


            }
            else
            {
                //if save.dat is not exitst,then doesn't need to unlock
                InfoIsLock = false;
                btn_save.Text = "Save";
            }


        }



        private static string DataFileRead()
        {
            string saves = "";
            using (FileStream fs = new FileStream(FILE_NAME, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader r = new BinaryReader(fs))
                {
                    saves = r.ReadString();
                }
            }
            saves = StringEncrypt.aesDecryptBase64(saves, FILE_KEY);
            return saves;
        }





        private async void Form1_Load(object sender, EventArgs e)
        {
            ThreadStartUpdateInfo();
            InitUI();

            //start collect data tasks
            DataCenter.StartCollect();

            //set CustomID of Datapack
            DataCenter.CollectCustomID(txt_cid.Text);

            await ConnectToSocket();

            ThreadStartKeepSendData();
            // Start auto-reconnect thread
            //Hide Form and let notifyIcon visible(small icon in right bottom)
            ThreadKeepHide();

        }
        private static void ShowWindowsMessage(bool flag)
        {
            //MessageBox.Show(flag.ToString());
        }


        public async Task ConnectToSocket()
        {
            try
            {
                await Task.Run(() =>
                {
                    ws.ConnectToServer(txt_host.Text, txt_port.Text);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        bool InfoIsLock = false;


        private void InfoSave(string pw)
        {
            //delete save.dat when it already existed
            if (File.Exists(FILE_NAME))
                File.Delete(FILE_NAME);

            //get new admin password
            DataCenter.mydata.cid = txt_cid.Text;
            //write to save.dat
            using (FileStream fs = new FileStream(FILE_NAME, FileMode.CreateNew))
            {
                using (BinaryWriter w = new BinaryWriter(fs))
                {
                    string saves = txt_host.Text + ",";
                    saves += txt_port.Text + ",";
                    saves += txt_cid.Text + ",";
                    saves += pw;
                    saves = StringEncrypt.aesEncryptBase64(saves, FILE_KEY);
                    w.Write(saves);
                }
            }
        }


        public bool UpdateClient(String update_url)
        {
            try
            {
                var client = new WebClient();
                if (File.Exists(@"Angelplayer_Client_2.exe"))
                {
                    File.Delete(@"Angelplayer_Client_2.exe");
                }
                client.DownloadFile(update_url, "Angelplayer_Client_2.exe");
                Process.Start("update.bat", "");
                return true;
            }
            catch
            {
                MessageBox.Show("update failed");
                return false;
            }
        }


        private async void btn_save_Click(object sender, EventArgs e)
        {
            if (!InfoIsLock)
            {

                adminPW = Interaction.InputBox("input admin password", "input admin password", "", -1, -1);

                InfoSave(adminPW);

                txt_passwd.Text = adminPW;
                SettingPanel.Enabled = false;
                btn_save.Text = "unlock";
            }
            else
            {
                string input = Interaction.InputBox("input admin password", "input admin password");
                if (input != adminPW)
                {
                    MessageBox.Show("incorrect password!");
                    return;
                }
                SettingPanel.Enabled = true;
                btn_save.Text = "save";
            }
            InfoIsLock = !InfoIsLock;

            //set CustomID of Datapack
            DataCenter.CollectCustomID(txt_cid.Text);

            //connect to new socket server
            await ConnectToSocket();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            ws.DisconnectToServer();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            //MessageBox.Show("This Program can not be closed!");
            if (!mannualClose)
                e.Cancel = true;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            //when click minimized button,then hide form and show notifyicon
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //make Form show again
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.notifyIcon1.Visible = false;
        }

        /// <summary>
        /// DEBUG時的手動關閉選擇
        /// </summary>
        private bool mannualClose = false;
        private void MenuItem_Exit_Click(object sender, EventArgs e)
        {
            mannualClose = true;
            this.Close();
        }


        private CancellationTokenSource KeepSendCancelToken;
        private void ThreadStartKeepSendData()
        {
            KeepSendCancelToken = new CancellationTokenSource();
            Task.Factory.StartNew(new Action(async () =>
            {
                while (!KeepSendCancelToken.IsCancellationRequested)
                {
                    if (InfoIsLock == true && ws.ReadyState == WebSocketState.Open)
                        ws.DataSend(DataCenter.mydata);

                    await Task.Delay(1000);
                }

            }
            ), KeepSendCancelToken.Token);
            //TODO: 連線錯誤防呆
            //send data when textboxes saved and websocket opened only


            ////sender was done,wait elapsed timer next toggle
            //Console.WriteLine("Disk Load: " + GetDisksUsage());
        }

        public void ThreadStartUpdateInfo()
        {
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        lbl_ip.Text = "Local IP: " + DataCenter.mydata.IPv4;
                        lbl_device_name.Text = "Device Name: " + DataCenter.mydata.DeviceName;
                        lbl_mac.Text = DataCenter.mydata.Mac;
                        lbl_user_name.Text = "User Name: " + DataCenter.mydata.UserName;
                        lbl_os_version.Text = "OS version: " + DataCenter.mydata.OS;
                        lbl_cpu.Text = "Processor: " + DataCenter.mydata.CPUName;
                        lbl_mem.Text = "RAM: " + DataCenter.mydata.RAMsize + "MB";
                        lbl_version.Text = "AngelPlayer Control System ver. " + LOCAL_VERSION;
                    }));


                    await Task.Delay(500);
                }


            });
        }

        private void ThreadKeepHide()
        {
            Task.Factory.StartNew(new Action(async () =>
            {
                while (true)
                {
                    if (this.Size.Height < this.MinimumSize.Height)
                    {
                        this.Hide();
                        this.notifyIcon1.Visible = true;
                    }
                    await Task.Delay(10);
                }
            }));
        }
    }

}