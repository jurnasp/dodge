using UnityEngine;

namespace UI
{
    public class SpawnCountAdd : MonoBehaviour
    {
        public int spawnCount;
        private void OnTriggerEnter(Collider other)
        {
            spawnCount += 1;
        }
    }
}
