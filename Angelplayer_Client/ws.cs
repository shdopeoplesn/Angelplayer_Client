using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace Angelplayer_Client
{
    public class WS
    {
        public static WebSocket client = new WebSocket("ws://127.0.0.1:7779");
    }

    public class SystemPerformanceCounter 
    {
        //disks info
        public static PerformanceCounter diskCounter = new PerformanceCounter("LogicalDisk", "% Disk Time", "_Total");
        public static float diskMaxCounter = 1;

        //cpu info
        public static PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
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
