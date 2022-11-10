using Messages.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Models
{
    internal class MockEventListener : IListener<MockEvent>
    {
        public List<IUiBusEvent> Events { get; } = new List<IUiBusEvent>();
        public MockEventListener()
        {
        }
        public void Dispose()
        {
        }

        public void Handle(MockEvent theEvent)
        {
            this.Events.Add(theEvent);
        }
    }
}
