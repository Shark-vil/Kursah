//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kursah.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Provide_offers_goods
    {
        public int id { get; set; }
        public int provider_id { get; set; }
        public int payment_type_id { get; set; }
        public int delivery_tide { get; set; }
        public int payment_delay { get; set; }
        public int good_id { get; set; }
        public float price { get; set; }
    }
}