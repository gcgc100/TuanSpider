using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace GetXmlData
{
    public class GetSocket
    {
        private static Socket ConnectSocket(string server, int port)
        {
            Socket s = null;
            IPHostEntry hostEntry = null;

            // Get host related information.
            hostEntry = Dns.GetHostEntry(server);

            // Loop through the AddressList to obtain the supported AddressFamily. This is to avoid
            // an exception that occurs when the host IP Address is not compatible with the address family
            // (typical in the IPv6 case).
            foreach (IPAddress address in hostEntry.AddressList)
            {
                IPEndPoint ipe = new IPEndPoint(address, port);
                if (ipe.AddressFamily != AddressFamily.InterNetwork)
                    continue;
                Socket tempSocket =
                    new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                tempSocket.Connect(ipe);

                if (tempSocket.Connected)
                {
                    s = tempSocket;
                    break;
                }
                else
                {
                    continue;
                }
            }
            return s;
        }

        // This method requests the home page content for the specified server.
        public static string SocketSendReceive(string server, string url, int port, StreamWriter sw)
        {
            try
            {
                int totalbytes = 0;
                if(url == "")
                    url = "/";
                string request = "GET " + url + " HTTP/1.1\r\nHost: " + server +
                    "\r\nConnection: Close\r\n\r\n";
                Byte[] bytesSent = Encoding.ASCII.GetBytes(request);
                Byte[] bytesReceived = new Byte[256];

                // Create a socket connection with the specified server and port.
                Socket s = ConnectSocket(server, port);

                if (s == null)
                    return ("fail");

                // Send request to the server.
                s.Send(bytesSent, bytesSent.Length, 0);


                // Receive the server home page content.
                int flag = 0;
                int bytes = 0;
                string page = "";
                do
                {
                    bytes = s.Receive(bytesReceived, bytesReceived.Length, 0);
                    page = page + Encoding.UTF8.GetString(bytesReceived, 0, bytes);
                    totalbytes = totalbytes + bytesReceived.Length;
                    Console.WriteLine("Already download {0} bytes", totalbytes);
                    flag++;
                }
                while (bytes > 0 && flag < 50);

                //正则匹配部分
                string headrm;
                if (bytes > 0)
                {
                    headrm = @"<\?xml.*";
                }
                else
                    headrm = @"<\?xml.*>";
                Regex rheadrm = new Regex(headrm, RegexOptions.Singleline);
                Match m = rheadrm.Match(page); 
                if (m.Success)
                {
                    page = m.Groups[0].Captures[0].Value;
                    sw.Write(page);
                    page = "";
                }
                else
                {
                    Console.WriteLine("获取html正文失败。");
                    return "";
                }

                // The following will block until te page is transmitted.
                flag = 0;
                do
                {
                    bytes = s.Receive(bytesReceived, bytesReceived.Length, 0);
                    page = page + Encoding.UTF8.GetString(bytesReceived, 0, bytes);
                    totalbytes = totalbytes + bytesReceived.Length;
                    Console.WriteLine("Already download {0} bytes",totalbytes);
                    //if (bytes <= 0)
                    //{
                    //    //正则匹配部分
                    //    string tail = @".*>";
                    //    Regex rtail = new Regex(tail, RegexOptions.Singleline);
                    //    m = rheadrm.Match(page); 
                    //    if (m.Success)
                    //    {
                    //        page = m.Groups[0].Captures[0].Value;
                    //        sw.Write(page);
                    //        page = "";
                    //    }
                    //    else
                    //    {
                    //        Console.WriteLine("获取结束符错误。");
                    //    }
                    //    return "";
                    //}
                    if (flag > 10)
                    {
                        sw.Write(page);
                        page = "";
                        flag = 0;
                    }
                    flag++;
                }
                while (bytes > 0);
                sw.Write(page);
                return "";
            }
            catch
            {
                return "fail";
            }
        }
    }
}
