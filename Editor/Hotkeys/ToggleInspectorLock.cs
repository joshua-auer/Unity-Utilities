using UnityEditor;

#if UNITY_2023_2_OR_NEWER
using System.Reflection;
using UnityEngine;
#endif

namespace UnityUtilities
{
    /// <summary>
    /// Adds a hotkey to lock/unlock the inspector.
    /// </summary>
    public static class ToggleInspectorLock
    {
        const string MenuPath = "Edit/Toggle Inspector Lock %l";

#if UNITY_2023_2_OR_NEWER
        static readonly MethodInfo s_flipLockedMethod;

        static ToggleInspectorLock()
        {
            var editorLockTrackerType = typeof(EditorGUIUtility).Assembly.GetType("UnityEditor.EditorGUIUtility+EditorLockTracker");
            s_flipLockedMethod = editorLockTrackerType.GetMethod("FlipLocked", BindingFlags.NonPublic | BindingFlags.Instance);
        }
#endif

        [MenuItem(MenuPath)]
        public static void ToggleInspectorLockMethod()
        {
#if UNITY_2023_2_OR_NEWER
            var inspectorWindowType = typeof(Editor).Assembly.GetType("UnityEditor.InspectorWindow");

            foreach (var inspectorWindow in Resources.FindObjectsOfTypeAll(inspectorWindowType))
            {
                var lockTracker = inspectorWindowType.GetField("m_LockTracker", BindingFlags.NonPublic | BindingFlags.Instance)?.GetValue(inspectorWindow);
                s_flipLockedMethod?.Invoke(lockTracker, new object[] { });
            }
#else
            ActiveEditorTracker.sharedTracker.isLocked = !ActiveEditorTracker.sharedTracker.isLocked;
#endif
            
            ActiveEditorTracker.sharedTracker.ForceRebuild();
        }

        [MenuItem(MenuPath, true)]
        public static bool ValidateToggleInspectorLock() => ActiveEditorTracker.sharedTracker.activeEditors.Length != 0;
    }
}
