using System;
using System.Collections.Generic;

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

        public List<Type> Dependencies { get; set; }

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

    public class Property
    {
        public string Name { set; get; }
        public Type Type { set; get; }
    }
    public class Structor
    {
        public string Name { set; get; }
        public List<Functional> FunctionalsList { set; get; }
        public List<Property> ProprietysList { set; get; }

    }
}
