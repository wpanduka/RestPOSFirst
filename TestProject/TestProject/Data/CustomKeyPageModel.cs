using FFImageLoading.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestProject.Data
{
    public class CustomKeyPageModel  : ResturentList
    {
        public CustomKeyPageModel()
        {

        }
    }

    public class CustomCacheKeyFactory : ICacheKeyFactory
    {
        public string GetKey(Xamarin.Forms.ImageSource imageSource, object bindingContext)
        {
            if (imageSource == null)
                return null;

            string itemSuffix = string.Empty;
            var bindingItem = bindingContext as ByteArrayToImageConverter;

            if (bindingItem != null)
                itemSuffix = bindingItem.ToString();

            // UriImageSource
            var uriImageSource = imageSource as UriImageSource;
            if (uriImageSource != null)
                return string.Format("{0}+myCustomUriSuffix+{1}", uriImageSource.Uri, itemSuffix);

            // FileImageSource
            var fileImageSource = imageSource as FileImageSource;
            if (fileImageSource != null)
                return string.Format("{0}+myCustomFileSuffix+{1}", fileImageSource.File, itemSuffix);

            // StreamImageSource
            var streamImageSource = imageSource as StreamImageSource;
            if (streamImageSource != null)
                return string.Format("{0}+myCustomStreamSuffix+{1}", streamImageSource.Stream.GetHashCode(), itemSuffix);

            //var byteimagesource = byte[] imageAsBytes = (byte[]bindingContext);
            ////retSource = ImageSource.FromStream(() => new MemoryStream(imageAsBytes));

            throw new NotImplementedException("ImageSource type not supported");
        }
    }
}
