﻿// <auto-generated />
using System;
using DbFirst.Models2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DbFirst.Migrations.MyTodoDb
{
    [DbContext(typeof(MyTodoDbContext))]
    [Migration("20230829124130_mg10")]
    partial class mg10
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DbFirst.Models2.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("DbFirst.Models2.Todo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<string>("Work")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Todos");
                });

            modelBuilder.Entity("DbFirst.Models2.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Provider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpires")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DbFirst.Models2.UserRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "RoleId" }, "IX_UserRoles_RoleId");

                    b.HasIndex(new[] { "UserId" }, "IX_UserRoles_UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("DbFirst.Models2.UserRole", b =>
                {
                    b.HasOne("DbFirst.Models2.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId");

                    b.HasOne("DbFirst.Models2.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId");

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DbFirst.Models2.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("DbFirst.Models2.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
