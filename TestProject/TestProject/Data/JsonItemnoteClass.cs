using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestProject.Data
{

    public class JsonItemnoteClass : INotifyPropertyChanged
    {
        private bool _isSelected;

        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonIgnore]
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected != value)
                {

                    _isSelected = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("IsSelected"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }




    public class JsonItemNote
    {
        public List<JsonItemnoteClass> NoteInfo { get; set; }
    }



}
