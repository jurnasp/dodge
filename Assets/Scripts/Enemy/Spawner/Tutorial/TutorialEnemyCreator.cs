using System;
using Library.Enemy.Spawner;
using UnityEngine;

namespace Enemy.Spawner.Tutorial
{
    public class TutorialEnemyCreator : MonoBehaviour, IEnemyCreator
    {
        [SerializeField] private TutorialPanelToEnemy[] enemiesToPanels;

        private TutorialPanelToEnemy _currentPanelToEnemy;
        private int _index;

        private void Start()
        {
            ShowPanelAndPrepareEnemy();
        }

        public void Create()
        {
            var enemy = Instantiate(_currentPanelToEnemy.enemy);
            enemy.transform.position += transform.position;
            _index++;

            HideCurrentPanel();

            if (_index < enemiesToPanels.Length)
                ShowPanelAndPrepareEnemy();
        }

        public void IncreaseDifficulty()
        {
        }

        public void OnGameEnd()
        {
            HideCurrentPanel();
        }

        public int GetSpawnCount()
        {
            return _index;
        }

        private void ShowPanelAndPrepareEnemy()
        {
            _currentPanelToEnemy = enemiesToPanels[_index];
            ShowCurrentPanel();
        }

        private void ShowCurrentPanel()
        {
            _currentPanelToEnemy.tutorialPanel.SetActive(true);
        }

        private void HideCurrentPanel()
        {
            _currentPanelToEnemy.tutorialPanel.SetActive(false);
        }

        [Serializable]
        public class TutorialPanelToEnemy
        {
            public GameObject tutorialPanel;
            public GameObject enemy;
        }
    }
}