namespace OBSCountdown
{
    internal class CountdownDuration
    {
        public int Hours { get; private set; }
        public int Minutes { get; private set; }
        public int Seconds { get; private set; }

        public bool Tick()
        {
            if (Seconds == 0 && Minutes == 0 && Hours == 0)
            {
                return false;
            }
            else if (Minutes == 0 && Seconds == 0)
            {
                Hours--;
                Minutes = 59;
                Seconds = 60;
            }
            else if (Seconds == 0)
            {
                Minutes--;
                Seconds = 60;
            }
            Seconds--;

            return true;
        }

        public string GetOutput()
        {
            return Hours.ToString("00") + ":" + Minutes.ToString("00") + ":" + Seconds.ToString("00");
        }

        internal static CountdownDuration Parse(int secondsToGo)
        {
            int hours = secondsToGo / 3600;
            int minutes = (secondsToGo - hours * 3600) / 60;
            int seconds = secondsToGo - (minutes * 60) - (hours * 3600);

            return new CountdownDuration
            {
                Hours = hours,
                Minutes = minutes,
                Seconds = seconds,
            };            
        }
    }
}
