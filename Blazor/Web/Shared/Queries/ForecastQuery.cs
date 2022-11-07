using Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Shared.Models;

namespace Web.Shared.Queries
{
    public class ForecastQuery :IRemoteQuery<WeatherForecast[]>
    {
    }
}
