using Bunit;
using Xunit.Abstractions;

namespace ComponentTests
{
    public class UIBusTests
    {
        public ITestOutputHelper Output { get; }
        public UIBusTests(ITestOutputHelper output) 
        {
            this.Output = output;
        }
        [Fact]
        public void ComponentsIncrement_ButtonClicked()
        {
            var ctx = new TestContext();
            RegisterServices(ctx.Services);

            var counter = ctx.RenderComponent<Web.Client.Pages.Counter>();
            var comps = counter.FindComponents<Web.Client.Components.CounterComponent>();
            Assert.NotEmpty(comps);

            var button = counter.Find("button.btn-primary");
            for (int i = 0; i < 10; i++)
            {                
                AssertCount(comps, i);
                button.Click();
            }            
        }

        private void AssertCount(IReadOnlyList<IRenderedComponent<Web.Client.Components.CounterComponent>> comps, int i)
        {
            foreach(var comp in comps)
                Assert.Contains("Current count: " + i, comp.Markup);            
        }

        private void RegisterServices(TestServiceProvider services)
        {
            Messages.Extentions.AddUIBusService(services);
        }
    }
}