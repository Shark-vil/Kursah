﻿using Kursah.Common;
using Kursah.Model;
using BaseMVVM.Command;
using BaseMVVM.Abstraction;

using System.Collections.Generic;
using System;

namespace Kursah.ViewModel
{
    public class Stage_1_2VM : ViewModelBase
    {
        public static List<Stage_1_2M> Stage_1_2_Data { get; private set; }

        public string MinPrice { get; set; }
        public string MaxPrice { get; set; }

        private List<GoodsMaxPrice> MaxPrices { get; set; }

        public SimpleCommand MathTotal { get; set; }

        private string total;
        private string _error;

        public string Total
        {
            get => total;
            set
            {
                total = value;

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

        public Stage_1_2VM()
        {
            MinPrice = "";
            MaxPrice = "";

            Stage_1_2_Data = new List<Stage_1_2M>();
            MaxPrices = new List<GoodsMaxPrice>();

            MathTotal = new SimpleCommand(() =>
            {
                if (Stage_1_2_Data.FindAll(item => item.IsSelected).Count > 0)
                {
                    float goodTotal = 0;
                    foreach (GoodsCounts match in InitializeVM.Counts)
                    {
                        float goodSum = 0;
                        foreach (Stage_1_2M row in Stage_1_2_Data.FindAll(item => item.IsSelected && item.Good_name == match.Good.name))
                        {
                            if ((int.Parse(row.GoodPrice) > MaxPrices.Find(item => item.Good.name == row.Good_name).Price))
                                Error = Errors.HighPrice;
                            else if (row.Bad)
                                Error = Errors.BadReputation;
                            else if (row.DeliveryTide > InitializeVM.MaxDeliveryTide)
                                Error = Errors.LongDelivery;
                            else
                                Error = Errors.Normal;
                            goodSum += int.Parse(row.GoodPrice);

                        }
                        if (match.Count > 0)
                            goodTotal += (goodSum / Stage_1_2_Data.FindAll(item => item.IsSelected && item.Good_name == match.Good.name).Count) * match.Count;
                    }
                    if (Error == Errors.Normal)
                    {
                        Total = goodTotal.ToString();
                        SmallestTotal.Stage_1_2Min = Convert.ToDouble(Total);
                    }
                }
                else
                    Error = Errors.NoSelected;
            });

            Stage_1_2_Data = kursahEntities.Instane.Database.SqlQuery<Stage_1_2M>(Queries.Stage_1_2Querry).ToListAsync().Result;

            //Расчет минимальной и максимальной цен
            foreach (GoodsCounts match in InitializeVM.Counts)
            {
                double tmpMin = 0;

                foreach (Stage_1_2M item in Stage_1_2_Data)
                {
                    if (item.Good_name == match.Good.name)
                        tmpMin = tmpMin == 0 ? int.Parse(item.GoodPrice) :
                            int.Parse(item.GoodPrice) > tmpMin ? tmpMin :
                            int.Parse(item.GoodPrice);
                }
                double tmpMax = tmpMin * 1.25;
                MaxPrices.Add(new GoodsMaxPrice(match.Good, tmpMax));
                MinPrice += string.Concat(tmpMin.ToString(), "; ");
                MaxPrice += string.Concat(tmpMax.ToString(), "; ");
            }
        }

        public static void SelectSecond(string providerName)
        {
            List<Stage_1_2M> tmpList = Stage_1_2_Data.FindAll(item => item.Provider_name == providerName);
            foreach (Stage_1_2M item in tmpList)
            {
                if (!item.IsSelected)
                    item.Select(true);
            }
        }
        public static void DeselectSecond(string providerName)
        {
            List<Stage_1_2M> tmpList = Stage_1_2_Data.FindAll(item => item.Provider_name == providerName);
            foreach (Stage_1_2M item in tmpList)
            {
                if (item.IsSelected)
                    item.Select(false);
            }
        }
    }
}
