﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Yaba.Infrastructure.Persistence.Context;

namespace Yaba.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Yaba.Domain.Models.BankAccounts.BankAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("BK_Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Agency")
                        .IsRequired()
                        .HasColumnName("BK_Agency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("Code")
                        .HasColumnName("BK_Code")
                        .HasColumnType("smallint");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnName("BK_Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnName("BK_UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("BankAccounts");
                });

            modelBuilder.Entity("Yaba.Domain.Models.Transactions.Transaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TR_Id")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnName("TR_Amount")
                        .HasColumnType("decimal(12,2)");

                    b.Property<int?>("BankAccountId")
                        .HasColumnType("int");

                    b.Property<short?>("Category")
                        .HasColumnName("TR_Category")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("Date")
                        .HasColumnName("TR_Date")
                        .HasColumnType("date");

                    b.Property<string>("Origin")
                        .HasColumnName("TR_Origin")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("BankAccountId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Yaba.Domain.Models.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("US_Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("US_Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("US_Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("US_Password")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Yaba.Domain.Models.BankAccounts.BankAccount", b =>
                {
                    b.HasOne("Yaba.Domain.Models.Users.User", "User")
                        .WithMany("BankAccounts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Yaba.Domain.Models.Transactions.Transaction", b =>
                {
                    b.HasOne("Yaba.Domain.Models.BankAccounts.BankAccount", "BankAccount")
                        .WithMany("Transactions")
                        .HasForeignKey("BankAccountId");
                });
#pragma warning restore 612, 618
        }
    }
}
