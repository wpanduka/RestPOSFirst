using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Data
{
    class PromotionDB
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(1000)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Date { get; set; }
        public string Image { get; set; }
        public PromotionDB()
        {
        }
    }
}
