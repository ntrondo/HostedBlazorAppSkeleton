using Messages.ClientServer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Web.Server.Controllers
{
    [ApiController]
    [Route(PublisherGateway.ApiRelativeUrl)]
    public class ApiController : ControllerBase
    {
        private readonly IAPIBus _bus;

        public ApiController(IAPIBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task<string> Post(WebServiceMessage webServiceMessage)
        {
            object body = webServiceMessage.GetBodyObject() ?? new();
            var result = await _bus.Send(body) ?? throw new InvalidOperationException();
            return new WebServiceMessage(result).GetJson();
        }
    }
}
