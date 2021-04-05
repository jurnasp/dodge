using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Enemy
{
    public class EnemyCreator : MonoBehaviour
    {
        public List<GameObject> enemyPrefabs;
    
        public float enemySpeed = 15f;
        private float _enemySpeedAdd = 5f;
        
        private float _enemySpawnTimeIncrement = 0.25f;
        
        public float pauseBetweenEnemySpawns = 2.5f;
        private float _enemySpawnTimeoutEnd;
        
        public float pauseBetweenSpawnCycles = 5f;
        private float _spawnCyclePauseEnd;
        
        private Random _random;

        private int _spawnCount;
        private const int SpawnCycleSize = 10;

        public void Start()
        {
            _enemySpawnTimeoutEnd = Time.time;
            _random = new Random();
        }

        public void Update()
        {
            if (IsSpawnCyclePause()) {return;}

            if (CanSpawnEnemy())
            {
                SpawnRandomEnemy();
            }
        }

        private bool IsSpawnCyclePause()
        {
            return Time.time < _spawnCyclePauseEnd;
        }

        private bool CanSpawnEnemy()
        {
            return Time.time > _enemySpawnTimeoutEnd;
        }

        private void SpawnRandomEnemy()
        {
            var enemy = Instantiate(GetRandomEnemyPrefab());
            enemy.transform.position += transform.position;
            enemy.GetComponent<EnemyMove>().speed = enemySpeed;
            
            _spawnCount++;
            
            if (HasSpawnedEnoughEnemiesForSpawnCyclePause())
            {
                StartSpawnCyclePause();
                IncreaseDifficulty();
                return;
            }
            StartPauseBetweenSpawns();
        }

        private GameObject GetRandomEnemyPrefab()
        {
            var index = _random.Next(enemyPrefabs.Count);
            var enemy = enemyPrefabs[index];
            return enemy;
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
            IncreaseSpeed();
            DecreaseTimeBetweenSpawns();
        }

        public void IncreaseSpeed()
        {
            enemySpeed += _enemySpeedAdd;
        }

        public void DecreaseTimeBetweenSpawns()
        {
            pauseBetweenEnemySpawns -= _enemySpawnTimeIncrement;
        }

        private void StartPauseBetweenSpawns()
        {
            _enemySpawnTimeoutEnd = Time.time + pauseBetweenEnemySpawns;
        }
    }
}
