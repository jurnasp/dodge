using Core;

namespace Enemy
{
    public class NotifyParentOutOfCamera : MonoBehaviourParentMessenger
    {
        public void OnBecameInvisible()
        {
            NotifyParentsOfEvent("OnBecameInvisible");
        }
    }
}
