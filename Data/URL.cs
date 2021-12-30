namespace CoreRankingAPI.Data
{
    public record URL
    {        
        public static async Task<string[]> GetUrls()
        {            
            return await File.ReadAllLinesAsync("./Configurations/ListenerURL.json");
        }
    }
}
