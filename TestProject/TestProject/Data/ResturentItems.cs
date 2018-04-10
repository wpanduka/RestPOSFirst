using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestProject.Data
{
    public class ResturentItems : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //public ResturentItems(ResturentItem item)
        //{
        //    ResturentItem = item;
        //}

        public long ID { get; set; }
       // public CustomStreamImageSource Item { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool isservicecharge { get; set; }
        public bool isaddonapplicable { get; set; }
        public decimal CostPrice { get; set; }
        public string Date { get; set; }
        public byte[] _image;

        public byte[] Image 
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
                OnPropertyChanged();
            }
        }

        //public bool isaddonapplicable { get; set; }
        //private string resturentItem;
        //public string ResturentItem
        //{
        //    get { return resturentItem; }
        //    set { resturentItem = value; OnPropertyChanged(nameof(ResturentItem)); }
        //}

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    var handler = PropertyChanged;
        //    if (handler != null)
        //    {
        //        handler(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}

    }

    public class ResturentList
    {
        public IList<ResturentItems> Resturent { get; set; }
    }




}
