using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoveToDatabase;
using DownloadXml;

namespace TuanSpider
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Count() == 0)
            {
                Console.WriteLine("TuanSpider.exe [filepath] [start] [end]\nfilepath:xml文件名\nstart:起始index，可选\nend终止index，可选\n功能：将filepath文件中从start开始到end的团购条目索引化存入数据库");
                return;
            }
            LoadIntoDatabase temp = null;
            downloadXml down = null;
            switch (args[0])
            {
                case "d":
                    down = new downloadXml();
                    down.download(args[1], args[2]);
                    break;
                case "i":
                    temp = new LoadIntoDatabase(args[1], "localhost", "gyzdatabase", "root", "9917622q", 2);
                    switch (args.Count())
                    {
                        case 2:
                            temp.addLink();
                            break;
                        case 3:
                            temp.addLink(Convert.ToInt32(args[2]));
                            break;
                        case 4:
                            temp.addLink(Convert.ToInt32(args[2], Convert.ToInt32(args[3])));
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
