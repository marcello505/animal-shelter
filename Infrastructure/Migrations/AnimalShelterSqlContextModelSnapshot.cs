﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AnimalShelterSqlContext))]
    partial class AnimalShelterSqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Models.AdoptionRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Animal1")
                        .HasColumnType("int");

                    b.Property<int?>("Animal2")
                        .HasColumnType("int");

                    b.Property<int?>("Animal3")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AdoptionRequests");
                });

            modelBuilder.Entity("Core.Models.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Adoptable")
                        .HasColumnType("bit");

                    b.Property<string>("AdoptedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Breed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CageId")
                        .HasColumnType("int");

                    b.Property<bool>("CastratedOrSterilized")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DateOfAdoption")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfArrival")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfDeath")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DogOrCat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EstimatedAge")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReasonForLeavingOwner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("SafeForKids")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CageId");

                    b.ToTable("Animals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Adoptable = true,
                            Breed = "LapjesKat",
                            CastratedOrSterilized = true,
                            DateOfArrival = new DateTime(2020, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Een mooie lapjeskat",
                            DogOrCat = "cat",
                            EstimatedAge = 18,
                            Gender = "f",
                            Name = "Carolientje",
                            ReasonForLeavingOwner = "Eigenaar had het te druk met werk.",
                            SafeForKids = true
                        },
                        new
                        {
                            Id = 2,
                            Adoptable = true,
                            Breed = "Amerikaanse Korthaar",
                            CastratedOrSterilized = true,
                            DateOfArrival = new DateTime(2020, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Een brutale kater",
                            DogOrCat = "cat",
                            EstimatedAge = 15,
                            Gender = "m",
                            Name = "Tom",
                            ReasonForLeavingOwner = "Veel te eigenwijs en iritant.",
                            SafeForKids = false
                        });
                });

            modelBuilder.Entity("Core.Models.AnimalSubmission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CastratedOrSterilized")
                        .HasColumnType("bit");

                    b.Property<string>("DogOrCat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReasonForLeavingOwner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AnimalSubmissions");
                });

            modelBuilder.Entity("Core.Models.Cage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaximumAnimals")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cages");
                });

            modelBuilder.Entity("Core.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AnimalId")
                        .HasColumnType("int");

                    b.Property<string>("CommentMadeBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfComment")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Core.Models.Treatment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AnimalId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Cost")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("DateOfTreatment")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MinimumAgeInMonths")
                        .HasColumnType("int");

                    b.Property<string>("TreatmentDoneBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.ToTable("Treatments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnimalId = 1,
                            DateOfTreatment = new DateTime(2005, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TreatmentDoneBy = "Marcello",
                            Type = 0
                        },
                        new
                        {
                            Id = 2,
                            AnimalId = 2,
                            DateOfTreatment = new DateTime(2008, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TreatmentDoneBy = "Dirk",
                            Type = 1
                        });
                });

            modelBuilder.Entity("Core.Models.Animal", b =>
                {
                    b.HasOne("Core.Models.Cage", null)
                        .WithMany("Animals")
                        .HasForeignKey("CageId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Core.Models.Comment", b =>
                {
                    b.HasOne("Core.Models.Animal", null)
                        .WithMany("Comments")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Core.Models.Treatment", b =>
                {
                    b.HasOne("Core.Models.Animal", null)
                        .WithMany("Treatments")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.SetNull);
                });
#pragma warning restore 612, 618
        }
    }
}
