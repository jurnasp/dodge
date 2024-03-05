﻿using System;
using Library.Core;
using Library.Enemy.Spawner;
using UnityEngine;

namespace Enemy.Spawner
{
    public class TenCycleSpawnTimer : MonoBehaviour, IEnemySpawnTimer
    {
        [SerializeField] private float increaseDifficultyIncrement = 0.25f;
        [SerializeField] private float increaseDifficultyMultiplier = 1f;
        private const int SpawnCycleSize = 10;

        private const float PauseBetweenEnemySpawnsMin = 0.5f;
        [SerializeField] private float pauseBetweenEnemySpawns = 2.5f;

        [SerializeField] private float pauseBetweenSpawnCycles = 5f;
        private Timer _enemySpawnTimeoutTimer;

        private bool _gameEnd;
        private Timer _spawnCyclePauseTimer;

        public bool Stopped => false;

        public void Tick(float deltaTime)
        {
            _enemySpawnTimeoutTimer?.Tick(deltaTime);
            _spawnCyclePauseTimer?.Tick(deltaTime);
        }

        public bool IsGameEnd()
        {
            return _gameEnd;
        }

        public void InvokePause(params Action[] onPauseEndActions)
        {
            _enemySpawnTimeoutTimer = new Timer(pauseBetweenEnemySpawns);
            foreach (var action in onPauseEndActions)
                _enemySpawnTimeoutTimer.OnTimerEnd += action;
        }

        public void InvokeLongPause(params Action[] onLongPauseEndActions)
        {
            _spawnCyclePauseTimer = new Timer(pauseBetweenSpawnCycles);
            foreach (var action in onLongPauseEndActions)
                _spawnCyclePauseTimer.OnTimerEnd += action;
        }

        public bool CanIncreaseDifficulty(int spawnCount)
        {
            return spawnCount != 0 && spawnCount % SpawnCycleSize == 0;
        }

        public void OnGameEnd()
        {
            _gameEnd = true;
        }

        public bool IsPause()
        {
            return !_enemySpawnTimeoutTimer?.HasEnded() ?? false;
        }

        public bool IsLongPause()
        {
            return !_spawnCyclePauseTimer?.HasEnded() ?? false;
        }

        public void IncreaseDifficulty()
        {
            DecreaseTimeBetweenSpawns();
        }

        private void DecreaseTimeBetweenSpawns()
        {
            if (Math.Abs(pauseBetweenEnemySpawns - PauseBetweenEnemySpawnsMin) < 0.1f) return;

            pauseBetweenEnemySpawns -= increaseDifficultyIncrement;
            pauseBetweenEnemySpawns *= increaseDifficultyMultiplier;

            pauseBetweenEnemySpawns = Math.Max(pauseBetweenEnemySpawns, PauseBetweenEnemySpawnsMin);
        }
    }
}