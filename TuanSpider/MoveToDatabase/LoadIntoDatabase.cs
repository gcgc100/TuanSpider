using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Security.Cryptography;
using MySQLDriverCS;
using XmlInterface;
using System.Data;
/*
 * 输入：团购信息xml文件的路径filepath、xml文件的类型（是哪个团购网站提供的）
 * 输出：存入数据库的操作是否成功
 * 功能：使用xmlData类和Statistic类提供的统一接口获取计算好的数据
 *      将其按格式导入数据库中
 */

namespace MoveToDatabase
{
    public class LoadIntoDatabase
    {
        private MySQLConnection conn;
        private MySQLCommand cmd;
        XmlData xmlparse;
        Statistic staContext;
        public LoadIntoDatabase(string filepath, int type)
        {
            switch (type)
            {
                case 1:
                    xmlparse = new MeiTuanXml(filepath);
                    break;
                case 2:
                    xmlparse = new LashouXml(filepath);
                    break;
                case 3:
                    xmlparse = new NuomiXml(filepath);
                    break;
                default:
                    break;
            }
            staContext = new Statistic();
            conn = new MySQLConnection(new MySQLConnectionString("localhost", "gyzdatabase", "root", "9917622q").AsString);
            conn.Open();
        }
        public LoadIntoDatabase(string filepath, string host, string database, string user, string passwd, int type)
        {
            switch (type)
            {
                case 1:
                    xmlparse = new MeiTuanXml(filepath);
                    break;
                case 2:
                    xmlparse = new LashouXml(filepath);
                    break;
                case 3:
                    xmlparse = new NuomiXml(filepath);
                    break;
                default:
                    break;
            }
            staContext = new Statistic();
            conn = new MySQLConnection(new MySQLConnectionString(host, database, user, passwd).AsString);
            conn.Open();
        }

        ~LoadIntoDatabase()
        {
            conn.Close();
        }

        public int getcount()
        {
            return xmlparse.getCount();
        }

        public bool addLink(int start, int end)
        {//添加xml文件中从start到end的团购条目信息
            int pos = start;
            while (pos <= end)
            {
                if (!addOneUrl(pos++))
                    return false;
            }
            return true;
        }

        public bool addLink(int start)
        {//添加xml文件中从start到最后的团购条目信息
            int pos = start;
            while (pos < xmlparse.getCount())
            {
                if (!addOneUrl(pos++))
                    return false;
            }
            return true;
        }

        public bool addLink()
        {//添加xml文件中所有团购条目信息
            int pos = 0;
            while (pos < xmlparse.getCount())
            {
                if (!addOneUrl(pos++))
                    return false;
            }
            return true;
        }
        private bool addOneUrl(int pos)
        {//添加第pos条团购条目信息
            string query;
            int link_id;
            MD5 md5 = new MD5CryptoServiceProvider(); ;
            //XmlNode oneUrl = lashouDocument.DocumentElement.ChildNodes[pos];
            oneUrl oneUrl = xmlparse.getOneUrl(pos);
            StatisticOutput sta = staContext.statistic(oneUrl);

            Console.WriteLine("Insert the data to the database....");
            query = "insert into links (site_id, url, title, description) values(5, \"" +
                sta.url + "\",\"" + sta.title + "\",\"" + sta.description + "\")";
            cmd = new MySQLDriverCS.MySQLCommand(query, conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            query = "select link_id from links where url = \"" + sta.url + "\"";
            cmd = new MySQLDriverCS.MySQLCommand(query, conn);
            IDataReader dt = cmd.ExecuteReader();
            link_id = Convert.ToInt32(dt.GetSchemaTable().Rows[0]["link_id"]);
            foreach (DictionaryEntry de in sta.keywordList)
            {
                int keyword_id = 0;
                query = "select keyword_id from keywords where keyword = \"" + de.Key + "\"";
                cmd = new MySQLDriverCS.MySQLCommand(query, conn);
                dt = cmd.ExecuteReader();
                if (dt.GetSchemaTable().Rows.Count == 0)
                {
                    query = "insert into keywords (keyword) values (\"" + de.Key + "\")";
                    cmd = new MySQLDriverCS.MySQLCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    query = "select keyword_id from keywords where keyword = \"" + de.Key + "\"";
                    cmd = new MySQLDriverCS.MySQLCommand(query, conn);
                    dt = cmd.ExecuteReader();
                    keyword_id = Convert.ToInt32(dt.GetSchemaTable().Rows[0]["keyword_id"]);
                }
                else
                    keyword_id = Convert.ToInt32(dt.GetSchemaTable().Rows[0]["keyword_id"]);
                byte[] hash = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(de.Key.ToString()));
                string flag;
                switch (hash[0] >> 4)
                {
                    case 10:
                        flag = "a";
                        break;
                    case 11:
                        flag = "b";
                        break;
                    case 12:
                        flag = "c";
                        break;
                    case 13:
                        flag = "d";
                        break;
                    case 14:
                        flag = "e";
                        break;
                    case 15:
                        flag = "f";
                        break;
                    default:
                        flag = (hash[0] >> 4).ToString();
                        break;
                }
                query = "insert into link_keyword" + flag + "(link_id, keyword_id, weight, time, feat, discount) values (" +
                    link_id + "," + keyword_id + "," + de.Value + "," + sta.time + "," + sta.feat + "," +
                    sta.discount + ")";
                cmd = new MySQLDriverCS.MySQLCommand(query, conn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            Console.WriteLine("Write one link sucessfully!");
            return true;
        }
    }
}
