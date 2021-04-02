using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
