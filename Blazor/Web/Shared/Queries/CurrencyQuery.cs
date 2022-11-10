using Messages.ClientServer;
using Web.Server.Models;

namespace Web.Shared.Queries
{
    public class CurrencyQuery : CurrencyPairModel, IRemoteQuery<CurrencyResponse>
    {
        public CurrencyQuery(string firstTicker, string secondTicker) : base(firstTicker, secondTicker)
        {
        }
    }
    public class CurrencyResponse 
    {
        public string? Error { get; set; }
        public double Rate { get; set; }
    }
}
