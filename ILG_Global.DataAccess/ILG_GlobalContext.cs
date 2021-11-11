
using ILG_Global.BussinessLogic.Models;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.DataAccess
{
    public class ILG_GlobalContext : DbContext
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

        public DbSet<ContactInformationMaster> ContactInformationMasters { get; set; }
        public DbSet<ContactInformationDetail> ContactInformationDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<SucessStoryDetail>()
                .HasKey(a => new {  a.SucessStoryID, a.LanguageCode });  
            
            modelBuilder.Entity<ImageDetail>()
                .HasKey(a => new {  a.ImageID, a.LanguageCode });

            modelBuilder.Entity<HtmlContentDetail>()
               .HasKey(a => new {  a.HtmlContentID, a.LanguageCode });

            modelBuilder.Entity<OurServiceDetail>()
                .HasKey(a => new {  a.OurServiceID, a.LanguageCode });

            modelBuilder.Entity<ContactInformationDetail>()
                .HasKey(a => new {  a.ContactInformationID, a.LanguageCode, });


        }

    }

 
}
