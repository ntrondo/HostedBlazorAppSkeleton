using Messages.Client;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Client.Components
{
    public partial class HeartBeat:ComponentBase,IDisposable
    {
        private CancellationTokenSource? CSource { get; set; }
        [Inject]
        private IUIBus? UIBus { get; set; }
        private static readonly int StartingInterval = 5000;
        private static readonly double BackOffFactor = 1.1;
        private double interval = StartingInterval;
        private int Interval
        {
            get
            {
                int i = (int)interval;
                interval = interval * BackOffFactor;
                return i;
            }
        }
        public void Dispose()
        {
            CSource?.Cancel();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            CSource = new CancellationTokenSource();
            _ = EmitHeartBeat(CSource.Token);
        }
        private Task EmitHeartBeat(CancellationToken token)
        {
            if (token.IsCancellationRequested)
                return Task.CompletedTask;
            int ms = Interval;
            UIBus?.Notify(new HeartBeatNotification(ms));
           
            return Task.Run(async () => { await Task.Delay(ms, token); return EmitHeartBeat(token); });
        }
        public class HeartBeatNotification : IUiBusEvent 
        {
            public int Frequency { get; }
            internal HeartBeatNotification(int frequency)
            {
                this.Frequency = frequency;
            }
        }
    }
}
