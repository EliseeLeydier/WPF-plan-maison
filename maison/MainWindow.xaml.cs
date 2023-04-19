using System;
using System.Windows;
using System.Windows.Input;

namespace maison
{
    public partial class MainWindow : Window
    {
        private MainViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();

            viewModel = new MainViewModel(myCanvas);
            DataContext = viewModel;
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (myCanvas.IsMouseOver)
            {
                double x = Math.Round(e.GetPosition(myCanvas).X / 20.0) * 20.0;
            double y = Math.Round(e.GetPosition(myCanvas).Y / 20.0) * 20.0;
            viewModel.DessinCarre(x, y);
            }
        }
    }
}
