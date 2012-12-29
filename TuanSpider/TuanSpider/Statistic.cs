using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XmlInterface;
using System.Collections;
using KTDictSeg;
using FTAlgorithm;
/*
 * 输入：xmlData类
 * 输出：统计好的一条团购信息条，存储在结构体StatisticOutput中
 * 功能：从xmlData类得到一条团购信息条，将其中提供的字符串、数字等信息进行分词、统计等操作后，得到数据检索时使用的
 *      权重、链接等信息。
 */

namespace TuanSpider
{
    public class Statistic
    {
        const int TITLE_WEIGHT = 5;
        const int DESCRIPTION_WEIGHT = 1;
        const int OTHER_WEIGHT = 1;
        const int SELLER_WEIGHT = 5;

        public static CSimpleDictSeg m_SimpleDictSeg;
        StatisticOutput output;
        public Statistic()
        {
            initDict();
            output = new StatisticOutput();
            output.time = 0;
            output.feat = 0;
            output.title = "";
            output.discount = 0;
            output.url = "";
            output.description = "";
            output.keywordList = new Hashtable();
        }
        public Statistic(oneUrl item)
        {
            initDict();
            output = new StatisticOutput();
            output.time = item.time;
            output.feat = item.feat;
            output.discount = 100 - Convert.ToInt32(10 * Convert.ToDouble(item.discount));
            output.title = item.seller + "-" + item.deal_title;
            output.description = item.description;
            output.keywordList = new Hashtable();
            splitwords(output.title, TITLE_WEIGHT);
            splitwords(item.other, OTHER_WEIGHT);
            splitwords(item.description, DESCRIPTION_WEIGHT);
        }
        public StatisticOutput statistic(oneUrl item)
        {//统计item中存储的团购条目信息
            Console.WriteLine("Computing the statisitc data of the item...");
            StatisticOutput oneOutput = new StatisticOutput();
            oneOutput.url = item.url;
            oneOutput.time = item.time;
            oneOutput.feat = item.feat;
            oneOutput.discount = 100 - Convert.ToInt32(10 * Convert.ToDouble(item.discount));
            oneOutput.title = item.seller + "-" + item.deal_title;
            oneOutput.description = item.description;
            oneOutput.keywordList = new Hashtable();
            splitwords(ref oneOutput, oneOutput.title, TITLE_WEIGHT);
            splitwords(ref oneOutput, item.other, OTHER_WEIGHT);
            splitwords(ref oneOutput, item.description, DESCRIPTION_WEIGHT);
            Console.WriteLine("Statistic ready.");
            return oneOutput;
        }
        public void splitwords(string sentence, int weight)
        {//分词函数，对sentence进行分词，其中每个词的权重按weight计算，分出的词加入关键词列表中
            List<T_WordInfo> words = m_SimpleDictSeg.SegmentToWordInfos(sentence);
            for (int i = 0; i < words.Count; i++)
            {
                //判断文本是否进入
                if (words[i] == null)
                    continue;
                if (output.keywordList.ContainsKey(words[i].Word))
                {
                    output.keywordList[words[i].Word] = (int)output.keywordList[words[i].Word] + weight;
                }
                else
                {
                    output.keywordList.Add(words[i].Word, weight);
                }
            }
        }
        private static void splitwords(ref StatisticOutput temOutput, string sentence, int weight)
        {//分词函数，作用同上，但分出的词加入tempOutput的关键词列表中
            List<T_WordInfo> words = m_SimpleDictSeg.SegmentToWordInfos(sentence);
            for (int i = 0; i < words.Count; i++)
            {
                //判断文本是否进入
                if (words[i] == null)
                    continue;
                if (temOutput.keywordList.ContainsKey(words[i].Word))
                {
                    temOutput.keywordList[words[i].Word] = (int)temOutput.keywordList[words[i].Word] + weight;
                }
                else
                {
                    temOutput.keywordList.Add(words[i].Word, weight);
                }
            }
        }

        public void initDict()
        {//出事话分词词典
            m_SimpleDictSeg = new CSimpleDictSeg();
            m_SimpleDictSeg.LoadConfig("KTDictSeg.xml");
            m_SimpleDictSeg.LoadDict();
        }
    }

    public struct StatisticOutput
    {
        public int time;
        public int feat;
        public int discount;
        public string url;
        public string title;
        public string description;
        public Hashtable keywordList;
    }
}
