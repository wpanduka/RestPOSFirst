using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Data
{
    class StuwardTbl
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(500)]
        public int StuwaID { get; set; }
        public string StuwaName { get; set; }
        public StuwardTbl()
        {
        }
    }
}
