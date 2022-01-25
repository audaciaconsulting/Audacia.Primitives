using System.Collections.Generic;
using System.Linq;

namespace Audacia.Primitives
{
    /// <summary>
    /// Extensions to <see cref="IEnumerable{T}"/> relating to entities that implement <see cref="IHasId"/>.
    /// </summary>
    public static class HasIdEnumerableExtensions
    {
        /// <summary>
        /// Filters the given <paramref name="enumerable"/> to only return items with the given <paramref name="id"/>.
        /// </summary>
        /// <typeparam name="T">The type of entity in the given <paramref name="enumerable"/>.</typeparam>
        /// <param name="enumerable">The collection to filter.</param>
        /// <param name="id">The Id to match.</param>
        /// <returns>An <see cref="IQueryable{T}"/> instance that has been filtered to the given <paramref name="id"/>.</returns>
        public static IQueryable<T> WithId<T>(this IEnumerable<T> enumerable, int id)
            where T : IHasId
        {
            return enumerable
                .AsQueryable()
                .Where(item => item.Id == id);
        }
    }
}
