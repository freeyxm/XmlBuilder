using System;
using System.Text;
using XmlBuilder.Define;

namespace XmlBuilder.Parser
{
    class XmlClassParser : XmlBaseParser
    {
        private new XmlClass m_xmlDef;

        public XmlClassParser(XmlClass def, string nodeName)
            : base(def, nodeName)
        {
            m_xmlDef = def;
        }

        public override void ToDefine(ref StringBuilder buff, int indent)
        {
            for (int i = 0; i < m_xmlDef.Fields.Count; ++i)
            {
                var field = m_xmlDef.Fields[i];
                var parser = XmlBaseParser.Parse(field, m_nodeName);
                parser.ToDefine(ref buff, indent);
            }

            buff.Append('\t', indent);
            buff.Append("private static ").Append(m_xmlDef.type).Append(" Parse").Append(m_xmlDef.type)
                .Append("(XmlNode ").Append(m_nodeName).AppendLine(")");
            buff.Append('\t', indent).AppendLine("{");
            ++indent;
            {
                buff.Append('\t', indent);
                buff.Append(m_xmlDef.type).Append(" data = new ").Append(m_xmlDef.type).Append("();").AppendLine();

                if (m_xmlDef.HasAttrField())
                {
                    buff.AppendLine();
                    ToDefineAttributes(ref buff, indent);
                }

                if (m_xmlDef.HasNodeField())
                {
                    buff.AppendLine();
                    ToDefineChildNodes(ref buff, indent);
                }

                buff.AppendLine();
                buff.Append('\t', indent);
                buff.AppendLine("return data;");
            }
            --indent;
            buff.Append('\t', indent).AppendLine("}");
            buff.AppendLine();
        }

        private void ToDefineAttributes(ref StringBuilder buff, int indent)
        {
            buff.Append('\t', indent);
            buff.Append("foreach (XmlAttribute attr in ").Append(m_nodeName).AppendLine(".Attributes)");
            buff.Append('\t', indent).AppendLine("{");
            ++indent;
            {
                buff.Append('\t', indent);
                buff.Append("string attrName = \"m_\" + attr.Name;").AppendLine();

                bool isFirst = true;
                for (int i = 0; i < m_xmlDef.Fields.Count; ++i)
                {
                    var field = m_xmlDef.Fields[i];
                    if (field.IsAttr)
                    {
                        buff.Append('\t', indent);
                        if (!isFirst)
                        {
                            buff.Append("else ");
                        }
                        buff.Append("if(attrName == \"").Append(field.name).AppendLine("\")");
                        buff.Append('\t', indent).AppendLine("{");
                        ++indent;
                        {
                            buff.Append('\t', indent);
                            var parser = XmlBaseParser.Parse(field, "attr");
                            buff.Append("data.").Append(field.name).Append(" = ");
                            parser.ToMember(ref buff, 0);
                        }
                        --indent;
                        buff.Append('\t', indent).AppendLine("}");
                        isFirst = false;
                    }
                }
            }
            --indent;
            buff.Append('\t', indent).AppendLine("}");
        }

        private void ToDefineChildNodes(ref StringBuilder buff, int indent)
        {
            buff.Append('\t', indent);
            buff.Append("foreach (XmlNode node in ").Append(m_nodeName).AppendLine(".ChildNodes)");
            buff.Append('\t', indent).AppendLine("{");
            ++indent;
            {
                buff.Append('\t', indent);
                buff.Append("if (node.NodeType != XmlNodeType.Element)").AppendLine();
                buff.Append('\t', indent + 1).Append("continue;").AppendLine();

                buff.Append('\t', indent);
                buff.Append("string nodeName = \"m_\" + node.Name;").AppendLine();

                bool isFirst = true;
                for (int i = 0; i < m_xmlDef.Fields.Count; ++i)
                {
                    var field = m_xmlDef.Fields[i];
                    if (!field.IsAttr)
                    {
                        buff.Append('\t', indent);
                        if (!isFirst)
                        {
                            buff.Append("else ");
                        }
                        buff.Append("if(nodeName == \"").Append(field.name).AppendLine("\")");
                        buff.Append('\t', indent).AppendLine("{");
                        ++indent;
                        {
                            buff.Append('\t', indent);
                            var parser = XmlBaseParser.Parse(field, "node");
                            buff.Append("data.").Append(field.name).Append(" = ");
                            parser.ToMember(ref buff, 0);
                        }
                        --indent;
                        buff.Append('\t', indent).AppendLine("}");
                        isFirst = false;
                    }
                }
            }
            --indent;
            buff.Append('\t', indent).AppendLine("}");
        }

        public override void ToMember(ref StringBuilder buff, int indent)
        {
            buff.Append('\t', indent);
            buff.Append("Parse").Append(m_xmlDef.type).Append("(").Append(m_nodeName).AppendLine(");");
        }
    }
}
