using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Core
{
    public class MonoBehaviourParentMessenger : MonoBehaviour
    {
        public List<MonoBehaviour> parentMonoBehaviours;
        
        protected void NotifyParentsOfEvent(string eventName) {
            foreach (var parentMonoBehaviour in parentMonoBehaviours)
            {
                parentMonoBehaviour.SendMessage(eventName);
            }
        }
    }
}