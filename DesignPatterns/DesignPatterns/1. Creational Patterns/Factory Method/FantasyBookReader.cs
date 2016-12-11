using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.FactoryMethod
{
    public class FantasyBookReader : BookReader
    {
        public override Book BuyBook()
        {
            return new LordOfTheRings();            
        }
    }
}
