using System.Collections.Generic;

using BaseMVVM.Abstraction;
using BaseMVVM.Command;

using Kursah.Model;

namespace Kursah.ViewModel
{
    public class InitializeVM : ViewModelBase
    {
        private int _maxDeliveryTideLocal;
        private int _KIFLocal;

        public static List<GoodsCounts> Counts { get; set; }
        public static int MaxDeliveryTide { get; set; }
        public static int KIF { get; set; }

        public int MaxDeliveryTideLocal
        {
            get => _maxDeliveryTideLocal;
            set
            {
                _maxDeliveryTideLocal = value;
                MaxDeliveryTide = value;

                OnPropertyChanged();
            }
        }
        public int KIFLocal
        {
            get => _KIFLocal;
            set
            {
                _KIFLocal = value;
                KIF = value;

                OnPropertyChanged();
            }
        }

        static InitializeVM()
        {
            List<GoodsCounts> tmpList = new List<GoodsCounts>();
            foreach (Goods good in kursahEntities.Instane.Goods)
            {
                tmpList.Add(new GoodsCounts(good, 0));
            }
            Counts = tmpList;
        }

        public static void Select()
        {
            if (Counts != null)
            {
                bool check = false;
                foreach (GoodsCounts item in Counts)
                {
                    if (item.IsSelected)
                        check = true;
                }
                if (check)
                    MainViewVM.CanContinue = true;                
                else
                    MainViewVM.CanContinue = false;

            }
        }
    }
}
