using Microsoft.Win32;
using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using WebSocketSharp;

namespace Angelplayer_Client
{
    public partial class Form1 : Form
    {
        public void GetInstalledApps()
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
                            output += sk.GetValue("DisplayName").ToString() + "\r\n";
                        }
                        catch (Exception ex)
                        { }
                    }
                }
            }
            MessageBox.Show(output);
        }

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

        public static string GetMacAddress() {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

            string MACAddress = String.Empty;
            foreach (var nic in nics)
            {
                // 只回傳 Ethernet 網卡的 MAC
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    MACAddress += nic.GetPhysicalAddress().ToString() + ",";
                }    
            }
            return MACAddress.TrimEnd(','); ;
        }
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
            lbl_ip.Text = "Local IP: " + GetIP4Address();
            lbl_device_name.Text = "Device Name: " + GetDeviceName();
            lbl_mac.Text = "MAC Address: " + GetMacAddress();
        }
        private static void ShowWindowsMessage(bool flag)
        {
            //MessageBox.Show(flag.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ws = WS.client;
            ws.OnMessage += (sender1, e1) =>
                MessageBox.Show("server says: " + e1.Data);
            Action<bool> completed = ShowWindowsMessage;
            ws.SendAsync("Hello World", completed);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try{
                WS.client.Close();
                WS.client = new WebSocket("ws://" + txt_host.Text + ":" + txt_port.Text);
                WS.client.Connect();
                MessageBox.Show("Connect to server successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            } 
        }
    }
}