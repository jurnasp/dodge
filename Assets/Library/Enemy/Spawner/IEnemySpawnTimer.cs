using System;

namespace Library.Enemy.Spawner
{
    public interface IEnemySpawnTimer
    {
        bool Stopped { get; }
        void Tick(float deltaTime);

        bool IsGameEnd();

        void IncreaseDifficulty();

        void InvokePause(params Action[] onPauseEndActions);

        bool IsPause();

        void InvokeLongPause(params Action[] onLongPauseEndActions);

        bool IsLongPause();

        bool CanIncreaseDifficulty(int spawnCount);

        void OnGameEnd();
    }
}