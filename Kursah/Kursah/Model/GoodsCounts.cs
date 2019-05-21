using BaseMVVM.Abstraction;

namespace Kursah.Model
{
    /// <summary>
    /// Модель данных. Содержит товар и его количество.
    /// </summary>
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
