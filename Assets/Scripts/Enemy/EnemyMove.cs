using UnityEngine;

namespace Enemy
{
    public class EnemyMove : MonoBehaviour
    {
        public float speed = 15f;

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, Vector3.down * 2000, Time.deltaTime * speed);
        }
    }
}