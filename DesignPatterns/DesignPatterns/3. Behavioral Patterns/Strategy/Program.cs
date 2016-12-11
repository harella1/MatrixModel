using System;
using System.Collections.Generic;
using System.Text;
using DesignPatterns.Iterator;

namespace DesignPatterns
{
    public partial class Program
    {
        public static void Iterator()
        {
            var root = 
                new Node
                    {
                        Value = "ROOT",
 
                        Left = 
                            new Node
                                {
                                    Value = "LEFT"
                                },
 
                        Right = 
                            new Node
                                {
                                    Value = "RIGHT"
                                }
                    };

            var tree = new BreadthFirstTree(root);

            var traversal = new StringBuilder();
            using (IEnumerator<Node> iterator = tree.GetEnumerator())
            {
                while (iterator.MoveNext())
                {
                    string currentValue = iterator.Current.Value;
                    traversal.Append(currentValue);
                    traversal.Append(";");
                }
            }
            Console.WriteLine(traversal.ToString());
        }
    }
}