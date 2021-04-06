using System;
using Dodge.Core;
using UnityEngine;

namespace Dodge.Enemy.Spawner.Tutorial
{
    public class TutorialEnemyCreator : MonoBehaviour, IEnemyCreator
    {
        public float tutorialEnemySpeed = 15f;
        
        [Serializable]
        public class TutorialEnemyToPanel
        {
            public GameObject tutorialPrefab;
            public GameObject tutorialPanel ;
        }

        public TutorialEnemyToPanel[] enemiesToPanels;

        private TutorialEnemyToPanel _currentEnemyToPanel;
        private int _index;

        public void Start()
        {
            ShowPanelAndPrepareEnemy();
        }

        public void Create()
        {
            var enemy = Instantiate(GetCurrentEnemyPrefab());
            
            enemy.transform.position += transform.position;
            enemy.GetComponent<EnemyMove>().speed = tutorialEnemySpeed;
        }

        private GameObject GetCurrentEnemyPrefab()
        {
            return _currentEnemyToPanel.tutorialPrefab;
        }

        public void IncreaseDifficulty()
        {
            HidePanel();
            _index++;

            ShowPanelAndPrepareEnemy();
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
    }
}