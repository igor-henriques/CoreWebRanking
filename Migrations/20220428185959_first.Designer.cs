﻿// <auto-generated />
using System;
using CoreRankingAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoreRankingAPI.Migrations
{
    [DbContext(typeof(CoreRankingContext))]
    [Migration("20220428185959_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CoreRankingInfra.Model.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Ip")
                        .HasColumnType("longtext");

                    b.Property<string>("Login")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("CoreRankingInfra.Model.Banned", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("BanTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Banned");
                });

            modelBuilder.Entity("CoreRankingInfra.Model.Battle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("KilledId")
                        .HasColumnType("int");

                    b.Property<int>("KillerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KilledId");

                    b.HasIndex("KillerId");

                    b.ToTable("Battle");
                });

            modelBuilder.Entity("CoreRankingInfra.Model.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("CharacterClass")
                        .HasColumnType("longtext");

                    b.Property<string>("CharacterGender")
                        .HasColumnType("longtext");

                    b.Property<string>("CharacterName")
                        .HasColumnType("longtext");

                    b.Property<double>("CollectPoint")
                        .HasColumnType("double");

                    b.Property<int>("Death")
                        .HasColumnType("int");

                    b.Property<int>("Doublekill")
                        .HasColumnType("int");

                    b.Property<int>("Kill")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<DateTime>("LevelDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Pentakill")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("Quadrakill")
                        .HasColumnType("int");

                    b.Property<int>("Triplekill")
                        .HasColumnType("int");

                    b.HasKey("RoleId");

                    b.HasIndex("AccountId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("CoreRankingInfra.Model.Banned", b =>
                {
                    b.HasOne("CoreRankingInfra.Model.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CoreRankingInfra.Model.Battle", b =>
                {
                    b.HasOne("CoreRankingInfra.Model.Role", "KilledRole")
                        .WithMany()
                        .HasForeignKey("KilledId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoreRankingInfra.Model.Role", "KillerRole")
                        .WithMany()
                        .HasForeignKey("KillerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KilledRole");

                    b.Navigation("KillerRole");
                });

            modelBuilder.Entity("CoreRankingInfra.Model.Role", b =>
                {
                    b.HasOne("CoreRankingInfra.Model.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });
#pragma warning restore 612, 618
        }
    }
}
