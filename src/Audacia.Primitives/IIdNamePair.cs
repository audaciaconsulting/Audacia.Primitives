namespace Audacia.Primitives
{
    /// <summary>
    /// Represents a type that has Id and Name properties.
    /// </summary>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public interface IIdNamePair<out TId>
    {
        /// <summary>
        /// Gets the Id.
        /// </summary>
        TId Id { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        string Name { get; }
    }
}
