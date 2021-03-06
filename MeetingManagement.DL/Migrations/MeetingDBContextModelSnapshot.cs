﻿// <auto-generated />
using System;
using MeetingManagement.DL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MeetingManagement.DL.Migrations
{
    [DbContext(typeof(MeetingDBContext))]
    partial class MeetingDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MeetingManagement.DL.Attendee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Attendees");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Attendee 1"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Attendee 2"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Attendee 3"
                        });
                });

            modelBuilder.Entity("MeetingManagement.DL.Meeting", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MeetingAgenda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MeetingDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Meetings");
                });

            modelBuilder.Entity("MeetingManagement.DL.MeetingAttendee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttendeeID")
                        .HasColumnType("int");

                    b.Property<int>("MeetingID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AttendeeID");

                    b.HasIndex("MeetingID");

                    b.ToTable("MeetingAttendees");
                });

            modelBuilder.Entity("MeetingManagement.DL.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Password = "pass1",
                            UserName = "user1"
                        },
                        new
                        {
                            ID = 2,
                            Password = "pass2",
                            UserName = "user2"
                        },
                        new
                        {
                            ID = 3,
                            Password = "pass3",
                            UserName = "user3"
                        });
                });

            modelBuilder.Entity("MeetingManagement.DL.MeetingAttendee", b =>
                {
                    b.HasOne("MeetingManagement.DL.Attendee", "Attendee")
                        .WithMany()
                        .HasForeignKey("AttendeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeetingManagement.DL.Meeting", "Meeting")
                        .WithMany()
                        .HasForeignKey("MeetingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
