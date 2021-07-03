using Dodge.Library.Enemy.Spawner;

namespace Library.Enemy.Spawner
{
    public class Spawner
    {
        private readonly IEnemyCreator _enemyCreator;
        private readonly IEnemySpawnTimer _spawnTimer;
        
        public Spawner(IEnemyCreator enemyCreator, IEnemySpawnTimer spawnTimer)
        {
            _enemyCreator = enemyCreator;
            _spawnTimer = spawnTimer;
        }

        public void EvaluateSpawningAnEnemy()
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