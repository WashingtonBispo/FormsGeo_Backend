﻿// <auto-generated />
using System;
using FormsGeo.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FormsGeo.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FormEntityUserEntity", b =>
                {
                    b.Property<int>("FormsidForm")
                        .HasColumnType("integer");

                    b.Property<string>("UsersEmail")
                        .HasColumnType("text");

                    b.HasKey("FormsidForm", "UsersEmail");

                    b.HasIndex("UsersEmail");

                    b.ToTable("FormEntityUserEntity");
                });

            modelBuilder.Entity("FormsGeo.Domain.Entities.FormEntity", b =>
                {
                    b.Property<int>("idForm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idForm"));

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("deletedAt")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("finalMessage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("gatherEnd")
                        .HasColumnType("boolean");

                    b.Property<bool>("gatherPassage")
                        .HasColumnType("boolean");

                    b.Property<string>("icon")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("linkConsent")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("questions")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("status")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("updatedAt")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("idForm");

                    b.ToTable("Form", (string)null);
                });

            modelBuilder.Entity("FormsGeo.Domain.Entities.UserEntity", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<bool>("isAdmin")
                        .HasColumnType("boolean");

                    b.HasKey("Email");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("FormEntityUserEntity", b =>
                {
                    b.HasOne("FormsGeo.Domain.Entities.FormEntity", null)
                        .WithMany()
                        .HasForeignKey("FormsidForm")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FormsGeo.Domain.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UsersEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
