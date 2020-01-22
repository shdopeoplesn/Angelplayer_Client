using Microsoft.VisualBasic;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WebSocketSharp;
using static Angelplayer_Client.Encrypt;

namespace Angelplayer_Client
{

    public partial class Form1 : Form
    {

        //declare NotifyIcon to make application show in right-down toolbox
        private System.Windows.Forms.NotifyIcon notifyIcon1;

        private const string FILE_NAME = "saves.dat";
        private const string FILE_KEY = "tachibana_kanade_maji_tenshi";

        /* Get Memory size
         * @return String
         */
        public string GetMemory() 
        {
            try
            {
                ulong mem = new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory / 1024 / 1024;
                return mem.ToString();
            }
            catch
            {
                return "0";
            }
        }


        /* Get CPU type
         * @return String
         */
        public string GetCPU()
        {
            try
            {
                String cpu_name = "";
                ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_Processor");

                foreach (ManagementObject obj in myProcessorObject.Get())
                {
                    cpu_name = obj["Name"].ToString();
                }
                return cpu_name;
            }
            catch 
            {
                return "N/A";
            }
        }

        /* Get CPU Usage
         * @return String
         */
        static PerformanceCounter cpuCounter = new PerformanceCounter(
            "Processor", "% Processor Time", "_Total");
        public static string GetCurrentCpuUsage
        {
            get
            {
                return cpuCounter.NextValue().ToString();
            }
        }

        /* Get RAM Usage
         * @return String
         */
        public string GetAvailableRAM()
        {
            try
            {
                PerformanceCounter ramCounter;
                ramCounter = new PerformanceCounter("Memory", "Available MBytes");
                return ramCounter.NextValue().ToString();
            }
            catch 
            {
                return "0";
            }
        }
        /* Get Installed Applications from windows machine key
         * @return ApplicationType List
         */
        public List<ApplicationType> GetInstalledApps()
        {
            try
            {
                List<ApplicationType> output = new List<ApplicationType>();
                string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
                // search in: LocalMachine_32
                using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(uninstallKey))
                {
                    foreach (string skName in rk.GetSubKeyNames())
                    {
                        using (RegistryKey sk = rk.OpenSubKey(skName))
                        {
                            try
                            {
                                if (sk.GetValue("DisplayName") != null)
                                {
                                    String name = sk.GetValue("DisplayName") == null ? "N/A" : sk.GetValue("DisplayName").ToString();
                                    String version = sk.GetValue("DisplayVersion") == null ? "N/A" : sk.GetValue("DisplayVersion").ToString();
                                    String date = sk.GetValue("InstallDate") == null ? "N/A" : sk.GetValue("InstallDate").ToString();
                                    ApplicationType app = new ApplicationType
                                    {
                                        name_ = name,
                                        version_ = version,
                                        date_ = date,
                                        path_ = ""
                                    };
                                    if (sk.GetValue("InstallSource") != null)
                                    {
                                        app.path_ = sk.GetValue("InstallSource").ToString();
                                    }
                                    else
                                    {
                                        app.path_ = sk.GetValue("InstallLocation") == null ? "N/A" : sk.GetValue("InstallLocation").ToString();
                                    }
                                    output.Add(app);
                                }
                            }
                            catch
                            {
                                //Do nothing
                            }
                        }
                    }
                }
                return output;
            }catch 
            {
                List<ApplicationType> output = new List<ApplicationType>();
                ApplicationType app = new ApplicationType
                {
                    name_ = "N/A",
                    version_ = "N/A",
                    date_ = "N/A",
                    path_ = "N/A"
                };
                output.Add(app);
                return output;
            }
            

            
        }

