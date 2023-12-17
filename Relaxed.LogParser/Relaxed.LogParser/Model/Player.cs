namespace Relaxed.LogParser.Model;

public partial class Player
{
    public int PlayerId { get; set; }

    public string PlayerName { get; set; } = null!;

    public string? BattleEyeId { get; set; }

    public string? SteamId { get; set; }

    public string? DayzId { get; set; }

    public string? Country { get; set; }

    public DateTime LastLogin { get; set; }
}
