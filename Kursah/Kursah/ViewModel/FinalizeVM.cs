using Kursah.Common;
using Kursah.Model;

using BaseMVVM.Command;
using BaseMVVM.Abstraction;

using System.Collections.Generic;
using System;

namespace Kursah.ViewModel
{
    public class FinalizeVM : ViewModelBase
    {
        private double _stage_1_1MinLocal;
        private double _stage_1_2MinLocal;
        private double _stage_2MinLocal;
        private double _stage_3MinLocal;
        private double _stage_4MinLocal;


        public double Stage_1_1MinLocal
        {
            get => _stage_1_1MinLocal;
            set
            {
                _stage_1_1MinLocal = value;

                OnPropertyChanged();
            }
        }
        public double Stage_1_2MinLocal
        {
            get => _stage_1_2MinLocal;
            set
            {
                _stage_1_2MinLocal = value;

                OnPropertyChanged();
            }
        }
        public double Stage_2MinLocal
        {
            get => _stage_2MinLocal;
            set
            {
                _stage_2MinLocal = value;

                OnPropertyChanged();
            }
        }
        public double Stage_3MinLocal
        {
            get => _stage_3MinLocal;
            set
            {
                _stage_3MinLocal = value;

                OnPropertyChanged();
            }
        }
        public double Stage_4MinLocal
        {
            get => _stage_4MinLocal;
            set
            {
                _stage_4MinLocal = value;

                OnPropertyChanged();
            }
        }

        public SimpleCommand Refresh { get; set; }

        public FinalizeVM()
        {
            Refresh = new SimpleCommand(() =>
            {
                Stage_1_1MinLocal = SmallestTotal.Stage_1_1Min;
                Stage_1_2MinLocal = SmallestTotal.Stage_1_2Min;
                Stage_2MinLocal = SmallestTotal.Stage_2Min;
                Stage_3MinLocal = SmallestTotal.Stage_3Min;
                Stage_4MinLocal = SmallestTotal.Stage_4Min;
            });
        }
    }
}
