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
            if (response != null)
                return response;
            double d = r.NextDouble();
            await Task.Delay((int)(d * 2000));
            double rate = d * 10;
            return new CurrencyResponse() { Rate = rate };
        }
        private static async Task<CurrencyResponse?> Fetch(ICurrencyPair input)
        {
            string baseUrl = "https://min-api.cryptocompare.com/data/price";
            CurrencyResponse? response = null;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl + String.Format("?fsym={0}&tsyms={1}", input.FirstTicker, input.SecondTicker)))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            if (data != null)
                            {
                                Dictionary<string, double>? parsed = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, double>>(data);
                                if (parsed != null && input.SecondTicker != null && parsed.ContainsKey(input.SecondTicker))
                                    response = new CurrencyResponse() { Rate = parsed[input.SecondTicker] };
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
            }
            return response;
        }
    }
}
