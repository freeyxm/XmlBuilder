using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace XmlBuilder.Define
{
    class XmlList : XmlBase
    {
        List<XmlBase> m_list = new List<XmlBase>();

        public bool Parse(XmlNode node)
        {
            name = "m_" + node.Name;

            foreach (XmlNode child in node.ChildNodes)
            {
                m_list.Add(ParseNode(child));
            }

            if (m_list.Count > 0)
                type = string.Format("List<{0}>", m_list[0].type);
            else
                type = "List<object>";

            return true;
        }

        public override void ToDefine(ref StringBuilder buff, int indent)
        {
            if (m_list.Count > 0)
            {
                m_list[0].ToDefine(ref buff, indent);
            }
        }

        public override void ToMember(ref StringBuilder buff, int indent)
        {
            buff.Append('\t', indent);
            buff.Append("public ").Append(type).Append(" ").Append(name)
                .Append(" = new ").Append(type).Append("();")
                .AppendLine();
        }

        public List<XmlBase> ListData { get { return m_list; } }
    }
}
