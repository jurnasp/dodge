using Dodge.Core;

namespace Dodge.Enemy.Desctruction
{
    public class NotifyParentOutOfCamera : MonoBehaviourParentMessenger
    {
        public void OnBecameInvisible()
        {
            NotifyParentsOfEvent("OnBecameInvisible");
        }
    }
}