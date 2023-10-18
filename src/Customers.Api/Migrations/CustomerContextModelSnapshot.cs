﻿// <auto-generated />
using System;
using Customers.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Customers.Api.Migrations
{
    [DbContext(typeof(CustomerContext))]
    partial class CustomerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("Customers.Api.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .HasColumnType("varchar(150)")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("country");

                    b.Property<string>("PostalCode")
                        .HasColumnType("varchar(9)")
                        .HasColumnName("postal_code");

                    b.Property<string>("State")
                        .HasColumnType("varchar(2)")
                        .HasColumnName("state");

                    b.Property<string>("Street")
                        .HasColumnType("varchar(80)")
                        .HasColumnName("street");

                    b.Property<Guid?>("customer_id")
                        .HasColumnType("TEXT");

                    b.HasKey("Id")
                        .HasName("id_address");

                    b.HasIndex("customer_id");

                    b.ToTable("addresses", (string)null);
                });

            modelBuilder.Entity("Customers.Api.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<short>("Age")
                        .HasColumnType("int")
                        .HasColumnName("age");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(150)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("id_customer");

                    b.ToTable("customers", (string)null);
                });

            modelBuilder.Entity("Customers.Api.Models.Address", b =>
                {
                    b.HasOne("Customers.Api.Models.Customer", null)
                        .WithMany("Address")
                        .HasForeignKey("customer_id");
                });

            modelBuilder.Entity("Customers.Api.Models.Customer", b =>
                {
                    b.Navigation("Address");
                });
#pragma warning restore 612, 618
        }
    }
}