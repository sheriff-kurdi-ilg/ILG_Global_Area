
using ILG_Global.BussinessLogic.Models;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.DataAccess
{
    public class ILG_GlobalContext:DbContext
    {
        public ILG_GlobalContext(DbContextOptions<ILG_GlobalContext> options) : base(options)
        {

        }

        public DbSet<ImageMaster> ImageMasters { get; set; }
        public DbSet<ImageDetail> ImageDetails { get; set; }
        public DbSet<SucessStoryDetail> SucessStoryDetails { get; set; }
        public DbSet<SucessStoryMaster> SucessStoryMasters { get; set; }

        public DbSet<HtmlContentMaster> HtmlContentMasters { get; set; }
        public DbSet<HtmlContentDetail> HtmlContentDetails { get; set; }

        public DbSet<OurServiceMaster> OurServiceMasters { get; set; }
        public DbSet<OurServiceDetail> OurServiceDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<SucessStoryDetail>()
                .HasKey(a => new { a.LanguageCode, a.SucessStoryID });  
            
            modelBuilder.Entity<ImageDetail>()
                .HasKey(a => new { a.LanguageCode, a.ImageID });

            modelBuilder.Entity<HtmlContentDetail>()
               .HasKey(a => new { a.LanguageCode, a.HtmlContentID });

            modelBuilder.Entity<OurServiceDetail>()
                .HasKey(a => new { a.LanguageCode, a.OurServiceID });




        }

    }

 
}
