namespace Kursah.Model
{
    public class GoodsMaxPrice
    {
        public Goods Good { get; set; }
        public double Price { get; set; }

        public GoodsMaxPrice(Goods good, double price)
        {
            Good = good;
            Price = price;
        }
    }
}
