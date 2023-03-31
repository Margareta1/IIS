using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection.PortableExecutable;
using System;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
namespace IIS.Services
{
    public class XPathService
    {

        public static IList<XmlNode> Search(string type, string value)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"..\IIS\Assets\billboardrecents.xml");
            XPathNavigator navigator = xmlDoc.CreateNavigator();
            //string xpathExpr = $"//Datum[{type}='{value}']";
            string xpathExpr = $"//Datum[contains({type},'{value}')]";
            XPathNodeIterator nodes = navigator.Select(xpathExpr);
            var nodesList = new List<XmlNode>();
            while (nodes.MoveNext())
            {
                XmlNode node = ((IHasXmlNode)nodes.Current).GetNode();
                nodesList.Add(node);
            }
            return nodesList;
        }

    }
}
