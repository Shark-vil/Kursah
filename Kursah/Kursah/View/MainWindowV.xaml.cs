﻿using NLog;
using Kursah.Model;
using System.Windows.Controls;
using System.Windows;

namespace Kursah.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindowV: Window
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

        private int radioButtonNum;

        public static bool CanGo { get; set; }

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
                if (true)
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
                else
                    IntroductionRB.IsChecked = true;
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
                    RadioButtonNum = 1;
                    break;
                case "Stage_1_1_RB":
                    Answers.Stage_1_1A = AnswerTextBox.Text;
                    AnswerTextBox.Clear();
                    AnswerTextBox.Text = Answers.Stage_1_2A;
                    RadioButtonNum = 2;
                    break;
                case "Stage_1_2_RB":
                    Answers.Stage_1_2A = AnswerTextBox.Text;
                    AnswerTextBox.Clear();
                    AnswerTextBox.Text = Answers.Stage_2A;
                    RadioButtonNum = 3;
                    break;
                case "Stage_2_RB":
                    Answers.Stage_2A = AnswerTextBox.Text;
                    AnswerTextBox.Clear();
                    AnswerTextBox.Text = Answers.Stage_3A;
                    RadioButtonNum = 4;
                    break;
                case "Stage_3_RB":
                    Answers.Stage_3A = AnswerTextBox.Text;
                    AnswerTextBox.Clear();
                    AnswerTextBox.Text = Answers.Stage_4A;
                    RadioButtonNum = 5;
                    break;
                case "Stage_4_RB":
                    Answers.Stage_4A = AnswerTextBox.Text;
                    AnswerTextBox.Clear();
                    AnswerTextBox.Text = Answers.FinalizeA;
                    RadioButtonNum = 6;
                    break;
                case "FinalizeRB":
                    Answers.FinalizeA = AnswerTextBox.Text;
                    AnswerTextBox.Clear();
                    RadioButtonNum = 7;
                    break;
                default:
                    RadioButtonNum = 1;
                    break;
            }
        }
    }
}
