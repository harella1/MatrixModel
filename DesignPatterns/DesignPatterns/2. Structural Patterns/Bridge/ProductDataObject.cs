using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Bridge
{
    public class ProductDataObject : DataObject
    {
        public override void Register()
        {
            Console.WriteLine("ProductDataObject was registered");
        }

        public override DataObject Copy()
        {
            Console.WriteLine("ProductDataObject was copied");
            return new ProductDataObject();
        }

        public override void Delete()
        {
            Console.WriteLine("ProductDataObject was deleted");
        }
    }
}
