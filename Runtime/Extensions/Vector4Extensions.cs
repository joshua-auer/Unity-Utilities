using UnityEngine;

namespace UnityUtilities
{
    public static class Vector4Extensions
    {
        /// <summary>
        /// Sets any component of the vector.
        /// </summary>
        public static Vector4 With(this Vector4 vector, float? x = null, float? y = null, float? z = null, float? w = null) => new(x ?? vector.x, y ?? vector.y, z ?? vector.z, w ?? vector.w);

        /// <summary>
        /// Adds to any component of the vector.
        /// </summary>
        public static Vector4 Add(this Vector4 vector, float x = 0, float y = 0, float z = 0, float w = 0) => new(vector.x + x, vector.y + y, vector.z + z, vector.w + w);

        /// <summary>
        /// Returns a vector with the same direction, but the given <paramref name="magnitude"/>.
        /// </summary>
        /// <param name="magnitude">The magnitude of the vector.</param>
        public static Vector4 WithMagnitude(this Vector4 vector, float magnitude) => vector.normalized * magnitude;

        /// <summary>
        /// Returns the displacement between this vector and the target vector.
        /// </summary>
        public static Vector4 To(this Vector4 vector, Vector4 target) => target - vector;

        /// <summary>
        /// Returns the normalized direction from this vector to the target.
        /// </summary>
        public static Vector4 DirectionTo(this Vector4 vector, Vector4 target) => (target - vector).normalized;

        #region Swizzling

        /// <summary>
        /// Swizzles the components of the vector in accordance to the method name.
        /// </summary>
        public static Vector4 XYWZ(this Vector4 vector) => new(vector.x, vector.y, vector.w, vector.z);

        /// <inheritdoc cref="XYWZ(Vector4)"/>
        public static Vector4 XZYW(this Vector4 vector) => new(vector.x, vector.z, vector.y, vector.w);

        /// <inheritdoc cref="XYWZ(Vector4)"/>
        public static Vector4 XZWY(this Vector4 vector) => new(vector.x, vector.z, vector.w, vector.y);

        /// <inheritdoc cref="XYWZ(Vector4)"/>
        public static Vector4 XWYZ(this Vector4 vector) => new(vector.x, vector.w, vector.y, vector.z);

        /// <inheritdoc cref="XYWZ(Vector4)"/>
        public static Vector4 XWZY(this Vector4 vector) => new(vector.x, vector.w, vector.z, vector.y);

        /// <inheritdoc cref="XYWZ(Vector4)"/>
        public static Vector4 YXZW(this Vector4 vector) => new(vector.y, vector.x, vector.z, vector.w);

        /// <inheritdoc cref="XYWZ(Vector4)"/>
        public static Vector4 YXWZ(this Vector4 vector) => new(vector.y, vector.x, vector.w, vector.z);

        /// <inheritdoc cref="XYWZ(Vector4)"/>
        public static Vector4 YZXW(this Vector4 vector) => new(vector.y, vector.z, vector.x, vector.w);

        /// <inheritdoc cref="XYWZ(Vector4)"/>
        public static Vector4 YZWX(this Vector4 vector) => new(vector.y, vector.z, vector.w, vector.x);

        /// <inheritdoc cref="XYWZ(Vector4)"/>
        public static Vector4 YWXZ(this Vector4 vector) => new(vector.y, vector.w, vector.x, vector.z);

        /// <inheritdoc cref="XYWZ(Vector4)"/>
        public static Vector4 YWZX(this Vector4 vector) => new(vector.y, vector.w, vector.z, vector.x);

        /// <inheritdoc cref="XYWZ(Vector4)"/>
        public static Vector4 ZXYW(this Vector4 vector) => new(vector.z, vector.x, vector.y, vector.w);

        /// <inheritdoc cref="XYWZ(Vector4)"/>
        public static Vector4 ZXWY(this Vector4 vector) => new(vector.z, vector.x, vector.w, vector.y);

        /// <inheritdoc cref="XYWZ(Vector4)"/>
        public static Vector4 ZYXW(this Vector4 vector) => new(vector.z, vector.y, vector.x, vector.w);

        /// <inheritdoc cref="XYWZ(Vector4)"/>
        public static Vector4 ZYWX(this Vector4 vector) => new(vector.z, vector.y, vector.w, vector.x);

        /// <inheritdoc cref="XYWZ(Vector4)"/>
        public static Vector4 ZWXY(this Vector4 vector) => new(vector.z, vector.w, vector.x, vector.y);

        /// <inheritdoc cref="XYWZ(Vector4)"/>
        public static Vector4 ZWYX(this Vector4 vector) => new(vector.z, vector.w, vector.y, vector.x);

        /// <inheritdoc cref="XYWZ(Vector4)"/>
        public static Vector4 WXYZ(this Vector4 vector) => new(vector.w, vector.x, vector.y, vector.z);

        /// <inheritdoc cref="XYWZ(Vector4)"/>
        public static Vector4 WXZY(this Vector4 vector) => new(vector.w, vector.x, vector.z, vector.y);

        /// <inheritdoc cref="XYWZ(Vector4)"/>
        public static Vector4 WYXZ(this Vector4 vector) => new(vector.w, vector.y, vector.x, vector.z);

        /// <inheritdoc cref="XYWZ(Vector4)"/>
        public static Vector4 WYZX(this Vector4 vector) => new(vector.w, vector.y, vector.z, vector.x);

        /// <inheritdoc cref="XYWZ(Vector4)"/>
        public static Vector4 WZXY(this Vector4 vector) => new(vector.w, vector.z, vector.x, vector.y);

        /// <inheritdoc cref="XYWZ(Vector4)"/>
        public static Vector4 WZYX(this Vector4 vector) => new(vector.w, vector.z, vector.y, vector.x);

        #endregion
    }
}
