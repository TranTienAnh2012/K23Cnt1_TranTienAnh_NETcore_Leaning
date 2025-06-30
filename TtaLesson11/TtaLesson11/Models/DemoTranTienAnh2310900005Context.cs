using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TtaLesson11.Models;

public partial class DemoTranTienAnh2310900005Context : DbContext
{
    public DemoTranTienAnh2310900005Context()
    {
    }

    public DemoTranTienAnh2310900005Context(DbContextOptions<DemoTranTienAnh2310900005Context> options)
        : base(options)
    {
    }

    public virtual DbSet<TtaEmployee> TtaEmployees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=LAPTOP-F48PQH12\\TIENANH1; Database=DemoTranTienAnh_2310900005; uid=TtaAdmin; PWD=tienanh2005; MultipleActiveResultSets=True; TrustServerCertificate=True ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TtaEmployee>(entity =>
        {
            entity.HasKey(e => e.TtaEmpId).HasName("PK__TtaEmplo__F10E50181E679116");

            entity.ToTable("TtaEmployee");

            entity.Property(e => e.TtaEmpLevel).HasMaxLength(50);
            entity.Property(e => e.TtaEmpName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
