using System;

namespace BallGame
{
    internal static class TimeInterpreterExtension
    {
        public static string SecondsToTimeString(this float seconds) => TimeSpan.FromSeconds(seconds).ToString(@"hh\:mm\:ss\.fff");
    }
}
