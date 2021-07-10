using Library.Core;
using NUnit.Framework;

namespace Tests.EditMode
{
    public class CancelableTimerTests
    {
        [Test]
        public void Test_InitializedWithTimeOneSecond_CallCancel_TickOneSecond_WillNotNotifyObserver()
        {
            var notified = false;
            var timer = new CancelableTimer(1f);
            
            timer.OnTimerEnd += delegate { notified = true; };
            timer.Cancel();
            timer.Tick(1f);
            
            Assert.AreEqual(false, notified);
        }
    }
}
