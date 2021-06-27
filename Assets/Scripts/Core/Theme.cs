using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Dodge.Core
{
    [CreateAssetMenu(fileName = "Themes", menuName = "ScriptableObjects/ThemeScriptableObject", order = 1)]
    public class Theme : ScriptableObject
    {
        public Material[] materials;

        public string themeName;
        public int scoreToUnlock;

        private Dictionary<string, Material> _materialDictionary;

        public bool IsUnlocked()
        {
            return PlayerPrefs.GetInt("TotalScore") >= scoreToUnlock;
        }

        [CanBeNull]
        public Material FindMaterialWithName(string materialName)
        {
            if (_materialDictionary == null) LoadMaterials();
            return _materialDictionary.ContainsKey(materialName) ? _materialDictionary[materialName] : null;
        }
        
        private void LoadMaterials()
        {
            _materialDictionary = new Dictionary<string, Material>();
            foreach (var material in materials)
            {
                _materialDictionary.Add(material.name, material);
            }
        }
    }
}