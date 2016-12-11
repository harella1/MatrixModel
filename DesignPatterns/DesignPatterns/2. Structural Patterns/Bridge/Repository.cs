using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace DesignPatterns.Bridge
{
    public abstract class Repository
    {        
        public abstract void AddObject(DataObject dataObject);
        public abstract void CopyObject(DataObject dataObject);
        public abstract void RemoveObject(DataObject dataObject);

        public void SaveChanges()
        {
            Console.WriteLine("Changes were saved");
        }
    }
}
