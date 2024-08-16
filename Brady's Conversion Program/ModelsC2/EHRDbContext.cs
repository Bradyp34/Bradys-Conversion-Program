using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsC2;

public partial class EHRDbContext : DbContext
{
    private readonly string _connectionString;
    public EHRDbContext(string connectionString) {
        _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public EHRDbContext(DbContextOptions<EHRDbContext> options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        : base(options)
    {
    }

    public virtual DbSet<AccountXref> AccountXrefs { get; set; }

    public virtual DbSet<Allergy> Allergies { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<ContactLen> ContactLens { get; set; }

    public virtual DbSet<DiagCodePool> DiagCodePools { get; set; }

    public virtual DbSet<DiagTest> DiagTests { get; set; }

    public virtual DbSet<ExamCondition> ExamConditions { get; set; }

    public virtual DbSet<FamilyHistory> FamilyHistories { get; set; }

    public virtual DbSet<Iop> Iops { get; set; }

    public virtual DbSet<MedicalHistory> MedicalHistories { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PatientDocument> PatientDocuments { get; set; }

    public virtual DbSet<PatientNote> PatientNotes { get; set; }

    public virtual DbSet<PlanNarrative> PlanNarratives { get; set; }

    public virtual DbSet<ProcDiagPool> ProcDiagPools { get; set; }

    public virtual DbSet<ProcPool> ProcPools { get; set; }

    public virtual DbSet<Refraction> Refractions { get; set; }

    public virtual DbSet<Ro> Ros { get; set; }

    public virtual DbSet<RxMedication> RxMedications { get; set; }

    public virtual DbSet<SurgHistory> SurgHistories { get; set; }

    public virtual DbSet<Tech> Teches { get; set; }

    public virtual DbSet<Tech2> Tech2s { get; set; }

    public virtual DbSet<Visit> Visits { get; set; }

    public virtual DbSet<VisitDoctor> VisitDoctors { get; set; }

    public virtual DbSet<VisitOrder> VisitOrders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Allergy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Allergie__3214EC27312A5B72");
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Appointm__3214EC27F825B5AD");
        });

        modelBuilder.Entity<ContactLen>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ContactL__3214EC27BA0E4D4E");
        });

        modelBuilder.Entity<DiagTest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Diag_Tes__3214EC275229319C");
        });

        modelBuilder.Entity<ExamCondition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Exam_Con__3214EC276ED4DDE0");
        });

        modelBuilder.Entity<FamilyHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FamilyHi__3214EC2746233ECD");
        });

        modelBuilder.Entity<Iop>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__IOP__3214EC27877BC8E7");
        });

        modelBuilder.Entity<MedicalHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Medical___3214EC273A44D3A0");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Patients__3214EC276F1F2C80");

            entity.Property(e => e.UpsizeTs)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<PatientDocument>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Patient___3214EC2718C930B7");
        });

        modelBuilder.Entity<PatientNote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Patient___3214EC278BFDC470");
        });

        modelBuilder.Entity<PlanNarrative>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Plan_Nar__3214EC272B4834D2");
        });

        modelBuilder.Entity<ProcDiagPool>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proc_Dia__3214EC27CD2F46BF");
        });

        modelBuilder.Entity<ProcPool>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proc_Poo__3214EC2794E5BEEE");
        });

        modelBuilder.Entity<Refraction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Refracti__3214EC27717A0BAE");
        });

        modelBuilder.Entity<Ro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ROS__3214EC27C6C7D2B6");
        });

        modelBuilder.Entity<RxMedication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rx_Medic__3214EC27D33EF994");
        });

        modelBuilder.Entity<SurgHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Surg_His__3214EC272A5C0430");
        });

        modelBuilder.Entity<Tech>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tech__3214EC27283C3AED");
        });

        modelBuilder.Entity<Tech2>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tech2__3214EC27F382E117");
        });

        modelBuilder.Entity<Visit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__visit__3214EC277F31487A");
        });

        modelBuilder.Entity<VisitDoctor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Visit_Do__3214EC279E4D28D1");
        });

        modelBuilder.Entity<VisitOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Visit Or__3214EC27ABD55E9A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
