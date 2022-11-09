using Microsoft.AspNetCore.Components;

namespace Web.Client.Shared
{
    public partial class NavMenu : ComponentBase
    {
        private bool collapseNavMenu = true;

        private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
       
        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }    
    }
}
