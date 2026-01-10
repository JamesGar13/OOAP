using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace ooap_lab5
{
    public class CropCircleDecorator : ImageDecorator
    {
        public CropCircleDecorator(IImage image) : base(image) { }

        public override WriteableBitmap GetImage()
        {
            WriteableBitmap square = new CropSquareDecorator(_image).GetImage();
            int size = square.PixelWidth;
            int stride = size * 4;
            byte[] pixels = new byte[size * size * 4];
            square.CopyPixels(pixels, stride, 0);

            int centerX = size / 2;
            int centerY = size / 2;
            int radius = size / 2;

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    int dx = x - centerX;
                    int dy = y - centerY;
                    if (dx * dx + dy * dy > radius * radius)
                    {
                        int idx = (y * stride) + (x * 4);
                        pixels[idx + 3] = 0; // alpha = 0 (прозорий)
                    }
                }
            }

            WriteableBitmap output = new WriteableBitmap(size, size, 96, 96, PixelFormats.Bgra32, null);
            output.WritePixels(new System.Windows.Int32Rect(0, 0, size, size), pixels, stride, 0);
            return output;
        }
    }
}
