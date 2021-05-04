using System;
using System.Collections.Generic;
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

namespace DealOrNoDeal.UserInterfaces
{
    /// <summary>
    /// Interaktionslogik für MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        public event EventHandler OptionsSelected;
        public event EventHandler PlaySelected;

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            PlaySelected?.Invoke(this, null);
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void optionButton_Click(object sender, RoutedEventArgs e)
        {
            OptionsSelected?.Invoke(this, null);
        }
    }
}
