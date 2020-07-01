using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.EF
{
    //Package Nuget
    //Microsoft.EntityFrameworkCore.SqlServer
    //Microsoft.EntityFrameworkCore.Tools
    //Microsoft.Extensions.Logging.Console
    //Outils -> Gestionnaire de package Nuget -> Console du gestionnaire de package

    //add-migration [Nom]
    //update-database
    public class EntitiesDbContext : DbContext
    {
        private static ILoggerFactory ConsoleLoggerFactory;

        static EntitiesDbContext()
        {
            ConsoleLoggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                .AddFilter((category, level) =>
                    category == DbLoggerCategory.Database.Command.Name &&
                    level == LogLevel.Information)
                .AddConsole();
            });
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Section> Sections { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder
                .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Entities;Integrated Security=True;")
                .EnableSensitiveDataLogging()
                .UseLoggerFactory(ConsoleLoggerFactory);
            //optionsBuilder.UseSqlServer(@"Data Source=Forma-vdi13xx\TFTIC;Initial Catalog=Entities;User Id=sa;Password=tftic@2012;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Section>()
                .Property(se => se.SectionName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Student>()
                .Property(st => st.LastName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Student>()
                .Property(st => st.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Student>()
                .Property(st => st.Login)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Student>()
                .HasCheckConstraint("CK_Student_YearResult", "YearResult Between 0 and 20");
        }
    }
}
