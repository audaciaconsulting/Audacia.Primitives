﻿using System;
using System.Diagnostics.CodeAnalysis;

namespace Audacia.Primitives
{
    /// <summary>
    /// A class that can be used to describe a timespan in words (for app settings).
    /// </summary>
    public class ConfigurableTimespan
    {
        /// <summary>
        /// Gets or sets the integer value that will be used to convert to a timespan.
        /// </summary>
        public int Value { get; set; } = default;

        /// <summary>
        /// Gets or sets the type of value that has been given.
        /// </summary>
        public ConfigurableTimespanType Type { get; set; }

        /// <summary>
        /// Gets the values that are in settings in Timespan form.
        /// </summary>
        /// <param name="tokenName">The name of the token that is being retrieved from appsettings.</param>
        /// <returns>A timespan representation of the token from appsettings.</returns>
        /// <exception cref="ArgumentException">The given <paramref name="tokenName"/> is invalid.</exception>
        [SuppressMessage("Maintainability", "ACL1002:Member or local function contains too many statements", Justification = "Dependent on number of timespan types.")]
        public TimeSpan GetLifetime(string tokenName)
        {
            TimeSpan span;

            switch (Type)
            {
                case ConfigurableTimespanType.Days:
                    span = TimeSpan.FromDays(Value);
                    break;
                case ConfigurableTimespanType.Hours:
                    span = TimeSpan.FromHours(Value);
                    break;
                case ConfigurableTimespanType.Minutes:
                case ConfigurableTimespanType.Mins:
                    span = TimeSpan.FromMinutes(Value);
                    break;
                case ConfigurableTimespanType.Seconds:
                case ConfigurableTimespanType.Secs:
                    span = TimeSpan.FromSeconds(Value);
                    break;
                default:
                    throw new ArgumentException($"The type for {tokenName} is not recognised");
            }

            if (Value == default)
            {
                throw new ArgumentException($"The value for {tokenName} cannot be zero");
            }

            return span;
        }
    }
}
