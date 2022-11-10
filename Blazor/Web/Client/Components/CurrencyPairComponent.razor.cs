using Messages.Client;
using Messages.ClientServer;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading;
using System.Threading.Tasks;
using Web.Shared.Models;
using Web.Shared.Queries;

namespace Web.Client.Components
{    
    public partial class CurrencyPairComponent:UpdateIndicatorBaseComponent, ICurrencyPair, IListener<HeartBeat.HeartBeatNotification>, IDisposable
    {
        [Inject]
        private IUIBus? UIBus { get; set; }
        [Inject]
        private IAPIBus? APIBus { get; set; }
        [Parameter, EditorRequired]
        public string FirstTicker { get; set; } = string.Empty;
        [Parameter, EditorRequired]

        public string SecondTicker { get; set; } = string.Empty;
        protected override int DelayMS { get; } = 150;
        private double Rate { get; set; }
        private string DisplayRate => Rate == 0 ? "Loading..." : Rate.ToString();

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Handle(null);
            UIBus?.Register(this);
        }
        public void Dispose()
        {
            UIBus?.UnRegister(this);
            CSource?.Cancel();
            CSource?.Dispose();
            GC.SuppressFinalize(this);
        }
        private CancellationTokenSource? CSource;
        private Task? LoadingTask;
        public void Handle(HeartBeat.HeartBeatNotification? theEvent)
        {
            if (LoadingTask != null && !LoadingTask.IsCompleted && !LoadingTask.IsCanceled)
                return;
            CSource?.Cancel();
            CSource?.Dispose();
            CSource = new CancellationTokenSource();
            LoadingTask = LoadRate(CSource.Token);
        }
        private async Task LoadRate(CancellationToken token)
        {
            if (APIBus == null || FirstTicker == null || SecondTicker == null)
                return;
            var response = await APIBus.Send(new CurrencyQuery(FirstTicker, SecondTicker));
            if (token.IsCancellationRequested)
                return;
            this.Rate = response.Rate;
            Indicate();
        }
    }
}
