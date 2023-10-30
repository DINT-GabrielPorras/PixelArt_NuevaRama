using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PixelArt
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

        public void EstableceTamañoRejilla(int dimension)
        {
            rejilla.Children.Clear();

            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    Border bd = new Border();
                    bd.BorderBrush = Brushes.Gray;
                    bd.BorderThickness = new Thickness(1);
                    rejilla.Children.Add(bd);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EstableceTamañoRejilla(25);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            EstableceTamañoRejilla(50);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            EstableceTamañoRejilla(75);
        }
    }
}
