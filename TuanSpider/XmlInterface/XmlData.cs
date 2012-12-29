using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XmlInterface
{
    public abstract class XmlData
    {
        protected XmlDocument xmldoc;
        public XmlData(string filepath)
        {
            xmldoc = new XmlDocument();
            xmldoc.Load(filepath);
        }

        public virtual oneUrl getOneUrl(int pos)
        {
            throw new System.NotImplementedException();
        }
        public virtual int getCount()
        {
            throw new System.NotImplementedException();
        }
    }

    public struct oneUrl
    {
        public int time;
        public int feat;
        public double discount;
        public string url;
        public string deal_title;
        public string seller;
        public string description;
        public string other;
    }
}
