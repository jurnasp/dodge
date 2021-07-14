namespace Library.Enemy.Spawner
{
    public class Spawner
    {
        private readonly IEnemyCreator _enemyCreator;
        private readonly IEnemySpawnTimer _spawnTimer;
        public bool IsSpawning => _spawnTimer.Stopped;

        public Spawner(IEnemyCreator enemyCreator, IEnemySpawnTimer spawnTimer)
        {
            _enemyCreator = enemyCreator;
            _spawnTimer = spawnTimer;
        }

        public void EndGame()
        {
            _spawnTimer.OnGameEnd();
            _enemyCreator.OnGameEnd();
        }

        public void Tick(float deltaTime)
        {
            _spawnTimer.Tick(deltaTime);
            EvaluateSpawningAnEnemy();
        }

        private void EvaluateSpawningAnEnemy()
        {
            if (_spawnTimer.IsGameEnd()) return;
            
            if (!_spawnTimer.IsLongPause() && _spawnTimer.CanIncreaseDifficulty(_enemyCreator.GetSpawnCount()))
                _spawnTimer.InvokeLongPause(IncreaseDifficulty, _enemyCreator.Create);
            else if (!_spawnTimer.IsLongPause() && !_spawnTimer.IsPause())
                _spawnTimer.InvokePause(_enemyCreator.Create);
        }

        private void IncreaseDifficulty()
        {
            _spawnTimer.IncreaseDifficulty();
            _enemyCreator.IncreaseDifficulty();
        }
    }
}