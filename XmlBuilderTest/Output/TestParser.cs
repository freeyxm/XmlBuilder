using System;
using System.Collections.Generic;
using System.Xml;
using XmlBuilder.Parser;

namespace XmlBuilder.NS_RootClass
{
	public class RootClassParser
	{
		private static Attr33 ParseAttr33(XmlNode rootNode)
		{
			Attr33 data = new Attr33();

			foreach (XmlNode node in rootNode.ChildNodes)
			{
				if (node.NodeType != XmlNodeType.Element)
					continue;
				string nodeName = "m_" + node.Name;
				if(nodeName == "m_attr0")
				{
					data.m_attr0 = XmlHelper.ParseInt(node);
				}
			}

			return data;
		}

		private static Attr8 ParseAttr8(XmlNode rootNode)
		{
			Attr8 data = new Attr8();

			foreach (XmlNode node in rootNode.ChildNodes)
			{
				if (node.NodeType != XmlNodeType.Element)
					continue;
				string nodeName = "m_" + node.Name;
				if(nodeName == "m_attr0")
				{
					data.m_attr0 = XmlHelper.ParseInt(node);
				}
			}

			return data;
		}

		private static SubClass ParseSubClass(XmlNode rootNode)
		{
			SubClass data = new SubClass();

			foreach (XmlNode node in rootNode.ChildNodes)
			{
				if (node.NodeType != XmlNodeType.Element)
					continue;
				string nodeName = "m_" + node.Name;
				if(nodeName == "m_attr1")
				{
					data.m_attr1 = XmlHelper.ParseString(node);
				}
				else if(nodeName == "m_attr2")
				{
					data.m_attr2 = XmlHelper.ParseFloat(node);
				}
			}

			return data;
		}

		private static List<int> ParseSubList(XmlNode rootNode)
		{
			List<int> list = new List<int>();

			foreach (XmlNode node in rootNode.ChildNodes)
			{
				if (node.NodeType != XmlNodeType.Element)
					continue;
				var dataItem = XmlHelper.ParseInt(node);
				list.Add(dataItem);
			}

			return list;
		}

		private static SubClass3 ParseSubClass3(XmlNode rootNode)
		{
			SubClass3 data = new SubClass3();

			foreach (XmlNode node in rootNode.ChildNodes)
			{
				if (node.NodeType != XmlNodeType.Element)
					continue;
				string nodeName = "m_" + node.Name;
				if(nodeName == "m_attr1")
				{
					data.m_attr1 = XmlHelper.ParseString(node);
				}
				else if(nodeName == "m_attr2")
				{
					data.m_attr2 = XmlHelper.ParseFloat(node);
				}
			}

			return data;
		}

		private static SubClass2 ParseSubClass2(XmlNode rootNode)
		{
			SubClass2 data = new SubClass2();

			foreach (XmlNode node in rootNode.ChildNodes)
			{
				if (node.NodeType != XmlNodeType.Element)
					continue;
				string nodeName = "m_" + node.Name;
				if(nodeName == "m_SubClass3")
				{
					data.m_SubClass3 = ParseSubClass3(node);
				}
				else if(nodeName == "m_attr1")
				{
					data.m_attr1 = XmlHelper.ParseString(node);
				}
				else if(nodeName == "m_attr2")
				{
					data.m_attr2 = XmlHelper.ParseFloat(node);
				}
			}

			return data;
		}

		private static List<SubClass2> ParseSubList2(XmlNode rootNode)
		{
			List<SubClass2> list = new List<SubClass2>();

			foreach (XmlNode node in rootNode.ChildNodes)
			{
				if (node.NodeType != XmlNodeType.Element)
					continue;
				var dataItem = ParseSubClass2(node);
				list.Add(dataItem);
			}

			return list;
		}

		private static RootClass ParseRootClass(XmlNode rootNode)
		{
			RootClass data = new RootClass();

			foreach (XmlNode node in rootNode.ChildNodes)
			{
				if (node.NodeType != XmlNodeType.Element)
					continue;
				string nodeName = "m_" + node.Name;
				if(nodeName == "m_Attr33")
				{
					data.m_Attr33 = ParseAttr33(node);
				}
				else if(nodeName == "m_attr1")
				{
					data.m_attr1 = XmlHelper.ParseString(node.Attributes[0]);
				}
				else if(nodeName == "m_attr2")
				{
					data.m_attr2 = XmlHelper.ParseInt(node.Attributes[0]);
				}
				else if(nodeName == "m_attr3")
				{
					data.m_attr3 = XmlHelper.ParseFloat(node.Attributes[0]);
				}
				else if(nodeName == "m_attr4")
				{
					data.m_attr4 = XmlHelper.ParseString(node);
				}
				else if(nodeName == "m_attr5")
				{
					data.m_attr5 = XmlHelper.ParseInt(node);
				}
				else if(nodeName == "m_attr6")
				{
					data.m_attr6 = XmlHelper.ParseFloat(node);
				}
				else if(nodeName == "m_attr7")
				{
					data.m_attr7 = XmlHelper.ParseBool(node);
				}
				else if(nodeName == "m_Attr8")
				{
					data.m_Attr8 = ParseAttr8(node);
				}
				else if(nodeName == "m_SubClass")
				{
					data.m_SubClass = ParseSubClass(node);
				}
				else if(nodeName == "m_SubList")
				{
					data.m_SubList = ParseSubList(node);
				}
				else if(nodeName == "m_SubList2")
				{
					data.m_SubList2 = ParseSubList2(node);
				}
			}

			return data;
		}

		public static RootClass Parse(XmlNode rootNode)
		{
			var data = ParseRootClass(rootNode);
			return data;
		}
	}
}
