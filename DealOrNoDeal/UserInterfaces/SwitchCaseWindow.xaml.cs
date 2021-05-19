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

namespace DealOrNoDeal.UserInterfaces
{
    /// <summary>
    /// Interaktionslogik für SwitchCaseWindow.xaml
    /// </summary>
    public partial class SwitchCaseWindow : UserControl
    {
        public SwitchCaseWindow()
        {
            InitializeComponent();
        }

        private List<Case> caseList;

        public void Refresh(List<Case> cases)
        {
            cases.Sort((m, n) => m.Counter.CompareTo(n.Counter));
            firstCaseText.Text = cases.First().Counter.ToString();
            secondCaseText.Text = cases.Last().Counter.ToString();
            caseList = cases;
        }

        public void DealAccepted(string dealPrice)
        {
            firstCaseImage.Source = new BitmapImage(new Uri(@"\Icons\koffer_angebot_offen.png", UriKind.Relative));
            firstMoneyText.Text = dealPrice;
            firstCaseGrid.MouseLeftButtonDown -= firstCaseGrid_MouseLeftButtonDown;
            Grid.SetColumnSpan(firstCaseGrid, 2);
            Grid.SetColumn(firstCaseGrid, 0);
            secondCaseGrid.Visibility = Visibility.Collapsed;
        }

        private void secondCaseGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            secondCaseImage.Source = new BitmapImage(new Uri(@"\Icons\koffer_angebot_offen.png", UriKind.Relative));
            secondMoneyText.Text = caseList.Last().MoneyReadable;
            Grid.SetColumnSpan(secondCaseGrid, 2);
            Grid.SetColumn(secondCaseGrid, 0);
            firstCaseGrid.Visibility = Visibility.Collapsed;
        }

        private void firstCaseGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            firstCaseImage.Source = new BitmapImage(new Uri(@"\Icons\koffer_angebot_offen.png", UriKind.Relative));
            firstMoneyText.Text = caseList.First().MoneyReadable;
            Grid.SetColumnSpan(firstCaseGrid, 2);
            Grid.SetColumn(firstCaseGrid, 0);
            secondCaseGrid.Visibility = Visibility.Collapsed;
        }
    }
}
