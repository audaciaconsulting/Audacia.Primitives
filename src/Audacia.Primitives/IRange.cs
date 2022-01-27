namespace Audacia.Primitives
{
    /// <summary>
    /// A type that represents something with a start and an end.
    /// </summary>
    /// <typeparam name="T">The type of object that is defining the range.</typeparam>
    internal interface IRange<out T>
    {
        /// <summary>
        /// Gets the start of the range.
        /// </summary>
        T Start { get; }

        /// <summary>
        /// Gets the end of the range.
        /// </summary>
        T End { get; }
    }
}
