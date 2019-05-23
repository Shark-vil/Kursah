namespace Kursah.Model
{
    /// <summary>
    /// Класс для хранения выводов пользователя
    /// </summary>
    public  class Answers
    {
        public  string Stage_1_1A { get; set; }
        public  string Stage_1_2A { get; set; }
        public  string Stage_2A { get; set; }
        public  string Stage_3A { get; set; }
        public  string Stage_4A { get; set; }
        public  string FinalizeA { get; set; }

        public Answers()
        {
            Stage_1_1A = "";
            Stage_1_2A = "";
            Stage_2A = "";
            Stage_3A = "";
            Stage_4A = "";
            FinalizeA = "";
        }
    }
}
