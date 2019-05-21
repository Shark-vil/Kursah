namespace Kursah.Common
{
    public static class Errors
    {
        public static string Normal { get; } = "";

        public static string HighPrice { get;} = "Стоимость одного из выбранных товаров превышает максимальную расчетную стоимость";
        public static string BadReputation { get; } = "Один из поставщиков находится в списке ненадежных поставщиков";
        public static string LongDelivery { get; } = "Один из поставщиков предлагает слишком долгую доставку";
        public static string NoSelected { get; } = "Не выбрано ни одного поставщика";
        public static string NoKIF { get; } = "КИФ не указан или указан не верно";

    }
}
