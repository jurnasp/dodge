using Dodge.Core;
using UnityEngine;

namespace Dodge.Enemy
{
    public abstract class AbstractEnemySpawner : MonoBehaviour
    {
        private IEnemyCreator _enemyCreator;
        private IEnemySpawnTimer _enemySpawnTimer;
        
        public void Start()
        {
            _enemyCreator = gameObject.GetComponent<IEnemyCreator>();
            _enemySpawnTimer = gameObject.GetComponent<IEnemySpawnTimer>();
        }
    }
}