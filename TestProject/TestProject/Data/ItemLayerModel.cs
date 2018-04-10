using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Data
{
    public class ItemLayerModel
    {
        public int itemlid { get; set; }
        public string Name { get; set; }        
    }

    public class ItemLayerInfoM
    {
        public List<ItemLayerModel> ItmLayerInfo { get; set; }
    }
}
