using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsC;

public partial class EHRDbContext : DbContext
{
    private readonly string _connectionString;
    public EHRDbContext(string connectionString)
    {
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
        modelBuilder.Entity<AccountXref>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Account_Xref");

            entity.Property(e => e.NewAccount)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("New_Account");
            entity.Property(e => e.OldAccount)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Old_Account");
        });

        modelBuilder.Entity<Allergy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Allergie__3214EC27410B03FC");

            entity.Property(e => e.Id).HasColumnName("ID");
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
            entity.Property(e => e.PtId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PtID");
            entity.Property(e => e.Reaction)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Severity)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StartDate)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.VisitId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VisitID");
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Appointm__3214EC274CFB9F76");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ApptHl7status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ApptHL7Status");
            entity.Property(e => e.ApptId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ApptID");
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
            entity.Property(e => e.ApptPtId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ApptPtID");
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
        });

        modelBuilder.Entity<ContactLen>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contact___3214EC27B06C75DA");

            entity.ToTable("Contact_Lens");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Add_OD");
            entity.Property(e => e.AddOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Add_OS");
            entity.Property(e => e.Axis2Od)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Axis2_OD");
            entity.Property(e => e.Axis2Os)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Axis2_OS");
            entity.Property(e => e.AxisOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Axis_OD");
            entity.Property(e => e.AxisOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Axis_OS");
            entity.Property(e => e.Bc2Od)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("BC2_OD");
            entity.Property(e => e.Bc2Os)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("BC2_OS");
            entity.Property(e => e.BcOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("BC_OD");
            entity.Property(e => e.BcOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("BC_OS");
            entity.Property(e => e.BlendOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Blend_OD");
            entity.Property(e => e.BlendOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Blend_OS");
            entity.Property(e => e.CatalogBrandIdOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CatalogBrandID_OD");
            entity.Property(e => e.CatalogBrandIdOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CatalogBrandID_OS");
            entity.Property(e => e.CatalogManufacturerIdOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CatalogManufacturerID_OD");
            entity.Property(e => e.CatalogManufacturerIdOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CatalogManufacturerID_OS");
            entity.Property(e => e.CatalogProductIdOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CatalogProductID_OD");
            entity.Property(e => e.CatalogProductIdOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CatalogProductID_OS");
            entity.Property(e => e.CatalogSource)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CenterThicknessOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CenterThickness_OD");
            entity.Property(e => e.CenterThicknessOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CenterThickness_OS");
            entity.Property(e => e.CentrationOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Centration_OD");
            entity.Property(e => e.CentrationOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Centration_OS");
            entity.Property(e => e.ColorOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Color_OD");
            entity.Property(e => e.ColorOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Color_OS");
            entity.Property(e => e.ComfortOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Comfort_OD");
            entity.Property(e => e.ComfortOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Comfort_OS");
            entity.Property(e => e.ContactClass)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CoverageOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Coverage_OD");
            entity.Property(e => e.CoverageOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Coverage_OS");
            entity.Property(e => e.Cylinder2Od)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Cylinder2_OD");
            entity.Property(e => e.Cylinder2Os)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Cylinder2_OS");
            entity.Property(e => e.CylinderOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Cylinder_OD");
            entity.Property(e => e.CylinderOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Cylinder_OS");
            entity.Property(e => e.Diameter2Od)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Diameter2_OD");
            entity.Property(e => e.Diameter2Os)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Diameter2_OS");
            entity.Property(e => e.DiameterOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Diameter_OD");
            entity.Property(e => e.DiameterOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Diameter_OS");
            entity.Property(e => e.DistNearOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Dist_Near_OD");
            entity.Property(e => e.DistNearOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Dist_Near_OS");
            entity.Property(e => e.DkOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Dk_OD");
            entity.Property(e => e.DkOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Dk_OS");
            entity.Property(e => e.Dosdate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DOSDate");
            entity.Property(e => e.EdgeLiftOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Edge_Lift_OD");
            entity.Property(e => e.EdgeLiftOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Edge_Lift_OS");
            entity.Property(e => e.EdgeOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Edge_OD");
            entity.Property(e => e.EdgeOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Edge_OS");
            entity.Property(e => e.EquivalentCurveOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EquivalentCurve_OD");
            entity.Property(e => e.EquivalentCurveOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EquivalentCurve_OS");
            entity.Property(e => e.Expires)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.KOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("K_OD");
            entity.Property(e => e.KOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("K_OS");
            entity.Property(e => e.LensDesignOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LensDesign_OD");
            entity.Property(e => e.LensDesignOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LensDesign_OS");
            entity.Property(e => e.LensType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MaterialOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Material_OD");
            entity.Property(e => e.MaterialOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Material_OS");
            entity.Property(e => e.MovementOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Movement_OD");
            entity.Property(e => e.MovementOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Movement_OS");
            entity.Property(e => e.NaFlPatternOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("NaFlPattern_OD");
            entity.Property(e => e.NaFlPatternOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("NaFlPattern_OS");
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OpticalZoneDiaOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OpticalZoneDia_OD");
            entity.Property(e => e.OpticalZoneDiaOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OpticalZoneDia_OS");
            entity.Property(e => e.OrAxisOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OR_Axis_OD");
            entity.Property(e => e.OrAxisOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OR_Axis_OS");
            entity.Property(e => e.OrCylinderOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OR_Cylinder_OD");
            entity.Property(e => e.OrCylinderOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OR_Cylinder_OS");
            entity.Property(e => e.OrSphereOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OR_Sphere_OD");
            entity.Property(e => e.OrSphereOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OR_Sphere_OS");
            entity.Property(e => e.OrVaDOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OR_VaD_OD");
            entity.Property(e => e.OrVaDOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OR_VaD_OS");
            entity.Property(e => e.OrVaNOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OR_VaN_OD");
            entity.Property(e => e.OrVaNOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OR_VaN_OS");
            entity.Property(e => e.PeriphCurve2Od)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PeriphCurve2_OD");
            entity.Property(e => e.PeriphCurve2Os)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PeriphCurve2_OS");
            entity.Property(e => e.PeriphCurveOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PeriphCurve_OD");
            entity.Property(e => e.PeriphCurveOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PeriphCurve_OS");
            entity.Property(e => e.Power2Od)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Power2_OD");
            entity.Property(e => e.Power2Os)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Power2_OS");
            entity.Property(e => e.PowerOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Power_OD");
            entity.Property(e => e.PowerOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Power_OS");
            entity.Property(e => e.ProductOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Product_OD");
            entity.Property(e => e.ProductOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Product_OS");
            entity.Property(e => e.PtId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PtID");
            entity.Property(e => e.PtInsertedRemoved)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Pt_InsertedRemoved");
            entity.Property(e => e.PupilOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Pupil_OD");
            entity.Property(e => e.PupilOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Pupil_OS");
            entity.Property(e => e.Remarks)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ReplacementSchedule)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.RgpLayoutOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("RGP_Layout_OD");
            entity.Property(e => e.RgpLayoutOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("RGP_Layout_OS");
            entity.Property(e => e.RotationDegOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Rotation_Deg_OD");
            entity.Property(e => e.RotationDegOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Rotation_Deg_OS");
            entity.Property(e => e.RotationDirectionOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Rotation_Direction_OD");
            entity.Property(e => e.RotationDirectionOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Rotation_Direction_OS");
            entity.Property(e => e.RxId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RxID");
            entity.Property(e => e.SecondaryCurveOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SecondaryCurve_OD");
            entity.Property(e => e.SecondaryCurveOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SecondaryCurve_OS");
            entity.Property(e => e.SegHeightOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Seg_Height_OD");
            entity.Property(e => e.SegHeightOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Seg_Height_OS");
            entity.Property(e => e.Solution)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SpecialInstructionsOd)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("SpecialInstructions_OD");
            entity.Property(e => e.SpecialInstructionsOs)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("SpecialInstructions_OS");
            entity.Property(e => e.SurfaceWettingOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SurfaceWetting_OD");
            entity.Property(e => e.SurfaceWettingOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SurfaceWetting_OS");
            entity.Property(e => e.TrialNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpcOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UPC_OD");
            entity.Property(e => e.UpcOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UPC_OS");
            entity.Property(e => e.VaDOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VaD_OD");
            entity.Property(e => e.VaDOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VaD_OS");
            entity.Property(e => e.VaDOu)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VaD_OU");
            entity.Property(e => e.VaIOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VaI_OD");
            entity.Property(e => e.VaIOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VaI_OS");
            entity.Property(e => e.VaIOu)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VaI_OU");
            entity.Property(e => e.VaNOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VaN_OD");
            entity.Property(e => e.VaNOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VaN_OS");
            entity.Property(e => e.VaNOu)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VaN_OU");
            entity.Property(e => e.VisitId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VisitID");
            entity.Property(e => e.WAgeOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("W_Age_OD");
            entity.Property(e => e.WAgeOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("W_Age_OS");
            entity.Property(e => e.WAvgWearTimeOd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("W_Avg_WearTime_OD");
            entity.Property(e => e.WAvgWearTimeOs)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("W_Avg_WearTime_OS");
            entity.Property(e => e.WTimeTodayOd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("W_TimeToday_OD");
            entity.Property(e => e.WTimeTodayOs)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("W_TimeToday_OS");
            entity.Property(e => e.WearingInstructions)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DiagCodePool>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Diag_Code_Pool");

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
            entity.Property(e => e.DiagText)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DoNotReconcile)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Dosdate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DOSDate");
            entity.Property(e => e.IsActive)
                .HasMaxLength(50)
                .IsUnicode(false);
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
            entity.Property(e => e.PtId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PtID");
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
            entity.Property(e => e.VisitId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VisitID");
        });

        modelBuilder.Entity<DiagTest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Diag_Tes__3214EC27B6F87A67");

            entity.ToTable("Diag_Test");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Dosdate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DOSDate");
            entity.Property(e => e.GonioAngleDepthInOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GonioAngleDepth_In_OD");
            entity.Property(e => e.GonioAngleDepthInOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GonioAngleDepth_In_OS");
            entity.Property(e => e.GonioAngleDepthMedialOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GonioAngleDepth_Medial_OD");
            entity.Property(e => e.GonioAngleDepthMedialOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GonioAngleDepth_Medial_OS");
            entity.Property(e => e.GonioAngleDepthSuOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GonioAngleDepth_Su_OD");
            entity.Property(e => e.GonioAngleDepthSuOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GonioAngleDepth_Su_OS");
            entity.Property(e => e.GonioAngleDepthTemporalOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GonioAngleDepth_Temporal_OD");
            entity.Property(e => e.GonioAngleDepthTemporalOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GonioAngleDepth_Temporal_OS");
            entity.Property(e => e.GonioAngleStructureInOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GonioAngleStructure_In_OD");
            entity.Property(e => e.GonioAngleStructureInOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GonioAngleStructure_In_OS");
            entity.Property(e => e.GonioAngleStructureMedialOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GonioAngleStructure_Medial_OD");
            entity.Property(e => e.GonioAngleStructureMedialOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GonioAngleStructure_Medial_OS");
            entity.Property(e => e.GonioAngleStructureSuOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GonioAngleStructure_Su_OD");
            entity.Property(e => e.GonioAngleStructureSuOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GonioAngleStructure_Su_OS");
            entity.Property(e => e.GonioAngleStructureTemporalOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GonioAngleStructure_Temporal_OD");
            entity.Property(e => e.GonioAngleStructureTemporalOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GonioAngleStructure_Temporal_OS");
            entity.Property(e => e.GonioComments)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GonioPigmentOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GonioPigment_OD");
            entity.Property(e => e.GonioPigmentOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GonioPigment_OS");
            entity.Property(e => e.MbalanceCcOrtho)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalance_CC_Ortho");
            entity.Property(e => e.MbalanceCcType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalance_CC_Type");
            entity.Property(e => e.MbalanceHorizCcDownGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHoriz_CC_DownGaze");
            entity.Property(e => e.MbalanceHorizCcDownLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHoriz_CC_DownLtGaze");
            entity.Property(e => e.MbalanceHorizCcDownRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHoriz_CC_DownRtGaze");
            entity.Property(e => e.MbalanceHorizCcLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHoriz_CC_LtGaze");
            entity.Property(e => e.MbalanceHorizCcPriGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHoriz_CC_PriGaze");
            entity.Property(e => e.MbalanceHorizCcRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHoriz_CC_RtGaze");
            entity.Property(e => e.MbalanceHorizCcUpGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHoriz_CC_UpGaze");
            entity.Property(e => e.MbalanceHorizCcUpLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHoriz_CC_UpLtGaze");
            entity.Property(e => e.MbalanceHorizCcUpRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHoriz_CC_UpRtGaze");
            entity.Property(e => e.MbalanceHorizScDownGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHoriz_SC_DownGaze");
            entity.Property(e => e.MbalanceHorizScDownLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHoriz_SC_DownLtGaze");
            entity.Property(e => e.MbalanceHorizScDownRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHoriz_SC_DownRtGaze");
            entity.Property(e => e.MbalanceHorizScLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHoriz_SC_LtGaze");
            entity.Property(e => e.MbalanceHorizScPriGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHoriz_SC_PriGaze");
            entity.Property(e => e.MbalanceHorizScRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHoriz_SC_RtGaze");
            entity.Property(e => e.MbalanceHorizScUpGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHoriz_SC_UpGaze");
            entity.Property(e => e.MbalanceHorizScUpLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHoriz_SC_UpLtGaze");
            entity.Property(e => e.MbalanceHorizScUpRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHoriz_SC_UpRtGaze");
            entity.Property(e => e.MbalanceHorizTypeCcDownGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizType_CC_DownGaze");
            entity.Property(e => e.MbalanceHorizTypeCcDownLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizType_CC_DownLtGaze");
            entity.Property(e => e.MbalanceHorizTypeCcDownRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizType_CC_DownRtGaze");
            entity.Property(e => e.MbalanceHorizTypeCcLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizType_CC_LtGaze");
            entity.Property(e => e.MbalanceHorizTypeCcPriGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizType_CC_PriGaze");
            entity.Property(e => e.MbalanceHorizTypeCcRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizType_CC_RtGaze");
            entity.Property(e => e.MbalanceHorizTypeCcUpGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizType_CC_UpGaze");
            entity.Property(e => e.MbalanceHorizTypeCcUpLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizType_CC_UpLtGaze");
            entity.Property(e => e.MbalanceHorizTypeCcUpRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizType_CC_UpRtGaze");
            entity.Property(e => e.MbalanceHorizTypeScDownGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizType_SC_DownGaze");
            entity.Property(e => e.MbalanceHorizTypeScDownLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizType_SC_DownLtGaze");
            entity.Property(e => e.MbalanceHorizTypeScDownRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizType_SC_DownRtGaze");
            entity.Property(e => e.MbalanceHorizTypeScLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizType_SC_LtGaze");
            entity.Property(e => e.MbalanceHorizTypeScPriGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizType_SC_PriGaze");
            entity.Property(e => e.MbalanceHorizTypeScRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizType_SC_RtGaze");
            entity.Property(e => e.MbalanceHorizTypeScUpGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizType_SC_UpGaze");
            entity.Property(e => e.MbalanceHorizTypeScUpLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizType_SC_UpLtGaze");
            entity.Property(e => e.MbalanceHorizTypeScUpRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceHorizType_SC_UpRtGaze");
            entity.Property(e => e.MbalanceMethod)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceMethod");
            entity.Property(e => e.MbalanceMethodCc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceMethod_CC");
            entity.Property(e => e.MbalanceMethodSc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceMethod_SC");
            entity.Property(e => e.MbalanceScOrtho)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalance_SC_Ortho");
            entity.Property(e => e.MbalanceScType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalance_SC_Type");
            entity.Property(e => e.MbalanceVertCcDownGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVert_CC_DownGaze");
            entity.Property(e => e.MbalanceVertCcDownLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVert_CC_DownLtGaze");
            entity.Property(e => e.MbalanceVertCcDownRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVert_CC_DownRtGaze");
            entity.Property(e => e.MbalanceVertCcLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVert_CC_LtGaze");
            entity.Property(e => e.MbalanceVertCcPriGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVert_CC_PriGaze");
            entity.Property(e => e.MbalanceVertCcRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVert_CC_RtGaze");
            entity.Property(e => e.MbalanceVertCcUpGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVert_CC_UpGaze");
            entity.Property(e => e.MbalanceVertCcUpLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVert_CC_UpLtGaze");
            entity.Property(e => e.MbalanceVertCcUpRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVert_CC_UpRtGaze");
            entity.Property(e => e.MbalanceVertScDownGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVert_SC_DownGaze");
            entity.Property(e => e.MbalanceVertScDownLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVert_SC_DownLtGaze");
            entity.Property(e => e.MbalanceVertScDownRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVert_SC_DownRtGaze");
            entity.Property(e => e.MbalanceVertScLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVert_SC_LtGaze");
            entity.Property(e => e.MbalanceVertScPriGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVert_SC_PriGaze");
            entity.Property(e => e.MbalanceVertScRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVert_SC_RtGaze");
            entity.Property(e => e.MbalanceVertScUpGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVert_SC_UpGaze");
            entity.Property(e => e.MbalanceVertScUpLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVert_SC_UpLtGaze");
            entity.Property(e => e.MbalanceVertScUpRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVert_SC_UpRtGaze");
            entity.Property(e => e.MbalanceVertTypeCcDownGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertType_CC_DownGaze");
            entity.Property(e => e.MbalanceVertTypeCcDownLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertType_CC_DownLtGaze");
            entity.Property(e => e.MbalanceVertTypeCcDownRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertType_CC_DownRtGaze");
            entity.Property(e => e.MbalanceVertTypeCcLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertType_CC_LtGaze");
            entity.Property(e => e.MbalanceVertTypeCcPriGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertType_CC_PriGaze");
            entity.Property(e => e.MbalanceVertTypeCcRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertType_CC_RtGaze");
            entity.Property(e => e.MbalanceVertTypeCcUpGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertType_CC_UpGaze");
            entity.Property(e => e.MbalanceVertTypeCcUpLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertType_CC_UpLtGaze");
            entity.Property(e => e.MbalanceVertTypeCcUpRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertType_CC_UpRtGaze");
            entity.Property(e => e.MbalanceVertTypeScDownGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertType_SC_DownGaze");
            entity.Property(e => e.MbalanceVertTypeScDownLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertType_SC_DownLtGaze");
            entity.Property(e => e.MbalanceVertTypeScDownRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertType_SC_DownRtGaze");
            entity.Property(e => e.MbalanceVertTypeScLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertType_SC_LtGaze");
            entity.Property(e => e.MbalanceVertTypeScPriGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertType_SC_PriGaze");
            entity.Property(e => e.MbalanceVertTypeScRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertType_SC_RtGaze");
            entity.Property(e => e.MbalanceVertTypeScUpGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertType_SC_UpGaze");
            entity.Property(e => e.MbalanceVertTypeScUpLtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertType_SC_UpLtGaze");
            entity.Property(e => e.MbalanceVertTypeScUpRtGaze)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MBalanceVertType_SC_UpRtGaze");
            entity.Property(e => e.PtId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PtID");
            entity.Property(e => e.SmotorAbute)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotor_ABUTE");
            entity.Property(e => e.SmotorAvpattern)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorAVPattern");
            entity.Property(e => e.SmotorColorVisionOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorColorVision_OD");
            entity.Property(e => e.SmotorColorVisionOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorColorVision_OS");
            entity.Property(e => e.SmotorColorVisionType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorColorVision_Type");
            entity.Property(e => e.SmotorComments)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("SMotorComments");
            entity.Property(e => e.SmotorDirectionOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorDirection_OD");
            entity.Property(e => e.SmotorDirectionOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorDirection_OS");
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
                .HasColumnName("SMotorDMadRod_OD");
            entity.Property(e => e.SmotorDmadRodOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorDMadRod_OS");
            entity.Property(e => e.SmotorDmadRodTorsionOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorDMadRodTorsion_OD");
            entity.Property(e => e.SmotorDmadRodTorsionOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorDMadRodTorsion_OS");
            entity.Property(e => e.SmotorFixPrefDist)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorFixPref_Dist");
            entity.Property(e => e.SmotorFixPrefNear)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorFixPref_Near");
            entity.Property(e => e.SmotorFrisby)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorFrisby");
            entity.Property(e => e.SmotorHorizCcDist)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHoriz_CC_Dist");
            entity.Property(e => e.SmotorHorizCcNear)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHoriz_CC_Near");
            entity.Property(e => e.SmotorHorizCcNear3Plus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHoriz_CC_Near3Plus");
            entity.Property(e => e.SmotorHorizScDist)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHoriz_SC_Dist");
            entity.Property(e => e.SmotorHorizScNear)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHoriz_SC_Near");
            entity.Property(e => e.SmotorHorizTypeCcDist)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHorizType_CC_Dist");
            entity.Property(e => e.SmotorHorizTypeCcNear)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHorizType_CC_Near");
            entity.Property(e => e.SmotorHorizTypeCcNear3Plus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHorizType_CC_Near3Plus");
            entity.Property(e => e.SmotorHorizTypeScDist)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHorizType_SC_Dist");
            entity.Property(e => e.SmotorHorizTypeScNear)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHorizType_SC_Near");
            entity.Property(e => e.SmotorHorizVergBiBreak)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHorizVerg_BI_Break");
            entity.Property(e => e.SmotorHorizVergBiRecover)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHorizVerg_BI_Recover");
            entity.Property(e => e.SmotorHorizVergBoBreak)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHorizVerg_BO_Break");
            entity.Property(e => e.SmotorHorizVergBoRecover)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorHorizVerg_BO_Recover");
            entity.Property(e => e.SmotorHtLtHorizCc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotor_HT_LtHoriz_CC");
            entity.Property(e => e.SmotorHtLtHorizSc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotor_HT_LtHoriz_SC");
            entity.Property(e => e.SmotorHtLtHorizTypeCc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotor_HT_LtHorizType_CC");
            entity.Property(e => e.SmotorHtLtHorizTypeSc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotor_HT_LtHorizType_SC");
            entity.Property(e => e.SmotorHtLtVertCc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotor_HT_LtVert_CC");
            entity.Property(e => e.SmotorHtLtVertSc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotor_HT_LtVert_SC");
            entity.Property(e => e.SmotorHtLtVertTypeCc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotor_HT_LtVertType_CC");
            entity.Property(e => e.SmotorHtLtVertTypeSc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotor_HT_LtVertType_SC");
            entity.Property(e => e.SmotorHtRtHorizCc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotor_HT_RtHoriz_CC");
            entity.Property(e => e.SmotorHtRtHorizSc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotor_HT_RtHoriz_SC");
            entity.Property(e => e.SmotorHtRtHorizTypeCc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotor_HT_RtHorizType_CC");
            entity.Property(e => e.SmotorHtRtHorizTypeSc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotor_HT_RtHorizType_SC");
            entity.Property(e => e.SmotorHtRtVertCc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotor_HT_RtVert_CC");
            entity.Property(e => e.SmotorHtRtVertSc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotor_HT_RtVert_SC");
            entity.Property(e => e.SmotorHtRtVertTypeCc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotor_HT_RtVertType_CC");
            entity.Property(e => e.SmotorHtRtVertTypeSc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotor_HT_RtVertType_SC");
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
                .HasColumnName("SMotorPrism_OD");
            entity.Property(e => e.SmotorPrismOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorPrism_OS");
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
            entity.Property(e => e.SmotorVertCcDist)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorVert_CC_Dist");
            entity.Property(e => e.SmotorVertCcNear)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorVert_CC_Near");
            entity.Property(e => e.SmotorVertCcNear3Plus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorVert_CC_Near3Plus");
            entity.Property(e => e.SmotorVertScDist)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorVert_SC_Dist");
            entity.Property(e => e.SmotorVertScNear)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorVert_SC_Near");
            entity.Property(e => e.SmotorVertTypeCcDist)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorVertType_CC_Dist");
            entity.Property(e => e.SmotorVertTypeCcNear)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorVertType_CC_Near");
            entity.Property(e => e.SmotorVertTypeCcNear3Plus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorVertType_CC_Near3Plus");
            entity.Property(e => e.SmotorVertTypeScDist)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorVertType_SC_Dist");
            entity.Property(e => e.SmotorVertTypeScNear)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorVertType_SC_Near");
            entity.Property(e => e.SmotorVertVergBdBreak)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorVertVerg_BD_Break");
            entity.Property(e => e.SmotorVertVergBdRecover)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorVertVerg_BD_Recover");
            entity.Property(e => e.SmotorVertVergBuBreak)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorVertVerg_BU_Break");
            entity.Property(e => e.SmotorVertVergBuRecover)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorVertVerg_BU_Recover");
            entity.Property(e => e.SmotorWorth4DotDist)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorWorth4Dot_Dist");
            entity.Property(e => e.SmotorWorth4DotNear)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMotorWorth4Dot_Near");
            entity.Property(e => e.VisitId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VisitID");
        });

        modelBuilder.Entity<ExamCondition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Exam_Con__3214EC274E93C407");

            entity.ToTable("Exam_Conditions");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Comment)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Condition)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ConditionValue)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Condition Value");
            entity.Property(e => e.Dosdate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DOSDate");
            entity.Property(e => e.Eye)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PtId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PtID");
            entity.Property(e => e.VisitId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VisitID");
        });

        modelBuilder.Entity<FamilyHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FamilyHi__3214EC27E15BCAE7");

            entity.ToTable("FamilyHistory");

            entity.Property(e => e.Id).HasColumnName("ID");
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
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DOSDate");
            entity.Property(e => e.PtId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PtID");
            entity.Property(e => e.Relation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VisitId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VisitID");
        });

        modelBuilder.Entity<Iop>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__IOP__3214EC27483BDF07");

            entity.ToTable("IOP");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CornealHysteresisOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CornealHysteresis_OD");
            entity.Property(e => e.CornealHysteresisOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CornealHysteresis_OS");
            entity.Property(e => e.Dosdate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DOSDate");
            entity.Property(e => e.IopOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("IOP_OD");
            entity.Property(e => e.IopOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("IOP_OS");
            entity.Property(e => e.IopccOd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("IOPCC_OD");
            entity.Property(e => e.IopccOs)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("IOPCC_OS");
            entity.Property(e => e.IopdeviceUsed)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IOPDeviceUsed");
            entity.Property(e => e.Iopnotes)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IOPNotes");
            entity.Property(e => e.IoptimeTaken)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("IOPTimeTaken");
            entity.Property(e => e.PtId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PtID");
            entity.Property(e => e.VisitId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VisitID");
        });

        modelBuilder.Entity<MedicalHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Medical___3214EC27096A1F23");

            entity.ToTable("Medical_History");

            entity.Property(e => e.Id).HasColumnName("ID");
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
                .HasMaxLength(20)
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
            entity.Property(e => e.PtId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PtID");
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
            entity.Property(e => e.VisitId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VisitID");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Patients__3214EC276F1F2C80");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ClientSoftwarePtIdassignAuth)
                .HasMaxLength(50)
                .HasColumnName("ClientSoftwarePtIDAssignAuth");
            entity.Property(e => e.ClientSoftwarePtIdassignAuthIdtype)
                .HasMaxLength(50)
                .HasColumnName("ClientSoftwarePtIDAssignAuthIDType");
            entity.Property(e => e.ErxSystemAccessed).HasColumnName("ERxSystemAccessed");
            entity.Property(e => e.GenderIdentityConceptCode).HasMaxLength(50);
            entity.Property(e => e.GenderIdentityId).HasColumnName("GenderIdentityID");
            entity.Property(e => e.GenderIdentityOtherDescription).HasMaxLength(50);
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.PatientChartNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Patient_Chart_Number");
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
            entity.Property(e => e.PatientFirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Patient_First_Name");
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
            entity.Property(e => e.PatientLastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Patient_Last_Name");
            entity.Property(e => e.PatientMaritalStatus).HasMaxLength(60);
            entity.Property(e => e.PatientMiddleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Patient_Middle_Name");
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
            entity.Property(e => e.PmPatientId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PM_Patient_Id");
            entity.Property(e => e.PmimportCheckInNote).HasColumnName("PMImportCheckInNote");
            entity.Property(e => e.PtDeceasedDate).HasColumnType("datetime");
            entity.Property(e => e.SexualOrientationConceptCode).HasMaxLength(50);
            entity.Property(e => e.SexualOrientationId).HasColumnName("SexualOrientationID");
            entity.Property(e => e.SexualOrientationOtherDescription).HasMaxLength(50);
            entity.Property(e => e.UpsizeTs)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("upsize_ts");
        });

        modelBuilder.Entity<PatientDocument>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Patient___3214EC27AC890812");

            entity.ToTable("Patient_Documents");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AaohandoutsInfo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AAOHandoutsInfo");
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
                .HasMaxLength(20)
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
                .IsUnicode(false)
                .HasColumnName("Document Description");
            entity.Property(e => e.DocumentNotes)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Document Notes");
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
                .IsUnicode(false)
                .HasColumnName("File Path-Name");
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
            entity.Property(e => e.PatientId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Patient_Id");
            entity.Property(e => e.PatientInsuranceCompany)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Patient Insurance Company");
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
            entity.Property(e => e.VisitIdDocumentImageType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VisitID\r\n	[Document-Image Type");
        });

        modelBuilder.Entity<PatientNote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Patient___3214EC27D64D2C90");

            entity.ToTable("Patient_Notes");

            entity.Property(e => e.Id).HasColumnName("ID");
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
            entity.Property(e => e.PtId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PtID");
            entity.Property(e => e.VisitId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VisitID");
        });

        modelBuilder.Entity<PlanNarrative>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Plan_Nar__3214EC27060E1C01");

            entity.ToTable("Plan_Narrative");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DisplayOrder)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Dosdate)
                .HasMaxLength(20)
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
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NarrativeText)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.NarrativeType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PtId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PtID");
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
            entity.Property(e => e.VisitId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VisitID");
        });

        modelBuilder.Entity<ProcDiagPool>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proc_Dia__3214EC2719D9E02C");

            entity.ToTable("Proc_Diag_Pool");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Dosdate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DOSDate");
            entity.Property(e => e.PtId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PtID");
            entity.Property(e => e.RequestedProcedureId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RequestedProcedureID");
            entity.Property(e => e.VisitDiagCodePoolId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VisitDiagCodePoolID");
            entity.Property(e => e.VisitId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VisitID");
            entity.Property(e => e.VisitProcCodePoolId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VisitProcCodePoolID");
        });

        modelBuilder.Entity<ProcPool>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proc_Poo__3214EC276D63ECE1");

            entity.ToTable("Proc_Pool");

            entity.Property(e => e.Id).HasColumnName("ID");
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
            entity.Property(e => e.PtId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PtID");
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
            entity.Property(e => e.VisitId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VisitID");
        });

        modelBuilder.Entity<Refraction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Refracti__3214EC27A10AA323");

            entity.ToTable("Refraction");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Age)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.AxisOd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Axis_OD");
            entity.Property(e => e.AxisOs)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Axis_OS");
            entity.Property(e => e.BifocalAddOd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Bifocal_Add_OD");
            entity.Property(e => e.BifocalAddOs)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Bifocal_Add_OS");
            entity.Property(e => e.CylinderOd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Cylinder_OD");
            entity.Property(e => e.CylinderOs)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Cylinder_OS");
            entity.Property(e => e.DirectionOd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Direction_OD");
            entity.Property(e => e.DirectionOs)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Direction_OS");
            entity.Property(e => e.Dosdate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DOSDate");
            entity.Property(e => e.Expires)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PdDistOd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PD_Dist_OD");
            entity.Property(e => e.PdDistOs)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PD_Dist_OS");
            entity.Property(e => e.PdNearOd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PD_Near_OD");
            entity.Property(e => e.PdNearOs)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PD_Near_OS");
            entity.Property(e => e.Prism360Od)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Prism_360_OD");
            entity.Property(e => e.Prism360Os)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Prism_360_OS");
            entity.Property(e => e.PrismTypeOd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PrismType_OD");
            entity.Property(e => e.PrismTypeOs)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PrismType_OS");
            entity.Property(e => e.PtId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PtID");
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
                .HasColumnName("Sphere_OD");
            entity.Property(e => e.SphereOs)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Sphere_OS");
            entity.Property(e => e.VaDOd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("VaD_OD");
            entity.Property(e => e.VaDOs)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("VaD_OS");
            entity.Property(e => e.VaDOu)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("VaD_OU");
            entity.Property(e => e.VaIOd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("VaI_OD");
            entity.Property(e => e.VaIOs)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("VaI_OS");
            entity.Property(e => e.VaIOu)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("VaI_OU");
            entity.Property(e => e.VaNOd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("VaN_OD");
            entity.Property(e => e.VaNOs)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("VaN_OS");
            entity.Property(e => e.VaNOu)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("VaN_OU");
            entity.Property(e => e.VisitId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VisitID");
        });

        modelBuilder.Entity<Ro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ROS__3214EC27733946DA");

            entity.ToTable("ROS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Dosdate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DOSDate");
            entity.Property(e => e.PtId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PtID");
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
            entity.Property(e => e.VisitId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VisitID");
        });

        modelBuilder.Entity<RxMedication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rx Medic__3214EC273DA866C0");

            entity.ToTable("Rx Medication");

            entity.Property(e => e.Id).HasColumnName("ID");
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
            entity.Property(e => e.PtId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PtID");
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
            entity.Property(e => e.VisitId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VisitID");
        });

        modelBuilder.Entity<SurgHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Surg_His__3214EC272E7ED9EE");

            entity.ToTable("Surg_History");

            entity.Property(e => e.Id).HasColumnName("ID");
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
                .HasMaxLength(20)
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
            entity.Property(e => e.PtId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PtID");
            entity.Property(e => e.TypeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("TypeID");
            entity.Property(e => e.VisitId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VisitID");
        });

        modelBuilder.Entity<Tech>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tech__3214EC27C0361FDC");

            entity.ToTable("tech");

            entity.Property(e => e.Id).HasColumnName("ID");
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
                .HasMaxLength(500)
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
            entity.Property(e => e.PtId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PtID");
            entity.Property(e => e.VisitId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VisitID");
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
                .HasColumnName("WUAmsler_OD");
            entity.Property(e => e.WuamslerOs)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("WUAmsler_OS");
            entity.Property(e => e.WucvfAbute)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUCVF_ABUTE");
            entity.Property(e => e.WucvfdiagOd)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("WUCVFDiag_OD");
            entity.Property(e => e.WucvfdiagOs)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("WUCVFDiag_OS");
            entity.Property(e => e.Wudilated)
                .HasMaxLength(10)
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
            entity.Property(e => e.WueomInNaOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUEOM_In_Na_OD");
            entity.Property(e => e.WueomInNaOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUEOM_In_Na_OS");
            entity.Property(e => e.WueomInTmOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUEOM_In_Tm_OD");
            entity.Property(e => e.WueomInTmOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUEOM_In_Tm_OS");
            entity.Property(e => e.WueomMedialOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUEOM_Medial_OD");
            entity.Property(e => e.WueomMedialOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUEOM_Medial_OS");
            entity.Property(e => e.WueomSuNaOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUEOM_Su_Na_OD");
            entity.Property(e => e.WueomSuNaOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUEOM_Su_Na_OS");
            entity.Property(e => e.WueomSuTmOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUEOM_Su_Tm_OD");
            entity.Property(e => e.WueomSuTmOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUEOM_Su_Tm_OS");
            entity.Property(e => e.WueomTemporalOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUEOM_Temporal_OD");
            entity.Property(e => e.WueomTemporalOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUEOM_Temporal_OS");
            entity.Property(e => e.WueomType)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("WUEOM_Type");
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
            entity.Property(e => e.WuiopAbute)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUIOP_ABUTE");
            entity.Property(e => e.Wumood)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("WUMood");
            entity.Property(e => e.WunCcOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUN_CC_OD");
            entity.Property(e => e.WunCcOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUN_CC_OS");
            entity.Property(e => e.WunCcOu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUN_CC_OU");
            entity.Property(e => e.WunScOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUN_SC_OD");
            entity.Property(e => e.WunScOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUN_SC_OS");
            entity.Property(e => e.WunScOu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUN_SC_OU");
            entity.Property(e => e.Wunotes)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("WUNotes");
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
            entity.Property(e => e.WupupilApdOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUPupilAPD_OD");
            entity.Property(e => e.WupupilApdOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUPupilAPD_OS");
            entity.Property(e => e.WupupilDarkSizeOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUPupilDarkSize_OD");
            entity.Property(e => e.WupupilDarkSizeOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUPupilDarkSize_OS");
            entity.Property(e => e.WupupilLightSizeOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUPupilLightSize_OD");
            entity.Property(e => e.WupupilLightSizeOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUPupilLightSize_OS");
            entity.Property(e => e.WupupilNearOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUPupilNear_OD");
            entity.Property(e => e.WupupilNearOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUPupilNear_OS");
            entity.Property(e => e.WupupilReactionOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUPupilReaction_OD");
            entity.Property(e => e.WupupilReactionOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUPupilReaction_OS");
            entity.Property(e => e.WupupilShapeOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUPupilShape_OD");
            entity.Property(e => e.WupupilShapeOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUPupilShape_OS");
            entity.Property(e => e.WutcvfOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUTCVF_OD");
            entity.Property(e => e.WutcvfOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUTCVF_OS");
            entity.Property(e => e.WuvaCcOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUVA_CC_OD");
            entity.Property(e => e.WuvaCcOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUVA_CC_OS");
            entity.Property(e => e.WuvaCcOu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUVA_CC_OU");
            entity.Property(e => e.WuvaCcType)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("WUVA_CC_Type");
            entity.Property(e => e.WuvaPhOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUVA_PH_OD");
            entity.Property(e => e.WuvaPhOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUVA_PH_OS");
            entity.Property(e => e.WuvaScOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUVA_SC_OD");
            entity.Property(e => e.WuvaScOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUVA_SC_OS");
            entity.Property(e => e.WuvaScOu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUVA_SC_OU");
            entity.Property(e => e.WuvaTestUsed)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WUVA_TestUsed");
        });

        modelBuilder.Entity<Tech2>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tech2__3214EC271E595BA1");

            entity.ToTable("tech2");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Dosdate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DOSDate");
            entity.Property(e => e.PtId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PtID");
            entity.Property(e => e.VisitId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VisitID");
            entity.Property(e => e.Wu2GlareHighOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2_Glare_High_OD");
            entity.Property(e => e.Wu2GlareHighOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2_Glare_High_OS");
            entity.Property(e => e.Wu2GlareLowOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2_Glare_Low_OD");
            entity.Property(e => e.Wu2GlareLowOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2_Glare_Low_OS");
            entity.Property(e => e.Wu2GlareMedOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2_Glare_Med_OD");
            entity.Property(e => e.Wu2GlareMedOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2_Glare_Med_OS");
            entity.Property(e => e.Wu2GlareType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2_Glare_Type");
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
            entity.Property(e => e.Wu2hertelBase)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("WU2Hertel_Base");
            entity.Property(e => e.Wu2hertelOd)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("WU2Hertel_OD");
            entity.Property(e => e.Wu2hertelOs)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("WU2Hertel_OS");
            entity.Property(e => e.Wu2kmaxDegOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2KMaxDeg_OD");
            entity.Property(e => e.Wu2kmaxDegOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2KMaxDeg_OS");
            entity.Property(e => e.Wu2kmaxOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2KMax_OD");
            entity.Property(e => e.Wu2kmaxOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2KMax_OS");
            entity.Property(e => e.Wu2kminDegOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2KMinDeg_OD");
            entity.Property(e => e.Wu2kminDegOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2KMinDeg_OS");
            entity.Property(e => e.Wu2kminOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2KMin_OD");
            entity.Property(e => e.Wu2kminOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2KMin_OS");
            entity.Property(e => e.Wu2ktype)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("WU2KType");
            entity.Property(e => e.Wu2pachCctOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2PachCCT_OD");
            entity.Property(e => e.Wu2pachCctOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2PachCCT_OS");
            entity.Property(e => e.Wu2tearOsmolarityCollectionDifficult)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("WU2TearOsmolarityCollectionDifficult");
            entity.Property(e => e.Wu2tearOsmolarityOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2TearOsmolarity_OD");
            entity.Property(e => e.Wu2tearOsmolarityOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2TearOsmolarity_OS");
            entity.Property(e => e.Wu2ttvOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2TTV_OD");
            entity.Property(e => e.Wu2ttvOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2TTV_OS");
            entity.Property(e => e.Wu2ttvtype)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("WU2TTVType");
            entity.Property(e => e.Wu2vaOrxOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2VA_ORx_OD");
            entity.Property(e => e.Wu2vaOrxOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2VA_ORx_OS");
            entity.Property(e => e.Wu2vaPamOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2VA_PAM_OD");
            entity.Property(e => e.Wu2vaPamOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WU2VA_PAM_OS");
        });

        modelBuilder.Entity<Visit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__visit__3214EC27384F805C");

            entity.ToTable("visit");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ClientSoftwareApptId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ClientSoftwareApptID");
            entity.Property(e => e.ClrefNoteRemember)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("CLRefNoteRemember");
            entity.Property(e => e.Dosdate)
                .HasMaxLength(20)
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
            entity.Property(e => e.ProvidedPtEducation)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PtId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PtID");
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
            entity.Property(e => e.VisitType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VisitTypeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VisitTypeID");
        });

        modelBuilder.Entity<VisitDoctor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Visit_Do__3214EC27143AB283");

            entity.ToTable("Visit_Doctor");

            entity.Property(e => e.Id).HasColumnName("ID");
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
            entity.Property(e => e.DfeCdratioHorizOd)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DFE_CDRatio_Horiz_OD");
            entity.Property(e => e.DfeCdratioHorizOs)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DFE_CDRatio_Horiz_OS");
            entity.Property(e => e.DfeCdratioVertOd)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DFE_CDRatio_Vert_OD");
            entity.Property(e => e.DfeCdratioVertOs)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DFE_CDRatio_Vert_OS");
            entity.Property(e => e.DfeDiagOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DFE_Diag_OD");
            entity.Property(e => e.DfeDiagOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DFE_Diag_OS");
            entity.Property(e => e.Dfecomments)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("DFEComments");
            entity.Property(e => e.DfedilatedPupilSizeOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DFEDilatedPupilSize_OD");
            entity.Property(e => e.DfedilatedPupilSizeOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DFEDilatedPupilSize_OS");
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
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DOSDate");
            entity.Property(e => e.PdDistOu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PD_Dist_OU");
            entity.Property(e => e.PdNearOu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PD_Near_OU");
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
            entity.Property(e => e.PlanTargetIopOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PlanTargetIOP_OD");
            entity.Property(e => e.PlanTargetIopOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PlanTargetIOP_OS");
            entity.Property(e => e.ProvidedClinicalSummary)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ProvidedClinicalSummaryDays)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PtId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PtID");
            entity.Property(e => e.ScribeEmpId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ScribeEmpID");
            entity.Property(e => e.SleAbutehl)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SLE_ABUTEHL");
            entity.Property(e => e.SleDiagOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SLE_Diag_OD");
            entity.Property(e => e.SleDiagOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SLE_Diag_OS");
            entity.Property(e => e.Slecomments)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("SLEComments");
            entity.Property(e => e.VisitId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VisitID");
        });

        modelBuilder.Entity<VisitOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Visit Or__3214EC2794C9A990");

            entity.ToTable("Visit Orders");

            entity.Property(e => e.Id).HasColumnName("ID");
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
                .HasMaxLength(20)
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
            entity.Property(e => e.PtId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PtID");
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
            entity.Property(e => e.VisitId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VisitID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
