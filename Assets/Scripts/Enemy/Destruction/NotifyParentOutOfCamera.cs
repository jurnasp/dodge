using Dodge.Core;

namespace Dodge.Enemy.Destruction
{
    public class NotifyParentOutOfCamera : MonoBehaviourParentMessenger
    {
        public void OnBecameInvisible()
        {
            NotifyParentsOfEvent("OnBecameInvisible");
        }
    }
}