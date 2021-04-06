using Dodge.Core;

namespace Dodge.Enemy
{
    public class NotifyParentOutOfCamera : MonoBehaviourParentMessenger
    {
        public void OnBecameInvisible()
        {
            NotifyParentsOfEvent("OnBecameInvisible");
        }
    }
}
