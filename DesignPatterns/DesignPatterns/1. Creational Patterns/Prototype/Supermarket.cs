using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Prototype
{
    public class Supermarket
    {
        private Dictionary<string, ProductPrototype> _productList = 
            new Dictionary<string, ProductPrototype>();

        public void AddProduct(string key, ProductPrototype productPrototype)
        {
            _productList.Add(key, productPrototype);
        }

        public ProductPrototype GetProduct(string key)
        {
            var product = _productList[key];
            return product.Clone();
        }
    }
}
