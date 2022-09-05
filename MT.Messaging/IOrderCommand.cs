using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Messaging
{
    public interface IOrderCommand
    {
        int OrderID { get; set; }
        string OrderCode { get; set; }
    }
}
