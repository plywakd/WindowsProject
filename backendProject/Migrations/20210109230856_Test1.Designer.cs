﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using backendProject.Models;

namespace backendProject.Migrations
{
    [DbContext(typeof(CustomContext))]
    [Migration("20210109230856_Test1")]
    partial class Test1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("backendProject.Models.Account", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("Last_logged")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("backendProject.Models.Game", b =>
                {
                    b.Property<int>("GameID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("difficulty")
                        .HasColumnType("integer");

                    b.Property<string>("gameName")
                        .HasColumnType("text");

                    b.Property<int>("maxMistakes")
                        .HasColumnType("integer");

                    b.Property<double>("minWordspeed")
                        .HasColumnType("double precision");

                    b.Property<int?>("textToWriteWritingTextID")
                        .HasColumnType("integer");

                    b.Property<int>("wordCount")
                        .HasColumnType("integer");

                    b.HasKey("GameID");

                    b.HasIndex("textToWriteWritingTextID");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("backendProject.Models.Result", b =>
                {
                    b.Property<int>("ResultID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int?>("GameID")
                        .HasColumnType("integer");

                    b.Property<int?>("accountID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("finish_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("isPassed")
                        .HasColumnType("boolean");

                    b.Property<List<string>>("mistakes")
                        .HasColumnType("text[]");

                    b.Property<double>("wordSpeed")
                        .HasColumnType("double precision");

                    b.HasKey("ResultID");

                    b.HasIndex("GameID");

                    b.HasIndex("accountID");

                    b.ToTable("Result");
                });

            modelBuilder.Entity("backendProject.Models.WritingText", b =>
                {
                    b.Property<int>("WritingTextID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<double>("averageSpeed")
                        .HasColumnType("double precision");

                    b.Property<string>("source")
                        .HasColumnType("text");

                    b.Property<string>("text")
                        .HasColumnType("text");

                    b.Property<double>("topSpeed")
                        .HasColumnType("double precision");

                    b.HasKey("WritingTextID");

                    b.ToTable("WritingText");
                });

            modelBuilder.Entity("backendProject.Models.Game", b =>
                {
                    b.HasOne("backendProject.Models.WritingText", "textToWrite")
                        .WithMany()
                        .HasForeignKey("textToWriteWritingTextID");

                    b.Navigation("textToWrite");
                });

            modelBuilder.Entity("backendProject.Models.Result", b =>
                {
                    b.HasOne("backendProject.Models.Game", "game")
                        .WithMany()
                        .HasForeignKey("GameID");

                    b.HasOne("backendProject.Models.Account", "account")
                        .WithMany()
                        .HasForeignKey("accountID");

                    b.Navigation("account");

                    b.Navigation("game");
                });
#pragma warning restore 612, 618
        }
    }
}
