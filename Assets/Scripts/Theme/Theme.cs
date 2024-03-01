using System.Collections.Generic;
using Core;
using JetBrains.Annotations;
using UnityEngine;

namespace Theme
{
    [CreateAssetMenu(fileName = "Themes", menuName = "ScriptableObjects/ThemeScriptableObject", order = 1)]
    public class Theme : ScriptableObject
    {
        public Material DefaultMaterial() => new(Shader.Find("Standard")) { color = Color.magenta };
        public Material[] materials;

        public string themeName;
        public int totalScoreToUnlock;
        public int highScoreToUnlock;

        private Dictionary<string, Material> _materialDictionary;

        public bool IsUnlocked()
        {
            return PlayerConfig.GetTotalScore() >= totalScoreToUnlock
                || PlayerConfig.GetHighScore() >= highScoreToUnlock;
        }

        [CanBeNull]
        public Material FindMaterialWithName(string materialName)
        {
            if (_materialDictionary == null) LoadMaterials();
            return MaterialExists(materialName) ? _materialDictionary[materialName] : DefaultMaterial();
        }

        private bool MaterialExists(string materialName)
        {
            return _materialDictionary.ContainsKey(materialName);
        }

        private void LoadMaterials()
        {
            _materialDictionary = new Dictionary<string, Material>();
            foreach (var material in materials)
            {
                if (material.GetType() != typeof(Material) || material == null)
                {
                    Debug.LogWarning($"Missing material in {themeName}");
                    continue;
                }

                _materialDictionary.Add(material.name, material);
            }
        }
    }
}