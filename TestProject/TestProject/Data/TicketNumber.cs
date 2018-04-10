using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Data
{
    public class TicketNumber
    {
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }

        [MaxLength(500)]
        public string TicketNum { get; set; }
        public TicketNumber()
        {
        }
    }
}
