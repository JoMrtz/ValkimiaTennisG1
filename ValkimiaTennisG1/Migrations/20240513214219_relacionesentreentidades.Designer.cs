﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ValkimiaTennisG1.Repository;

#nullable disable

namespace ValkimiaTennisG1.Migrations
{
    [DbContext(typeof(TennisContext))]
    [Migration("20240513214219_relacionesentreentidades")]
    partial class relacionesentreentidades
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ValkimiaTennisG1.Models.Entities.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GenderType")
                        .HasColumnType("int")
                        .HasColumnName("GenderType");

                    b.HasKey("Id");

                    b.ToTable("Gender", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GenderType = 0
                        },
                        new
                        {
                            Id = 2,
                            GenderType = 1
                        });
                });

            modelBuilder.Entity("ValkimiaTennisG1.Models.Entities.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date")
                        .HasColumnName("Date");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId");

                    b.ToTable("Match", (string)null);
                });

            modelBuilder.Entity("ValkimiaTennisG1.Models.Entities.MatchPlayer", b =>
                {
                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<bool>("Winner")
                        .HasColumnType("bit");

                    b.HasKey("MatchId", "PlayerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("MatchPlayer", (string)null);
                });

            modelBuilder.Entity("ValkimiaTennisG1.Models.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Ability")
                        .HasMaxLength(2)
                        .HasColumnType("int")
                        .HasColumnName("Ability");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name");

                    b.Property<int?>("ReactionTime")
                        .HasMaxLength(2)
                        .HasColumnType("int")
                        .HasColumnName("ReactionTime");

                    b.Property<int?>("Speed")
                        .HasMaxLength(2)
                        .HasColumnType("int")
                        .HasColumnName("Speed");

                    b.Property<int?>("Strength")
                        .HasMaxLength(2)
                        .HasColumnType("int")
                        .HasColumnName("Strength");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.ToTable("Player", (string)null);
                });

            modelBuilder.Entity("ValkimiaTennisG1.Models.Entities.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CourtType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("CourtType");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Location");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name");

                    b.Property<int>("Winner")
                        .HasColumnType("int")
                        .HasColumnName("Winner");

                    b.HasKey("Id");

                    b.ToTable("Tournament", (string)null);
                });

            modelBuilder.Entity("ValkimiaTennisG1.Models.Entities.Match", b =>
                {
                    b.HasOne("ValkimiaTennisG1.Models.Entities.Tournament", "Tournament")
                        .WithMany("Matches")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("ValkimiaTennisG1.Models.Entities.MatchPlayer", b =>
                {
                    b.HasOne("ValkimiaTennisG1.Models.Entities.Match", "Match")
                        .WithMany("MatchPlayers")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ValkimiaTennisG1.Models.Entities.Player", "Player")
                        .WithMany("MatchPlayers")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("ValkimiaTennisG1.Models.Entities.Player", b =>
                {
                    b.HasOne("ValkimiaTennisG1.Models.Entities.Gender", "Gender")
                        .WithMany("Players")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("ValkimiaTennisG1.Models.Entities.Gender", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("ValkimiaTennisG1.Models.Entities.Match", b =>
                {
                    b.Navigation("MatchPlayers");
                });

            modelBuilder.Entity("ValkimiaTennisG1.Models.Entities.Player", b =>
                {
                    b.Navigation("MatchPlayers");
                });

            modelBuilder.Entity("ValkimiaTennisG1.Models.Entities.Tournament", b =>
                {
                    b.Navigation("Matches");
                });
#pragma warning restore 612, 618
        }
    }
}
