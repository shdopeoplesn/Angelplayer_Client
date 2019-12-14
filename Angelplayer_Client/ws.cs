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
}
