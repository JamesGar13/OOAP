using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Drawing;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using щщфз_дфи5;



namespace ooap_lab5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ImageProcessorFacade _facade;
        private BitmapImage _originalImage;
        private IImage _currentImage;
        public MainWindow()


        {
            InitializeComponent();
        }

        #region buttons
        private void LoadImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpg)|*.png;*.jpg";

            if (openFileDialog.ShowDialog() == true)
            {
                _originalImage = new BitmapImage(new Uri(openFileDialog.FileName));
                _facade = new ImageProcessorFacade(_originalImage);
                ImageControl.Source = _originalImage;
            }
        }

        private void SaveImage_Click(object sender, RoutedEventArgs e)
        {
            if (_facade == null) return;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG Image|*.png";

            if (saveFileDialog.ShowDialog() == true)
            {
                _facade.Save(saveFileDialog.FileName);
                MessageBox.Show("Image saved!");
            }

        }

        #endregion

        private void GrayScale_Click(object sender, RoutedEventArgs e)
        {
            if (_facade == null) return;

            _facade.ApplyGrayscale();
            ImageControl.Source = _facade.GetCurrentImage();
        }

        private void Blur_Click(object sender, RoutedEventArgs e)
        {
            if (_facade == null) return;

            _facade.ApplyBlur();
            ImageControl.Source = _facade.GetCurrentImage();
        }

        private void Noise_Click(object sender, RoutedEventArgs e)
        {
            if (_facade == null) return;

            _facade.ApplyNoise();
            ImageControl.Source = _facade.GetCurrentImage();
        }

        private void Saturation_Click(object sender, RoutedEventArgs e)
        {
            if (_facade == null) return;
            _facade.ApplySaturation();
            ImageControl.Source = _facade.GetCurrentImage();
        }

        private void Sharpen_Click(object sender, RoutedEventArgs e)
        {
            if (_facade == null) return;
            _facade.ApplySharpen();
            ImageControl.Source = _facade.GetCurrentImage();
        }

        private void Resize_Click(object sender, RoutedEventArgs e)
        {
            if (_facade == null) return;
            _facade.ApplyResize();
            ImageControl.Source = _facade.GetCurrentImage();
        }

        private void CropSquare_Click(object sender, RoutedEventArgs e)
        {
            if (_facade == null) return;
            _facade.ApplyCropSquare();
            ImageControl.Source = _facade.GetCurrentImage();
        }

        private void CropCircle_Click(object sender, RoutedEventArgs e)
        {
            if (_facade == null) return;
            _facade.ApplyCropCircle();
            ImageControl.Source = _facade.GetCurrentImage();
        }
    }
}
