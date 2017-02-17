using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;


namespace GetXmlData
{
    class Program
    {
        static void Main(string[] args)
        {
            string host, url;
            int port = 80;
            url = args[0];
            string filename = args[1];
            StreamWriter sw = new StreamWriter(filename);
            String regexp = "(http://)?([^/]*)(/?.*)";
            Regex hostfind = new Regex(regexp);
            Match m = hostfind.Match(url);
            if (m.Success)
            {
                host = m.Groups[2].Value;
                url = m.Groups[3].Value;
            }
            else
            {
                Console.WriteLine("提取主机名失败，请检查url格式是否正确。");
                return;
            }
            string result = GetSocket.SocketSendReceive(host, url, port, sw);

            ////正则匹配部分
            //string headrm = @"<\?xml.*>";
            //// Instantiate the regular expression object.
            //Regex rheadrm = new Regex(headrm, RegexOptions.Singleline);
            //// Match the regular expression pattern against a text string.
            //m = rheadrm.Match(result);
            //if (m.Success)
            //{
            //    result = m.Groups[0].Captures[0].Value;
            //}
            //else
            //{
            //    Console.WriteLine("获取html正文失败。");
            //    return;
            //}

            //sw.Write(result);
            sw.Flush();
            sw.Close();
        }
    }
}
