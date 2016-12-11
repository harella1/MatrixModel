using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Prototype
{
    public class CloneableProduct : ICloneable
    {
        public decimal Price { get; set; }

        public CloneableProduct(decimal price)
        {
            Price = price;
        }

        public object Clone()
        {
            // Shallow Copy: only top-level objects are duplicated
            return this.MemberwiseClone();

            // Deep Copy: all objects are duplicated
            //return this.Clone();
        }
    }
}
