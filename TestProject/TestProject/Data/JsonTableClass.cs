using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Data
{
    public class JsonTableClass
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string tableDet { get; set; }
    }

    public class JsonTableone
    {
        public List<JsonTableClass> TableInfo { get; set; }
    }
}
