using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace maison
{
    internal class Piece
    {
        public Point[] Points { get; private set; }
        public Canvas Canvas { get; private set; }

        public Piece(Canvas canvas)
        {
            Points = new Point[4];
            InitializePoints();
            Canvas = canvas;
        }

        public void InitializePoints()
        {
            for (int i = 0; i < Points.Length; i++)
            {
                Points[i] = new Point(0, 0);
            }
        }

        public void DessinCarre(double x, double y)
        {
            // Si c'est la première fois que l'on appuie
            if (Points[0].X == 0 && Points[0].Y == 0)
            {
                Points[0].X = x;
                Points[0].Y = y;
                creerRond(Points[0].X, Points[0].Y);
            }
            else // Si ce n'est pas la première fois
            {
                creerRond(x, y);
                creerRond(Points[0].X, y);
                creerRond(x, Points[0].Y);

                Points[1] = new Point(Points[0].X, y);
                Points[2] = new Point(x, Points[0].Y);
                Points[3] = new Point(x, y);

                Canvas.Children.Add(creerLine(Points[0], Points[1]));
                Canvas.Children.Add(creerLine(Points[1], Points[3]));
                Canvas.Children.Add(creerLine(Points[3], Points[2]));
                Canvas.Children.Add(creerLine(Points[2], Points[0]));

                InitializePoints();
            }
        }
        private Line creerLine(Point point1, Point point2)
        {
            Line line = new Line
            {
                Stroke = Brushes.Black,
                X1 = point1.X,
                Y1 = point1.Y,
                X2 = point2.X,
                Y2 = point2.Y
            };
            return line;
        }

        private void creerRond(double x, double y)
        {
            Ellipse circle = new Ellipse
            {
                Width = 10,
                Height = 10,
                Fill = Brushes.LightBlue,
                Stroke = Brushes.Black
            };
            Canvas.SetLeft(circle, x - circle.Width / 2);
            Canvas.SetTop(circle, y - circle.Height / 2);
            Canvas.Children.Add(circle);
        }
    }
}
