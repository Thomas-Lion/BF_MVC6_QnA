﻿// <auto-generated />
using System;
using MVC6_QAndA.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVC6_QAndA.DAL.Migrations
{
    [DbContext(typeof(QAndAContext))]
    partial class QAndAContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("MVC6_QAndA.DAL.Entities.AnswerEF", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AnswerTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Answering")
                        .HasColumnType("TEXT");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SaviorId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("SaviorId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("MVC6_QAndA.DAL.Entities.QuestionEF", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LostSoulId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Questioning")
                        .HasColumnType("TEXT");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("LostSoulId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("MVC6_QAndA.DAL.Entities.UserEF", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("UserEF");
                });

            modelBuilder.Entity("MVC6_QAndA.DAL.Entities.AnswerEF", b =>
                {
                    b.HasOne("MVC6_QAndA.DAL.Entities.QuestionEF", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId");

                    b.HasOne("MVC6_QAndA.DAL.Entities.UserEF", "Savior")
                        .WithMany()
                        .HasForeignKey("SaviorId");
                });

            modelBuilder.Entity("MVC6_QAndA.DAL.Entities.QuestionEF", b =>
                {
                    b.HasOne("MVC6_QAndA.DAL.Entities.UserEF", "LostSoul")
                        .WithMany("Questions")
                        .HasForeignKey("LostSoulId");
                });
#pragma warning restore 612, 618
        }
    }
}
