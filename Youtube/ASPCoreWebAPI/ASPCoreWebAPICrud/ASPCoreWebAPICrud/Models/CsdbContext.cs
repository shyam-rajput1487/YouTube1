using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ASPCoreWebAPICrud.Models;

public partial class CsdbContext : DbContext
{
    public CsdbContext()
    {
    }

    public CsdbContext(DbContextOptions<CsdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Dept> Depts { get; set; }

    public virtual DbSet<Emp> Emps { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-Q6DM7AN\\SQLEXPRESS;Database=CSDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dept>(entity =>
        {
            entity.HasKey(e => e.Deptno).HasName("Deptno_Pk");

            entity.ToTable("Dept");

            entity.Property(e => e.Deptno).ValueGeneratedNever();
            entity.Property(e => e.Dname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Emp>(entity =>
        {
            entity.HasKey(e => e.Empno).HasName("Empno_Pk");

            entity.ToTable("Emp");

            entity.Property(e => e.Empno).ValueGeneratedNever();
            entity.Property(e => e.Comm).HasColumnType("money");
            entity.Property(e => e.Ename)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Job)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Salary).HasColumnType("money");

            entity.HasOne(d => d.DeptnoNavigation).WithMany(p => p.Emps)
                .HasForeignKey(d => d.Deptno)
                .HasConstraintName("FK__Emp__Deptno__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
