using System;
using System.Xml;

namespace XmlBuilder.Parser
{
    public class XmlHelper
    {
        #region XmlNode
        public static int ParseInt(XmlNode node)
        {
            return ParseInt(node.InnerText);
        }

        public static float ParseFloat(XmlNode node)
        {
            return ParseFloat(node.InnerText);
        }

        public static bool ParseBool(XmlNode node)
        {
            return ParseBool(node.InnerText);
        }

        public static string ParseString(XmlNode node)
        {
            return node.InnerText;
        }
        #endregion

        #region XmlAttribute
        public static int ParseInt(XmlAttribute attr)
        {
            return ParseInt(attr.Value);
        }

        public static float ParseFloat(XmlAttribute attr)
        {
            return ParseFloat(attr.Value);
        }

        public static bool ParseBool(XmlAttribute attr)
        {
            return ParseBool(attr.Value);
        }

        public static string ParseString(XmlAttribute attr)
        {
            return attr.Value;
        }
        #endregion

        #region Parse
        public static int ParseInt(string value)
        {
            return int.Parse(value);
        }

        public static float ParseFloat(string value)
        {
            return float.Parse(value);
        }

        public static bool ParseBool(string value)
        {
            return bool.Parse(value);
        }
        #endregion
    }
}
