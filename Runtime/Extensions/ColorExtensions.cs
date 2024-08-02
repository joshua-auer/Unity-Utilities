using UnityEngine;

namespace UnityUtilities
{
    public static class ColorExtensions
    {
        /// <summary>
        /// Sets any component of the color.
        /// </summary>
        public static Color With(this Color color, float? r = null, float? g = null, float? b = null, float? a = null) => new(r ?? color.r, g ?? color.g, b ?? color.b, a ?? color.a);

        /// <summary>
        /// Adds to any component of the color.
        /// </summary>
        public static Color Add(this Color color, float r = 0, float g = 0, float b = 0, float a = 0) => new(color.r + r, color.g + g, color.b + b, color.a + a);
    }
}
