using Kursah.Model;
using Kursah.Common;

using BaseMVVM.Command;
using BaseMVVM.Abstraction;

namespace Kursah.ViewModel
{
    public class MainViewVM : ViewModelBase
    {
        private bool _canContinueLocal;

        public MainViewVM()
        {
            kursahEntities.Start();

            IntroductionContext = new InitializeVM();

            Stage_1_1_Context = new Stage_1_1VM();
            Stage_1_2_Context = new Stage_1_2VM();
            Stage_2_Context = new Stage_2VM();
            Stage_3_Context = new Stage_3VM();
            Stage_4_Context = new Stage_4VM();
            FinalizeContext = new FinalizeVM();
           

            RefreshData = new SimpleCommand(() =>
            {
                //if (InitializeVM.Counts != null)
                //{
                //    bool check = false;
                //    string addToQ = "";
                //    foreach (GoodsCounts item in InitializeVM.Counts)
                //    {
                //        if (item.IsSelected)
                //        {
                //            check = true;
                //            addToQ += addToQ.Contains(" WHERE `Goods`.`name` = ") ? "" : " WHERE `Goods`.`name` = ";
                //            addToQ += string.Concat(" \"", item.Good.name, "\" OR");
                //        }
                //    }
                //    if (addToQ != "")
                //        addToQ = addToQ.Remove(addToQ.Length-2, 2);
                //    if (check)
                //    {
                //        //Stage_1_1_Context.Stage_1_1_Data = kursahEntities.Instane.Database.SqlQuery<Stage_1_1M>(Queries.Stage_1_1Querry + addToQ).ToListAsync().Result;
                //    }
                //    else
                //    {

                //    }

                //}
            });
        }

        public InitializeVM IntroductionContext { get; set; }
        public Stage_1_1VM Stage_1_1_Context { get; set; }
        public Stage_1_2VM Stage_1_2_Context { get; set; }
        public Stage_2VM Stage_2_Context { get; set; }
        public Stage_3VM Stage_3_Context { get; set; }
        public Stage_4VM Stage_4_Context { get; set; }
        public FinalizeVM FinalizeContext { get; set; }

        public string Answer { get; set; }        

        public bool CanContinueLocal
        {
            get => _canContinueLocal;
            set
            {
                _canContinueLocal = value;

                OnPropertyChanged();
            }
        }

        public SimpleCommand RefreshData { get; set; }
    }
}
