using UnityEngine;

namespace Dodge.Enemy.Spawner
{
    public class TenCycleSpawnTimer : MonoBehaviour, IEnemySpawnTimer
    {
        public float pauseBetweenEnemySpawns = 2.5f;
        private float _enemySpawnTimeoutEnd;
        
        public float pauseBetweenSpawnCycles = 5f;
        private float _spawnCyclePauseEnd;
        private const float EnemySpawnTimeIncrement = 0.25f;
        
        private int _spawnCount;
        private const int SpawnCycleSize = 10;
        

        public bool CanSpawn()
        {
            return !IsSpawnCyclePause() && !IsEnemySpawnTimeout();
        }

        private bool IsSpawnCyclePause()
        {
            return Time.time < _spawnCyclePauseEnd;
        }

        private bool IsEnemySpawnTimeout()
        {
            return Time.time < _enemySpawnTimeoutEnd;
        }

        public void IncreaseDifficulty()
        {
            DecreaseTimeBetweenSpawns();
        }

        private void DecreaseTimeBetweenSpawns()
        {
            pauseBetweenEnemySpawns -= EnemySpawnTimeIncrement;
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
    }
}
