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

        public async override Task<R> Send<R>(IQuery<R> q)
        {
            if(q is IRemoteQuery<R> rq)
            {
                WebServiceMessage result = await _gateway.Publish(rq) ?? throw new InvalidOperationException();
                R? r = result.GetBodyObject<R>();
                return r ?? new();
            }
            return await base.Send(q);
        }
    }
}
