using UnityEngine;

namespace Dodge.Enemy.Spawner
{
    public class TenCycleSpawnTimer : MonoBehaviour, IEnemySpawnTimer
    {
        private const float EnemySpawnTimeIncrement = 0.25f;
        private const int SpawnCycleSize = 10;
        public float pauseBetweenEnemySpawns = 2.5f;

        public float pauseBetweenSpawnCycles = 5f;
        private float _enemySpawnTimeoutEnd;

        private int _spawnCount;
        private float _spawnCyclePauseEnd;


        public bool CanSpawn()
        {
            return !IsSpawnCyclePause() && !IsEnemySpawnTimeout();
        }

        public void IncreaseDifficulty()
        {
            DecreaseTimeBetweenSpawns();
        }

        public void InvokePause()
        {
            _enemySpawnTimeoutEnd = Time.time + pauseBetweenEnemySpawns;
        }

        public void InvokeLongPause()
        {
            _spawnCyclePauseEnd = Time.time + pauseBetweenSpawnCycles;
        }

        public void IncrementSpawnCount()
        {
            _spawnCount++;
        }

        public bool HasSpawnedEnoughEnemiesForLongPause()
        {
            return _spawnCount % SpawnCycleSize == 0;
        }

        private bool IsSpawnCyclePause()
        {
            return Time.time < _spawnCyclePauseEnd;
        }

        private bool IsEnemySpawnTimeout()
        {
            return Time.time < _enemySpawnTimeoutEnd;
        }

        private void DecreaseTimeBetweenSpawns()
        {
            pauseBetweenEnemySpawns -= EnemySpawnTimeIncrement;
        }
    }
}