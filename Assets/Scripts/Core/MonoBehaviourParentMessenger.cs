using System.Collections.Generic;
using UnityEngine;

namespace Dodge.Core
{
    public class MonoBehaviourParentMessenger : MonoBehaviour
    {
        public List<MonoBehaviour> parentMonoBehaviours;
        
        protected void NotifyParentsOfEvent(string eventName) {
            foreach (var parentMonoBehaviour in parentMonoBehaviours)
            {
                parentMonoBehaviour.SendMessage(eventName, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}