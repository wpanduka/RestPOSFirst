using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Data
{
    public class TotalTbl
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(500)]
        public int ItmID { get; set; }
        public decimal ItmTotal { get; set; }
        public TotalTbl()
        {
        }
    }
}
