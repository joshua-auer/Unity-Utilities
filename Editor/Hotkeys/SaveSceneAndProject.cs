using UnityEditor;

namespace UnityUtilities
{
    /// <summary>
    /// Adds a hotkey to save both the scene and the project simultaneously.
    /// </summary>
    public static class SaveSceneAndProject
    {
        const string MenuPath = "File/Save Scene and Project %#&s";
        const string SaveMenuPath = "File/Save";
        const string SaveProjectMenuPath = "File/Save Project";

        [MenuItem(MenuPath)]
        public static void SaveSceneAndProjectMethod()
        {
            EditorApplication.ExecuteMenuItem(SaveMenuPath);
            EditorApplication.ExecuteMenuItem(SaveProjectMenuPath);
        }
    }
}
