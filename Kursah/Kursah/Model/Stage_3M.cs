using BaseMVVM.Abstraction;

namespace Kursah.Model
{
    /// <summary>
    /// Модель данных для Стадии_3
    /// </summary>
    public class Stage_3M : ViewModelBase
    {
        private bool _isSelected;

        public string GoodName { get; set; }
        public double GoodPrice { get; set; }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;

                OnPropertyChanged();
            }
        }
    }
}
