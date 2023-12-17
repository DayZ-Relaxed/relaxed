using Microsoft.Extensions.Configuration;

namespace Relaxed.LogParser.Settings
{
    public class AppSettings
    {

        public AppSettings(IConfiguration configuration)
        {
            _configuration = configuration;
            
            ConnectionStrings = new ConnectionStrings();
            ConnectionStrings.DayZRelaxed = _configuration.GetValue<string>("ConnectionStrings:DayZRelaxed");

            DayZLogs = new DayZLogs();
            DayZLogs.LogFilesPath = _configuration.GetValue<string>("DayZLogs:LogFilesPath");
            DayZLogs.LogFilesPathActive = _configuration.GetValue<string>("DayZLogs:LogFilesPathActive");
            DayZLogs.LogFilesPathCarCover = _configuration.GetValue<string>("DayZLogs:LogFilesPathCarCover");
            DayZLogs.LogFilesPathKillNotifications = _configuration.GetValue<string>("DayZLogs:LogFilesPathKillNotifications");
            DayZLogs.LogFilesPathKillNotificationsActive = _configuration.GetValue<string>("DayZLogs:LogFilesPathKillNotificationsActive");
            DayZLogs.LogFilesPathMoney = _configuration.GetValue<string>("DayZLogs:LogFilesPathMoney");
            
            DayZLogs.LogFileName = _configuration.GetValue<string>("DayZLogs:LogFileName");
            DayZLogs.LogFileNameCarCover = _configuration.GetValue<string>("DayZLogs:LogFileNameCarCover");
            DayZLogs.LogFileNameKillNotifications = _configuration.GetValue<string>("DayZLogs:LogFileNameKillNotifications");
        }

        private IConfiguration _configuration;

        public ConnectionStrings ConnectionStrings { get; set; }
        public DayZLogs DayZLogs { get; set; }

    }
}
