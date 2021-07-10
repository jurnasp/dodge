using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class MonoBehaviourParentMessenger : MonoBehaviour
    {
        public List<MonoBehaviour> parentMonoBehaviours = new List<MonoBehaviour>();

        protected void NotifyParentsOfEvent(string eventName)
        {
            foreach (var parentMonoBehaviour in parentMonoBehaviours)
                parentMonoBehaviour.SendMessage(eventName, SendMessageOptions.DontRequireReceiver);
        }
    }
}