        /* Get all porcess
         * @return ProcessType List
         */
        public List<ProcessType> GetAllProcess()
        {
            try
            {
                Process[] processlist = Process.GetProcesses();
                var process_list = processlist.OrderBy(item => item.Id).ToList();
                List<ProcessType> output = new List<ProcessType>();
                foreach (Process theprocess in process_list)
                {
                    ProcessType process = new ProcessType
                    {
                        pid_ = theprocess.Id,
                        name_ = theprocess.ProcessName,
                        mem_usage_ = theprocess.WorkingSet64,

                    };
                    output.Add(process);
                }
                return output;
            }
            catch 
            {
                ProcessType process = new ProcessType
                {
                    pid_ = -1,
                    name_ = "N/A",
                    mem_usage_ = -1,
                };
                List<ProcessType> output = new List<ProcessType>();
                output.Add(process);
                return output;
            }
        }


        /* Get IPv4 Address from System.Net
         * @return String
         */
        public static string GetIP4Address()
        {
            try
            {
                string IP4Address = String.Empty;
                foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
                {
                    if (IPA.AddressFamily.ToString() == "InterNetwork")
                    {
                        IP4Address += IPA.ToString() + ",";
                    }
                }
                return IP4Address.TrimEnd(',');
            }
            catch 
            {
                return "N/A";
            }
            
        }

        /* Get IPv4 Address from System.Net
         * @return String
         */
        public static string GetMacAddress() {
            try
            {
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

                string MACAddress = String.Empty;
                foreach (var nic in nics)
                {
                    //Catch Ethernet MAC only
                    if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                    {
                        MACAddress += nic.GetPhysicalAddress().ToString() + ",";
                    }
                }
                return MACAddress.TrimEnd(',');
            }
            catch
            {
                return "N/A";
            }
        }


        /* Get computer/Device Name
         * @return String
         */
        public static string GetDeviceName()
        {
            try
            {
                return Environment.MachineName;
            }
            catch 
            {
                return "N/A";
            }
        }

        /* Get User Name
         * @return String
         */
        public static string GetUserName()
        {
            try
            {
                return Environment.UserName;
            }
            catch
            {
                return "N/A";
            }
        }

        /* Get OS Info.
         * @return String
         */
        public static string GetOSVersion()
        {
            try
            {
                string r = "";
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem"))
                {
                    ManagementObjectCollection information = searcher.Get();
                    if (information != null)
                    {
                        foreach (ManagementObject obj in information)
                        {
                            r = obj["Caption"].ToString() + " - " + obj["OSArchitecture"].ToString();
                        }
                    }
                    r = r.Replace("NT 5.1.2600", "XP");
                    r = r.Replace("NT 5.2.3790", "Server 2003");
                }
                return r;
            }
            catch
            {
                return "unknown OS";
            }
        }

        /* compress string to gzip formate based base64 encoding
         * @return String
         */

        public static string CompressString(string text)
        {
            if (string.IsNullOrEmpty(text)) { return text; }

            byte[] buffer = Encoding.UTF8.GetBytes(text);

            using (var outStream = new MemoryStream())
            using (var zip = new GZipStream(outStream, CompressionMode.Compress))
            {
                zip.Write(buffer, 0, buffer.Length);
                zip.Close();

                string compressedBase64 = Convert.ToBase64String(outStream.ToArray());
                return compressedBase64;
            }
        }

