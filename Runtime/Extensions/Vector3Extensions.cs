using UnityEngine;

namespace UnityUtilities
{
    public static class Vector3Extensions
    {
        /// <summary>
        /// Sets any component of the vector.
        /// </summary>
        public static Vector3 With(this Vector3 vector, float? x = null, float? y = null, float? z = null) => new(x ?? vector.x, y ?? vector.y, z ?? vector.z);

        /// <summary>
        /// Adds to any component of the vector.
        /// </summary>
        public static Vector3 Add(this Vector3 vector, float x = 0, float y = 0, float z = 0) => new(vector.x + x, vector.y + y, vector.z + z);

        /// <summary>
        /// Returns a vector with the same direction, but the given <paramref name="magnitude"/>.
        /// </summary>
        /// <param name="magnitude">The magnitude of the vector.</param>
        public static Vector3 WithMagnitude(this Vector3 vector, float magnitude) => vector.normalized * magnitude;

        /// <summary>
        /// Returns the displacement between this vector and the target vector.
        /// </summary>
        public static Vector3 To(this Vector3 vector, Vector3 target) => target - vector;

        /// <summary>
        /// Returns the normalized direction from this vector to the target.
        /// </summary>
        public static Vector3 DirectionTo(this Vector3 vector, Vector3 target) => (target - vector).normalized;

        #region Swizzling

        /// <summary>
        /// Swizzles the components of the vector in accordance to the method name.
        /// </summary>
        public static Vector3 XZY(this Vector3 vector) => new(vector.x, vector.z, vector.y);
 
        /// <inheritdoc cref="XZY(Vector3)"/>
        public static Vector3 YXZ(this Vector3 vector) => new(vector.y, vector.x, vector.z);

        /// <inheritdoc cref="XZY(Vector3)"/>
        public static Vector3 YZX(this Vector3 vector) => new(vector.y, vector.z, vector.x);

        /// <inheritdoc cref="XZY(Vector3)"/>
        public static Vector3 ZXY(this Vector3 vector) => new(vector.z, vector.x, vector.y);

        /// <inheritdoc cref="XZY(Vector3)"/>
        public static Vector3 ZYX(this Vector3 vector) => new(vector.z, vector.y, vector.x);

        #endregion
    }
}
