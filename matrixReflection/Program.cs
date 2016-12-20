using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace matrixReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFile(@"C:\Users\Ella\Downloads\MatrixModel\DesignPatterns\DesignPatterns\bin\Debug\DesignPatterns.exe");
            var alltypes = assembly.GetTypes();
            var excluded = new List<string> { "ToString", "Equals", "GetHashCode", "GetType" };
            var alltypes1 = alltypes.Where(x => (x.Namespace != null || x.Namespace.Contains("Annotations")));
            foreach (var item in alltypes1)
            {
                var methods = item.GetMethods().Where(x => !excluded.Contains(x.Name));
            
            }
        }
    }
}
