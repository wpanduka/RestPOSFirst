using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Data
{
    public class TicketGroupModel
    {
        public int TableID { get; set; }
        public int TicketID { get; set; }
    }

    public class TicketGroup
    {
        public List<TicketGroupModel> TicketGroupInfo { get; set; }
    }
}
