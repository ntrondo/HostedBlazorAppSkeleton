using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.ClientServer
{
    public interface IRemoteQuery<T> : IRemoteableRequest, IQuery<T>
    {
    }
}
