using System.IO;
using System.Threading;

namespace OBSCountdown
{
    class Program
    {
        static void Main(string[] args)
        {
            int secondsToGo = GetSecondsFromArgs(args);
            var duration = CountdownDuration.Parse(secondsToGo);

            do
            {
                Thread.Sleep(990);
                WriteFile(duration.GetOutput());
            } while (duration.Tick());
        }

        private static int GetSecondsFromArgs(string[] args)
        {
            return int.Parse(args[args.Length - 1]);
        }

        private static void WriteFile(string input)
        {
            File.WriteAllText("countdown.txt", input);
        }
    }
}
