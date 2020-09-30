using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 15f;
    public int toY = -5;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Vector3.up * -2000, Time.deltaTime * speed);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}