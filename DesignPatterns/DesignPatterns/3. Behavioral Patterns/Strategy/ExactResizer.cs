using System;

namespace DesignPatterns.Strategy
{
    /// <summary>
    ///     Keeps array size minimal.
    ///     Grows by one if add. Schrinks by one if removed.
    ///     Schrinks to 0 if cleaned. Initial size is set to 0.
    /// </summary>
    public class ExactResizer : IResizer
    {
        public int InitialCapacity
        {
            get { return 0; }
        }

        public void OnAdd<T>(ref T[] array, int count)
        {
            Array.Resize(ref array, count);
        }

        public void OnRemove<T>(ref T[] array, int count)
        {
            Array.Resize(ref array, count);
        }
    }
}