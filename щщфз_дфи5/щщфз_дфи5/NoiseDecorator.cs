
    using System;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using global::ooap_lab5;

    namespace ooap_lab5
    {
        public class NoiseDecorator : ImageDecorator
        {
            private static Random _rand = new Random();

            public NoiseDecorator(IImage image) : base(image) { }

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
                    int noise = _rand.Next(-30, 30);

                    pixels[i] = Clamp(pixels[i] + noise);       
                    pixels[i + 1] = Clamp(pixels[i + 1] + noise); 
                    pixels[i + 2] = Clamp(pixels[i + 2] + noise); 
                                                                 
                }

                WriteableBitmap result = new WriteableBitmap(width, height, 96, 96, PixelFormats.Bgra32, null);
                result.WritePixels(new System.Windows.Int32Rect(0, 0, width, height), pixels, stride, 0);
                return result;
            }

            private byte Clamp(int value)
            {
                return (byte)(value < 0 ? 0 : (value > 255 ? 255 : value));
            }
        }
    }


