using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestProject.Data
{
    public class CachedListView : ListView
    {
        public CachedListView() : base(ListViewCachingStrategy.RecycleElement) { }

        
    }


}
