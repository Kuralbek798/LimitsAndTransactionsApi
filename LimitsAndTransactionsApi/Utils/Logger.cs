using Serilog;

namespace LimitsAndTransactionsApi.Utils
{
    public static class Logger
    {
       static string logPath = "D:\\logs/myapp.txt";
        public static void ConfigureLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(logPath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public static void Info(string message)
        {
            Log.Information(message);
        }

        public static void Error(Exception exception, string message)
        {
            Log.Error(exception, message);
        }

        public static void Warn(string message)
        {           
            Log.Warning(message);
        }

      
    }
}
