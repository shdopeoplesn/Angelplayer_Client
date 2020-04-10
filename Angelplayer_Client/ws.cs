using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebSocketSharp;

namespace Angelplayer_Client
{
    public class WS
    {
        //
        // 摘要:
        //     Gets a value indicating whether the WebSocket connection is alive.
        public bool IsAlive { get { return client.IsAlive; } set { } }

        //
        // 摘要:
        //     Gets the state of the WebSocket connection.
        public WebSocketState ReadyState { get { return client.ReadyState; } set { } }

        private WebSocket client = new WebSocket("ws://127.0.0.1:7779");

        public WS() { }

        /// <summary>
        /// 連接至指定Server
        /// </summary>
        /// <param name="host">url</param>
        /// <param name="port">阜號</param>
        /// <returns>連接成功回傳true，否則傳回false</returns>
        public bool ConnectToServer(string host, string port)
        {
            try
            {
                if (client.IsAlive)
                    client.Close();
                client = new WebSocket($@"ws://{host}:{port}");
                client.WaitTime = TimeSpan.FromSeconds(15000);
                client.Connect();
                client.OnMessage += (sender1, e1) =>
                {
                    //MessageBox.Show("server says: " + e1.Data);
                    dynamic data = JsonConvert.DeserializeObject(e1.Data);
                    if (data.message.ToString() == "updateinfo")
                    {
                        //if (data.version.ToString() != LOCAL_VERSION && data.force_update == true) //TODO:預留更新程式
                        //{
                        //    //UpdateClient(data.url.ToString());
                        //}
                    }
                };
                ThreadKeepReconnect();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool DisconnectToServer()
        {
            try
            {
                ReconnectCancelToken.Cancel();
                client.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void DataSend(DataPack data)
        {
            if (ReadyState == WebSocketState.Open)
            {
                String comm;
                try
                {
                    comm = CompressString(JsonConvert.SerializeObject(new
                    {
                        code = 200,
                        cid = data.cid,
                        ipv4 = data.IPv4,
                        mac = data.Mac,
                        device_name = data.DeviceName,
                        os = data.OS,
                        cpu = data.CPUName,
                        mem = data.RAMsize,
                        cpu_usage = data.CPUCurrentUsage,
                        mem_remain = data.AvailableRAM,
                        user_name = data.UserName,
                        apps = data.InstalledApps,
                        process = data.Process,
                        disks = data.disksTypes,
                        disks_usage = data.DisksUsage
                    }));


                    SandMessages(CompressString("SYN"));
                    SandMessages(comm);
                    SandMessages(CompressString("ACK"));
#if DEBUG
                    Console.WriteLine(DateTime.Now + " data sent to server!");
#endif
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void SandMessages(string Msg)
        {
            if (ReadyState == WebSocketState.Open)
            {
                int max_length = 512;
                while (Msg.Length > 0)
                {
                    if (Msg.Length < max_length)
                    {
                        client.Send(Msg);
                        break;
                    }
                    else
                    {
                        int len = Msg.Length;
                        client.Send(Msg.Substring(0, max_length).ToString());
                        Msg = Msg.Substring(max_length, len - max_length);
                    }
                }
            }
        }

        private CancellationTokenSource ReconnectCancelToken;
        public void ThreadKeepReconnect()
        {
            ReconnectCancelToken = new CancellationTokenSource();
            Task.Factory.StartNew(new Action(async () =>
            {
                while (!ReconnectCancelToken.Token.IsCancellationRequested)
                {
                    if (client.ReadyState == WebSocketState.Closed)
                        client.ConnectAsync();
                    await Task.Delay(5000);
                }
            }), ReconnectCancelToken.Token);
        }

        /// <summary>
        ///  compress string to gzip formate based base64 encoding
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Base64 output</returns>
        /// 
        public static string CompressString(string text)
        {
            Byte[] text_bytes = System.Text.Encoding.UTF8.GetBytes(text);
            string compressedBase64 = Convert.ToBase64String(text_bytes);
            return compressedBase64;
        }

    }

    public class SystemPerformanceCounter
    {
        //disks info
        public static PerformanceCounter diskCounter = new PerformanceCounter("LogicalDisk", "% Disk Time", "_Total");
        public static float diskMaxCounter = 1;

        //cpu info
        public static PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
    }




}
