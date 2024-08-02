using System.Linq;
using UnityEngine;

namespace UnityUtilities
{
    public static class GameObjectExtensions
    {
        /// <summary>
        /// Gets a component of type <typeparamref name="T"/> on this game object. If the component doesn't already exist, it adds the component.
        /// </summary>
        /// <typeparam name="T">The type of component to get or add.</typeparam>
        /// <returns>The existing component, or the added component if it doesn't exist.</returns>
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            if (!gameObject.TryGetComponent(out T component))
                component = gameObject.AddComponent<T>();
            
            return component;
        }

        /// <summary>
        /// Enables all child game objects.
        /// </summary>
        public static void EnableChildren(this GameObject gameObject) => gameObject.transform.EnableChildren();

        /// <summary>
        /// Disables all child game objects.
        /// </summary>
        public static void DisableChildren(this GameObject gameObject) => gameObject.transform.DisableChildren();

        /// <summary>
        /// Destroys all child game objects.
        /// </summary>
        public static void DestroyChildren(this GameObject gameObject) => gameObject.transform.DestroyChildren();

        /// <summary>
        /// Destroys all child game objects immediately.
        /// </summary>
        public static void DestroyChildrenImmediate(this GameObject gameObject) => gameObject.transform.DestroyChildrenImmediate();

        /// <summary>
        /// Returns path in the scene hierarchy of this game object.
        /// </summary>
        /// <returns>A '/' separated string, where each part is the name of a game object, starting from the root and ending with this game object.</returns>
        public static string GetPath(this GameObject gameObject)
        {
            return "/" + string.Join("/", gameObject.GetComponentsInParent<Transform>(true).Select(transform => transform.name).Reverse());
        }
    }
}
