using Messages.Client;
using System.Security.Principal;
using UnitTests.Models;

namespace UnitTests
{
    public class UIBusTests
    {
        [Fact]
        public void ListenersReceivesEvent_EventPublished_SameObject()
        {
            IUIBus bus = Messages.Extentions.CreateDefaultClientBusImplementation();
            var listeners = new int[] { 0, 1, 2 }.Select(i => new MockEventListener()).ToList();
            listeners.ForEach(l => bus.Register(l));
            
            MockEvent ev = new();
            bus.Notify(ev);

            foreach(var listener in listeners)
                Assert.Equal(ev, listener.Events.LastOrDefault());
        }
        [Fact]
        public void ListenerNotReceivesEvent_EventPublishedUnRegistered()
        {
            IUIBus bus = Messages.Extentions.CreateDefaultClientBusImplementation();
            var listener = new MockEventListener();
            bus.Register(listener);
            bus.UnRegister(listener);

            MockEvent ev = new();
            bus.Notify(ev);

            Assert.Empty(listener.Events);
        }
    }
}