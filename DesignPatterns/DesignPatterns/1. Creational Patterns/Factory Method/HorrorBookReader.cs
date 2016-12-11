using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.FactoryMethod
{
    public class HorrorBookReader : BookReader
    {
        public override Book BuyBook()
        {
            return new Dracula();
        }
    }
}
