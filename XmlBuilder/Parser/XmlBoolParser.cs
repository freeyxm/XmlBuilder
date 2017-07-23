using System;
using System.Text;
using XmlBuilder.Define;

namespace XmlBuilder.Parser
{
    class XmlBoolParser : XmlFieldParser
    {
        private new XmlBool m_xmlDef;

        public XmlBoolParser(XmlBool def, string nodeName)
            : base(def, nodeName)
        {
            m_xmlDef = def;
        }

        protected override string GetTypeStr()
        {
            return "Bool";
        }
    }
}
