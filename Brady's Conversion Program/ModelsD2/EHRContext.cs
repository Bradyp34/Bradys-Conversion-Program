using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsD2;

public partial class EHRContext : DbContext
{
    public EHRContext()
    {
    }

    public EHRContext(DbContextOptions<EHRContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Clbrand> Clbrands { get; set; }

    public virtual DbSet<Clinventory> Clinventories { get; set; }

    public virtual DbSet<Cllense> Cllenses { get; set; }

    public virtual DbSet<Cpt> Cpts { get; set; }

    public virtual DbSet<Cptdept> Cptdepts { get; set; }

    public virtual DbSet<Cptmapping> Cptmappings { get; set; }

    public virtual DbSet<Frame> Frames { get; set; }

    public virtual DbSet<FrameCategory> FrameCategories { get; set; }

    public virtual DbSet<FrameCollection> FrameCollections { get; set; }

    public virtual DbSet<FrameColor> FrameColors { get; set; }

    public virtual DbSet<FrameEtype> FrameEtypes { get; set; }

    public virtual DbSet<FrameFtype> FrameFtypes { get; set; }

    public virtual DbSet<FrameLensColor> FrameLensColors { get; set; }

    public virtual DbSet<FrameMaterial> FrameMaterials { get; set; }

    public virtual DbSet<FrameMount> FrameMounts { get; set; }

    public virtual DbSet<FrameOrder> FrameOrders { get; set; }

    public virtual DbSet<FrameShape> FrameShapes { get; set; }

    public virtual DbSet<FrameStatus> FrameStatuses { get; set; }

    public virtual DbSet<FrameTemple> FrameTemples { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=FoxDevSql19;Database=Foxfire_Inv_Conv;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clbrand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CL Brand__3214EC27135F657C");
        });

        modelBuilder.Entity<Clinventory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CL Inven__3214EC2737241797");
        });

        modelBuilder.Entity<Cllense>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CL Lense__3214EC2758F913D4");
        });

        modelBuilder.Entity<Cpt>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CPTs__3214EC270DCDCDAD");
        });

        modelBuilder.Entity<Cptdept>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CPT Dept__3214EC275E27AEF6");
        });

        modelBuilder.Entity<Cptmapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CPT Mapp__3214EC271E548074");
        });

        modelBuilder.Entity<Frame>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Frames__3214EC275587845C");
        });

        modelBuilder.Entity<FrameCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Frame Ca__3214EC2768763AEA");
        });

        modelBuilder.Entity<FrameCollection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Frame Co__3214EC27BEAFFFB2");
        });

        modelBuilder.Entity<FrameColor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Frame Co__3214EC2721C54F85");
        });

        modelBuilder.Entity<FrameEtype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FrameETy__3214EC27D2B41AE4");
        });

        modelBuilder.Entity<FrameFtype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FrameFTy__3214EC279363411F");
        });

        modelBuilder.Entity<FrameLensColor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FrameLen__3214EC2721B8551A");
        });

        modelBuilder.Entity<FrameMaterial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FrameMat__3214EC27A01B8FA6");
        });

        modelBuilder.Entity<FrameMount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FrameMou__3214EC277B1B6CED");
        });

        modelBuilder.Entity<FrameOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FrameOrd__3214EC270ADB0589");
        });

        modelBuilder.Entity<FrameShape>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Frame Sh__3214EC27F1C2EE64");
        });

        modelBuilder.Entity<FrameStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Frame St__3214EC27182C7233");
        });

        modelBuilder.Entity<FrameTemple>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Frame Te__3214EC27B51FE5E6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
