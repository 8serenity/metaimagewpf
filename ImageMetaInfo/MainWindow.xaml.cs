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

            MetaCustomData infoImage = new MetaCustomData();

            var fullFilePath = @"C:\Users\Мухамедьян\Downloads\1.jpg";


            using (FileStream fileStream = new FileStream(fullFilePath, FileMode.Open, FileAccess.Read))
            {
                BitmapFrame bitmapFrame = BitmapFrame.Create(fileStream, BitmapCreateOptions.DelayCreation, BitmapCacheOption.None);
                BitmapMetadata bitmapMetadata = bitmapFrame.Metadata as BitmapMetadata;


                MessageBox.Show(bitmapMetadata.Format);



            }
        }
    }
}
