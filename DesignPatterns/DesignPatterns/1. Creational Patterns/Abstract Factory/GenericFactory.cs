using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.AbstractFactory
{
    public class GenericFactory<T> 
        where T : new()
    {
        public T CreateObject()
        {
            return new T();
        }
    }
}
