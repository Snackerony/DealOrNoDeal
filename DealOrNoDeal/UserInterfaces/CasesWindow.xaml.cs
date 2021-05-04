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
        }
        float casePercentage = 0.4f;
        int casesLeft;

        bool selectCase = true;

        List<Case> caseList = new List<Case>();

        public void FillCases(List<int> intList)
        {
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
                    caseGrid.ColumnDefinitions.Add(new ColumnDefinition() { MaxWidth = 75, MinWidth = 75 });
                }
                if (column == 0)
                {
                    caseGrid.RowDefinitions.Add(new RowDefinition() { MaxHeight = 75, MinHeight = 75 });
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
        }

        private void FillGrid()
        {
            caseGrid.Children.Clear();
            foreach (var item in caseList)
            {
                if (!item.IsSelected && !item.IsOpen)
                    caseGrid.Children.Add(GenerateLabel(item));
            }

        }

        private Label GenerateLabel(Case selectedCase)
        {
            Label label = new Label()
            {
                Content = selectedCase.Counter,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            label.MouseLeftButtonDown += (sender, e) =>
            {
                if(selectCase == true)
                {
                    selectedCase.IsSelected = true;
                    selectCase = false;
                    headerText.Content = $"Wähle Koffer zum Öffnen aus. Ausgewählter Koffer #{selectedCase.Counter}";
                    FillGrid();

                }
                else
                {
                    selectedCase.IsOpen = true;
                    label.Content = selectedCase.MoneyReadable;
                    casesLeft--;
                    if(casesLeft == 0)
                    {
                        casesLeft = (int)(caseList.FindAll(m => !m.IsOpen && !m.IsSelected).Count * casePercentage);
                        FillGrid();
                    }
                }
            };
            Grid.SetColumn(label, selectedCase.Column);
            Grid.SetRow(label, selectedCase.Row);
            return label;
        }
    }
}
