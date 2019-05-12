using NLog;
using System.Windows;
using System.Windows.Controls;

namespace Kursah.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindowV: Window
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

        private int radioButtonNum;

        public MainWindowV()
        {
            InitializeComponent();

            logger.Info("Application started");
        }

        public int RadioButtonNum
        {
            get => radioButtonNum;
            set
            {
                radioButtonNum = value;
                switch (radioButtonNum)
                {
                    case 1:
                        IntroductionRB.IsChecked = true;
                        break;
                    case 2:
                        Stage_1_1_RB.IsChecked = true;
                        break;
                    case 3:
                        Stage_1_2_RB.IsChecked = true;
                        break;
                    case 4:
                        Stage_2_RB.IsChecked = true;
                        break;
                    case 5:
                        Stage_3_RB.IsChecked = true;
                        break;
                    case 6:
                        Stage_4_RB.IsChecked = true;
                        break;
                    case 7:
                        FinalizeRB.IsChecked = true;
                        break;
                    default:
                        IntroductionRB.IsChecked = true;
                        break;
                }
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButtonNum = RadioButtonNum + 1;
        }

        private void RadioButtonsChecked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            switch (rb.Name)
            {
                case "IntroductionRB":
                    radioButtonNum = 1;
                    break;
                case "Stage_1_1_RB":
                    radioButtonNum = 2;
                    break;
                case "Stage_1_2_RB":
                    radioButtonNum = 3;
                    break;
                case "Stage_2_RB":
                    radioButtonNum = 4;
                    break;
                case "Stage_3_RB":
                    radioButtonNum = 5;
                    break;
                case "Stage_4_RB":
                    radioButtonNum = 6;
                    break;
                case "FinalizeRB":
                    radioButtonNum = 7;
                    break;
                default:
                    radioButtonNum = 1;
                    break;
            }
        }
    }
}
