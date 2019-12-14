using Microsoft.Win32;
using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;
using WebSocketSharp;

namespace Angelplayer_Client
{
    public partial class Form1 : Form
    {
        /* Get Installed Applications from windows machine key
         * @return String
         */
        public string GetInstalledApps()
        {
            string output = "";
            string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(uninstallKey))
            {
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        try
                        {
                            output += sk.GetValue("DisplayName").ToString() + ",";
                        }
                        catch (Exception ex)
                        { }
                    }
                }
            }
            return output.TrimEnd(',');
        }

        /* Get IPv4 Address from System.Net
         * @return String
         */
        public static string GetIP4Address()
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

        /* Get IPv4 Address from System.Net
         * @return String
         */
        public static string GetMacAddress() {
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
            return MACAddress.TrimEnd(','); ;
        }


        /* Get computer/Device Name
         * @return String
         */
        public static string GetDeviceName()
        {
            return Environment.MachineName;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //initialize all lbels to print device info.
            lbl_ip.Text = "Local IP: " + GetIP4Address();
            lbl_device_name.Text = "Device Name: " + GetDeviceName();
            lbl_mac.Text = "MAC Address: " + GetMacAddress();
        }
        private static void ShowWindowsMessage(bool flag)
        {
            //MessageBox.Show(flag.ToString());
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            var ws = WS.client;
            Action<bool> completed = ShowWindowsMessage;
            ws.SendAsync("test", completed);
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            try{
                WS.client.Close();
                WS.client = new WebSocket("ws://" + txt_host.Text + ":" + txt_port.Text);
                WS.client.Connect();
                WS.client.OnMessage += (sender1, e1) =>
                    MessageBox.Show("server says: " + e1.Data);
                MessageBox.Show("Connect to server successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void timer_send_Tick(object sender, EventArgs e)
        {
            var ws = WS.client;
            Action<bool> completed = ShowWindowsMessage;
            String comm = txt_cid.Text + ":";
            comm += GetIP4Address() + ":";
            comm += GetDeviceName() + ":";
            comm += GetMacAddress();
            comm += GetInstalledApps();
            int max_length = 1000;
            while (comm.Length > 0) {
                if (comm.Length < max_length)
                {
                    ws.SendAsync(comm, completed);
                    break;
                }
                else {
                    int len = comm.Length;
                    ws.SendAsync(comm.Substring(0, max_length).ToString(), completed);
                    comm = comm.Substring(max_length, len - max_length);
                }
                Thread.Sleep(10);
            }
            
        }
    }
}