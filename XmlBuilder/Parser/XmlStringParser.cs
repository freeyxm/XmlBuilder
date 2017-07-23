using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using XmlBuilder.Define;

namespace XmlBuilder.Parser
{
    class XmlStringParser : XmlBaseParser
    {
        private XmlString m_xmlDef;

        public XmlStringParser(XmlString def, string nodeName)
            : base(def, nodeName)
        {
            m_xmlDef = def;
        }

        public override void ToMember(ref StringBuilder buff, int indent)
        {
            buff.Append('\t', indent);
            buff.Append("XmlHelper.ParseString(").Append(m_nodeName).AppendLine(");");
        }
    }
}
