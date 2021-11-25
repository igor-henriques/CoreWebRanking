namespace CoreRankingAPI.Model;

public class Banned
{
    [Key]
    public int Id { get; set; }
    [Required]
    [ForeignKey("Role")]
    public int RoleId { get; set; }
    public Role Role { get; set; }
    public DateTime BanTime { get; set; }
}