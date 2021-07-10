using Core;
using Dodge.Library.Enemy.Spawner;
using Library.Enemy.Spawner;
using UnityEngine;

namespace Enemy.Spawner
{
    using Spawner = global::Library.Enemy.Spawner.Spawner;

    public class SpawnerMonoBehaviour : MonoBehaviour
    {
        private IEnemyCreator _enemyCreator;
        private Spawner _spawner;
        private IEnemySpawnTimer _spawnTimer;

        private void Awake()
        {
            _enemyCreator = gameObject.GetComponent<IEnemyCreator>();
            _spawnTimer = gameObject.GetComponent<IEnemySpawnTimer>();
        }

        private void Start()
        {
            PlayerConfig.IncrementTotalGamesPlayed();
            _spawner = new Spawner(_enemyCreator, _spawnTimer);
        }

        private void Update()
        {
            _spawner.Tick(Time.deltaTime);
            _spawner.EvaluateSpawningAnEnemy();
        }

        public void StopSpawning()
        {
            _spawner?.EndGame();
        }
    }
}