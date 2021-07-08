namespace Library.Core
{
    public class CancelableTimer : Timer
    {
        public CancelableTimer(float timeRemaining) : base(timeRemaining)
        {
            TimeRemaining = timeRemaining;
        }

        public void Cancel()
        {
            TimeRemaining = 0f;
        }
    }
}