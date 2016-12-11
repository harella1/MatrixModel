using System.Linq;
using DesignPatterns.Strategy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns.Tests.BehavioralPatterns
{
    [TestClass]
    public class StrategyTests
    {
        [TestMethod]
        public void Test_ExactResizer()
        {
            var resizeStrategy = new ExactResizer();
            Test_Add_Remove(resizeStrategy);
        }

        [TestMethod]
        public void Test_GeometricResizer()
        {
            var resizeStrategy = new GeometricResizer();
            Test_Add_Remove(resizeStrategy);
        }

        public void Test_Add_Remove(IResizer resizeStrategy)
        {
            var initial = new[] {0, 1, 2, 3, 4, 5, 6, 7};
            var toRemove = new[] {2, 3, 5};
            var collection = new ArrayBasedCollection<int>(resizeStrategy);

            foreach (int element in initial)
            {
                collection.Add(element);
            }
            CollectionAssert.AreEquivalent(initial, collection.ToArray());

            foreach (int elementToRemove in toRemove)
            {
                collection.Remove(elementToRemove);
            }

            int[] expected = initial.Except(toRemove).ToArray();
            CollectionAssert.AreEquivalent(expected, collection.ToArray());

            collection.Clear();
            int[] emptyArray = Enumerable.Empty<int>().ToArray();
            CollectionAssert.AreEquivalent(emptyArray, collection.ToArray());
        }
    }
}