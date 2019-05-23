using Kursah.Common;
using Kursah.Model;

using BaseMVVM.Command;
using BaseMVVM.Abstraction;
using System.IO;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Text.RegularExpressions;

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

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            if (!Directory.Exists(dirResult))
                Directory.CreateDirectory(dirResult);

            CreateDoc = new SimpleCommand(() =>
            {
                for (int i = 0; i < fileEnd.Length; i++)
                    if (File.Exists(filePath + $".{fileEnd[i]}"))
                    {
                        string niceFilePath = filePath + $".{fileEnd[i]}";
                        string niceFilePathResult = filePathResult + $".{fileEnd[i]}";

                        if (File.Exists(niceFilePathResult))
                            File.Delete(niceFilePathResult);

                        File.Copy(niceFilePath, niceFilePathResult);

                        Dictionary<string, string> marks = new Dictionary<string, string>()
                        {
                            { "Stage_1_1MinLocal", Stage_1_1MinLocal.ToString()},
                            { "Stage_1_2MinLocal", Stage_1_2MinLocal.ToString()},
                            { "Stage_2MinLocal", Stage_2MinLocal.ToString()},
                            { "Stage_3MinLocal", Stage_3MinLocal.ToString()},
                            { "Date", DateTime.Now.ToLongDateString()}
                        };

                        try
                        {
                            using (WordprocessingDocument document = WordprocessingDocument.Open(niceFilePathResult, true))
                            {
                                Body documentBody = document.MainDocumentPart.Document.Body;
                                List<Paragraph> paragraphsWithMarks = documentBody.Descendants<Paragraph>().Where(x => Regex.IsMatch(x.InnerText, @".*\[\w+\].*")).ToList();
                                foreach (Paragraph paragraph in paragraphsWithMarks)
                                {
                                    foreach (Match markMatch in Regex.Matches(paragraph.InnerText, @"\[\w+\]", RegexOptions.Compiled))
                                    {

                                        string paragraphMarkValue = markMatch.Value.Trim(new[] { '[', ']' });
                                        string markValueFromCollection;
                                        if (marks.TryGetValue(paragraphMarkValue, out markValueFromCollection))
                                        {
                                            string editedParagraphText = paragraph.InnerText.Replace(markMatch.Value, markValueFromCollection);
                                            paragraph.RemoveAllChildren<Run>();
                                            paragraph.AppendChild<Run>(new Run(new Text(editedParagraphText)));
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            NLog.LogManager.GetCurrentClassLogger().Error($"Ошибка записи данных в документ: \r\n{ex}");
                        }

                        break;
                    }
            });
        }
    }
}
