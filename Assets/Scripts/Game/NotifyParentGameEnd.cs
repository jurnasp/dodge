using Dodge.Core;
using UnityEngine;

namespace Dodge.Game
{
    public class NotifyParentGameEnd : MonoBehaviourParentMessenger
    {
        private const string EnemyTag = "Enemy";
        
        private void OnTriggerEnter(Collider other)
        {
            if (!IsEnemy(other)) return;
            
            GameEnd();
        }
        
        private static bool IsEnemy(Collider other)
        {
            return other.CompareTag(EnemyTag);
        }
        
        private void GameEnd()
        {
            NotifyParentsOfEvent("GameEnd");
        }
    }
}