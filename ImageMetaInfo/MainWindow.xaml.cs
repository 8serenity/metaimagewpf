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
using System.IO;
using Microsoft.Win32;


//Создайте настраиваемый элемент управления,
//который будет воспроизводить изображение и автоматически извлекать
//из метаданных его имя, выводимое под изображением.

namespace ImageMetaInfo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            
            
        }

        private void clickedChange(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                image.Source = new BitmapImage(new Uri(op.FileName));
            }
            BitmapSource img = BitmapFrame.Create(new Uri(op.FileName));
            BitmapMetadata md = (BitmapMetadata)img.Metadata;

            metaText.Text += "Format: " + md.Format;
            metaText.Text += "\n" + "Date taken: " + md.DateTaken;
            metaText.Text += "\n" + "Location: " + md.Comment;



        }
    }
}
