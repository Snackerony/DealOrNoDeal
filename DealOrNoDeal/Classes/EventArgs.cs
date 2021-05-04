using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealOrNoDeal.Classes
{
    public class ListEventArgs<T> : EventArgs
    {
        public List<T> list { get; set; }
    }
}
