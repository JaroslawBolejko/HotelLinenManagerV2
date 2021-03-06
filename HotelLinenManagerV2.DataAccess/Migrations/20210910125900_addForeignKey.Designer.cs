// <auto-generated />
using System;
using HotelLinenManagerV2.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HotelLinenManagerV2.DataAccess.Migrations
{
    [DbContext(typeof(WarehauseStorageHotelLinenContext))]
    [Migration("20210910125900_addForeignKey")]
    partial class addForeignKey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApartmentNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("EMail")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TaxNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("TelefonNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.HotelLinen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("HotelLinenTypeId")
                        .HasColumnType("int");

                    b.Property<string>("NameWithShortDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("HotelLinenTypeId");

                    b.ToTable("HotelLinens");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.HotelLinenType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PricePerKg")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Tax")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.Property<byte>("TypeName")
                        .HasMaxLength(80)
                        .HasColumnType("tinyint");

                    b.Property<string>("Weight")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.ToTable("HotelLinenTypes");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.LaundryService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<bool>("IsFinished")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("IssuedDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Number")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("RecievedDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("LaundryServices");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.LaundryServiceDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("HotelLinenId")
                        .HasColumnType("int");

                    b.Property<int>("LaundryServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelLinenId");

                    b.HasIndex("LaundryServiceId");

                    b.ToTable("LaundryServiceDetails");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Permission")
                        .HasColumnType("int");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Workplace")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.Warehause", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("WarehauseNumber")
                        .HasColumnType("int");

                    b.Property<byte>("WarehauseType")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Warehauses");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.WarehauseDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("HotelLinenId")
                        .HasColumnType("int");

                    b.Property<int>("WarehauseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelLinenId");

                    b.HasIndex("WarehauseId");

                    b.ToTable("WarehauseDetails");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.HotelLinen", b =>
                {
                    b.HasOne("HotelLinenManagerV2.DataAccess.Entities.Company", "Company")
                        .WithMany("HotelLinens")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelLinenManagerV2.DataAccess.Entities.HotelLinenType", "HotelLinenType")
                        .WithMany("HotelLinens")
                        .HasForeignKey("HotelLinenTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("HotelLinenType");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.LaundryService", b =>
                {
                    b.HasOne("HotelLinenManagerV2.DataAccess.Entities.Company", "Company")
                        .WithMany("LaundryServices")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.LaundryServiceDetail", b =>
                {
                    b.HasOne("HotelLinenManagerV2.DataAccess.Entities.HotelLinen", "HotelLinen")
                        .WithMany()
                        .HasForeignKey("HotelLinenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelLinenManagerV2.DataAccess.Entities.LaundryService", "LaundryService")
                        .WithMany("LaundryServiceDetails")
                        .HasForeignKey("LaundryServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HotelLinen");

                    b.Navigation("LaundryService");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.User", b =>
                {
                    b.HasOne("HotelLinenManagerV2.DataAccess.Entities.Company", "Company")
                        .WithMany("Users")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.Warehause", b =>
                {
                    b.HasOne("HotelLinenManagerV2.DataAccess.Entities.Company", "Company")
                        .WithMany("Warehauses")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.WarehauseDetail", b =>
                {
                    b.HasOne("HotelLinenManagerV2.DataAccess.Entities.HotelLinen", "HotelLinen")
                        .WithMany("WarehauseDetails")
                        .HasForeignKey("HotelLinenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelLinenManagerV2.DataAccess.Entities.Warehause", "Warehause")
                        .WithMany("WarehauseDetails")
                        .HasForeignKey("WarehauseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HotelLinen");

                    b.Navigation("Warehause");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.Company", b =>
                {
                    b.Navigation("HotelLinens");

                    b.Navigation("LaundryServices");

                    b.Navigation("Users");

                    b.Navigation("Warehauses");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.HotelLinen", b =>
                {
                    b.Navigation("WarehauseDetails");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.HotelLinenType", b =>
                {
                    b.Navigation("HotelLinens");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.LaundryService", b =>
                {
                    b.Navigation("LaundryServiceDetails");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.Warehause", b =>
                {
                    b.Navigation("WarehauseDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
