namespace BerlinClock
{
    public struct Time
    {
        public int Hours { get; }

        public int Minutes { get; }

        public int Seconds { get; }

        public Time(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }
    }
}