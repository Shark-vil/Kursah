﻿using System;

using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using Kursah.Model;

namespace Kursah.Common
{
    public class DataBase: DbContext
    {
        public static DataBase Instane;

        public DataBase()
            : base("name=kursahEntities")
        {
        }

        public static void Start()
        {
            Instane = new DataBase();

            Instane.Goods.Load();
            Instane.Offers.Load();
            Instane.Offers_goods.Load();
            Instane.Payment_types.Load();
            Instane.Provide_offers_goods.Load();
            Instane.Providers.Load();
        }

        public static void Update()
        {
            try
            {
                Instane.SaveChanges();
            }
            catch (Exception) { }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Goods> Goods { get; set; }
        public virtual DbSet<Offers> Offers { get; set; }
        public virtual DbSet<Offers_goods> Offers_goods { get; set; }
        public virtual DbSet<Payment_types> Payment_types { get; set; }
        public virtual DbSet<Provide_offers_goods> Provide_offers_goods { get; set; }
        public virtual DbSet<Providers> Providers { get; set; }

        public static void Close()
            => Instane.Dispose();
    }
}
