using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace ooap_lab5
{
    public class ResizeDecorator : ImageDecorator
    {
        private int _newWidth, _newHeight;

        public ResizeDecorator(IImage image, int newWidth, int newHeight) : base(image)
        {
            _newWidth = newWidth;
            _newHeight = newHeight;
        }

        public override WriteableBitmap GetImage()
        {
            TransformedBitmap tb = new TransformedBitmap(_image.GetImage(),
                new ScaleTransform((double)_newWidth / _image.GetImage().PixelWidth,
                                   (double)_newHeight / _image.GetImage().PixelHeight));
            return new WriteableBitmap(tb);
        }
    }
}
