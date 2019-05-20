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
        public static List<Stage_3M> Stage_3_Data { get; private set; }
        public SimpleCommand MathTotal { get; set; }

        public Stage_3VM()
        {
            Stage_3_Data = kursahEntities.Instane.Database.SqlQuery<Stage_3M>(Queries.Stage_3Querry).ToListAsync().Result;

            MathTotal = new SimpleCommand(() =>
            {

            });
        }
    }
}
