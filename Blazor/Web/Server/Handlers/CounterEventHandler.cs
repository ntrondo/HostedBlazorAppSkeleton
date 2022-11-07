using MediatR;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Web.Shared.Queries;

namespace Web.Server.Handlers
{
    public class CounterEventHandler : IRequestHandler<CounterQuery, ServerCount>
    {
        public Task<ServerCount> Handle(CounterQuery request, CancellationToken cancellationToken)
        {
            var spn = Process.GetCurrentProcess().ProcessName;
            var sc = new ServerCount(request.Count + 2, spn);
            return Task.FromResult(sc);
        }
    }
}
