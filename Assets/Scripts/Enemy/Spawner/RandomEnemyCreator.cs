using System;
using System.Collections.Generic;
using Dodge.Library.Enemy.Spawner;
using UnityEngine;
using Random = System.Random;

namespace Dodge.Enemy.Spawner
{
    [Serializable]
    public class RandomEnemyCreator : MonoBehaviour, IEnemyCreator
    {
        private const float EnemySpeedAdd = 5f;
        public List<GameObject> enemyPrefabs;

        public float enemySpeed = 15f;

        private Random _random;

        private bool _gameEnd;

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
        }

        public void IncreaseDifficulty()
        {
            if (_gameEnd) return;
            
            enemySpeed += EnemySpeedAdd;
        }

        public void OnGameEnd()
        {
            _gameEnd = true;
        }

        private GameObject GetRandomEnemyPrefab()
        {
            var index = _random.Next(enemyPrefabs.Count);
            var enemy = enemyPrefabs[index];
            return enemy;
        }
    }
}