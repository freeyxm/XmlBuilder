using System;
using System.Text;

namespace XmlBuilder
{
    class XmlFloat : XmlBase
    {
        float m_value;

        public XmlFloat(float value)
        {
            m_value = value;
            type = "float";
        }

        public override void ToMember(ref StringBuilder buff, int indent)
        {
            buff.Append('\t', indent);
            buff.Append("public ").Append(type).Append(" ").Append(name).Append(" = 0;").AppendLine();
        }
    }
}
