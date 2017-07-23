using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace XmlBuilder.Define
{
    class XmlBase
    {
        public string name
        {
            get;
            protected set;
        }

        public string type
        {
            get;
            protected set;
        }

        public string SrcName
        {
            get { return name.Substring(2); }
        }

        public bool IsAttr { get; set; }

        public string ToDefine()
        {
            int indent = 0;
            StringBuilder buff = new StringBuilder();
            buff.AppendLine("using System;");
            buff.AppendLine("using System.Collections.Generic;");
            buff.AppendLine("using System.Xml;");
            buff.AppendLine();
            buff.Append("namespace XmlBuilder.NS_").Append(SrcName).AppendLine();
            buff.AppendLine("{");
            ++indent;
            {
                ToDefine(ref buff, indent);
            }
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

        public static XmlBase Parse(XmlNode node)
        {
            if (node.Attributes.Count + node.ChildNodes.Count > 1)
            {
                if (IsListNode(node))
                {
                    return ParseListNode(node);
                }
                else
                {
                    return ParseClassNode(node);
                }
            }
            else if (node.Attributes.Count > 0)
            {
                return ParseAttribute(node.Attributes[0]);
            }
            else
            {
                return ParseNormalNode(node.ChildNodes[0]);
            }
        }

        protected static XmlBase ParseAttribute(XmlAttribute attr)
        {
            XmlBase target = ParseValue(attr.Value);
            target.name = "m_" + attr.OwnerElement.Name;
            target.IsAttr = true;
            return target;
        }

        protected static XmlBase ParseNormalNode(XmlNode node)
        {
            XmlBase target = ParseValue(node.InnerText);
            target.name = "m_" + node.ParentNode.Name;
            target.IsAttr = false;
            return target;
        }

        protected static XmlClass ParseClassNode(XmlNode node)
        {
            XmlClass target = new XmlClass();
            target.ParseNode(node);
            target.IsAttr = false;
            return target;
        }

        protected static XmlList ParseListNode(XmlNode node)
        {
            XmlList target = new XmlList();
            target.ParseNode(node);
            target.IsAttr = false;
            return target;
        }

        protected static XmlBase ParseValue(string value)
        {
            int valueInt;
            if (int.TryParse(value, out valueInt))
            {
                return new XmlInt(valueInt);
            }
            float valueFloat;
            if (float.TryParse(value, out valueFloat))
            {
                return new XmlFloat(valueFloat);
            }
            if (value == "true" || value == "false")
            {
                return new XmlBool(bool.Parse(value));
            }
            else
            {
                return new XmlString(value);
            }
        }

        protected static bool IsListNode(XmlNode node)
        {
            if (node.Attributes.Count > 0)
                return false;
            if (node.ChildNodes.Count < 2)
                return false;

            string name = node.ChildNodes[0].Name;
            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.Name != name)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
