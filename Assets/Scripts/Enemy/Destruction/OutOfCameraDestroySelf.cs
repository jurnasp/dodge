using UnityEngine;

namespace Dodge.Enemy.Destruction
{
    public class OutOfCameraDestroySelf : MonoBehaviour
    {
        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}