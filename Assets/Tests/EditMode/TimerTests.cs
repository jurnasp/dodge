using Library.Core;
using NUnit.Framework;

namespace Tests.EditMode
{
    public class TimerTests
    {
        [Test]
        public void Test_InitializedWithTimeZeroSecond_WillNotNotifyObserverAfterTick()
        {
            var notified = false;
            var timer = new Timer(0f);

            timer.OnTimerEnd += delegate { notified = true; };
            timer.Tick(0.1f);
            
            Assert.AreEqual(false, notified);
        }
        
        [Test]
        public void Test_InitializedWithTimeOneSecond_WillNotifyObserverAfterTickedOneSecond()
        {
            var notified = false;
            var timer = new Timer(1f);

            timer.OnTimerEnd += delegate { notified = true; };
            timer.Tick(1f);
            
            Assert.AreEqual(true, notified);
        }
        
        [Test]
        public void Test_InitializedWithTimeOneSecond_WillNotifyObserverOnlyAfterOneSecondPasses()
        {
            var notified = false;
            var timer = new Timer(1f);

            timer.OnTimerEnd += delegate { notified = true; };
            
            timer.Tick(0.5f);
            Assert.AreEqual(false, notified);
            
            timer.Tick(0.4f);
            Assert.AreEqual(false, notified);
            
            timer.Tick(0.2f);
            Assert.AreEqual(true, notified);
        }
        
        [Test]
        public void Test_InitializedWithTimeZeroSecond_CallHasEnded_WillReturnTrueWithoutTick()
        {
            var timer = new Timer(0f);
            
            Assert.AreEqual(true, timer.HasEnded());
        }
        
        [Test]
        public void Test_InitializedWithTimeOneSecond_CallHasEnded_WillReturnTrueOnlyAfterOneSecondPasses()
        {
            var timer = new Timer(1f);
            
            timer.Tick(0.5f);
            Assert.AreEqual(false, timer.HasEnded());
            
            timer.Tick(0.4f);
            Assert.AreEqual(false, timer.HasEnded());
            
            timer.Tick(0.2f);
            Assert.AreEqual(true, timer.HasEnded());
        }
        
        [Test]
        public void Test_InitializedWithTimeOneSecond_TickOneSecond_GetTimeRemaining_WillReturnZeroSecond()
        {
            var timer = new Timer(1f);
            
            timer.Tick(1f);
            
            Assert.AreEqual(0f, timer.TimeRemaining);
        }
        
        [Test]
        public void Test_InitializedWithTimeOneSecond_TickHalfSecond_GetTimeRemaining_WillReturnHalfSecond()
        {
            var timer = new Timer(1f);
            
            timer.Tick(0.5f);
            
            Assert.AreEqual(0.5f, timer.TimeRemaining);
        }
        
        [Test]
        public void Test_InitializedWithTimeOneSecond_TickTwoSecond_GetTimeRemaining_WillReturnZeroSecond()
        {
            var timer = new Timer(1f);
            
            timer.Tick(2f);
            
            Assert.AreEqual(0f, timer.TimeRemaining);
        }
    }
}