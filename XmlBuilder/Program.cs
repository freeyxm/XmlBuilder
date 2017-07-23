using System;
using System.IO;
using System.Xml;
using XmlBuilder.Define;

namespace XmlBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "../../test.xml";

            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlBase xmlBase = XmlBase.ParseNode(doc.FirstChild);
            string str = xmlBase.ToDefine();

            using (FileStream file = File.Open(path + ".out", FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    writer.Write(str);
                    writer.Close();
                }
            }

        }
    }
}
