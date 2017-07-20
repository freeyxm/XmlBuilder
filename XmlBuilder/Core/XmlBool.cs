using System;
using System.Text;

namespace XmlBuilder
{
    class XmlBool : XmlBase
    {
        bool m_value;

        public XmlBool(bool value)
        {
            m_value = value;
            type = "bool";
        }

        public override void ToMember(ref StringBuilder buff, int indent)
        {
            buff.Append('\t', indent);
            buff.Append("public ").Append(type).Append(" ").Append(name).Append(" = false;").AppendLine();
        }
    }
}
