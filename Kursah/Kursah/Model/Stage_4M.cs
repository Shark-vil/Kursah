using BaseMVVM.Abstraction;


namespace Kursah.Model
{
    public class Stage_4M : ViewModelBase
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
