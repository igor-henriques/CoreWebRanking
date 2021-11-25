namespace CoreRankingAPI.Model;

public record Role
{
    [Required]
    [ForeignKey("Account")]
    public int AccountId { get; private init; }

    public Account Account { get; private init; }

    [Key]
    public int RoleId { get; private init; }

    public string CharacterName { get; private init; }

    public string CharacterClass { get; private init; }

    public string CharacterGender { get; private init; }

    public int Kill { get; private init; }

    public int Death { get; private init; }

    public string Elo { get; private init; }

    public int Level { get; private init; }

    public DateTime LevelDate { get; private init; }

    public int Points { get; private init; }

    public int Doublekill { get; private init; }

    public int Triplekill { get; private init; }

    public int Quadrakill { get; private init; }

    public int Pentakill { get; private init; }

    public double CollectPoint { get; private init; }

    public IEnumerable<Battle> Battles { get; private init; }
}