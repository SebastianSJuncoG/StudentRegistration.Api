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

    public virtual DbSet<Administrative> Administratives { get; set; }

    public virtual DbSet<IdentificationType> IdentificationTypes { get; set; }

    public virtual DbSet<Program> Programs { get; set; }

    public virtual DbSet<ProgramStudent> ProgramStudents { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<SubjectStudent> SubjectStudents { get; set; }

    public virtual DbSet<SubjectTeacher> SubjectTeachers { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<UsersLogin> UsersLogins { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrative>(entity =>
        {
            entity.HasKey(e => e.IdAdministrative).HasName("PK__Administ__D57A3A047324FED4");

            entity.ToTable("Administrative");

            entity.Property(e => e.IdAdministrative)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Id_Administrative");
            entity.Property(e => e.DocumentNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Document_Number");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.IdIdentificationType).HasColumnName("Id_Identification_Type");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.IdIdentificationTypeNavigation).WithMany(p => p.Administratives)
                .HasForeignKey(d => d.IdIdentificationType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Administrative_IdentificationType");

            entity.HasOne(d => d.User).WithMany(p => p.Administratives)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Administr__User___628FA481");
        });

        modelBuilder.Entity<IdentificationType>(entity =>
        {
            entity.HasKey(e => e.IdIdentificationType).HasName("PK__Identifi__A7E9D9F7E6D9081F");

            entity.ToTable("Identification_Type");

            entity.Property(e => e.IdIdentificationType).HasColumnName("Id_Identification_Type");
            entity.Property(e => e.IdentificationTypeName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Identification_Type_Name");
        });

        modelBuilder.Entity<Program>(entity =>
        {
            entity.HasKey(e => e.IdProgram).HasName("PK__Program__44CAD3892AC7FCCB");

            entity.ToTable("Program");

            entity.Property(e => e.IdProgram).HasColumnName("Id_Program");
            entity.Property(e => e.NumCredits).HasColumnName("Num_Credits");
            entity.Property(e => e.ProgramName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Program_Name");
        });

        modelBuilder.Entity<ProgramStudent>(entity =>
        {
            entity.HasKey(e => e.IdProgramStudent).HasName("PK__Program___E42AD5831A14F010");

            entity.ToTable("Program_Student");

            entity.Property(e => e.IdProgramStudent).HasColumnName("Id_Program_Student");
            entity.Property(e => e.IdProgram).HasColumnName("Id_Program");
            entity.Property(e => e.IdStudents).HasColumnName("Id_Students");

            entity.HasOne(d => d.IdProgramNavigation).WithMany(p => p.ProgramStudents)
                .HasForeignKey(d => d.IdProgram)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Program_S__Id_Pr__0B91BA14");

            entity.HasOne(d => d.IdStudentsNavigation).WithMany(p => p.ProgramStudents)
                .HasForeignKey(d => d.IdStudents)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Program_S__Id_St__0C85DE4D");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__55932E86453C7EAA");

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol).HasColumnName("Id_Rol");
            entity.Property(e => e.RolName)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Rol_Name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.IdRoles)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id_Roles");
            entity.Property(e => e.RoleName)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Role_Name");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.IdStudents).HasName("PK__Students__021843322A3D4B4D");

            entity.Property(e => e.IdStudents)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Id_Students");
            entity.Property(e => e.DocumentNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Document_Number");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.IdIdentificationType).HasColumnName("Id_Identification_Type");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.IdIdentificationTypeNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.IdIdentificationType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Students_IdentificationType");

            entity.HasOne(d => d.User).WithMany(p => p.Students)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Students__User_I__5AEE82B9");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.IdSubject).HasName("PK__Subject__F9D8B01D00BC50F3");

            entity.ToTable("Subject");

            entity.Property(e => e.IdSubject).HasColumnName("Id_Subject");
            entity.Property(e => e.IdProgram).HasColumnName("Id_Program");
            entity.Property(e => e.NumCredits).HasColumnName("Num_Credits");
            entity.Property(e => e.SubjectName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Subject_Name");

            entity.HasOne(d => d.IdProgramNavigation).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.IdProgram)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Subject__Id_Prog__7C4F7684");
        });

        modelBuilder.Entity<SubjectStudent>(entity =>
        {
            entity.HasKey(e => e.IdSubjectStudent).HasName("PK__Subject___3C5A836C4076C3AD");

            entity.ToTable("Subject_Student");

            entity.Property(e => e.IdSubjectStudent).HasColumnName("Id_Subject_Student");
            entity.Property(e => e.IdStudents).HasColumnName("Id_Students");
            entity.Property(e => e.IdSubject).HasColumnName("Id_Subject");

            entity.HasOne(d => d.IdStudentsNavigation).WithMany(p => p.SubjectStudents)
                .HasForeignKey(d => d.IdStudents)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Subject_S__Id_St__08B54D69");

            entity.HasOne(d => d.IdSubjectNavigation).WithMany(p => p.SubjectStudents)
                .HasForeignKey(d => d.IdSubject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Subject_S__Id_Su__07C12930");
        });

        modelBuilder.Entity<SubjectTeacher>(entity =>
        {
            entity.HasKey(e => e.IdSubjectTeacher).HasName("PK__Subject___9CE4E5A36627BD38");

            entity.ToTable("Subject_Teacher");

            entity.Property(e => e.IdSubjectTeacher).HasColumnName("Id_Subject_Teacher");
            entity.Property(e => e.IdSubject).HasColumnName("Id_Subject");
            entity.Property(e => e.IdTeacher).HasColumnName("Id_Teacher");

            entity.HasOne(d => d.IdSubjectNavigation).WithMany(p => p.SubjectTeachers)
                .HasForeignKey(d => d.IdSubject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Subject_T__Id_Su__03F0984C");

            entity.HasOne(d => d.IdTeacherNavigation).WithMany(p => p.SubjectTeachers)
                .HasForeignKey(d => d.IdTeacher)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Subject_T__Id_Te__04E4BC85");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.IdTeacher).HasName("PK__Teachers__E7B06FD2483378C1");

            entity.Property(e => e.IdTeacher)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Id_Teacher");
            entity.Property(e => e.DocumentNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Document_Number");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.IdIdentificationType).HasColumnName("Id_Identification_Type");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.IdIdentificationTypeNavigation).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.IdIdentificationType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Teachers_IdentificationType");

            entity.HasOne(d => d.User).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Teachers__User_I__74AE54BC");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("User_Roles");

            entity.Property(e => e.IdRol).HasColumnName("Id_Rol");
            entity.Property(e => e.IdUserRoles)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_User_Roles");
            entity.Property(e => e.IdUsers).HasColumnName("Id_Users");

            entity.HasOne(d => d.IdRolNavigation).WithMany()
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__User_Role__Id_Ro__70DDC3D8");

            entity.HasOne(d => d.IdUsersNavigation).WithMany()
                .HasForeignKey(d => d.IdUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__User_Role__Id_Us__6FE99F9F");
        });

        modelBuilder.Entity<UsersLogin>(entity =>
        {
            entity.HasKey(e => e.IdUsers).HasName("PK__Users_Lo__FB0668EE6569EA66");

            entity.ToTable("Users_Login");

            entity.Property(e => e.IdUsers)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Id_Users");
            entity.Property(e => e.BlockingAttempts).HasColumnName("Blocking_Attempts");
            entity.Property(e => e.CreationDate)
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.DateLastLogin)
                .HasColumnType("datetime")
                .HasColumnName("DateLast_Login");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(256)
                .HasColumnName("Password_Hash");
            entity.Property(e => e.Salt).HasMaxLength(128);
            entity.Property(e => e.TempPassword)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Temp_Password");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Update_Date");
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("User_Name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
