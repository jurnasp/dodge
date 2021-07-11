using System;
using Library.Enemy.Spawner;
using UnityEngine;

namespace Enemy.Spawner.Tutorial
{
    public class TutorialEnemyCreator : MonoBehaviour, IEnemyCreator
    {
        public float tutorialEnemySpeed = 15f;

        public TutorialEnemyToPanel[] enemiesToPanels;

        private TutorialEnemyToPanel _currentEnemyToPanel;
        private int _index;
        private int _spawnCount;

        private void Start()
        {
            ShowPanelAndPrepareEnemy();
        }

        public void Create()
        {
            var enemy = Instantiate(GetCurrentEnemyPrefab());

            enemy.transform.position += transform.position;
            enemy.GetComponent<EnemyMove>().speed = tutorialEnemySpeed;

            _spawnCount++;
        }

        public void IncreaseDifficulty()
        {
            HidePanel();
            _index++;

            ShowPanelAndPrepareEnemy();
        }

        public void OnGameEnd()
        {
        }

        public int GetSpawnCount()
        {
            return _spawnCount;
        }

        private GameObject GetCurrentEnemyPrefab()
        {
            return _currentEnemyToPanel.tutorialPrefab;
        }

        private void ShowPanelAndPrepareEnemy()
        {
            _currentEnemyToPanel = enemiesToPanels[_index];
            ShowPanel();
        }

        private void ShowPanel()
        {
            _currentEnemyToPanel.tutorialPanel.SetActive(true);
        }

        private void HidePanel()
        {
            _currentEnemyToPanel.tutorialPanel.SetActive(false);
        }

        [Serializable]
        public class TutorialEnemyToPanel
        {
            public GameObject tutorialPrefab;
            public GameObject tutorialPanel;
        }
    }
}