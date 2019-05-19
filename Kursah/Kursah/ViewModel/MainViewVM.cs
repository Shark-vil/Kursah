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
        }

        public InitializeVM IntroductionContext { get; set; }
        public Stage_1_1VM Stage_1_1_Context { get; set; }
        public Stage_1_2VM Stage_1_2_Context { get; set; }
        public Stage_2VM Stage_2_Context { get; set; }

        public string Answer { get; set; }
    }
}
