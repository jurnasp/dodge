using System;
using Library.Game;
using NUnit.Framework;

namespace Tests.EditMode
{
    public class LimitedQueueTests
    {
        [Test]
        public void Test_InitializedWithSizeTwo_CountReturnsZero()
        {
            var limitedStack = new LimitedQueue<int>(2);

            Assert.AreEqual(0, limitedStack.Count);
        }

        [Test]
        public void Test_WithNegativeSize_ThrowsArgumentOutOfRangeException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(
                delegate { new LimitedQueue<int>(-1); }
            );
            Assert.That(ex.Message, Does.Contain("Non-negative number required."));
        }

        [Test]
        public void Test_WithSizeTwo_WhenPushThreeItems_CountReturnsTwo()
        {
            var limitedStack = new LimitedQueue<int>(2);

            for (var i = 0; i < 3; i++) limitedStack.Push(i);

            Assert.AreEqual(2, limitedStack.Count);
        }

        [Test]
        public void Test_AddOne_ContainsOneReturnsTrue()
        {
            var limitedStack = new LimitedQueue<int>(5);

            limitedStack.Push(1);

            Assert.IsTrue(limitedStack.Contains(1));
        }

        [Test]
        public void Test_InitializeWithSizeTwo_PushTwo_ContainsBothPushed()
        {
            var limitedStack = new LimitedQueue<int>(2);

            limitedStack.Push(1);
            limitedStack.Push(2);

            Assert.IsTrue(limitedStack.Contains(1));
            Assert.IsTrue(limitedStack.Contains(2));
        }

        [Test]
        public void Test_InitializeWithSizeTwo_PushThree_DoesNotContainFirstPushed()
        {
            var limitedStack = new LimitedQueue<int>(2);

            limitedStack.Push(1);
            limitedStack.Push(2);
            limitedStack.Push(3);

            Assert.IsFalse(limitedStack.Contains(1));
        }
    }
}