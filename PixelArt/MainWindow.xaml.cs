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
        Brush colorSeleccionado = Brushes.White;
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
                    bd.Style = (Style)this.Resources["bdRejilla"]; 
                    rejilla.Children.Add(bd);
                }
            }
        }
        
        private void celda_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ((Border)sender).Background = colorSeleccionado;
        }      

        private void celda_Enter (object sender, EventArgs e)
        {
            if (System.Windows.Input.Mouse.LeftButton==MouseButtonState.Pressed)
            {
                (sender as Border).Background = colorSeleccionado;
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

        private void SeleccionaColor(object sender, RoutedEventArgs e)
        {
            String color = (sender as RadioButton).Tag.ToString();
            BrushConverter c1 = new BrushConverter();

            colorSeleccionado = (Brush)c1.ConvertFrom(color);
        }
    }
}
