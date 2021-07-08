using System;

namespace Library.Core
{
    public class Timer
    {
        public Timer(float timeRemaining)
        {
            TimeRemaining = timeRemaining;
        }

        public float TimeRemaining { get; protected set; }

        public event Action OnTimerEnd;

        public void Tick(float deltaTime)
        {
            if (TimeRemaining == 0f) return;
            TimeRemaining -= deltaTime;

            CheckTimerEnd();
        }

        private void CheckTimerEnd()
        {
            if (TimeRemaining > 0f) return;

            TimeRemaining = 0f;

            OnTimerEnd?.Invoke();
        }

        public bool HasEnded()
        {
            return TimeRemaining == 0f;
        }
    }
}