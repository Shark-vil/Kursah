using Kursah.Common;
using Kursah.Model;

using BaseMVVM.Command;
using BaseMVVM.Abstraction;

using System.Collections.Generic;
using System;

namespace Kursah.ViewModel
{
    public class Stage_3VM : ViewModelBase
    {
        //public static List<Stage_3M> Stage_3_Data { get; private set; }
        public static List<Stage_3M> Stage_3_Data { get; set; }
        public SimpleCommand MathTotal { get; set; }

        public Stage_3VM()
        {
            Error = Errors.Normal;
            Total = "";

            Stage_3_Data = kursahEntities.Instane.Database.SqlQuery<Stage_3M>(Queries.Stage_3Querry).ToListAsync().Result;

            MathTotal = new SimpleCommand(() =>
            {
<<<<<<< HEAD
                if (Stage_3_Data == null || Stage_3_Data.Count == 0)
                {
                    Total = "";
                    Error = "Нету объектов, которые бы удовлетворяли требованиям вычисления";
                    return;
                }

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
=======

>>>>>>> parent of 40f795b... Расчёт БД ценовых показателей - Stage_3
            });
        }
    }
}
