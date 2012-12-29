using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XmlInterface
{
    public class LashouXml:XmlData
    {
        public LashouXml(string filepath)            
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
                string a = xmldoc.DocumentElement.FirstChild.ChildNodes[1].FirstChild.Value;
                XmlNode xmlNode = xmldoc.DocumentElement.ChildNodes[pos];
                
                temp.url = xmlNode.ChildNodes[0].FirstChild.Value;
                temp.time = Convert.ToInt32(xmlNode.ChildNodes[2].FirstChild.ChildNodes[8].FirstChild.Value);
                temp.feat = Convert.ToInt32(xmlNode.ChildNodes[2].FirstChild.ChildNodes[13].FirstChild.Value);
                temp.discount = Convert.ToDouble(xmlNode.ChildNodes[2].FirstChild.ChildNodes[12].FirstChild.Value);
                temp.description = (xmlNode.ChildNodes[2].FirstChild.ChildNodes[14].FirstChild.InnerText != "" ? xmlNode.ChildNodes[2].FirstChild.ChildNodes[14].FirstChild.InnerText : xmlNode.ChildNodes[2].FirstChild.ChildNodes[5].FirstChild.InnerText);
                temp.seller = "拉手网";
                temp.deal_title = xmlNode.ChildNodes[2].FirstChild.ChildNodes[5].InnerText;
                //temp.description = xmlNode.ChildNodes[2].FirstChild.ChildNodes[5].FirstChild.Value;
                temp.other = "";
                foreach (XmlNode shops in xmlNode.ChildNodes[2].FirstChild.ChildNodes[15].ChildNodes)
                {
                    temp.other += (shops.ChildNodes[0].FirstChild != null ? shops.ChildNodes[0].FirstChild.Value : "") +
                        (shops.ChildNodes[2].FirstChild != null ? shops.ChildNodes[2].FirstChild.Value : "");
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
