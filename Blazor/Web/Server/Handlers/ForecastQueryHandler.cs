using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Web.Shared.Models;
using Web.Shared.Queries;

namespace Web.Server.Handlers
{
    public class ForecastQueryHandler : IRequestHandler<ForecastQuery, WeatherForecast[]>
    {
        public Task<WeatherForecast[]> Handle(ForecastQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new WeatherForecastData().GetAll());
        }
    }
}
