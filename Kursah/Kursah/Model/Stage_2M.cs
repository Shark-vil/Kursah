using System;

using BaseMVVM.Abstraction;

namespace Kursah.Model
{
    public class Stage_2M : ViewModelBase
    {
        private double _iPC;
        private double _priceNew;
        private double _priceNewPerOne;
        private double _priceOldPerOne;
        private double _priceOld;

        public string OfferName { get; set; }
        public DateTime DateComplete { get; set; }
        public string GoodName { get; set; }
        public int Count { get; set; }
        public double PriceOld
        {
            get => _priceOld;
            set
            {
                _priceOld = value;

                OnPropertyChanged();
            }
        }
        public double PriceOldPerOne
        {
            get => _priceOldPerOne;
            set
            {
                _priceOldPerOne = value;

                OnPropertyChanged();
            }
        }
        public double PriceNewPerOne
        {
            get => _priceNewPerOne;
            set
            {
                _priceNewPerOne = value;

                OnPropertyChanged();
            }
        }
        public double PriceNew
        {
            get => _priceNew;
            set
            {
                _priceNew = value;

                OnPropertyChanged();
            }
        }

        public double IPC { get => 1; set => _iPC = value; }
    }
}
