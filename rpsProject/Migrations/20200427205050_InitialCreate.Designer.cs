﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using rpsProject;

namespace rpsProject.Migrations
{
    [DbContext(typeof(RPS_DbContext))]
    [Migration("20200427205050_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("rpsProject.Game", b =>
                {
                    b.Property<int>("GameID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Player1playerID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Player2playerID")
                        .HasColumnType("INTEGER");

                    b.HasKey("GameID");

                    b.HasIndex("Player1playerID");

                    b.HasIndex("Player2playerID");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("rpsProject.Player", b =>
                {
                    b.Property<int>("playerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerLosses")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PlayerName")
                        .HasColumnType("TEXT");

                    b.Property<int>("PlayerWins")
                        .HasColumnType("INTEGER");

                    b.HasKey("playerID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("rpsProject.Round", b =>
                {
                    b.Property<int>("roundID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GameID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Player1Choice")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Player2Choice")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("WinnerplayerID")
                        .HasColumnType("INTEGER");

                    b.HasKey("roundID");

                    b.HasIndex("GameID");

                    b.HasIndex("WinnerplayerID");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("rpsProject.Game", b =>
                {
                    b.HasOne("rpsProject.Player", "Player1")
                        .WithMany()
                        .HasForeignKey("Player1playerID");

                    b.HasOne("rpsProject.Player", "Player2")
                        .WithMany()
                        .HasForeignKey("Player2playerID");
                });

            modelBuilder.Entity("rpsProject.Round", b =>
                {
                    b.HasOne("rpsProject.Game", null)
                        .WithMany("Rounds")
                        .HasForeignKey("GameID");

                    b.HasOne("rpsProject.Player", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerplayerID");
                });
#pragma warning restore 612, 618
        }
    }
}
