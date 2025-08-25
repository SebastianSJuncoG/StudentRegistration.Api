using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentRegistration.Data.Models;

public partial class StudentRegistrationContext : DbContext
{
    public StudentRegistrationContext()
    {
    }

    public StudentRegistrationContext(DbContextOptions<StudentRegistrationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<IdentificationType> IdentificationTypes { get; set; }

    public virtual DbSet<LogUser> LogUsers { get; set; }

    public virtual DbSet<TypeOfEvent> TypeOfEvents { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-A3SUTCK;Database=student_registration;User Id=SebastianSJG;Password=GeHid59*;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentificationType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Identifi__3214EC07331A930E");

            entity.ToTable("IdentificationType");

            entity.Property(e => e.IdentificationTypeName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LogUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LogUsers__3214EC0752482E0F");

            entity.Property(e => e.DateRegister).HasColumnType("datetime");
            entity.Property(e => e.ErrorMessage)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.EventDetails)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.IpRegister)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTypeEventNavigation).WithMany(p => p.LogUsers)
                .HasForeignKey(d => d.IdTypeEvent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IdTypeOfEventsLogUsers");
        });

        modelBuilder.Entity<TypeOfEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TypeOfEv__3214EC07C0DECED3");

            entity.Property(e => e.EventName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07E5E4564A");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("TR_Insert_Users_HashPassword");
                    tb.HasTrigger("TR_Update_Users_HashPassword");
                });

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.DateLastLogin).HasColumnType("datetime");
            entity.Property(e => e.DocumentNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdCountry).HasColumnName("idCountry");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash).HasMaxLength(256);
            entity.Property(e => e.Salt).HasMaxLength(128);
            entity.Property(e => e.TempPassword)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdIdentificationTypeNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdIdentificationType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IdIdentificationType");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
