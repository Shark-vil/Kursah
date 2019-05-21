using BaseMVVM.Abstraction;

using Kursah.ViewModel;
using Kursah.Common;

namespace Kursah.Model
{
    /// <summary>
    /// Модель данных для Стадии_1_1
    /// </summary>
    public class Stage_1_1M : ViewModelBase
    {
        private bool _isSelected;

        public string Provider_name { get; set; }
        public string Good_name { get; set; }
        public string GoodPrice { get; set; }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;

                if (_isSelected)
                    SelectSecond(Provider_name);
                else
                    DeselectSecond(Provider_name);                

                OnPropertyChanged();
            }
        }

        public void Select(bool value)
        {
            _isSelected = value;
        }

        public override string ToString()
        {
            return string.Concat(Provider_name, " ", Good_name, " ", GoodPrice);
        }

        /// <summary>
        /// Выбор остальных товаров поставщика
        /// </summary>
        /// <param name="providerName">Наименование поставщика</param>
        public static void SelectSecond(string providerName)
        {
            foreach (Stage_1_1M item in Lists.MainWindow.Stage_1_1_Context.Stage_1_1_Data.FindAll(item => item.Provider_name == providerName))
            {
                if (!item.IsSelected)
                    item.Select(true);
            }
        }

        /// <summary>
        /// ОТмена выбора остальных товаров поставщика
        /// </summary>
        /// <param name="providerName">Наименование поставщика</param>
        public static void DeselectSecond(string providerName)
        {
            foreach (Stage_1_1M item in Lists.MainWindow.Stage_1_1_Context.Stage_1_1_Data.FindAll(item => item.Provider_name == providerName))
            {
                if (item.IsSelected)
                    item.Select(false);
            }
        }
    }
}
