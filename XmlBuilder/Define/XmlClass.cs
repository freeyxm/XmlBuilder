using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace XmlBuilder.Define
{
    class XmlClass : XmlBase
    {
        List<XmlBase> m_fields = new List<XmlBase>();

        public bool ParseNode(XmlNode node)
        {
            name = "m_" + node.Name;
            type = node.Name;

            foreach (XmlAttribute attr in node.Attributes)
            {
                m_fields.Add(ParseAttribute(attr));
            }

            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.NodeType != XmlNodeType.Element)
                {
                    continue;
                }
                var field = XmlBase.Parse(child);
                if (field.IsAttr)
                {
                    field.IsAttr = false;
                    field.IsChildAttr = true;
                }
                m_fields.Add(field);
            }

            return true;
        }

        public override void ToDefine(ref StringBuilder buff, int indent)
        {
            for (int i = 0; i < m_fields.Count; ++i)
            {
                m_fields[i].ToDefine(ref buff, indent);
            }

            buff.Append('\t', indent);
            buff.Append("public class ").Append(type).AppendLine();
            buff.Append('\t', indent).AppendLine("{");
            for (int i = 0; i < m_fields.Count; ++i)
            {
                m_fields[i].ToMember(ref buff, indent + 1);
            }
            buff.Append('\t', indent).AppendLine("}");
            buff.AppendLine();
        }

        public override void ToMember(ref StringBuilder buff, int indent)
        {
            buff.Append('\t', indent);
            buff.Append("public ").Append(type).Append(" ").Append(name)
                .Append(" = new ").Append(type).Append("();")
                .AppendLine();
        }

        public List<XmlBase> Fields { get { return m_fields; } }

        public bool HasAttrField()
        {
            for (int i = 0; i < m_fields.Count; ++i)
            {
                if (m_fields[i].IsAttr == true)
                    return true;
            }
            return false;
        }

        public bool HasNodeField()
        {
            for (int i = 0; i < m_fields.Count; ++i)
            {
                if (m_fields[i].IsAttr == false)
                    return true;
            }
            return false;
        }
    }
}
