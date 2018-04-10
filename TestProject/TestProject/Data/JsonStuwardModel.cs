using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Data
{
    public class JsonStuwardModel
    {
        public long ID { get; set; }
        public string StName { get; set; }
    }

    public class JsonStuwardone
    {
        public List<JsonStuwardModel> StuwardInfo { get; set; }
    }
}
