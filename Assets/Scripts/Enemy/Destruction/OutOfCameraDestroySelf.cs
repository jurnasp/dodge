using UnityEngine;

namespace Dodge.Enemy.Destruction
{
    public class OutOfCameraDestroySelf : MonoBehaviour
    {
        public void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}