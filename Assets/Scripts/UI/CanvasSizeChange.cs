using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class CanvasSizeChange : MonoBehaviour
    {
        public UnityEvent onCanvasSizeChange;

        private void OnRectTransformDimensionsChange()
        {
            onCanvasSizeChange.Invoke();
        }
    }
}