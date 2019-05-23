using Kursah.Common;
using Kursah.Model;

using BaseMVVM.Command;
using BaseMVVM.Abstraction;
using System.IO;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System;
using Microsoft.Win32;

namespace Kursah.ViewModel
{
    /// <summary>
    /// Класс для взаимодейтвия данных и отображения вывода.
    /// </summary>
    public class FinalizeVM : ViewModelBase
    {
        private double _stage_1_1MinLocal;
        private double _stage_1_2MinLocal;
        private double _stage_2MinLocal;
        private double _stage_3MinLocal;
        private double _stage_4MinLocal;
        private string _error;
        private string filePath;

        public double Stage_1_1MinLocal
        {
            get => _stage_1_1MinLocal;
            set
            {
                _stage_1_1MinLocal = value;

                OnPropertyChanged();
            }
        }
        public double Stage_1_2MinLocal
        {
            get => _stage_1_2MinLocal;
            set
            {
                _stage_1_2MinLocal = value;

                OnPropertyChanged();
            }
        }
        public double Stage_2MinLocal
        {
            get => _stage_2MinLocal;
            set
            {
                _stage_2MinLocal = value;

                OnPropertyChanged();
            }
        }
        public double Stage_3MinLocal
        {
            get => _stage_3MinLocal;
            set
            {
                _stage_3MinLocal = value;

                OnPropertyChanged();
            }
        }
        public double Stage_4MinLocal
        {
            get => _stage_4MinLocal;
            set
            {
                _stage_4MinLocal = value;

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

        public SimpleCommand Refresh { get; set; }
        public SimpleCommand CreateDoc { get; set; }

        public FinalizeVM()
        {
            Refresh = new SimpleCommand(() =>
            {
                Stage_1_1MinLocal = SmallestTotal.Stage_1_1Min;
                Stage_1_2MinLocal = SmallestTotal.Stage_1_2Min;
                Stage_2MinLocal = SmallestTotal.Stage_2Min;
                Stage_3MinLocal = SmallestTotal.Stage_3Min;
                Stage_4MinLocal = SmallestTotal.Stage_4Min;
            });

            string dir = "doc_templates";
            string dirResult = "docs";
            string fileName = "report";
            string filePath = dir + "/" + fileName;
            string filePathResult = dirResult + "/" + fileName;
            string[] fileEnd = new string[] { "docx", "doc" };

            CreateDoc = new SimpleCommand(() =>
            {
                Lists.MainWindow.Answers.FinalizeA = Lists.MainWindow.Answer;
                CreateDocument();
            });
        }

        public bool SaveFileDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Word files(*.docx)|*.docx";
            if (saveFileDialog.ShowDialog() == true)
            {
                filePath = saveFileDialog.FileName;
                return true;
            }
            return false;
        }

        private void CreateDocument()
        {
            try
            {
                Error = Errors.Normal;

                Word.Application winword = new Word.Application();

                winword.ShowAnimation = false;
                winword.Visible = false;

                object missing = Missing.Value;

                Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);

                Word.Paragraph para1 = document.Content.Paragraphs.Add(ref missing);
                para1.Range.Text = "Вывод о расчете на основе коммерческих предложений:";
                para1.Range.InsertParagraphAfter();

                Word.Paragraph para11 = document.Content.Paragraphs.Add(ref missing);
                para11.Range.Text = Lists.MainWindow.Answers.Stage_1_1A;
                para11.Range.InsertParagraphAfter();

                Word.Paragraph para2 = document.Content.Paragraphs.Add(ref missing);
                para2.Range.Text = "Вывод о расчете на основе коммерческих предложений с дополнительными параметрами:";
                para2.Range.InsertParagraphAfter();

                Word.Paragraph para22 = document.Content.Paragraphs.Add(ref missing);
                para22.Range.Text = Lists.MainWindow.Answers.Stage_1_2A;
                para22.Range.InsertParagraphAfter();

                Word.Paragraph para3 = document.Content.Paragraphs.Add(ref missing);
                para3.Range.Text = "Вывод о расчете на основе реестра контрактов:";
                para3.Range.InsertParagraphAfter();

                Word.Paragraph para33 = document.Content.Paragraphs.Add(ref missing);
                para33.Range.Text = Lists.MainWindow.Answers.Stage_2A;
                para33.Range.InsertParagraphAfter();

                Word.Paragraph para4 = document.Content.Paragraphs.Add(ref missing);
                para4.Range.Text = "Вывод о расчете на основе значений из базы данных ценовых показателей:";
                para4.Range.InsertParagraphAfter();

                Word.Paragraph para44 = document.Content.Paragraphs.Add(ref missing);
                para44.Range.Text = Lists.MainWindow.Answers.Stage_3A;
                para44.Range.InsertParagraphAfter();

                Word.Paragraph para5 = document.Content.Paragraphs.Add(ref missing);
                para5.Range.Text = "Вывод о проделанной работе:";
                para5.Range.InsertParagraphAfter();

                Word.Paragraph para55 = document.Content.Paragraphs.Add(ref missing);
                para55.Range.Text = Lists.MainWindow.Answers.FinalizeA;
                para55.Range.InsertParagraphAfter();

                SaveFileDialog();

                document.SaveAs2(filePath);
                document.Close(ref missing, ref missing, ref missing);
                document = null;
                winword.Quit(ref missing, ref missing, ref missing);
                winword = null;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }
    }
}
