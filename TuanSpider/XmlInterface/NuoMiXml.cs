using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XmlInterface
{
    public class NuomiXml:XmlData
    {
        public NuomiXml(string filepath)
            : base(filepath)
        {
        }
        public override oneUrl getOneUrl(int pos)
        {
            try
            {
                oneUrl temp = new oneUrl();
                if (xmldoc.DocumentElement == null)
                    throw new System.NullReferenceException();
                XmlNode xmlNode = xmldoc.DocumentElement.ChildNodes[pos];
                temp.url = xmlNode.ChildNodes[0].FirstChild.Value;
                temp.time = Convert.ToInt32(xmlNode.ChildNodes[1].FirstChild.ChildNodes[10].FirstChild.Value);
                temp.feat = Convert.ToInt32(xmlNode.ChildNodes[1].FirstChild.ChildNodes[15].FirstChild.Value);
                temp.discount = Convert.ToDouble(xmlNode.ChildNodes[1].FirstChild.ChildNodes[14].FirstChild.Value);
                temp.deal_title = xmlNode.ChildNodes[1].FirstChild.ChildNodes[7].FirstChild.Value;
                temp.seller = "糯米网";
                temp.description = temp.deal_title + " 原价" + Convert.ToInt32(xmlNode.ChildNodes[1].FirstChild.ChildNodes[12].FirstChild.Value) +"元，现价仅售" + Convert.ToInt32(xmlNode.ChildNodes[1].FirstChild.ChildNodes[13].FirstChild.Value) + "元";
                temp.other = "";
                foreach (XmlNode shops in xmlNode.ChildNodes[1].FirstChild.ChildNodes[16].ChildNodes)
                {
                    temp.other += (shops.ChildNodes[0].FirstChild != null ? shops.ChildNodes[0].FirstChild.Value : "") +
                        (shops.ChildNodes[2].FirstChild != null ? shops.ChildNodes[2].FirstChild.Value : "") +
                        (shops.ChildNodes[3].FirstChild != null ? shops.ChildNodes[3].FirstChild.Value : "");
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
            return xmldoc.DocumentElement.ChildNodes.Count;
        }
    }
}
