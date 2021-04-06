namespace Dodge.Core
{
    public interface IEnemySpawnTimer
    {
        bool CanSpawn();
        void IncreaseDifficulty();

        void InvokePause();

        void InvokeLongPause();
    }
}