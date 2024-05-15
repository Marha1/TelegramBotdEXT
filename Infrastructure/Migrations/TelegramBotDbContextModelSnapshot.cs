﻿// <auto-generated />
using System;
using Infrastructure.Dal.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(TelegramBotDbContext))]
    partial class TelegramBotDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.3.24172.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CustomField<string>Person", b =>
                {
                    b.Property<Guid>("CustomFieldsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uuid");

                    b.HasKey("CustomFieldsId", "PersonId");

                    b.HasIndex("PersonId");

                    b.ToTable("CustomField<string>Person");
                });

            modelBuilder.Entity("Domain.Entities.CustomField<string>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.ToTable("CustomFields");
                });

            modelBuilder.Entity("Domain.Entities.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp")
                        .HasColumnName("birth_date");

                    b.Property<int>("Gender")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("gender");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<string>("Telegram")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("telegram");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("CustomField<string>Person", b =>
                {
                    b.HasOne("Domain.Entities.CustomField<string>", null)
                        .WithMany()
                        .HasForeignKey("CustomFieldsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Person", null)
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Person", b =>
                {
                    b.OwnsOne("Domain.Entities.ValueObjects.FullName", "FullName", b1 =>
                        {
                            b1.Property<Guid>("PersonId")
                                .HasColumnType("uuid");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("first_name");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("last_name");

                            b1.Property<string>("MiddleName")
                                .HasColumnType("text")
                                .HasColumnName("middle_name");

                            b1.HasKey("PersonId");

                            b1.ToTable("Persons");

                            b1.WithOwner()
                                .HasForeignKey("PersonId");
                        });

                    b.Navigation("FullName");
                });
#pragma warning restore 612, 618
        }
    }
}
