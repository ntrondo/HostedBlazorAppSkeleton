namespace Messages.ClientServer
{
    /// <summary>
    /// Inspired by https://github.com/jeffreypalermo/blazor-wasm-single-web-api/blob/master/src/Shared/Bus.cs
    /// Handles messages on the server. 
    /// </summary>
    internal class APIServerBus : IAPIBus
    {
        private readonly MediatR.IMediator _mediator;
        public APIServerBus(MediatR.IMediator mediator)
        {
            _mediator = mediator;
        }

        public virtual async Task<TResponse> Send<TResponse>(IQuery<TResponse> q)
        {
            TResponse response = await _mediator.Send(q);
            return response;
        }

        public async Task<object?> Send(object request)
        {
            var response = await _mediator.Send(request);
            return response;
        }
    }
}
