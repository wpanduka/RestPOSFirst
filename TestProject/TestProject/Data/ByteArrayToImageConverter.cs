using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestProject.Data
{
    public class ByteArrayToImageConverter : IValueConverter
    {
        /// from hear///////////////////////////////////////////////
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ImageSource imgsrc = null;
            try
            {
                if (value == null)
                    return null;
                byte[] bArray = (byte[])value;

                imgsrc = ImageSource.FromStream(() =>
                {
                    var ms = new MemoryStream(bArray);
                    // ms.Position = 0;
                    //imgsrc.CopyTo(ms);
                    //ms.Read(bArray, 0, (int)ms.Length); 
                    ms.FlushAsync();
                    ms.Flush();
                    if (value == imgsrc)
                    {
                        //var ms = new MemoryStream(bArray);
                        ms.Dispose();
                        ms.FlushAsync();
                        ms.Flush();
                    }
                    // ms.Dispose();  
                    ms.FlushAsync();
                    ms.Flush();
                    return ms;      
                    
                });

                if (value == imgsrc)
                {
                    var ms = new MemoryStream(bArray);
                    ms.Dispose();
                }
                


            }
            catch (System.Exception sysExc)
            {
                System.Diagnostics.Debug.WriteLine(sysExc.Message);
            }
            return imgsrc;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
          System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        ///// to hear//////////////////////
    }
}

