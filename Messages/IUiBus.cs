using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public interface IUiBus
    {
        void Register(IListener listener);
        void UnRegister(IListener listener);
        IListener<T>[] GetListeners<T>() where T : IUiBusEvent;
        void Notify<T>(T notification) where T : IUiBusEvent;
        void UnRegisterAll();
    }
}
