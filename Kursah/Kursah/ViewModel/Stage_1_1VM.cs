using System.ComponentModel;
using System.Data.Entity;

using Kursah.Common;
using Kursah.Model;

using BaseMVVM.Command;
using BaseMVVM.Abstraction;
using System.Collections.Generic;

namespace Kursah.ViewModel
{
    public  class Stage_1_1VM : ViewModelBase
    {
        public static List<Stage_1_1M> Stage_1_1_Data { get; private set; }

        public Stage_1_1VM()
        {
            //List<Stage_1_1M> list = new List<Stage_1_1M>();
            Stage_1_1_Data = kursahEntities.Instane.Database.SqlQuery<Stage_1_1M>("SELECT `Providers`.`name` AS `Provider_name`,`Goods`.`name` AS `Good_name`,`Provide_offers_goods`.`price` AS `Good_price` FROM Providers " +
                "LEFT JOIN `kursah`.`Provide_offers_goods` ON `Providers`.`id` = `Provide_offers_goods`.`provider_id`  " +
                "LEFT JOIN `kursah`.`Goods` ON `Provide_offers_goods`.`good_id` = `Goods`.`id` ").ToListAsync().Result;
            //foreach (Providers providers in kursahEntities.Instane.Providers.Include(p=>p.provide_Offers_Goods))
            //{
            //    Stage_1_1M tmp = new Stage_1_1M()
            //    {
            //        Provider_name = providers.name
            //    };
            //    foreach (Goods good in  providers)
            //    {
            //        tmp.Good_name = good.name;
            //        tmp.Good_price = good.provide_Offers_Goods.
            //    }
            //}
        }
    }
}
