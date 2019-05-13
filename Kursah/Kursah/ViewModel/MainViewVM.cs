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

            Stage_1_1_Context = new Stage_1_1VM();
            IntroductionContext = new InitializeVM();
        }

        public Stage_1_1VM Stage_1_1_Context { get; set; }
        public InitializeVM IntroductionContext { get; set; }
        public string Answer { get; set; }
    }
}
