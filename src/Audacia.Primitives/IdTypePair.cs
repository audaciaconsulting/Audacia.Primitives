namespace Audacia.Primitives
{
    /// <inheritdoc />
    public class IdTypePair<TId, TType> : IIdTypePair<TId, TType>
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public TId Id { get; set; } = default!;

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public TType Type { get; set; } = default!;

        /// <summary>
        /// Initializes a new instance of the <see cref="IdTypePair{TId, TType}"/> class.
        /// </summary>
        public IdTypePair()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdTypePair{TId, TType}"/> class.
        /// </summary>
        /// <param name="id">The Id to set.</param>
        /// <param name="type">The type to set.</param>
        public IdTypePair(TId id, TType type)
        {
            Id = id;
            Type = type;
        }
    }

    /// <inheritdoc />
    public class IdTypePair<TType> : IdTypePair<int, TType>
    {
    }
}
