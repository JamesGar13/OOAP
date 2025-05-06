using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.IO;
using щщфз_дфи5;

namespace ooap_lab5
{
    public interface IImage
    {
        WriteableBitmap GetImage();
    }

    #region ImageType
    public class BaseImage : IImage
    {
        private WriteableBitmap _bitmap;

        public BaseImage(BitmapImage bitmapImage) 
        {
            _bitmap = new WriteableBitmap(bitmapImage);
        }

        public WriteableBitmap GetImage() => _bitmap;
    }

    public class CustomImage : IImage
    {
        private WriteableBitmap _bitmap;
        public CustomImage(WriteableBitmap bitmap)
        {
            _bitmap = bitmap;
        }
        public WriteableBitmap GetImage() => _bitmap;
    }
    #endregion

    #region ImageDecorator

    public abstract class ImageDecorator : IImage
    {
        protected IImage _image;

        protected ImageDecorator(IImage image) 
        {
        _image = image;
        }
        public abstract WriteableBitmap GetImage();
    }

    
    public class ImageProcessorFacade
    {
        private IImage _image;

        public ImageProcessorFacade(BitmapImage image)
        {
            _image = new BaseImage(image);
        }

        public WriteableBitmap GetCurrentImage()
        {
            return _image?.GetImage();
        }

        public void Save(string filePath)
        {
            var bitmap = GetCurrentImage();
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmap));
                encoder.Save(fileStream);
            }
        }
        #endregion

        #region Apply
        public void ApplyGrayscale()
        {
            _image = new GrayScaleDecorator(_image);
        }
        public void ApplyBlur()
        {
            _image = new BlurDecorator(_image);
        }

        public void ApplyNoise()
        {
            _image = new NoiseDecorator(_image);
        }
        public void ApplySharpen()
        {
            _image = new SharpenDecorator(_image);
        }

        public void ApplySaturation()
        {
            _image = new SaturationDecorator(_image,10);
        }

        public void ApplyResize()
        {
            _image = new ResizeDecorator(_image, 100, 100);
        }

        public void ApplyCropSquare()
        {
            _image = new CropSquareDecorator(_image);
        }

        public void ApplyCropCircle()
        {
            _image = new CropCircleDecorator(_image);
        }

    }

    #endregion
}




