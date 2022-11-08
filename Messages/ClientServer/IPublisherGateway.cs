namespace Messages.ClientServer
{
    /// <summary>
    /// Inspired by https://github.com/jeffreypalermo/blazor-wasm-single-web-api/blob/master/src/Shared/IPublisherGateway.cs
    /// </summary>
    public interface IPublisherGateway
    {
        Task<WebServiceMessage?> Publish(IRemoteableRequest request);
    }
}