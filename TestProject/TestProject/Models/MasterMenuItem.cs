using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestProject.Models
{
    public class MasterMenuItem
    {
        public string Title { get; set; }
        public string IconSource { get; set; }
        public Color BackgroundColor { get; set; }
        public Type TargetType { get; set; }

        public MasterMenuItem ( string Title, string IconSource, Color color, Type Target)
        {
            this.Title = Title;
            this.IconSource = IconSource;
            this.BackgroundColor = color;
            this.TargetType = Target;

        }
    
    }
}
