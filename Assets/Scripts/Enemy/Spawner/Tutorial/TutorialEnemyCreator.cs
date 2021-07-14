using System;
using Library.Enemy.Spawner;
using UnityEngine;

namespace Enemy.Spawner.Tutorial
{
    public class TutorialEnemyCreator : MonoBehaviour, IEnemyCreator
    {
        [SerializeField] private TutorialPanel[] enemiesToPanels;

        private TutorialPanel _currentPanel;
        private int _index;
        private int _spawnCount;

        private void Start()
        {
            ShowPanelAndPrepareEnemy();
        }

        public void Create()
        {
            _spawnCount++;
        }

        public void IncreaseDifficulty()
        {
            HideCurrentPanel();
            _index++;

            if (_index < enemiesToPanels.Length)
                ShowPanelAndPrepareEnemy();
        }

        public void OnGameEnd()
        {
        }

        public int GetSpawnCount()
        {
            return _spawnCount;
        }

        private void ShowPanelAndPrepareEnemy()
        {
            
            _currentPanel = enemiesToPanels[_index];
            ShowCurrentPanel();
        }

        private void ShowCurrentPanel()
        {
            _currentPanel.tutorialPanel.SetActive(true);
        }

        private void HideCurrentPanel()
        {
            _currentPanel.tutorialPanel.SetActive(false);
        }

        [Serializable]
        public class TutorialPanel
        {
            public GameObject tutorialPanel;
        }
    }
}