﻿// <auto-generated />
using System;
using Interparking.Planner.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Interparking.Planner.Data.Migrations
{
    [DbContext(typeof(InterparkingPlannerDbContext))]
    [Migration("20200616094947_BaseParkings")]
    partial class BaseParkings
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Interparking.Planner.Data.Contracts.Models.Parking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DisabledSpaces")
                        .HasColumnType("int");

                    b.Property<string>("Latitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("MaxHeight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Spaces")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Parkings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "bvd de Waterloo 2a, 1000 Bruxelles",
                            Description = "Le parking se situe en plein cœur d'un quartier commercial et du cinéma UGC Toison d'Or.",
                            DisabledSpaces = 32,
                            Latitude = "50.838497",
                            Longitude = "4.361148",
                            MaxHeight = 2.1m,
                            Name = "2 Portes (Bruxelles)",
                            Spaces = 719
                        },
                        new
                        {
                            Id = 2,
                            Address = "Place de la Justice 16, 1000 Bruxelles",
                            Description = "Le parking se situe sous le Square, lieu d'évènements innombrables. Il est également à deux pas du Palais des Beaux Arts, du Musée Magritte et du Musée des Instruments de Musique.",
                            DisabledSpaces = 15,
                            Latitude = "50.843919",
                            Longitude = "4.354608",
                            MaxHeight = 2m,
                            Name = "Albertine-Square (Bruxelles)",
                            Spaces = 714
                        },
                        new
                        {
                            Id = 3,
                            Address = "Brussels Airport, 1930 Zaventem",
                            Description = @"Le parking se trouve en face du terminal de départ de Brussels Airport.

Parfait pour l'homme d'affaires qui arrive juste à temps pour le check in.

Pour y accéder, entrez dans le parking P1 Front et suivez les indications Fast Zone.",
                            DisabledSpaces = 3,
                            Latitude = "50.897399",
                            Longitude = "4.481088",
                            MaxHeight = 2.1m,
                            Name = "P1 Fast Zone level 3 (Zaventem)",
                            Spaces = 166
                        });
                });

            modelBuilder.Entity("Interparking.Planner.Data.Contracts.Models.Point", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Latitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RouteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RouteId");

                    b.ToTable("Point");
                });

            modelBuilder.Entity("Interparking.Planner.Data.Contracts.Models.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EndPointId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("StartPointId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EndPointId");

                    b.HasIndex("StartPointId");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("Interparking.Planner.Data.Contracts.Models.Point", b =>
                {
                    b.HasOne("Interparking.Planner.Data.Contracts.Models.Route", null)
                        .WithMany("WayPoints")
                        .HasForeignKey("RouteId");
                });

            modelBuilder.Entity("Interparking.Planner.Data.Contracts.Models.Route", b =>
                {
                    b.HasOne("Interparking.Planner.Data.Contracts.Models.Point", "EndPoint")
                        .WithMany()
                        .HasForeignKey("EndPointId");

                    b.HasOne("Interparking.Planner.Data.Contracts.Models.Point", "StartPoint")
                        .WithMany()
                        .HasForeignKey("StartPointId");
                });
#pragma warning restore 612, 618
        }
    }
}
