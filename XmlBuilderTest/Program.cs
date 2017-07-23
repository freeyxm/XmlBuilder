using System;
using System.Xml;
using System.IO;
using XmlBuilder.NS_RootClass;

namespace XmlBuilderTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string path;
            string inputPath = "../../Config/";
            string outputPath = "../../Output/";
            XmlDocument doc = new XmlDocument();

            string[] files = Directory.GetFiles(inputPath);
            for (int i = 0; i < files.Length; ++i)
            {
                path = files[i];
                doc.Load(path);

                RootClass data = RootClassParser.Parse(doc.FirstChild);
                break; //!!!
            }
        }
    }
}