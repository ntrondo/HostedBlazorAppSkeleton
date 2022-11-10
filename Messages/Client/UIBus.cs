
namespace Messages.Client
{
    /// <summary>
    /// Inspired by https://github.com/jeffreypalermo/blazormvc/blob/master/BlazorMvc/MvcBus.cs
    /// </summary>
    internal class UIBus : IUIBus,IDisposable
    {
        private bool _disposed;
        private readonly ISet<IListener> _listeners = new HashSet<IListener>();

        public void Register(IListener listener)
        {
            if (listener == null) return;
            _listeners.Add(listener);
        }

        public void UnRegister(IListener listener)
        {
            _listeners.Remove(listener);
        }

        public IListener<T>[] GetListeners<T>() where T : IUiBusEvent
        {
            IEnumerable<IListener> listeners = _listeners.Where(c => c is IListener<T>);
            IEnumerable<IListener<T>> enumerable = listeners.Select(listener => (IListener<T>)listener);
            return enumerable.ToArray();
        }

        public void Notify<T>(T notification) where T : IUiBusEvent
        {
            IListener<T>[] listeners = GetListeners<T>();
            foreach (IListener<T> listener in listeners)
                listener.Handle(notification);
        }

        public void UnRegisterAll()
        {
            _listeners.Clear();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) { return; }
            if (disposing)
            {
                UnRegisterAll();
            }
            _disposed = true;
        }
        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
