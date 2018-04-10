using System;
using System.Globalization;
using Xamarin.Forms;
using System.IO;
using System.Threading.Tasks;
using TestProject.Data;
using FFImageLoading.Helpers;
using FFImageLoading.Cache;
using FFImageLoading;

namespace TestProject
{
    public class ResturentItemToImageSourceConverter : IValueConverter
    {
        private readonly IMD5Helper _md5;
        private readonly IDiskCache _diskCache;

        public ResturentItemToImageSourceConverter()
        {
            _md5 = ImageService.Instance.Config.MD5Helper;
            _diskCache = ImageService.Instance.Config.DiskCache;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var item = value as ResturentItems;

            if (item == null)
                return null;

            var key = _md5.MD5($"ResturentItems://{item.ID}");

            return new CustomStreamImageSource()
            {
                Key = key,
                Stream = (token) => 
                {
                    if (token.IsCancellationRequested)
                        return null;
                    
                    return _diskCache.TryGetStreamAsync(key);
                }
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
