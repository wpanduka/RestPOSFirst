using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Data
{
    public class Contact
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string ImageBase64 { private get; set; }
        public byte[] Image
        {
            get
            {
                if (ImageBase64 != "" && ImageBase64 != null)
                {
                    byte[] image = Convert.FromBase64String(ImageBase64);
                    return image;
                }

                return null;
            }
        }
    }
}
