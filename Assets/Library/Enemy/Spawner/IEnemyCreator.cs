namespace Dodge.Library.Enemy.Spawner
{
    public interface IEnemyCreator
    {
        void Create();

        void IncreaseDifficulty();

        void OnGameEnd();

        int GetSpawnCount();
    }
}