using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationSyscompsa.Controllers.Restaurant;

namespace WebApplicationSyscompsa.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Rola110> Rola110 { get; set; }
        public DbSet<AdapMesa> AdapMesa { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region
            modelBuilder.Entity<Rola110>().HasNoKey();
            #endregion

        }



    }
}
