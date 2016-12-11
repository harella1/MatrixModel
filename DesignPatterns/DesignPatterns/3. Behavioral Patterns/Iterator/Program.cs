using DesignPatterns.Strategy;

namespace DesignPatterns
{
    public partial class Program
    {
        public static void Strategy()
        {
            var initial = new[] {0, 1, 2, 3, 4, 5, 6, 7};
            var toRemove = new[] {2, 3, 5};
            IResizer resizeStrategy = new ExactResizer();
            var collection = new ArrayBasedCollection<int>(resizeStrategy);

            foreach (int element in initial)
            {
                collection.Add(element);
            }

            foreach (int elementToRemove in toRemove)
            {
                collection.Remove(elementToRemove);
            }

            collection.Clear();
        }
    }
}