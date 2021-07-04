namespace Dodge.Library.Enemy.Spawner
{
    public interface IEnemySpawnTimer
    {
        bool CanSpawn();
        void IncreaseDifficulty();

        void InvokePause();

        void InvokeLongPause();

        void IncrementSpawnCount();

        bool HasSpawnedEnoughEnemiesForLongPause();

        void OnGameEnd();
    }
}