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
    public class BlurDecorator : ImageDecorator
    {
        public BlurDecorator(IImage image) : base(image) { }

        public override WriteableBitmap GetImage()
        {
            WriteableBitmap source = _image.GetImage();
            int width = source.PixelWidth;
            int height = source.PixelHeight;
            int stride = width * 4;
            byte[] pixels = new byte[height * stride];
            source.CopyPixels(pixels, stride, 0);
            byte[] result = new byte[pixels.Length];

            int[,] kernel = {
                {1, 1, 1},
                {1, 1, 1},
                {1, 1, 1}
            };

            int kernelSize = 3;
            int kernelSum = 9;

            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    int blue = 0, green = 0, red = 0;

                    for (int ky = 0; ky < kernelSize; ky++)
                    {
                        for (int kx = 0; kx < kernelSize; kx++)
                        {
                            int px = (x + kx - 1);
                            int py = (y + ky - 1);
                            int idx = (py * stride) + (px * 4);

                            blue += pixels[idx] * kernel[ky, kx];
                            green += pixels[idx + 1] * kernel[ky, kx];
                            red += pixels[idx + 2] * kernel[ky, kx];
                        }
                    }

                    int i = (y * stride) + (x * 4);
                    result[i] = (byte)(blue / kernelSum);
                    result[i + 1] = (byte)(green / kernelSum);
                    result[i + 2] = (byte)(red / kernelSum);
                    result[i + 3] = 255; 
                }
            }

            WriteableBitmap output = new WriteableBitmap(width, height, 96, 96, PixelFormats.Bgra32, null);
            output.WritePixels(new System.Windows.Int32Rect(0, 0, width, height), result, stride, 0);
            return output;
        }
    }
}
