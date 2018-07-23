﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WPFAspire.Database;

namespace WPFAspire.Database.Migrations
{
    [DbContext(typeof(AspireDbContext))]
    [Migration("20180722200505_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WPFAspire.Database.Entities.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateOfBirth");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("WPFAspire.Database.Entities.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adreess");

                    b.Property<int?>("ContactId");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("Email");
                });

            modelBuilder.Entity("WPFAspire.Database.Entities.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ContactId");

                    b.Property<string>("Number");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("Phone");
                });

            modelBuilder.Entity("WPFAspire.Database.Entities.Email", b =>
                {
                    b.HasOne("WPFAspire.Database.Entities.Contact", "Contact")
                        .WithMany("Emails")
                        .HasForeignKey("ContactId");
                });

            modelBuilder.Entity("WPFAspire.Database.Entities.Phone", b =>
                {
                    b.HasOne("WPFAspire.Database.Entities.Contact", "Contact")
                        .WithMany("Phones")
                        .HasForeignKey("ContactId");
                });
#pragma warning restore 612, 618
        }
    }
}
