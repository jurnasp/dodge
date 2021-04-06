using System;
using System.Collections.Generic;
using Dodge.Core;
using UnityEngine;
using Random = System.Random;

namespace Dodge.Enemy.Spawner
{
    [Serializable]
    public class RandomEnemyCreator : MonoBehaviour, IEnemyCreator
    {
        public List<GameObject> enemyPrefabs;
    
        public float enemySpeed = 15f;
        private const float EnemySpeedAdd = 5f;


        private Random _random;
        public void Start()
        {
            _random = new Random();
        }

        public void Create()
        {
            var enemy = Instantiate(GetRandomEnemyPrefab());
            
            enemy.transform.position += transform.position;
            enemy.GetComponent<EnemyMove>().speed = enemySpeed;
        }

        private GameObject GetRandomEnemyPrefab()
        {
            var index = _random.Next(enemyPrefabs.Count);
            var enemy = enemyPrefabs[index];
            return enemy;
        }

        public void IncreaseDifficulty()
        {
            enemySpeed += EnemySpeedAdd;
        }
    }
}
