namespace Audacia.Primitives
{
    /// <summary>
    /// Represents a type that has a generic Id property.
    /// </summary>
    /// <typeparam name="T">The type of the Id.</typeparam>
    public interface IHasId<out T>
    {
        /// <summary>
        /// Gets the Id.
        /// </summary>
        T Id { get; }
    }

    /// <summary>
    /// Represents a type that has an integer Id property.
    /// </summary>
    public interface IHasId : IHasId<int>
    {
    }
}
