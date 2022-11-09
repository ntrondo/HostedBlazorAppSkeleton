using Messages.ClientServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Shared.Models;

namespace Web.Shared.Queries
{
    public class CurrencyQuery : IRemoteQuery<CurrencyResponse>, ICurrencyPair
    {
        public string? FirstTicker { get; set; }

        public string? SecondTicker { get; set; }
    }
    public class CurrencyResponse 
    {
        public string? Error { get; set; }
        public double Rate { get; set; }
    }
}
