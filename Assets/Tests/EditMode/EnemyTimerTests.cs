using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Tests.EditMode
{
    public class EnemyTimerTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void FirstTestSimplePasses()
        {
            Assert.AreEqual(1, 1);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator FirstTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
