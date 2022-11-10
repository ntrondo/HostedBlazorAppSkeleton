using Web.Shared.Models;

namespace Web.Server.Models
{
    public class CurrencyPairModel : ICurrencyPair
    {
        public CurrencyPairModel(string firstTicker, string secondTicker)
        {
            this.FirstTicker = firstTicker;
            this.SecondTicker = secondTicker;
        }

        public string FirstTicker { get; }
        public string SecondTicker { get; }
        public string Id => FirstTicker + SecondTicker;
    }
}
