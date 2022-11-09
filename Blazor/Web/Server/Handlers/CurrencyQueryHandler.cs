using MediatR;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Web.Shared.Models;
using Web.Shared.Queries;

namespace Web.Server.Handlers
{
    public class CurrencyQueryHandler : IRequestHandler<CurrencyQuery, CurrencyResponse>
    {
        private static Random r = new Random();
        public async Task<CurrencyResponse> Handle(CurrencyQuery request, CancellationToken cancellationToken)
        {
            var response = await Fetch(request);
            return response;
        }
        private static async Task<CurrencyResponse> Fetch(ICurrencyPair input)
        {
            string baseUrl = "https://min-api.cryptocompare.com/data/price";
            CurrencyResponse? response = new ();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = baseUrl + String.Format("?fsym={0}&tsyms={1}", input.FirstTicker, input.SecondTicker);
                    using (HttpResponseMessage res = await client.GetAsync(url))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            if (data != null)
                            {
                                Dictionary<string, double>? parsed = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, double>>(data);
                                if (parsed != null && input.SecondTicker != null && parsed.ContainsKey(input.SecondTicker))
                                    response.Rate = parsed[input.SecondTicker];
                            }
                            else
                            {
                                response.Error = "Could not read json from response.Content. Url: " + url;
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                response.Error = exception.Message;
            }
            return response;
        }
    }
}
