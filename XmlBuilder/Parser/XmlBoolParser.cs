using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using XmlBuilder.Define;

namespace XmlBuilder.Parser
{
    class XmlBoolParser : XmlBaseParser
    {
        private XmlBool m_xmlDef;

        public XmlBoolParser(XmlBool def, string nodeName)
            : base(def, nodeName)
        {
            m_xmlDef = def;
        }

        public override void ToMember(ref StringBuilder buff, int indent)
        {
            buff.Append('\t', indent);
            buff.Append("XmlHelper.ParseBool(").Append(m_nodeName).AppendLine(");");
        }
    }
}
