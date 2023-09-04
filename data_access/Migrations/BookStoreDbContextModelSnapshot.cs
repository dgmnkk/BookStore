﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using data_access.Data;

#nullable disable

namespace data_access.Migrations
{
    [DbContext(typeof(BookStoreDbContext))]
    partial class BookStoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookOrder", b =>
                {
                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.Property<int>("OrdersId")
                        .HasColumnType("int");

                    b.HasKey("BooksId", "OrdersId");

                    b.HasIndex("OrdersId");

                    b.ToTable("BookOrder");
                });

            modelBuilder.Entity("data_access.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "John",
                            Surname = "Doe"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Jane",
                            Surname = "Smith"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Michael",
                            Surname = "Johnson"
                        });
                });

            modelBuilder.Entity("data_access.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pages")
                        .HasColumnType("int");

                    b.Property<int?>("PreviousBookId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GenreId");

                    b.HasIndex("PreviousBookId")
                        .IsUnique()
                        .HasFilter("[PreviousBookId] IS NOT NULL");

                    b.HasIndex("PublisherId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Cost = 15,
                            GenreId = 1,
                            Name = "Book 1",
                            Pages = 300,
                            Price = 25,
                            PublisherId = 1,
                            Year = 2020
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 2,
                            Cost = 12,
                            GenreId = 2,
                            Name = "Book 2",
                            Pages = 250,
                            Price = 20,
                            PublisherId = 2,
                            Year = 2019
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 3,
                            Cost = 120,
                            GenreId = 3,
                            Name = "Book 3",
                            Pages = 500,
                            Price = 200,
                            PublisherId = 3,
                            Year = 2023
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 2,
                            Cost = 100,
                            GenreId = 2,
                            Name = "Book 4",
                            Pages = 123,
                            Price = 200,
                            PublisherId = 2,
                            Year = 2000
                        },
                        new
                        {
                            Id = 5,
                            AuthorId = 1,
                            Cost = 83,
                            GenreId = 3,
                            Name = "Book 5",
                            Pages = 600,
                            Price = 166,
                            PublisherId = 2,
                            Year = 2012
                        });
                });

            modelBuilder.Entity("data_access.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Alice",
                            Surname = "Johnson"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bob",
                            Surname = "Smith"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Ann",
                            Surname = "Brown"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Phillip",
                            Surname = "Jackson"
                        });
                });

            modelBuilder.Entity("data_access.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Science Fiction"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Mystery"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Fantasy"
                        });
                });

            modelBuilder.Entity("data_access.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            Time = new DateTime(2023, 9, 4, 17, 23, 34, 577, DateTimeKind.Local).AddTicks(4370)
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 2,
                            Time = new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Local)
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 3,
                            Time = new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Local)
                        },
                        new
                        {
                            Id = 4,
                            CustomerId = 4,
                            Time = new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Local)
                        },
                        new
                        {
                            Id = 5,
                            CustomerId = 2,
                            Time = new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Local)
                        });
                });

            modelBuilder.Entity("data_access.PublishingHouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PublishingHouses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Publisher A"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Publisher B"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Publisher C"
                        });
                });

            modelBuilder.Entity("data_access.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Login = "admin",
                            Password = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Login = "consultant",
                            Password = "consultant"
                        });
                });

            modelBuilder.Entity("BookOrder", b =>
                {
                    b.HasOne("data_access.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("data_access.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("data_access.Book", b =>
                {
                    b.HasOne("data_access.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("data_access.Genre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("data_access.Book", "PreviousBook")
                        .WithOne("NextBook")
                        .HasForeignKey("data_access.Book", "PreviousBookId");

                    b.HasOne("data_access.PublishingHouse", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Genre");

                    b.Navigation("PreviousBook");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("data_access.Order", b =>
                {
                    b.HasOne("data_access.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("data_access.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("data_access.Book", b =>
                {
                    b.Navigation("NextBook");
                });

            modelBuilder.Entity("data_access.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("data_access.Genre", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("data_access.PublishingHouse", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}