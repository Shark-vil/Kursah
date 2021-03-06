﻿using Kursah.Common;
using Kursah.Model;

using BaseMVVM.Command;
using BaseMVVM.Abstraction;

using System.Collections.Generic;

namespace Kursah.ViewModel
{
    /// <summary>
    /// Класс для взаимодейтвия данных и отображения Стадии_3.
    /// </summary>
    public class Stage_3VM : ViewModelBase
    {
        public List<Stage_3M> Stage_3_Data { get; set; }
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
                Error = Errors.Normal;

                if (InitializeVM.Counts.FindAll(i => i.IsSelected).Count <= 0)
                    Error = Errors.NoSelectedGood;
                if (Stage_3_Data.FindAll(item => item.IsSelected).Count <= 0)
                    Error = Errors.NoSelectedGood;
                foreach (GoodsCounts itemSec in InitializeVM.Counts.FindAll(t => t.IsSelected))
                    if (Stage_3_Data.Find(i => i.GoodName == itemSec.Good.name && i.IsSelected) == null)
                        Error = Errors.WrongSelect;
                foreach (Stage_3M item in Stage_3_Data.FindAll(item => item.IsSelected))
                {
                    if (InitializeVM.Counts.Find(i => i.Good.name == item.GoodName && i.IsSelected) == null)
                    {
                        Error = Errors.WrongSelect;
                        break;
                    }
                    else
                        summ += item.GoodPrice * InitializeVM.Counts.Find(i => i.Good.name == item.GoodName).Count;
                }
                if (Error == Errors.Normal)
                {
                    SmallestTotal.Stage_3Min = summ;

                    Total = summ.ToString();
                }
                else
                    Total = "";
            });
        }
    }
}
