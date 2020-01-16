using System;
using System.Collections.Generic;
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
}
