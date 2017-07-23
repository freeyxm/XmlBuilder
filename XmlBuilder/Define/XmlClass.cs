using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace XmlBuilder.Define
{
    class XmlClass : XmlBase
    {
        List<XmlBase> m_fields = new List<XmlBase>();

        public bool Parse(XmlNode node)
        {
            name = "m_" + node.Name;
            type = node.Name;

            foreach (XmlAttribute attr in node.Attributes)
            {
                m_fields.Add(ParseAttribute(attr));
            }

            foreach (XmlNode child in node.ChildNodes)
            {
                m_fields.Add(ParseNode(child));
            }

            return true;
        }

        public override void ToDefine(ref StringBuilder buff, int indent)
        {
            for (int i = 0; i < m_fields.Count; ++i)
            {
                m_fields[i].ToDefine(ref buff, indent);
            }

            buff.AppendLine();
            buff.Append('\t', indent);
            buff.Append("public class ").Append(type).AppendLine();
            buff.Append('\t', indent);
            buff.AppendLine("{");
            for (int i = 0; i < m_fields.Count; ++i)
            {
                m_fields[i].ToMember(ref buff, indent + 1);
            }
            buff.Append('\t', indent);
            buff.AppendLine("}");
        }

        public override void ToMember(ref StringBuilder buff, int indent)
        {
            buff.Append('\t', indent);
            buff.Append("public ").Append(type).Append(" ").Append(name)
                .Append(" = new ").Append(type).Append("();")
                .AppendLine();
        }
    }
}
