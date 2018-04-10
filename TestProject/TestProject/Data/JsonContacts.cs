using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Data{
    public class Contactone    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool isservicecharge { get; set; }
        public decimal CostPrice { get; set; }
        public string Date { get; set; }        
        public byte[] Image { get; set; }       
    }
    public class ContectList
    {
        public List<Contactone> contacts { get; set; }
    }
}
