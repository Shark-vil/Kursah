using BaseMVVM.Abstraction;

using Kursah.Common;

namespace Kursah.Model
{
    /// <summary>
    /// Модель данных для Стадии_1_2
    /// </summary>
    public class Stage_1_2M : ViewModelBase
    {
        private bool _isSelected;

        public string Provider_name { get; set; }
        public string Good_name { get; set; }
        public string GoodPrice { get; set; }
        public string PaymentType { get; set; }
        public int PaymentDelay { get; set; }
        public int DeliveryTide { get; set; }
        public bool Bad { get; set; }


        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                if (_isSelected)
                {
                    SelectSecond(Provider_name);
                }
                else
                {
                    DeselectSecond(Provider_name);
                }

                OnPropertyChanged();
            }
        }

        public void Select(bool value)
        {
            _isSelected = value;
        }

        /// <summary>
        /// Выбор остальных товаров поставщика
        /// </summary>
        /// <param name="providerName">Наименование поставщика</param>
        public static void SelectSecond(string providerName)
        {
            foreach (Stage_1_2M item in Lists.MainWindow.Stage_1_2_Context.Stage_1_2_Data.FindAll(item => item.Provider_name == providerName))
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
            foreach (Stage_1_2M item in Lists.MainWindow.Stage_1_2_Context.Stage_1_2_Data.FindAll(item => item.Provider_name == providerName))
            {
                if (item.IsSelected)
                    item.Select(false);
            }
        }
    }
}
