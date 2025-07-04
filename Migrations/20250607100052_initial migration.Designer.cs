﻿// <auto-generated />
using BelleAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BelleAPI.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20250607100052_initial migration")]
    partial class initialmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BelleAPI.Models.Entities.item", b =>
                {
                    b.Property<string>("kode_item")
                        .HasColumnType("text");

                    b.Property<decimal>("harga")
                        .HasColumnType("numeric");

                    b.Property<string>("keterangan")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("satuan")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("kode_item");

                    b.ToTable("items");
                });
#pragma warning restore 612, 618
        }
    }
}
