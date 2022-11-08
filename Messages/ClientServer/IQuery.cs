using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.ClientServer
{
    public interface IQuery<T>: MediatR.IRequest<T>
    {
    }
}
