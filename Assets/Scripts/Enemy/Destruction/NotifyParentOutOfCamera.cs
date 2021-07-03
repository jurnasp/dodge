using Dodge.Core;

namespace Dodge.Enemy.Destruction
{
    public class NotifyParentOutOfCamera : MonoBehaviourParentMessenger
    {
        private void OnBecameInvisible()
        {
            NotifyParentsOfEvent("OnBecameInvisible");
        }
    }
}