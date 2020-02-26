using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Puzzle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Image swap;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Handle_DragImage(object sender, MouseButtonEventArgs e)
        {
            Image image = (Image)e.Source;
            swap = image;
            DataObject data = new DataObject(typeof(ImageSource), image.Source);
            DragDrop.DoDragDrop(image, data, DragDropEffects.Move);
        }

        private void Handle_DropImage(object sender, DragEventArgs e)
        {
            ImageSource image = (ImageSource)e.Data.GetData(typeof(ImageSource));
            Image dropTarget = (Image)sender;
            swap.Source = dropTarget.Source;
            dropTarget.Source = image;
        }
    }
}