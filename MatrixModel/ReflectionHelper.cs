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
                temp.ProprietysList = new List<Propriety>();
                temp.Name =  T.Name;
                temp.FunctionalsList.AddRange(LoadFunctionals(T));
                temp.ProprietysList.AddRange(LoadProprietys(T));
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
                    {
                        temp.Add(new Functional() { Name = m.Name,
                            ReturnType = m.ReturnType,
                            Parameters = new List<Type>(
                            m.GetParameters().Select(x=>x.ParameterType))
                        });
                        var pInfo = m.GetParameters();
                        var mb = m.GetMethodBody();
                        var locvars = mb.LocalVariables;
                    }
                }
                return temp;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error loading type-" + ex.Message);
                return temp;
            }
        }

        public static List<Propriety> LoadProprietys(Type T)
        {
            List<Propriety> temp = new List<Propriety>();
            try
            {
                FieldInfo[] proprietys =T.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
                foreach (FieldInfo prop in proprietys)
                {
                    temp.Add(new Propriety() { Name = prop.Name, Type = prop.GetType() });
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
