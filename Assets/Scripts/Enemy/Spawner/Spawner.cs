using Dodge.Core;
using Dodge.Library.Enemy.Spawner;
using Library.Enemy.Spawner;
using UnityEngine;

namespace Dodge.Enemy.Spawner
{
    using SpawnerLibrary = global::Library.Enemy.Spawner.Spawner;

    public class Spawner : MonoBehaviour
    {
        private IEnemyCreator _enemyCreator;
        private SpawnerLibrary _spawner;
        private IEnemySpawnTimer _spawnTimer;

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
            _spawner.Tick(Time.deltaTime);
            _spawner.EvaluateSpawningAnEnemy();
        }

        public void StopSpawning()
        {
            _spawner.EndGame();
        }
    }
}