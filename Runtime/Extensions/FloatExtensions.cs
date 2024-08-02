using UnityEngine;

namespace UnityUtilities
{
    public static class FloatExtensions
    {
        /// <summary>
        /// Returns true if the value is approximately the same as the provided <paramref name="comparisonValue"/>.
        /// </summary>
        public static bool Approx(this float value, float comparisonValue) => Mathf.Approximately(value, comparisonValue);

        /// <summary>
        /// Returns true if the value is between, but not equal to, <paramref name="min"/> and <paramref name="max"/>.
        /// </summary>
        public static bool Between(this float value, float min, float max) => value > min && value < max;

        /// <summary>
        /// Returns true if the value is between or equal to <paramref name="min"/> and <paramref name="max"/>.
        /// </summary>
        public static bool Within(this float value, float min, float max) => value >= min && value <= max;

        /// <summary>
        /// Clamps the value to be at least <paramref name="min"/>.
        /// </summary>
        public static float AtLeast(this float value, float min) => Mathf.Max(value, min);

        /// <summary>
        /// Clamps the value to be at most <paramref name="max"/>.
        /// </summary>
        public static float AtMost(this float value, float max) => Mathf.Min(value, max);

        /// <summary>
        /// Returns the sign of the value, allowing zero.
        /// </summary>
        public static int SignWithZero(this float value) => Mathf.Approximately(value, 0f) ? 0 : value > 0f ? 1 : -1;

        /// <summary>
        /// Remaps the value from the input range [ <paramref name="iMin"/>...<paramref name="iMax"/> ], to the output range [ <paramref name="oMin"/>...<paramref name="oMax"/> ].
        /// </summary>
        /// <param name="iMin">The minimum value of the input range.</param>
        /// <param name="iMax">The maximum value of the input range.</param>
        /// <param name="oMin">The minimum value of the output range.</param>
        /// <param name="oMax">The maximum value of the output range.</param>
        public static float Remap(this float value, float iMin, float iMax, float oMin, float oMax) => Mathf.Lerp(oMin, oMax, Mathf.InverseLerp(iMin, iMax, value));
    }
}
