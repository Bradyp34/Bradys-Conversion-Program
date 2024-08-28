using System;
using System.Collections.Generic;
using Brady_s_Conversion_Program.Models;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsC;

public partial class EHRDbContext : DbContext {
    private readonly string _connectionString;
    public EHRDbContext(string connectionString) {
        _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public EHRDbContext(DbContextOptions<EHRDbContext> options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        : base(options) {
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
        modelBuilder.Entity<AccountXref>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("AccountXref");

            entity.Property(e => e.NewAccount)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OldAccount)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Allergy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Allergie__3214EC27312A5B72");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.AllergyName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Created)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedEmpId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CreatedEmpID");
            entity.Property(e => e.Dosdate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DOSDate");
            entity.Property(e => e.Inactive)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.Reaction)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Severity)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StartDate)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Appointm__3214EC27D7AB586C");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ApptHl7status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ApptHL7Status");
            entity.Property(e => e.ApptLocationId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ApptLocationID");
            entity.Property(e => e.ApptNotes)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ApptProviderEmpId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ApptProviderEmpID");
            entity.Property(e => e.ApptReason)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ApptStartTime)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ApptStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApptType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ClientSoftwareApptId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ClientSoftwareApptID");
            entity.Property(e => e.IntakeStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OldApptId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("OldApptID");
            entity.Property(e => e.PtId).HasColumnName("PtID");
        });

        modelBuilder.Entity<ContactLen>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ContactL__3214EC279FD20081");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.AddOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("AddOD");
            entity.Property(e => e.AddOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("AddOS");
            entity.Property(e => e.Axis2Od)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Axis2OD");
            entity.Property(e => e.Axis2Os)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Axis2OS");
            entity.Property(e => e.AxisOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("AxisOD");
            entity.Property(e => e.AxisOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("AxisOS");
            entity.Property(e => e.Bc2od)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("BC2OD");
            entity.Property(e => e.Bc2os)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("BC2OS");
            entity.Property(e => e.Bcod)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("BCOD");
            entity.Property(e => e.Bcos)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("BCOS");
            entity.Property(e => e.BlendOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("BlendOD");
            entity.Property(e => e.BlendOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("BlendOS");
            entity.Property(e => e.CatalogBrandIdod)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CatalogBrandIDOD");
            entity.Property(e => e.CatalogBrandIdos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CatalogBrandIDOS");
            entity.Property(e => e.CatalogManufacturerIdod)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CatalogManufacturerIDOD");
            entity.Property(e => e.CatalogManufacturerIdos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CatalogManufacturerIDOS");
            entity.Property(e => e.CatalogProductIdod)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CatalogProductIDOD");
            entity.Property(e => e.CatalogProductIdos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CatalogProductIDOS");
            entity.Property(e => e.CatalogSource)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CenterThicknessOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CenterThicknessOD");
            entity.Property(e => e.CenterThicknessOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CenterThicknessOS");
            entity.Property(e => e.CentrationOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CentrationOD");
            entity.Property(e => e.CentrationOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CentrationOS");
            entity.Property(e => e.ColorOd)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ColorOD");
            entity.Property(e => e.ColorOs)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ColorOS");
            entity.Property(e => e.ComfortOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ComfortOD");
            entity.Property(e => e.ComfortOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ComfortOS");
            entity.Property(e => e.ContactClass)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CoverageOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CoverageOD");
            entity.Property(e => e.CoverageOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CoverageOS");
            entity.Property(e => e.Cylinder2Od)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Cylinder2OD");
            entity.Property(e => e.Cylinder2Os)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Cylinder2OS");
            entity.Property(e => e.CylinderOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CylinderOD");
            entity.Property(e => e.CylinderOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CylinderOS");
            entity.Property(e => e.Diameter2Od)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Diameter2OD");
            entity.Property(e => e.Diameter2Os)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Diameter2OS");
            entity.Property(e => e.DiameterOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DiameterOD");
            entity.Property(e => e.DiameterOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DiameterOS");
            entity.Property(e => e.DistNearOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DistNearOD");
            entity.Property(e => e.DistNearOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DistNearOS");
            entity.Property(e => e.DkOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DkOD");
            entity.Property(e => e.DkOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DkOS");
            entity.Property(e => e.Dosdate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DOSDate");
            entity.Property(e => e.EdgeLiftOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EdgeLiftOD");
            entity.Property(e => e.EdgeLiftOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EdgeLiftOS");
            entity.Property(e => e.EdgeOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EdgeOD");
            entity.Property(e => e.EdgeOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EdgeOS");
            entity.Property(e => e.EquivalentCurveOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EquivalentCurveOD");
            entity.Property(e => e.EquivalentCurveOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EquivalentCurveOS");
            entity.Property(e => e.Expires)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Kod)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("KOD");
            entity.Property(e => e.Kos)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("KOS");
            entity.Property(e => e.LensDesignOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LensDesignOD");
            entity.Property(e => e.LensDesignOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LensDesignOS");
            entity.Property(e => e.LensType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MaterialOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MaterialOD");
            entity.Property(e => e.MaterialOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MaterialOS");
            entity.Property(e => e.MovementOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MovementOD");
            entity.Property(e => e.MovementOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MovementOS");
            entity.Property(e => e.NaFlPatternOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("NaFlPatternOD");
            entity.Property(e => e.NaFlPatternOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("NaFlPatternOS");
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OpticalZoneDiaOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OpticalZoneDiaOD");
            entity.Property(e => e.OpticalZoneDiaOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OpticalZoneDiaOS");
            entity.Property(e => e.OraxisOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ORAxisOD");
            entity.Property(e => e.OraxisOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ORAxisOS");
            entity.Property(e => e.OrcylinderOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ORCylinderOD");
            entity.Property(e => e.OrcylinderOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ORCylinderOS");
            entity.Property(e => e.OrsphereOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ORSphereOD");
            entity.Property(e => e.OrsphereOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ORSphereOS");
            entity.Property(e => e.OrvaDod)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ORVaDOD");
            entity.Property(e => e.OrvaDos)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ORVaDOS");
            entity.Property(e => e.OrvaNod)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ORVaNOD");
            entity.Property(e => e.OrvaNos)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ORVaNOS");
            entity.Property(e => e.PeriphCurve2Od)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PeriphCurve2OD");
            entity.Property(e => e.PeriphCurve2Os)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PeriphCurve2OS");
            entity.Property(e => e.PeriphCurveOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PeriphCurveOD");
            entity.Property(e => e.PeriphCurveOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PeriphCurveOS");
            entity.Property(e => e.Power2Od)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Power2OD");
            entity.Property(e => e.Power2Os)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Power2OS");
            entity.Property(e => e.PowerOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PowerOD");
            entity.Property(e => e.PowerOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PowerOS");
            entity.Property(e => e.ProductOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ProductOD");
            entity.Property(e => e.ProductOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ProductOS");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.PtInsertedRemoved)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PupilOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PupilOD");
            entity.Property(e => e.PupilOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PupilOS");
            entity.Property(e => e.Remarks)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ReplacementSchedule)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.RgplayoutOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("RGPLayoutOD");
            entity.Property(e => e.RgplayoutOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("RGPLayoutOS");
            entity.Property(e => e.RotationDegOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("RotationDegOD");
            entity.Property(e => e.RotationDegOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("RotationDegOS");
            entity.Property(e => e.RotationDirectionOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("RotationDirectionOD");
            entity.Property(e => e.RotationDirectionOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("RotationDirectionOS");
            entity.Property(e => e.RxId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RxID");
            entity.Property(e => e.SecondaryCurveOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SecondaryCurveOD");
            entity.Property(e => e.SecondaryCurveOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SecondaryCurveOS");
            entity.Property(e => e.SegHeightOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SegHeightOD");
            entity.Property(e => e.SegHeightOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SegHeightOS");
            entity.Property(e => e.Solution)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SpecialInstructionsOd)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("SpecialInstructionsOD");
            entity.Property(e => e.SpecialInstructionsOs)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("SpecialInstructionsOS");
            entity.Property(e => e.SurfaceWettingOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SurfaceWettingOD");
            entity.Property(e => e.SurfaceWettingOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SurfaceWettingOS");
            entity.Property(e => e.TrialNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Upcod)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UPCOD");
            entity.Property(e => e.Upcos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UPCOS");
            entity.Property(e => e.VaDod)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VaDOD");
            entity.Property(e => e.VaDos)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VaDOS");
            entity.Property(e => e.VaDou)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VaDOU");
            entity.Property(e => e.VaIod)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VaIOD");
            entity.Property(e => e.VaIos)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VaIOS");
            entity.Property(e => e.VaIou)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VaIOU");
            entity.Property(e => e.VaNod)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VaNOD");
            entity.Property(e => e.VaNos)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VaNOS");
            entity.Property(e => e.VaNou)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VaNOU");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
            entity.Property(e => e.WageOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("WAgeOD");
            entity.Property(e => e.WageOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("WAgeOS");
            entity.Property(e => e.WavgWearTimeOd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WAvgWearTimeOD");
            entity.Property(e => e.WavgWearTimeOs)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WAvgWearTimeOS");
            entity.Property(e => e.WearingInstructions)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.WtimeTodayOd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WTimeTodayOD");
            entity.Property(e => e.WtimeTodayOs)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WTimeTodayOS");
        });

        modelBuilder.Entity<DiagCodePool>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DiagCode__3214EC2798973AA8");

            entity.ToTable("DiagCodePool");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CodeIcd10)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CodeICD10");
            entity.Property(e => e.CodeSnomed)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CodeSNOMED");
            entity.Property(e => e.DiagText).IsUnicode(false);
            entity.Property(e => e.DoNotReconcile)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Dosdate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DOSDate");
            entity.Property(e => e.IsResolved1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsResolved2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Location1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Location2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Location2OnsetVisitId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Location2OnsetVisitID");
            entity.Property(e => e.Modifier)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OnsetDay1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OnsetDay2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OnsetMonth1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OnsetMonth2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OnsetYear1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OnsetYear2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.RequestedProcedureId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RequestedProcedureID");
            entity.Property(e => e.ResolveType1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ResolveType2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ResolvedDate1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ResolvedDate2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ResolvedRequestedProcedureId1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ResolvedRequestedProcedureID1");
            entity.Property(e => e.ResolvedRequestedProcedureId2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ResolvedRequestedProcedureID2");
            entity.Property(e => e.ResolvedVisitId1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ResolvedVisitID1");
            entity.Property(e => e.ResolvedVisitId2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ResolvedVisitID2");
            entity.Property(e => e.SourceField)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<DiagTest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DiagTest__3214EC277866F33C");

            entity.ToTable("DiagTest");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Dosdate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DOSDate");
            entity.Property(e => e.GonioAngleDepthInOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GonioAngleDepthInOD");
            entity.Property(e => e.GonioAngleDepthInOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GonioAngleDepthInOS");
            entity.Property(e => e.GonioAngleDepthMedialOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GonioAngleDepthMedialOD");
            entity.Property(e => e.GonioAngleDepthMedialOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GonioAngleDepthMedialOS");
            entity.Property(e => e.GonioAngleDepthSuOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GonioAngleDepthSuOD");
            entity.Property(e => e.GonioAngleDepthSuOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GonioAngleDepthSuOS");
            entity.Property(e => e.GonioAngleDepthTemporalOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GonioAngleDepthTemporalOD");
            entity.Property(e => e.GonioAngleDepthTemporalOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GonioAngleDepthTemporalOS");
            entity.Property(e => e.GonioAngleStructureInOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GonioAngleStructureInOD");
            entity.Property(e => e.GonioAngleStructureInOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GonioAngleStructureInOS");
            entity.Property(e => e.GonioAngleStructureMedialOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GonioAngleStructureMedialOD");
            entity.Property(e => e.GonioAngleStructureMedialOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GonioAngleStructureMedialOS");
            entity.Property(e => e.GonioAngleStructureSuOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GonioAngleStructureSuOD");
            entity.Property(e => e.GonioAngleStructureSuOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GonioAngleStructureSuOS");
            entity.Property(e => e.GonioAngleStructureTemporalOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GonioAngleStructureTemporalOD");
            entity.Property(e => e.GonioAngleStructureTemporalOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GonioAngleStructureTemporalOS");
            entity.Property(e => e.GonioComments)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GonioPigmentOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GonioPigmentOD");
            entity.Property(e => e.GonioPigmentOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GonioPigmentOS");
            entity.Property(e => e.MbalanceCcortho)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceCCOrtho");
            entity.Property(e => e.MbalanceCctype)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceCCType");
            entity.Property(e => e.MbalanceHorizCcdownGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizCCDownGaze");
            entity.Property(e => e.MbalanceHorizCcdownLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizCCDownLtGaze");
            entity.Property(e => e.MbalanceHorizCcdownRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizCCDownRtGaze");
            entity.Property(e => e.MbalanceHorizCcltGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizCCLtGaze");
            entity.Property(e => e.MbalanceHorizCcpriGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizCCPriGaze");
            entity.Property(e => e.MbalanceHorizCcrtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizCCRtGaze");
            entity.Property(e => e.MbalanceHorizCcupGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizCCUpGaze");
            entity.Property(e => e.MbalanceHorizCcupLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizCCUpLtGaze");
            entity.Property(e => e.MbalanceHorizCcupRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizCCUpRtGaze");
            entity.Property(e => e.MbalanceHorizScdownGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizSCDownGaze");
            entity.Property(e => e.MbalanceHorizScdownLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizSCDownLtGaze");
            entity.Property(e => e.MbalanceHorizScdownRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizSCDownRtGaze");
            entity.Property(e => e.MbalanceHorizScltGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizSCLtGaze");
            entity.Property(e => e.MbalanceHorizScpriGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizSCPriGaze");
            entity.Property(e => e.MbalanceHorizScrtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizSCRtGaze");
            entity.Property(e => e.MbalanceHorizScupGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizSCUpGaze");
            entity.Property(e => e.MbalanceHorizScupLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizSCUpLtGaze");
            entity.Property(e => e.MbalanceHorizScupRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizSCUpRtGaze");
            entity.Property(e => e.MbalanceHorizTypeCcdownGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizTypeCCDownGaze");
            entity.Property(e => e.MbalanceHorizTypeCcdownLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizTypeCCDownLtGaze");
            entity.Property(e => e.MbalanceHorizTypeCcdownRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizTypeCCDownRtGaze");
            entity.Property(e => e.MbalanceHorizTypeCcltGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizTypeCCLtGaze");
            entity.Property(e => e.MbalanceHorizTypeCcpriGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizTypeCCPriGaze");
            entity.Property(e => e.MbalanceHorizTypeCcrtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizTypeCCRtGaze");
            entity.Property(e => e.MbalanceHorizTypeCcupGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizTypeCCUpGaze");
            entity.Property(e => e.MbalanceHorizTypeCcupLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizTypeCCUpLtGaze");
            entity.Property(e => e.MbalanceHorizTypeCcupRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizTypeCCUpRtGaze");
            entity.Property(e => e.MbalanceHorizTypeScdownGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizTypeSCDownGaze");
            entity.Property(e => e.MbalanceHorizTypeScdownLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizTypeSCDownLtGaze");
            entity.Property(e => e.MbalanceHorizTypeScdownRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizTypeSCDownRtGaze");
            entity.Property(e => e.MbalanceHorizTypeScltGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizTypeSCLtGaze");
            entity.Property(e => e.MbalanceHorizTypeScpriGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizTypeSCPriGaze");
            entity.Property(e => e.MbalanceHorizTypeScrtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizTypeSCRtGaze");
            entity.Property(e => e.MbalanceHorizTypeScupGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizTypeSCUpGaze");
            entity.Property(e => e.MbalanceHorizTypeScupLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizTypeSCUpLtGaze");
            entity.Property(e => e.MbalanceHorizTypeScupRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizTypeSCUpRtGaze");
            entity.Property(e => e.MbalanceMethod)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceMethod");
            entity.Property(e => e.MbalanceMethodCc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceMethodCC");
            entity.Property(e => e.MbalanceMethodSc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceMethodSC");
            entity.Property(e => e.MbalanceScortho)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceSCOrtho");
            entity.Property(e => e.MbalanceSctype)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceSCType");
            entity.Property(e => e.MbalanceVertCcdownGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertCCDownGaze");
            entity.Property(e => e.MbalanceVertCcdownLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertCCDownLtGaze");
            entity.Property(e => e.MbalanceVertCcdownRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertCCDownRtGaze");
            entity.Property(e => e.MbalanceVertCcltGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertCCLtGaze");
            entity.Property(e => e.MbalanceVertCcpriGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertCCPriGaze");
            entity.Property(e => e.MbalanceVertCcrtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertCCRtGaze");
            entity.Property(e => e.MbalanceVertCcupGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertCCUpGaze");
            entity.Property(e => e.MbalanceVertCcupLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertCCUpLtGaze");
            entity.Property(e => e.MbalanceVertCcupRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertCCUpRtGaze");
            entity.Property(e => e.MbalanceVertScdownGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertSCDownGaze");
            entity.Property(e => e.MbalanceVertScdownLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertSCDownLtGaze");
            entity.Property(e => e.MbalanceVertScdownRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertSCDownRtGaze");
            entity.Property(e => e.MbalanceVertScltGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertSCLtGaze");
            entity.Property(e => e.MbalanceVertScpriGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertSCPriGaze");
            entity.Property(e => e.MbalanceVertScrtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertSCRtGaze");
            entity.Property(e => e.MbalanceVertScupGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertSCUpGaze");
            entity.Property(e => e.MbalanceVertScupLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertSCUpLtGaze");
            entity.Property(e => e.MbalanceVertScupRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertSCUpRtGaze");
            entity.Property(e => e.MbalanceVertTypeCcdownGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertTypeCCDownGaze");
            entity.Property(e => e.MbalanceVertTypeCcdownLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertTypeCCDownLtGaze");
            entity.Property(e => e.MbalanceVertTypeCcdownRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertTypeCCDownRtGaze");
            entity.Property(e => e.MbalanceVertTypeCcltGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertTypeCCLtGaze");
            entity.Property(e => e.MbalanceVertTypeCcpriGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertTypeCCPriGaze");
            entity.Property(e => e.MbalanceVertTypeCcrtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertTypeCCRtGaze");
            entity.Property(e => e.MbalanceVertTypeCcupGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertTypeCCUpGaze");
            entity.Property(e => e.MbalanceVertTypeCcupLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertTypeCCUpLtGaze");
            entity.Property(e => e.MbalanceVertTypeCcupRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertTypeCCUpRtGaze");
            entity.Property(e => e.MbalanceVertTypeScdownGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertTypeSCDownGaze");
            entity.Property(e => e.MbalanceVertTypeScdownLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertTypeSCDownLtGaze");
            entity.Property(e => e.MbalanceVertTypeScdownRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertTypeSCDownRtGaze");
            entity.Property(e => e.MbalanceVertTypeScltGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertTypeSCLtGaze");
            entity.Property(e => e.MbalanceVertTypeScpriGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertTypeSCPriGaze");
            entity.Property(e => e.MbalanceVertTypeScrtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertTypeSCRtGaze");
            entity.Property(e => e.MbalanceVertTypeScupGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertTypeSCUpGaze");
            entity.Property(e => e.MbalanceVertTypeScupLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertTypeSCUpLtGaze");
            entity.Property(e => e.MbalanceVertTypeScupRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertTypeSCUpRtGaze");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.SmotorAbute)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorABUTE");
            entity.Property(e => e.SmotorAvpattern)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorAVPattern");
            entity.Property(e => e.SmotorColorVisionOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorColorVisionOD");
            entity.Property(e => e.SmotorColorVisionOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorColorVisionOS");
            entity.Property(e => e.SmotorColorVisionType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorColorVisionType");
            entity.Property(e => e.SmotorComments)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("SMotorComments");
            entity.Property(e => e.SmotorDirectionOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorDirectionOD");
            entity.Property(e => e.SmotorDirectionOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorDirectionOS");
            entity.Property(e => e.SmotorDistStereo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorDistStereo");
            entity.Property(e => e.SmotorDistVectograph)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorDistVectograph");
            entity.Property(e => e.SmotorDmadRodOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorDMadRodOD");
            entity.Property(e => e.SmotorDmadRodOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorDMadRodOS");
            entity.Property(e => e.SmotorDmadRodTorsionOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorDMadRodTorsionOD");
            entity.Property(e => e.SmotorDmadRodTorsionOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorDMadRodTorsionOS");
            entity.Property(e => e.SmotorFixPrefDist)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorFixPrefDist");
            entity.Property(e => e.SmotorFixPrefNear)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorFixPrefNear");
            entity.Property(e => e.SmotorFrisby)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorFrisby");
            entity.Property(e => e.SmotorHorizCcdist)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHorizCCDist");
            entity.Property(e => e.SmotorHorizCcnear)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHorizCCNear");
            entity.Property(e => e.SmotorHorizCcnear3Plus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHorizCCNear3Plus");
            entity.Property(e => e.SmotorHorizScdist)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHorizSCDist");
            entity.Property(e => e.SmotorHorizScnear)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHorizSCNear");
            entity.Property(e => e.SmotorHorizTypeCcdist)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHorizTypeCCDist");
            entity.Property(e => e.SmotorHorizTypeCcnear)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHorizTypeCCNear");
            entity.Property(e => e.SmotorHorizTypeCcnear3Plus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHorizTypeCCNear3Plus");
            entity.Property(e => e.SmotorHorizTypeScdist)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHorizTypeSCDist");
            entity.Property(e => e.SmotorHorizTypeScnear)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHorizTypeSCNear");
            entity.Property(e => e.SmotorHorizVergBibreak)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHorizVergBIBreak");
            entity.Property(e => e.SmotorHorizVergBirecover)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHorizVergBIRecover");
            entity.Property(e => e.SmotorHorizVergBobreak)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHorizVergBOBreak");
            entity.Property(e => e.SmotorHorizVergBorecover)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHorizVergBORecover");
            entity.Property(e => e.SmotorHtltHorizCc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHTLtHorizCC");
            entity.Property(e => e.SmotorHtltHorizSc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHTLtHorizSC");
            entity.Property(e => e.SmotorHtltHorizTypeCc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHTLtHorizTypeCC");
            entity.Property(e => e.SmotorHtltHorizTypeSc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHTLtHorizTypeSC");
            entity.Property(e => e.SmotorHtltVertCc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHTLtVertCC");
            entity.Property(e => e.SmotorHtltVertSc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHTLtVertSC");
            entity.Property(e => e.SmotorHtltVertTypeCc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHTLtVertTypeCC");
            entity.Property(e => e.SmotorHtltVertTypeSc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHTLtVertTypeSC");
            entity.Property(e => e.SmotorHtrtHorizCc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHTRtHorizCC");
            entity.Property(e => e.SmotorHtrtHorizSc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHTRtHorizSC");
            entity.Property(e => e.SmotorHtrtHorizTypeCc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHTRtHorizTypeCC");
            entity.Property(e => e.SmotorHtrtHorizTypeSc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHTRtHorizTypeSC");
            entity.Property(e => e.SmotorHtrtVertCc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHTRtVertCC");
            entity.Property(e => e.SmotorHtrtVertSc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHTRtVertSC");
            entity.Property(e => e.SmotorHtrtVertTypeCc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHTRtVertTypeCC");
            entity.Property(e => e.SmotorHtrtVertTypeSc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHTRtVertTypeSC");
            entity.Property(e => e.SmotorLang)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorLang");
            entity.Property(e => e.SmotorNpc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorNPC");
            entity.Property(e => e.SmotorNystagmus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorNystagmus");
            entity.Property(e => e.SmotorPrismOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorPrismOD");
            entity.Property(e => e.SmotorPrismOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorPrismOS");
            entity.Property(e => e.SmotorRandotCircles)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorRandotCircles");
            entity.Property(e => e.SmotorTitmusStereoAnimals)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorTitmusStereoAnimals");
            entity.Property(e => e.SmotorTitmusStereoCircles)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorTitmusStereoCircles");
            entity.Property(e => e.SmotorTitmusStereoFly)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorTitmusStereoFly");
            entity.Property(e => e.SmotorVertCcdist)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorVertCCDist");
            entity.Property(e => e.SmotorVertCcnear)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorVertCCNear");
            entity.Property(e => e.SmotorVertCcnear3Plus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorVertCCNear3Plus");
            entity.Property(e => e.SmotorVertScdist)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorVertSCDist");
            entity.Property(e => e.SmotorVertScnear)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorVertSCNear");
            entity.Property(e => e.SmotorVertTypeCcdist)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorVertTypeCCDist");
            entity.Property(e => e.SmotorVertTypeCcnear)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorVertTypeCCNear");
            entity.Property(e => e.SmotorVertTypeCcnear3Plus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorVertTypeCCNear3Plus");
            entity.Property(e => e.SmotorVertTypeScdist)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorVertTypeSCDist");
            entity.Property(e => e.SmotorVertTypeScnear)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorVertTypeSCNear");
            entity.Property(e => e.SmotorVertVergBdbreak)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorVertVergBDBreak");
            entity.Property(e => e.SmotorVertVergBdrecover)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorVertVergBDRecover");
            entity.Property(e => e.SmotorVertVergBubreak)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorVertVergBUBreak");
            entity.Property(e => e.SmotorVertVergBurecover)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorVertVergBURecover");
            entity.Property(e => e.SmotorWorth4DotDist)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorWorth4DotDist");
            entity.Property(e => e.SmotorWorth4DotNear)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorWorth4DotNear");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<ExamCondition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ExamCond__3214EC2739C8BCFA");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Comment)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Condition)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ConditionValue).IsUnicode(false);
            entity.Property(e => e.Dosdate)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DOSDate");
            entity.Property(e => e.Eye)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<FamilyHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FamilyHi__3214EC27675CE7F1");

            entity.ToTable("FamilyHistory");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Age)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CodeIcd10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CodeICD10");
            entity.Property(e => e.CodeIcd9)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CodeICD9");
            entity.Property(e => e.CodeSnomed)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CodeSNOMED");
            entity.Property(e => e.Comments)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Dosdate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DOSDate");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.Relation)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<Iop>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__IOP__3214EC27F069E049");

            entity.ToTable("IOP");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CornealHysteresisOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CornealHysteresisOD");
            entity.Property(e => e.CornealHysteresisOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CornealHysteresisOS");
            entity.Property(e => e.Dosdate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DOSDate");
            entity.Property(e => e.Iopccod)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("IOPCCOD");
            entity.Property(e => e.Iopccos)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("IOPCCOS");
            entity.Property(e => e.IopdeviceUsed)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IOPDeviceUsed");
            entity.Property(e => e.Iopnotes)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IOPNotes");
            entity.Property(e => e.Iopod)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("IOPOD");
            entity.Property(e => e.Iopos)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("IOPOS");
            entity.Property(e => e.IoptimeTaken)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("IOPTimeTaken");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<MedicalHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Medical___3214EC273A44D3A0");

            entity.ToTable("MedicalHistory");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CodeIcd10)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CodeICD10");
            entity.Property(e => e.CodeSnomed)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CodeSNOMED");
            entity.Property(e => e.ControlId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ControlID");
            entity.Property(e => e.Created)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedEmpId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CreatedEmpID");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DoNotReconcile)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Dosdate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DOSDate");
            entity.Property(e => e.IsResolved1)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.IsResolved2)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LastModified)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedEmpId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LastModifiedEmpID");
            entity.Property(e => e.Location1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Location2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Location2OnsetVisitId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Location2OnsetVisitID");
            entity.Property(e => e.Modifier)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OnsetDay1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OnsetDay2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OnsetMonth1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OnsetMonth2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OnsetYear1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OnsetYear2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OrigDosdate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("OrigDOSDate");
            entity.Property(e => e.OrigVisitDiagCodePoolId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OrigVisitDiagCodePoolID");
            entity.Property(e => e.OrigVisitMedicalHistoryId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OrigVisitMedicalHistoryID");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.ResolveType1)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ResolveType2)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ResolvedDate1)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ResolvedDate2)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ResolvedRequestedProcedureId1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ResolvedRequestedProcedureID1");
            entity.Property(e => e.ResolvedRequestedProcedureId2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ResolvedRequestedProcedureID2");
            entity.Property(e => e.ResolvedVisitId1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ResolvedVisitID1");
            entity.Property(e => e.ResolvedVisitId2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ResolvedVisitID2");
            entity.Property(e => e.Severity1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Severity2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TypeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("TypeID");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });
/*
        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Patients__3214EC275C78C6D4");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ChartNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ClientSoftwarePtIdassignAuth)
                .HasMaxLength(50)
                .HasColumnName("ClientSoftwarePtIDAssignAuth");
            entity.Property(e => e.ClientSoftwarePtIdassignAuthIdtype)
                .HasMaxLength(50)
                .HasColumnName("ClientSoftwarePtIDAssignAuthIDType");
            entity.Property(e => e.ErxSystemAccessed).HasColumnName("ERxSystemAccessed");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GenderIdentityConceptCode).HasMaxLength(50);
            entity.Property(e => e.GenderIdentityId).HasColumnName("GenderIdentityID");
            entity.Property(e => e.GenderIdentityOtherDescription).HasMaxLength(50);
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PatientCity).HasMaxLength(50);
            entity.Property(e => e.PatientCreated).HasColumnType("datetime");
            entity.Property(e => e.PatientDefaultEyeCareProviderId).HasColumnName("PatientDefaultEyeCareProviderID");
            entity.Property(e => e.PatientDefaultPriProviderId).HasColumnName("PatientDefaultPriProviderID");
            entity.Property(e => e.PatientDefaultRefProviderId).HasColumnName("PatientDefaultRefProviderID");
            entity.Property(e => e.PatientDob)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PatientDOB");
            entity.Property(e => e.PatientEmail)
                .HasMaxLength(255)
                .HasColumnName("PatientEMail");
            entity.Property(e => e.PatientEthnicity).HasMaxLength(60);
            entity.Property(e => e.PatientFaxPhone).HasMaxLength(50);
            entity.Property(e => e.PatientGuardianDob)
                .HasColumnType("datetime")
                .HasColumnName("PatientGuardianDOB");
            entity.Property(e => e.PatientGuardianNameFirst).HasMaxLength(50);
            entity.Property(e => e.PatientGuardianNameLast).HasMaxLength(50);
            entity.Property(e => e.PatientGuardianNameMiddle).HasMaxLength(50);
            entity.Property(e => e.PatientHomePhone).HasMaxLength(50);
            entity.Property(e => e.PatientInsPri).HasMaxLength(255);
            entity.Property(e => e.PatientInsPriId)
                .HasMaxLength(50)
                .HasColumnName("PatientInsPriID");
            entity.Property(e => e.PatientInsSec).HasMaxLength(255);
            entity.Property(e => e.PatientInsSecId)
                .HasMaxLength(50)
                .HasColumnName("PatientInsSecID");
            entity.Property(e => e.PatientLastEdited).HasColumnType("datetime");
            entity.Property(e => e.PatientMaritalStatus).HasMaxLength(60);
            entity.Property(e => e.PatientMobilePhone).HasMaxLength(50);
            entity.Property(e => e.PatientNameSuffix).HasMaxLength(50);
            entity.Property(e => e.PatientPreferredContactMethod).HasMaxLength(100);
            entity.Property(e => e.PatientPreferredLanguage).HasMaxLength(60);
            entity.Property(e => e.PatientPreviousCity).HasMaxLength(50);
            entity.Property(e => e.PatientPreviousState).HasMaxLength(50);
            entity.Property(e => e.PatientPreviousZip).HasMaxLength(50);
            entity.Property(e => e.PatientRace).HasMaxLength(60);
            entity.Property(e => e.PatientSex).HasMaxLength(50);
            entity.Property(e => e.PatientSsn)
                .HasMaxLength(110)
                .HasColumnName("PatientSSN");
            entity.Property(e => e.PatientState).HasMaxLength(50);
            entity.Property(e => e.PatientWorkPhone).HasMaxLength(50);
            entity.Property(e => e.PatientZip).HasMaxLength(50);
            entity.Property(e => e.PmimportCheckInNote).HasColumnName("PMImportCheckInNote");
            entity.Property(e => e.PmpatientId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PMPatientID");
            entity.Property(e => e.PtDeceasedDate).HasColumnType("datetime");
            entity.Property(e => e.SexualOrientationConceptCode).HasMaxLength(50);
            entity.Property(e => e.SexualOrientationId).HasColumnName("SexualOrientationID");
            entity.Property(e => e.SexualOrientationOtherDescription).HasMaxLength(50);
            entity.Property(e => e.UpsizeTs)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("upsizeTs");
        });*/

        modelBuilder.Entity<PatientDocument>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PatientD__3214EC2707B1DC0E");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AaohandoutsInfo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AAOHandoutsInfo");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.AmendRequest)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AmendRequestDate)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.AmendResultDate)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.AmendSource)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ControlId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ControlID");
            entity.Property(e => e.Date)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Dicommodality)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DICOMModality");
            entity.Property(e => e.DicomptDob)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DICOMPtDOB");
            entity.Property(e => e.DicomptName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DICOMPtName");
            entity.Property(e => e.DicomrequestedProcedureId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DICOMRequestedProcedureID");
            entity.Property(e => e.DicomscheduledProcedureStepId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DICOMScheduledProcedureStepID");
            entity.Property(e => e.DicomstudyId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DICOMStudyID");
            entity.Property(e => e.DocumentClass)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DocumentDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DocumentImageType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DocumentNotes)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DocumentSha1hashes)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DocumentSHA1Hashes");
            entity.Property(e => e.EdgeHash)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EdgeUploadPending)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FhirCategory)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FhirCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FilePathName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ImageDevice)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.InstanceNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsSummaryRecord)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Laterality)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Mdreview)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MDReview");
            entity.Property(e => e.Mdreviewed)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MDReviewed");
            entity.Property(e => e.MdreviewedDate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MDReviewedDate");
            entity.Property(e => e.MdreviewedEmpId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MDReviewedEmpID");
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.PatientInsuranceCompany)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Prioritize)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReconciledCcdavisitId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ReconciledCCDAVisitID");
            entity.Property(e => e.Reference)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReferencedSopinstanceUid)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ReferencedSOPInstanceUID");
            entity.Property(e => e.RelatedIomid)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RelatedIOMID");
            entity.Property(e => e.RelatedProviderId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RelatedProviderID");
            entity.Property(e => e.RelatedSiteId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RelatedSiteID");
            entity.Property(e => e.RepresentativeFrame)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RequestedProcedureId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("RequestedProcedureID");
            entity.Property(e => e.SeriesInstanceUid)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SeriesInstanceUID");
            entity.Property(e => e.SeriesNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SopclassUid)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SOPClassUID");
            entity.Property(e => e.SopinstanceUid)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SOPInstanceUID");
            entity.Property(e => e.StudyInstanceUid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("StudyInstanceUID");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<PatientNote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Patient___3214EC278BFDC470");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Created)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Dosdate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DOSDate");
            entity.Property(e => e.EmpId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EmpID");
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<PlanNarrative>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Plan_Nar__3214EC272B4834D2");

            entity.ToTable("PlanNarrative");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DisplayOrder)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Dosdate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DOSDate");
            entity.Property(e => e.Icd10code)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ICD10Code");
            entity.Property(e => e.Icd9code)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ICD9Code");
            entity.Property(e => e.NarrativeHeader)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NarrativeText).IsUnicode(false);
            entity.Property(e => e.NarrativeType)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.Snomedcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SNOMEDCode");
            entity.Property(e => e.VisitDiagCodePoolId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VisitDiagCodePoolID");
            entity.Property(e => e.VisitDoctorId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VisitDoctorID");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<ProcDiagPool>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proc_Dia__3214EC27CD2F46BF");

            entity.ToTable("ProcDiagPool");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Dosdate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DOSDate");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.RequestedProcedureId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RequestedProcedureID");
            entity.Property(e => e.VisitDiagCodePoolId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VisitDiagCodePoolID");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
            entity.Property(e => e.VisitProcCodePoolId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VisitProcCodePoolID");
        });

        modelBuilder.Entity<ProcPool>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proc_Poo__3214EC2794E5BEEE");

            entity.ToTable("ProcPool");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.AdditionalModifier)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BillMultiProcControlId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("BillMultiProcControlID");
            entity.Property(e => e.BillMultiProcId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("BillMultiProcID");
            entity.Property(e => e.BillingOrder)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Denominator)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DenominatorException)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DenominatorExclusion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Dosdate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DOSDate");
            entity.Property(e => e.EyeMdqrnum)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EyeMDQRNum");
            entity.Property(e => e.InitialPatientPopulation)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.IsBilled)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.IsHidden)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.IsQr)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("IsQR");
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Modifier)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NotPorelated)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("NotPORelated");
            entity.Property(e => e.Nqfnum)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NQFNum");
            entity.Property(e => e.Numerator)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OriginalModifier)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Pqrsnum)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PQRSNum");
            entity.Property(e => e.ProcDiagTestComponents)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProcLocationType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ProcText)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ProcType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.Qrcomponent)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("QRComponent");
            entity.Property(e => e.RequestedProcedureId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RequestedProcedureID");
            entity.Property(e => e.SentInVisit)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.SourceField)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SourceRecordId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SourceRecordID");
            entity.Property(e => e.Units)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<Refraction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Refracti__3214EC27C183FCB9");

            entity.ToTable("Refraction");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Age)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.AxisOd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("AxisOD");
            entity.Property(e => e.AxisOs)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("AxisOS");
            entity.Property(e => e.BifocalAddOd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BifocalAddOD");
            entity.Property(e => e.BifocalAddOs)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BifocalAddOS");
            entity.Property(e => e.CylinderOd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CylinderOD");
            entity.Property(e => e.CylinderOs)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CylinderOS");
            entity.Property(e => e.DirectionHod)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DirectionHOD");
            entity.Property(e => e.DirectionHos)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DirectionHOS");
            entity.Property(e => e.DirectionVod)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DirectionVOD");
            entity.Property(e => e.DirectionVos)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DirectionVOS");
            entity.Property(e => e.Dosdate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DOSDate");
            entity.Property(e => e.Expires)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PddistOd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PDDistOD");
            entity.Property(e => e.PddistOs)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PDDistOS");
            entity.Property(e => e.PdnearOd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PDNearOD");
            entity.Property(e => e.PdnearOs)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PDNearOS");
            entity.Property(e => e.Prism360Od)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Prism360OD");
            entity.Property(e => e.Prism360Os)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Prism360OS");
            entity.Property(e => e.PrismHorzOd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PrismHorzOD");
            entity.Property(e => e.PrismHorzOs)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PrismHorzOS");
            entity.Property(e => e.PrismVertOd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PrismVertOD");
            entity.Property(e => e.PrismVertOs)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PrismVertOS");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.RefractionClass)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RefractionType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Remarks)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.SphereOd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SphereOD");
            entity.Property(e => e.SphereOs)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SphereOS");
            entity.Property(e => e.VaDod)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("VaDOD");
            entity.Property(e => e.VaDos)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("VaDOS");
            entity.Property(e => e.VaDou)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("VaDOU");
            entity.Property(e => e.VaIod)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("VaIOD");
            entity.Property(e => e.VaIos)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("VaIOS");
            entity.Property(e => e.VaIou)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("VaIOU");
            entity.Property(e => e.VaNod)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("VaNOD");
            entity.Property(e => e.VaNos)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("VaNOS");
            entity.Property(e => e.VaNou)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("VaNOU");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<Ro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ROS__3214EC27C6C7D2B6");

            entity.ToTable("ROS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Dosdate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DOSDate");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.RosbloodCustomDesc1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROSBloodCustomDesc1");
            entity.Property(e => e.RosbloodCustomDesc2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROSBloodCustomDesc2");
            entity.Property(e => e.RosbloodCustomValue1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSBloodCustomValue1");
            entity.Property(e => e.RosbloodCustomValue2)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSBloodCustomValue2");
            entity.Property(e => e.RosbloodEasyBruise)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSBloodEasyBruise");
            entity.Property(e => e.RosbloodGumsBleed)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSBloodGumsBleed");
            entity.Property(e => e.RosbloodHeavyAsprin)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSBloodHeavyAsprin");
            entity.Property(e => e.RosbloodProlongedBleed)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSBloodProlongedBleed");
            entity.Property(e => e.RoscardioChestPain)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSCardioChestPain");
            entity.Property(e => e.RoscardioCustomDesc1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROSCardioCustomDesc1");
            entity.Property(e => e.RoscardioCustomDesc2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROSCardioCustomDesc2");
            entity.Property(e => e.RoscardioCustomValue1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSCardioCustomValue1");
            entity.Property(e => e.RoscardioCustomValue2)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSCardioCustomValue2");
            entity.Property(e => e.RoscardioDiffLyingFlat)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSCardioDiffLyingFlat");
            entity.Property(e => e.RoscardioDizziness)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSCardioDizziness");
            entity.Property(e => e.RoscardioFainting)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSCardioFainting");
            entity.Property(e => e.RoscardioIrreHeartBeat)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSCardioIrreHeartBeat");
            entity.Property(e => e.RoscardioShortBreath)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSCardioShortBreath");
            entity.Property(e => e.RosconsCustomDesc1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROSConsCustomDesc1");
            entity.Property(e => e.RosconsCustomDesc2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROSConsCustomDesc2");
            entity.Property(e => e.RosconsCustomValue1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSConsCustomValue1");
            entity.Property(e => e.RosconsCustomValue2)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSConsCustomValue2");
            entity.Property(e => e.RosconsFatigue)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSConsFatigue");
            entity.Property(e => e.RosconsFever)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSConsFever");
            entity.Property(e => e.RosconsWeightGainLoss)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSConsWeightGainLoss");
            entity.Property(e => e.RosendoCustomDesc1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROSEndoCustomDesc1");
            entity.Property(e => e.RosendoCustomDesc2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROSEndoCustomDesc2");
            entity.Property(e => e.RosendoCustomValue1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSEndoCustomValue1");
            entity.Property(e => e.RosendoCustomValue2)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSEndoCustomValue2");
            entity.Property(e => e.RosendoHunger)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSEndoHunger");
            entity.Property(e => e.RosendoNailChanges)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSEndoNailChanges");
            entity.Property(e => e.RosendoSweating)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSEndoSweating");
            entity.Property(e => e.RosendoThirst)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSEndoThirst");
            entity.Property(e => e.RosendoUrination)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSEndoUrination");
            entity.Property(e => e.RosentcustomDesc1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROSENTCustomDesc1");
            entity.Property(e => e.RosentcustomDesc2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROSENTCustomDesc2");
            entity.Property(e => e.RosentcustomValue1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSENTCustomValue1");
            entity.Property(e => e.RosentcustomValue2)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSENTCustomValue2");
            entity.Property(e => e.RosenthardHearing)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSENTHardHearing");
            entity.Property(e => e.RosentringingEars)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSENTRingingEars");
            entity.Property(e => e.Rosentvertigo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSENTVertigo");
            entity.Property(e => e.RoseyeCataracts)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSEyeCataracts");
            entity.Property(e => e.RoseyeContactLens)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSEyeContactLens");
            entity.Property(e => e.RoseyeCustomDesc1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROSEyeCustomDesc1");
            entity.Property(e => e.RoseyeCustomDesc2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROSEyeCustomDesc2");
            entity.Property(e => e.RoseyeCustomDesc3)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROSEyeCustomDesc3");
            entity.Property(e => e.RoseyeCustomDesc4)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROSEyeCustomDesc4");
            entity.Property(e => e.RoseyeCustomValue1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSEyeCustomValue1");
            entity.Property(e => e.RoseyeCustomValue2)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSEyeCustomValue2");
            entity.Property(e => e.RoseyeCustomValue3)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSEyeCustomValue3");
            entity.Property(e => e.RoseyeCustomValue4)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSEyeCustomValue4");
            entity.Property(e => e.RoseyeDblVision)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSEyeDblVision");
            entity.Property(e => e.RoseyeDryEyes)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSEyeDryEyes");
            entity.Property(e => e.RoseyeGlaucoma)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSEyeGlaucoma");
            entity.Property(e => e.RoseyeMacDegen)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSEyeMacDegen");
            entity.Property(e => e.RoseyePain)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSEyePain");
            entity.Property(e => e.RoseyePrevSurg)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSEyePrevSurg");
            entity.Property(e => e.RosgasCustomDesc1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROSGasCustomDesc1");
            entity.Property(e => e.RosgasCustomDesc2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROSGasCustomDesc2");
            entity.Property(e => e.RosgasCustomValue1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSGasCustomValue1");
            entity.Property(e => e.RosgasCustomValue2)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSGasCustomValue2");
            entity.Property(e => e.RosgasHeartBurn)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSGasHeartBurn");
            entity.Property(e => e.RosgasJaundiceHepa)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSGasJaundiceHepa");
            entity.Property(e => e.RosgasNausea)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSGasNausea");
            entity.Property(e => e.RosimmuCustomDesc1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROSImmuCustomDesc1");
            entity.Property(e => e.RosimmuCustomDesc2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROSImmuCustomDesc2");
            entity.Property(e => e.RosimmuCustomValue1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSImmuCustomValue1");
            entity.Property(e => e.RosimmuCustomValue2)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSImmuCustomValue2");
            entity.Property(e => e.RosimmuHives)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSImmuHives");
            entity.Property(e => e.RosimmuItching)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSImmuItching");
            entity.Property(e => e.RosimmuRunnyNose)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSImmuRunnyNose");
            entity.Property(e => e.RosimmuSinusPressure)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSImmuSinusPressure");
            entity.Property(e => e.RosmusSkeArthritis)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSMusSkeArthritis");
            entity.Property(e => e.RosmusSkeCustomDesc1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROSMusSkeCustomDesc1");
            entity.Property(e => e.RosmusSkeCustomDesc2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROSMusSkeCustomDesc2");
            entity.Property(e => e.RosmusSkeCustomValue1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSMusSkeCustomValue1");
            entity.Property(e => e.RosmusSkeCustomValue2)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSMusSkeCustomValue2");
            entity.Property(e => e.RosmusSkeJointPain)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSMusSkeJointPain");
            entity.Property(e => e.RosmusSkeStiffness)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSMusSkeStiffness");
            entity.Property(e => e.RosneuroCustomDesc1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROSNeuroCustomDesc1");
            entity.Property(e => e.RosneuroCustomDesc2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROSNeuroCustomDesc2");
            entity.Property(e => e.RosneuroCustomValue1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSNeuroCustomValue1");
            entity.Property(e => e.RosneuroCustomValue2)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSNeuroCustomValue2");
            entity.Property(e => e.RosneuroNumbness)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSNeuroNumbness");
            entity.Property(e => e.RosneuroSeizures)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSNeuroSeizures");
            entity.Property(e => e.RosneuroTremors)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSNeuroTremors");
            entity.Property(e => e.RosneuroWeakParalysis)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSNeuroWeakParalysis");
            entity.Property(e => e.Rosnotes)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ROSNotes");
            entity.Property(e => e.RospsycAnxiety)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSPsycAnxiety");
            entity.Property(e => e.RospsycCustomDesc1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROSPsycCustomDesc1");
            entity.Property(e => e.RospsycCustomDesc2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROSPsycCustomDesc2");
            entity.Property(e => e.RospsycCustomValue1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSPsycCustomValue1");
            entity.Property(e => e.RospsycCustomValue2)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSPsycCustomValue2");
            entity.Property(e => e.RospsycDiffSleeping)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSPsycDiffSleeping");
            entity.Property(e => e.RospsycMoodSwings)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSPsycMoodSwings");
            entity.Property(e => e.RosrespAsthma)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSRespAsthma");
            entity.Property(e => e.RosrespCongestion)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSRespCongestion");
            entity.Property(e => e.RosrespCough)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSRespCough");
            entity.Property(e => e.RosrespCustomDesc1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROSRespCustomDesc1");
            entity.Property(e => e.RosrespCustomDesc2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROSRespCustomDesc2");
            entity.Property(e => e.RosrespCustomValue1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSRespCustomValue1");
            entity.Property(e => e.RosrespCustomValue2)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSRespCustomValue2");
            entity.Property(e => e.RosrespWeezing)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSRespWeezing");
            entity.Property(e => e.RosskinCustomDesc1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROSSkinCustomDesc1");
            entity.Property(e => e.RosskinCustomDesc2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROSSkinCustomDesc2");
            entity.Property(e => e.RosskinCustomValue1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSSkinCustomValue1");
            entity.Property(e => e.RosskinCustomValue2)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSSkinCustomValue2");
            entity.Property(e => e.RosskinHivesEczema)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSSkinHivesEczema");
            entity.Property(e => e.RosskinLesions)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSSkinLesions");
            entity.Property(e => e.RosskinRashSores)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSSkinRashSores");
            entity.Property(e => e.RosurinaryBloodIn)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSUrinaryBloodIn");
            entity.Property(e => e.RosurinaryCustomDesc1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROSUrinaryCustomDesc1");
            entity.Property(e => e.RosurinaryCustomDesc2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROSUrinaryCustomDesc2");
            entity.Property(e => e.RosurinaryCustomValue1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSUrinaryCustomValue1");
            entity.Property(e => e.RosurinaryCustomValue2)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSUrinaryCustomValue2");
            entity.Property(e => e.RosurinaryKidneyStones)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSUrinaryKidneyStones");
            entity.Property(e => e.RosurinaryPainDifficulty)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSUrinaryPainDifficulty");
            entity.Property(e => e.RosurinaryStd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROSUrinarySTD");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<RxMedication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rx_Medic__3214EC27D33EF994");

            entity.ToTable("RxMedication");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.AdministeredMed)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.BrandMedOnly)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CalledInLocationId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CalledInLocationID");
            entity.Property(e => e.CalledInProviderEmpId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CalledInProviderEmpID");
            entity.Property(e => e.Created)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedEmpId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CreatedEmpID");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DoNotPrintRx)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DoNotReconcile)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Dosdate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DOSDate");
            entity.Property(e => e.DrugAltMappingId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DrugAltMappingID");
            entity.Property(e => e.DrugDeaclass)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DrugDEAClass");
            entity.Property(e => e.DrugFdastatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DrugFDAStatus");
            entity.Property(e => e.DrugForm)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DrugMappingId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DrugMappingID");
            entity.Property(e => e.DrugName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DrugNameId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DrugNameID");
            entity.Property(e => e.DrugRoute)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DrugStrength)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ErxGuid)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ERxGUID");
            entity.Property(e => e.ErxPendingTransmit)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ERxPendingTransmit");
            entity.Property(e => e.ErxStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ERxStatus");
            entity.Property(e => e.FormularyChecked)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.IsRefill)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LastModified)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedEmpId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LastModifiedEmpID");
            entity.Property(e => e.MedDisp)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.MedDispType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MedDispUnitType)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MedName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.MedRefill)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.MedSig)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.MedTableId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MedTableID");
            entity.Property(e => e.MedType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OriginalMedicationDate)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OriginalMedicationId)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("OriginalMedicationID");
            entity.Property(e => e.PrintedRx)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.RecordedEmpRole)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.RxDurationDays)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.RxEndDate)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RxRemarks)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.RxStartDate)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Rxcui)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RXCUI");
            entity.Property(e => e.SampleGiven)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.SentViaErx)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SentViaERx");
            entity.Property(e => e.Snomed)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SNOMED");
            entity.Property(e => e.VisitDiagCodePoolId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VisitDiagCodePoolID");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<SurgHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Surg_His__3214EC272A5C0430");

            entity.ToTable("SurgHistory");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CodeIcd10)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CodeICD10");
            entity.Property(e => e.CodeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CodeID");
            entity.Property(e => e.CodeSnomed)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CodeSNOMED");
            entity.Property(e => e.ComanageEmpId1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ComanageEmpID1");
            entity.Property(e => e.ComanageEmpId2)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ComanageEmpID2");
            entity.Property(e => e.ComanageFullName1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ComanageFullName2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ComanageRefProviderId1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ComanageRefProviderID1");
            entity.Property(e => e.ComanageRefProviderId2)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ComanageRefProviderID2");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DoNotReconcile)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Dosdate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DOSDate");
            entity.Property(e => e.Location1)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Location2)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Modifier)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OrigVisitDate)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.OrigVisitSurgicalHistoryId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OrigVisitSurgicalHistoryID");
            entity.Property(e => e.PerformedbyEmpId1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PerformedbyEmpID1");
            entity.Property(e => e.PerformedbyEmpId2)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PerformedbyEmpID2");
            entity.Property(e => e.PerformedbyFullName1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PerformedbyFullName2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PerformedbyRefProviderId1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PerformedbyRefProviderID1");
            entity.Property(e => e.PerformedbyRefProviderId2)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PerformedbyRefProviderID2");
            entity.Property(e => e.ProcedureDay1)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ProcedureDay2)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ProcedureMonth1)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ProcedureMonth2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProcedureYear1)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ProcedureYear2)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PtDeviceId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PtDeviceID");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.TypeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("TypeID");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<Tech>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tech__3214EC27BE9EDCBB");

            entity.ToTable("tech");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Created)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedEmpId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CreatedEmpID");
            entity.Property(e => e.Dosdate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DOSDate");
            entity.Property(e => e.HistoryMdreviewed)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("HistoryMDReviewed");
            entity.Property(e => e.HistoryMdreviewedDate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HistoryMDReviewedDate");
            entity.Property(e => e.HistoryMdreviewedEmpId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("HistoryMDReviewedEmpID");
            entity.Property(e => e.Hpi1letterText)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("HPI1LetterText");
            entity.Property(e => e.HpiadditionalComments1)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("HPIAdditionalComments1");
            entity.Property(e => e.HpiassoSignsSymp1)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("HPIAssoSignsSymp1");
            entity.Property(e => e.HpichiefComplaint)
                .IsUnicode(false)
                .HasColumnName("HPIChiefComplaint");
            entity.Property(e => e.Hpicontext1)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("HPIContext1");
            entity.Property(e => e.Hpiduration1)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("HPIDuration1");
            entity.Property(e => e.Hpilocation1)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("HPILocation1");
            entity.Property(e => e.HpimodFactors1)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("HPIModFactors1");
            entity.Property(e => e.Hpiquality1)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("HPIQuality1");
            entity.Property(e => e.Hpiseverity1)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("HPISeverity1");
            entity.Property(e => e.Hpitiming1)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("HPITiming1");
            entity.Property(e => e.IntakeReconciled)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LasstModified)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedEmpId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LastModifiedEmpID");
            entity.Property(e => e.MedRecNotPerformed)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.OldVisitId).HasColumnName("OldVisitID");
            entity.Property(e => e.Pmhalcohol)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PMHAlcohol");
            entity.Property(e => e.PmhalcoholHowMuch)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PMHAlcoholHowMuch");
            entity.Property(e => e.Pmhdrugs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PMHDrugs");
            entity.Property(e => e.PmhdrugsHowLong)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PMHDrugsHowLong");
            entity.Property(e => e.PmhdrugsHowMuch)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PMHDrugsHowMuch");
            entity.Property(e => e.PmhdrugsNames)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("PMHDrugsNames");
            entity.Property(e => e.PmhdrugsWhenQuit)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PMHDrugsWhenQuit");
            entity.Property(e => e.Pmhfhother)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("PMHFHOther");
            entity.Property(e => e.PmhsmokeHowLong)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PMHSmokeHowLong");
            entity.Property(e => e.PmhsmokeHowMuch)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PMHSmokeHowMuch");
            entity.Property(e => e.PmhsmokeWhenQuit)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PMHSmokeWhenQuit");
            entity.Property(e => e.Pmhsmoking)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PMHSmoking");
            entity.Property(e => e.PmhsmokingStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PMHSmokingStatus");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.VitalsBgl)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VitalsBGL");
            entity.Property(e => e.VitalsBglunits)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VitalsBGLUnits");
            entity.Property(e => e.VitalsBmi)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VitalsBMI");
            entity.Property(e => e.VitalsBmipercentile)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VitalsBMIPercentile");
            entity.Property(e => e.VitalsBpdia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VitalsBPDia");
            entity.Property(e => e.VitalsBpsys)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VitalsBPSys");
            entity.Property(e => e.VitalsHeight)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VitalsHeightUnits)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VitalsHofcpercentile)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("VitalsHOFCPercentile");
            entity.Property(e => e.VitalsInhaled02Concentration)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.VitalsPulse)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VitalsPulseOximetry)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.VitalsRespRate)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.VitalsTemp)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VitalsTempUnits)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VitalsWeight)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VitalsWeightUnits)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VitalsWflpercentile)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("VitalsWFLPercentile");
            entity.Property(e => e.WorkupMdreviewed)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("WorkupMDReviewed");
            entity.Property(e => e.WorkupMdreviewedDate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WorkupMDReviewedDate");
            entity.Property(e => e.WorkupMdreviewedEmpId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WorkupMDReviewedEmpID");
            entity.Property(e => e.WuamslerOd)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("WUAmslerOD");
            entity.Property(e => e.WuamslerOs)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("WUAmslerOS");
            entity.Property(e => e.Wucvfabute)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUCVFABUTE");
            entity.Property(e => e.WucvfdiagOd)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("WUCVFDiagOD");
            entity.Property(e => e.WucvfdiagOs)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("WUCVFDiagOS");
            entity.Property(e => e.Wudilated)
                .IsUnicode(false)
                .HasColumnName("WUDilated");
            entity.Property(e => e.WudilatedAgent)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("WUDilatedAgent");
            entity.Property(e => e.WudilatedEye)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUDilatedEye");
            entity.Property(e => e.WudilatedFrequency)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("WUDilatedFrequency");
            entity.Property(e => e.WudilatedTime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WUDilatedTime");
            entity.Property(e => e.WudilatedTimeZone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("WUDilatedTimeZone");
            entity.Property(e => e.WudomEye)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUDomEye");
            entity.Property(e => e.WueominNaOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUEOMInNaOD");
            entity.Property(e => e.WueominNaOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUEOMInNaOS");
            entity.Property(e => e.WueominTmOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUEOMInTmOD");
            entity.Property(e => e.WueominTmOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUEOMInTmOS");
            entity.Property(e => e.WueommedialOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUEOMMedialOD");
            entity.Property(e => e.WueommedialOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUEOMMedialOS");
            entity.Property(e => e.WueomsuNaOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUEOMSuNaOD");
            entity.Property(e => e.WueomsuNaOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUEOMSuNaOS");
            entity.Property(e => e.WueomsuTmOd)
                .IsUnicode(false)
                .HasColumnName("WUEOMSuTmOD");
            entity.Property(e => e.WueomsuTmOs)
                .IsUnicode(false)
                .HasColumnName("WUEOMSuTmOS");
            entity.Property(e => e.WueomtemporalOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUEOMTemporalOD");
            entity.Property(e => e.WueomtemporalOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUEOMTemporalOS");
            entity.Property(e => e.Wueomtype)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("WUEOMType");
            entity.Property(e => e.Wuextlids)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("WUEXTLids");
            entity.Property(e => e.Wuextorbits)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("WUEXTOrbits");
            entity.Property(e => e.Wuextpan)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("WUEXTPAN");
            entity.Property(e => e.Wuiopabute)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUIOPABUTE");
            entity.Property(e => e.Wumood)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("WUMood");
            entity.Property(e => e.Wunccod)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUNCCOD");
            entity.Property(e => e.Wunccos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUNCCOS");
            entity.Property(e => e.Wunccou)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUNCCOU");
            entity.Property(e => e.Wunotes)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("WUNotes");
            entity.Property(e => e.Wunscod)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUNSCOD");
            entity.Property(e => e.Wunscos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUNSCOS");
            entity.Property(e => e.Wunscou)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUNSCOU");
            entity.Property(e => e.WuorientPerson)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("WUOrientPerson");
            entity.Property(e => e.WuorientPlace)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("WUOrientPlace");
            entity.Property(e => e.WuorientSituation)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("WUOrientSituation");
            entity.Property(e => e.WuorientTime)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("WUOrientTime");
            entity.Property(e => e.WupupilApdod)
                .IsUnicode(false)
                .HasColumnName("WUPupilAPDOD");
            entity.Property(e => e.WupupilApdos)
                .IsUnicode(false)
                .HasColumnName("WUPupilAPDOS");
            entity.Property(e => e.WupupilDarkSizeOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUPupilDarkSizeOD");
            entity.Property(e => e.WupupilDarkSizeOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUPupilDarkSizeOS");
            entity.Property(e => e.WupupilLightSizeOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUPupilLightSizeOD");
            entity.Property(e => e.WupupilLightSizeOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUPupilLightSizeOS");
            entity.Property(e => e.WupupilNearOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUPupilNearOD");
            entity.Property(e => e.WupupilNearOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUPupilNearOS");
            entity.Property(e => e.WupupilReactionOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUPupilReactionOD");
            entity.Property(e => e.WupupilReactionOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUPupilReactionOS");
            entity.Property(e => e.WupupilShapeOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUPupilShapeOD");
            entity.Property(e => e.WupupilShapeOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUPupilShapeOS");
            entity.Property(e => e.Wutcvfod)
                .IsUnicode(false)
                .HasColumnName("WUTCVFOD");
            entity.Property(e => e.Wutcvfos)
                .IsUnicode(false)
                .HasColumnName("WUTCVFOS");
            entity.Property(e => e.Wuvaccod)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUVACCOD");
            entity.Property(e => e.Wuvaccos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUVACCOS");
            entity.Property(e => e.Wuvaccou)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUVACCOU");
            entity.Property(e => e.Wuvacctype)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("WUVACCType");
            entity.Property(e => e.Wuvaphod)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUVAPHOD");
            entity.Property(e => e.Wuvaphos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUVAPHOS");
            entity.Property(e => e.Wuvascod)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUVASCOD");
            entity.Property(e => e.Wuvascos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUVASCOS");
            entity.Property(e => e.Wuvascou)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUVASCOU");
            entity.Property(e => e.WuvatestUsed)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUVATestUsed");
        });

        modelBuilder.Entity<Tech2>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tech2__3214EC27F76BCDE1");

            entity.ToTable("tech2");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Dosdate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DOSDate");
            entity.Property(e => e.OldVisitId).HasColumnName("OldVisitID");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.Wu2custom10Data)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("WU2Custom10Data");
            entity.Property(e => e.Wu2custom10Desc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2Custom10Desc");
            entity.Property(e => e.Wu2custom11Data)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("WU2Custom11Data");
            entity.Property(e => e.Wu2custom11Desc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2Custom11Desc");
            entity.Property(e => e.Wu2custom12Data)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("WU2Custom12Data");
            entity.Property(e => e.Wu2custom12Desc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2Custom12Desc");
            entity.Property(e => e.Wu2custom13Data)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("WU2Custom13Data");
            entity.Property(e => e.Wu2custom13Desc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2Custom13Desc");
            entity.Property(e => e.Wu2custom14Data)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("WU2Custom14Data");
            entity.Property(e => e.Wu2custom14Desc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2Custom14Desc");
            entity.Property(e => e.Wu2custom15Data)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("WU2Custom15Data");
            entity.Property(e => e.Wu2custom15Desc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2Custom15Desc");
            entity.Property(e => e.Wu2custom16Data)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("WU2Custom16Data");
            entity.Property(e => e.Wu2custom16Desc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2Custom16Desc");
            entity.Property(e => e.Wu2custom17Data)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("WU2Custom17Data");
            entity.Property(e => e.Wu2custom17Desc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2Custom17Desc");
            entity.Property(e => e.Wu2custom18Data)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("WU2Custom18Data");
            entity.Property(e => e.Wu2custom18Desc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2Custom18Desc");
            entity.Property(e => e.Wu2custom19Data)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("WU2Custom19Data");
            entity.Property(e => e.Wu2custom19Desc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2Custom19Desc");
            entity.Property(e => e.Wu2custom1Data)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("WU2Custom1Data");
            entity.Property(e => e.Wu2custom1Desc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2Custom1Desc");
            entity.Property(e => e.Wu2custom20Data)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("WU2Custom20Data");
            entity.Property(e => e.Wu2custom20Desc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2Custom20Desc");
            entity.Property(e => e.Wu2custom21Data)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("WU2Custom21Data");
            entity.Property(e => e.Wu2custom21Desc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2Custom21Desc");
            entity.Property(e => e.Wu2custom22Data)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("WU2Custom22Data");
            entity.Property(e => e.Wu2custom22Desc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2Custom22Desc");
            entity.Property(e => e.Wu2custom2Data)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("WU2Custom2Data");
            entity.Property(e => e.Wu2custom2Desc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2Custom2Desc");
            entity.Property(e => e.Wu2custom3Data)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("WU2Custom3Data");
            entity.Property(e => e.Wu2custom3Desc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2Custom3Desc");
            entity.Property(e => e.Wu2custom4Data)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("WU2Custom4Data");
            entity.Property(e => e.Wu2custom4Desc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2Custom4Desc");
            entity.Property(e => e.Wu2custom5Data)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("WU2Custom5Data");
            entity.Property(e => e.Wu2custom5Desc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2Custom5Desc");
            entity.Property(e => e.Wu2custom6Data)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("WU2Custom6Data");
            entity.Property(e => e.Wu2custom6Desc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2Custom6Desc");
            entity.Property(e => e.Wu2custom7Data)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("WU2Custom7Data");
            entity.Property(e => e.Wu2custom7Desc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2Custom7Desc");
            entity.Property(e => e.Wu2custom8Data)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("WU2Custom8Data");
            entity.Property(e => e.Wu2custom8Desc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2Custom8Desc");
            entity.Property(e => e.Wu2custom9Data)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("WU2Custom9Data");
            entity.Property(e => e.Wu2custom9Desc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2Custom9Desc");
            entity.Property(e => e.Wu2glareHighOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2GlareHighOD");
            entity.Property(e => e.Wu2glareHighOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2GlareHighOS");
            entity.Property(e => e.Wu2glareLowOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2GlareLowOD");
            entity.Property(e => e.Wu2glareLowOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2GlareLowOS");
            entity.Property(e => e.Wu2glareMedOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2GlareMedOD");
            entity.Property(e => e.Wu2glareMedOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2GlareMedOS");
            entity.Property(e => e.Wu2glareType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2GlareType");
            entity.Property(e => e.Wu2hertelBase)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("WU2HertelBase");
            entity.Property(e => e.Wu2hertelOd)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("WU2HertelOD");
            entity.Property(e => e.Wu2hertelOs)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("WU2HertelOS");
            entity.Property(e => e.Wu2kmaxDegOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2KMaxDegOD");
            entity.Property(e => e.Wu2kmaxDegOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2KMaxDegOS");
            entity.Property(e => e.Wu2kmaxOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2KMaxOD");
            entity.Property(e => e.Wu2kmaxOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2KMaxOS");
            entity.Property(e => e.Wu2kminDegOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2KMinDegOD");
            entity.Property(e => e.Wu2kminDegOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2KMinDegOS");
            entity.Property(e => e.Wu2kminOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2KMinOD");
            entity.Property(e => e.Wu2kminOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2KMinOS");
            entity.Property(e => e.Wu2ktype)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("WU2KType");
            entity.Property(e => e.Wu2pachCctod)
                .IsUnicode(false)
                .HasColumnName("WU2PachCCTOD");
            entity.Property(e => e.Wu2pachCctos)
                .IsUnicode(false)
                .HasColumnName("WU2PachCCTOS");
            entity.Property(e => e.Wu2tearOsmolarityCollectionDifficult)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("WU2TearOsmolarityCollectionDifficult");
            entity.Property(e => e.Wu2tearOsmolarityOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2TearOsmolarityOD");
            entity.Property(e => e.Wu2tearOsmolarityOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2TearOsmolarityOS");
            entity.Property(e => e.Wu2ttvod)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2TTVOD");
            entity.Property(e => e.Wu2ttvos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2TTVOS");
            entity.Property(e => e.Wu2ttvtype)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("WU2TTVType");
            entity.Property(e => e.Wu2vaorxOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2VAORxOD");
            entity.Property(e => e.Wu2vaorxOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2VAORxOS");
            entity.Property(e => e.Wu2vapamod)
                .IsUnicode(false)
                .HasColumnName("WU2VAPAMOD");
            entity.Property(e => e.Wu2vapamos)
                .IsUnicode(false)
                .HasColumnName("WU2VAPAMOS");
        });

        modelBuilder.Entity<Visit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__visit__3214EC277F31487A");

            entity.ToTable("visit");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ClientSoftwareApptId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ClientSoftwareApptID");
            entity.Property(e => e.ClrefNoteRemember)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("CLRefNoteRemember");
            entity.Property(e => e.Dosdate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DOSDate");
            entity.Property(e => e.ExcludeVisit)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.InitialSignedOff)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.InitialSignedOffDate)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.InitialSignedOffEmpId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("InitialSignedOffEmpID");
            entity.Property(e => e.InitialSignedOffRole)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LinkedProcedureVisitId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LinkedProcedureVisitID");
            entity.Property(e => e.MdsignedOff)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MDSignedOff");
            entity.Property(e => e.MdsignedOffDate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MDSignedOffDate");
            entity.Property(e => e.MdsignedOffEmpId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MDSignedOffEmpID");
            entity.Property(e => e.OldVisitId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("OldVisitID");
            entity.Property(e => e.ProvidedPtEducation)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.ReconciledCcda)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ReconciledCCDA");
            entity.Property(e => e.ServiceType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.VisitClassId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VisitClassID");
            entity.Property(e => e.VisitDoctor)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VisitEyeCareProviderId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VisitEyeCareProviderID");
            entity.Property(e => e.VisitPriCareProviderId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VisitPriCareProviderID");
            entity.Property(e => e.VisitRefProviderId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VisitRefProviderID");
            entity.Property(e => e.VisitTech)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VisitType).IsUnicode(false);
            entity.Property(e => e.VisitTypeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VisitTypeID");
        });

        modelBuilder.Entity<VisitDoctor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VisitDoc__3214EC27B63DBA08");

            entity.ToTable("VisitDoctor");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CodingAdditionalProcedures)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CodingC3emlevel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CodingC3EMLevel");
            entity.Property(e => e.CodingC3eyeCareLevel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CodingC3EyeCareLevel");
            entity.Property(e => e.CodingMdm)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CodingMDM");
            entity.Property(e => e.DfecdratioHorizOd)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DFECDRatioHorizOD");
            entity.Property(e => e.DfecdratioHorizOs)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DFECDRatioHorizOS");
            entity.Property(e => e.DfecdratioVertOd)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DFECDRatioVertOD");
            entity.Property(e => e.DfecdratioVertOs)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DFECDRatioVertOS");
            entity.Property(e => e.Dfecomments)
                .IsUnicode(false)
                .HasColumnName("DFEComments");
            entity.Property(e => e.DfediagOd)
                .IsUnicode(false)
                .HasColumnName("DFEDiagOD");
            entity.Property(e => e.DfediagOs)
                .IsUnicode(false)
                .HasColumnName("DFEDiagOS");
            entity.Property(e => e.DfedilatedPupilSizeOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DFEDilatedPupilSizeOD");
            entity.Property(e => e.DfedilatedPupilSizeOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DFEDilatedPupilSizeOS");
            entity.Property(e => e.DfeextOpth)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DFEExtOpth");
            entity.Property(e => e.DfelensUsed)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DFELensUsed");
            entity.Property(e => e.DiagOtherDiagnoses)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Dosdate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DOSDate");
            entity.Property(e => e.OldVisitId).HasColumnName("OldVisitID");
            entity.Property(e => e.PddistOu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PDDistOU");
            entity.Property(e => e.PdnearOu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PDNearOU");
            entity.Property(e => e.PlanDictateEyeCareDoc)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PlanDictatePatient)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PlanDictatePriCareDoc)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PlanDictateReferingDoc)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PlanLensRxNotes)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PlanNextScheduledAppt)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PlanRtoreason)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("PlanRTOReason");
            entity.Property(e => e.PlanRtowhen)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("PlanRTOWhen");
            entity.Property(e => e.PlanRxMedRemarks)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PlanRxOrdersRemarks)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PlanStaffOrderComments)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PlanTargetIopod)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PlanTargetIOPOD");
            entity.Property(e => e.PlanTargetIopos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PlanTargetIOPOS");
            entity.Property(e => e.ProvidedClinicalSummary)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ProvidedClinicalSummaryDays)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.ScribeEmpId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ScribeEmpID");
            entity.Property(e => e.Sleabutehl)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SLEABUTEHL");
            entity.Property(e => e.Slecomments)
                .IsUnicode(false)
                .HasColumnName("SLEComments");
            entity.Property(e => e.SlediagOd)
                .IsUnicode(false)
                .HasColumnName("SLEDiagOD");
            entity.Property(e => e.SlediagOs)
                .IsUnicode(false)
                .HasColumnName("SLEDiagOS");
        });

        modelBuilder.Entity<VisitOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Visit Or__3214EC27ABD55E9A");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.AddedbyFastPlanId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("AddedbyFastPlanID");
            entity.Property(e => e.CodeCpt)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CodeCPT");
            entity.Property(e => e.CodeLoinc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CodeLOINC");
            entity.Property(e => e.CodeSnomed)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CodeSNOMED");
            entity.Property(e => e.DicomrequestedProcedureId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DICOMRequestedProcedureID");
            entity.Property(e => e.DicomscheduledProcedureStepId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DICOMScheduledProcedureStepID");
            entity.Property(e => e.DoNotPrintRx)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Dosdate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DOSDate");
            entity.Property(e => e.OrderDescription)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OrderHasSpecimen)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.OrderLabResultFulfilledDate)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.OrderLabResultId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("OrderLabResultID");
            entity.Property(e => e.OrderModalityId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("OrderModalityID");
            entity.Property(e => e.OrderNeedsFollowup)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.OrderNotes)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OrderRemarks)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OrderScheduledDate)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.OrderSpecimenId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("OrderSpecimenID");
            entity.Property(e => e.OrderSpecimenType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.OrderTypeId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("OrderTypeID");
            entity.Property(e => e.OrderWasFollowedup)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.OrderWhen)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.RecordedEmpRole)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.RefProviderFirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RefProviderId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RefProviderID");
            entity.Property(e => e.RefProviderLastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RefProviderOrganizationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ScheduledAe)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ScheduledAE");
            entity.Property(e => e.StudyInstanceUid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("StudyInstanceUID");
            entity.Property(e => e.SummarySent)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.SummaryTransmitted)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
