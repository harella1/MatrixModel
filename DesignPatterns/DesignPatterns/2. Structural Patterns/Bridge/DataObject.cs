using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Bridge
{
    public abstract class DataObject
    {
        public abstract void Register();
        public abstract DataObject Copy();
        public abstract void Delete();
    }
}
