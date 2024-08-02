using UnityEngine.UIElements;

namespace UnityUtilities
{
    public static class VisualElementExtensions
    {
        /// <summary>
        /// Shows/hides the visual element by enabling/disabling flex.
        /// </summary>
        /// <param name="visible">The visible state of the visual element.</param>
        public static void SetVisible(this VisualElement visualElement, bool visible) => visualElement.style.display = visible ? DisplayStyle.Flex : DisplayStyle.None;

        /// <summary>
        /// Indents the visual element by adjusting the left margin.
        /// </summary>
        public static void Indent(this VisualElement visualElement) => visualElement.style.marginLeft = 15;
    }
}
