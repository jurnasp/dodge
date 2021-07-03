using System;
using System.Collections.Generic;
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

        private void Start()
        {
            _random = new Random();
        }

        public void Create()
        {
            var enemy = Instantiate(GetRandomEnemyPrefab());

            enemy.transform.position += transform.position;
            enemy.GetComponent<EnemyMove>().speed = enemySpeed;
        }

        public void IncreaseDifficulty()
        {
            enemySpeed += EnemySpeedAdd;
        }

        private GameObject GetRandomEnemyPrefab()
        {
            var index = _random.Next(enemyPrefabs.Count);
            var enemy = enemyPrefabs[index];
            return enemy;
        }
    }
}