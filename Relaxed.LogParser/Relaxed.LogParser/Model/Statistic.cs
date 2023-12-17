namespace Relaxed.LogParser.Model;

public partial class Statistic
{
    public int StatisticsId { get; set; }

    public int StatisticsType { get; set; }

    public string Description { get; set; } = null!;

    public DateTime DateWritten { get; set; }

    public int Value { get; set; }
}
