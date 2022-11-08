using Messages.Client;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading;
using System.Threading.Tasks;
using Web.Shared.Notifications;

namespace Web.Client.Shared
{
    public partial class NavMenu : ComponentBase, IListener<CounterIncrementingNotification>, IListener<CounterIncrementedNotification>,IDisposable
    {
        [Inject]
        private IUIBus? UIBus { get; set; }
        private bool isIncrementing { get; set; }
        private int Count { get; set; }
        private bool collapseNavMenu = true;

        private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        protected override void OnInitialized()
        {
            UIBus?.Register(this);
            base.OnInitialized();
        }
       
        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }     

        public async void Handle(CounterIncrementingNotification theEvent)
        {
            await Task.Delay(0);
            isIncrementing = true;
            _ = InvokeAsync(StateHasChanged);
        }

        public async void Handle(CounterIncrementedNotification theEvent)
        {
            Count++;
            isIncrementing = false;
            await Task.Delay(1000);
            _ = InvokeAsync(StateHasChanged);
        }

        public void Dispose()
        {
            UIBus?.UnRegister(this);
        }
    }
}
