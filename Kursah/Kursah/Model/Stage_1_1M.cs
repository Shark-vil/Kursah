namespace Kursah.Model
{
    public class Stage_1_1M
    {
        public string Provider_name { get; set; }
        public string Good_name { get; set; }
        public string GoodPrice { get; set; }
        public bool IsSelected { get; set; }

        public override string ToString()
        {
            return string.Concat(Provider_name, " ", Good_name, " ", GoodPrice);
        }
    }
}
