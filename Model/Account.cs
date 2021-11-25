namespace CoreRankingAPI.Model;

public record Account
{
    [Key]
    public int Id { get; private init; }

    public string Login { get; private init; }

    public string Ip { get; private init; }
}