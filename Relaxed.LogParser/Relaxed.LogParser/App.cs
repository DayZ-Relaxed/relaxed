
using Relaxed.LogParser.Model;
using Relaxed.LogParser.Settings;

public class App (DayzRelaxedContext context, AppSettings appSettings)
{
    private readonly DayzRelaxedContext _context = context;
    private AppSettings _appSettings = appSettings;

    public void Run(string[] args)
    {
        Console.WriteLine($"{_context.Players.ToList().Count}");
    }
}