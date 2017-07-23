using System;
using System.Text;
using XmlBuilder.Define;

namespace XmlBuilder.Parser
{
    class XmlBaseParser
    {
        private XmlBase m_xmlDef;
        protected string m_nodeName;

        public XmlBaseParser(XmlBase xmlBase, string nodeName)
        {
            m_xmlDef = xmlBase;
            m_nodeName = nodeName;
        }

        public static XmlBaseParser Parse(XmlBase define, string nodeName)
        {
            if (define is XmlClass)
            {
                return new XmlClassParser(define as XmlClass, nodeName);
            }
            else if (define is XmlInt)
            {
                return new XmlIntParser(define as XmlInt, nodeName);
            }
            else if (define is XmlFloat)
            {
                return new XmlFloatParser(define as XmlFloat, nodeName);
            }
            else if (define is XmlString)
            {
                return new XmlStringParser(define as XmlString, nodeName);
            }
            else if (define is XmlBool)
            {
                return new XmlBoolParser(define as XmlBool, nodeName);
            }
            else if (define is XmlList)
            {
                return new XmlListParser(define as XmlList, nodeName);
            }
            else
            {
                return new XmlBaseParser(define, nodeName);
            }
        }

        public string ToDefine()
        {
            int indent = 0;
            StringBuilder buff = new StringBuilder();
            buff.AppendLine("using System;");
            buff.AppendLine("using System.Collections.Generic;");
            buff.AppendLine("using System.Xml;");
            buff.AppendLine("using XmlBuilder.Parser;");
            buff.AppendLine();
            buff.Append("namespace XmlBuilder.NS_").Append(m_xmlDef.SrcName).AppendLine();
            buff.AppendLine("{");
            ++indent;
            buff.Append('\t', indent);
            buff.Append("public class ").Append(m_xmlDef.SrcName).Append("Parser").AppendLine();
            buff.Append('\t', indent).AppendLine("{");
            ++indent;
            ToDefine(ref buff, indent);
            {
                buff.Append('\t', indent);
                buff.Append("public static ").Append(m_xmlDef.type).Append(" Parse(XmlNode rootNode)").AppendLine();
                buff.Append('\t', indent).AppendLine("{");
                ++indent;
                {
                    buff.Append('\t', indent);
                    buff.Append("var data = ");
                    var parser = XmlBaseParser.Parse(m_xmlDef, "rootNode");
                    parser.ToMember(ref buff, 0);

                    buff.Append('\t', indent);
                    buff.AppendLine("return data;");
                }
                --indent;
                buff.Append('\t', indent).AppendLine("}");
            }
            --indent;
            buff.Append('\t', indent).AppendLine("}");
            --indent;
            buff.AppendLine("}");
            return buff.ToString();
        }

        public virtual void ToDefine(ref StringBuilder buff, int indent)
        {
        }

        public virtual void ToMember(ref StringBuilder buff, int indent)
        {
        }
    }
}
