using Kursah.Common;
using Kursah.Model;

using BaseMVVM.Command;
using BaseMVVM.Abstraction;

using System.Collections.Generic;

namespace Kursah.ViewModel
{
    /// <summary>
    /// Класс для взаимодейтвия данных и отображения Стадии_4.
    /// </summary>
    public class Stage_4VM : ViewModelBase
    {
        public static List<Stage_4M> Stage_4_Data { get; set; }
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

        public Stage_4VM()
        {
            Error = Errors.Normal;
            Total = "";

            Stage_4_Data = kursahEntities.Instane.Database.SqlQuery<Stage_4M>(Queries.Stage_3Querry).ToListAsync().Result;

            MathTotal = new SimpleCommand(() =>
            {

                if (Stage_4_Data == null || Stage_4_Data.Count == 0)
                {
                    Total = "";
                    Error = "Нету объектов, которые бы удовлетворяли требованиям вычисления";
                    return;
                }

                double summ = 0;
                int count = InitializeVM.Counts.Count;

                foreach (Stage_4M value in Stage_4_Data.FindAll(item => item.IsSelected))
                    summ += value.GoodPrice;

                if (summ == 0)
                {
                    Total = "";
                    Error = "Не выбран ни один элемент списка";
                    return;
                }

                SmallestTotal.Stage_4Min = summ;

                Total = summ.ToString();
            });
        }
    }
}
