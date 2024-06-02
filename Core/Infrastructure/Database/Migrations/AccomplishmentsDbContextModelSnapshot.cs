﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TedOliviaAccomplishmentsApi.Core.Infrastructure.Database;

#nullable disable

namespace TedOliviaAccomplishmentsApi.Core.Infrastructure.Database.Migrations
{
    [DbContext(typeof(AccomplishmentsDbContext))]
    partial class AccomplishmentsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TedOliviaAccomplishmentsApi.Core.Infrastructure.Database.Entities.Accomplishment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<bool>("IsDone")
                        .HasColumnType("boolean")
                        .HasColumnName("is_done");

                    b.Property<DateTimeOffset>("ModifiedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("note");

                    b.Property<int>("Owner")
                        .HasColumnType("integer")
                        .HasColumnName("owner");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("pk_accomplishments");

                    b.ToTable("accomplishments", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}