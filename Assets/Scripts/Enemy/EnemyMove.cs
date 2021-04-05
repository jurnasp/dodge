using UnityEngine;

namespace Enemy
{
    public class EnemyMove : MonoBehaviour
    {
        public float speed = 15f;

        public void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, Vector3.down * 2000, Time.deltaTime * speed);
        }

        public void AddSpeed(float add)
        {
            speed += add;
        }
    }
}