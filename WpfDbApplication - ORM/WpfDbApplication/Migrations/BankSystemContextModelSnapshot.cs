﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WpfDbApplication.DbContexts;

namespace WpfDbApplication.Migrations
{
    [DbContext(typeof(BankSystemContext))]
    partial class BankSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.14");

            modelBuilder.Entity("WpfDbApplication.DTOs.AccountDto", b =>
                {
                    b.Property<string>("Uuid")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CardId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("Money")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nationality")
                        .HasColumnType("TEXT");

                    b.HasKey("Uuid");

                    b.ToTable("AccountDtos");
                });

            modelBuilder.Entity("WpfDbApplication.DTOs.CardDto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("cardNum")
                        .HasColumnType("TEXT");

                    b.Property<int>("cvv")
                        .HasColumnType("INTEGER");

                    b.Property<string>("expDate")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("CardDtos");
                });
#pragma warning restore 612, 618
        }
    }
}
