namespace DesignPatterns.Strategy
{
    /// <summary>
    ///     Determines resizing behaviour of array based collection
    ///     implementation <see cref="ArrayBasedCollection{T}" />
    /// </summary>
    public interface IResizer
    {
        /// <summary>
        ///     Determines initial size of underlaying array.
        /// </summary>
        int InitialCapacity { get; }

        /// <summary>
        ///     Grows the array prior to adding an element(s) if necessary.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">The array to resize.</param>
        /// <param name="count">Minimal required array size.</param>
        void OnAdd<T>(ref T[] array, int count);

        /// <summary>
        ///     Schrinks the array after an alement(s) where removed if necessary.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">The array to resize.</param>
        /// <param name="count">Minimal required array size.</param>
        void OnRemove<T>(ref T[] array, int count);
    }
}