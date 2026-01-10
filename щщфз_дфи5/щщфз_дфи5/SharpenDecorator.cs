using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ooap_lab5;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace ooap_lab5
{
    public class SharpenDecorator : ImageDecorator
    {
        public SharpenDecorator(IImage image) : base(image) { }

        public override WriteableBitmap GetImage()
        {
            WriteableBitmap source = _image.GetImage();
            int width = source.PixelWidth;
            int height = source.PixelHeight;
            int stride = width * 4;
            byte[] pixels = new byte[height * stride];
            byte[] result = new byte[pixels.Length];
            source.CopyPixels(pixels, stride, 0);

            int[,] kernel = {
                {  0, -1,  0 },
                { -1,  5, -1 },
                {  0, -1,  0 }
            };

            int kSize = 3;

            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    int blue = 0, green = 0, red = 0;
                    for (int ky = 0; ky < kSize; ky++)
                    {
                        for (int kx = 0; kx < kSize; kx++)
                        {
                            int px = x + kx - 1;
                            int py = y + ky - 1;
                            int idx = (py * stride) + (px * 4);
                            int k = kernel[ky, kx];

                            blue += pixels[idx] * k;
                            green += pixels[idx + 1] * k;
                            red += pixels[idx + 2] * k;
                        }
                    }

                    int i = (y * stride) + (x * 4);
                    result[i] = Clamp(blue, 0, 255);
                    result[i + 1] = Clamp(green, 0, 255);
                    result[i + 2] = Clamp(red, 0, 255);
                    result[i + 3] = 255;
                }
            }

            WriteableBitmap output = new WriteableBitmap(width, height, 96, 96, PixelFormats.Bgra32, null);
            output.WritePixels(new System.Windows.Int32Rect(0, 0, width, height), result, stride, 0);
            return output;
        }
        private byte Clamp(double value, byte min = 0, byte max = 255)
        {
            if (value < min) return min;
            if (value > max) return max;
            return (byte)value;
        }
    }
}
