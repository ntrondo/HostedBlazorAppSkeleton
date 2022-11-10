namespace Messages.ClientServer
{
    /// <summary>
    /// Inspired by https://github.com/jeffreypalermo/blazor-wasm-single-web-api/blob/master/src/Shared/IBus.cs
    /// Trimmed for use as api funnel
    /// </summary>
    public interface IAPIBus
    {
        Task<R> Send<R>(IQuery<R> request)where R:new();
        Task<object> Send(object request);
    }
}