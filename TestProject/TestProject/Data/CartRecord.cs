using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Data
{
    public class CartRecord
    {
        [PrimaryKey, AutoIncrement, Column("ID")]
        public int Id { get; set; }

        [MaxLength(1000)]
        public string Name { get; set; }
        public string Price { get; set; }
        public string Qty { get; set; }
        public string Total { get; set; }
        public string Image { get; set; }
        public string Table { get; set; }
        public string Results { get; set; }
       
        public CartRecord()
        {
        }
        
    }
}
