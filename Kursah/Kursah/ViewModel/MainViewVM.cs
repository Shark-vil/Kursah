using Kursah.Model;
using Kursah.Common;

using BaseMVVM.Command;
using BaseMVVM.Abstraction;

namespace Kursah.ViewModel
{
    /// <summary>
    /// Класс для взаимодейтвия данных и отображения основного окна.
    /// </summary>
    public class MainViewVM : ViewModelBase
    {
        private bool _canContinueLocal;
        private string _answer;

        public MainViewVM()
        {
            kursahEntities.Start();

            CustomParams_Context = new CustomParams_VM();

            IntroductionContext = new InitializeVM();

            Stage_1_1_Context = new Stage_1_1VM();
            Stage_1_2_Context = new Stage_1_2VM();
            Stage_2_Context = new Stage_2VM();
            Stage_3_Context = new Stage_3VM();
            Stage_4_Context = new Stage_4VM();
            FinalizeContext = new FinalizeVM();

            Answers = new Answers();

            RefreshData = new SimpleCommand(() =>
            {
            });
        }

        public CustomParams_VM CustomParams_Context { get; set; }
        public InitializeVM IntroductionContext { get; set; }
        public Stage_1_1VM Stage_1_1_Context { get; set; }
        public Stage_1_2VM Stage_1_2_Context { get; set; }
        public Stage_2VM Stage_2_Context { get; set; }
        public Stage_3VM Stage_3_Context { get; set; }
        public Stage_4VM Stage_4_Context { get; set; }
        public FinalizeVM FinalizeContext { get; set; }

        public Answers Answers { get; set; }

        public string Answer
        {
            get => _answer;
            set
            {
                _answer = value;

                OnPropertyChanged();
            }
        }

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
