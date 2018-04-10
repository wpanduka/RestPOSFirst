using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Data
{
    public class TiketViewModel
    {
        public int TiketNumb { get; set; }
        public int FlagNum { get; set; }
    }

    public class JsonTicketNewNum
    {
        public List<TiketViewModel>TicketInfo { get; set; }
    }
}
