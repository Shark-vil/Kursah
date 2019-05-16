﻿using System.ComponentModel;
using System.Data.Entity;

using Kursah.Common;
using Kursah.Model;

using BaseMVVM.Command;
using BaseMVVM.Abstraction;
using System.Collections.Generic;
using System.Windows.Controls;
using System;

namespace Kursah.ViewModel
{
    public class Stage_1_1VM : ViewModelBase
    {
        public static List<Stage_1_1M> Stage_1_1_Data { get; private set; }

        public string MinPrice { get; set; }
        public string MaxPrice { get; set; }

        private List<GoodsMaxPrice> MaxPrices { get; set; }

        public SimpleCommand MathTotal { get; set; }

        public string Total { get; set; }

        public string Error { get; set; }

        public Stage_1_1VM()
        {
            Error = "";
            MinPrice = "";
            MaxPrice = "";

            Stage_1_1_Data = new List<Stage_1_1M>();
            MaxPrices = new List<GoodsMaxPrice>();

            MathTotal = new SimpleCommand(() =>
            {
                float goodTotal = 0;
                foreach (GoodsCounts match in InitializeVM.Counts)
                {
                    float goodSum = 0;
                    foreach (Stage_1_1M row in Stage_1_1_Data.FindAll(item => item.IsSelected && item.Good_name == match.Good.name))
                    {
                        if ((int.Parse(row.GoodPrice) > MaxPrices.Find(item => item.Good.name == row.Good_name).Price))
                            Error = "Стоимость одного из выбранных товаров превышает максимальную расчетную стоимость";
                        else
                            Error = "";
                        goodSum += int.Parse(row.GoodPrice);
                                              
                    }
                    if (match.Count > 0)
                        goodTotal += goodSum / match.Count;
                }
                if (Error != "")
                {
                    Total = goodTotal.ToString();
                    SmallestTotal.Stage_1_1Min = Convert.ToDouble(Total);
                }
            });            

            Stage_1_1_Data = kursahEntities.Instane.Database.SqlQuery<Stage_1_1M>(
                "SELECT `Providers`.`name` AS `Provider_name`,`Goods`.`name` AS `Good_name`,`Provide_offers_goods`.`price` AS `GoodPrice` FROM Providers " +
                "LEFT JOIN `kursah`.`Provide_offers_goods` ON `Providers`.`id` = `Provide_offers_goods`.`provider_id`  " +
                "LEFT JOIN `kursah`.`Goods` ON `Provide_offers_goods`.`good_id` = `Goods`.`id` ").ToListAsync().Result;            

            //Расчет минимальной и максимальной цен
            foreach (GoodsCounts match in InitializeVM.Counts)
            {
                double tmpMin = 0;
                foreach (Stage_1_1M item in Stage_1_1_Data)
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
            List<Stage_1_1M> tmpList = Stage_1_1_Data.FindAll(item => item.Provider_name == providerName);
            foreach (Stage_1_1M item in tmpList)
            {
                item.Select(true);
            }
        }
        public static void DeselectSecond(string providerName)
        {
            List<Stage_1_1M> tmpList = Stage_1_1_Data.FindAll(item => item.Provider_name == providerName);
            foreach (Stage_1_1M item in tmpList)
            {
                item.Select(false);
            }
        }

        
        

    }
}
