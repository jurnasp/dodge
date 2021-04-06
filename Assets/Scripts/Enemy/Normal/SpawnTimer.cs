using Dodge.Core;
using UnityEngine;

namespace Dodge.Enemy.Normal
{
    public class SpawnTimer : MonoBehaviour, IEnemySpawnTimer
    {
        public float pauseBetweenEnemySpawns = 2.5f;
        private float _enemySpawnTimeoutEnd;
        
        public float pauseBetweenSpawnCycles = 5f;
        private float _spawnCyclePauseEnd;
        private const float EnemySpawnTimeIncrement = 0.25f;
        

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
    }
}
