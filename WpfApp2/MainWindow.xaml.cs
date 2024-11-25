using ImageMagick;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //var image = new List<(BitmapSource image, int delay)>();
            //using var collection = new MagickImageCollection("Wait.gif");
            //collection.Coalesce();
            //foreach (var magickImage in collection)
            //{
            //    if (magickImage.AnimationDelay == 0)
            //    {
            //        image.Add((magickImage.ToBitmapSource(), 0x0a * 10));//不含帧时长的情况下默认一个
            //    }
            //    else
            //    {
            //        image.Add((magickImage.ToBitmapSource(), (int)magickImage.AnimationDelay * 10));
            //    }
            //};
            ////----------
            _ = Task.Run(async () =>
            {
                //-----------注释此段代码并取消注释前面的代码则可以正常显示
                var image = new List<(BitmapSource image, int delay)>();
                using var collection = new MagickImageCollection("Wait.gif");
                collection.Coalesce();
                foreach (var magickImage in collection)
                {
                    if (magickImage.AnimationDelay == 0)
                    {
                        image.Add((magickImage.ToBitmapSource(), 0x0a * 10));
                    }
                    else
                    {
                        image.Add((magickImage.ToBitmapSource(), (int)magickImage.AnimationDelay * 10));
                    }
                };
                //-----------



                int n = 0;
                while (true)
                {
                    await Dispatcher.InvokeAsync(() => { G.Source = image[n].image; });
                    n++;
                    if (n == image.Count)
                    {
                        n = 0;
                    }

                    await Task.Delay(image[n].delay);
                }
            });
        }
    }
}