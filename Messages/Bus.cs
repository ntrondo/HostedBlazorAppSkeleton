
namespace Messages
{
    /// <summary>
    /// Inspired by https://github.com/jeffreypalermo/blazor-wasm-single-web-api/blob/master/src/Shared/Bus.cs
    /// </summary>
    public class Bus : IBus
    {
        private readonly MediatR.IMediator _mediator;
        public Bus(MediatR.IMediator mediator)
        {
            _mediator = mediator;
        }

        public virtual async Task<TResponse> Send<TResponse>(MediatR.IRequest<TResponse> request)
        {
            TResponse response = await _mediator.Send(request);
            return response;
        }

        public virtual async Task<object?> Send(object request)
        {
            var response = await _mediator.Send(request);
            return response;
        }

        public void Publish<TNotification>(TNotification notification) where TNotification : MediatR.INotification
        {
            _mediator.Publish(notification);
        }
    }
}
