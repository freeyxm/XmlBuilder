using System;
using System.Text;
using XmlBuilder.Define;

namespace XmlBuilder.Parser
{
    class XmlStringParser : XmlFieldParser
    {
        private new XmlString m_xmlDef;

        public XmlStringParser(XmlString def, string nodeName)
            : base(def, nodeName)
        {
            m_xmlDef = def;
        }

        protected override string GetTypeStr()
        {
            return "String";
        }
    }
}
