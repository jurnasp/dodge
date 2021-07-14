using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Enemy.Spawner
{
    public class EnemySpawnerManager : MonoBehaviour
    {
        [SerializeField] private GameObject tutorialSpawner;
        [SerializeField] private GameObject gameSpawner;

        private Dictionary<SpawnerType, SpawnerCache> _spawnerCache;

        private void Start()
        {
            SetupSpawnerCache();

            if (PlayerConfig.GetIsTutorialEnabled()) StartTutorial();
            else StartGame();
        }

        private void Update()
        {
            if (!PlayerConfig.GetIsTutorialEnabled()) return;
            if (_spawnerCache[SpawnerType.Tutorial].spawner.IsSpawning) return;

            PlayerConfig.SetIsTutorialEnabled(false);
            EnableGameAndDisableTutorial(true);
        }

        private void SetupSpawnerCache()
        {
            _spawnerCache = new Dictionary<SpawnerType, SpawnerCache>
            {
                {
                    SpawnerType.Tutorial, new SpawnerCache
                    {
                        spawnerGameObject = tutorialSpawner,
                        spawner = tutorialSpawner.GetComponent<SpawnerMonoBehaviour>()
                    }
                },
                {
                    SpawnerType.Game, new SpawnerCache
                    {
                        spawnerGameObject = gameSpawner,
                        spawner = gameSpawner.GetComponent<SpawnerMonoBehaviour>()
                    }
                }
            };
        }

        private void StartGame()
        {
            EnableGameAndDisableTutorial(true);
        }

        private void StartTutorial()
        {
            EnableGameAndDisableTutorial(false);
        }

        private void EnableGameAndDisableTutorial(bool enable)
        {
            _spawnerCache[SpawnerType.Game].spawnerGameObject.SetActive(enable);
            _spawnerCache[SpawnerType.Tutorial].spawnerGameObject.SetActive(!enable);
        }

        private enum SpawnerType
        {
            Tutorial,
            Game
        }

        private class SpawnerCache
        {
            public SpawnerMonoBehaviour spawner;
            public GameObject spawnerGameObject;
        }
    }
}