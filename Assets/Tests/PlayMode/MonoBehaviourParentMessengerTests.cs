using System.Collections;
using System.Collections.Generic;
using Core;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.PlayMode
{
    public class MonoBehaviourParentMessengerTests
    {
        private class ParentMessengerDummy : MonoBehaviourParentMessenger
        {
            public void NotifyParents()
            {
                NotifyParentsOfEvent("ParentEvent");
            }
        }

        private class ParentMessageReceiverDummy : MonoBehaviour
        {
            public bool Notified { get; private set; }
            public void ParentEvent()
            {
                Notified = true;
            }
        }
        
        [UnityTest]
        public IEnumerator AParent_WhenSubjectCallsNotify_ParentIsNotified()
        {
            var subject = new GameObject();
            var subjectMessenger = subject.AddComponent<ParentMessengerDummy>();
            
            var parent = new GameObject();
            var parentMessageReceiver = parent.AddComponent<ParentMessageReceiverDummy>();
            subjectMessenger.parentMonoBehaviours.Add(parentMessageReceiver);
            
            subjectMessenger.NotifyParents();
            
            yield return null;
            
            Assert.AreEqual(true, parentMessageReceiver.Notified);
        }
        
        [UnityTest]
        public IEnumerator ThreeParents_WhenSubjectCallsNotify_ParentsAreNotified()
        {
            var subject = new GameObject();
            var subjectMessenger = subject.AddComponent<ParentMessengerDummy>();
            var parentMessageReceivers = new List<ParentMessageReceiverDummy>();

            for (int i = 0; i < 3; i++)
            {
                var parent = new GameObject();
                var parentMessageReceiver = parent.AddComponent<ParentMessageReceiverDummy>();
                parentMessageReceivers.Add(parentMessageReceiver);
                
                subjectMessenger.parentMonoBehaviours.Add(parentMessageReceiver);
            }

            subjectMessenger.NotifyParents();
            
            yield return null;

            foreach (var parentMessageReceiver in parentMessageReceivers)
            {
                Assert.AreEqual(true, parentMessageReceiver.Notified);
            }
        }
    }
}
