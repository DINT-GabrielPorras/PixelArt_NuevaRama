﻿using System;
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

                    // Propiedades definidas en estilos XAML.
                    // bd.BorderBrush = Brushes.Gray;
                    // bd.BorderThickness = new Thickness(1);

                    bd.Style = (Style)this.Resources["bdRejilla"]; // Estilo definido en XAML.
                    rejilla.Children.Add(bd);
                }
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EstableceTamañoRejilla(10);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            EstableceTamañoRejilla(25);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            EstableceTamañoRejilla(50);
        }

        private void SeleccionaColor(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            if (rb.Tag.ToString() == "Personalized")
            {
                // Activamos el TextBox para poner el color en hexadecimal.
                colorPersonalizadoTextBox.IsEnabled = true;
            }
            else
            {
                // Mantenemos la caja de texto personalizada desactivada.
                colorPersonalizadoTextBox.IsEnabled = false;
                colorPersonalizadoTextBox.Text = "";

                // Hallar el color desde cadena
                String color = rb.Tag.ToString();
                BrushConverter c1 = new BrushConverter();

                colorSeleccionado = (Brush)c1.ConvertFrom(color);
            }
        }

        private void SeleccionaColorPersonalizado(object sender, KeyEventArgs e)
        {
            BrushConverter c1 = new BrushConverter();
            TextBox t1 = (TextBox)sender;

            if (e.Key == Key.Enter) // Se debe de pulsar ENTER.
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
     }
}
