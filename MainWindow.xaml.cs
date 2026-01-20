using System.Windows;
using System.Windows.Controls;

namespace SimpleTicTacToe
{
    public partial class MainWindow : Window
    {
        private bool isNextO = true; // true = следующий будет нолик, false = следующий будет крестик

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Cell_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

           
            if (button.Content != null && button.Content.ToString() != "")
                return;

         
            if (isNextO)
            {
                button.Content = "O";
                button.Foreground = System.Windows.Media.Brushes.Blue;
                isNextO = false;
            }
            else
            {
                button.Content = "X";
                button.Foreground = System.Windows.Media.Brushes.Red;
                isNextO = true;
            }
        }
    }
}