using UnityEngine;

namespace Dodge.Core
{
    public class Themeable : MonoBehaviour
    {
        private MeshRenderer MeshRenderer => gameObject.GetComponent<MeshRenderer>();

        public void Start()
        {
            if (MeshRenderer == null)
            {
                Debug.LogError(
                    $"{typeof(MeshRenderer)} missing for object({gameObject.name}) with {typeof(Themeable)} script.");
            }

            ThemeManager.Instance.ApplyThemeToThemeable(this);
        }

        public string GetMaterialName()
        {
            return MeshRenderer.material.name.Replace("(Instance)", "").Trim();
        }

        public void SetMaterial(Material material)
        {
            MeshRenderer.material = material;
        }
    }
}