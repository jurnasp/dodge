using UnityEngine;

namespace Enemy.Destruction
{
    public class OutOfCameraDestroySelf : MonoBehaviour
    {
        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}