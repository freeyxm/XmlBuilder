using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace XmlBuilder.Parser
{
    class XmlHelper
    {
        public static int ParseInt(XmlNode node)
        {
            return int.Parse(node.InnerText);
        }
    }
}
