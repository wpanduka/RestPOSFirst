using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Data
{
    class TempTbl
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(500)]
        public string TblName{ get; set; }   
        public int TblNumbe { get; set; }
        public TempTbl()
        {
        }
    }
}
