using System;

using BaseMVVM.Abstraction;

using Kursah.ViewModel;

namespace Kursah.Model
{
    public class Stage_2M : ViewModelBase
    {
        public string OfferName { get; set; }
        public DateTime DateComplete { get; set; }
        public string GoodName { get; set; }
        public int Count { get; set; }
        public double PriceOld { get; set; }
        public double PriceOldPerOne { get; set; }
        public double PriceNewPerOne { get; set; }
        public double PriceNew { get; set; }
        public double IPC { get; set; }
    }
}
