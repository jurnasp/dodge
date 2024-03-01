using System;
using System.Collections.Generic;
using Library.Enemy.Spawner;
using UnityEngine;
using Random = System.Random;

namespace Enemy.Spawner
{
    [Serializable]
    public class RandomEnemyCreator : MonoBehaviour, IEnemyCreator
    {
        [SerializeField] private float increaseDifficultyIncrement = 5f;
        [SerializeField] private float increaseDifficultyMultiplier = 5f;
        public List<GameObject> enemyPrefabs;

        public float enemySpeed = 15f;

        private bool _gameEnd;

        private Random _random;
        private int _spawnCount;

        private void Start()
        {
            _random = new Random();
        }

        public void Create()
        {
            if (_gameEnd) return;

            var enemy = Instantiate(GetRandomEnemyPrefab());

            enemy.transform.position += transform.position;
            enemy.GetComponent<EnemyMove>().speed = enemySpeed;

            _spawnCount++;
        }

        public void IncreaseDifficulty()
        {
            if (_gameEnd) return;

            enemySpeed += increaseDifficultyIncrement;
            enemySpeed *= increaseDifficultyMultiplier;
        }

        public void OnGameEnd()
        {
            _gameEnd = true;
        }

        public int GetSpawnCount()
        {
            return _spawnCount;
        }

        private GameObject GetRandomEnemyPrefab()
        {
            var index = _random.Next(enemyPrefabs.Count);
            var enemy = enemyPrefabs[index];
            return enemy;
        }
    }
}