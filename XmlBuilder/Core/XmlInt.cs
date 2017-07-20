using System;
using System.Text;

namespace XmlBuilder
{
    class XmlInt : XmlBase
    {
        int m_value;

        public XmlInt(int value)
        {
            m_value = value;
            type = "int";
        }

        public override void ToMember(ref StringBuilder buff, int indent)
        {
            buff.Append('\t', indent);
            buff.Append("public ").Append(type).Append(" ").Append(name).Append(" = 0;").AppendLine();
        }
    }
}
