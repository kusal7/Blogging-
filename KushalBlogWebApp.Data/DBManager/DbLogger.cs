namespace DBManager
{
    public class DefaultDbLoggerSetting
    {
        public bool AllowLogging { get; set; }
    }

    public class DbLogger
    {

        private static object _ratesFileLock = new object();
        private string Basedir { get; set; }
        private string _todaysDate { get; set; }

        public DbLogger(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            ;
            Basedir = hostingEnvironment.ContentRootPath + "\\DbLogs\\";
            _todaysDate = DateTime.Now.ToString("yyyy_MM_dd");

            if (!Directory.Exists(Basedir))
            {
                Directory.CreateDirectory(Basedir);
            }
            LogFilePath = Basedir + CustomFileName + _todaysDate + ".log";

            _init();
        }

        public bool CreateFile<T>()
        {
            var type = typeof(T);
            CustomFileName = type.FullName;
            LogFilePath = Basedir + CustomFileName + _todaysDate + ".log";
            return true;
        }

        private string CustomFileName { get; set; } = "";

        public bool CreateFile(string name)
        {
            CustomFileName = name;
            LogFilePath = Basedir + CustomFileName + _todaysDate + ".log";
            return true;
        }

        private string LogFilePath { get; set; }
        //private List<Log.Log> Logs { get; set; }

        private void _init()
        {
            _todaysDate = DateTime.Now.ToString("yyyy_MM_dd");

            if (!File.Exists(LogFilePath))
            {
                File.Create(LogFilePath, 1024, FileOptions.None);
            }
            else
            {
                long b = new FileInfo(LogFilePath).Length;
                long kb = b / 1024;
                long mb = kb / 1024;
                // long gb = mb / 1024;
                if (mb >= 5)
                {
                    LogFilePath = Basedir + CustomFileName + _todaysDate + "-" + DateTime.Now.ToString("h.mm") + ".log";
                    File.Create(LogFilePath, 1024, FileOptions.None);
                }
            }
        }



        public void AddLog(string log)
        {
            Attempt(TryToUpdateRates, log, maximumNumberOfAttempts: 50, timeToWaitBetweenRetriesInMs: 100);
        }

        private void TryToUpdateRates(string log)
        {
            lock (_ratesFileLock)
            {
                using (var stream = GetRatesFileStream())
                {
                    WriteLog(log, stream);
                }
            }
        }

        private Stream GetRatesFileStream()
        {
            return File.Open(LogFilePath, FileMode.Append, FileAccess.Write);
        }

        private void WriteLog(string log, Stream stream)
        {
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.WriteLine(log);
            }
        }

        private static void Attempt(Action<string> work, string log, int maximumNumberOfAttempts, int timeToWaitBetweenRetriesInMs)
        {
            var numberOfFailedAttempts = 0;
            while (true)
            {
                try
                {
                    work(log);
                    return;
                }
                catch
                {
                    numberOfFailedAttempts++;
                    if (numberOfFailedAttempts >= maximumNumberOfAttempts)
                        throw;
                    Thread.Sleep(timeToWaitBetweenRetriesInMs);
                }
            }
        }
    }
}