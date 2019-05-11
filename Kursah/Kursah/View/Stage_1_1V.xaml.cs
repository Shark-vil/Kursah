using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            Stage_1_1M row = (Stage_1_1M)dataGrid.SelectedItem;
            List<Stage_1_1M> second = Stage_1_1VM.Stage_1_1_Data.FindAll(item=>item.Provider_name == row.Provider_name);
            foreach (Stage_1_1M item in second)
            {
                dataGrid.SelectedItems.Add(item);
            }        

        }
    }
}
