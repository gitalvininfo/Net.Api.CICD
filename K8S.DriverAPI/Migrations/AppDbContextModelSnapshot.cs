﻿// <auto-generated />
using System;
using K8S.DriverAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace K8S.DriverAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("K8S.DriverAPI.Models.Driver", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("DriverNumber")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Drivers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2533a92b-16ae-4a4f-ab9d-9a2a1c229a0a"),
                            AddedDate = new DateTime(2024, 10, 23, 4, 24, 44, 813, DateTimeKind.Utc).AddTicks(4410),
                            DateOfBirth = new DateTime(1985, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DriverNumber = 44,
                            FirstName = "Lewis",
                            LastName = "Hamilton",
                            Status = 1,
                            UpdatedDate = new DateTime(2024, 10, 23, 4, 24, 44, 813, DateTimeKind.Utc).AddTicks(4415)
                        },
                        new
                        {
                            Id = new Guid("bae4eb9d-6347-4e11-b886-f2880b65797e"),
                            AddedDate = new DateTime(2024, 10, 23, 4, 24, 44, 813, DateTimeKind.Utc).AddTicks(4423),
                            DateOfBirth = new DateTime(1997, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DriverNumber = 33,
                            FirstName = "Max",
                            LastName = "Verstappen",
                            Status = 1,
                            UpdatedDate = new DateTime(2024, 10, 23, 4, 24, 44, 813, DateTimeKind.Utc).AddTicks(4423)
                        },
                        new
                        {
                            Id = new Guid("86a3df6c-cf33-48f9-9f39-7ea8d0c6c8b6"),
                            AddedDate = new DateTime(2024, 10, 23, 4, 24, 44, 813, DateTimeKind.Utc).AddTicks(4425),
                            DateOfBirth = new DateTime(1997, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DriverNumber = 16,
                            FirstName = "Charles",
                            LastName = "Leclerc",
                            Status = 1,
                            UpdatedDate = new DateTime(2024, 10, 23, 4, 24, 44, 813, DateTimeKind.Utc).AddTicks(4425)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
