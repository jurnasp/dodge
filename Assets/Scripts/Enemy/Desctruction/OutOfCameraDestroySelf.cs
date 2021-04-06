using UnityEngine;

namespace Dodge.Enemy.Desctruction
{
    public class OutOfCameraDestroySelf : MonoBehaviour
    {
        public void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}
