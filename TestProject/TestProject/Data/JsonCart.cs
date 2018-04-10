using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Data
{
    public class JsonCart
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Qty { get; set; }
        public string Price { get; set; }
        public decimal Total { get; set; }
        public string Comments { get; set; }
        public int Tabledetailid { get; set; }
        public string Batchno { get; set; }
        public string Stewardname { get; set; }
        //  public int PaxNum { get; set; }        
        //public string Image { get; set; }
        // public string ImageBase64 { private get; set; }
        // public byte[] Image { get; set; }
    }

    public class JsonCartone
    {
        public List<JsonCart> CartDetails { get; set; }
    }


}
