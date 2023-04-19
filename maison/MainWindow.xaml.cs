using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace maison
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Point lastPoint;
        private Piece piece;

        public MainWindow()
        {
            InitializeComponent();
            AjouterGrille();
            piece = new Piece(canvas);
        }

        private void AjouterGrille()
        {
            // redessiner la grille lorsque la fenêtre est redimensionnée
            this.SizeChanged += (s, e) =>
            {
                canvas.Children.Clear();
                // dessiner des lignes horizontales
                for (int i = 0; i < (this.ActualHeight / 20); i++)
                {
                    Line line = new Line();
                    line.X1 = 0;
                    line.Y1 = i * 20;
                    line.X2 = canvas.ActualWidth;
                    line.Y2 = i * 20;
                    line.Stroke = Brushes.LightBlue;
                    line.StrokeThickness = 1;
                    canvas.Children.Add(line);
                }

                // dessiner des lignes verticales
                for (int i = 0; i < (this.ActualWidth / 20); i++)
                {
                    Line line = new Line();
                    line.X1 = i * 20;
                    line.Y1 = 0;
                    line.X2 = i * 20;
                    line.Y2 = canvas.ActualHeight;
                    line.Stroke = Brushes.LightBlue;
                    line.StrokeThickness = 1;
                    canvas.Children.Add(line);
                }
            };
        }

        /*private void MyControl_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                points[0].X = 0;
                points[0].Y = 0;
            }
        }*/

        // Bouton de la souris pressé
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            double x = Math.Round(e.GetPosition(canvas).X / 20.0) * 20.0;
            double y = Math.Round(e.GetPosition(canvas).Y / 20.0) * 20.0;
            piece.DessinCarre(x, y);
        }

    }
}