using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Adapter
{
    public class HttpStreamConnector : Connector
    {
        public override void GetData()
        {
            var websiteScanner = new WebSiteScanner();
            websiteScanner.Scan();
        }
    }
}
