using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Adapter
{
    public class DatabaseConnector : Connector
    {
        public override void GetData()
        {
            var databaseHelper = new DatabaseHelper();
            databaseHelper.QueryForChanges();           
        }
    }
}
