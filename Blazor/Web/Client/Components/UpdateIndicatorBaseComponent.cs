using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Client.Components
{
    public abstract class UpdateIndicatorBaseComponent:ComponentBase
    {
        protected bool Update { get; set; }
        protected bool Transition { get; set; }
        protected int Count { get; set; }
        private static string transitionClassName = "has-update-transition", updateClassName = "was-just-updated";
        protected string className
        {
            get
            {
                var cns = new List<string>(2);
                if (Update)
                    cns.Add(updateClassName);
                if (Transition)
                    cns.Add(transitionClassName);
                return string.Join(" ", cns.ToArray());
            }
        }
        protected abstract int DelayMS { get; }
        protected void Indicate()
        {
            Update = true;
            Transition = false;
            Count++;
            _ = Task.Run(async () => { await Task.Delay(DelayMS); TurnOffUpdate(); });
            _ = Task.Run(async () => { await Task.Delay(DelayMS / 2); TurnOnTransition(); });
            _ = InvokeAsync(base.StateHasChanged);
        }
        private void TurnOnTransition()
        {
            Transition = true;
            InvokeAsync(base.StateHasChanged);
        }

        private void TurnOffUpdate()
        {
            Update = false;
            InvokeAsync(base.StateHasChanged);
        }
    }
}
