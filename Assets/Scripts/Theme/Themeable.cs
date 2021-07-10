using UnityEngine;

namespace Theme
{
    public class Themeable : MonoBehaviour
    {
        private MeshRenderer MeshRenderer => gameObject.GetComponent<MeshRenderer>();

        private void Start()
        {
            if (MeshRenderer == null)
                Debug.LogError(
                    $"{typeof(MeshRenderer)} missing for object({gameObject.name}) with {typeof(Themeable)} script.");

            ThemeManager.Instance.ApplyThemeToThemeable(this);
        }

        public string GetCurrentMaterialName()
        {
            return MeshRenderer.material.name.Replace("(Instance)", "").Trim();
        }

        public void SetMaterial(Material material)
        {
            MeshRenderer.material = material;
        }
    }
}