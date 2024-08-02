using UnityEngine;

namespace UnityUtilities
{
    public static class Vector2Extensions
    {
        /// <summary>
        /// Sets any component of the vector.
        /// </summary>
        public static Vector2 With(this Vector2 vector, float? x = null, float? y = null) => new(x ?? vector.x, y ?? vector.y);

        /// <summary>
        /// Adds to any component of the vector.
        /// </summary>
        public static Vector2 Add(this Vector2 vector, float x = 0, float y = 0) => new(vector.x + x, vector.y + y);

        /// <summary>
        /// Returns a vector with the same direction, but the given <paramref name="magnitude"/>.
        /// </summary>
        /// <param name="magnitude">The magnitude of the vector.</param>
        public static Vector2 WithMagnitude(this Vector2 vector, float magnitude) => vector.normalized * magnitude;

        /// <summary>
        /// Returns the displacement between this vector and the target vector.
        /// </summary>
        public static Vector2 To(this Vector2 vector, Vector2 target) => target - vector;

        /// <summary>
        /// Returns the normalized direction from this vector to the target.
        /// </summary>
        public static Vector2 DirectionTo(this Vector2 vector, Vector2 target) => (target - vector).normalized;

        /// <summary>
        /// Swizzles the components of the vector in accordance to the method name.
        /// </summary>
        public static Vector2 YX(this Vector2 vector) => new(vector.y, vector.x);
    }
}
