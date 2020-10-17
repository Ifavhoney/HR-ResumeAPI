using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ResumeAPI.Models
{
    public partial class ResumeContext : DbContext
    {
        public ResumeContext()
        {
        }

        public ResumeContext(DbContextOptions<ResumeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserEducation> UserEducation { get; set; }
        public virtual DbSet<UserExperience> UserExperience { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<UserOther> UserOther { get; set; }

  //      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  //      {
  //          if (!optionsBuilder.IsConfigured)
  //          {
  //  #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
  //              optionsBuilder.UseSqlServer("Server=mydbinstancer.cypzkuhx9sqk.us-east-1.rds.amazonaws.com,1433;Database=Resume;User ID=Admin;Password = Password");
  //          }
  //      }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEducation>(entity =>
            {
                entity.ToTable("userEducation");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DegreeType)
                    .HasColumnName("degree_type")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fk_Info_Id).HasColumnName("fk_info_id");

                entity.Property(e => e.Gpa).HasColumnName("gpa");

                entity.Property(e => e.Major)
                    .HasColumnName("major")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.School)
                    .HasMaxLength(50)
                    .IsUnicode(false);

             //   entity.HasOne(d => d.FkInfo)
             //       .WithMany(p => p.UserEducation)
             //       .HasForeignKey(d => d.FkInfoId)
             //       .HasConstraintName("FK__userEduca__fk_in__2A4B4B5E");
            });

            modelBuilder.Entity<UserExperience>(entity =>
            {
                entity.ToTable("userExperience");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CurrentlyEmployed)
                    .HasColumnName("currently_employed")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Duties)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Fk_Info_Id).HasColumnName("fk_info_id");

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MonthsSpent).HasColumnName("Months_Spent");

             // entity.HasOne(d => d.FkInfo)
             //     .WithMany(p => p.UserExperience)
             //     .HasForeignKey(d => d.FkInfoId)
             //     .HasConstraintName("FK__userExper__fk_in__2F10007B");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.ToTable("userInfo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FieldOfExpertise)
                    .HasColumnName("fieldOfExpertise")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fullname)
                    .HasColumnName("fullname")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserOther>(entity =>
            {
                entity.ToTable("userOther");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bilingual)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Certification)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Fk_Info_Id).HasColumnName("fk_info_id");

                entity.Property(e => e.Skills)
                    .HasMaxLength(250)
                    .IsUnicode(false);

               // entity.HasOne(d => d.FkInfo)
               //     .WithMany(p => p.UserOther)
               //     .HasForeignKey(d => d.FkInfoId)
               //     .HasConstraintName("FK__userOther__fk_in__31EC6D26");
            });
        }
    }
}
