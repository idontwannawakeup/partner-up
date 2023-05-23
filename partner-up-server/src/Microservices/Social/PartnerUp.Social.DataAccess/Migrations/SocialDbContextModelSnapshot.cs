﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PartnerUp.Social.DataAccess;

#nullable disable

namespace PartnerUp.Social.DataAccess.Migrations
{
    [DbContext(typeof(SocialDbContext))]
    partial class SocialDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PartnerUp.Social.DataAccess.Entities.Rating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("ntext");

                    b.Property<Guid>("FromId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Punctuality")
                        .HasColumnType("int");

                    b.Property<int>("Responsibility")
                        .HasColumnType("int");

                    b.Property<int>("Skills")
                        .HasColumnType("int");

                    b.Property<int>("Social")
                        .HasColumnType("int");

                    b.Property<Guid>("ToId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasAlternateKey("FromId", "ToId")
                        .HasName("AK_Ratings_FromId_ToId");

                    b.HasIndex("ToId");

                    b.ToTable("Ratings");

                    b.HasData(
                        new
                        {
                            Id = new Guid("05fa2b57-f3cb-4053-bd7a-d4a3669b596f"),
                            Comment = "Just a great person",
                            FromId = new Guid("3b333929-f974-444e-a8d3-68f50a0459c0"),
                            Punctuality = 4,
                            Responsibility = 5,
                            Skills = 5,
                            Social = 5,
                            ToId = new Guid("61dfb9e3-1c27-424a-9963-9586ca110220")
                        });
                });

            modelBuilder.Entity("PartnerUp.Social.DataAccess.Entities.UserProfile", b =>
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

            modelBuilder.Entity("UserProfileUserProfile", b =>
                {
                    b.Property<Guid>("FriendForUsersId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("SecondId");

                    b.Property<Guid>("FriendsId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("FirstId");

                    b.HasKey("FriendForUsersId", "FriendsId");

                    b.HasIndex("FriendsId");

                    b.ToTable("Friends", (string)null);
                });

            modelBuilder.Entity("PartnerUp.Social.DataAccess.Entities.Rating", b =>
                {
                    b.HasOne("PartnerUp.Social.DataAccess.Entities.UserProfile", "From")
                        .WithMany("MyRatings")
                        .HasForeignKey("FromId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Ratings_FromId");

                    b.HasOne("PartnerUp.Social.DataAccess.Entities.UserProfile", "To")
                        .WithMany("RatingsFromMe")
                        .HasForeignKey("ToId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Ratings_ToId");

                    b.Navigation("From");

                    b.Navigation("To");
                });

            modelBuilder.Entity("UserProfileUserProfile", b =>
                {
                    b.HasOne("PartnerUp.Social.DataAccess.Entities.UserProfile", null)
                        .WithMany()
                        .HasForeignKey("FriendForUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PartnerUp.Social.DataAccess.Entities.UserProfile", null)
                        .WithMany()
                        .HasForeignKey("FriendsId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PartnerUp.Social.DataAccess.Entities.UserProfile", b =>
                {
                    b.Navigation("MyRatings");

                    b.Navigation("RatingsFromMe");
                });
#pragma warning restore 612, 618
        }
    }
}