using System;
using System.Text;
using XmlBuilder.Define;

namespace XmlBuilder.Parser
{
    class XmlIntParser : XmlFieldParser
    {
        private new XmlInt m_xmlDef;

        public XmlIntParser(XmlInt def, string nodeName)
            : base(def, nodeName)
        {
            m_xmlDef = def;
        }

        protected override string GetTypeStr()
        {
            return "Int";
        }
    }
}
