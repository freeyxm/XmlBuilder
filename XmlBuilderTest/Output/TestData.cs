using System;
using System.Collections.Generic;
using System.Xml;

namespace XmlBuilder.NS_RootClass
{
	public class Attr33
	{
		public int m_attr0 = 0;
	}

	public class Attr8
	{
		public int m_attr0 = 0;
	}

	public class SubClass
	{
		public string m_attr1 = "";
		public float m_attr2 = 0;
	}

	public class SubClass3
	{
		public string m_attr1 = "";
		public float m_attr2 = 0;
	}

	public class SubClass2
	{
		public SubClass3 m_SubClass3 = new SubClass3();
		public string m_attr1 = "";
		public float m_attr2 = 0;
	}

	public class RootClass
	{
		public Attr33 m_Attr33 = new Attr33();
		public string m_attr1 = "";
		public int m_attr2 = 0;
		public float m_attr3 = 0;
		public string m_attr4 = "";
		public int m_attr5 = 0;
		public float m_attr6 = 0;
		public bool m_attr7 = false;
		public Attr8 m_Attr8 = new Attr8();
		public SubClass m_SubClass = new SubClass();
		public List<int> m_SubList = new List<int>();
		public List<SubClass2> m_SubList2 = new List<SubClass2>();
	}

}
