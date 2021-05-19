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
    /// Interaktionslogik für CasesWindow.xaml
    /// </summary>
    public partial class CasesWindow : UserControl
    {
        public CasesWindow()
        {
            InitializeComponent();
            dealWindow.NoDealPressed += DealWindow_NoDealPressed;
            dealWindow.DealPressed += DealWindow_DealPressed;
        }

        private void DealWindow_DealPressed(object sender, StringEventArgs e)
        {
            switchCaseWindow.Visibility = Visibility.Visible;
            caseWindow.Visibility = Visibility.Collapsed;
            dealWindow.Visibility = Visibility.Collapsed;
            switchCaseWindow.DealAccepted(e.price);
        }

        private void DealWindow_NoDealPressed(object sender, EventArgs e)
        {
            dealWindow.Visibility = Visibility.Collapsed;
            caseWindow.Visibility = Visibility.Visible;
        }

        float casePercentage = 0.5f;
        private int _casesLeft = 0;
        int casesLeft
        {
            get
            {
                return _casesLeft;
            }
            set
            {
                _casesLeft = value;
                counterText.Content = $"Koffer: {value}";
            }
        }

        bool selectCase = true;

        List<Case> caseList = new List<Case>();

        public void FillCases(List<int> intList)
        {
            intList = ShuffleList(intList);
            selectCase = true;
            caseList.Clear();
            caseGrid.Children.Clear();
            caseGrid.RowDefinitions.Clear();
            caseGrid.ColumnDefinitions.Clear();
            int counter = 0;
            int columnCount = (int)Math.Ceiling(Math.Sqrt(intList.Count));
            int column;
            int row;
            foreach (var item in intList)
            {
                column = counter % columnCount;
                row = counter / columnCount;
                if (row == 0)
                {
                    caseGrid.ColumnDefinitions.Add(new ColumnDefinition() { MaxWidth = 200, MinWidth = 200 });
                }
                if (column == 0)
                {
                    caseGrid.RowDefinitions.Add(new RowDefinition() { MaxHeight = 200, MinHeight = 200 });
                }
                Case box = new Case()
                {
                    IsOpen = false,
                    Column = column,
                    Row = row,
                    IsSelected = false,
                    Money = item,
                    Counter = counter + 1
                };
                caseList.Add(box);

                counter++;
            }
            casesLeft = (int)(caseList.FindAll(m => !m.IsOpen && !m.IsSelected).Count * casePercentage);
            FillGrid();
            FillListGrid();
        }

        private List<int> ShuffleList(List<int> intList)
        {
            List<int> shuffledList = new List<int>();
            Random ran = new Random();
            while (intList.Count > 0)
            {
                int nextInt = ran.Next(0, intList.Count);
                shuffledList.Add(intList[nextInt]);
                intList.RemoveAt(nextInt);
            }
            return shuffledList;
        }

        private void FillGrid()
        {
            caseGrid.Children.Clear();
            foreach (var item in caseList)
            {
                if (!item.IsSelected && !item.IsOpen)
                    caseGrid.Children.Add(GenerateGrid(item));
            }

        }

        private Grid GenerateGrid(Case selectedCase)
        {
            Grid grid = new Grid();
            Image img = new Image()
            {
                Height = 200,
                Width = 200,
                Source = new BitmapImage(new Uri(@"\Icons\koffer_zu.png", UriKind.Relative))
            };
            TextBlock textNumber = new TextBlock()
            {
                Foreground = Brushes.White,
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 0, 0, 18),
                Text = selectedCase.Counter.ToString(),
                FontSize = 24
            };
            TextBlock textMoney = new TextBlock()
            {
                Foreground = Brushes.White,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 0, 0, 30),
                Text = selectedCase.MoneyReadable.ToString(),
                FontSize = 24,
                Visibility = Visibility.Collapsed
            };
            grid.MouseLeftButtonDown += (sender, e) =>
            {
                if (selectCase == true)
                {
                    selectedCase.IsSelected = true;
                    selectCase = false;
                    headerText.Content = $"Wähle Koffer zum Öffnen aus. Ausgewählter Koffer #{selectedCase.Counter}";
                    FillGrid();

                }
                else
                {
                    selectedCase.IsOpen = true;
                    img.Source = new BitmapImage(new Uri(@"\Icons\koffer_offen.png", UriKind.Relative));
                    textMoney.Visibility = Visibility.Visible;
                    //label.Content = selectedCase.MoneyReadable;
                    casesLeft--;
                    FillListGrid();
                    if (casesLeft == 0)
                    {
                        if (caseList.FindAll(m => m.IsSelected || !m.IsOpen).Count > 2)
                        {
                            caseWindow.Visibility = Visibility.Collapsed;
                            dealWindow.Visibility = Visibility.Visible;
                            dealWindow.Refresh(caseList);
                            casesLeft = (int)(caseList.FindAll(m => !m.IsOpen && !m.IsSelected).Count * casePercentage);
                            FillGrid();
                        }
                        else
                        {
                            switchCaseWindow.Visibility = Visibility.Visible;
                            caseWindow.Visibility = Visibility.Collapsed;
                            switchCaseWindow.Refresh(caseList.FindAll(m => m.IsSelected || !m.IsOpen));
                        }


                    }
                }
            };
            grid.Children.Add(img);
            grid.Children.Add(textNumber);
            grid.Children.Add(textMoney);
            Grid.SetColumn(grid, selectedCase.Column);
            Grid.SetRow(grid, selectedCase.Row);
            return grid;
        }

        private void FillListGrid()
        {
            caseList.Sort((m, n) => m.Money.CompareTo(n.Money));
            listGrid.RowDefinitions.Clear();
            listGrid.Children.Clear();
            int column = 0;
            int row = 0;
            foreach (var item in caseList)
            {
                if (column == 0)
                {
                    listGrid.RowDefinitions.Add(new RowDefinition()
                    {
                        MaxHeight = 50,
                        MinHeight = 50
                    });
                }
                listGrid.Children.Add(GenerateLabel(item, row, column));
                if (column == 0)
                {
                    column++;
                }
                else
                {
                    column = 0;
                    row++;
                }
            }
        }

        private Grid GenerateLabel(Case myCase, int row, int column)
        {

            Grid grid = new Grid()
            {
                Margin = new Thickness(5)
            };
            Image img = new Image()
            {
                Height = 50
            };
            Label lbl = new Label()
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Foreground = Brushes.White,
                Content = myCase.MoneyReadable
            };
            if (myCase.IsOpen)
            {
                img.Source = new BitmapImage(new Uri(@"\Icons\button_off.png", UriKind.Relative));
            }
            else
            {
                img.Source = new BitmapImage(new Uri(@"\Icons\button.png", UriKind.Relative));
            }
            grid.Children.Add(img);
            grid.Children.Add(lbl);
            Grid.SetColumn(grid, column);
            Grid.SetRow(grid, row);
            return grid;
        }
    }
}
