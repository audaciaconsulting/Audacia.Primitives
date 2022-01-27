using System;

namespace Audacia.Primitives
{
    /// <summary>
    /// Implementation of <see cref="IRange{T}"/> for <see cref="DateTime"/>.
    /// </summary>
    public class DateTimeRange : IRange<DateTime>
    {
        /// <inheritdoc />
        public DateTime Start { get; }

        /// <inheritdoc />
        public DateTime End { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimeRange"/> class.
        /// </summary>
        /// <param name="start">The start of the range.</param>
        /// <param name="end">The end of the range.</param>
        public DateTimeRange(DateTime start, DateTime end)
        {
            if (start > end)
            {
                throw new ArgumentOutOfRangeException(nameof(end), "The end of the range must be later than the start of the range.");
            }

            Start = start;
            End = end;
        }
    }
}
