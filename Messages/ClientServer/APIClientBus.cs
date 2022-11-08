namespace Messages.ClientServer
{
    /// <summary>
    /// Inspired by: https://github.com/jeffreypalermo/blazor-wasm-single-web-api/blob/master/src/Shared/RemotableBus.cs
    /// Handles messages on client that are going to the server.
    /// </summary>
    internal class APIClientBus : APIServerBus
    {
        private PublisherGateway _gateway;        

        public APIClientBus(MediatR.IMediator mediator, PublisherGateway gateway):base(mediator)
        {
            _gateway = gateway;
        }

        public async override Task<TResponse> Send<TResponse>(IQuery<TResponse> q)
        {
            if(q is IRemoteQuery<TResponse> rq)
            {
                WebServiceMessage result = await _gateway.Publish(rq) ?? throw new InvalidOperationException();
                TResponse returnEvent = result.GetBodyObject<TResponse>();
                return returnEvent;
            }
            return await base.Send(q);
        }
    }
}
