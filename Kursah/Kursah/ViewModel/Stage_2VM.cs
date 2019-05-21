using Kursah.Common;
using Kursah.Model;

using BaseMVVM.Command;
using BaseMVVM.Abstraction;

using System.Collections.Generic;
using System;

namespace Kursah.ViewModel
{
    public class Stage_2VM : ViewModelBase
    {
        public static List<Stage_2M> Stage_2_Data { get; private set; }

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

        public Stage_2VM()
        {
            Error = Errors.Normal;
            Total = "";

            Stage_2_Data = kursahEntities.Instane.Database.SqlQuery<Stage_2M>(Queries.Stage_2Querry).ToListAsync().Result;

            MathTotal = new SimpleCommand(() =>
            {
                double goodTotal = 0;
                Error = Errors.Normal;

                if (InitializeVM.KIF <= 0)
                    Error = Errors.NoKIF;

                if (Error == Errors.Normal)
                {
                    foreach (GoodsCounts match in InitializeVM.Counts)
                    {
                        double goodSum = 0;
                        foreach (Stage_2M row in Stage_2_Data.FindAll(item => item.GoodName == match.Good.name))
                        {
                            row.PriceOldPerOne = row.PriceOld / row.Count;
                            row.PriceNewPerOne = row.PriceOldPerOne * InitializeVM.KIF * row.IPC;
                            row.PriceNew = row.PriceNewPerOne * match.Count;
                            goodSum += row.PriceNew;
                        }
                        if (match.Count > 0 && goodSum != 0)
                            goodTotal += (goodSum / Stage_2_Data.FindAll(item => item.GoodName == match.Good.name).Count);
                    }

                    Total = goodTotal.ToString();
                    SmallestTotal.Stage_2Min = Convert.ToDouble(Total);
                }
                else
                    Total = "";
            });
        }
    }
}
