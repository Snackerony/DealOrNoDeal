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
    /// Interaktionslogik für OptionsMenu.xaml
    /// </summary>
    public partial class OptionsMenu : UserControl
    {
        public OptionsMenu()
        {
            InitializeComponent();
        }

        public event EventHandler<ListEventArgs<int>> BackSelected;

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(moneyText.Text))
            {
                moneyText.Text = "1-25";
            }
            CheckTextBox();
        }

        private void CheckTextBox()
        {
            string[] texts = moneyText.Text.Replace(" ","").Split(',');
            List<int> moneySelected = new List<int>();
            for (int i = 0; i < texts.Length; i++)
            {
                if (texts[i].Contains("-"))
                {
                    string[] splittedString = texts[i].Split('-');
                    int firstNumber, secondNumber = 0;
                    if(splittedString.Length == 2 && int.TryParse(splittedString[0], out firstNumber) &&
                        int.TryParse(splittedString[1], out secondNumber) && firstNumber <= secondNumber)
                    {
                        for (int j = firstNumber; j <= secondNumber; j++)
                        {
                            if (!moneySelected.Contains(j))
                            {
                                moneySelected.Add(j);
                            }
                        }
                    }
                    else
                    {
                        ErrorHandling();
                        return;
                    }
                }
                else
                {
                    int number = 0;
                    if(int.TryParse(texts[i], out number))
                    {
                        if (!moneySelected.Contains(number))
                        {
                            moneySelected.Add(number);
                        }
                    }
                    else
                    {
                        ErrorHandling();
                        return;
                    }
                }
            }
            moneyText.BorderBrush = Brushes.Black;
            BackSelected?.Invoke(this, new ListEventArgs<int>() { list = moneySelected });
        }

        private void ErrorHandling()
        {
            moneyText.BorderBrush = Brushes.Red;
        }
    }
}
