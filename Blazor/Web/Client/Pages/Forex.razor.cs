using Microsoft.AspNetCore.Components;
using Web.Server.Models;

namespace Web.Client.Pages
{
    public partial class Forex : ComponentBase
    {
        private CurrencyPairModel[] Models = new CurrencyPairModel[]
        {
            new CurrencyPairModel("SEK","NOK"),
            new CurrencyPairModel("EUR","NOK"),
            new CurrencyPairModel("GBP","NOK"),
            new CurrencyPairModel("USD","NOK")
        };
       
    }
}
