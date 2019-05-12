using System.ComponentModel;
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
    public  class Stage_1_1VM : ViewModelBase
    {
        public static List<Stage_1_1M> Stage_1_1_Data { get; private set; }

        public string MinPrice { get; set; }
        public string MaxPrice { get; set; }        

        public Stage_1_1VM()
        {            
            Stage_1_1_Data = new List<Stage_1_1M>();
            Stage_1_1_Data = kursahEntities.Instane.Database.SqlQuery<Stage_1_1M>(
                "SELECT `Providers`.`name` AS `Provider_name`,`Goods`.`name` AS `Good_name`,`Provide_offers_goods`.`price` AS `GoodPrice` FROM Providers " +
                "LEFT JOIN `kursah`.`Provide_offers_goods` ON `Providers`.`id` = `Provide_offers_goods`.`provider_id`  " +
                "LEFT JOIN `kursah`.`Goods` ON `Provide_offers_goods`.`good_id` = `Goods`.`id` ").ToListAsync().Result;
            List<string> goodNames = new List<string>();
            foreach (Stage_1_1M item in Stage_1_1_Data)
            {
                if (!goodNames.Contains(item.Good_name))
                    goodNames.Add(item.Good_name);
            }
            MinPrice = "";
            MaxPrice = "";
            foreach (string name in goodNames)
            {
                int tmpMin = 0;
                foreach (Stage_1_1M item in Stage_1_1_Data)
                {
                    if (item.Good_name == name)
                    tmpMin = tmpMin == 0 ? 
                        int.Parse(item.GoodPrice) : int.Parse(item.GoodPrice) > tmpMin ? 
                        tmpMin : int.Parse(item.GoodPrice);
                }
                double tmpMax = tmpMin * 1.25;
                MinPrice += string.Concat(tmpMin.ToString(), "; ");
                MaxPrice += string.Concat(tmpMax.ToString(), "; ");
            }
            MinPrice.Remove(MinPrice.Length-2, 2);
            MaxPrice.Remove(MinPrice.Length-2, 2);
        }

        public static void SelectSecond(DataGrid dataGrid)
        {
            List<Stage_1_1M> second = new List<Stage_1_1M>();
            for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
            {
                Stage_1_1M row = (Stage_1_1M)dataGrid.SelectedItems[i];
                foreach (Stage_1_1M item in Stage_1_1_Data.FindAll(item => item.Provider_name == row.Provider_name))
                {
                    if (!second.Contains(item))
                        second.Add(item);
                }
            }
            dataGrid.SelectedItems.Clear();
            foreach (Stage_1_1M item in second)
            {
                dataGrid.SelectedItems.Add(item);
            }
        }

        
        
    }
}
