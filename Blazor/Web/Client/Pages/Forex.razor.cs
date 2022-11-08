using Messages.Client;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Client.Components;
using Web.Shared.Models;

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
