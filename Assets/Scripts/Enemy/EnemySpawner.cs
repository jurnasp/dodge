using UnityEngine;

namespace Dodge.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        private IEnemyCreator _enemyCreator;
        
        public float pauseBetweenEnemySpawns = 2.5f;
        private float _enemySpawnTimeoutEnd;
        
        public float pauseBetweenSpawnCycles = 5f;
        private float _spawnCyclePauseEnd;
        private const float EnemySpawnTimeIncrement = 0.25f;

        private int _spawnCount;
        private const int SpawnCycleSize = 10;
        
        public void Start()
        {
            _enemyCreator = gameObject.GetComponent<IEnemyCreator>();
        }
        
        public void Update()
        {
            if (IsSpawnCyclePause()) return;

            if (IsEnemySpawnTimeout()) return;
            
            _enemyCreator.CreateEnemy();
            
            _spawnCount++;
            
            if (HasSpawnedEnoughEnemiesForSpawnCyclePause())
            {
                StartSpawnCyclePause();
                IncreaseDifficulty();
                return;
            }
            StartPauseBetweenSpawns();
        }

        private bool IsSpawnCyclePause()
        {
            return Time.time < _spawnCyclePauseEnd;
        }

        private bool IsEnemySpawnTimeout()
        {
            return Time.time < _enemySpawnTimeoutEnd;
        }

        private bool HasSpawnedEnoughEnemiesForSpawnCyclePause()
        {
            return _spawnCount % SpawnCycleSize == 0;
        }

        private void StartSpawnCyclePause()
        {
            _spawnCyclePauseEnd = Time.time + pauseBetweenSpawnCycles;
        }

        private void IncreaseDifficulty()
        {
            _enemyCreator.IncreaseDifficulty();
            DecreaseTimeBetweenSpawns();
        }

        private void DecreaseTimeBetweenSpawns()
        {
            pauseBetweenEnemySpawns -= EnemySpawnTimeIncrement;
        }

        private void StartPauseBetweenSpawns()
        {
            _enemySpawnTimeoutEnd = Time.time + pauseBetweenEnemySpawns;
        }
    }
}
