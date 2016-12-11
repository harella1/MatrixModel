using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Prototype
{
    public class Bread : ProductPrototype
    {
        public Bread(decimal price)
            : base(price)
        {

        }

        public override ProductPrototype Clone()
        {
            // Shallow Copy: only top-level objects are duplicated
            return (ProductPrototype) this.MemberwiseClone();

            // Deep Copy: all objects are duplicated
            //return (ProductPrototype)this.Clone();
        }
    }
}
