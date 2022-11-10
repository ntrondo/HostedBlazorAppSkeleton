using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.ClientServer
{
    public interface IQueryHandler<Q,R>: IRequestHandler<Q, R> where Q : IQuery<R>
    {
    }
}
