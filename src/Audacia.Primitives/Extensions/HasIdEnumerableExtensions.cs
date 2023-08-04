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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Miscellaneous Design", "AV1250:Evaluate LINQ query before returning it", Justification = "Deferred execution by design as intended to be chained with other method calls.")]
        public static IEnumerable<T> WithId<T>(this IEnumerable<T> enumerable, int id)
            where T : IHasId
        {
            return enumerable
                .Where(item => item.Id == id);
        }

        /// <summary>
        /// Checks whether an <paramref name="entity"/> is new or existing.
        /// </summary>
        /// <param name="entity">The <paramref name="entity"/> which is being checked if new or existing.</param>
        /// <returns>Whether the <paramref name="entity"/> is 'new'.</returns>
        public static bool IsNew(this IHasId entity) => entity?.Id == default;

        /// <summary>
        /// Determines which elements in an collection need adding, updating or removing from the existing collection.
        /// </summary>
        /// <param name="source">The existing collection of entities.</param>
        /// <param name="newItems">The new collection of entities.</param>
        /// <typeparam name="T">The type of entity.</typeparam>
        /// <returns>A tuple of the following collections, entities needing adding, updating and removed.</returns>
        public static (IEnumerable<T> ToAdd, IEnumerable<T> ToUpdate, IEnumerable<T> ToRemove) DetermineChanges<T>(
            this IEnumerable<T> source,
            IEnumerable<T> newItems)
            where T : IHasId
        {
            var entityWithIds = source as T[] ?? source.ToArray();
            var newItemsList = newItems.ToList();
            var toAdd = newItemsList
                .Where(newModel => newModel.IsNew() || entityWithIds.ToList().TrueForAll(entity => entity.Id != newModel.Id))
                .ToList();

            var toRemove = entityWithIds.Where(entity => newItemsList.TrueForAll(newEntity => newEntity.Id != entity.Id))
                .ToList();

            var toUpdate = entityWithIds
                .Where(entity => toAdd.Select(addEntity => addEntity.Id).All(addId => addId != entity.Id) &&
                                 toRemove.Select(removeEntity => removeEntity.Id)
                                     .All(removeId => removeId != entity.Id))
                .ToList();

            return (toAdd, toUpdate, toRemove);
        }
    }
}
