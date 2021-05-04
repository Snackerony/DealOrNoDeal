using DealOrNoDeal.Classes;
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

namespace DealOrNoDeal
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<int> moneySelected = new List<int>();
        public MainWindow()
        {
            InitializeComponent();
            AddEventHandler();
            for (int i = 1; i <= 25; i++)
            {
                moneySelected.Add(i);
            }
        }

        private void AddEventHandler()
        {
            mainMenuWindow.OptionsSelected += MainMenuWindow_OptionsSelected;
            mainMenuWindow.PlaySelected += MainMenuWindow_PlaySelected;

            optionsMenuWindow.BackSelected += OptionsMenuWindow_BackSelected;
        }

        private void MainMenuWindow_PlaySelected(object sender, EventArgs e)
        {
            casesWindow.FillCases(moneySelected);
            mainMenuWindow.Visibility = Visibility.Collapsed;
            casesWindow.Visibility = Visibility.Visible;
        }

        private void MainMenuWindow_OptionsSelected(object sender, EventArgs e)
        {
            mainMenuWindow.Visibility = Visibility.Collapsed;
            optionsMenuWindow.Visibility = Visibility.Visible;
        }

        private void OptionsMenuWindow_BackSelected(object sender, ListEventArgs<int> e)
        {
            moneySelected = e.list;
            mainMenuWindow.Visibility = Visibility.Visible;
            optionsMenuWindow.Visibility = Visibility.Collapsed;
        }

    }
}
