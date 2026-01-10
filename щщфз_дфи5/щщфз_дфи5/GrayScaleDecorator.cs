using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ooap_lab5;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace щщфз_дфи5
{
    public class GrayScaleDecorator : ImageDecorator
    {
        public GrayScaleDecorator(IImage image) : base(image) { }
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
                byte r = pixels[i + 2];
                byte g = pixels[i + 1];
                byte b = pixels[i];

                byte gray = (byte)((r + g + b) / 3);
                pixels[i] = gray;
                pixels[i + 1] = gray;
                pixels[i + 2] = gray;
            }

            WriteableBitmap result = new WriteableBitmap(width, height, 96, 96, PixelFormats.Bgra32, null);
            result.WritePixels(new System.Windows.Int32Rect(0, 0, width, height), pixels, stride, 0);

            return result;
        }
    }

}
