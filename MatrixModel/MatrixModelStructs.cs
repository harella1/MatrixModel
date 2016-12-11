using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixModel
{
    public class MatrixModelStructs
    {
        public string Name { set; get; }
        public List<Structor> StructorsList { set; get; }
    }

    public class Functional
    {
        public string Name {set ; get;}
        public Type ReturnType {set ; get ;}

        public int Identifier { set; get; }

        public List<Type> Parameters { get; set; }

    }

    public class FunctionalMatrix
    {
        public string Name { set; get; }

        public int Identifier { set; get; }

    }

    public class StructsMatrix
    {
        public string Name { set; get; }
        public List<Attribute> AttributeList { set; get; }
    }

    public class Attribute
    {
        public int Identifier { set; get; }
    }

    public class Propriety
    {
        public string Name { set; get; }
        public Type Type { set; get; }
    }
    public class Structor
    {
        public string Name { set; get; }
        public List<Functional> FunctionalsList { set; get; }
        public List<Propriety> ProprietysList { set; get; }

    }
}
