﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SendGridDemo.Data;

namespace SendGridDemo.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190607181542_AddMessagesTable")]
    partial class AddMessagesTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SendGridDemo.Data.Models.ApplicationUser", b =>
                {
                    b.Property<int>("ApplicationUserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("ApplicationUserId");

                    b.ToTable("ApplicationUsers");
                });

            modelBuilder.Entity("SendGridDemo.Data.Models.EmailMessage", b =>
                {
                    b.Property<int>("EmailMessageId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("SendGridMessageId")
                        .HasMaxLength(100);

                    b.HasKey("EmailMessageId");

                    b.ToTable("EmailMessage");
                });

            modelBuilder.Entity("SendGridDemo.Data.Models.EmailMessageEvent", b =>
                {
                    b.Property<int>("EmailMessageEventId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Event");

                    b.Property<string>("Response");

                    b.Property<string>("SendGridEventId")
                        .HasMaxLength(100);

                    b.Property<double>("TimeStamp");

                    b.Property<string>("Url");

                    b.Property<int>("fkEmailMessageId");

                    b.HasKey("EmailMessageEventId");

                    b.HasIndex("fkEmailMessageId");

                    b.ToTable("EmailMessageEvent");
                });

            modelBuilder.Entity("SendGridDemo.Data.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("MessageId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("SendGridDemo.Data.Models.EmailMessageEvent", b =>
                {
                    b.HasOne("SendGridDemo.Data.Models.EmailMessage", "EmailMessage")
                        .WithMany("EmailEvents")
                        .HasForeignKey("fkEmailMessageId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
