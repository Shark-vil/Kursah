﻿using BaseMVVM.Abstraction;

using Kursah.ViewModel;

namespace Kursah.Model
{
    public class Stage_1_2M : ViewModelBase
    {
        private bool _isSelected;

        public string Provider_name { get; set; }
        public string Good_name { get; set; }
        public string GoodPrice { get; set; }
        public string PaymentType { get; set; }
        public int PaymentDelay { get; set; }
        public int DeliveryTide { get; set; }
        public bool Bad { get; set; }


        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                if (_isSelected)
                {
                    Stage_1_1VM.SelectSecond(Provider_name);
                }
                else
                {
                    Stage_1_1VM.DeselectSecond(Provider_name);
                }

                OnPropertyChanged();
            }
        }

        public void Select(bool value)
        {
            _isSelected = value;
        }
    }
}