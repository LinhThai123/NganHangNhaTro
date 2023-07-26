using Microsoft.EntityFrameworkCore;
using NganHangNhaTro.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace NganHangNhaTro.Data
{
    public class MyDbContext : DbContext 
    {
        public MyDbContext() { }    
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public  DbSet<Agent> Agent { get; set; }

        public  DbSet<Level> Level { get; set; }
        public DbSet<RealEstate> RealEstate { get; set; }

        public DbSet<Picture> Picture { get; set; }

        public DbSet<RealEstateType> RealEstateType { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            // Cấu hình kiểu dữ liệu cho cột WifiPrice
            modelBuilder.Entity<RealEstate>()
                .Property(e => e.WifiPrice)
                .HasColumnType("decimal(18, 0)");

            modelBuilder.Entity<RealEstate>()
                .Property(e => e.Price)
                .HasColumnType("decimal(18, 0)");

        }

        internal IEnumerable<object> Set<T>(RealEstate realEstate)
        {
            throw new NotImplementedException();
        }
    }
    
}
