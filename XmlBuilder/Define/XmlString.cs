using System;
using System.Text;

namespace XmlBuilder.Define
{
    class XmlString : XmlBase
    {
        string m_value;

        public XmlString(string value)
        {
            m_value = value;
            type = "string";
        }

        public override void ToMember(ref StringBuilder buff, int indent)
        {
            buff.Append('\t', indent);
            buff.Append("public ").Append(type).Append(" ").Append(name).Append(" = \"\";").AppendLine();
        }
    }
}
