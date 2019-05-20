using System;

using BaseMVVM.Abstraction;

using Kursah.ViewModel;

namespace Kursah.Model
{
    public class Stage_2M : ViewModelBase
    {
        private double _iPC;

        public string OfferName { get; set; }
        public DateTime DateComplete { get; set; }
        public string GoodName { get; set; }
        public int Count { get; set; }
        public double PriceOld { get; set; }
        public double PriceOldPerOne { get; set; }
        public double PriceNewPerOne { get; set; }
        public double PriceNew { get; set; }
        public double IPC { get => 1; set => _iPC = value; }
    }
}
