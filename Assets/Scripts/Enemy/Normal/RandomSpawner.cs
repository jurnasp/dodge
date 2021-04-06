namespace Dodge.Enemy.Normal
{
    public class RandomSpawner : AbstractEnemySpawner
    {
        private int _spawnCount;
        private const int SpawnCycleSize = 10;
        
        public void Update()
        {
            if (!spawnTimer.CanSpawn()) return;
            
            enemyCreator.Create();
            _spawnCount++;

            if (HasSpawnedEnoughEnemiesForSpawnCyclePause())
            {
                spawnTimer.InvokeLongPause();
                IncreaseDifficulty();
                return;
            }
            spawnTimer.InvokePause();
        }

        private bool HasSpawnedEnoughEnemiesForSpawnCyclePause()
        {
            return _spawnCount % SpawnCycleSize == 0;
        }
    }
}