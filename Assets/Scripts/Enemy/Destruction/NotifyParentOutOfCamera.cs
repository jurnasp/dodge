using Core;

namespace Enemy.Destruction
{
    public class NotifyParentOutOfCamera : MonoBehaviourParentMessenger
    {
        private void OnBecameInvisible()
        {
            NotifyParentsOfEvent("OnBecameInvisible");
        }
    }
}