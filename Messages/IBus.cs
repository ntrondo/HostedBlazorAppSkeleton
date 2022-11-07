

namespace Messages
{
    /// <summary>
    /// Inspired by https://github.com/jeffreypalermo/blazor-wasm-single-web-api/blob/master/src/Shared/IBus.cs
    /// </summary>
    public interface IBus 
    {
        Task<TResponse> Send<TResponse>(MediatR.IRequest<TResponse> request);
        Task<object?> Send(object request);
        void Publish<TNotification>(TNotification notification) where TNotification : MediatR.INotification;
    }
}