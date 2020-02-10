﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using beltexam2.Models;

namespace beltexam2.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20191219210705_beltexam27")]
    partial class beltexam27
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("beltexam2.Models.Association", b =>
                {
                    b.Property<int>("AssociationId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("HobbyId");

                    b.Property<int>("UserId");

                    b.HasKey("AssociationId");

                    b.HasIndex("HobbyId");

                    b.HasIndex("UserId");

                    b.ToTable("Associations");
                });

            modelBuilder.Entity("beltexam2.Models.Hobby", b =>
                {
                    b.Property<int>("HobbyId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatorId");

                    b.Property<DateTime>("HobbyDate");

                    b.Property<string>("HobbyDescription")
                        .IsRequired();

                    b.Property<string>("HobbyName")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("HobbyId");

                    b.HasIndex("CreatorId");

                    b.ToTable("Hobbies");
                });

            modelBuilder.Entity("beltexam2.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("beltexam2.Models.Association", b =>
                {
                    b.HasOne("beltexam2.Models.Hobby", "aHobby")
                        .WithMany("Responses")
                        .HasForeignKey("HobbyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("beltexam2.Models.User", "addtohobbys")
                        .WithMany("Participants")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("beltexam2.Models.Hobby", b =>
                {
                    b.HasOne("beltexam2.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
