using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Angelplayer_Client
{
    class DataCenter
    {
        public DataPack mydata;

        Task InfoCollecter, DataCollecter;
        CancellationTokenSource CollecterCancellToken;
        public DataCenter()
        {
            mydata = new DataPack();
        }

       public void StartCollect()
        {
            CollecterCancellToken = new CancellationTokenSource();
            InfoCollecter = new Task(InfoCollect, CollecterCancellToken.Token);
            DataCollecter = new Task(DataCollect, CollecterCancellToken.Token);
            InfoCollecter.Start();
            DataCollecter.Start();
        }

        public void StopCollect()
        {
            CollecterCancellToken.Cancel();
        }

        public void RestartCollect()
        {
            StopCollect();
            StartCollect();
        }

        //
        // 摘要:
        //     set CustomID to Datapack.
        public void CollectCustomID(String cid)
        {
            mydata.cid = cid;
        }

        public async void InfoCollect()
        {
            while (!CollecterCancellToken.IsCancellationRequested)
            {
                CollecterCancellToken.Token.ThrowIfCancellationRequested();

                mydata.disksTypes = GetDisksSize();
                mydata.RAMsize = GetRAMSize();
                mydata.CPUName = GetCPU();
                mydata.IPv4 = GetIP4Address();
                mydata.Mac = GetMacAddress();
                mydata.DeviceName = GetDeviceName();
                mydata.UserName = GetUserName();
                mydata.OS = GetOSVersion();

                await Task.Delay(10000);
            }
        }
        public async void DataCollect()
        {
            while (!CollecterCancellToken.IsCancellationRequested)
            {
                CollecterCancellToken.Token.ThrowIfCancellationRequested();

                mydata.DisksUsage = GetDisksUsage();
                mydata.AvailableRAM = GetAvailableRAM();
                mydata.CPUCurrentUsage = GetCurrentCpuUsage();
                mydata.InstalledApps = GetInstalledApps();
                mydata.Process = GetAllProcess();

                await Task.Delay(500);
            }
        }

        /// <summary>
        /// Get disks size
        /// </summary>
        /// <returns>Disks size</returns>
        private static List<DisksType> GetDisksSize()
        {
            List<DisksType> output = new List<DisksType>();
            //取得所有磁碟機的DriveInfo類別
            DriveInfo[] ListDrivesInfo = DriveInfo.GetDrives();
            try
            {
                foreach (DriveInfo vListDrivesInfo in ListDrivesInfo)
                {
                    //使用IsReady屬性判斷裝置是否就緒
                    if (vListDrivesInfo.IsReady)
                    {
                        DisksType disk = new DisksType
                        {
                            name_ = vListDrivesInfo.Name,
                            label_ = vListDrivesInfo.VolumeLabel,
                            type_ = vListDrivesInfo.DriveType.ToString(),
                            format_ = vListDrivesInfo.DriveFormat,
                            size_ = vListDrivesInfo.TotalSize.ToString(),
                            remain_ = vListDrivesInfo.AvailableFreeSpace.ToString()
                        };
                        output.Add(disk);
                    }
                }
            }
            catch (Exception ex)
            {
                DisksType disk = new DisksType
                {
                    name_ = "N/A",
                    label_ = "N/A",
                    type_ = "N/A",
                    format_ = "N/A",
                    size_ = "N/A",
                    remain_ = "N/A"
                };
                output.Add(disk);
            }
            return output;
        }
        /// <summary>
        /// Get current disks usage
        /// </summary>
        /// <returns>current disks usage</returns>
        public static float GetDisksUsage()
        {
            try
            {
                float raw = SystemPerformanceCounter.diskCounter.NextValue();
                if (raw > 100) raw = SystemPerformanceCounter.diskMaxCounter;
#if DEBUG
                Console.WriteLine("disk raw: " + raw.ToString() + " max: " + SystemPerformanceCounter.diskMaxCounter.ToString());
#endif
                float result = (raw / SystemPerformanceCounter.diskMaxCounter) * 100;
                if (raw > SystemPerformanceCounter.diskMaxCounter) SystemPerformanceCounter.diskMaxCounter = raw;
                if (result <= 100.0) return result;
                return 100;
            }
            catch
            {
                return 0;
            }
        }


        /// <summary>
        /// Get RAM size
        /// </summary>
        /// <returns>Total RAM size</returns>
        public static ulong GetRAMSize()
        {
            try
            {
                ulong mem = new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory / 1024 / 1024;
                return mem;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Get current RAM usage
        /// </summary>
        /// <returns>current RAM usage</returns>
        public static float GetAvailableRAM()
        {
            try
            {
                PerformanceCounter ramCounter;
                ramCounter = new PerformanceCounter("Memory", "Available MBytes");
                return ramCounter.NextValue();
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// Get CPU type
        /// </summary>
        /// <returns>CPU type</returns>
        public static string GetCPU()
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
        /// <summary>
        /// Get current CPU usage
        /// </summary>
        /// <returns>current CPU usage</returns>
        public static float GetCurrentCpuUsage()
        {
            return SystemPerformanceCounter.cpuCounter.NextValue();
        }


        /// <summary>
        /// Get Installed Applications from windows machine key
        /// </summary>
        /// <returns>ApplicationType List</returns>
        public static List<ApplicationType> GetInstalledApps()
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
                                //TODO:Add error log
                            }
                        }
                    }
                }
                return output;
            }
            catch
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


        /// <summary>
        /// Get all porcess
        /// </summary>
        /// <returns>porcess</returns>
        public static List<ProcessType> GetAllProcess()
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
                //TODO:Add error Log
            }
        }


        /// <summary>
        /// Get IPv4 Address from System.Net
        /// </summary>
        /// <returns>IP4 Address</returns>
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
                //TODO:Add error Log
                return "N/A";
            }

        }

        /// <summary>
        /// Get Mac Address 
        /// </summary>
        /// <returns>Mac Address </returns>
        public static string GetMacAddress()
        {
            //TODO: 防呆?
            //if (lbl_mac.Text != "N/A") return lbl_mac.Text;

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


        /// <summary>
        /// Get computer/Device Name
        /// </summary>
        /// <returns>Device name</returns>
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

        /// <summary>
        /// Get User Name
        /// </summary>
        /// <returns>User Name</returns>
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


        /// <summary>
        /// Get OS Info.
        /// </summary>
        /// <returns>OS Info.</returns>
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



    }

   public  class DataPack
    {
        public DataPack()
        {
            cid = "N/A";

            disksTypes = new List<DisksType>();
            DisksUsage = -1;

            RAMsize = 0;
            AvailableRAM = -1;

            CPUName = "N/A";
            CPUCurrentUsage = -1;

            InstalledApps = new List<ApplicationType>();

            Process = new List<ProcessType>();

            IPv4 = "N/A";
            Mac = "N/A";
            DeviceName = "N/A";
            UserName = "N/A";
            OS = "N/A";

        }
        public string cid;

        public List<DisksType> disksTypes;
        public float DisksUsage;

        public ulong RAMsize;
        public float AvailableRAM;

        public string CPUName;
        public float CPUCurrentUsage;

        public List<ApplicationType> InstalledApps;

        public List<ProcessType> Process;

        public string IPv4;
        public string Mac;
        public string DeviceName;
        public string UserName;
        public string OS;
    }

    public class ProcessType
    {
        public int pid_ { get; set; }         //process id
        public string name_ { get; set; }         //process name
        public long mem_usage_ { get; set; }          //process mem usage
    }

    public class ApplicationType
    {
        public string name_ { get; set; }         //app name
        public string version_ { get; set; }      // app version
        public string date_ { get; set; }         //app install date
        public string path_ { get; set; }          //app install path
    }

    public class DisksType
    {
        public string name_ { get; set; }         //Disk name
        public string label_ { get; set; }      //Disk Label
        public string type_ { get; set; }         //Disk type
        public string format_ { get; set; }          //Disk data format
        public string size_ { get; set; }          //Disk total Size
        public string remain_ { get; set; }          //Disk Avaliable Size
    }
}
