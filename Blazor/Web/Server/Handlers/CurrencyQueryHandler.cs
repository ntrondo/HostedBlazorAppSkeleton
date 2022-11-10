using Messages.ClientServer;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Web.Shared.Models;
using Web.Shared.Queries;

namespace Web.Server.Handlers
{
    public class CurrencyQueryHandler : IQueryHandler<CurrencyQuery, CurrencyResponse>
    {
        public async Task<CurrencyResponse> Handle(CurrencyQuery request, CancellationToken cancellationToken)
        {
            var response = await Fetch(request);
            return response;
        }
        private static async Task<CurrencyResponse> Fetch(ICurrencyPair input)
        {
            string baseUrl = "https://min-api.cryptocompare.com/data/price";
            
            CurrencyResponse? response = new ();
            string ft = input.FirstTicker ?? string.Empty, st = input.SecondTicker ?? string.Empty;
            string url = baseUrl + String.Format("?fsym={0}&tsyms={1}", ft, st);
            try
            {
                using HttpClient client = new();                
                using HttpResponseMessage res = await client.GetAsync(url);
                using HttpContent content = res.Content;
                string data = await content.ReadAsStringAsync();
                response.Rate = GetNamedDoubleFromJson(st, data);
                if (response.Rate == default)
                    response.Error = "Could not read json from response or value is 0. Url: " + url;                
            }
            catch (Exception exception)
            {
                response.Error = exception.Message;
            }
            return response;
        }

        private static double GetNamedDoubleFromJson(string name, string json)
        {
            Dictionary<string, double> dict = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, double>>(json) ?? new();
            return dict.ContainsKey(name) ? dict[name] : default;
        }
    }
}
