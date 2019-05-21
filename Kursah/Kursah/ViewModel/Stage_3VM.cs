﻿using Kursah.Common;
using Kursah.Model;

using BaseMVVM.Command;
using BaseMVVM.Abstraction;

using System.Collections.Generic;
using System;

namespace Kursah.ViewModel
{
    public class Stage_3VM : ViewModelBase
    {
        public static List<Stage_3M> Stage_3_Data { get; set; }
        public SimpleCommand MathTotal { get; set; }

        private string _total;
        private string _error;

        public string Total
        {
            get => _total;
            set
            {
                _total = value;

                OnPropertyChanged();
            }
        }
        public string Error
        {
            get => _error;
            set
            {
                _error = value;

                OnPropertyChanged();
            }
        }

        public Stage_3VM()
        {
            Error = Errors.Normal;
            Total = "";

            Stage_3_Data = kursahEntities.Instane.Database.SqlQuery<Stage_3M>(Queries.Stage_3Querry).ToListAsync().Result;

            MathTotal = new SimpleCommand(() =>
            {
                double summ = 0;
                int count = InitializeVM.Counts.Count;

                foreach (Stage_3M value in Stage_3_Data.FindAll(item => item.IsSelected))
                    summ += value.GoodPrice;

                if (summ == 0)
                {
                    Total = "";
                    Error = "Не выбран ни один элемент списка";
                    return;
                }

                double result = summ / count;

                SmallestTotal.Stage_3Min = result;

                Total = result.ToString();
            });
        }
    }
}
