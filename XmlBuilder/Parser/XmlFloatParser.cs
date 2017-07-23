using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using XmlBuilder.Define;

namespace XmlBuilder.Parser
{
    class XmlFloatParser : XmlBaseParser
    {
        private XmlFloat m_xmlDef;

        public XmlFloatParser(XmlFloat def, string nodeName)
            : base(def, nodeName)
        {
            m_xmlDef = def;
        }

        public override void ToMember(ref StringBuilder buff, int indent)
        {
            buff.Append('\t', indent);
            buff.Append("XmlHelper.ParseFloat(").Append(m_nodeName).AppendLine(");");
        }
    }
}
