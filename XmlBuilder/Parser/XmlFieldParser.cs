using System;
using System.Text;
using XmlBuilder.Define;

namespace XmlBuilder.Parser
{
    class XmlFieldParser : XmlBaseParser
    {
        public XmlFieldParser(XmlBase def, string nodeName)
            : base(def, nodeName)
        {
        }

        public override void ToMember(ref StringBuilder buff, int indent)
        {
            buff.Append('\t', indent);
            buff.Append("XmlHelper.Parse").Append(GetTypeStr()).Append("(");
            if (m_xmlDef.IsAttr)
            {
                buff.Append(m_nodeName);
            }
            else if (m_xmlDef.IsChildAttr)
            {
                buff.Append(m_nodeName).Append(".Attributes[0]");
            }
            else
            {
                buff.Append(m_nodeName);
            }
            buff.AppendLine(");");
        }

        protected virtual string GetTypeStr()
        {
            return "";
        }
    }
}
