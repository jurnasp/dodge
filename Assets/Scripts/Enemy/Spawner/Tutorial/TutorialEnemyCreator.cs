using System;
using Dodge.Library.Enemy.Spawner;
using UnityEngine;

namespace Dodge.Enemy.Spawner.Tutorial
{
    public class TutorialEnemyCreator : MonoBehaviour, IEnemyCreator
    {
        public float tutorialEnemySpeed = 15f;

        public TutorialEnemyToPanel[] enemiesToPanels;

        private TutorialEnemyToPanel _currentEnemyToPanel;
        private int _index;

        private void Start()
        {
            ShowPanelAndPrepareEnemy();
        }

        public void Create()
        {
            var enemy = Instantiate(GetCurrentEnemyPrefab());

            enemy.transform.position += transform.position;
            enemy.GetComponent<EnemyMove>().speed = tutorialEnemySpeed;
        }

        public void IncreaseDifficulty()
        {
            HidePanel();
            _index++;

            ShowPanelAndPrepareEnemy();
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