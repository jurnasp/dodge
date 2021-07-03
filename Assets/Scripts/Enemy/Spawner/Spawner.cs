using Dodge.Core;
using UnityEngine;

namespace Dodge.Enemy.Spawner
{
    public class Spawner : MonoBehaviour
    {
        private IEnemyCreator _enemyCreator;
        private IEnemySpawnTimer _spawnTimer;

        private void Awake()
        {
            _enemyCreator = gameObject.GetComponent<IEnemyCreator>();
            _spawnTimer = gameObject.GetComponent<IEnemySpawnTimer>();
        }

        private void Start()
        {
            PlayerConfig.IncrementTotalGamesPlayed();
        }

        private void Update()
        {
            if (!_spawnTimer.CanSpawn()) return;

            _enemyCreator.Create();
            _spawnTimer.IncrementSpawnCount();

            if (_spawnTimer.HasSpawnedEnoughEnemiesForLongPause())
            {
                _spawnTimer.InvokeLongPause();
                IncreaseDifficulty();
                return;
            }

            _spawnTimer.InvokePause();
        }

        private void IncreaseDifficulty()
        {
            _spawnTimer.IncreaseDifficulty();
            _enemyCreator.IncreaseDifficulty();
        }
    }
}