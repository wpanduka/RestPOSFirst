using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Data
{
    public class TicketTableModel
    {
       // public int ID { get; set; }
        public int TicketNum { get; set; }
       
    }

    public class TicketModel
    {
        public List<TicketTableModel> TicketNumJson { get; set; }
    }
}
