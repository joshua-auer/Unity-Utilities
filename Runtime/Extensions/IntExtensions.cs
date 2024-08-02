using UnityEngine;

namespace UnityUtilities
{
    public static class IntExtensions
    {
        /// <summary>
        /// Returns true if the value is between, but not equal to, <paramref name="min"/> and <paramref name="max"/>.
        /// </summary>
        public static bool Between(this int value, int min, int max) => value > min && value < max;

        /// <summary>
        /// Returns true if the value is between or equal to <paramref name="min"/> and <paramref name="max"/>.
        /// </summary>
        public static bool Within(this int value, int min, int max) => value >= min && value <= max;

        /// <summary>
        /// Clamps the value to be at least <paramref name="min"/>.
        /// </summary>
        public static int AtLeast(this int value, int min) => Mathf.Max(value, min);

        /// <summary>
        /// Clamps the value to be at most <paramref name="max"/>.
        /// </summary>
        public static int AtMost(this int value, int max) => Mathf.Min(value, max);

        /// <summary>
        /// Returns the sign of the value, allowing zero.
        /// </summary>
        public static int SignWithZero(this int value) => Mathf.Approximately(value, 0f) ? 0 : value > 0f ? 1 : -1;

        /// <summary>
        /// Returns true if the value is an even number.
        /// </summary>
        public static bool IsEven(this int value) => value % 2 == 0;

        /// <summary>
        /// Returns true if the value is an odd number.
        /// </summary>
        public static bool IsOdd(this int value) => value % 2 != 0;
    }
}
