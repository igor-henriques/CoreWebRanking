namespace CoreRankingAPI;

public class Program
{
    public static async Task Main(string[] args)
    {
        var listenerUrls = await URL.GetUrls();

        ClientAccessControl.StartDailyTimer();

        CreateHostBuilder(listenerUrls).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseUrls(args);
                webBuilder.UseStartup<Startup>();
            });
}