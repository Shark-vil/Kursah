namespace Kursah.Model
{
    public class GoodsCounts
    {
        public Goods Good { get; set; }
        public int Count { get; set; }

        public GoodsCounts(Goods good, int count)
        {
            Good = good;
            Count = count;
        }
    }
}
