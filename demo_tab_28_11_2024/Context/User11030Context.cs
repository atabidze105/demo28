using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using demo_tab_28_11_2024.Models;

namespace demo_tab_28_11_2024.Context;

public partial class User11030Context : DbContext
{
    public User11030Context()
    {
    }

    public User11030Context(DbContextOptions<User11030Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeCode> EmployeeCodes { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<SoloUser> SoloUsers { get; set; }

    public virtual DbSet<Teamuser> Teamusers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=192.168.7.159:5432;Database=user11030;Username=user11030;Password=73794");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("department_pk");

            entity.ToTable("department", "demo2811");

            entity.Property(e => e.DepartmentId)
                .ValueGeneratedNever()
                .HasColumnName("department_id");
            entity.Property(e => e.DepartmentName)
                .HasColumnType("character varying")
                .HasColumnName("department_name");

            entity.HasMany(d => d.Employees).WithMany(p => p.Departments)
                .UsingEntity<Dictionary<string, object>>(
                    "DepartmentEmployee",
                    r => r.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("department_employee_employee_fk"),
                    l => l.HasOne<Department>().WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("department_employee_department_fk"),
                    j =>
                    {
                        j.HasKey("DepartmentId", "EmployeeId").HasName("department_employee_pk");
                        j.ToTable("department_employee", "demo2811");
                        j.IndexerProperty<int>("DepartmentId").HasColumnName("department_id");
                        j.IndexerProperty<int>("EmployeeId").HasColumnName("employee_id");
                    });
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("newtable_pk");

            entity.ToTable("Employee", "demo2811");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("user_id");
            entity.Property(e => e.Department).HasColumnName("department");
            entity.Property(e => e.EmployeeCode).HasColumnName("employee_code");
            entity.Property(e => e.UserName)
                .HasColumnType("character varying")
                .HasColumnName("user_name");
            entity.Property(e => e.UserPatronymic)
                .HasColumnType("character varying")
                .HasColumnName("user_patronymic");
            entity.Property(e => e.UserSurname)
                .HasColumnType("character varying")
                .HasColumnName("user_surname");

            entity.HasOne(d => d.EmployeeCodeNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmployeeCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employee_employeecode_fk");
        });

        modelBuilder.Entity<EmployeeCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("role_pk");

            entity.ToTable("EmployeeCode", "demo2811");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnType("character varying");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("event_pk");

            entity.ToTable("Event", "demo2811");

            entity.Property(e => e.EventId)
                .ValueGeneratedNever()
                .HasColumnName("event_id");
            entity.Property(e => e.DateEnd).HasColumnName("date_end");
            entity.Property(e => e.DateStart).HasColumnName("date_start");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.Purpose)
                .HasColumnType("character varying")
                .HasColumnName("purpose");

            entity.HasOne(d => d.Department).WithMany(p => p.Events)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("event_department_fk");

            entity.HasMany(d => d.Teams).WithMany(p => p.Events)
                .UsingEntity<Dictionary<string, object>>(
                    "TeamuserEvent",
                    r => r.HasOne<Teamuser>().WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("teamuser_event_teamuser_fk"),
                    l => l.HasOne<Event>().WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("teamuser_event_event_fk"),
                    j =>
                    {
                        j.HasKey("EventId", "TeamId").HasName("teamuser_event_pk");
                        j.ToTable("teamuser_event", "demo2811");
                        j.IndexerProperty<int>("EventId").HasColumnName("event_id");
                        j.IndexerProperty<int>("TeamId").HasColumnName("team_id");
                    });

            entity.HasMany(d => d.Users).WithMany(p => p.Events)
                .UsingEntity<Dictionary<string, object>>(
                    "SolouserEvent",
                    r => r.HasOne<SoloUser>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("user_event_solouser_fk"),
                    l => l.HasOne<Event>().WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("user_event_event_fk"),
                    j =>
                    {
                        j.HasKey("EventId", "UserId").HasName("user_event_pk");
                        j.ToTable("solouser_event", "demo2811");
                        j.IndexerProperty<int>("EventId").HasColumnName("event_id");
                        j.IndexerProperty<int>("UserId").HasColumnName("user_id");
                    });
        });

        modelBuilder.Entity<SoloUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("solouser_pk");

            entity.ToTable("SoloUser", "demo2811");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("user_id");
            entity.Property(e => e.Admin).HasColumnName("admin");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.Login)
                .HasColumnType("character varying")
                .HasColumnName("login");
            entity.Property(e => e.OrganisationName)
                .HasColumnType("character varying")
                .HasColumnName("organisation_name");
            entity.Property(e => e.PassportNumber)
                .HasColumnType("character varying")
                .HasColumnName("passport_number");
            entity.Property(e => e.PassportSerie)
                .HasColumnType("character varying")
                .HasColumnName("passport_serie");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasColumnType("character varying")
                .HasColumnName("phone");
            entity.Property(e => e.Photo)
                .HasColumnType("character varying")
                .HasColumnName("photo");
            entity.Property(e => e.Purpose)
                .HasColumnType("character varying")
                .HasColumnName("purpose");
            entity.Property(e => e.UserName)
                .HasColumnType("character varying")
                .HasColumnName("user_name");
            entity.Property(e => e.UserPatronymic)
                .HasColumnType("character varying")
                .HasColumnName("user_patronymic");
            entity.Property(e => e.UserSurname)
                .HasColumnType("character varying")
                .HasColumnName("user_surname");
        });

        modelBuilder.Entity<Teamuser>(entity =>
        {
            entity.HasKey(e => e.TeamId).HasName("teamuser_pk");

            entity.ToTable("teamuser", "demo2811");

            entity.Property(e => e.TeamId)
                .ValueGeneratedNever()
                .HasColumnName("team_id");
            entity.Property(e => e.Teamlist)
                .HasColumnType("character varying")
                .HasColumnName("teamlist");
        });
        modelBuilder.HasSequence("role_seq", "demo2811");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
