﻿// <auto-generated />
using EfCoreExperiments.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace EfCoreExperiments.Migrations
{
    [DbContext(typeof(PersistenceContext))]
    [Migration("20171223093250_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EfCoreExperiments.Models.GiftCard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ProviderName");

                    b.HasKey("Id");

                    b.ToTable("GiftCards");
                });

            modelBuilder.Entity("EfCoreExperiments.Models.GiftCard", b =>
                {
                    b.OwnsOne("EfCoreExperiments.Models.ExpirationDate", "ExpiryDate", b1 =>
                        {
                            b1.Property<Guid>("GiftCardId");

                            b1.Property<DateTime?>("Date")
                                .HasColumnName("GiftCardExpiryDate");

                            b1.ToTable("GiftCards");

                            b1.HasOne("EfCoreExperiments.Models.GiftCard")
                                .WithOne("ExpiryDate")
                                .HasForeignKey("EfCoreExperiments.Models.ExpirationDate", "GiftCardId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}