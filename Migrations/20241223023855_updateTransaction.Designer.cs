﻿// <auto-generated />
using System;
using Banking_system.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Banking_system.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241223023855_updateTransaction")]
    partial class updateTransaction
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Banking_system.DataInstanse.AppUser", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("balanc")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("passwordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("passwordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("appUser");
                });

            modelBuilder.Entity("Banking_system.DataInstanse.Transaction", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("mountOfTransaction")
                        .HasColumnType("int");

                    b.Property<int>("receiverId")
                        .HasColumnType("int");

                    b.Property<int>("senderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("time")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("receiverId");

                    b.HasIndex("senderId");

                    b.ToTable("transaction");
                });

            modelBuilder.Entity("Banking_system.DataInstanse.Transaction", b =>
                {
                    b.HasOne("Banking_system.DataInstanse.AppUser", "receiver")
                        .WithMany("receive")
                        .HasForeignKey("receiverId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Banking_system.DataInstanse.AppUser", "sender")
                        .WithMany("send")
                        .HasForeignKey("senderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("receiver");

                    b.Navigation("sender");
                });

            modelBuilder.Entity("Banking_system.DataInstanse.AppUser", b =>
                {
                    b.Navigation("receive");

                    b.Navigation("send");
                });
#pragma warning restore 612, 618
        }
    }
}
