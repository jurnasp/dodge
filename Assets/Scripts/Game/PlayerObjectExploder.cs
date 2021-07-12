using UnityEngine;

namespace Game
{
    public class PlayerObjectExploder : MonoBehaviour
    {
        public GameObject fragmentedPrefab;

        public void GameEnd()
        {
            var transf = transform;
            Instantiate(fragmentedPrefab, transf.position, transf.rotation);
            Destroy(gameObject);
        }
    }
}