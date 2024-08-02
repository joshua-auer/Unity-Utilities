using UnityEngine;

namespace UnityUtilities
{
    public static class Maths
    {
        /// <summary>
        /// Returns true if the value is between, but not equal to, <paramref name="min"/> and <paramref name="max"/>.
        /// </summary>
        public static bool Between(float value, float min, float max) => value > min && value < max;

        /// <summary>
        /// Returns true if the value is between or equal to <paramref name="min"/> and <paramref name="max"/>.
        /// </summary>
        public static bool Within(float value, float min, float max) => value >= min && value <= max;

        /// <summary>
        /// Returns the sign of the value, allowing zero.
        /// </summary>
        public static int SignWithZero(float value) => Mathf.Approximately(value, 0f) ? 0 : value > 0f ? 1 : -1;

        /// <summary>
        /// Returns the sign of the value, allowing zero.
        /// </summary>
        public static int SignWithZero(int value) => Mathf.Approximately(value, 0f) ? 0 : value > 0f ? 1 : -1;

        /// <summary>
        /// Remaps the <paramref name="value"/> from the input range [ <paramref name="iMin"/>...<paramref name="iMax"/> ], to the output range [ <paramref name="oMin"/>...<paramref name="oMax"/> ].
        /// </summary>
        /// <param name="iMin">The minimum value of the input range.</param>
        /// <param name="iMax">The maximum value of the input range.</param>
        /// <param name="oMin">The minimum value of the output range.</param>
        /// <param name="oMax">The maximum value of the output range.</param>
        public static float Remap(float value, float iMin, float iMax, float oMin, float oMax) => Mathf.Lerp(iMin, iMax, Mathf.InverseLerp(oMin, oMax, value));
    }
}
