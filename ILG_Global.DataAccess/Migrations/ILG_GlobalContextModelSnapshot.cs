﻿// <auto-generated />
using System;
using ILG_Global.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ILG_Global.DataAccess.Migrations
{
    [DbContext(typeof(ILG_GlobalContext))]
    partial class ILG_GlobalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ILG_Global.BussinessLogic.Models.HtmlContentDetail", b =>
                {
                    b.Property<int>("HtmlContentID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HtmlContentMasterID")
                        .HasColumnType("int");

                    b.Property<string>("LanguageCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SubTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HtmlContentID");

                    b.HasIndex("LanguageCode");

                    b.ToTable("HtmlContentDetails");
                });

            modelBuilder.Entity("ILG_Global.BussinessLogic.Models.HtmlContentMaster", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CanBeDeletedByUser")
                        .HasColumnType("bit");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("HtmlContentMasters");
                });

            modelBuilder.Entity("ILG_Global.BussinessLogic.Models.ImageDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AlternateText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ImageMasterID")
                        .HasColumnType("int");

                    b.Property<string>("LanguageCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ImageMasterID");

                    b.HasIndex("LanguageCode");

                    b.ToTable("ImageDetails");
                });

            modelBuilder.Entity("ILG_Global.BussinessLogic.Models.ImageMaster", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("SectionMasterID")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SectionMasterID");

                    b.ToTable("ImageMasters");
                });

            modelBuilder.Entity("ILG_Global.BussinessLogic.Models.Language", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Title")
                        .HasColumnType("int");

                    b.HasKey("Code");

                    b.ToTable("Language");
                });

            modelBuilder.Entity("ILG_Global.BussinessLogic.Models.SectionDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LanguageCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SectionMasterID")
                        .HasColumnType("int");

                    b.Property<string>("SectionTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("LanguageCode");

                    b.HasIndex("SectionMasterID");

                    b.ToTable("SectionDetails");
                });

            modelBuilder.Entity("ILG_Global.BussinessLogic.Models.SectionMaster", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("SectionMasters");
                });

            modelBuilder.Entity("ILG_Global.BussinessLogic.Models.SucessStoryDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LanguageCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("SucessStoryMasterID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("LanguageCode");

                    b.HasIndex("SucessStoryMasterID");

                    b.ToTable("SucessStoryDetails");
                });

            modelBuilder.Entity("ILG_Global.BussinessLogic.Models.SucessStoryMaster", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("SucessStoryMasters");
                });

            modelBuilder.Entity("ILG_Global.BussinessLogic.Models.HtmlContentDetail", b =>
                {
                    b.HasOne("ILG_Global.BussinessLogic.Models.HtmlContentMaster", "HtmlContentMaster")
                        .WithMany("HtmlContentDetails")
                        .HasForeignKey("HtmlContentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ILG_Global.BussinessLogic.Models.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageCode");

                    b.Navigation("HtmlContentMaster");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("ILG_Global.BussinessLogic.Models.ImageDetail", b =>
                {
                    b.HasOne("ILG_Global.BussinessLogic.Models.ImageMaster", "ImageMaster")
                        .WithMany()
                        .HasForeignKey("ImageMasterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ILG_Global.BussinessLogic.Models.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageCode");

                    b.Navigation("ImageMaster");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("ILG_Global.BussinessLogic.Models.ImageMaster", b =>
                {
                    b.HasOne("ILG_Global.BussinessLogic.Models.SectionMaster", "SectionMaster")
                        .WithMany()
                        .HasForeignKey("SectionMasterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SectionMaster");
                });

            modelBuilder.Entity("ILG_Global.BussinessLogic.Models.SectionDetail", b =>
                {
                    b.HasOne("ILG_Global.BussinessLogic.Models.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageCode");

                    b.HasOne("ILG_Global.BussinessLogic.Models.SectionMaster", "SectionMaster")
                        .WithMany()
                        .HasForeignKey("SectionMasterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("SectionMaster");
                });

            modelBuilder.Entity("ILG_Global.BussinessLogic.Models.SucessStoryDetail", b =>
                {
                    b.HasOne("ILG_Global.BussinessLogic.Models.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageCode");

                    b.HasOne("ILG_Global.BussinessLogic.Models.SucessStoryMaster", "SucessStoryMaster")
                        .WithMany()
                        .HasForeignKey("SucessStoryMasterID");

                    b.Navigation("Language");

                    b.Navigation("SucessStoryMaster");
                });

            modelBuilder.Entity("ILG_Global.BussinessLogic.Models.HtmlContentMaster", b =>
                {
                    b.Navigation("HtmlContentDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
