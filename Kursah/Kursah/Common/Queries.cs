namespace Kursah.Common
{
    public static class Queries
    {
        public static string Stage_1_1Querry { get; } = 
            "SELECT `Providers`.`name` AS `Provider_name`,`Goods`.`name` AS `Good_name`,`Provide_offers_goods`.`price` AS `GoodPrice` FROM Providers " +
            "LEFT JOIN `kursah`.`Provide_offers_goods` ON `Providers`.`id` = `Provide_offers_goods`.`provider_id`  " +
            "LEFT JOIN `kursah`.`Goods` ON `Provide_offers_goods`.`good_id` = `Goods`.`id` ";
        public static string Stage_1_2Querry { get; } =
            "SELECT  `Providers`.`name` AS `Provider_name`,  `Goods`.`name` AS `Good_name` ,  `Provide_offers_goods`.`price` AS `GoodPrice`,  " +
            "`Payment_types`.`name` AS `PaymentType`,  `Provide_offers_goods`.`payment_delay` AS `PaymentDelay`, " +
            "`Provide_offers_goods`.`delivery_tide` AS `DeliveryTide`, `Providers`.`bad` AS `Bad`" +
            "FROM Providers " +
            "LEFT JOIN  `kursah`.`Provide_offers_goods` ON  `Providers`.`id` =  `Provide_offers_goods`.`provider_id` " +
            "LEFT JOIN  `kursah`.`Goods` ON  `Provide_offers_goods`.`good_id` =  `Goods`.`id` " +
            "LEFT JOIN  `kursah`.`Payment_types` ON  `Provide_offers_goods`.`payment_type_id` =  `Payment_types`.`id`";
        public static string Stage_2Querry { get; } =
            "SELECT `Offers`.`name` AS `OfferName`,`Offers`.`date_complete` AS `DateComplete`,`Goods`.`name` AS `GoodName`, " +
            "`Offers_goods`.`count` AS `Count`,`Offers_goods`.`price` AS `PriceOld` " +
            "FROM Offers " +
            "LEFT JOIN `kursah`.`Offers_goods` ON `Offers`.`id` = `Offers_goods`.`offer_id`  " +
            "LEFT JOIN `kursah`.`Goods` ON `Offers_goods`.`goods_id` = `Goods`.`id` ";
        public static string Stage_3Querry { get; } =
            "SELECT `Goods`.`name` AS `GoodName`, `Offers_goods`.`price` AS `GoodPrice`" +
            "FROM Offers " +
            "LEFT JOIN `kursah`.`Offers_goods` ON `Offers`.`id` = `Offers_goods`.`offer_id`  " +
            "LEFT JOIN `kursah`.`Goods` ON `Offers_goods`.`goods_id` = `Goods`.`id` ";
        public static string Stage_4Querry { get; } =
            "SELECT `Goods`.`name` AS `GoodName`, `Offers_goods`.`price` AS `GoodPrice`" +
            "FROM Offers " +
            "LEFT JOIN `kursah`.`Offers_goods` ON `Offers`.`id` = `Offers_goods`.`offer_id`  " +
            "LEFT JOIN `kursah`.`Goods` ON `Offers_goods`.`goods_id` = `Goods`.`id` ";
    }
}
