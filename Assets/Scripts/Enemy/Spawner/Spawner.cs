using Dodge.Core;
using Dodge.Library.Enemy.Spawner;
using UnityEngine;

namespace Dodge.Enemy.Spawner
{
    using SpawnerLibrary = global::Library.Enemy.Spawner.Spawner;
    public class Spawner : MonoBehaviour
    {
        private IEnemyCreator _enemyCreator;
        private IEnemySpawnTimer _spawnTimer;
        private SpawnerLibrary _spawner;

        private void Awake()
        {
            _enemyCreator = gameObject.GetComponent<IEnemyCreator>();
            _spawnTimer = gameObject.GetComponent<IEnemySpawnTimer>();
        }

        private void Start()
        {
            PlayerConfig.IncrementTotalGamesPlayed();
            _spawner = new SpawnerLibrary(_enemyCreator, _spawnTimer);
        }

        private void Update()
        {
            _spawner.EvaluateSpawningAnEnemy();
        }

        public void OnGameEnd()
        {
            _spawner.EndGame();
        }
    }
}