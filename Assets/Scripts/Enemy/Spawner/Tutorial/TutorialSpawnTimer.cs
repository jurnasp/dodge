using System;
using Core;
using Library.Enemy.Spawner;
using UnityEngine;

namespace Enemy.Spawner.Tutorial
{
    public class TutorialSpawnTimer : MonoBehaviour, IEnemySpawnTimer
    {
        public InputManager inputManager;

        [SerializeField]
        private float timeToHoldKeyDown = 1.5f;

        private float? _keyHeldTime;

        private bool _gameEnd;

        public bool Stopped { get; private set; }

        public void Tick(float deltaTime) { }

        public bool IsGameEnd()
        {
            return _gameEnd;
        }

        public void IncreaseDifficulty() { }

        public void InvokePause(params Action[] onPauseEndActions) { }

        public void InvokeLongPause(params Action[] onLongPauseEndActions)
        {
            foreach (var action in onLongPauseEndActions)
                action.Invoke();
        }

        public void OnGameEnd()
        {
            _gameEnd = true;
        }

        public bool IsPause()
        {
            return true;
        }

        public bool IsLongPause()
        {
            return false;
        }

        public bool CanIncreaseDifficulty(int spawnCount)
        {
            return !IsGameEnd() && IsTutorialKeyHeldLongEnough(spawnCount);
        }

        private bool IsTutorialKeyHeldLongEnough(int index)
        {
            return index switch
            {
                0 => InputHeld(false, true),
                1 => InputHeld(true, false),
                2 => InputHeld(true, true),
                _ => Stopped = true
            };
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
    }
}