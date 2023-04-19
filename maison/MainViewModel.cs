using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace maison
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Piece piece;
        public Piece Piece
        {
            get { return piece; }
            set
            {
                piece = value;
                OnPropertyChanged("Piece");
            }
        }
        public MainViewModel(Canvas canvas)
        {
            Piece = new Piece(canvas);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void DessinCarre(double x, double y)
        {
            Piece.DessinCarre(x, y);
        }
    }
}
