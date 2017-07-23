using System;
using System.Text;
using XmlBuilder.Define;

namespace XmlBuilder.Parser
{
    class XmlFloatParser : XmlFieldParser
    {
        private new XmlFloat m_xmlDef;

        public XmlFloatParser(XmlFloat def, string nodeName)
            : base(def, nodeName)
        {
            m_xmlDef = def;
        }

        protected override string GetTypeStr()
        {
            return "Float";
        }
    }
}
