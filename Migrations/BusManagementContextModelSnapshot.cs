﻿// <auto-generated />
using BusManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BusManagement.Migrations
{
    [DbContext(typeof(BusManagementContext))]
    partial class BusManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BusManagement.Models.Bus", b =>
                {
                    b.Property<int>("BusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BusId"), 1L, 1);

                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Routeid")
                        .HasColumnType("int");

                    b.Property<decimal>("Seats")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("BusId");

                    b.HasIndex("Routeid");

                    b.ToTable("Bus");
                });

            modelBuilder.Entity("BusManagement.Models.Roadroute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("FairPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("FromLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ToLocation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roadroute");
                });

            modelBuilder.Entity("BusManagement.Models.Bus", b =>
                {
                    b.HasOne("BusManagement.Models.Roadroute", "Id")
                        .WithMany()
                        .HasForeignKey("Routeid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Id");
                });
#pragma warning restore 612, 618
        }
    }
}
