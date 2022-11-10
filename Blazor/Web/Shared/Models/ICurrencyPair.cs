using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Shared.Models
{
    public interface ICurrencyPair
    {
        string FirstTicker { get; }
        string SecondTicker { get; }
    }
}
