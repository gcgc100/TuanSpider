using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XmlInterface
{
    public class MeiTuanXml:XmlData
    {
        public MeiTuanXml(string filepath)
            : base(filepath)
        {
        }
        public override oneUrl getOneUrl(int pos)
        {
            try
            {
                oneUrl temp = new oneUrl();
                if (xmldoc.DocumentElement.FirstChild == null)
                    throw new System.NullReferenceException();
                XmlNode xmlNode = xmldoc.DocumentElement.FirstChild.ChildNodes[pos];
                temp.url = xmlNode.FirstChild.ChildNodes[10].FirstChild.Value;
                temp.time = Convert.ToInt32(xmlNode.FirstChild.ChildNodes[25].FirstChild.Value);
                temp.feat = Convert.ToInt32(xmlNode.FirstChild.ChildNodes[22].FirstChild.Value);
                temp.discount = Convert.ToDouble(xmlNode.FirstChild.ChildNodes[20].FirstChild.Value);
                temp.deal_title = xmlNode.FirstChild.ChildNodes[8].FirstChild.Value;
                temp.seller = xmlNode.FirstChild.ChildNodes[36].FirstChild.Value;
                temp.description = xmlNode.FirstChild.ChildNodes[17].FirstChild.Value;
                temp.other = "";
                foreach (XmlNode shops in xmlNode.ChildNodes[1].ChildNodes)
                {
                    temp.other += (shops.ChildNodes[0].FirstChild != null ? shops.ChildNodes[0].FirstChild.Value : "") +
                        (shops.ChildNodes[3].FirstChild != null ? shops.ChildNodes[3].FirstChild.Value : "") +
                        (shops.ChildNodes[4].FirstChild != null ? shops.ChildNodes[4].FirstChild.Value : "");
                }
                Console.WriteLine("Get one item.");
                return temp;
            }
            catch(System.NullReferenceException e)
            {
                Console.WriteLine(e);
                return new oneUrl();
            }
        }
        public override int getCount()
        {
            return xmldoc.DocumentElement.FirstChild.ChildNodes.Count;
        }
    }
}
