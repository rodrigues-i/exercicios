﻿// <auto-generated />
using System;
using CrudClientes.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CrudClientes.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220815170453_firstNameNowRequired")]
    partial class firstNameNowRequired
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CrudClientes.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<DateTime?>("creationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("surname")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
