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
            Stage_2_Data = kursahEntities.Instane.Database.SqlQuery<Stage_2M>(Queries.Stage_2Querry).ToListAsync().Result;
        }
    }
}
