using UnityEngine;

namespace Dodge.Enemy
{
    public class OutOfCameraDestroySelf : MonoBehaviour
    {
        public void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}
