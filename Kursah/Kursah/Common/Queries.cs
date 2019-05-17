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
    }
}
