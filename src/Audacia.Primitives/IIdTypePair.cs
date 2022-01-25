namespace Audacia.Primitives
{
    /// <summary>
    /// Represents a type that has Id and Type properties.
    /// </summary>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    /// <typeparam name="TType">The type of the type.</typeparam>
    public interface IIdTypePair<out TId, out TType>
    {
        /// <summary>
        /// Gets the Id.
        /// </summary>
        TId Id { get; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        TType Type { get; }
    }
}
