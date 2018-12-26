using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Backend.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace Backend.DbContexts
{
    public class DbDispatchingSystem : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<DispatchList> DispatchLists { get; set; }
        public DbDispatchingSystem(DbContextOptions<DbDispatchingSystem> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            // 套用一些Json欄位的設定
            builder.ApplyConfiguration(new DispatchListConfiguration());
        }
    }
    public class DispatchListConfiguration : IEntityTypeConfiguration<DispatchList>
    {
        public void Configure(EntityTypeBuilder<DispatchList> builder)
        {
            builder.Property(e => e.CheckIn).HasConversion(
                v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                v => JsonConvert.DeserializeObject<IList<Record>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
            builder.Property(e => e.CheckOut).HasConversion(
                v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                v => JsonConvert.DeserializeObject<IList<Record>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        }
    }
}