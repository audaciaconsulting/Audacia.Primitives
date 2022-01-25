namespace Audacia.Primitives
{
    /// <inheritdoc />
    public class IdNamePair<TId> : IIdNamePair<TId>
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public TId Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdNamePair{TId}"/> class.
        /// </summary>
        public IdNamePair()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdNamePair{TId}"/> class.
        /// </summary>
        /// <param name="id">The Id to set.</param>
        /// <param name="name">The name to set.</param>
        public IdNamePair(TId id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    /// <inheritdoc />
    public class IdNamePair : IdNamePair<int>
    {
    }
}
