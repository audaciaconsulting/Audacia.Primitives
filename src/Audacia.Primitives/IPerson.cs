namespace Audacia.Primitives
{
    /// <summary>
    /// A type that represents a person.
    /// </summary>
    public interface IPerson
    {
        /// <summary>
        /// Gets the given name, e.g. the first name, of the person.
        /// </summary>
        string GivenName { get; }

        /// <summary>
        /// Gets the surname of the person.
        /// </summary>
        string Surname { get; }
    }
}
