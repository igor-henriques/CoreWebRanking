namespace CoreRankingAPI.Security
{
    internal static class ClientAccessRule
    {
        //All rules are analysed by IP Address. 
        //30 requests per minute per IP;
        //1.500 requests per hour per IP;
        //30.000 requests per day per IP;

        private static readonly int minuteLimitRequests = 30;
        private static readonly int hourLimitRequests = 1_500;
        private static readonly int dayLimitRequests = 30_000;

        public static bool AccordingToMinuteRule(this List<ClientAccess> requests)
        {
            var filteredRequests = requests
                .Where(x => x.RequestDate > DateTime.Now.AddMinutes(-1));

            return filteredRequests.Count() <= minuteLimitRequests;
        }

        public static bool AccordingToHourRule(this List<ClientAccess> requests)
        {
            var filteredRequests = requests
                .Where(x => x.RequestDate > DateTime.Now.AddHours(-1));              

            return filteredRequests.Count() <= hourLimitRequests;
        }

        public static bool AccordingToDayRule(this List<ClientAccess> requests)
        {
            var filteredRequests = requests
                .Where(x => x.RequestDate > DateTime.Now.AddDays(-1));                

            return filteredRequests.Count() <= dayLimitRequests;
        }
    }
}
