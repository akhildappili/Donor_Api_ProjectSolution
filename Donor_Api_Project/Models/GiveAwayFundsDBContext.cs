using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Donor_Api_Project.Models
{
    public partial class GiveAwayFundsDBContext : DbContext
    {
        public GiveAwayFundsDBContext()
        {
        }

        public GiveAwayFundsDBContext(DbContextOptions<GiveAwayFundsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Donation> Donations { get; set; }
        public virtual DbSet<Donor> Donors { get; set; }
        public virtual DbSet<EventFund> EventFunds { get; set; }
        public virtual DbSet<LoginDetail> LoginDetails { get; set; }
        public virtual DbSet<Ngo> Ngos { get; set; }
        public virtual DbSet<Verification> Verifications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=GiveAwayFundsDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Donation>(entity =>
            {
                entity.HasKey(e => e.TransactionId)
                    .HasName("PK__Donation__55433A6B1AC47A0D");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Donor)
                    .WithMany(p => p.Donations)
                    .HasForeignKey(d => d.DonorId)
                    .HasConstraintName("FK__Donations__Donor__3C69FB99");

                entity.HasOne(d => d.Ngo)
                    .WithMany(p => p.Donations)
                    .HasForeignKey(d => d.NgoId)
                    .HasConstraintName("FK__Donations__NgoId__3D5E1FD2");
            });

            modelBuilder.Entity<Donor>(entity =>
            {
                entity.ToTable("Donor");

                entity.Property(e => e.DonorConfirmPassword)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DonorMailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DonorName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DonorPassword)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DonorPhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DonorUserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EventFund>(entity =>
            {
                entity.HasKey(e => e.FundId)
                    .HasName("PK__FundRais__830DFC5A7BDB136B");

                entity.ToTable("EventFund");

                entity.Property(e => e.FundDescription)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Ngo)
                    .WithMany(p => p.EventFunds)
                    .HasForeignKey(d => d.NgoId)
                    .HasConstraintName("FK__FundRaise__NgoId__403A8C7D");
            });

            modelBuilder.Entity<LoginDetail>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("PK__LoginDet__C9F284574B3377A2");

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Loginas)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ngo>(entity =>
            {
                entity.ToTable("NGO");

                entity.Property(e => e.NgoAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NgoConfirmPassword)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NgoMailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NgoName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NgoPassword)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NgoPhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NgoUserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Verification>(entity =>
            {
                entity.ToTable("Verification");

                entity.Property(e => e.ProofOfVerification)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Ngo)
                    .WithMany(p => p.Verifications)
                    .HasForeignKey(d => d.NgoId)
                    .HasConstraintName("FK__Verificat__NgoId__4316F928");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
