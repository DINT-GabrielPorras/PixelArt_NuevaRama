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
        Brush colorSeleccionado = Brushes.Black;
        int dimensionRejilla;
        
        public MainWindow()
        {
            InitializeComponent();       
        }

        private void DibujaRejilla(int dimension, Brush color)
        {
            rejilla.Children.Clear();

            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    Border bd = new Border();

                    bd.Style = (Style)this.Resources["bdRejilla"];
                    bd.Background = color;

                    rejilla.Children.Add(bd);
                }
            }
        }

        private void EstableceTamañoRejilla_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;

            switch (b.Tag.ToString())
            {
                case "Small":
                    dimensionRejilla = 10;
                    DibujaRejilla(dimensionRejilla, Brushes.White);
                    break;
                case "Middle":
                    dimensionRejilla = 25;
                    DibujaRejilla(dimensionRejilla, Brushes.White);
                    break;
                case "Big":
                    dimensionRejilla = 50;
                    DibujaRejilla(dimensionRejilla, Brushes.White);
                    break;
            }
        }

        private void celda_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ((Border)sender).Background = colorSeleccionado;
        }      

        private void celda_MouseEnter (object sender, EventArgs e)
        {
            if (System.Windows.Input.Mouse.LeftButton==MouseButtonState.Pressed)
            {
                (sender as Border).Background = colorSeleccionado;
            }         
        }       

        private void SeleccionaColor(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            if (rb.Tag.ToString() == "Personalized")
            {
                colorPersonalizadoTextBox.IsEnabled = true;
            }
            else
            {
                colorPersonalizadoTextBox.IsEnabled = false;
                colorPersonalizadoTextBox.Text = "";

                String color = rb.Tag.ToString();
                BrushConverter c1 = new BrushConverter();

                colorSeleccionado = (Brush)c1.ConvertFrom(color);
            }
        }

        private void SeleccionaColorPersonalizado(object sender, KeyEventArgs e)
        {
            BrushConverter c1 = new BrushConverter();
            TextBox t1 = (TextBox)sender;

            if (e.Key == Key.Enter)
            {
                try 
                { 
                    colorSeleccionado = (Brush)c1.ConvertFrom(t1.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("El color introducido no es válido");
                }
            }
        }

        private void PintaRejilla_Click(object sender, RoutedEventArgs e)
        {
            DibujaRejilla(dimensionRejilla, colorSeleccionado);
        }
    }
}
