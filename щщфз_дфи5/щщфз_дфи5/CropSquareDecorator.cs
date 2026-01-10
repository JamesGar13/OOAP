using System;
using System.Windows.Media.Imaging;

namespace ooap_lab5
{
    public class CropSquareDecorator : ImageDecorator
    {
        public CropSquareDecorator(IImage image) : base(image) { }

        public override WriteableBitmap GetImage()
        {
            WriteableBitmap source = _image.GetImage();
            int size = Math.Min(source.PixelWidth, source.PixelHeight);
            int x = (source.PixelWidth - size) / 2;
            int y = (source.PixelHeight - size) / 2;

            var cropped = new CroppedBitmap(source, new System.Windows.Int32Rect(x, y, size, size));
            return new WriteableBitmap(cropped);
        }
    }
}
