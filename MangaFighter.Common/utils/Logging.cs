namespace MangaFighter.Common.Utils
{
    class Log
    {
        private static Stopwatch stopwatch = new Stopwatch();
        private static DateTime StartTime = DateTime.Now;
        public static void Init()
        {
            // Console.Title = $"MangaFighter {Settings.Get()[0].Prefix} Server v{Settings.Get()[0].version} - 0 users online - 0day(s) 0 hour(s) uptime";
            Log.Info("Initializing the log module..");

            Timer aTimer = new System.Timers.Timer(30000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += UpdateTitle;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;

            stopwatch.Start();

        }

        #region console log - colors
        public static void Command(string input)
        {
            Console.WriteLine($"|{DateTime.Now}| \u001b[32m{input}\u001b[0m \r\n", Color.Green);
        }

        public static void Info(string input)
        {
            Console.WriteLine($"|{DateTime.Now}| \u001b[36m{input}\u001b[0m \r\n", Color.Aqua);
        }

        public static void Error(string input)
        {
            Console.WriteLine($"|{DateTime.Now}| \u001b[31m{input}\u001b[0m \r\n", Color.DarkRed);
        }

        public static void Warning(string input)
        {
            Console.WriteLine($"|{DateTime.Now}| \u001b[33m{input}\u001b[0m \r\n", Color.Yellow);
        }
        #endregion

        #region console title
        private static void UpdateTitle(Object source, ElapsedEventArgs e)
        {
            DateTime now = StartTime.Add(stopwatch.Elapsed);
            TimeSpan uptime = now.Subtract(StartTime);
            // Console.Title = $"MangaFighter {Settings.Get()[0].Prefix} Server v{Settings.Get()[0].version} - 0 users online - {uptime.Days} day(s) {uptime.Hours} hour(s) {uptime.Minutes} minute(s) uptime";
        }
        #endregion
    }
}