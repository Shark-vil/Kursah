using BaseMVVM.Abstraction;

namespace Kursah.Model
{
    public class Stage_3M : ViewModelBase
    {
        private bool _isSelected;

        public string GoodName { get; set; }
        public double Price { get; set; }

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
