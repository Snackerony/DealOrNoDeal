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
    /// Interaktionslogik für DealWindow.xaml
    /// </summary>
    public partial class DealWindow : UserControl
    {
        public DealWindow()
        {
            InitializeComponent();
        }

        private string finalPriceString;
        public event EventHandler NoDealPressed;
        public event EventHandler<StringEventArgs> DealPressed;

        public void Refresh(List<Case> caseList)
        {
            int counter = 0;
            int money = 0;
            int maxMoney = 0;
            foreach (var item in caseList)
            {
                if (!item.IsOpen)
                {
                    money += item.Money;
                    counter++;
                    if (maxMoney < item.Money)
                    {
                        maxMoney = item.Money;
                    }
                }
            }
            float finalPrice = (money / counter);
            finalPrice += (maxMoney - finalPrice) * 0.2f;
            finalPriceString = finalPrice.ToString("0.00") + "€";
            moneyText.Text = finalPriceString;
        }

        private void noDealButton_Click(object sender, RoutedEventArgs e)
        {
            NoDealPressed?.Invoke(this, null);
        }

        private void dealButton_Click(object sender, RoutedEventArgs e)
        {
            DealPressed?.Invoke(this, new StringEventArgs() { price = finalPriceString });
        }
    }
}
