﻿// <auto-generated />
using System;
using Fonour.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fonour.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(FonourDbContext))]
    partial class FonourDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Fonour.Domain.Entities.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("int");

                    b.Property<string>("Manager")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ae0f7027-185e-40dd-b190-9a3fb99d4ad7"),
                            Code = "001",
                            IsDeleted = 0,
                            Name = "Fonour集团总部",
                            ParentId = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("Fonour.Domain.Entities.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SerialNumber")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Menus");

                    b.HasData(
                        new
                        {
                            Id = new Guid("954f0113-8c95-4aac-a7ab-4932fe1b82ae"),
                            Code = "Department",
                            Icon = "fa fa-link",
                            Name = "组织机构管理",
                            ParentId = new Guid("00000000-0000-0000-0000-000000000000"),
                            SerialNumber = 0,
                            Type = 0,
                            Url = "/Department/Index"
                        },
                        new
                        {
                            Id = new Guid("d4f9fbfe-f1ba-4321-8847-e1522bf3f18b"),
                            Code = "Role",
                            Icon = "fa fa-link",
                            Name = "角色管理",
                            ParentId = new Guid("00000000-0000-0000-0000-000000000000"),
                            SerialNumber = 1,
                            Type = 0,
                            Url = "/Role/Index"
                        },
                        new
                        {
                            Id = new Guid("e19ef1a2-eb43-4ef3-9e54-613ec0caef5b"),
                            Code = "User",
                            Icon = "fa fa-link",
                            Name = "用户管理",
                            ParentId = new Guid("00000000-0000-0000-0000-000000000000"),
                            SerialNumber = 2,
                            Type = 0,
                            Url = "/User/Index"
                        },
                        new
                        {
                            Id = new Guid("eb7490d1-fb64-4de5-a8a1-43066b6d2611"),
                            Code = "Department",
                            Icon = "fa fa-link",
                            Name = "功能管理",
                            ParentId = new Guid("00000000-0000-0000-0000-000000000000"),
                            SerialNumber = 3,
                            Type = 0,
                            Url = "/Menu/Index"
                        });
                });

            modelBuilder.Entity("Fonour.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a57904bf-40a6-42a4-94b3-e738dffd46d7"),
                            Code = "001",
                            CreateUserId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Name = "超级管理员"
                        });
                });

            modelBuilder.Entity("Fonour.Domain.Entities.RoleMenu", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MenuId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoleId", "MenuId");

                    b.HasIndex("MenuId");

                    b.ToTable("RoleMenus");

                    b.HasData(
                        new
                        {
                            RoleId = new Guid("a57904bf-40a6-42a4-94b3-e738dffd46d7"),
                            MenuId = new Guid("954f0113-8c95-4aac-a7ab-4932fe1b82ae")
                        },
                        new
                        {
                            RoleId = new Guid("a57904bf-40a6-42a4-94b3-e738dffd46d7"),
                            MenuId = new Guid("d4f9fbfe-f1ba-4321-8847-e1522bf3f18b")
                        },
                        new
                        {
                            RoleId = new Guid("a57904bf-40a6-42a4-94b3-e738dffd46d7"),
                            MenuId = new Guid("e19ef1a2-eb43-4ef3-9e54-613ec0caef5b")
                        },
                        new
                        {
                            RoleId = new Guid("a57904bf-40a6-42a4-94b3-e738dffd46d7"),
                            MenuId = new Guid("eb7490d1-fb64-4de5-a8a1-43066b6d2611")
                        });
                });

            modelBuilder.Entity("Fonour.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastLoginTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("LoginTimes")
                        .HasColumnType("int");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("52c4babe-ff19-44e6-8e91-699a60f932d7"),
                            CreateUserId = new Guid("00000000-0000-0000-0000-000000000000"),
                            DepartmentId = new Guid("ae0f7027-185e-40dd-b190-9a3fb99d4ad7"),
                            IsDeleted = 0,
                            LastLoginTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LoginTimes = 0,
                            Name = "超级管理员",
                            Password = "123456",
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("Fonour.Domain.Entities.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("52c4babe-ff19-44e6-8e91-699a60f932d7"),
                            RoleId = new Guid("a57904bf-40a6-42a4-94b3-e738dffd46d7")
                        });
                });

            modelBuilder.Entity("Fonour.Domain.Entities.RoleMenu", b =>
                {
                    b.HasOne("Fonour.Domain.Entities.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fonour.Domain.Entities.Role", "Role")
                        .WithMany("RoleMenus")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Fonour.Domain.Entities.User", b =>
                {
                    b.HasOne("Fonour.Domain.Entities.Department", "Department")
                        .WithMany("Users")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Fonour.Domain.Entities.UserRole", b =>
                {
                    b.HasOne("Fonour.Domain.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fonour.Domain.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Fonour.Domain.Entities.Department", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Fonour.Domain.Entities.Role", b =>
                {
                    b.Navigation("RoleMenus");
                });

            modelBuilder.Entity("Fonour.Domain.Entities.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
