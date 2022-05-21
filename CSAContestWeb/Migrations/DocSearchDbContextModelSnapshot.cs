﻿// <auto-generated />
using CSAContestWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CSAContestWeb.Migrations
{
    [DbContext(typeof(DocSearchDbContext))]
    partial class DocSearchDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CSAContestWeb.Models.DocumentModel", b =>
                {
                    b.Property<int>("DocSearchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocSearchId"), 1L, 1);

                    b.Property<string>("BirdFindLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateInvoice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DonorAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DonorApt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DonorCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DonorEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DonorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DonorPostal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DonorTel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GiftConsideration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiverBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StoragePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SumGifted")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxReceipt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DocSearchId");

                    b.ToTable("DocSearch");

                    b.HasData(
                        new
                        {
                            DocSearchId = 1,
                            BirdFindLocation = "Dallas",
                            DateInvoice = "05/09/2022",
                            DonorAddress = "",
                            DonorApt = "",
                            DonorCity = "",
                            DonorEmail = "",
                            DonorName = "Kone",
                            DonorPostal = "",
                            DonorTel = "",
                            GiftConsideration = "",
                            ReceiverBy = "nape",
                            StoragePath = "kljghdgfsgfjhjh",
                            SumGifted = "",
                            TaxReceipt = ""
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
