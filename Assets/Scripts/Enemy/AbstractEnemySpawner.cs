using Dodge.Core;
using UnityEngine;

namespace Dodge.Enemy
{
    public abstract class AbstractEnemySpawner : MonoBehaviour
    {
        protected IEnemyCreator enemyCreator;
        protected IEnemySpawnTimer spawnTimer;
        
        public void Start()
        {
            enemyCreator = gameObject.GetComponent<IEnemyCreator>();
            spawnTimer = gameObject.GetComponent<IEnemySpawnTimer>();
        }

        protected void IncreaseDifficulty()
        {
            spawnTimer.IncreaseDifficulty();
            enemyCreator.IncreaseDifficulty();
        }
    }
}