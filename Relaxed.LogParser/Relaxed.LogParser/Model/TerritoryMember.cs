namespace Relaxed.LogParser.Model;

public partial class TerritoryMember
{
    public int TerritoryMemberId { get; set; }

    public int TerritoryId { get; set; }

    public int? MemberPlayerId { get; set; }

    public string MemberDayzId { get; set; } = null!;

    public DateTime LastFound { get; set; }
}
