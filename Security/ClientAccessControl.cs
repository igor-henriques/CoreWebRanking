using System.Timers;

namespace CoreRankingAPI.Security
{
    public class ClientAccessControl
    {
        private static readonly Timer dailyTimer = new Timer(TimeSpan.FromDays(1).TotalMilliseconds);

        private static readonly List<ClientAccess> clientsRequests = new List<ClientAccess>();

        public static void StartDailyTimer()
        {
            dailyTimer.Elapsed += (obj, e) => ClearRequests();
            dailyTimer.Start();
        }

        public static bool ProcessRequest(string ipAddress)
        {
            AddRequest(ipAddress);

            var thisClientRequests = clientsRequests.Where(x => x.IpAddress.Equals(ipAddress)).ToList();

            return thisClientRequests.AccordingToMinuteRule() &
                   thisClientRequests.AccordingToHourRule()   &
                   thisClientRequests.AccordingToDayRule();
        }

        private static void AddRequest(string ipAddress) => clientsRequests.Add(new(ipAddress, DateTime.Now));

        private static void ClearRequests() => clientsRequests.Clear();
    }
}
