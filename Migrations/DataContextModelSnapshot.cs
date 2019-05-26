﻿// <auto-generated />
using AspNetCoreMiniProfiler.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AspNetCoreMiniProfiler.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AspNetCoreMiniProfiler.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Will",
                            LastName = "May"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "James",
                            LastName = "San"
                        });
                });

            modelBuilder.Entity("AspNetCoreMiniProfiler.Models.ClientProduct", b =>
                {
                    b.Property<int>("ClientId");

                    b.Property<int>("ProductId");

                    b.HasKey("ClientId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ClientProducts");

                    b.HasData(
                        new
                        {
                            ClientId = 1,
                            ProductId = 1
                        },
                        new
                        {
                            ClientId = 1,
                            ProductId = 2
                        },
                        new
                        {
                            ClientId = 1,
                            ProductId = 5
                        },
                        new
                        {
                            ClientId = 1,
                            ProductId = 6
                        },
                        new
                        {
                            ClientId = 2,
                            ProductId = 2
                        },
                        new
                        {
                            ClientId = 2,
                            ProductId = 3
                        },
                        new
                        {
                            ClientId = 2,
                            ProductId = 5
                        },
                        new
                        {
                            ClientId = 2,
                            ProductId = 4
                        });
                });

            modelBuilder.Entity("AspNetCoreMiniProfiler.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "MacBook",
                            Price = 1500.0
                        },
                        new
                        {
                            Id = 2,
                            Name = "Iphone",
                            Price = 800.0
                        },
                        new
                        {
                            Id = 3,
                            Name = "Acer Predator Helios 300",
                            Price = 999.99000000000001
                        },
                        new
                        {
                            Id = 4,
                            Name = "Acer SB220Q",
                            Price = 89.989999999999995
                        },
                        new
                        {
                            Id = 5,
                            Name = "TP-Link AC1750 Smart Wifi Router",
                            Price = 56.990000000000002
                        },
                        new
                        {
                            Id = 6,
                            Name = "Logitek MK270 Wireless Keyboard and Mouse",
                            Price = 18.489999999999998
                        });
                });

            modelBuilder.Entity("AspNetCoreMiniProfiler.Models.ClientProduct", b =>
                {
                    b.HasOne("AspNetCoreMiniProfiler.Models.Client", "Client")
                        .WithMany("ClientProducts")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AspNetCoreMiniProfiler.Models.Product", "Product")
                        .WithMany("ClientProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
