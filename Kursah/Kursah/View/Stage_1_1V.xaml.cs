using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Kursah.Model;
using Kursah.ViewModel;

namespace Kursah.View
{
    /// <summary>
    /// Логика взаимодействия для Stage_1_1.xaml
    /// </summary>
    public partial class Stage_1_1V : UserControl
    {
        public Stage_1_1V()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = (DataGrid)sender;

            List<Stage_1_1M> second = new List<Stage_1_1M>();

            for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
            {
                Stage_1_1M row = (Stage_1_1M)dataGrid.SelectedItems[i];

                foreach (Stage_1_1M item in Stage_1_1VM.Stage_1_1_Data.FindAll(item => item.Provider_name == row.Provider_name))
                {
                    if (!second.Contains(item))
                    {
                        second.Add(item);
                        item.Select(true);
                    }           
                }
            }

            foreach (Stage_1_1M item in second)
            {
                dataGrid.SelectedItems.Add(item);
            }

        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
            //for (int i = 0; i < Stage_1_1DataGrid.SelectedItems.Count; i++)
            //{
            //    Stage_1_1M row = (Stage_1_1M)Stage_1_1DataGrid.SelectedItems[i];
            //    int providerTotal = 0;
            //    foreach (Stage_1_1M item in Stage_1_1DataGrid.SelectedItems.(item => item.Good_name == row.Good_name))
            //    {
            //        providerTotal += int.Parse(item.GoodPrice);
            //    }
                
            //}
        }
    }
}
