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

        public void Tick(float deltaTime)
        {
            _spawnTimer.Tick(deltaTime);
        }

        public void EvaluateSpawningAnEnemy()
        {
            if (!_spawnTimer.IsLongPause() && _spawnTimer.CanIncreaseDifficulty(_enemyCreator.GetSpawnCount()))
                _spawnTimer.InvokeLongPause(IncreaseDifficulty, _enemyCreator.Create);
            else if (!_spawnTimer.IsLongPause() && !_spawnTimer.IsPause() && !_spawnTimer.IsGameEnd())
                _spawnTimer.InvokePause(_enemyCreator.Create);
        }

        private void IncreaseDifficulty()
        {
            _spawnTimer.IncreaseDifficulty();
            _enemyCreator.IncreaseDifficulty();
        }

        public void EndGame()
        {
            _spawnTimer.OnGameEnd();
            _enemyCreator.OnGameEnd();
        }
    }
}