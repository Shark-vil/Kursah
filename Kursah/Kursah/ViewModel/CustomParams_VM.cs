using System.Collections.Generic;
using System.Windows;
using BaseMVVM.Abstraction;
using BaseMVVM.Command;

using Kursah.Model;


namespace Kursah.ViewModel
{
    public class CustomParams_VM : ViewModelBase
    {
        public SimpleCommand AddClick_InitData { get; set; }
        private string _Add_DataGrid_Initializate_Name { get; set; }
        private int _Add_DataGrid_Initializate_Count { get; set; }

        public string Add_DataGrid_Initializate_Name
        {
            get => _Add_DataGrid_Initializate_Name;
            set
            {
                _Add_DataGrid_Initializate_Name = value;

                OnPropertyChanged();
            }
        }
        public int Add_DataGrid_Initializate_Count
        {
            get => _Add_DataGrid_Initializate_Count;
            set
            {
                _Add_DataGrid_Initializate_Count = value;

                OnPropertyChanged();
            }
        }

        public CustomParams_VM()
        {
            AddClick_InitData = new SimpleCommand(() =>
            {
                if (_Add_DataGrid_Initializate_Name != null &&
                    _Add_DataGrid_Initializate_Name.Length != 0 && _Add_DataGrid_Initializate_Count != 0)
                {
                    MessageBox.Show((InitializeVM.Counts[InitializeVM.Counts.Count - 1].Good.id + 1).ToString());
                    MessageBox.Show(_Add_DataGrid_Initializate_Name);
                    MessageBox.Show(_Add_DataGrid_Initializate_Count.ToString());

                    InitializeVM.Counts.Add(new GoodsCounts(new Goods {
                        id = InitializeVM.Counts[InitializeVM.Counts.Count - 1].Good.id + 1,
                        name = _Add_DataGrid_Initializate_Name }, _Add_DataGrid_Initializate_Count
                    ));
                }
            });
        }
    }
}
