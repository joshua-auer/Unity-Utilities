using System.Collections.Generic;
using UnityEngine;

namespace UnityUtilities
{
    public static class TransformExtensions
    {
        /// <summary>
        /// Retrieves all children of the transform.
        /// </summary>
        /// <returns>An IEnumerable&lt;Transform&gt; of all child transforms.</returns>
        public static IEnumerable<Transform> Children(this Transform parent)
        {
            foreach (Transform child in parent)
                yield return child;
        }

        /// <summary>
        /// Resets the transform's world space position, rotation and scale.
        /// </summary>
        public static void Reset(this Transform transform)
        {
            transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
            transform.localScale = Vector3.one;
        }

        /// <summary>
        /// Resets the transform's local space position, rotation and scale.
        /// </summary>
        public static void ResetLocal(this Transform transform)
        {
            transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            transform.localScale = Vector3.one;
        }

        /// <summary>
        /// Sets the transform's world space position, rotation and scale.
        /// </summary>
        public static void SetPositionRotationAndScale(this Transform transform, Vector3 position, Quaternion rotation, Vector3 scale)
        {
            transform.SetPositionAndRotation(position, rotation);
            transform.localScale = scale;
        }

        /// <summary>
        /// Sets the transform's local space position, rotation and scale.
        /// </summary>
        public static void SetLocalPositionRotationAndScale(this Transform transform, Vector3 localPosition, Quaternion localRotation, Vector3 localScale)
        {
            transform.SetLocalPositionAndRotation(localPosition, localRotation);
            transform.localScale = localScale;
        }

        /// <summary>
        /// Executes the supplied <paramref name="action"/> for each child transform.
        /// </summary>
        /// <param name="action">The action to be executed for each child transform.</param>
        /// <remarks>Iterates through all child transforms in reverse order.</remarks>
        public static void ForEachChild(this Transform parent, System.Action<Transform> action)
        {
            for (int i = parent.childCount - 1; i >= 0; i--)
                action(parent.GetChild(i));
        }

        /// <summary>
        /// Enables all child game objects.
        /// </summary>
        public static void EnableChildren(this Transform parent) => parent.ForEachChild(child => child.gameObject.SetActive(true));

        /// <summary>
        /// Disables all child game objects.
        /// </summary>
        public static void DisableChildren(this Transform parent) => parent.ForEachChild(child => child.gameObject.SetActive(false));

        /// <summary>
        /// Destroys all child game objects.
        /// </summary>
        public static void DestroyChildren(this Transform parent) => parent.ForEachChild(child => Object.Destroy(child.gameObject));

        /// <summary>
        /// Destroys all child game objects immediately.
        /// </summary>
        public static void DestroyChildrenImmediate(this Transform parent) => parent.ForEachChild(child => Object.DestroyImmediate(child.gameObject));

        /// <summary>
        /// Gets a component of type <typeparamref name="T"/> on this transform. If the component doesn't already exist, it adds the component.
        /// </summary>
        /// <typeparam name="T">The type of component to get or add.</typeparam>
        /// <returns>The existing component, or the added component if it doesn't exist.</returns>
        public static T GetOrAddComponent<T>(this Transform transform) where T : Component
        {
            if (!transform.TryGetComponent(out T component))
                component = transform.gameObject.AddComponent<T>();

            return component;
        }
    }
}
