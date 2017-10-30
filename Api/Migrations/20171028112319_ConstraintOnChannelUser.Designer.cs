﻿// <auto-generated />
using Api.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Api.Migrations
{
    [DbContext(typeof(ApiDatabaseContext))]
    [Migration("20171028112319_ConstraintOnChannelUser")]
    partial class ConstraintOnChannelUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Api.DataModel.ChannelUserEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ChannelType")
                        .IsRequired();

                    b.Property<string>("ChannelUserId")
                        .IsRequired();

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasAlternateKey("ChannelType", "ChannelUserId");

                    b.ToTable("ChannelUsers");
                });

            modelBuilder.Entity("Api.DataModel.ConfirmationCodeEntity", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<long>("ChannelUserId");

                    b.Property<string>("ConfirmationCode");

                    b.HasKey("UserId", "ChannelUserId");

                    b.ToTable("ConfirmationCodes");
                });

            modelBuilder.Entity("Api.DataModel.DocumentEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("ChannelUserId");

                    b.Property<string>("Link");

                    b.Property<int>("Rating");

                    b.Property<DateTimeOffset>("SubmitDate");

                    b.HasKey("Id");

                    b.HasIndex("ChannelUserId");

                    b.HasIndex("Link")
                        .IsUnique()
                        .HasFilter("[Link] IS NOT NULL");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("Api.DataModel.DocumentEntity", b =>
                {
                    b.HasOne("Api.DataModel.ChannelUserEntity")
                        .WithMany()
                        .HasForeignKey("ChannelUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}