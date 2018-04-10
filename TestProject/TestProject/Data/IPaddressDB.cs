using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TestProject.Data
{
    public class IPaddressDB
    {
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }

        [MaxLength(500)]
        public string IPnumb { get; set; }
        public string Terminal { get; set;}
        public string Counter { get; set; }
        public string backgrund { get; set;}

        public IPaddressDB()
        {
        }
    }
}
