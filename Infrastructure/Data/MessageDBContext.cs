using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Infrastructure.Data
{
    public partial class MessageDBContext : DbContext
    {

        public virtual DbSet<MessageModel> MessageTable { get; set; }
        public virtual DbSet<UserModel> UserModels { get; set; }

        public MessageDBContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //get appsetting from web api project
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string relativePath = @"..\..\..\..\Web Api";
                string webPath = Path.GetFullPath(basePath + relativePath);

                IConfigurationRoot configuration = new ConfigurationBuilder()
                                                .SetBasePath(webPath)
                                                .AddJsonFile("appsettings.json")
                                                .Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));


            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserModel>(e => {
                e.HasKey(e => e.Id);

                e.Property(e => e.Fullname)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnName("fullname");

                e.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");
            });


            modelBuilder.Entity<MessageModel>(e =>
            {
                e.ToTable("message-table");

                e.HasKey(e => e.Id);

                e.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsRequired()
                    .HasColumnName("title");

                e.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("content");

                e.Property(e => e.CreateDate)
                    .HasDefaultValue(DateTime.Now)
                    .HasColumnType("DateTime");

                e.Property(e => e.SenderId)
                    .HasColumnName("senderId");

                e.Property(e => e.RecipientId)
                    .HasColumnName("recipientId");

                e.HasOne(e => e.Sender)
                    .WithMany()
                    .HasForeignKey(p => p.SenderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_User_Message_Se");

                e.HasOne(e => e.Recipeint)
                    .WithMany()
                    .HasForeignKey(p => p.RecipientId)
                    .OnDelete(DeleteBehavior.ClientNoAction)
                    .HasConstraintName("FK_User_Message_Re");
            });


 

        }
    }
}
