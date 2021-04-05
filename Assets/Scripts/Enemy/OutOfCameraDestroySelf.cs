using UnityEngine;

namespace Enemy
{
    public class OutOfCameraDestroySelf : MonoBehaviour
    {
        public void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}
