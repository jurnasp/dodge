using Dodge.Core;
using UnityEngine;

namespace Dodge.Enemy.Spawner.Tutorial
{
    public class TutorialSpawnTimer : MonoBehaviour, IEnemySpawnTimer
    {
        public InputManager inputManager;

        public float pauseBetweenEnemySpawns = 5f;
        private float _enemySpawnTimeoutEnd;

        private int _index;

        private float? _keyHeldTime;
        private int _spawnCount;

        public bool CanSpawn()
        {
            if (IsEnemySpawnTimeout()) return false;

            return _index switch
            {
                0 => InputHeld(false, true),
                1 => InputHeld(true, false),
                2 => InputHeld(true, true),
                _ => false
            };
        }

        public void IncreaseDifficulty()
        {
            _index++;
        }

        public void InvokeLongPause()
        {
        }

        public void InvokePause()
        {
            _enemySpawnTimeoutEnd = Time.time + pauseBetweenEnemySpawns;
        }

        public void IncrementSpawnCount()
        {
            _spawnCount++;
        }

        public bool HasSpawnedEnoughEnemiesForLongPause()
        {
            // @Todo dependant on if lost or not
            return true;
        }

        private bool InputHeld(bool left, bool right)
        {
            if (inputManager.LeftPressed == left && inputManager.RightPressed == right)
            {
                if (_keyHeldTime == null)
                    _keyHeldTime = Time.time + 3f;
                else if (_keyHeldTime < Time.time) return true;
            }
            else
            {
                _keyHeldTime = null;
            }

            return false;
        }

        private bool IsEnemySpawnTimeout()
        {
            return Time.time < _enemySpawnTimeoutEnd;
        }
    }
}