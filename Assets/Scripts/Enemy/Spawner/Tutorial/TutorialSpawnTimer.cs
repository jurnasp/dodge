using System;
using Dodge.Core;
using Dodge.Game;
using Library.Core;
using Library.Enemy.Spawner;
using UnityEngine;
using UnityEngine.Serialization;

namespace Dodge.Enemy.Spawner.Tutorial
{
    public class TutorialSpawnTimer : MonoBehaviour, IEnemySpawnTimer
    {
        public InputManager inputManager;
        public CountScore scoreCounter;

        public float pauseBetweenEnemySpawns = 6.5f;
        public float pauseBetweenSpawnCycles = 1f;

        [FormerlySerializedAs("keyHeldTime")] [SerializeField]
        private float timeToHoldKeyDown = 1.5f;

        private CancelableTimer _enemySpawnTimeoutTimer;

        private bool _gameEnd;

        private int _index;

        private float? _keyHeldTime;

        private Timer _spawnCyclePauseTimer;


        public void Tick(float deltaTime)
        {
            _enemySpawnTimeoutTimer?.Tick(deltaTime);
            _spawnCyclePauseTimer?.Tick(deltaTime);
        }

        public bool IsGameEnd()
        {
            return _gameEnd;
        }

        public void IncreaseDifficulty()
        {
            print("IncreaseDifficulty");
            _index++;
        }

        public void InvokePause(params Action[] onPauseEndActions)
        {
            print("InvokePause");
            _enemySpawnTimeoutTimer = new CancelableTimer(pauseBetweenEnemySpawns);
            foreach (var action in onPauseEndActions)
                _enemySpawnTimeoutTimer.OnTimerEnd += action;
        }

        public void InvokeLongPause(params Action[] onLongPauseEndActions)
        {
            _spawnCyclePauseTimer = new Timer(pauseBetweenSpawnCycles);

            _spawnCyclePauseTimer.OnTimerEnd += onLongPauseEndActions[0];
            _enemySpawnTimeoutTimer.Cancel();
        }

        public bool CanIncreaseDifficulty(int spawnCount)
        {
            return HasPassedCurrentEnemy() && !IsGameEnd();
        }

        public void OnGameEnd()
        {
            _gameEnd = true;
        }

        public bool IsPause()
        {
            return HasEnded(_enemySpawnTimeoutTimer) || !IsTutorialKeyHeldLongEnough();
        }

        public bool IsLongPause()
        {
            return HasEnded(_spawnCyclePauseTimer);
        }

        private bool HasPassedCurrentEnemy()
        {
            return _index + 1 == scoreCounter.Score;
        }

        private bool InputHeld(bool left, bool right)
        {
            if (inputManager.IsLeftPressed == left && inputManager.IsRightPressed == right)
            {
                if (_keyHeldTime == null)
                    _keyHeldTime = Time.time + timeToHoldKeyDown;
                else if (_keyHeldTime < Time.time) return true;
            }
            else
            {
                _keyHeldTime = null;
            }

            return false;
        }

        private static bool HasEnded(Timer timer)
        {
            return !timer?.HasEnded() ?? false;
        }

        private bool IsTutorialKeyHeldLongEnough()
        {
            return _index switch
            {
                0 => InputHeld(false, true),
                1 => InputHeld(true, false),
                2 => InputHeld(true, true),
                _ => false
            };
        }
    }
}