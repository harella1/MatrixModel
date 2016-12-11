using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Adapter
{
    public class XmlFileConnector : Connector
    {
        public override void GetData()
        {
            var xmlfileLoader = new XmlFileLoader();
            xmlfileLoader.LoadXML();
        }
    }
}
