using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Linq;

namespace MatrixModel
{
    public static class ReflectionHelper
    {
        private static List<string> FunctionalException = new List<string>() { "GetHashCode", "ToString", "GetType", "Equals" };
        public static Structor LoadTypeObject(Type T)
        {
            Structor temp = new Structor();
            try
            {
                temp.FunctionalsList = new List<Functional>();
                temp.ProprietysList = new List<Property>();
                temp.Name =  T.Name;
                temp.FunctionalsList.AddRange(LoadFunctionals(T));
                temp.ProprietysList.AddRange(LoadProperties(T));
                return temp;
               
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error loading type-" + ex.Message);
                return temp;
            }
        }

        public static List<Functional> LoadFunctionals(Type T)
        {
            List<Functional> temp = new List<Functional>();
            try
            {
                MethodInfo[] mth = T.GetMethods();
                foreach (MethodInfo m in mth)
                {
                    if (!FunctionalException.Exists(element => element == m.Name))
                        temp.Add(new Functional()
                        {
                            Name = m.Name,
                            ReturnType = m.ReturnType,
                            Dependencies = new List<Type>(
                            m.GetParameters().Select(x => x.ParameterType)
                            .Union(m.GetMethodBody().LocalVariables
                            .Select(v => v.LocalType)))
                            .Where(ty => !ty.FullName.StartsWith("System", StringComparison.OrdinalIgnoreCase)).ToList()
                        });
                }
                return temp;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error loading type-" + ex.Message);
                return temp;
            }
        }

        public static List<Property> LoadProperties(Type T)
        {
            List<Property> temp = new List<Property>();
            try
            {
                FieldInfo[] proprietys =T.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
                foreach (FieldInfo prop in proprietys)
                {
                    temp.Add(new Property() { Name = prop.Name, Type = prop.GetType() });
                }
                return temp;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error loading Propriety-" + ex.Message);
                return temp;
            }

        }
    }
}
