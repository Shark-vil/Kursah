using Kursah.Model;

using BaseMVVM.Command;
using BaseMVVM.Abstraction;

namespace Kursah.ViewModel
{
    public class MainViewVM
    {
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
        }

        public InitializeVM IntroductionContext { get; set; }
        public Stage_1_1VM Stage_1_1_Context { get; set; }
        public Stage_1_2VM Stage_1_2_Context { get; set; }
        public Stage_2VM Stage_2_Context { get; set; }
        public Stage_3VM Stage_3_Context { get; set; }
        public Stage_4VM Stage_4_Context { get; set; }
        public FinalizeVM FinalizeContext { get; set; }

        public string Answer { get; set; }
    }
}
