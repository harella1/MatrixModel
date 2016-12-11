using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using DesignPatterns.Iterator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns.Tests.BehavioralPatterns
{
    [TestClass]
    public class IteratorTest
    {
        [TestMethod]
        public void BreadthFirstTree_Iterator_Using_IEnumerator_Test()
        {
            const string treeStr = @"          (ROOT)          " +
                                   "          /    \\         " +
                                   "        (A)    (B)        " +
                                   "        / \\     /        " +
                                   "      (C) (D)  (E)        ";

            const string expected = "ROOT;B;A;E;D;C;";

            var rootNode = BinaryTreeParser.Parse(treeStr);
            var tree = new BreadthFirstTree(rootNode);

            var actual = new StringBuilder();
            using (var iterator = tree.GetEnumerator())
            {
                while (iterator.MoveNext())
                {
                    var currentValue = iterator.Current.Value;
                    actual.Append(currentValue);
                    actual.Append(";");
                }
            }
            Assert.AreEqual(expected, actual.ToString());
        }


        [TestMethod]
        public void DepthFirstTree_Iterator_Using_IEnumerable_Test()
        {
            const string treeStr = @"          (ROOT)          " +
                                   "          /    \\         " +
                                   "        (A)    (B)        " +
                                   "        / \\     /        " +
                                   "      (C) (D)  (E)        ";

            const string expected = "ROOT;B;E;D;A;C;";

            var root = BinaryTreeParser.Parse(treeStr);
            var tree = new DepthFirstTree(root);

            string actual = 
                tree
                    .Select(node => node.Value)
                    .Aggregate(string.Empty, (current, nodeValue) => current + nodeValue + ";");

            Assert.AreEqual(expected, actual);
        }
    }
}
