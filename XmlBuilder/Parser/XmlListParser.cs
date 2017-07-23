using System;
using System.Text;
using XmlBuilder.Define;

namespace XmlBuilder.Parser
{
    class XmlListParser : XmlBaseParser
    {
        private XmlList m_xmlDef;

        public XmlListParser(XmlList def, string nodeName)
            : base(def, nodeName)
        {
            m_xmlDef = def;
        }

        public override void ToDefine(ref StringBuilder buff, int indent)
        {
            if (m_xmlDef.ListData.Count > 0)
            {
                var field = m_xmlDef.ListData[0];
                var parser = XmlBaseParser.Parse(field, m_nodeName);
                parser.ToDefine(ref buff, indent);
            }

            buff.Append('\t', indent);
            buff.Append("private static ").Append(m_xmlDef.type).Append(" Parse").Append(m_xmlDef.SrcName).Append("(XmlNode ")
                .Append(m_nodeName).AppendLine(")");
            buff.Append('\t', indent).AppendLine("{");
            {
                buff.Append('\t', indent + 1);
                buff.Append(m_xmlDef.type).Append(" data = new ").Append(m_xmlDef.type).Append("();").AppendLine();

                buff.AppendLine();
                ToDefineChildNodes(ref buff, indent + 1);

                buff.AppendLine();
                buff.Append('\t', indent + 1);
                buff.AppendLine("return data;");
            }
            buff.Append('\t', indent).AppendLine("}");
            buff.AppendLine();
        }

        private void ToDefineChildNodes(ref StringBuilder buff, int indent)
        {
            XmlBase defItem = m_xmlDef.ListData[0];
            XmlBaseParser parser = XmlBaseParser.Parse(defItem, "node");

            buff.Append('\t', indent);
            buff.Append("foreach(XmlNode node in ").Append(m_nodeName).AppendLine(".ChildNodes)");
            buff.Append('\t', indent).AppendLine("{");
            {
                buff.Append('\t', indent + 1);
                buff.Append("var dataItem = ");
                parser.ToMember(ref buff, 0);

                buff.Append('\t', indent + 1);
                buff.AppendLine("data.Add(dataItem);");
            }
            buff.Append('\t', indent).AppendLine("}");
        }

        public override void ToMember(ref StringBuilder buff, int indent)
        {
            buff.Append('\t', indent);
            buff.Append("Parse").Append(m_xmlDef.SrcName).Append("(").Append(m_nodeName).AppendLine(");");
        }
    }
}
