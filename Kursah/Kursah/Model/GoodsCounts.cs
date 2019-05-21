using BaseMVVM.Abstraction;

using Kursah.ViewModel;

namespace Kursah.Model
{
    public class GoodsCounts : ViewModelBase
    {
        private bool _isSelected;
        
        public Goods Good { get; set; }
        public int Count { get; set; }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                
                OnPropertyChanged();
            }
        }

        public GoodsCounts(Goods good, int count)
        {
            Good = good;
            Count = count;
        }
    }
}
