using System;
using System.IO;
using System.Xml;
using XmlBuilder.Define;
using XmlBuilder.Parser;

namespace XmlBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "../../../XmlBuilderTest/Config/";
            string outputPath = "../../../XmlBuilderTest/Output/";
            XmlDocument doc = new XmlDocument();

            string[] files = Directory.GetFiles(inputPath);
            for (int i = 0; i < files.Length; ++i)
            {
                string file = files[i];
                doc.Load(file);

                XmlBase xmlBase = XmlBase.Parse(doc.FirstChild);

                FileInfo fileInfo = new FileInfo(file);
                string name = fileInfo.Name;
                name = char.ToUpper(name[0]) + name.Substring(1, name.LastIndexOf(".") - 1);

                string dataContent = xmlBase.ToDefine();
                WriteFile(outputPath + name + "Data.cs", dataContent);

                XmlBaseParser parser = XmlBaseParser.Parse(xmlBase, "rootNode");
                string parserContent = parser.ToDefine();
                WriteFile(outputPath + name + "Parser.cs", parserContent);
            }
        }

        static void WriteFile(string fileName, string content)
        {
            using (FileStream file = File.Open(fileName, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    writer.Write(content);
                    writer.Close();
                }
            }
        }
    }
}
