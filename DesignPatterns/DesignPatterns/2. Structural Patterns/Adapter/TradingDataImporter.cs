using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Adapter
{
    public class TradingDataImporter
    {
        public void ImportData(Connector connector)
        {
            connector.GetData();
        }
    }
}
