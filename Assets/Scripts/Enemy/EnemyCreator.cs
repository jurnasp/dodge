using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Enemy
{
    public class EnemyCreator : MonoBehaviour
    {
        public List<GameObject> enemyPrefabs;
    
        public float enemySpeed = 15f;
        private float _enemySpeedAdd = 5f;
        
        
        private Random _random;
        public void Start()
        {
            _random = new Random();
        }

        public void SpawnRandomEnemy()
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

        public void IncreaseSpeed()
        {
            enemySpeed += _enemySpeedAdd;
        }
    }
}
