namespace Relaxed.LogParser.Model;

public partial class Territory
{
    public int TerritoryId { get; set; }

    public int? OwnerPlayerId { get; set; }

    public string OwnerDayzId { get; set; } = null!;

    public int PosX { get; set; }

    public int PosY { get; set; }

    public string PosZ { get; set; } = null!;

    public DateTime LastFound { get; set; }
}
