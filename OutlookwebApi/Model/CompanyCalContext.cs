using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OutlookwebApi.Model
{
    public partial class CompanyCalContext : DbContext
    {
        public CompanyCalContext()
        {
        }

        public CompanyCalContext(DbContextOptions<CompanyCalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customreport> Customreport { get; set; }
        public virtual DbSet<Launchevent> Launchevent { get; set; }
        public virtual DbSet<Userpersonas> Userpersonas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:companycal.database.windows.net,1433;Initial Catalog=CompanyCal;Persist Security Info=False;User ID=demo;Password=Welcome2020;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customreport>(entity =>
            {
                entity.Property(e => e.FeatureName).IsUnicode(false);

                entity.Property(e => e.FrequencyofReport).IsUnicode(false);

                entity.Property(e => e.LaunchOwner).IsUnicode(false);

                entity.Property(e => e.Launchtier).IsUnicode(false);

                entity.Property(e => e.Linktoaddcalendar).IsUnicode(false);

                entity.Property(e => e.Linktodetails).IsUnicode(false);
            });

            modelBuilder.Entity<Launchevent>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Customfields).IsUnicode(false);

                entity.Property(e => e.FeatureName).IsUnicode(false);

                entity.Property(e => e.Hyperlinktodetails).IsUnicode(false);

                entity.Property(e => e.Launchtier).IsUnicode(false);

                entity.Property(e => e.Launchtype).IsUnicode(false);
            });

            modelBuilder.Entity<Userpersonas>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Role).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