        public void ConnectToSocket(){
            try
            {
                WS.client.Close();
                WS.client = new WebSocket("ws://" + txt_host.Text + ":" + txt_port.Text);
                WS.client.Connect();
                WS.client.OnMessage += (sender1, e1) =>
                    MessageBox.Show("server says: " + e1.Data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //Form UI Initilize
        public void InitUI()
        {
            //if save.dat exist
            if (File.Exists(FILE_NAME))
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

                //get saved data and put to textbox
                string[] data = saves.Split(',');
                txt_host.Text = data[0];
                txt_port.Text = data[1];
                txt_cid.Text = data[2];
                txt_passwd.Text = data[3];

                btn_unlock.Enabled = true;
                btn_save.Enabled = false;
                //disable all of textbox
                txt_cid.Enabled = false;
                txt_host.Enabled = false;
                txt_port.Enabled = false;
            }
            else {
                //if save.dat is not exitst,then doesn't need to unlock
                btn_unlock.Enabled = false;
            }
            //initialize all lbels to print device info.
            lbl_ip.Text = "Local IP: " + GetIP4Address();
            lbl_device_name.Text = "Device Name: " + GetDeviceName();
            lbl_mac.Text = "MAC Address: " + GetMacAddress();
            lbl_user_name.Text = "User Name: " + GetUserName();
            lbl_os_version.Text = "OS version: " + GetOSVersion();
            lbl_cpu.Text = "Processor: " + GetCPU();
            lbl_mem.Text = "RAM: " + GetMemory() + "MB";
        }

        public Form1()
        {
            InitializeComponent();
            //build NotifyIcon
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIcon1.Icon = new Icon("SSS.ico");
            this.notifyIcon1.Text = "Angelplayer Control System";
            this.notifyIcon1.MouseDoubleClick += new MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitUI();
            // Create a auto-send timer 
            System.Timers.Timer timer_auto_send = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer.
            timer_auto_send.Elapsed += timer_send_Tick;
            timer_auto_send.Enabled = true;

            // Create a auto-reconnect timer 
            System.Timers.Timer timer_auto_reconnect = new System.Timers.Timer(5000);
            // Hook up the Elapsed event for the timer.
            timer_auto_reconnect.Elapsed += timer_reconnect_Tick;
            timer_auto_reconnect.Enabled = true;

            //connect to new socket server
            ConnectToSocket();
        }
        private static void ShowWindowsMessage(bool flag)
        {
            //MessageBox.Show(flag.ToString());
        }

        //When Save button had been clicked
        private void btn_save_Click(object sender, EventArgs e)
        {
            //connect to new socket server
            ConnectToSocket();
            
            //delete save.dat when it already existed
            if (File.Exists(FILE_NAME))
            {
                File.Delete(FILE_NAME);
            }

            //get new admin password
            string pw = Interaction.InputBox("input admin password", "input admin password", "", -1, -1);

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

            txt_passwd.Text = pw;
            txt_cid.Enabled = false;
            txt_host.Enabled = false;
            txt_port.Enabled = false;
            btn_save.Enabled = false;
            btn_unlock.Enabled = true;
        }

        private void timer_send_Tick(object sender, EventArgs e)
        {
            //send data when textboxes saved only
            if (btn_unlock.Enabled == true && btn_save.Enabled == false) {
                var ws = WS.client;
                String comm = "";
                try
                {
                    comm = CompressString(JsonConvert.SerializeObject(new
                    {
                        code = 200,
                        cid = txt_cid.Text,
                        ipv4 = GetIP4Address(),
                        mac = GetMacAddress(),
                        device_name = GetDeviceName(),
                        os = GetOSVersion(),
                        cpu = GetCPU(),
                        mem = GetMemory(),
                        cpu_usage = GetCurrentCpuUsage,
                        mem_remain = GetAvailableRAM(),
                        user_name = GetUserName(),
                        apps = GetInstalledApps(),
                        process = GetAllProcess(),
                    }));
                    int max_length = 2000;

                    ws.Send(CompressString("SYN"));
                    while (comm.Length > 0)
                    {
                        if (comm.Length < max_length)
                        {
                            ws.Send(comm);
                            break;
                        }
                        else
                        {
                            int len = comm.Length;
                            ws.Send(comm.Substring(0, max_length).ToString());
                            comm = comm.Substring(max_length, len - max_length);
                        }
                    }
                    ws.Send(CompressString("ACK"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void timer_reconnect_Tick(object sender, EventArgs e)
        {
            WS.client.Connect();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            WS.client.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("This Program can not be closed!");
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

        private void btn_unlock_Click(object sender, EventArgs e)
        {
            string pw = Interaction.InputBox("input admin password", "input admin password");
            if (pw != txt_passwd.Text)
            {
                MessageBox.Show("incorrect password!");
                return;
            }
            btn_save.Enabled = true;
            txt_cid.Enabled = true;
            txt_host.Enabled = true;
            txt_port.Enabled = true;
            btn_unlock.Enabled = false;
        }
    }
}