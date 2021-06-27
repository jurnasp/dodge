using System;
using UnityEngine;

namespace Dodge.Core
{
    public class Themeable : MonoBehaviour
    {
        public void Start()
        {
            if (gameObject.GetComponent<MeshRenderer>() == null)
            {
                throw new MissingComponentException($"{typeof(MeshRenderer)} missing for object with {typeof(Themeable)} script.");
            }
            ThemeManager.Instance.LoadThemeToThemeable(this);
        }

        public string GetMaterialName()
        {
            return gameObject.GetComponent<MeshRenderer>().material.name.Replace("(Instance)", "").Trim();
        }

        public void SetMaterial(Material material)
        {
            gameObject.GetComponent<MeshRenderer>().material = material;
        }
    }
}
