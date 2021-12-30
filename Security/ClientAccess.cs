namespace CoreRankingAPI.Security
{
    internal record ClientAccess
    {
        public string IpAddress { get; private init; }
        public DateTime RequestDate { get; private init; }

        public ClientAccess(string ipAddress, DateTime requestDate)
        {
            this.IpAddress = ipAddress;
            this.RequestDate = requestDate;
        }
    }
}
