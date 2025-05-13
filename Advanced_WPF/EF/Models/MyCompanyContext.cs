using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Advanced_WPF.EF.Models;

public partial class MyCompanyContext : DbContext
{
    public MyCompanyContext()
    {
    }

    public MyCompanyContext(DbContextOptions<MyCompanyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

    string _connectionstring = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(_connectionstring);//"Server=.;Database=MyCompany;Trusted_Connection=True;TrustServerCertificate=True"

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Role");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.Property(e => e.Dob).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Fname).HasMaxLength(100);
            entity.Property(e => e.Lname).HasMaxLength(100);
            entity.Property(e => e.Mobile).HasMaxLength(50);
            entity.Property(e => e.RoleId).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.Workers)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_Workers_Roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
