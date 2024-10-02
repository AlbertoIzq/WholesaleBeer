﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WholesaleBeer.API.Data;

#nullable disable

namespace WholesaleBeer.API.Migrations
{
    [DbContext(typeof(WholesaleBeerDbContext))]
    [Migration("20241002000022_seedBreweryAndWholesaler")]
    partial class seedBreweryAndWholesaler
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WholesaleBeer.API.Models.Domain.Beer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("AlcoholContentPercentage")
                        .HasColumnType("real");

                    b.Property<Guid>("BreweryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("BreweryId");

                    b.ToTable("Beers");
                });

            modelBuilder.Entity("WholesaleBeer.API.Models.Domain.BeerStock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BeerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("StockLeft")
                        .HasColumnType("int");

                    b.Property<Guid>("WholesalerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BeerId");

                    b.HasIndex("WholesalerId");

                    b.ToTable("BeerStocks");
                });

            modelBuilder.Entity("WholesaleBeer.API.Models.Domain.Brewery", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Breweries");

                    b.HasData(
                        new
                        {
                            Id = new Guid("53965366-20b3-4f2d-9972-a886d6972c1f"),
                            Name = "Abbaye St Sixte Westvleteren"
                        },
                        new
                        {
                            Id = new Guid("62410140-4fb9-4662-8ef6-b5aa9dd7aa5d"),
                            Name = "Abbaye Notre Dame du Sacre Coeur de Westmalle"
                        },
                        new
                        {
                            Id = new Guid("91d8c67c-c92b-48a4-95b3-77182bfcbf73"),
                            Name = "Abbaye Notre Dame de St Remy"
                        },
                        new
                        {
                            Id = new Guid("8db2bb14-5ae6-4894-9aab-205d29bfb176"),
                            Name = "Abbaye d'Orval"
                        },
                        new
                        {
                            Id = new Guid("36a69969-2a36-4f96-b037-b5603fe94a78"),
                            Name = "Abbaye de Notre Dame de Scourmont"
                        });
                });

            modelBuilder.Entity("WholesaleBeer.API.Models.Domain.OrderDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BeerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("WholesalerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BeerId");

                    b.HasIndex("WholesalerId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("WholesaleBeer.API.Models.Domain.Wholesaler", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Wholesalers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9fc5f185-c6c3-4bcd-90c0-74e35304d69c"),
                            Name = "Belgibeer"
                        },
                        new
                        {
                            Id = new Guid("5c8e5f49-652b-42b0-8418-cd5a0ddba3fd"),
                            Name = "Bollaert Wijnhuis"
                        },
                        new
                        {
                            Id = new Guid("57ed2087-b816-4dcd-a3f1-3451822bb545"),
                            Name = "Bierhandel Dekoninck"
                        },
                        new
                        {
                            Id = new Guid("34acf5ff-19c2-477c-8a5b-b89b479002ce"),
                            Name = "Drinks Center Fontana"
                        },
                        new
                        {
                            Id = new Guid("0ffec24c-e643-410d-aafb-e0cefa0934b1"),
                            Name = "Drink Services - Brasserie Corman"
                        });
                });

            modelBuilder.Entity("WholesaleBeer.API.Models.Domain.Beer", b =>
                {
                    b.HasOne("WholesaleBeer.API.Models.Domain.Brewery", "Brewery")
                        .WithMany()
                        .HasForeignKey("BreweryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brewery");
                });

            modelBuilder.Entity("WholesaleBeer.API.Models.Domain.BeerStock", b =>
                {
                    b.HasOne("WholesaleBeer.API.Models.Domain.Beer", "Beer")
                        .WithMany()
                        .HasForeignKey("BeerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WholesaleBeer.API.Models.Domain.Wholesaler", "Wholesaler")
                        .WithMany()
                        .HasForeignKey("WholesalerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Beer");

                    b.Navigation("Wholesaler");
                });

            modelBuilder.Entity("WholesaleBeer.API.Models.Domain.OrderDetail", b =>
                {
                    b.HasOne("WholesaleBeer.API.Models.Domain.Beer", "Beer")
                        .WithMany()
                        .HasForeignKey("BeerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WholesaleBeer.API.Models.Domain.Wholesaler", "Wholesaler")
                        .WithMany()
                        .HasForeignKey("WholesalerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Beer");

                    b.Navigation("Wholesaler");
                });
#pragma warning restore 612, 618
        }
    }
}
