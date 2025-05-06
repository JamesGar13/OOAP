using System.Windows.Media.Imaging;
using System.Windows.Media;
using System;

namespace ooap_lab5
{
    public class SaturationDecorator : ImageDecorator
    {
        private double _factor;
        public SaturationDecorator(IImage image, double factor) : base(image)
        {
            _factor = factor;
        }

        public override WriteableBitmap GetImage()
        {
            WriteableBitmap source = _image.GetImage();
            int width = source.PixelWidth;
            int height = source.PixelHeight;
            int stride = width * 4;
            byte[] pixels = new byte[height * stride];
            source.CopyPixels(pixels, stride, 0);

            for (int i = 0; i < pixels.Length; i += 4)
            {
                double r = pixels[i + 2] / 255.0;
                double g = pixels[i + 1] / 255.0;
                double b = pixels[i + 0] / 255.0;

                double gray = (r + g + b) / 3.0;

                r = gray + (r - gray) * _factor;
                g = gray + (g - gray) * _factor;
                b = gray + (b - gray) * _factor;

                pixels[i + 2] = Clamp(r * 255, 0, 255);
                pixels[i + 1] = Clamp(g * 255, 0, 255);
                pixels[i + 0] = Clamp(b * 255, 0, 255);
            }

            WriteableBitmap result = new WriteableBitmap(width, height, 96, 96, PixelFormats.Bgra32, null);
            result.WritePixels(new System.Windows.Int32Rect(0, 0, width, height), pixels, stride, 0);
            return result;
        }
        private byte Clamp(double value, byte min = 0, byte max = 255)
        {
            if (value < min) return min;
            if (value > max) return max;
            return (byte)value;
        }
    }
}
