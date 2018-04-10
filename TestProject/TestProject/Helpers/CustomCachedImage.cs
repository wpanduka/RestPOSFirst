using System;
using FFImageLoading.Forms;
using Xamarin.Forms;

namespace TestProject
{
    public class CustomCachedImage : CachedImage
    {
        static ICacheKeyFactory _factory = new CustomCacheKeyFactory();

        public CustomCachedImage()
        {
        }

        protected override ImageSource CoerceImageSource(object newValue)
        {
            if (newValue is CustomStreamImageSource)
            {
                CacheKeyFactory = _factory;
            }
            else
            {
                CacheKeyFactory = null;
            }

            return base.CoerceImageSource(newValue);
        }

        class CustomCacheKeyFactory : ICacheKeyFactory
        {
            public string GetKey(ImageSource imageSource, object bindingContext)
            {
                var customStreamImageSource = imageSource as CustomStreamImageSource;

                if (customStreamImageSource != null)
                {
                    return customStreamImageSource.Key;
                }

                return null;
            }
        }
    }
}
