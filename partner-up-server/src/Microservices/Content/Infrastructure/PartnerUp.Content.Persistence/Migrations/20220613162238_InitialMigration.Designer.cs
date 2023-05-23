﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PartnerUp.Content.Persistence;

#nullable disable

namespace PartnerUp.Content.Persistence.Migrations
{
    [DbContext(typeof(ContentDbContext))]
    [Migration("20220613162238_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PartnerUp.Content.Domain.Entities.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NotifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("NotifiedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NotifiedUserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("PartnerUp.Content.Domain.Entities.NotificationTemplate", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NotificationTemplates");

                    b.HasData(
                        new
                        {
                            Id = 0,
                            Message = "{FullName}, you were assigned to ticket: {TicketTitle}",
                            Title = "New ticket"
                        },
                        new
                        {
                            Id = 1,
                            Message = "{FullName}, deadline for assigned ticket is soon: {TicketTitle}, {TicketDeadline}",
                            Title = "Deadline reminder"
                        },
                        new
                        {
                            Id = 2,
                            Message = "{FullName}, you have new friend request!",
                            Title = "New friend"
                        },
                        new
                        {
                            Id = 3,
                            Message = "{FullName}, description of ticket changed: {TicketTitle}",
                            Title = "Ticket description changed"
                        });
                });

            modelBuilder.Entity("PartnerUp.Content.Domain.Entities.RecentRequest", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RequestedEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RecentRequestEntityType")
                        .HasColumnType("int");

                    b.Property<DateTime>("RequestedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RequestedEntityId", "RecentRequestEntityType");

                    b.HasIndex("UserProfileId");

                    b.ToTable("RecentRequests");
                });

            modelBuilder.Entity("PartnerUp.Content.Domain.Entities.UserProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Profession")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Specialization")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("UserProfiles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("61dfb9e3-1c27-424a-9963-9586ca110220"),
                            FirstName = "Ostap",
                            LastName = "Nice",
                            Profession = "Developer",
                            Specialization = "Backend"
                        },
                        new
                        {
                            Id = new Guid("3b333929-f974-444e-a8d3-68f50a0459c0"),
                            FirstName = "Esmaralda",
                            LastName = "Voigt",
                            Profession = "Developer",
                            Specialization = "Frontend"
                        },
                        new
                        {
                            Id = new Guid("a36b02e1-81a9-47f4-89b6-d33c4f40ed5f"),
                            FirstName = "Sophia",
                            LastName = "Beringer",
                            Specialization = "Fullstack"
                        },
                        new
                        {
                            Id = new Guid("013a2014-4a25-4a3d-9fae-e0f783d42ef9"),
                            FirstName = "Marlyn",
                            LastName = "Hendry",
                            Profession = "Artist"
                        },
                        new
                        {
                            Id = new Guid("ae557ffc-2906-4913-bd26-40aa98a55570"),
                            FirstName = "Vlasi",
                            LastName = "Arterberry",
                            Profession = "Designer",
                            Specialization = "Interier"
                        },
                        new
                        {
                            Id = new Guid("e5ca09a8-d3c6-4114-99a0-6b2f86ff1df2"),
                            FirstName = "Chasity",
                            LastName = "Ilbert"
                        },
                        new
                        {
                            Id = new Guid("bc0c5522-0a02-4f23-bb6a-319529716a94"),
                            FirstName = "Seraphina",
                            LastName = "Salmon",
                            Profession = "Developer",
                            Specialization = "Backend"
                        },
                        new
                        {
                            Id = new Guid("7484e532-dc8e-4005-8b67-15ad8a421a37"),
                            FirstName = "Chas",
                            LastName = "Hope",
                            Profession = "Designer"
                        },
                        new
                        {
                            Id = new Guid("3f036c83-88e8-4aeb-ad33-290d60cf6b66"),
                            FirstName = "Nadezhda",
                            LastName = "Haynes"
                        },
                        new
                        {
                            Id = new Guid("7ad5c481-f391-45bb-a79c-cfcb1adb448b"),
                            FirstName = "Sonny",
                            LastName = "Gibb",
                            Profession = "Tester"
                        },
                        new
                        {
                            Id = new Guid("0a906f06-fc52-417b-bc81-352df8bbe721"),
                            FirstName = "Eric",
                            LastName = "Lincoln",
                            Profession = "Designer"
                        });
                });

            modelBuilder.Entity("PartnerUp.Content.Domain.Entities.Notification", b =>
                {
                    b.HasOne("PartnerUp.Content.Domain.Entities.UserProfile", "NotifiedUser")
                        .WithMany("Notifications")
                        .HasForeignKey("NotifiedUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NotifiedUser");
                });

            modelBuilder.Entity("PartnerUp.Content.Domain.Entities.RecentRequest", b =>
                {
                    b.HasOne("PartnerUp.Content.Domain.Entities.UserProfile", null)
                        .WithMany("RecentRequests")
                        .HasForeignKey("UserProfileId");
                });

            modelBuilder.Entity("PartnerUp.Content.Domain.Entities.UserProfile", b =>
                {
                    b.Navigation("Notifications");

                    b.Navigation("RecentRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
