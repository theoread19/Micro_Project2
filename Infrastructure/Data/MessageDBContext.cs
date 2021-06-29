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
                    .IsRequired();

                e.Property(e => e.RecipientId)
                    .IsRequired();
            });


        }
    }
}
