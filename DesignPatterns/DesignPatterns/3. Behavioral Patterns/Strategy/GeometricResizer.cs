using System;

namespace DesignPatterns.Strategy
{
    /// <summary>
    /// Doubles the size of an array if overpopulated.
    /// Halfes the sizei if underpopulated (less then half used.)
    /// Initial capacity is set to 10.
    /// </summary>
    public class GeometricResizer : IResizer
    {
        public int InitialCapacity
        {
            get { return 10; }
        }

        public void OnAdd<T>(ref T[] array, int count)
        {
            if (array.Length >= count) return;
            Array.Resize(ref array, array.Length*2);
        }

        public void OnRemove<T>(ref T[] array, int count)
        {
            if (array.Length/2 >= count) return;
            Array.Resize(ref array, count);
        }
    }
}