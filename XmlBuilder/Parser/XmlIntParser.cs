using System;
using System.Text;
using XmlBuilder.Define;

namespace XmlBuilder.Parser
{
    class XmlIntParser : XmlBaseParser
    {
        private XmlInt m_xmlDef;

        public XmlIntParser(XmlInt def, string nodeName)
            : base(def, nodeName)
        {
            m_xmlDef = def;
        }

        public override void ToMember(ref StringBuilder buff, int indent)
        {
            buff.Append('\t', indent);
            buff.Append("XmlHelper.ParseInt(").Append(m_nodeName).AppendLine(");");
        }
    }
}
