using Messages.Client;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Client.Components
{
    public partial class HeartBeatIndicator: UpdateIndicatorBaseComponent, IListener<HeartBeat.HeartBeatNotification>, IDisposable
    {
        [Inject]
        private IUIBus? UIBus { get; set; }
        protected override void OnInitialized()
        {
            base.OnInitialized();
            UIBus?.Register(this);
        }
        protected override int DelayMS { get; } = 100;
        private HeartBeat.HeartBeatNotification? LastBeat { get;  set; }

        public void Handle(HeartBeat.HeartBeatNotification theEvent)
        {
            this.LastBeat = theEvent;
            Indicate();
            
        }
        public void Dispose()
        {
            UIBus?.UnRegister(this);
        }
    }
}
