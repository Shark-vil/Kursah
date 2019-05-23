using NLog;
using Kursah.Model;
using System.Windows.Controls;
using System.Windows;

using Kursah.Common;

namespace Kursah.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindowV : Window
    {
        private int radioButtonNum;

        public MainWindowV()
        {
            InitializeComponent();
        }

        public int RadioButtonNum
        {
            get => radioButtonNum;
            set
            {
                radioButtonNum = value;
                switch (value)
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
            RadioButtonNum++;
        }

        private void RadioButtonsUnchecked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            switch (rb.Name)
            {
                case "IntroductionRB":
                    break;
                case "Stage_1_1_RB":
                    Lists.MainWindow.Answers.Stage_1_1A = AnswerTextBox.Text;
                    AnswerTextBox.Clear();
                    break;
                case "Stage_1_2_RB":
                    Lists.MainWindow.Answers.Stage_1_2A = AnswerTextBox.Text;
                    AnswerTextBox.Clear();
                    break;
                case "Stage_2_RB":
                    Lists.MainWindow.Answers.Stage_2A = AnswerTextBox.Text;
                    AnswerTextBox.Clear();
                    break;
                case "Stage_3_RB":
                    Lists.MainWindow.Answers.Stage_3A = AnswerTextBox.Text;
                    AnswerTextBox.Clear();
                    break;
                case "FinalizeRB":
                    Lists.MainWindow.Answers.FinalizeA = AnswerTextBox.Text;
                    AnswerTextBox.Clear();
                    break;
                default:
                    break;
            }
        }

        private void IntroductionRB_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            switch (rb.Name)
            {
                case "IntroductionRB":
                    radioButtonNum = 1;
                    break;
                case "Stage_1_1_RB":
                    radioButtonNum = 2;
                    AnswerTextBox.Text = Lists.MainWindow.Answers.Stage_1_1A;
                    break;
                case "Stage_1_2_RB":
                    radioButtonNum = 3;
                    AnswerTextBox.Text = Lists.MainWindow.Answers.Stage_1_2A;
                    break;
                case "Stage_2_RB":
                    radioButtonNum = 4;
                    AnswerTextBox.Text = Lists.MainWindow.Answers.Stage_2A;
                    break;
                case "Stage_3_RB":
                    radioButtonNum = 5;
                    AnswerTextBox.Text = Lists.MainWindow.Answers.Stage_3A;
                    break;
                case "FinalizeRB":
                    radioButtonNum = 6;
                    AnswerTextBox.Text = Lists.MainWindow.Answers.FinalizeA;
                    break;
                default:
                    radioButtonNum = 1;
                    break;
            }
        }
    }
}
