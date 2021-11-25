namespace CoreRankingAPI.Model;

public record Battle
{
    [Key]
    public int Id { get; private init; }

    public DateTime Date { get; private init; }

    [Required]
    [ForeignKey("KillerRole")]
    public int KillerId { get; private init; }

    public Role KillerRole { get; private init; }

    [Required]
    [ForeignKey("KilledRole")]
    public int KilledId { get; private init; }

    public Role KilledRole { get; private init; }
}