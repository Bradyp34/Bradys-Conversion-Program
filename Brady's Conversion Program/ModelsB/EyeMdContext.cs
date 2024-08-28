using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EyeMdContext : DbContext
{
    private readonly string _connectionString;
    public EyeMdContext(string connectionString) {
        _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public EyeMdContext(DbContextOptions<EyeMdContext> options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        : base(options)
    {
    }

    public virtual DbSet<AbbcatalogManufacturer> AbbcatalogManufacturers { get; set; }

    public virtual DbSet<AbbcatalogProduct> AbbcatalogProducts { get; set; }

    public virtual DbSet<AbbcatalogProductFamily> AbbcatalogProductFamilies { get; set; }

    public virtual DbSet<AbbcatalogSeries> AbbcatalogSeries { get; set; }

    public virtual DbSet<EmrallergyList> EmrallergyLists { get; set; }

    public virtual DbSet<EmrallergyListRxNorm> EmrallergyListRxNorms { get; set; }

    public virtual DbSet<Emrappt> Emrappts { get; set; }

    public virtual DbSet<Emrcdsalert> Emrcdsalerts { get; set; }

    public virtual DbSet<EmrchartFilter> EmrchartFilters { get; set; }

    public virtual DbSet<EmrcodeSystem> EmrcodeSystems { get; set; }

    public virtual DbSet<Emrcoding> Emrcodings { get; set; }

    public virtual DbSet<EmrcodingIcd10> EmrcodingIcd10s { get; set; }

    public virtual DbSet<EmrcolumnControlList> EmrcolumnControlLists { get; set; }

    public virtual DbSet<EmrcomboControlList> EmrcomboControlLists { get; set; }

    public virtual DbSet<EmrcontrolId> EmrcontrolIds { get; set; }

    public virtual DbSet<Emrdevice> Emrdevices { get; set; }

    public virtual DbSet<EmrdicomModalityCode> EmrdicomModalityCodes { get; set; }

    public virtual DbSet<Emrdicomdevice> Emrdicomdevices { get; set; }

    public virtual DbSet<EmrdrugList> EmrdrugLists { get; set; }

    public virtual DbSet<EmrdrugListRxNorm> EmrdrugListRxNorms { get; set; }

    public virtual DbSet<Emredge> Emredges { get; set; }

    public virtual DbSet<EmredgeSite> EmredgeSites { get; set; }

    public virtual DbSet<EmreditTracker> EmreditTrackers { get; set; }

    public virtual DbSet<Emremp> Emremps { get; set; }

    public virtual DbSet<EmrempMultiFactorToken> EmrempMultiFactorTokens { get; set; }

    public virtual DbSet<EmrempRole> EmrempRoles { get; set; }

    public virtual DbSet<EmrexportDevice> EmrexportDevices { get; set; }

    public virtual DbSet<EmrfastPlan> EmrfastPlans { get; set; }

    public virtual DbSet<EmrfastPlanDiag> EmrfastPlanDiags { get; set; }

    public virtual DbSet<EmrfastPlanMed> EmrfastPlanMeds { get; set; }

    public virtual DbSet<EmrfastPlanNarrativeFragment> EmrfastPlanNarrativeFragments { get; set; }

    public virtual DbSet<EmrfastPlanOrder> EmrfastPlanOrders { get; set; }

    public virtual DbSet<Emrfaxis> Emrfaxes { get; set; }

    public virtual DbSet<Emrfield> Emrfields { get; set; }

    public virtual DbSet<Emrgemsi10i9> Emrgemsi10i9s { get; set; }

    public virtual DbSet<Emrgemsi9i10> Emrgemsi9i10s { get; set; }

    public virtual DbSet<Emricd10> Emricd10s { get; set; }

    public virtual DbSet<Emricd9> Emricd9s { get; set; }

    public virtual DbSet<Emricd9toSnomed> Emricd9toSnomeds { get; set; }

    public virtual DbSet<EmrimagesImbedded> EmrimagesImbeddeds { get; set; }

    public virtual DbSet<EmrimagesLinked> EmrimagesLinkeds { get; set; }

    public virtual DbSet<EmrimagesLinkedDataTag> EmrimagesLinkedDataTags { get; set; }

    public virtual DbSet<EmrimagesLinkedDatum> EmrimagesLinkedData { get; set; }

    public virtual DbSet<EmrimagingModality> EmrimagingModalities { get; set; }

    public virtual DbSet<EmrimagingRequestedProcedure> EmrimagingRequestedProcedures { get; set; }

    public virtual DbSet<Emriom> Emrioms { get; set; }

    public virtual DbSet<Emrlab> Emrlabs { get; set; }

    public virtual DbSet<EmrlabResult> EmrlabResults { get; set; }

    public virtual DbSet<Emrlanguage> Emrlanguages { get; set; }

    public virtual DbSet<EmrletterTemplate> EmrletterTemplates { get; set; }

    public virtual DbSet<Emrlock> Emrlocks { get; set; }

    public virtual DbSet<EmrmobileCorrelation> EmrmobileCorrelations { get; set; }

    public virtual DbSet<Emroption> Emroptions { get; set; }

    public virtual DbSet<Emrpatient> Emrpatients { get; set; }

    public virtual DbSet<EmrpatientDevice> EmrpatientDevices { get; set; }

    public virtual DbSet<EmrpatientFlow> EmrpatientFlows { get; set; }

    public virtual DbSet<EmrpatientFlowHistory> EmrpatientFlowHistories { get; set; }

    public virtual DbSet<EmrpatientFlowStatusType> EmrpatientFlowStatusTypes { get; set; }

    public virtual DbSet<EmrpatientNameAlternate> EmrpatientNameAlternates { get; set; }

    public virtual DbSet<EmrpatientObservation> EmrpatientObservations { get; set; }

    public virtual DbSet<EmrpatientObservationValue> EmrpatientObservationValues { get; set; }

    public virtual DbSet<EmrpatientObservationValueStatus> EmrpatientObservationValueStatuses { get; set; }

    public virtual DbSet<EmrpatientScratchpad> EmrpatientScratchpads { get; set; }

    public virtual DbSet<EmrpatientSearch> EmrpatientSearches { get; set; }

    public virtual DbSet<EmrpatientSearchSchedule> EmrpatientSearchSchedules { get; set; }

    public virtual DbSet<EmrptNote> EmrptNotes { get; set; }

    public virtual DbSet<Emrrecall> Emrrecalls { get; set; }

    public virtual DbSet<EmrrefProvider> EmrrefProviders { get; set; }

    public virtual DbSet<Emrroom> Emrrooms { get; set; }

    public virtual DbSet<EmrroomType> EmrroomTypes { get; set; }

    public virtual DbSet<Emrrosdefault> Emrrosdefaults { get; set; }

    public virtual DbSet<EmrrxUsageDefault> EmrrxUsageDefaults { get; set; }

    public virtual DbSet<EmrscannerOption> EmrscannerOptions { get; set; }

    public virtual DbSet<Emrschedule> Emrschedules { get; set; }

    public virtual DbSet<EmrscheduledTask> EmrscheduledTasks { get; set; }

    public virtual DbSet<EmrsecurityGroup> EmrsecurityGroups { get; set; }

    public virtual DbSet<Emrsite> Emrsites { get; set; }

    public virtual DbSet<EmrsmartApp> EmrsmartApps { get; set; }

    public virtual DbSet<Emrsnomedconcept> Emrsnomedconcepts { get; set; }

    public virtual DbSet<Emrsnomeddescription> Emrsnomeddescriptions { get; set; }

    public virtual DbSet<Emrsnomedrelationship> Emrsnomedrelationships { get; set; }

    public virtual DbSet<EmrsnomedtoIcd10> EmrsnomedtoIcd10s { get; set; }

    public virtual DbSet<EmrsnomedtoIcd9> EmrsnomedtoIcd9s { get; set; }

    public virtual DbSet<EmrsnomedtoIcd9target> EmrsnomedtoIcd9targets { get; set; }

    public virtual DbSet<EmrtempLog> EmrtempLogs { get; set; }

    public virtual DbSet<EmrtreeViewControlList> EmrtreeViewControlLists { get; set; }

    public virtual DbSet<Emrvisit> Emrvisits { get; set; }

    public virtual DbSet<EmrvisitAllergy> EmrvisitAllergies { get; set; }

    public virtual DbSet<EmrvisitContactLense> EmrvisitContactLenses { get; set; }

    public virtual DbSet<EmrvisitDiagCodePool> EmrvisitDiagCodePools { get; set; }

    public virtual DbSet<EmrvisitDiagCodePoolStatus> EmrvisitDiagCodePoolStatuses { get; set; }

    public virtual DbSet<EmrvisitDiagTest> EmrvisitDiagTests { get; set; }

    public virtual DbSet<EmrvisitDoctor> EmrvisitDoctors { get; set; }

    public virtual DbSet<EmrvisitExamCondition> EmrvisitExamConditions { get; set; }

    public virtual DbSet<EmrvisitFamilyHistory> EmrvisitFamilyHistories { get; set; }

    public virtual DbSet<EmrvisitImmunization> EmrvisitImmunizations { get; set; }

    public virtual DbSet<EmrvisitIop> EmrvisitIops { get; set; }

    public virtual DbSet<EmrvisitMedicalHistory> EmrvisitMedicalHistories { get; set; }

    public virtual DbSet<EmrvisitOrder> EmrvisitOrders { get; set; }

    public virtual DbSet<EmrvisitOrdersDiag> EmrvisitOrdersDiags { get; set; }

    public virtual DbSet<EmrvisitPlanNarrative> EmrvisitPlanNarratives { get; set; }

    public virtual DbSet<EmrvisitPlanNarrativeFragment> EmrvisitPlanNarrativeFragments { get; set; }

    public virtual DbSet<EmrvisitProc> EmrvisitProcs { get; set; }

    public virtual DbSet<EmrvisitProcCodePool> EmrvisitProcCodePools { get; set; }

    public virtual DbSet<EmrvisitProcCodePoolDiag> EmrvisitProcCodePoolDiags { get; set; }

    public virtual DbSet<EmrvisitRefraction> EmrvisitRefractions { get; set; }

    public virtual DbSet<EmrvisitRxMedication> EmrvisitRxMedications { get; set; }

    public virtual DbSet<EmrvisitSurgicalHistory> EmrvisitSurgicalHistories { get; set; }

    public virtual DbSet<EmrvisitTech> EmrvisitTeches { get; set; }

    public virtual DbSet<EmrvisitTech2> EmrvisitTech2s { get; set; }

    public virtual DbSet<EmrvisitTechRo> EmrvisitTechRos { get; set; }

    public virtual DbSet<EmrvisitType> EmrvisitTypes { get; set; }

    public virtual DbSet<IntakeConsentForm> IntakeConsentForms { get; set; }

    public virtual DbSet<SchemaVersion> SchemaVersions { get; set; }

    public virtual DbSet<TrigOrder> TrigOrders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AbbcatalogManufacturer>(entity =>
        {
            entity.ToTable("ABBCatalogManufacturer");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ManId)
                .HasMaxLength(50)
                .HasColumnName("MAN_ID");
            entity.Property(e => e.ManName)
                .HasMaxLength(50)
                .HasColumnName("MAN_NAME");
        });

        modelBuilder.Entity<AbbcatalogProduct>(entity =>
        {
            entity.ToTable("ABBCatalogProduct");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PrdAddition)
                .HasMaxLength(50)
                .HasColumnName("PRD_ADDITION");
            entity.Property(e => e.PrdAxis)
                .HasMaxLength(50)
                .HasColumnName("PRD_AXIS");
            entity.Property(e => e.PrdCheckdigit)
                .HasMaxLength(1)
                .HasColumnName("PRD_CHECKDIGIT");
            entity.Property(e => e.PrdColor)
                .HasMaxLength(50)
                .HasColumnName("PRD_COLOR");
            entity.Property(e => e.PrdColorId)
                .HasMaxLength(50)
                .HasColumnName("PRD_COLOR_ID");
            entity.Property(e => e.PrdConvert)
                .HasMaxLength(50)
                .HasColumnName("PRD_CONVERT");
            entity.Property(e => e.PrdCylinder)
                .HasMaxLength(50)
                .HasColumnName("PRD_CYLINDER");
            entity.Property(e => e.PrdDescription)
                .HasMaxLength(100)
                .HasColumnName("PRD_DESCRIPTION");
            entity.Property(e => e.PrdId)
                .HasMaxLength(50)
                .HasColumnName("PRD_ID");
            entity.Property(e => e.PrdPower)
                .HasMaxLength(50)
                .HasColumnName("PRD_POWER");
            entity.Property(e => e.PrdUpcCode)
                .HasMaxLength(50)
                .HasColumnName("PRD_UPC_CODE");
            entity.Property(e => e.PrfId)
                .HasMaxLength(50)
                .HasColumnName("PRF_ID");
        });

        modelBuilder.Entity<AbbcatalogProductFamily>(entity =>
        {
            entity.ToTable("ABBCatalogProductFamily");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PrfBasecurve)
                .HasMaxLength(50)
                .HasColumnName("PRF_BASECURVE");
            entity.Property(e => e.PrfConvert)
                .HasMaxLength(50)
                .HasColumnName("PRF_CONVERT");
            entity.Property(e => e.PrfDiameter)
                .HasMaxLength(50)
                .HasColumnName("PRF_DIAMETER");
            entity.Property(e => e.PrfId)
                .HasMaxLength(50)
                .HasColumnName("PRF_ID");
            entity.Property(e => e.PrfRevDiagInd)
                .HasMaxLength(1)
                .HasColumnName("PRF_REV_DIAG_IND");
            entity.Property(e => e.UnitsAvailability)
                .HasMaxLength(50)
                .HasColumnName("UNITS_AVAILABILITY");
        });

        modelBuilder.Entity<AbbcatalogSeries>(entity =>
        {
            entity.ToTable("ABBCatalogSeries");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ManId)
                .HasMaxLength(50)
                .HasColumnName("MAN_ID");
            entity.Property(e => e.SerDayPerLens)
                .HasMaxLength(50)
                .HasColumnName("SER_DAY_PER_LENS");
            entity.Property(e => e.SerId)
                .HasMaxLength(50)
                .HasColumnName("SER_ID");
            entity.Property(e => e.SerName)
                .HasMaxLength(200)
                .HasColumnName("SER_NAME");
            entity.Property(e => e.StyId)
                .HasMaxLength(10)
                .HasColumnName("STY_ID");
        });

        modelBuilder.Entity<EmrallergyList>(entity =>
        {
            entity.HasKey(e => e.TableId).HasName("PK__EMRAllergyList__139DBB87");

            entity.ToTable("EMRAllergyList");

            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.AllergyName).HasMaxLength(255);
            entity.Property(e => e.ConceptId)
                .HasMaxLength(100)
                .HasColumnName("ConceptID");
            entity.Property(e => e.ConceptType).HasMaxLength(10);
            entity.Property(e => e.MappingId)
                .HasMaxLength(100)
                .HasColumnName("MappingID");
            entity.Property(e => e.Rxcui)
                .HasMaxLength(50)
                .HasColumnName("RXCUI");
            entity.Property(e => e.Snomed)
                .HasMaxLength(50)
                .HasColumnName("SNOMED");
        });

        modelBuilder.Entity<EmrallergyListRxNorm>(entity =>
        {
            entity.HasKey(e => e.TableId);

            entity.ToTable("EMRAllergyListRxNorm");

            entity.HasIndex(e => e.MappingId, "MappingID").HasFillFactor(90);

            entity.HasIndex(e => e.RxCui, "RxCUI").HasFillFactor(90);

            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.ActiveStatus).HasMaxLength(5);
            entity.Property(e => e.ConceptId)
                .HasMaxLength(10)
                .HasColumnName("ConceptID");
            entity.Property(e => e.MappingId)
                .HasMaxLength(10)
                .HasColumnName("MappingID");
            entity.Property(e => e.RxCui)
                .HasMaxLength(10)
                .HasColumnName("RxCUI");
        });

        modelBuilder.Entity<Emrappt>(entity =>
        {
            entity.HasKey(e => e.ApptId).HasName("PK__EMRAppt__38D961D7");

            entity.ToTable("EMRAppt");

            entity.HasIndex(e => new { e.ApptLocationId, e.ApptStatus, e.ApptPtId, e.ApptStartTime }, "IX_EMRAppt_ApptLocationID").HasFillFactor(90);

            entity.HasIndex(e => e.ClientSoftwareApptId, "IX_EMRAppt_ClientSoftwareApptID").HasFillFactor(90);

            entity.Property(e => e.ApptId).HasColumnName("ApptID");
            entity.Property(e => e.ApptHl7status)
                .HasMaxLength(50)
                .HasColumnName("ApptHL7Status");
            entity.Property(e => e.ApptLocationId).HasColumnName("ApptLocationID");
            entity.Property(e => e.ApptProviderEmpId).HasColumnName("ApptProviderEmpID");
            entity.Property(e => e.ApptPtId).HasColumnName("ApptPtID");
            entity.Property(e => e.ApptReason).HasMaxLength(500);
            entity.Property(e => e.ApptStartTime).HasColumnType("datetime");
            entity.Property(e => e.ApptType).HasMaxLength(50);
            entity.Property(e => e.ClientSoftwareApptId)
                .HasMaxLength(50)
                .HasColumnName("ClientSoftwareApptID");
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.IntakeSubmissionGuid).HasMaxLength(50);
        });

        modelBuilder.Entity<Emrcdsalert>(entity =>
        {
            entity.HasKey(e => e.TableId);

            entity.ToTable("EMRCDSAlerts");

            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.Allergy).HasMaxLength(255);
            entity.Property(e => e.InterventionDescription).HasMaxLength(255);
            entity.Property(e => e.InterventionFundingSource).HasMaxLength(255);
            entity.Property(e => e.LabTestName).HasMaxLength(255);
            entity.Property(e => e.LabTestOperator).HasMaxLength(10);
            entity.Property(e => e.LabTestValue).HasMaxLength(50);
            entity.Property(e => e.MedicationName).HasMaxLength(255);
            entity.Property(e => e.ProblemDescription).HasMaxLength(255);
            entity.Property(e => e.ProblemIcd10)
                .HasMaxLength(10)
                .HasColumnName("ProblemICD10");
            entity.Property(e => e.ProblemIcd9)
                .HasMaxLength(10)
                .HasColumnName("ProblemICD9");
            entity.Property(e => e.PtBpsysMax).HasColumnName("PtBPSysMax");
            entity.Property(e => e.PtBpsysMin).HasColumnName("PtBPSysMin");
            entity.Property(e => e.PtGender).HasMaxLength(10);
            entity.Property(e => e.PtIopmax).HasColumnName("PtIOPMax");
            entity.Property(e => e.PtIopmin).HasColumnName("PtIOPMin");
            entity.Property(e => e.PtRace).HasMaxLength(255);
        });

        modelBuilder.Entity<EmrchartFilter>(entity =>
        {
            entity.HasKey(e => e.ChartFilterId).HasName("PK__EMRChartFilters__3C00B29C");

            entity.ToTable("EMRChartFilters");

            entity.Property(e => e.ChartFilterId).HasColumnName("ChartFilterID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
        });

        modelBuilder.Entity<EmrcodeSystem>(entity =>
        {
            entity.HasKey(e => e.CodeSystemId);

            entity.ToTable("EMRCodeSystems");

            entity.Property(e => e.CodeSystemId).HasColumnName("CodeSystemID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Hl7id)
                .HasMaxLength(10)
                .HasColumnName("HL7ID");
            entity.Property(e => e.Oid)
                .HasMaxLength(140)
                .HasColumnName("OID");
            entity.Property(e => e.ShortName).HasMaxLength(10);
            entity.Property(e => e.Uri)
                .HasMaxLength(255)
                .HasColumnName("URI");
        });

        modelBuilder.Entity<Emrcoding>(entity =>
        {
            entity.HasKey(e => e.TableId);

            entity.ToTable("EMRCoding");

            entity.HasIndex(e => new { e.CodingParent, e.CodingValue }, "IX_EMRCoding").HasFillFactor(90);

            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.CodingParent).HasMaxLength(50);
            entity.Property(e => e.CodingValue).HasMaxLength(50);
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
        });

        modelBuilder.Entity<EmrcodingIcd10>(entity =>
        {
            entity.HasKey(e => e.TableId);

            entity.ToTable("EMRCodingICD10");

            entity.HasIndex(e => e.CodingParent, "IX_EMRCodingICD10_CodingParent").HasFillFactor(90);

            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.CodingParent).HasMaxLength(50);
            entity.Property(e => e.CodingValue).HasMaxLength(50);
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
        });

        modelBuilder.Entity<EmrcolumnControlList>(entity =>
        {
            entity.HasKey(e => e.TableId);

            entity.ToTable("EMRColumnControlList");

            entity.HasIndex(e => e.ControlId, "ColumnControlID").HasFillFactor(90);

            entity.HasIndex(e => e.ParentTableId, "ColumnParentTableID").HasFillFactor(90);

            entity.HasIndex(e => e.TableId, "TableID").HasFillFactor(90);

            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.CodeId).HasColumnName("CodeID");
            entity.Property(e => e.ControlId).HasColumnName("ControlID");
            entity.Property(e => e.DestField).HasMaxLength(50);
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(40)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.ModalityId).HasColumnName("ModalityID");
            entity.Property(e => e.ParentTableId).HasColumnName("ParentTableID");
            entity.Property(e => e.Snomed)
                .HasMaxLength(50)
                .HasColumnName("SNOMED");
        });

        modelBuilder.Entity<EmrcomboControlList>(entity =>
        {
            entity.HasKey(e => e.TableId)
                .HasName("aaaaaEMRComboControlList_PK")
                .IsClustered(false);

            entity.ToTable("EMRComboControlList");

            entity.HasIndex(e => e.ControlId, "ControlID").HasFillFactor(90);

            entity.HasIndex(e => e.TableId, "ItemsID").HasFillFactor(90);

            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.BillMultiProcId).HasColumnName("BillMultiProcID");
            entity.Property(e => e.CameFrom).HasComment("Number to Identify Shared Combos");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CodeIcd10)
                .HasMaxLength(50)
                .HasColumnName("CodeICD10");
            entity.Property(e => e.CodeId)
                .HasComment("TableID of Procedure Code")
                .HasColumnName("CodeID");
            entity.Property(e => e.CodeLoinc)
                .HasMaxLength(50)
                .HasColumnName("CodeLOINC");
            entity.Property(e => e.CodeSnomed)
                .HasMaxLength(50)
                .HasColumnName("CodeSNOMED");
            entity.Property(e => e.ControlId).HasColumnName("ControlID");
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.ModalityId).HasColumnName("ModalityID");
            entity.Property(e => e.Modifier).HasMaxLength(50);
            entity.Property(e => e.Order).HasComment("Field that determines order");
            entity.Property(e => e.UpsizeTs)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("upsize_ts");
            entity.Property(e => e.VisitTypeId).HasColumnName("VisitTypeID");
        });

        modelBuilder.Entity<EmrcontrolId>(entity =>
        {
            entity.HasKey(e => e.TableId)
                .HasName("aaaaaEMRControlIDs_PK")
                .IsClustered(false);

            entity.ToTable("EMRControlIDs");

            entity.HasIndex(e => e.ControlId, "ControlID")
                .IsUnique()
                .HasFillFactor(90);

            entity.HasIndex(e => e.TableId, "TableID").HasFillFactor(90);

            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.ControlId)
                .HasDefaultValue(0)
                .HasColumnName("ControlID");
            entity.Property(e => e.ControlNames).HasMaxLength(50);
            entity.Property(e => e.ControlType).HasMaxLength(50);
            entity.Property(e => e.LastUpdated).HasColumnType("datetime");
            entity.Property(e => e.Xmlname)
                .HasMaxLength(50)
                .HasColumnName("XMLName");
        });

        modelBuilder.Entity<Emrdevice>(entity =>
        {
            entity.HasKey(e => e.EmrdeviceId)
                .HasName("aaaaaEMRDevices_PK")
                .IsClustered(false);

            entity.ToTable("EMRDevices");

            entity.HasIndex(e => e.EmrdeviceId, "EMRDeviceID")
                .IsUnique()
                .HasFillFactor(90);

            entity.HasIndex(e => e.EmrdeviceTypeId, "EMRDeviceID1").HasFillFactor(90);

            entity.Property(e => e.EmrdeviceId).HasColumnName("EMRDeviceID");
            entity.Property(e => e.AutoImportLimit).HasDefaultValue((short)0);
            entity.Property(e => e.EmrdeviceAutoImport).HasColumnName("EMRDeviceAutoImport");
            entity.Property(e => e.EmrdeviceFilePath)
                .HasMaxLength(255)
                .HasComment("Do Not Include last\" \\\"")
                .HasColumnName("EMRDeviceFilePath");
            entity.Property(e => e.EmrdeviceImportLogic).HasColumnName("EMRDeviceImportLogic");
            entity.Property(e => e.EmrdeviceLocation).HasColumnName("EMRDeviceLocation");
            entity.Property(e => e.EmrdeviceName)
                .HasMaxLength(50)
                .HasColumnName("EMRDeviceName");
            entity.Property(e => e.EmrdeviceType)
                .HasComment("1 = Image Save Location, 2 = Diagnostic Device Save Location")
                .HasColumnName("EMRDeviceType");
            entity.Property(e => e.EmrdeviceTypeId).HasColumnName("EMRDeviceTypeID");
            entity.Property(e => e.ModalityId).HasColumnName("ModalityID");
        });

        modelBuilder.Entity<EmrdicomModalityCode>(entity =>
        {
            entity.HasKey(e => e.TableId);

            entity.ToTable("EMRDicomModalityCodes");

            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.Description).HasMaxLength(64);
            entity.Property(e => e.Prioritize).HasDefaultValue((short)0);
        });

        modelBuilder.Entity<Emrdicomdevice>(entity =>
        {
            entity.HasKey(e => e.DicomdeviceId);

            entity.ToTable("EMRDICOMDevices");

            entity.Property(e => e.DicomdeviceId).HasColumnName("DICOMDeviceID");
            entity.Property(e => e.Aetitle)
                .HasMaxLength(25)
                .HasColumnName("AETitle");
            entity.Property(e => e.Description).HasMaxLength(75);
            entity.Property(e => e.Ip)
                .HasMaxLength(25)
                .HasColumnName("IP");
        });

        modelBuilder.Entity<EmrdrugList>(entity =>
        {
            entity.HasKey(e => e.TableId).HasName("PK__EMRDrugList__11B57315");

            entity.ToTable("EMRDrugList");

            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.DrugAltMappingId)
                .HasMaxLength(100)
                .HasColumnName("DrugAltMappingID");
            entity.Property(e => e.DrugBrandType).HasMaxLength(100);
            entity.Property(e => e.DrugDeaclass)
                .HasMaxLength(25)
                .HasColumnName("DrugDEAClass");
            entity.Property(e => e.DrugFdastatus)
                .HasMaxLength(50)
                .HasColumnName("DrugFDAStatus");
            entity.Property(e => e.DrugForm).HasMaxLength(100);
            entity.Property(e => e.DrugFullName).HasMaxLength(255);
            entity.Property(e => e.DrugMappingId)
                .HasMaxLength(100)
                .HasColumnName("DrugMappingID");
            entity.Property(e => e.DrugName).HasMaxLength(100);
            entity.Property(e => e.DrugNameId)
                .HasMaxLength(100)
                .HasColumnName("DrugNameID");
            entity.Property(e => e.DrugRoute).HasMaxLength(100);
            entity.Property(e => e.DrugStrength).HasMaxLength(100);
            entity.Property(e => e.Manufacturer).HasMaxLength(30);
            entity.Property(e => e.Rxcui)
                .HasMaxLength(50)
                .HasColumnName("RXCUI");
            entity.Property(e => e.Snomed)
                .HasMaxLength(50)
                .HasColumnName("SNOMED");
        });

        modelBuilder.Entity<EmrdrugListRxNorm>(entity =>
        {
            entity.HasKey(e => e.TableId);

            entity.ToTable("EMRDrugListRxNorm");

            entity.HasIndex(e => e.DrugMappingId, "DrugMappingID").HasFillFactor(90);

            entity.HasIndex(e => e.RxCui, "RxCUI").HasFillFactor(90);

            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.ActiveStatus).HasMaxLength(5);
            entity.Property(e => e.DrugMappingId)
                .HasMaxLength(10)
                .HasColumnName("DrugMappingID");
            entity.Property(e => e.RxCui)
                .HasMaxLength(10)
                .HasColumnName("RxCUI");
        });

        modelBuilder.Entity<Emredge>(entity =>
        {
            entity.ToTable("EMREdge");

            entity.HasIndex(e => e.MachineKey, "UC_MachineKey").IsUnique();

            entity.Property(e => e.EmredgeId).HasColumnName("EMREdgeID");
            entity.Property(e => e.AuthKey).HasMaxLength(200);
            entity.Property(e => e.ComputerName).HasMaxLength(50);
            entity.Property(e => e.IpAddressV4).HasMaxLength(50);
            entity.Property(e => e.MachineKey).HasMaxLength(200);
        });

        modelBuilder.Entity<EmredgeSite>(entity =>
        {
            entity.ToTable("EMREdgeSite");

            entity.Property(e => e.EmredgeSiteId).HasColumnName("EMREdgeSiteID");
            entity.Property(e => e.EmredgeId).HasColumnName("EMREdgeID");
            entity.Property(e => e.SiteId).HasColumnName("SiteID");
        });

        modelBuilder.Entity<EmreditTracker>(entity =>
        {
            entity.HasKey(e => e.EditTrackerId);

            entity.ToTable("EMREditTracker");

            entity.HasIndex(e => e.PtId, "IX_PtID").HasFillFactor(90);

            entity.Property(e => e.EditTrackerId).HasColumnName("EditTrackerID");
            entity.Property(e => e.ActionType).HasMaxLength(10);
            entity.Property(e => e.AuditHash).HasMaxLength(100);
            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.LinkedFile).HasMaxLength(255);
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.RelatedProviderId).HasColumnName("RelatedProviderID");
            entity.Property(e => e.RequestDate).HasColumnType("datetime");
            entity.Property(e => e.TimeStamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UpsizeTs)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("upsize_ts");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<Emremp>(entity =>
        {
            entity.HasKey(e => e.EmpId);

            entity.ToTable("EMREmp");

            entity.HasIndex(e => e.EmpId, "EmpID").HasFillFactor(90);

            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.AzureAdUserId).HasMaxLength(256);
            entity.Property(e => e.C3enable)
                .HasDefaultValue((short)0)
                .HasColumnName("C3Enable");
            entity.Property(e => e.DirectMessageAddress).HasMaxLength(100);
            entity.Property(e => e.EmailAddress).HasMaxLength(254);
            entity.Property(e => e.EmpAbbr).HasMaxLength(10);
            entity.Property(e => e.EmpActivateErx).HasColumnName("EmpActivateERx");
            entity.Property(e => e.EmpIsActive)
                .HasDefaultValue((short)-1)
                .HasComment("False = Inactive");
            entity.Property(e => e.EmpNameFirst).HasMaxLength(40);
            entity.Property(e => e.EmpNameFull).HasMaxLength(140);
            entity.Property(e => e.EmpNameLast).HasMaxLength(40);
            entity.Property(e => e.EmpNameMiddle).HasMaxLength(40);
            entity.Property(e => e.EmpNameSuffix).HasMaxLength(50);
            entity.Property(e => e.EmpNoEm).HasColumnName("EmpNoEM");
            entity.Property(e => e.EmpQualityReportingAfterMdmc).HasColumnName("EmpQualityReportingAfterMDMC");
            entity.Property(e => e.EmpQualityReportingMedicareFilter).HasMaxLength(255);
            entity.Property(e => e.EmpRoleId)
                .HasDefaultValue(0)
                .HasColumnName("EmpRoleID");
            entity.Property(e => e.EmpRxDeanum)
                .HasMaxLength(50)
                .HasColumnName("EmpRxDEANum");
            entity.Property(e => e.EmpRxLicenseNum).HasMaxLength(50);
            entity.Property(e => e.EmpRxNpinum)
                .HasMaxLength(50)
                .HasColumnName("EmpRxNPINum");
            entity.Property(e => e.EmpRxPassword).HasMaxLength(50);
            entity.Property(e => e.EmpSignOnBehalf).HasMaxLength(255);
            entity.Property(e => e.EmpSignature).HasColumnType("image");
            entity.Property(e => e.EmpSignatureSize).HasDefaultValue(0);
            entity.Property(e => e.ExtEmpId)
                .HasDefaultValue(0)
                .HasColumnName("ExtEmpID");
            entity.Property(e => e.GroupNpi)
                .HasMaxLength(50)
                .HasColumnName("GroupNPI");
            entity.Property(e => e.HidproxAtr).HasColumnName("HIDPROX_ATR");
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.LastPasswordChanged)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MobilePhone).HasMaxLength(50);
            entity.Property(e => e.PatientEngagementAccessKey).HasMaxLength(200);
            entity.Property(e => e.Pmhl7empId)
                .HasMaxLength(50)
                .HasColumnName("PMHL7EmpID");
            entity.Property(e => e.PmintPassword).HasColumnName("PMIntPassword");
            entity.Property(e => e.PmintUserName)
                .HasMaxLength(50)
                .HasColumnName("PMIntUserName");
            entity.Property(e => e.SecurityGroupId).HasColumnName("SecurityGroupID");
            entity.Property(e => e.TestimonialTreeEnable).HasDefaultValue((short)0);
            entity.Property(e => e.UpsizeTs)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("upsize_ts");
            entity.Property(e => e.VisitListColor).HasMaxLength(25);
        });

        modelBuilder.Entity<EmrempMultiFactorToken>(entity =>
        {
            entity.HasKey(e => e.EmpMultiFactorTokenId);

            entity.ToTable("EMREmpMultiFactorToken");

            entity.HasIndex(e => e.EmpId, "IX_EmpMultiFactorToken_EmpID").HasFillFactor(90);

            entity.Property(e => e.EmpMultiFactorTokenId).HasColumnName("EmpMultiFactorTokenID");
            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.InsertGuid).HasMaxLength(50);
            entity.Property(e => e.IssuedOn).HasColumnType("datetime");
            entity.Property(e => e.Pcname)
                .HasMaxLength(50)
                .HasColumnName("PCName");
            entity.Property(e => e.PcuserName)
                .HasMaxLength(256)
                .HasColumnName("PCUserName");
            entity.Property(e => e.Token).HasMaxLength(6);
            entity.Property(e => e.VerifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<EmrempRole>(entity =>
        {
            entity.HasKey(e => e.TableId)
                .HasName("aaaaaEMREmpRole_PK")
                .IsClustered(false);

            entity.ToTable("EMREmpRole");

            entity.HasIndex(e => e.EmpRoleId, "EmpRoleID")
                .IsUnique()
                .HasFillFactor(90);

            entity.HasIndex(e => e.TableId, "TableID").HasFillFactor(90);

            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.EmpRoleId)
                .HasDefaultValue(0)
                .HasColumnName("EmpRoleID");
        });

        modelBuilder.Entity<EmrexportDevice>(entity =>
        {
            entity.HasKey(e => e.ExportDeviceId);

            entity.ToTable("EMRExportDevices");

            entity.Property(e => e.ExportDeviceId).HasColumnName("ExportDeviceID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.PtIdtype).HasColumnName("PtIDType");
        });

        modelBuilder.Entity<EmrfastPlan>(entity =>
        {
            entity.HasKey(e => e.FastPlanId)
                .HasName("aaaaaEMRFastPlan_PK")
                .IsClustered(false);

            entity.ToTable("EMRFastPlan");

            entity.HasIndex(e => e.FastPlanId, "CustomVisitID")
                .IsUnique()
                .HasFillFactor(90);

            entity.Property(e => e.FastPlanId).HasColumnName("FastPlanID");
            entity.Property(e => e.FastPlanEmpId).HasColumnName("FastPlanEmpID");
            entity.Property(e => e.FastPlanName).HasMaxLength(255);
            entity.Property(e => e.FastPlanPtEducationId).HasColumnName("FastPlanPtEducationID");
            entity.Property(e => e.FastPlanRtowhen)
                .HasMaxLength(255)
                .HasColumnName("FastPlanRTOWhen");
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.UpsizeTs)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("upsize_ts");
        });

        modelBuilder.Entity<EmrfastPlanDiag>(entity =>
        {
            entity.HasKey(e => e.FastPlanDiagId).HasName("PK__EMRFastPlanDiag__27A4B434");

            entity.ToTable("EMRFastPlanDiag");

            entity.Property(e => e.FastPlanDiagId).HasColumnName("FastPlanDiagID");
            entity.Property(e => e.DiagCode).HasMaxLength(25);
            entity.Property(e => e.FastPlanId).HasColumnName("FastPlanID");
        });

        modelBuilder.Entity<EmrfastPlanMed>(entity =>
        {
            entity.HasKey(e => e.FastPlanMedsId)
                .HasName("aaaaaEMRFastPlanMeds_PK")
                .IsClustered(false);

            entity.ToTable("EMRFastPlanMeds");

            entity.HasIndex(e => e.FastPlanId, "VisitID").HasFillFactor(90);

            entity.HasIndex(e => e.FastPlanMedsId, "VisitTechID")
                .IsUnique()
                .HasFillFactor(90);

            entity.Property(e => e.FastPlanMedsId).HasColumnName("FastPlanMedsID");
            entity.Property(e => e.FastPlanDrugAltMappingId)
                .HasMaxLength(100)
                .HasColumnName("FastPlanDrugAltMappingID");
            entity.Property(e => e.FastPlanDrugDeaclass)
                .HasMaxLength(25)
                .HasColumnName("FastPlanDrugDEAClass");
            entity.Property(e => e.FastPlanDrugFdastatus)
                .HasMaxLength(50)
                .HasColumnName("FastPlanDrugFDAStatus");
            entity.Property(e => e.FastPlanDrugForm).HasMaxLength(100);
            entity.Property(e => e.FastPlanDrugMappingId)
                .HasMaxLength(100)
                .HasColumnName("FastPlanDrugMappingID");
            entity.Property(e => e.FastPlanDrugName).HasMaxLength(200);
            entity.Property(e => e.FastPlanDrugNameId)
                .HasMaxLength(100)
                .HasColumnName("FastPlanDrugNameID");
            entity.Property(e => e.FastPlanDrugRoute).HasMaxLength(100);
            entity.Property(e => e.FastPlanDrugStrength).HasMaxLength(100);
            entity.Property(e => e.FastPlanId).HasColumnName("FastPlanID");
            entity.Property(e => e.FastPlanMedDisp).HasMaxLength(255);
            entity.Property(e => e.FastPlanMedDispUnitType).HasMaxLength(100);
            entity.Property(e => e.FastPlanMedName).HasMaxLength(255);
            entity.Property(e => e.FastPlanMedRefill).HasMaxLength(255);
            entity.Property(e => e.FastPlanMedSig).HasMaxLength(255);
            entity.Property(e => e.FastPlanMedType).HasComment("1 = Eye Medications, 2 =Systemic Medications");
            entity.Property(e => e.FastPlanRxRemarks).HasMaxLength(255);
            entity.Property(e => e.FastPlanRxcui)
                .HasMaxLength(50)
                .HasColumnName("FastPlanRXCUI");
            entity.Property(e => e.FastPlanSnomed)
                .HasMaxLength(50)
                .HasColumnName("FastPlanSNOMED");
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
        });

        modelBuilder.Entity<EmrfastPlanNarrativeFragment>(entity =>
        {
            entity.HasKey(e => e.FastPlanNarrativeFragmentId);

            entity.ToTable("EMRFastPlanNarrativeFragment");

            entity.Property(e => e.FastPlanNarrativeFragmentId).HasColumnName("FastPlanNarrativeFragmentID");
            entity.Property(e => e.FastPlanId).HasColumnName("FastPlanID");
            entity.Property(e => e.NarrativeType).HasMaxLength(50);
            entity.Property(e => e.ShortHand).HasMaxLength(20);
            entity.Property(e => e.Snomedcode)
                .HasMaxLength(50)
                .HasColumnName("SNOMEDCode");
        });

        modelBuilder.Entity<EmrfastPlanOrder>(entity =>
        {
            entity.HasKey(e => e.FastPlanOrdersId)
                .HasName("aaaaaEMRFastPlanOrders_PK")
                .IsClustered(false);

            entity.ToTable("EMRFastPlanOrders");

            entity.HasIndex(e => e.FastPlanId, "PTID").HasFillFactor(90);

            entity.HasIndex(e => e.FastPlanOrdersId, "VisitTechID")
                .IsUnique()
                .HasFillFactor(90);

            entity.Property(e => e.FastPlanOrdersId).HasColumnName("FastPlanOrdersID");
            entity.Property(e => e.FastPlanCodeCpt)
                .HasMaxLength(50)
                .HasColumnName("FastPlanCodeCPT");
            entity.Property(e => e.FastPlanCodeLoinc)
                .HasMaxLength(20)
                .HasColumnName("FastPlanCodeLOINC");
            entity.Property(e => e.FastPlanCodeSnomed)
                .HasMaxLength(50)
                .HasColumnName("FastPlanCodeSNOMED");
            entity.Property(e => e.FastPlanId).HasColumnName("FastPlanID");
            entity.Property(e => e.FastPlanOrderDescription).HasMaxLength(255);
            entity.Property(e => e.FastPlanOrderModalityId).HasColumnName("FastPlanOrderModalityID");
            entity.Property(e => e.FastPlanOrderRemarks).HasMaxLength(255);
            entity.Property(e => e.FastPlanOrderTypeId).HasColumnName("FastPlanOrderTypeID");
            entity.Property(e => e.FastPlanOrderWhen).HasMaxLength(255);
            entity.Property(e => e.FastPlanRefProviderFirstName).HasMaxLength(50);
            entity.Property(e => e.FastPlanRefProviderId)
                .HasMaxLength(20)
                .HasColumnName("FastPlanRefProviderID");
            entity.Property(e => e.FastPlanRefProviderLastName).HasMaxLength(50);
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
        });

        modelBuilder.Entity<Emrfaxis>(entity =>
        {
            entity.HasKey(e => e.FaxId);

            entity.ToTable("EMRFaxes");

            entity.Property(e => e.FaxId).HasColumnName("FaxID");
            entity.Property(e => e.AssignedPcname)
                .HasMaxLength(50)
                .HasColumnName("AssignedPCName");
            entity.Property(e => e.CreatedTime).HasColumnType("datetime");
            entity.Property(e => e.Csid)
                .HasMaxLength(25)
                .HasColumnName("CSID");
            entity.Property(e => e.ExtendedStatusId).HasColumnName("ExtendedStatusID");
            entity.Property(e => e.FaxDocumentUri)
                .HasMaxLength(400)
                .HasColumnName("FaxDocumentURI");
            entity.Property(e => e.InitialSubmissionComputer).HasMaxLength(50);
            entity.Property(e => e.InitialSubmissionWindowsUser).HasMaxLength(50);
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");
            entity.Property(e => e.LinkedImageId).HasColumnName("LinkedImageID");
            entity.Property(e => e.Memo).HasMaxLength(2000);
            entity.Property(e => e.OriginalDocument).HasMaxLength(350);
            entity.Property(e => e.Priority).HasDefaultValue(1);
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.RecipientName).HasMaxLength(50);
            entity.Property(e => e.SenderCompany).HasMaxLength(100);
            entity.Property(e => e.SenderFaxNumber).HasMaxLength(50);
            entity.Property(e => e.SenderInfoSiteId).HasColumnName("SenderInfoSiteID");
            entity.Property(e => e.SenderName).HasMaxLength(100);
            entity.Property(e => e.SenderOfficePhone).HasMaxLength(30);
            entity.Property(e => e.SenderStreetAddress).HasMaxLength(300);
            entity.Property(e => e.StateId).HasColumnName("StateID");
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.Subject).HasMaxLength(200);
            entity.Property(e => e.SubmissionId)
                .HasMaxLength(50)
                .HasColumnName("SubmissionID");
            entity.Property(e => e.SubmittedByEmpId).HasColumnName("SubmittedByEmpID");
            entity.Property(e => e.SubmittedBySiteId).HasColumnName("SubmittedBySiteID");
            entity.Property(e => e.SubmittedTime).HasColumnType("datetime");
            entity.Property(e => e.SubmittedToSiteId).HasColumnName("SubmittedToSiteID");
            entity.Property(e => e.SuccessfulSubmissionComputer).HasMaxLength(50);
            entity.Property(e => e.SuccessfulSubmissionWindowsUser).HasMaxLength(50);
            entity.Property(e => e.ToFaxNumber).HasMaxLength(30);
            entity.Property(e => e.Tsid)
                .HasMaxLength(25)
                .HasColumnName("TSID");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<Emrfield>(entity =>
        {
            entity.HasKey(e => e.FieldId)
                .HasName("aaaaaEMRFields_PK")
                .IsClustered(false);

            entity.ToTable("EMRFields");

            entity.HasIndex(e => e.ControlId, "ControlID").HasFillFactor(90);

            entity.HasIndex(e => e.FieldId, "FieldID")
                .IsUnique()
                .HasFillFactor(90);

            entity.HasIndex(e => e.LetterField, "LetterField")
                .IsUnique()
                .HasFillFactor(90);

            entity.Property(e => e.FieldId).HasColumnName("FieldID");
            entity.Property(e => e.ControlId).HasColumnName("ControlID");
            entity.Property(e => e.Field).HasMaxLength(50);
            entity.Property(e => e.FormerFields)
                .HasMaxLength(100)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.LetterField).HasMaxLength(50);
            entity.Property(e => e.Section).HasMaxLength(50);
            entity.Property(e => e.Tab).HasMaxLength(50);
            entity.Property(e => e.Table).HasMaxLength(50);
            entity.Property(e => e.TableField).HasMaxLength(255);
        });

        modelBuilder.Entity<Emrgemsi10i9>(entity =>
        {
            entity.HasKey(e => e.TableId);

            entity.ToTable("EMRGEMSI10I9");

            entity.HasIndex(e => e.Icd10code, "ICD10Code").HasFillFactor(90);

            entity.HasIndex(e => new { e.Icd9code, e.Icd10code }, "IX_EMRGEMSI10I9_ICD9_ICD10").HasFillFactor(90);

            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.Flags).HasMaxLength(6);
            entity.Property(e => e.Icd10code)
                .HasMaxLength(10)
                .HasColumnName("ICD10Code");
            entity.Property(e => e.Icd9code)
                .HasMaxLength(10)
                .HasColumnName("ICD9Code");
        });

        modelBuilder.Entity<Emrgemsi9i10>(entity =>
        {
            entity.HasKey(e => e.TableId);

            entity.ToTable("EMRGEMSI9I10");

            entity.HasIndex(e => new { e.Icd9code, e.Icd10code }, "ICD910Code").HasFillFactor(90);

            entity.HasIndex(e => e.Icd9code, "ICD9Code").HasFillFactor(90);

            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.Flags).HasMaxLength(6);
            entity.Property(e => e.Icd10code)
                .HasMaxLength(10)
                .HasColumnName("ICD10Code");
            entity.Property(e => e.Icd9code)
                .HasMaxLength(10)
                .HasColumnName("ICD9Code");
        });

        modelBuilder.Entity<Emricd10>(entity =>
        {
            entity.HasKey(e => e.TableId);

            entity.ToTable("EMRICD10");

            entity.HasIndex(e => e.Description, "Description").HasFillFactor(90);

            entity.HasIndex(e => new { e.Icd10code, e.IsHeader, e.Description }, "ICD10Code").HasFillFactor(90);

            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.HasUleyelid).HasColumnName("HasULEyelid");
            entity.Property(e => e.Icd10code)
                .HasMaxLength(10)
                .HasColumnName("ICD10Code");
        });

        modelBuilder.Entity<Emricd9>(entity =>
        {
            entity.HasKey(e => e.TableId);

            entity.ToTable("EMRICD9");

            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Icd9code)
                .HasMaxLength(10)
                .HasColumnName("ICD9Code");
        });

        modelBuilder.Entity<Emricd9toSnomed>(entity =>
        {
            entity.HasKey(e => e.TableId);

            entity.ToTable("EMRICD9toSNOMED");

            entity.HasIndex(e => e.IcdCode, "ICD_CODE").HasFillFactor(90);

            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.IcdCode)
                .HasMaxLength(10)
                .HasColumnName("ICD_CODE");
            entity.Property(e => e.SnomedCid)
                .HasMaxLength(18)
                .HasColumnName("SNOMED_CID");
        });

        modelBuilder.Entity<EmrimagesImbedded>(entity =>
        {
            entity.HasKey(e => e.ImbededImageId)
                .HasName("aaaaaEMRImagesImbedded_PK")
                .IsClustered(false);

            entity.ToTable("EMRImagesImbedded");

            entity.HasIndex(e => e.Code, "Code").HasFillFactor(90);

            entity.HasIndex(e => e.ControlId, "ControlID").HasFillFactor(90);

            entity.HasIndex(e => e.ImbededImageId, "ImageEmbededID")
                .IsUnique()
                .HasFillFactor(90);

            entity.Property(e => e.ImbededImageId).HasColumnName("ImbededImageID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CodeId).HasColumnName("CodeID");
            entity.Property(e => e.ControlId).HasColumnName("ControlID");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.DestField).HasMaxLength(50);
            entity.Property(e => e.Image).HasColumnType("image");
            entity.Property(e => e.ImageSize).HasDefaultValue(0);
            entity.Property(e => e.ImageType).HasComment("1 = Background Image, 2 = Stamp");
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(40)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.Itlevel).HasColumnName("ITLevel");
            entity.Property(e => e.ParentId).HasColumnName("ParentID");
            entity.Property(e => e.UpsizeTs)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("upsize_ts");
        });

        modelBuilder.Entity<EmrimagesLinked>(entity =>
        {
            entity.HasKey(e => e.LinkedImageId)
                .HasName("aaaaaEMRImagesLinked_PK")
                .IsClustered(false);

            entity.ToTable("EMRImagesLinked");

            entity.HasIndex(e => e.ControlId, "ControlID").HasFillFactor(90);

            entity.HasIndex(e => new { e.InsertGuid, e.LinkedImageId }, "IX_EMRImagesLinked_9_107863451__K20_K1").HasFillFactor(90);

            entity.HasIndex(e => e.RequestedProcedureId, "IX_ImagesLinked_RequestedProcedureID").HasFillFactor(90);

            entity.HasIndex(e => e.LinkedImageId, "LinkedImageID")
                .IsUnique()
                .HasFillFactor(90);

            entity.HasIndex(e => e.MdreviewedEmpId, "MDEmpID").HasFillFactor(90);

            entity.HasIndex(e => e.PtId, "PtID").HasFillFactor(90);

            entity.HasIndex(e => e.VisitId, "VisitID").HasFillFactor(90);

            entity.Property(e => e.LinkedImageId).HasColumnName("LinkedImageID");
            entity.Property(e => e.AaohandoutsInfo)
                .HasMaxLength(500)
                .HasColumnName("AAOHandoutsInfo");
            entity.Property(e => e.AmendRequestDate).HasColumnType("datetime");
            entity.Property(e => e.AmendResultDate).HasColumnType("datetime");
            entity.Property(e => e.AmendSource).HasMaxLength(100);
            entity.Property(e => e.ControlId).HasColumnName("ControlID");
            entity.Property(e => e.Dicommodality)
                .HasMaxLength(10)
                .HasColumnName("DICOMModality");
            entity.Property(e => e.DicomptDob)
                .HasMaxLength(25)
                .HasColumnName("DICOMPtDOB");
            entity.Property(e => e.DicomptName)
                .HasMaxLength(200)
                .HasColumnName("DICOMPtName");
            entity.Property(e => e.DicomrequestedProcedureId)
                .HasMaxLength(50)
                .HasColumnName("DICOMRequestedProcedureID");
            entity.Property(e => e.DicomscheduledProcedureStepId)
                .HasMaxLength(50)
                .HasColumnName("DICOMScheduledProcedureStepID");
            entity.Property(e => e.DicomstudyId)
                .HasMaxLength(50)
                .HasColumnName("DICOMStudyID");
            entity.Property(e => e.DocumentClass).HasComment("1 = Office Document, 2 = Medical Document, 3 = Records");
            entity.Property(e => e.DocumentSha1hashes).HasColumnName("DocumentSHA1Hashes");
            entity.Property(e => e.EdgeHash).HasMaxLength(40);
            entity.Property(e => e.FhirCategory).HasMaxLength(500);
            entity.Property(e => e.FhirCode).HasMaxLength(500);
            entity.Property(e => e.ImageDescription).HasMaxLength(255);
            entity.Property(e => e.ImagePath).HasMaxLength(255);
            entity.Property(e => e.ImageType).HasComment("1 = EMR Visit Image, 2 = Patient Documents");
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.Laterality).HasMaxLength(10);
            entity.Property(e => e.Mdreview).HasColumnName("MDReview");
            entity.Property(e => e.Mdreviewed).HasColumnName("MDReviewed");
            entity.Property(e => e.MdreviewedDate)
                .HasColumnType("datetime")
                .HasColumnName("MDReviewedDate");
            entity.Property(e => e.MdreviewedEmpId).HasColumnName("MDReviewedEmpID");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.ReconciledCcdavisitId).HasColumnName("ReconciledCCDAVisitID");
            entity.Property(e => e.Reference).HasMaxLength(2000);
            entity.Property(e => e.ReferencedSopinstanceUid)
                .HasMaxLength(65)
                .HasColumnName("ReferencedSOPInstanceUID");
            entity.Property(e => e.RelatedIomid).HasColumnName("RelatedIOMID");
            entity.Property(e => e.RelatedProviderId).HasColumnName("RelatedProviderID");
            entity.Property(e => e.RelatedSiteId).HasColumnName("RelatedSiteID");
            entity.Property(e => e.RequestedProcedureId).HasColumnName("RequestedProcedureID");
            entity.Property(e => e.SeriesInstanceUid)
                .HasMaxLength(65)
                .HasColumnName("SeriesInstanceUID");
            entity.Property(e => e.SopclassUid)
                .HasMaxLength(65)
                .HasColumnName("SOPClassUID");
            entity.Property(e => e.SopinstanceUid)
                .HasMaxLength(65)
                .HasColumnName("SOPInstanceUID");
            entity.Property(e => e.StudyInstanceUid)
                .HasMaxLength(65)
                .HasColumnName("StudyInstanceUID");
            entity.Property(e => e.TimeStamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<EmrimagesLinkedDataTag>(entity =>
        {
            entity.HasKey(e => e.LinkedDataTagId);

            entity.ToTable("EMRImagesLinkedDataTags");

            entity.Property(e => e.LinkedDataTagId).HasColumnName("LinkedDataTagID");
            entity.Property(e => e.DataTypeId)
                .HasMaxLength(25)
                .HasColumnName("DataTypeID");
            entity.Property(e => e.Description).HasMaxLength(75);
            entity.Property(e => e.Dicomtag)
                .HasMaxLength(15)
                .HasColumnName("DICOMTag");
            entity.Property(e => e.ModalityCode).HasMaxLength(25);
        });

        modelBuilder.Entity<EmrimagesLinkedDatum>(entity =>
        {
            entity.HasKey(e => e.LinkedDataId);

            entity.ToTable("EMRImagesLinkedData");

            entity.Property(e => e.LinkedDataId).HasColumnName("LinkedDataID");
            entity.Property(e => e.DataTypeId)
                .HasMaxLength(25)
                .HasColumnName("DataTypeID");
            entity.Property(e => e.DataValue).HasMaxLength(75);
            entity.Property(e => e.Description).HasMaxLength(75);
            entity.Property(e => e.Dicomtag)
                .HasMaxLength(15)
                .HasColumnName("DICOMTag");
            entity.Property(e => e.Dosdate)
                .HasColumnType("datetime")
                .HasColumnName("DOSDate");
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.LinkedImageId).HasColumnName("LinkedImageID");
            entity.Property(e => e.PtId).HasColumnName("PtID");
        });

        modelBuilder.Entity<EmrimagingModality>(entity =>
        {
            entity.HasKey(e => e.ModalityId);

            entity.ToTable("EMRImagingModalities");

            entity.Property(e => e.ModalityId).HasColumnName("ModalityID");
            entity.Property(e => e.Abbr).HasMaxLength(10);
            entity.Property(e => e.AcquisitionDeviceTypes).HasMaxLength(64);
            entity.Property(e => e.Description).HasMaxLength(64);
            entity.Property(e => e.IsActive).HasDefaultValue((short)-1);
            entity.Property(e => e.ModalityCodes).HasMaxLength(64);
            entity.Property(e => e.Prioritize).HasDefaultValue((short)0);
            entity.Property(e => e.Template).HasDefaultValue(0);
        });

        modelBuilder.Entity<EmrimagingRequestedProcedure>(entity =>
        {
            entity.HasKey(e => e.RequestedProcedureId);

            entity.ToTable("EMRImagingRequestedProcedure");

            entity.HasIndex(e => e.PtId, "IX_PtID").HasFillFactor(90);

            entity.Property(e => e.RequestedProcedureId).HasColumnName("RequestedProcedureID");
            entity.Property(e => e.CodeId).HasColumnName("CodeID");
            entity.Property(e => e.CodeLoinc)
                .HasMaxLength(50)
                .HasColumnName("CodeLOINC");
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.CreatedEmpId).HasColumnName("CreatedEmpID");
            entity.Property(e => e.Dicommodality)
                .HasMaxLength(5)
                .HasColumnName("DICOMModality");
            entity.Property(e => e.DicomptId)
                .HasMaxLength(50)
                .HasColumnName("DICOMPtID");
            entity.Property(e => e.DicomrequestedProcedureId)
                .HasMaxLength(50)
                .HasColumnName("DICOMRequestedProcedureID");
            entity.Property(e => e.DicomscheduledProcedureStepId)
                .HasMaxLength(50)
                .HasColumnName("DICOMScheduledProcedureStepID");
            entity.Property(e => e.DicomstudyId)
                .HasMaxLength(50)
                .HasColumnName("DICOMStudyID");
            entity.Property(e => e.Dosdate)
                .HasColumnType("datetime")
                .HasColumnName("DOSDate");
            entity.Property(e => e.ExcludeReview).HasDefaultValue((short)0);
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.IolselectedIolOd).HasColumnName("IOLSelectedIOL_OD");
            entity.Property(e => e.IolselectedIolOs).HasColumnName("IOLSelectedIOL_OS");
            entity.Property(e => e.IolselectedIolexpRefOd)
                .HasMaxLength(50)
                .HasColumnName("IOLSelectedIOLExpRef_OD");
            entity.Property(e => e.IolselectedIolexpRefOs)
                .HasMaxLength(50)
                .HasColumnName("IOLSelectedIOLExpRef_OS");
            entity.Property(e => e.IolselectedIolpowerOd)
                .HasMaxLength(50)
                .HasColumnName("IOLSelectedIOLPower_OD");
            entity.Property(e => e.IolselectedIolpowerOs)
                .HasMaxLength(50)
                .HasColumnName("IOLSelectedIOLPower_OS");
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedEmpId).HasColumnName("LastModifiedEmpID");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Mdreviewed)
                .HasDefaultValue((short)0)
                .HasColumnName("MDReviewed");
            entity.Property(e => e.MdreviewedDate)
                .HasColumnType("datetime")
                .HasColumnName("MDReviewedDate");
            entity.Property(e => e.MdreviewedEmpId).HasColumnName("MDReviewedEmpID");
            entity.Property(e => e.ModalityId).HasColumnName("ModalityID");
            entity.Property(e => e.ProviderEmpId).HasColumnName("ProviderEmpID");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.RpdirtyInfo)
                .HasMaxLength(255)
                .HasColumnName("RPDirtyInfo");
            entity.Property(e => e.RpisDirty).HasColumnName("RPIsDirty");
            entity.Property(e => e.StudyInstanceUid)
                .HasMaxLength(64)
                .HasColumnName("StudyInstanceUID");
            entity.Property(e => e.TestDescription).HasMaxLength(255);
            entity.Property(e => e.TestName).HasMaxLength(75);
        });

        modelBuilder.Entity<Emriom>(entity =>
        {
            entity.HasKey(e => e.Iomid)
                .HasName("aaaaaEMRIOM_PK")
                .IsClustered(false);

            entity.ToTable("EMRIOM");

            entity.HasIndex(e => new { e.Completed, e.EmpTo, e.IsDeleted }, "IX_EMRIOM_9_187863736__K11_K7_K16").HasFillFactor(90);

            entity.HasIndex(e => e.RelatedPtId, "PtID").HasFillFactor(90);

            entity.HasIndex(e => e.RelatedControlId, "RelatedControlID").HasFillFactor(90);

            entity.HasIndex(e => e.RelatedRecordId, "RelatedRecordID").HasFillFactor(90);

            entity.HasIndex(e => e.Iomid, "VisitDiagTestIOLID")
                .IsUnique()
                .HasFillFactor(90);

            entity.HasIndex(e => e.RelatedVisitId, "VisitID").HasFillFactor(90);

            entity.Property(e => e.Iomid).HasColumnName("IOMID");
            entity.Property(e => e.CompletedTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.DeletedTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.DirectGuid)
                .HasMaxLength(50)
                .HasColumnName("DirectGUID");
            entity.Property(e => e.IommessageGuid)
                .HasMaxLength(50)
                .HasColumnName("IOMMessageGUID");
            entity.Property(e => e.MessageText).HasColumnType("ntext");
            entity.Property(e => e.OriginalIomid).HasColumnName("OriginalIOMID");
            entity.Property(e => e.Priority).HasComment("Is Null or 0 = Normal, 1=Urgent");
            entity.Property(e => e.ReAssignedTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.ReadTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.RegardingText).HasColumnType("ntext");
            entity.Property(e => e.RelatedControlId).HasColumnName("RelatedControlID");
            entity.Property(e => e.RelatedPtId).HasColumnName("RelatedPtID");
            entity.Property(e => e.RelatedRecordId).HasColumnName("RelatedRecordID");
            entity.Property(e => e.RelatedReferralOrderId).HasColumnName("RelatedReferralOrderID");
            entity.Property(e => e.RelatedVisitId).HasColumnName("RelatedVisitID");
            entity.Property(e => e.SentTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.UpsizeTs)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("upsize_ts");
            entity.Property(e => e.WebportalMessageId).HasColumnName("WebportalMessageID");
        });

        modelBuilder.Entity<Emrlab>(entity =>
        {
            entity.HasKey(e => e.LabId).HasName("PK__EMRLabs__57B2EEB2");

            entity.ToTable("EMRLabs");

            entity.HasIndex(e => e.LabId, "UQ__EMRLabs__58A712EB").IsUnique();

            entity.Property(e => e.LabId).HasColumnName("LabID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.City).HasMaxLength(255);
            entity.Property(e => e.Fax).HasMaxLength(255);
            entity.Property(e => e.LabHl7enableExport).HasColumnName("LabHL7EnableExport");
            entity.Property(e => e.LabHl7exportLocation).HasColumnName("LabHL7ExportLocation");
            entity.Property(e => e.LabHl7facilityId)
                .HasMaxLength(255)
                .HasColumnName("LabHL7FacilityID");
            entity.Property(e => e.Phone).HasMaxLength(255);
            entity.Property(e => e.State).HasMaxLength(255);
            entity.Property(e => e.Zip).HasMaxLength(255);
        });

        modelBuilder.Entity<EmrlabResult>(entity =>
        {
            entity.HasKey(e => e.LabResultId).HasName("PK__EMRLabResults__5D6BC808");

            entity.ToTable("EMRLabResults");

            entity.HasIndex(e => e.LabResultId, "UQ__EMRLabResults__5E5FEC41").IsUnique();

            entity.Property(e => e.LabResultId).HasColumnName("LabResultID");
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.CreatedEmpId).HasColumnName("CreatedEmpID");
            entity.Property(e => e.FillerOrderId)
                .HasMaxLength(255)
                .HasColumnName("FillerOrderID");
            entity.Property(e => e.FillerOrderNamespace).HasMaxLength(100);
            entity.Property(e => e.Hl7ptDob)
                .HasMaxLength(50)
                .HasColumnName("HL7PtDOB");
            entity.Property(e => e.Hl7ptGender)
                .HasMaxLength(10)
                .HasColumnName("HL7PtGender");
            entity.Property(e => e.Hl7ptId)
                .HasMaxLength(100)
                .HasColumnName("HL7PtID");
            entity.Property(e => e.Hl7ptIdnameSpace)
                .HasMaxLength(100)
                .HasColumnName("HL7PtIDNameSpace");
            entity.Property(e => e.Hl7ptIdtypeCode)
                .HasMaxLength(50)
                .HasColumnName("HL7PtIDTypeCode");
            entity.Property(e => e.Hl7ptName)
                .HasMaxLength(150)
                .HasColumnName("HL7PtName");
            entity.Property(e => e.Hl7ptRace)
                .HasMaxLength(50)
                .HasColumnName("HL7PtRace");
            entity.Property(e => e.Hl7ptRaceAlt)
                .HasMaxLength(50)
                .HasColumnName("HL7PtRaceAlt");
            entity.Property(e => e.ImportOrderedDocId)
                .HasMaxLength(100)
                .HasColumnName("ImportOrderedDocID");
            entity.Property(e => e.ImportOrderedDocIdtypeCode)
                .HasMaxLength(50)
                .HasColumnName("ImportOrderedDocIDTypeCode");
            entity.Property(e => e.ImportOrderedDocNameTypeCode).HasMaxLength(50);
            entity.Property(e => e.ImportOrderedDocNamespace).HasMaxLength(100);
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.ItemDate).HasColumnType("datetime");
            entity.Property(e => e.ItemDateTimeZone).HasMaxLength(50);
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedEmpId).HasColumnName("LastModifiedEmpID");
            entity.Property(e => e.Mdreviewed).HasColumnName("MDReviewed");
            entity.Property(e => e.MdreviewedDate)
                .HasColumnType("datetime")
                .HasColumnName("MDReviewedDate");
            entity.Property(e => e.MdreviewedEmpId).HasColumnName("MDReviewedEmpID");
            entity.Property(e => e.OrderedEmpId).HasColumnName("OrderedEmpID");
            entity.Property(e => e.ParentFillerOrderId)
                .HasMaxLength(100)
                .HasColumnName("ParentFillerOrderID");
            entity.Property(e => e.ParentFillerOrderNamespace).HasMaxLength(100);
            entity.Property(e => e.ParentLabResultId).HasColumnName("ParentLabResultID");
            entity.Property(e => e.ParentServiceId)
                .HasMaxLength(100)
                .HasColumnName("ParentServiceID");
            entity.Property(e => e.ParentSubId)
                .HasMaxLength(100)
                .HasColumnName("ParentSubID");
            entity.Property(e => e.PerfOrgAddr).HasMaxLength(150);
            entity.Property(e => e.PerfOrgCity).HasMaxLength(150);
            entity.Property(e => e.PerfOrgCountry).HasMaxLength(50);
            entity.Property(e => e.PerfOrgCountyCode).HasMaxLength(50);
            entity.Property(e => e.PerfOrgIdentifier).HasMaxLength(50);
            entity.Property(e => e.PerfOrgIdentifierNameSpace).HasMaxLength(100);
            entity.Property(e => e.PerfOrgIdentifierTypeCode).HasMaxLength(50);
            entity.Property(e => e.PerfOrgMedDirId)
                .HasMaxLength(100)
                .HasColumnName("PerfOrgMedDirID");
            entity.Property(e => e.PerfOrgMedDirName).HasMaxLength(100);
            entity.Property(e => e.PerfOrgName).HasMaxLength(150);
            entity.Property(e => e.PerfOrgState).HasMaxLength(10);
            entity.Property(e => e.PerfOrgZip).HasMaxLength(15);
            entity.Property(e => e.PlacerGroupNamespace).HasMaxLength(100);
            entity.Property(e => e.PlacerGroupNumber).HasMaxLength(100);
            entity.Property(e => e.PlacerOrderId)
                .HasMaxLength(255)
                .HasColumnName("PlacerOrderID");
            entity.Property(e => e.PlacerOrderNamespace).HasMaxLength(100);
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.ResultFlag).HasMaxLength(255);
            entity.Property(e => e.ResultNumber).HasMaxLength(255);
            entity.Property(e => e.ResultRange).HasMaxLength(255);
            entity.Property(e => e.ResultStatus).HasMaxLength(255);
            entity.Property(e => e.ResultUnits).HasMaxLength(255);
            entity.Property(e => e.ResultValue).HasMaxLength(255);
            entity.Property(e => e.ResultsReportStatusChangeDateTime).HasMaxLength(50);
            entity.Property(e => e.ResultsReportStatusChangeTimeZone).HasMaxLength(50);
            entity.Property(e => e.ServiceId)
                .HasMaxLength(255)
                .HasColumnName("ServiceID");
            entity.Property(e => e.ServiceIdtype)
                .HasMaxLength(50)
                .HasColumnName("ServiceIDType");
            entity.Property(e => e.SpecimenActionCode).HasMaxLength(50);
            entity.Property(e => e.SpecimenCollectionStart).HasColumnType("datetime");
            entity.Property(e => e.SpecimenCollectionStartTimeZone).HasMaxLength(50);
            entity.Property(e => e.SpecimenCondition).HasMaxLength(100);
            entity.Property(e => e.SpecimenSource).HasMaxLength(255);
            entity.Property(e => e.SpecimenSourceCode).HasMaxLength(50);
            entity.Property(e => e.SubId)
                .HasMaxLength(100)
                .HasColumnName("SubID");
            entity.Property(e => e.TestEntered).HasColumnType("datetime");
            entity.Property(e => e.VisitOrderId).HasColumnName("VisitOrderID");
        });

        modelBuilder.Entity<Emrlanguage>(entity =>
        {
            entity.HasKey(e => e.TableId);

            entity.ToTable("EMRLanguages");

            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.Description).HasMaxLength(75);
            entity.Property(e => e.Iso6391code)
                .HasMaxLength(5)
                .HasColumnName("ISO6391Code");
            entity.Property(e => e.Iso6392code)
                .HasMaxLength(5)
                .HasColumnName("ISO6392Code");
            entity.Property(e => e.Prioritize).HasDefaultValue((short)0);
        });

        modelBuilder.Entity<EmrletterTemplate>(entity =>
        {
            entity.HasKey(e => e.LetterId)
                .HasName("aaaaaEMRLetterTemplates_PK")
                .IsClustered(false);

            entity.ToTable("EMRLetterTemplates");

            entity.HasIndex(e => e.LetterId, "DocumentID").HasFillFactor(90);

            entity.Property(e => e.LetterId).HasColumnName("LetterID");
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(40)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.LetterDescription).HasMaxLength(50);
            entity.Property(e => e.LetterRtf)
                .HasColumnType("image")
                .HasColumnName("LetterRTF");
            entity.Property(e => e.LetterType).HasComment(" 0=Other, 1=Consent Forms, 2=Referral Forms, 3= Surgery Forms, 4=Patient Letters");
            entity.Property(e => e.UpsizeTs)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("upsize_ts");
        });

        modelBuilder.Entity<Emrlock>(entity =>
        {
            entity.HasKey(e => e.LockId);

            entity.ToTable("EMRLocks");

            entity.Property(e => e.LockId).HasColumnName("LockID");
            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.FormName).HasMaxLength(50);
            entity.Property(e => e.LockTime).HasColumnType("datetime");
            entity.Property(e => e.OperatingSystemName).HasMaxLength(50);
            entity.Property(e => e.Pcname)
                .HasMaxLength(50)
                .HasColumnName("PCName");
            entity.Property(e => e.PcuserName)
                .HasMaxLength(50)
                .HasColumnName("PCUserName");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<EmrmobileCorrelation>(entity =>
        {
            entity.HasKey(e => e.TableId).HasName("PK_MobileCorrelation");

            entity.ToTable("EMRMobileCorrelation");

            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.AccessInfo).HasMaxLength(64);
            entity.Property(e => e.ClientId).HasMaxLength(32);
            entity.Property(e => e.Correlation).HasMaxLength(64);
            entity.Property(e => e.CurrentPtId).HasColumnName("CurrentPtID");
            entity.Property(e => e.CurrentPtInfo).HasMaxLength(128);
            entity.Property(e => e.CurrentVisitId).HasColumnName("CurrentVisitID");
            entity.Property(e => e.CurrentVisitInfo).HasMaxLength(80);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateLastAccessed).HasColumnType("datetime");
            entity.Property(e => e.EmpFullName).HasMaxLength(64);
            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.LastRequestInfo).HasMaxLength(80);
            entity.Property(e => e.ScreenSize).HasMaxLength(24);
        });

        modelBuilder.Entity<Emroption>(entity =>
        {
            entity.HasKey(e => e.OptionId)
                .HasName("aaaaaEMROptions_PK")
                .IsClustered(false);

            entity.ToTable("EMROptions");

            entity.HasIndex(e => e.OptionId, "OptionID")
                .IsUnique()
                .HasFillFactor(90);

            entity.Property(e => e.OptionId)
                .ValueGeneratedNever()
                .HasColumnName("OptionID");
            entity.Property(e => e.AaohandOutsVersion).HasColumnName("AAOHandOutsVersion");
            entity.Property(e => e.AaohandoutsLicense)
                .HasMaxLength(500)
                .HasColumnName("AAOHandoutsLicense");
            entity.Property(e => e.AlertsTono).HasMaxLength(50);
            entity.Property(e => e.AutoCopyFromPreviousPohpmh).HasColumnName("AutoCopyFromPreviousPOHPMH");
            entity.Property(e => e.ChartPrintUseHpiletterText).HasColumnName("ChartPrintUseHPILetterText");
            entity.Property(e => e.ClientId)
                .HasMaxLength(255)
                .HasColumnName("ClientID");
            entity.Property(e => e.ContactLensCatalogId).HasColumnName("ContactLensCatalogID");
            entity.Property(e => e.DaysToKeepHl7logFiles).HasColumnName("DaysToKeepHL7LogFiles");
            entity.Property(e => e.DefaultClexpires)
                .HasMaxLength(50)
                .HasColumnName("DefaultCLExpires");
            entity.Property(e => e.DefaultFaxGatewaySiteId).HasColumnName("DefaultFaxGatewaySiteID");
            entity.Property(e => e.DefaultSpecRxExpires).HasMaxLength(50);
            entity.Property(e => e.DfeDiscNormal)
                .HasMaxLength(255)
                .HasColumnName("DFE_Disc_Normal");
            entity.Property(e => e.DfeMaculaNormal)
                .HasMaxLength(255)
                .HasColumnName("DFE_Macula_Normal");
            entity.Property(e => e.DfeNflNormal)
                .HasMaxLength(255)
                .HasColumnName("DFE_NFL_Normal");
            entity.Property(e => e.DfePeriphNormal)
                .HasMaxLength(255)
                .HasColumnName("DFE_Periph_Normal");
            entity.Property(e => e.DfeRetinaNormal)
                .HasMaxLength(255)
                .HasColumnName("DFE_Retina_Normal");
            entity.Property(e => e.DfeVesselsNormal)
                .HasMaxLength(255)
                .HasColumnName("DFE_Vessels_Normal");
            entity.Property(e => e.DfeVitreousNormal)
                .HasMaxLength(255)
                .HasColumnName("DFE_Vitreous_Normal");
            entity.Property(e => e.DfedefaultExtended).HasColumnName("DFEDefaultExtended");
            entity.Property(e => e.DiagTestIdtypeUsed).HasColumnName("DiagTestIDTypeUsed");
            entity.Property(e => e.DicomserverEnable).HasColumnName("DICOMServerEnable");
            entity.Property(e => e.DoNotChangeStatusAfterSendtoPm).HasColumnName("DoNotChangeStatusAfterSendtoPM");
            entity.Property(e => e.DontEnforceUsssnformat).HasColumnName("DontEnforceUSSSNFormat");
            entity.Property(e => e.EtherFaxApikey)
                .HasMaxLength(200)
                .HasColumnName("EtherFaxAPIkey");
            entity.Property(e => e.EyeMdemrchargeMsh3)
                .HasMaxLength(100)
                .HasColumnName("EyeMDEMRChargeMSH3");
            entity.Property(e => e.EyeMdemrchargeMsh4)
                .HasMaxLength(100)
                .HasColumnName("EyeMDEMRChargeMSH4");
            entity.Property(e => e.EyeMdemrchargeMsh5)
                .HasMaxLength(100)
                .HasColumnName("EyeMDEMRChargeMSH5");
            entity.Property(e => e.EyeMdemrchargeMsh6)
                .HasMaxLength(100)
                .HasColumnName("EyeMDEMRChargeMSH6");
            entity.Property(e => e.EyeMdemrwebPortalAddress).HasColumnName("EyeMDEMRWebPortalAddress");
            entity.Property(e => e.EyeMdemrwebPortalInitialPass).HasColumnName("EyeMDEMRWebPortalInitialPass");
            entity.Property(e => e.FaxServerIp)
                .HasMaxLength(50)
                .HasColumnName("FaxServerIP");
            entity.Property(e => e.GatewayVersion)
                .HasMaxLength(25)
                .HasDefaultValue("0");
            entity.Property(e => e.Hl7opticalInterfaceEnableExport).HasColumnName("HL7OpticalInterfaceEnableExport");
            entity.Property(e => e.Hl7opticalInterfaceExportDirectory).HasColumnName("HL7OpticalInterfaceExportDirectory");
            entity.Property(e => e.Hl7opticalInterfaceExportTcpsocketIp)
                .HasMaxLength(50)
                .HasColumnName("HL7OpticalInterfaceExportTCPSocketIP");
            entity.Property(e => e.Hl7opticalInterfaceExportTcpsocketPort).HasColumnName("HL7OpticalInterfaceExportTCPSocketPort");
            entity.Property(e => e.Hl7opticalInterfaceExportType).HasColumnName("HL7OpticalInterfaceExportType");
            entity.Property(e => e.Hl7opticalInterfaceHttpaddress)
                .HasMaxLength(255)
                .HasColumnName("HL7OpticalInterfaceHTTPAddress");
            entity.Property(e => e.Hl7pminterfaceEnableExport).HasColumnName("HL7PMInterfaceEnableExport");
            entity.Property(e => e.Hl7pminterfaceEnableForwarder).HasColumnName("HL7PMInterfaceEnableForwarder");
            entity.Property(e => e.Hl7pminterfaceEnableImport).HasColumnName("HL7PMInterfaceEnableImport");
            entity.Property(e => e.Hl7pminterfaceExportDirectory).HasColumnName("HL7PMInterfaceExportDirectory");
            entity.Property(e => e.Hl7pminterfaceExportTcpsocketIp)
                .HasMaxLength(50)
                .HasColumnName("HL7PMInterfaceExportTCPSocketIP");
            entity.Property(e => e.Hl7pminterfaceExportTcpsocketPort).HasColumnName("HL7PMInterfaceExportTCPSocketPort");
            entity.Property(e => e.Hl7pminterfaceExportType).HasColumnName("HL7PMInterfaceExportType");
            entity.Property(e => e.Hl7pminterfaceImportDirectory).HasColumnName("HL7PMInterfaceImportDirectory");
            entity.Property(e => e.InfoButtonUri)
                .HasMaxLength(200)
                .HasDefaultValue("http://apps.nlm.nih.gov/medlineplus/services/mpconnect.cfm")
                .HasColumnName("InfoButtonURI");
            entity.Property(e => e.InterfaceSoftware).HasComment("0 = None, 1 = Versasuite");
            entity.Property(e => e.LastHl7controlNumber).HasColumnName("LastHL7ControlNumber");
            entity.Property(e => e.LastRxControlNumber).HasDefaultValue(0);
            entity.Property(e => e.LastUpdated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MinimumPasswordLength).HasDefaultValue(4);
            entity.Property(e => e.MsfaxDefaultCoverPageName)
                .HasMaxLength(50)
                .HasColumnName("MSFaxDefaultCoverPageName");
            entity.Property(e => e.NtptimeServer)
                .HasMaxLength(100)
                .HasColumnName("NTPTimeServer");
            entity.Property(e => e.OpticalIntegrationUserName).HasMaxLength(255);
            entity.Property(e => e.OutgoingFaxCopyToLocation)
                .HasMaxLength(100)
                .HasDefaultValue("GLOBAL\\OutgoingFaxes\\");
            entity.Property(e => e.PatientEngagementInfo).HasMaxLength(1000);
            entity.Property(e => e.PmintAdscelitePath)
                .HasMaxLength(255)
                .HasColumnName("PMIntADSCElitePath");
            entity.Property(e => e.PmintAdsceliteServer)
                .HasMaxLength(255)
                .HasColumnName("PMIntADSCEliteServer");
            entity.Property(e => e.PmintAdschttpAddress).HasColumnName("PMIntADSCHttpAddress");
            entity.Property(e => e.PmintAdscinstanceName)
                .HasMaxLength(255)
                .HasColumnName("PMIntADSCInstanceName");
            entity.Property(e => e.PmintMdsDatabaseName)
                .HasMaxLength(255)
                .HasColumnName("PMIntMDsDatabaseName");
            entity.Property(e => e.PmintMdsHttpAddress).HasColumnName("PMIntMDsHttpAddress");
            entity.Property(e => e.PmintMedinformatixCompany)
                .HasMaxLength(255)
                .HasColumnName("PMIntMedinformatixCompany");
            entity.Property(e => e.PmintMedinformatixPath)
                .HasMaxLength(255)
                .HasColumnName("PMIntMedinformatixPath");
            entity.Property(e => e.PmintOpenPmhttpAddress)
                .HasMaxLength(255)
                .HasColumnName("PMIntOpenPMHttpAddress");
            entity.Property(e => e.RequireDobcheckinPt).HasColumnName("RequireDOBCheckinPT");
            entity.Property(e => e.RequireDobcreatePt).HasColumnName("RequireDOBCreatePT");
            entity.Property(e => e.RequireIdcheckinPt).HasColumnName("RequireIDCheckinPT");
            entity.Property(e => e.RequireIdcreatePt).HasColumnName("RequireIDCreatePT");
            entity.Property(e => e.RxSoapurl).HasColumnName("RxSOAPUrl");
            entity.Property(e => e.ScanningInterfaceType).HasDefaultValue(1);
            entity.Property(e => e.SleAcNormal)
                .HasMaxLength(255)
                .HasColumnName("SLE_AC_Normal");
            entity.Property(e => e.SleAdnexaNormal)
                .HasMaxLength(255)
                .HasColumnName("SLE_Adnexa_Normal");
            entity.Property(e => e.SleConjNormal)
                .HasMaxLength(255)
                .HasColumnName("SLE_Conj_Normal");
            entity.Property(e => e.SleIrisNormal)
                .HasMaxLength(255)
                .HasColumnName("SLE_Iris_Normal");
            entity.Property(e => e.SleKNormal)
                .HasMaxLength(255)
                .HasColumnName("SLE_K_Normal");
            entity.Property(e => e.SleLashesNormal)
                .HasMaxLength(255)
                .HasColumnName("SLE_Lashes_Normal");
            entity.Property(e => e.SleLensNormal)
                .HasMaxLength(255)
                .HasColumnName("SLE_Lens_Normal");
            entity.Property(e => e.SleLidsNormal)
                .HasMaxLength(255)
                .HasColumnName("SLE_Lids_Normal");
            entity.Property(e => e.SleScleraNormal)
                .HasMaxLength(255)
                .HasColumnName("SLE_Sclera_Normal");
            entity.Property(e => e.SpectacleRxPrintShowPd)
                .HasDefaultValue((short)-1)
                .HasColumnName("SpectacleRxPrintShowPD");
            entity.Property(e => e.SpectacleRxPrintShowVa).HasColumnName("SpectacleRxPrintShowVA");
        });

        modelBuilder.Entity<Emrpatient>(entity =>
        {
            entity.HasKey(e => e.PtId);

            entity.ToTable("EMRPatients");

            entity.HasIndex(e => e.ClientSoftwarePtId, "ClientSoftwarePTID").HasFillFactor(90);

            entity.HasIndex(e => e.ClientSoftwarePtIdassignAuth, "ClientSoftwarePtIDAssignAuth").HasFillFactor(90);

            entity.HasIndex(e => e.ClientSoftwarePtIdassignAuthIdtype, "ClientSoftwarePtIDAssignAuthIDType").HasFillFactor(90);

            entity.HasIndex(e => e.CopyFromDefaultPatient, "IX_Patients_CopyFromDefaultPatient").HasFillFactor(90);

            entity.HasIndex(e => e.PtId, "PTID")
                .IsUnique()
                .HasFillFactor(90);

            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.ClientSoftwarePtId)
                .HasMaxLength(50)
                .HasDefaultValueSql("((0))")
                .HasColumnName("ClientSoftwarePtID");
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
            entity.Property(e => e.PatientChartNumber).HasMaxLength(50);
            entity.Property(e => e.PatientCity).HasMaxLength(50);
            entity.Property(e => e.PatientCreated).HasColumnType("datetime");
            entity.Property(e => e.PatientDefaultEyeCareProviderId).HasColumnName("PatientDefaultEyeCareProviderID");
            entity.Property(e => e.PatientDefaultPriProviderId).HasColumnName("PatientDefaultPriProviderID");
            entity.Property(e => e.PatientDefaultRefProviderId).HasColumnName("PatientDefaultRefProviderID");
            entity.Property(e => e.PatientDefaultRefProviderLastUpdated).HasColumnType("datetime");
            entity.Property(e => e.PatientDob)
                .HasColumnType("datetime")
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
            entity.Property(e => e.PatientNameFirst).HasMaxLength(50);
            entity.Property(e => e.PatientNameLast).HasMaxLength(50);
            entity.Property(e => e.PatientNameMiddle).HasMaxLength(50);
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
            entity.Property(e => e.PtDeceasedDate).HasColumnType("datetime");
            entity.Property(e => e.SexualOrientationConceptCode).HasMaxLength(50);
            entity.Property(e => e.SexualOrientationId).HasColumnName("SexualOrientationID");
            entity.Property(e => e.SexualOrientationOtherDescription).HasMaxLength(50);
            entity.Property(e => e.UpsizeTs)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("upsize_ts");
        });

        modelBuilder.Entity<EmrpatientDevice>(entity =>
        {
            entity.HasKey(e => e.PtDeviceId);

            entity.ToTable("EMRPatientDevices");

            entity.Property(e => e.PtDeviceId).HasColumnName("PtDeviceID");
            entity.Property(e => e.BrandName).HasMaxLength(200);
            entity.Property(e => e.DeviceDescription).HasMaxLength(2000);
            entity.Property(e => e.DeviceIdentifier).HasMaxLength(50);
            entity.Property(e => e.DeviceName).HasMaxLength(200);
            entity.Property(e => e.DonationIdentifier)
                .HasMaxLength(50)
                .HasComment("Also known as 'distinct identifier'");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.ExpirationDate).HasColumnType("datetime");
            entity.Property(e => e.Gmdnptdefinition).HasColumnName("GMDNPTDefinition");
            entity.Property(e => e.Gmdnptname)
                .HasMaxLength(200)
                .HasColumnName("GMDNPTName");
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.IssuingAgency).HasMaxLength(200);
            entity.Property(e => e.LabeledContainsNrl).HasColumnName("LabeledContainsNRL");
            entity.Property(e => e.LotNumber).HasMaxLength(50);
            entity.Property(e => e.ManufactureDate).HasColumnType("datetime");
            entity.Property(e => e.Manufacturer).HasMaxLength(200);
            entity.Property(e => e.MrisafetyInformation)
                .HasMaxLength(1000)
                .HasColumnName("MRISafetyInformation");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.RecordedDate).HasColumnType("datetime");
            entity.Property(e => e.SerialNumber).HasMaxLength(50);
            entity.Property(e => e.Snomedctcode).HasColumnName("SNOMEDCTCode");
            entity.Property(e => e.Snomedctdescription).HasColumnName("SNOMEDCTDescription");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Status).HasComment("0 = Unknown, 1 = Active, 2 = Inactive, 3 = Entered In Error");
            entity.Property(e => e.UniversalIdentifier).HasMaxLength(200);
            entity.Property(e => e.VersionModelNumber).HasMaxLength(50);
        });

        modelBuilder.Entity<EmrpatientFlow>(entity =>
        {
            entity.HasKey(e => e.PatientFlowId)
                .HasName("aaaaaEMRPatientFlow_PK")
                .IsClustered(false);

            entity.ToTable("EMRPatientFlow");

            entity.HasIndex(e => e.ProviderEmpId, "DoctorEmpID").HasFillFactor(90);

            entity.HasIndex(e => e.FlowStatusEmpId, "FlowStatusEmpID").HasFillFactor(90);

            entity.HasIndex(e => e.FlowStatusId, "FlowStatusID").HasFillFactor(90);

            entity.HasIndex(e => e.ApptId, "IX_ApptID").HasFillFactor(90);

            entity.HasIndex(e => new { e.PtId, e.FlowDate }, "IX_EMRPatientFlow_PtID_FlowDate").HasFillFactor(90);

            entity.HasIndex(e => e.FlowDate, "IX_FlowDate").HasFillFactor(90);

            entity.HasIndex(e => new { e.PtId, e.PatientFlowId, e.FlowStatusTimeStamp, e.FlowStatusId, e.SiteId, e.ProviderEmpId }, "IX_PatientFlow").HasFillFactor(90);

            entity.HasIndex(e => e.PatientFlowId, "PatienttFlowID").HasFillFactor(90);

            entity.HasIndex(e => e.PtId, "PtID").HasFillFactor(90);

            entity.HasIndex(e => e.SiteId, "SiteID").HasFillFactor(90);

            entity.Property(e => e.PatientFlowId).HasColumnName("PatientFlowID");
            entity.Property(e => e.ApptId).HasColumnName("ApptID");
            entity.Property(e => e.ApptTime).HasColumnType("datetime");
            entity.Property(e => e.ClientSoftwareApptId)
                .HasMaxLength(50)
                .HasColumnName("ClientSoftwareApptID");
            entity.Property(e => e.ClientSoftwarePtId)
                .HasMaxLength(50)
                .HasColumnName("ClientSoftwarePtID");
            entity.Property(e => e.FlowDate).HasColumnType("datetime");
            entity.Property(e => e.FlowStatusEmpId).HasColumnName("FlowStatusEmpID");
            entity.Property(e => e.FlowStatusId).HasColumnName("FlowStatusID");
            entity.Property(e => e.FlowStatusTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.Hl7pid18)
                .HasMaxLength(50)
                .HasColumnName("HL7PID18");
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.ProviderEmpId).HasColumnName("ProviderEmpID");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.RoomId).HasColumnName("RoomID");
            entity.Property(e => e.SiteId).HasColumnName("SiteID");
            entity.Property(e => e.UpsizeTs)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("upsize_ts");
        });

        modelBuilder.Entity<EmrpatientFlowHistory>(entity =>
        {
            entity.HasKey(e => e.TableId)
                .HasName("aaaaaEMRPatientFlowHistory_PK")
                .IsClustered(false);

            entity.ToTable("EMRPatientFlowHistory");

            entity.HasIndex(e => e.FlowStatusEmpId, "FlowStatusEmpID").HasFillFactor(90);

            entity.HasIndex(e => e.FlowStatusId, "FlowStatusID").HasFillFactor(90);

            entity.HasIndex(e => new { e.PtId, e.PatientFlowId, e.FlowStatusTimeStamp, e.FlowStatusId }, "IX_EMRPatienFlowHistory").HasFillFactor(90);

            entity.HasIndex(e => e.PatientFlowId, "PatienttFlowID").HasFillFactor(90);

            entity.HasIndex(e => e.PtId, "PtID").HasFillFactor(90);

            entity.HasIndex(e => e.TableId, "TableID")
                .IsUnique()
                .HasFillFactor(90);

            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.FlowStatusEmpId).HasColumnName("FlowStatusEmpID");
            entity.Property(e => e.FlowStatusId).HasColumnName("FlowStatusID");
            entity.Property(e => e.FlowStatusTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.PatientFlowId).HasColumnName("PatientFlowID");
            entity.Property(e => e.PtId).HasColumnName("PtID");
        });

        modelBuilder.Entity<EmrpatientFlowStatusType>(entity =>
        {
            entity.HasKey(e => e.TableId)
                .HasName("aaaaaEMRPatientFlowStatusTypes_PK")
                .IsClustered(false);

            entity.ToTable("EMRPatientFlowStatusTypes");

            entity.HasIndex(e => e.PatientFlowStatusTypeId, "PatienttFlowID").HasFillFactor(90);

            entity.HasIndex(e => e.Name, "PtID").HasFillFactor(90);

            entity.HasIndex(e => e.TableId, "TableID")
                .IsUnique()
                .HasFillFactor(90);

            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.EmrroomType).HasColumnName("EMRRoomType");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.PatientFlowStatusTypeId).HasColumnName("PatientFlowStatusTypeID");
        });

        modelBuilder.Entity<EmrpatientNameAlternate>(entity =>
        {
            entity.HasKey(e => e.PatientNameAlternateId);

            entity.ToTable("EMRPatientNameAlternates");

            entity.Property(e => e.PatientNameAlternateId).HasColumnName("PatientNameAlternateID");
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.PatientNameFirst).HasMaxLength(50);
            entity.Property(e => e.PatientNameLast).HasMaxLength(50);
            entity.Property(e => e.PatientNameMiddle).HasMaxLength(50);
            entity.Property(e => e.PatientNameSuffix).HasMaxLength(50);
            entity.Property(e => e.PatientNameTypeCode).HasMaxLength(20);
            entity.Property(e => e.PtId).HasColumnName("PtID");
        });

        modelBuilder.Entity<EmrpatientObservation>(entity =>
        {
            entity.HasKey(e => e.PtObservationId);

            entity.ToTable("EMRPatientObservations");

            entity.Property(e => e.PtObservationId).HasColumnName("PtObservationID");
            entity.Property(e => e.CodeSystemId).HasColumnName("CodeSystemID");
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.ObservationCode).HasMaxLength(50);
            entity.Property(e => e.ObservationDate).HasColumnType("datetime");
            entity.Property(e => e.ObservationDateEnd).HasColumnType("datetime");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.RecordedDate).HasColumnType("datetime");
            entity.Property(e => e.RelatedRecordId)
                .HasMaxLength(50)
                .HasColumnName("RelatedRecordID");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<EmrpatientObservationValue>(entity =>
        {
            entity.HasKey(e => e.PtObservationValueId);

            entity.ToTable("EMRPatientObservationValues");

            entity.Property(e => e.PtObservationValueId).HasColumnName("PtObservationValueID");
            entity.Property(e => e.CodeSystemId).HasColumnName("CodeSystemID");
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.ParentId).HasColumnName("ParentID");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.PtObservationId).HasColumnName("PtObservationID");
            entity.Property(e => e.ValueCode).HasMaxLength(50);
            entity.Property(e => e.ValueType).HasMaxLength(10);
        });

        modelBuilder.Entity<EmrpatientObservationValueStatus>(entity =>
        {
            entity.HasKey(e => e.PtObservationValueStatusId);

            entity.ToTable("EMRPatientObservationValueStatuses");

            entity.Property(e => e.PtObservationValueStatusId).HasColumnName("PtObservationValueStatusID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CodeSystemId).HasColumnName("CodeSystemID");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.PtObservationValueId).HasColumnName("PtObservationValueID");
            entity.Property(e => e.RecordedDate).HasColumnType("datetime");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<EmrpatientScratchpad>(entity =>
        {
            entity.HasKey(e => e.ScratchNoteId).HasName("PK_EMRVPatientScratchpad");

            entity.ToTable("EMRPatientScratchpad");

            entity.Property(e => e.ScratchNoteId).HasColumnName("ScratchNoteID");
            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.ScratchNote).HasMaxLength(500);
            entity.Property(e => e.ScratchNoteTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<EmrpatientSearch>(entity =>
        {
            entity.HasKey(e => e.PtSearchId);

            entity.ToTable("EMRPatientSearches");

            entity.Property(e => e.PtSearchId).HasColumnName("PtSearchID");
            entity.Property(e => e.SearchName).HasMaxLength(100);
        });

        modelBuilder.Entity<EmrpatientSearchSchedule>(entity =>
        {
            entity.HasKey(e => e.PtSearchScheduleId);

            entity.ToTable("EMRPatientSearchSchedules");

            entity.HasIndex(e => e.ExportDeviceId, "IX_PatientSearchSchedules_ExportDeviceID").HasFillFactor(90);

            entity.HasIndex(e => e.PtSearchId, "IX_PatientSearchSchedules_PtSearchID").HasFillFactor(90);

            entity.HasIndex(e => e.ScheduleId, "IX_PatientSearchSchedules_ScheduleID").HasFillFactor(90);

            entity.Property(e => e.PtSearchScheduleId).HasColumnName("PtSearchScheduleID");
            entity.Property(e => e.ExportDeviceId).HasColumnName("ExportDeviceID");
            entity.Property(e => e.LastRun).HasColumnType("datetime");
            entity.Property(e => e.PtSearchId).HasColumnName("PtSearchID");
            entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");
        });

        modelBuilder.Entity<EmrptNote>(entity =>
        {
            entity.HasKey(e => e.PtNotesId).HasName("PK__EMRPtNotes__40CF895A");

            entity.ToTable("EMRPtNotes");

            entity.HasIndex(e => e.PtId, "IX_PtNotes_PtID").HasFillFactor(90);

            entity.Property(e => e.PtNotesId).HasColumnName("PtNotesID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.PtId).HasColumnName("PtID");
        });

        modelBuilder.Entity<Emrrecall>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_EMRRecall");

            entity.ToTable("EMRRecalls");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ClientSoftwarePtId)
                .HasMaxLength(50)
                .HasColumnName("ClientSoftwarePtID");
            entity.Property(e => e.Ddpstatus)
                .HasMaxLength(50)
                .HasColumnName("DDPStatus");
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.ProviderEmpId).HasColumnName("ProviderEmpID");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.RecallDateTime).HasColumnType("datetime");
            entity.Property(e => e.RecallType).HasMaxLength(50);
            entity.Property(e => e.RefProviderEmpId).HasColumnName("RefProviderEmpID");
            entity.Property(e => e.ResourceId)
                .HasMaxLength(50)
                .HasColumnName("ResourceID");
        });

        modelBuilder.Entity<EmrrefProvider>(entity =>
        {
            entity.HasKey(e => e.RefProviderId);

            entity.ToTable("EMRRefProvider");

            entity.Property(e => e.RefProviderId).HasColumnName("RefProviderID");
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.RefDirectMessageAddress).HasMaxLength(100);
            entity.Property(e => e.RefProviderCellPhone).HasMaxLength(50);
            entity.Property(e => e.RefProviderCity).HasMaxLength(50);
            entity.Property(e => e.RefProviderClientSoftwareId)
                .HasMaxLength(50)
                .HasColumnName("RefProviderClientSoftwareID");
            entity.Property(e => e.RefProviderEmail)
                .HasMaxLength(50)
                .HasColumnName("RefProviderEMail");
            entity.Property(e => e.RefProviderFax).HasMaxLength(50);
            entity.Property(e => e.RefProviderIsActive).HasDefaultValue((short)-1);
            entity.Property(e => e.RefProviderMainPhone).HasMaxLength(50);
            entity.Property(e => e.RefProviderNameFirst).HasMaxLength(255);
            entity.Property(e => e.RefProviderNameFull).HasMaxLength(50);
            entity.Property(e => e.RefProviderNameLast).HasMaxLength(255);
            entity.Property(e => e.RefProviderNpi)
                .HasMaxLength(100)
                .HasColumnName("RefProviderNPI");
            entity.Property(e => e.RefProviderOrganizationName).HasMaxLength(100);
            entity.Property(e => e.RefProviderSalutation).HasMaxLength(255);
            entity.Property(e => e.RefProviderState).HasMaxLength(50);
            entity.Property(e => e.RefProviderZip).HasMaxLength(50);
        });

        modelBuilder.Entity<Emrroom>(entity =>
        {
            entity.HasKey(e => e.EmrroomId)
                .HasName("aaaaaEMRRooms_PK")
                .IsClustered(false);

            entity.ToTable("EMRRooms");

            entity.HasIndex(e => e.EmrroomLocationId, "EMRRoomLocationID").HasFillFactor(90);

            entity.HasIndex(e => e.EmrroomId, "RoomID").HasFillFactor(90);

            entity.Property(e => e.EmrroomId).HasColumnName("EMRRoomID");
            entity.Property(e => e.EmrroomDescription)
                .HasMaxLength(50)
                .HasColumnName("EMRRoomDescription");
            entity.Property(e => e.EmrroomLocationId).HasColumnName("EMRRoomLocationID");
            entity.Property(e => e.EmrroomType)
                .HasDefaultValue(0)
                .HasColumnName("EMRRoomType");
        });

        modelBuilder.Entity<EmrroomType>(entity =>
        {
            entity.HasKey(e => e.TableId)
                .HasName("aaaaaEMRRoomTypes_PK")
                .IsClustered(false);

            entity.ToTable("EMRRoomTypes");

            entity.HasIndex(e => e.EmrroomTypeId, "EMRRoomTypeID")
                .IsUnique()
                .HasFillFactor(90);

            entity.HasIndex(e => e.TableId, "TableID").HasFillFactor(90);

            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.EmrroomTypeId).HasColumnName("EMRRoomTypeID");
            entity.Property(e => e.RoomTypeDescription).HasMaxLength(50);
        });

        modelBuilder.Entity<Emrrosdefault>(entity =>
        {
            entity.HasKey(e => e.RosdefaultId)
                .HasName("aaaaaEMRROSDefault_PK")
                .IsClustered(false);

            entity.ToTable("EMRROSDefault");

            entity.HasIndex(e => e.RosdefaultId, "ROSDefaultID")
                .IsUnique()
                .HasFillFactor(90);

            entity.Property(e => e.RosdefaultId).HasColumnName("ROSDefaultID");
            entity.Property(e => e.RosbloodCustomDesc1)
                .HasMaxLength(50)
                .HasColumnName("ROSBloodCustomDesc1");
            entity.Property(e => e.RosbloodCustomDesc2)
                .HasMaxLength(50)
                .HasColumnName("ROSBloodCustomDesc2");
            entity.Property(e => e.RoscardioCustomDesc1)
                .HasMaxLength(50)
                .HasColumnName("ROSCardioCustomDesc1");
            entity.Property(e => e.RoscardioCustomDesc2)
                .HasMaxLength(50)
                .HasColumnName("ROSCardioCustomDesc2");
            entity.Property(e => e.RosconsCustomDesc1)
                .HasMaxLength(50)
                .HasColumnName("ROSConsCustomDesc1");
            entity.Property(e => e.RosconsCustomDesc2)
                .HasMaxLength(50)
                .HasColumnName("ROSConsCustomDesc2");
            entity.Property(e => e.RosendoCustomDesc1)
                .HasMaxLength(50)
                .HasColumnName("ROSEndoCustomDesc1");
            entity.Property(e => e.RosendoCustomDesc2)
                .HasMaxLength(50)
                .HasColumnName("ROSEndoCustomDesc2");
            entity.Property(e => e.RosentcustomDesc1)
                .HasMaxLength(50)
                .HasColumnName("ROSENTCustomDesc1");
            entity.Property(e => e.RosentcustomDesc2)
                .HasMaxLength(50)
                .HasColumnName("ROSENTCustomDesc2");
            entity.Property(e => e.RoseyeCustomDesc1)
                .HasMaxLength(50)
                .HasColumnName("ROSEyeCustomDesc1");
            entity.Property(e => e.RoseyeCustomDesc2)
                .HasMaxLength(50)
                .HasColumnName("ROSEyeCustomDesc2");
            entity.Property(e => e.RoseyeCustomDesc3)
                .HasMaxLength(50)
                .HasColumnName("ROSEyeCustomDesc3");
            entity.Property(e => e.RoseyeCustomDesc4)
                .HasMaxLength(50)
                .HasColumnName("ROSEyeCustomDesc4");
            entity.Property(e => e.RosgasCustomDesc1)
                .HasMaxLength(50)
                .HasColumnName("ROSGasCustomDesc1");
            entity.Property(e => e.RosgasCustomDesc2)
                .HasMaxLength(50)
                .HasColumnName("ROSGasCustomDesc2");
            entity.Property(e => e.RosimmuCustomDesc1)
                .HasMaxLength(50)
                .HasColumnName("ROSImmuCustomDesc1");
            entity.Property(e => e.RosimmuCustomDesc2)
                .HasMaxLength(50)
                .HasColumnName("ROSImmuCustomDesc2");
            entity.Property(e => e.RosmusSkeCustomDesc1)
                .HasMaxLength(50)
                .HasColumnName("ROSMusSkeCustomDesc1");
            entity.Property(e => e.RosmusSkeCustomDesc2)
                .HasMaxLength(50)
                .HasColumnName("ROSMusSkeCustomDesc2");
            entity.Property(e => e.RosneuroCustomDesc1)
                .HasMaxLength(50)
                .HasColumnName("ROSNeuroCustomDesc1");
            entity.Property(e => e.RosneuroCustomDesc2)
                .HasMaxLength(50)
                .HasColumnName("ROSNeuroCustomDesc2");
            entity.Property(e => e.RospsycCustomDesc1)
                .HasMaxLength(50)
                .HasColumnName("ROSPsycCustomDesc1");
            entity.Property(e => e.RospsycCustomDesc2)
                .HasMaxLength(50)
                .HasColumnName("ROSPsycCustomDesc2");
            entity.Property(e => e.RosrespCustomDesc1)
                .HasMaxLength(50)
                .HasColumnName("ROSRespCustomDesc1");
            entity.Property(e => e.RosrespCustomDesc2)
                .HasMaxLength(50)
                .HasColumnName("ROSRespCustomDesc2");
            entity.Property(e => e.RosskinCustomDesc1)
                .HasMaxLength(50)
                .HasColumnName("ROSSkinCustomDesc1");
            entity.Property(e => e.RosskinCustomDesc2)
                .HasMaxLength(50)
                .HasColumnName("ROSSkinCustomDesc2");
            entity.Property(e => e.RosurinaryCustomDesc1)
                .HasMaxLength(50)
                .HasColumnName("ROSUrinaryCustomDesc1");
            entity.Property(e => e.RosurinaryCustomDesc2)
                .HasMaxLength(50)
                .HasColumnName("ROSUrinaryCustomDesc2");
        });

        modelBuilder.Entity<EmrrxUsageDefault>(entity =>
        {
            entity.HasKey(e => e.RxusageId).HasName("PK__EMRRxUsageDefaul__1B3EDD4F");

            entity.ToTable("EMRRxUsageDefaults");

            entity.Property(e => e.RxusageId).HasColumnName("RXUsageID");
            entity.Property(e => e.DefaultDisp).HasMaxLength(255);
            entity.Property(e => e.DefaultDispUnitType).HasMaxLength(100);
            entity.Property(e => e.DefaultRefill).HasMaxLength(255);
            entity.Property(e => e.DefaultSig).HasMaxLength(255);
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
        });

        modelBuilder.Entity<EmrscannerOption>(entity =>
        {
            entity.HasKey(e => e.ScannerOptionsId)
                .HasName("aaaaaEMRScannerOptions_PK")
                .IsClustered(false);

            entity.ToTable("EMRScannerOptions");

            entity.HasIndex(e => e.ScannerOptionsId, "ScannerOptionID").HasFillFactor(90);

            entity.Property(e => e.ScannerOptionsId).HasColumnName("ScannerOptionsID");
            entity.Property(e => e.AllowMultiplePages).HasDefaultValue((short)-1);
            entity.Property(e => e.Dpi)
                .HasDefaultValue(75)
                .HasColumnName("DPI");
            entity.Property(e => e.DuplexSetting)
                .HasDefaultValue(0)
                .HasComment("0 = Simplex (no duplex), 1 = Duplex");
            entity.Property(e => e.FileType)
                .HasDefaultValue(2)
                .HasComment("1 = Tiff, 2 = PDF");
            entity.Property(e => e.HideTwainInterface)
                .HasDefaultValue(0)
                .HasComment("1 =Try to Hide, 0 = Do not Hide");
            entity.Property(e => e.IsWiadevice).HasColumnName("IsWIADevice");
            entity.Property(e => e.ModalityId).HasColumnName("ModalityID");
            entity.Property(e => e.PageRejectionCoverage)
                .HasDefaultValue(0.001)
                .HasComment(".001 Defualt");
            entity.Property(e => e.PaperSize)
                .HasDefaultValue(3)
                .HasComment("3=8.5x11, 4 = 8.5x14");
            entity.Property(e => e.ScanLeft).HasDefaultValue(0.0);
            entity.Property(e => e.ScanLength).HasDefaultValue(11.0);
            entity.Property(e => e.ScanTop).HasDefaultValue(0.0);
            entity.Property(e => e.ScanType)
                .HasDefaultValue(1)
                .HasComment("0=B&W, 1=Grayscale, 2=RGB Color");
            entity.Property(e => e.ScanWidth).HasDefaultValue(8.5);
            entity.Property(e => e.TryAdffirst)
                .HasDefaultValue((short)-1)
                .HasColumnName("TryADFFirst");
            entity.Property(e => e.UpsizeTs)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("upsize_ts");
            entity.Property(e => e.UsageDescription).HasMaxLength(50);
        });

        modelBuilder.Entity<Emrschedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId);

            entity.ToTable("EMRSchedules");

            entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.ScheduleTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<EmrscheduledTask>(entity =>
        {
            entity.ToTable("EMRScheduledTask");

            entity.Property(e => e.EmrscheduledTaskId).HasColumnName("EMRScheduledTaskID");
            entity.Property(e => e.LastAttemptedExecution).HasColumnType("datetime");
            entity.Property(e => e.MaintenanceTaskId).HasColumnName("MaintenanceTaskID");
            entity.Property(e => e.OmsscheduledTaskId).HasColumnName("OMSScheduledTaskID");
            entity.Property(e => e.ResultsReportedAt).HasColumnType("datetime");
            entity.Property(e => e.ScheduledExecution).HasColumnType("datetime");
            entity.Property(e => e.ScheduledTaskDescription).HasMaxLength(500);
            entity.Property(e => e.ScheduledTaskName).HasMaxLength(200);
            entity.Property(e => e.ScheduledTaskResultTypeId).HasColumnName("ScheduledTaskResultTypeID");
            entity.Property(e => e.ScheduledTaskTypeId).HasColumnName("ScheduledTaskTypeID");
        });

        modelBuilder.Entity<EmrsecurityGroup>(entity =>
        {
            entity.HasKey(e => e.SecurityGroupId);

            entity.ToTable("EMRSecurityGroups");

            entity.Property(e => e.SecurityGroupId).HasColumnName("SecurityGroupID");
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.IsActive).HasDefaultValue((short)-1);
            entity.Property(e => e.SecurityGroupName).HasMaxLength(50);
        });

        modelBuilder.Entity<Emrsite>(entity =>
        {
            entity.HasKey(e => e.SiteId)
                .HasName("aaaaaEMRSites_PK")
                .IsClustered(false);

            entity.ToTable("EMRSites");

            entity.HasIndex(e => e.SiteId, "SiteID")
                .IsUnique()
                .HasFillFactor(90);

            entity.Property(e => e.SiteId).HasColumnName("SiteID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Address2).HasMaxLength(255);
            entity.Property(e => e.City).HasMaxLength(255);
            entity.Property(e => e.ClientSoftwareSiteId)
                .HasMaxLength(255)
                .HasColumnName("ClientSoftwareSiteID");
            entity.Property(e => e.EdgeServiceAuthKey).HasMaxLength(50);
            entity.Property(e => e.EdgeServiceComputerName).HasMaxLength(50);
            entity.Property(e => e.EdgeServiceIpaddressV4)
                .HasMaxLength(50)
                .HasColumnName("EdgeServiceIPAddressV4");
            entity.Property(e => e.EtherFaxApikeyOverride)
                .HasMaxLength(200)
                .HasColumnName("EtherFaxAPIKeyOverride");
            entity.Property(e => e.Fax).HasMaxLength(50);
            entity.Property(e => e.FaxServerOverride).HasMaxLength(100);
            entity.Property(e => e.GroupNpi)
                .HasMaxLength(50)
                .HasColumnName("GroupNPI");
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.LogoImage).HasColumnType("image");
            entity.Property(e => e.LogoImageSize).HasDefaultValue(0);
            entity.Property(e => e.MainContactFirstName).HasMaxLength(50);
            entity.Property(e => e.MainContactLastName).HasMaxLength(50);
            entity.Property(e => e.OpticalIntegrationPracticeId)
                .HasMaxLength(100)
                .HasColumnName("OpticalIntegrationPracticeID");
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.SiteBusinessName).HasMaxLength(255);
            entity.Property(e => e.SiteIsActive).HasDefaultValue((short)-1);
            entity.Property(e => e.SiteName).HasMaxLength(255);
            entity.Property(e => e.SiteRxPaper).HasMaxLength(255);
            entity.Property(e => e.SiteType).HasComment("1=Office, 2=Surgery Center, 3=Hospital");
            entity.Property(e => e.State).HasMaxLength(255);
            entity.Property(e => e.Tin)
                .HasMaxLength(20)
                .HasColumnName("TIN");
            entity.Property(e => e.Zip).HasMaxLength(50);
        });

        modelBuilder.Entity<EmrsmartApp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("EMRSmartApps");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(540)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.Path).HasMaxLength(500);
            entity.Property(e => e.SmartAppId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Emrsnomedconcept>(entity =>
        {
            entity.HasKey(e => e.TableId);

            entity.ToTable("EMRSNOMEDConcepts");

            entity.HasIndex(e => e.Ctv3id, "CTV3ID").HasFillFactor(90);

            entity.HasIndex(e => e.ConceptId, "ConceptID").HasFillFactor(90);

            entity.HasIndex(e => e.ConceptStatus, "ConceptStatus").HasFillFactor(90);

            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.ConceptId)
                .HasMaxLength(18)
                .HasColumnName("ConceptID");
            entity.Property(e => e.Ctv3id)
                .HasMaxLength(8)
                .HasColumnName("CTV3ID");
            entity.Property(e => e.FullySpecifiedName).HasMaxLength(255);
            entity.Property(e => e.Snomedid)
                .HasMaxLength(10)
                .HasColumnName("SNOMEDID");
        });

        modelBuilder.Entity<Emrsnomeddescription>(entity =>
        {
            entity.HasKey(e => e.TableId);

            entity.ToTable("EMRSNOMEDDescriptions");

            entity.HasIndex(e => e.ConceptId, "ConceptID").HasFillFactor(90);

            entity.HasIndex(e => e.Term, "Term").HasFillFactor(90);

            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.ConceptId)
                .HasMaxLength(18)
                .HasColumnName("ConceptID");
            entity.Property(e => e.DescriptionId)
                .HasMaxLength(18)
                .HasColumnName("DescriptionID");
            entity.Property(e => e.LanguageCode).HasMaxLength(10);
            entity.Property(e => e.Term).HasMaxLength(255);
        });

        modelBuilder.Entity<Emrsnomedrelationship>(entity =>
        {
            entity.HasKey(e => e.TableId);

            entity.ToTable("EMRSNOMEDRelationships");

            entity.HasIndex(e => e.ConceptId1, "ConceptID1").HasFillFactor(90);

            entity.HasIndex(e => e.ConceptId2, "ConceptID2").HasFillFactor(90);

            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.ConceptId1)
                .HasMaxLength(18)
                .HasColumnName("ConceptID1");
            entity.Property(e => e.ConceptId2)
                .HasMaxLength(18)
                .HasColumnName("ConceptID2");
            entity.Property(e => e.RelationshipId)
                .HasMaxLength(18)
                .HasColumnName("RelationshipID");
            entity.Property(e => e.RelationshipType).HasMaxLength(18);
        });

        modelBuilder.Entity<EmrsnomedtoIcd10>(entity =>
        {
            entity.HasKey(e => e.TableId);

            entity.ToTable("EMRSNOMEDtoICD10");

            entity.HasIndex(e => e.ReferencedComponentId, "referencedComponentId").HasFillFactor(90);

            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.MapAdvice)
                .HasMaxLength(255)
                .HasColumnName("mapAdvice");
            entity.Property(e => e.MapGroup).HasColumnName("mapGroup");
            entity.Property(e => e.MapPriority).HasColumnName("mapPriority");
            entity.Property(e => e.MapTarget).HasMaxLength(18);
            entity.Property(e => e.ReferencedComponentId)
                .HasMaxLength(18)
                .HasColumnName("referencedComponentId");
        });

        modelBuilder.Entity<EmrsnomedtoIcd9>(entity =>
        {
            entity.HasKey(e => e.TableId);

            entity.ToTable("EMRSNOMEDtoICD9");

            entity.HasIndex(e => e.MapConceptId, "MapConceptID").HasFillFactor(90);

            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.MapAdvice).HasMaxLength(5);
            entity.Property(e => e.MapConceptId)
                .HasMaxLength(18)
                .HasColumnName("MapConceptID");
            entity.Property(e => e.MapRule).HasMaxLength(5);
            entity.Property(e => e.MapSetId)
                .HasMaxLength(18)
                .HasColumnName("MapSetID");
            entity.Property(e => e.MapTargetId)
                .HasMaxLength(18)
                .HasColumnName("MapTargetID");
        });

        modelBuilder.Entity<EmrsnomedtoIcd9target>(entity =>
        {
            entity.HasKey(e => e.TableId);

            entity.ToTable("EMRSNOMEDtoICD9Targets");

            entity.HasIndex(e => new { e.TargetCodes, e.TargetId }, "TargetCodesID").HasFillFactor(90);

            entity.HasIndex(e => e.TargetId, "TargetID").HasFillFactor(90);

            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.TargetCodes).HasMaxLength(30);
            entity.Property(e => e.TargetId)
                .HasMaxLength(18)
                .HasColumnName("TargetID");
        });

        modelBuilder.Entity<EmrtempLog>(entity =>
        {
            entity.HasKey(e => e.EmrtempLogId)
                .HasName("aaaaaEMRTempLog_PK")
                .IsClustered(false);

            entity.ToTable("EMRTempLog");

            entity.Property(e => e.EmrtempLogId).HasColumnName("EMRTempLogID");
            entity.Property(e => e.Emrtemp1).HasColumnName("EMRTemp1");
            entity.Property(e => e.Emrtemp2)
                .HasMaxLength(500)
                .HasColumnName("EMRTemp2");
            entity.Property(e => e.Emrtemp3).HasColumnName("EMRTemp3");
            entity.Property(e => e.Emrtemp4).HasColumnName("EMRTemp4");
        });

        modelBuilder.Entity<EmrtreeViewControlList>(entity =>
        {
            entity.HasKey(e => e.TableId)
                .HasName("aaaaaEMRTreeViewControlList_PK")
                .IsClustered(false);

            entity.ToTable("EMRTreeViewControlList");

            entity.HasIndex(e => e.Code, "Code").HasFillFactor(90);

            entity.HasIndex(e => e.ControlId, "ControlID").HasFillFactor(90);

            entity.HasIndex(e => e.ParentId, "ParentID").HasFillFactor(90);

            entity.HasIndex(e => e.TableId, "TableID").HasFillFactor(90);

            entity.HasIndex(e => e.VisitTypeId, "VisitTypeID").HasFillFactor(90);

            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.BillMultiProcId).HasColumnName("BillMultiProcID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CodeIcd10)
                .HasMaxLength(50)
                .HasColumnName("CodeICD10");
            entity.Property(e => e.CodeId).HasColumnName("CodeID");
            entity.Property(e => e.CodeSnomed)
                .HasMaxLength(50)
                .HasColumnName("CodeSNOMED");
            entity.Property(e => e.ControlId).HasColumnName("ControlID");
            entity.Property(e => e.ExpandOnLoad)
                .HasDefaultValue(0)
                .HasComment("-1 = yes");
            entity.Property(e => e.IncludeInLetterFilter)
                .HasDefaultValue(0)
                .HasComment("-1 = yes");
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.Itlevel)
                .HasDefaultValue(1)
                .HasComment("Tree Level")
                .HasColumnName("ITLevel");
            entity.Property(e => e.ModalityId).HasColumnName("ModalityID");
            entity.Property(e => e.Modifier).HasMaxLength(50);
            entity.Property(e => e.Order).HasDefaultValue(0);
            entity.Property(e => e.OrderModalityId).HasColumnName("OrderModalityID");
            entity.Property(e => e.ParentId)
                .HasDefaultValue(0)
                .HasComment("ControlID of Parent Record")
                .HasColumnName("ParentID");
            entity.Property(e => e.PrioritizeOrder)
                .HasDefaultValue(0)
                .HasComment("-1 = yes");
            entity.Property(e => e.ProcDiagTestComponents).HasComment("True = Can Split Technical & Professional Components");
            entity.Property(e => e.ProcExamLevel).HasComment("1 = EM L1, 2 = EM L2, 3 = EM L3, 4= EM L4, 5 = EM L5, 6 = OE Intermediate, 7 = OE Comprehensive");
            entity.Property(e => e.ProcExamType).HasComment("1 = New PT, 2 = Consult, 3 = Est Pt");
            entity.Property(e => e.ProcLocationType).HasComment("1 = Not Location Specific, 2 = Unilateral - Add Location Modifiers,  4=Bilateral - Do not add Location Modifiers, 5 = Bilateral - Add Location and 52 if not both eyes.");
            entity.Property(e => e.ProcType).HasComment("1 = Visit, 2 = Diag Test, 3 = Refraction, 4 =Tonometry, 5 = Contact Lens Fitting, 6 = SLE Drawing, 7 = DFE Drawing, 8 = Pachymetry, 9 = Gonioscopy, 10 = Muscle Balance, 11 = Other");
            entity.Property(e => e.Text).HasMaxLength(255);
            entity.Property(e => e.UpsizeTs)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("upsize_ts");
            entity.Property(e => e.VisitTypeId).HasColumnName("VisitTypeID");
        });

        modelBuilder.Entity<Emrvisit>(entity =>
        {
            entity.HasKey(e => e.VisitId);

            entity.ToTable("EMRVisit");

            entity.HasIndex(e => e.ClientSoftwareApptId, "ClientSoftwareApptID").HasFillFactor(90);

            entity.HasIndex(e => e.CodeId, "CodeID").HasFillFactor(90);

            entity.HasIndex(e => new { e.PtId, e.VisitId, e.Dosdate, e.MdsignedOff }, "IX_EMRVisit_VisitID_MDSignedOff").HasFillFactor(90);

            entity.HasIndex(e => e.ExcludeVisit, "IX_ExcludeVisit").HasFillFactor(90);

            entity.HasIndex(e => e.InitialSignedOffEmpId, "IX_InitialSignedOffEmpID").HasFillFactor(90);

            entity.HasIndex(e => e.VisitEyeCareProviderId, "IX_VisitEyeCareProviderID").HasFillFactor(90);

            entity.HasIndex(e => e.VisitPriCareProviderId, "IX_VisitPriCareProviderID").HasFillFactor(90);

            entity.HasIndex(e => e.VisitRefProviderId, "IX_VisitRefProviderID").HasFillFactor(90);

            entity.HasIndex(e => e.LinkedProcedureVisitId, "LinkedProcedureVisitID").HasFillFactor(90);

            entity.HasIndex(e => e.LocationId, "LocationID").HasFillFactor(90);

            entity.HasIndex(e => e.MdsignedOffEmpId, "MDReviewedEmpID").HasFillFactor(90);

            entity.HasIndex(e => e.PtId, "PTID").HasFillFactor(90);

            entity.HasIndex(e => e.ProviderEmpId, "ProviderEmpID").HasFillFactor(90);

            entity.HasIndex(e => e.VisitId, "VisitID")
                .IsUnique()
                .HasFillFactor(90);

            entity.HasIndex(e => e.VisitClassId, "VisitTypeID").HasFillFactor(90);

            entity.HasIndex(e => e.VisitTypeId, "VisitTypeID1").HasFillFactor(90);

            entity.Property(e => e.VisitId).HasColumnName("VisitID");
            entity.Property(e => e.ClientSoftwareApptId)
                .HasDefaultValue(0)
                .HasColumnName("ClientSoftwareApptID");
            entity.Property(e => e.ClientSoftwarePtId).HasColumnName("ClientSoftwarePtID");
            entity.Property(e => e.ClrefNoteRemember).HasColumnName("CLRefNoteRemember");
            entity.Property(e => e.CodeId).HasColumnName("CodeID");
            entity.Property(e => e.DiagTestDirtyInfo).HasMaxLength(255);
            entity.Property(e => e.DoctorDirtyInfo).HasMaxLength(255);
            entity.Property(e => e.Dosdate)
                .HasColumnType("datetime")
                .HasColumnName("DOSDate");
            entity.Property(e => e.ExamType).HasComment("1=NewPT, 2=Consult, 3 = Est PT");
            entity.Property(e => e.ExcludeVisit).HasDefaultValue((short)0);
            entity.Property(e => e.InitialSignedOff).HasDefaultValue((short)0);
            entity.Property(e => e.InitialSignedOffDate).HasColumnType("datetime");
            entity.Property(e => e.InitialSignedOffEmpId).HasColumnName("InitialSignedOffEmpID");
            entity.Property(e => e.InitialSignedOffRole).HasMaxLength(50);
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.LinkedProcedureVisitId).HasColumnName("LinkedProcedureVisitID");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.LocationSpecific)
                .HasMaxLength(50)
                .HasComment("OD, OS, OU, LT, RT, or Null");
            entity.Property(e => e.MdsignedOff).HasColumnName("MDSignedOff");
            entity.Property(e => e.MdsignedOffDate)
                .HasColumnType("datetime")
                .HasColumnName("MDSignedOffDate");
            entity.Property(e => e.MdsignedOffEmpId).HasColumnName("MDSignedOffEmpID");
            entity.Property(e => e.ProcDirtyInfo).HasMaxLength(255);
            entity.Property(e => e.ProcVisitTypeId).HasColumnName("ProcVisitTypeID");
            entity.Property(e => e.ProviderEmpId).HasColumnName("ProviderEmpID");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.ReconciledCcda).HasColumnName("ReconciledCCDA");
            entity.Property(e => e.ServiceType).HasDefaultValue(0);
            entity.Property(e => e.TabCchpi).HasColumnName("TabCCHPI");
            entity.Property(e => e.TabDfe).HasColumnName("TabDFE");
            entity.Property(e => e.TabMbalance).HasColumnName("TabMBalance");
            entity.Property(e => e.TabPohpmh).HasColumnName("TabPOHPMH");
            entity.Property(e => e.TabRos).HasColumnName("TabROS");
            entity.Property(e => e.TabSle).HasColumnName("TabSLE");
            entity.Property(e => e.TechDirtyInfo).HasMaxLength(255);
            entity.Property(e => e.TechRosdirtyInfo)
                .HasMaxLength(255)
                .HasColumnName("TechROSDirtyInfo");
            entity.Property(e => e.TechRosisDirty).HasColumnName("TechROSIsDirty");
            entity.Property(e => e.TechWu2dirtyInfo)
                .HasMaxLength(255)
                .HasColumnName("TechWU2DirtyInfo");
            entity.Property(e => e.TechWu2isDirty).HasColumnName("TechWU2IsDirty");
            entity.Property(e => e.VisitClassId)
                .HasComment("0 = Regular Office Visit, 1 = Procedure Related Visit")
                .HasColumnName("VisitClassID");
            entity.Property(e => e.VisitDoctor).HasDefaultValue(0);
            entity.Property(e => e.VisitEyeCareProviderId).HasColumnName("VisitEyeCareProviderID");
            entity.Property(e => e.VisitPriCareProviderId).HasColumnName("VisitPriCareProviderID");
            entity.Property(e => e.VisitRefProviderId).HasColumnName("VisitRefProviderID");
            entity.Property(e => e.VisitTech).HasDefaultValue(0);
            entity.Property(e => e.VisitType).HasMaxLength(50);
            entity.Property(e => e.VisitTypeId)
                .HasComment("ID of Visit Type for use with Custom Treeview Fields")
                .HasColumnName("VisitTypeID");
            entity.Property(e => e.Wu2visitTypeId).HasColumnName("WU2VisitTypeID");
        });

        modelBuilder.Entity<EmrvisitAllergy>(entity =>
        {
            entity.HasKey(e => e.VisitAllergyId).HasName("PK__EMRVisitAllergie__158603F9");

            entity.ToTable("EMRVisitAllergies");

            entity.HasIndex(e => new { e.PtId, e.VisitId }, "IX_VisitAllergies_PtID_VisitID").HasFillFactor(90);

            entity.Property(e => e.VisitAllergyId).HasColumnName("VisitAllergyID");
            entity.Property(e => e.AllergyConceptId)
                .HasMaxLength(100)
                .HasColumnName("AllergyConceptID");
            entity.Property(e => e.AllergyMappingId)
                .HasMaxLength(100)
                .HasColumnName("AllergyMappingID");
            entity.Property(e => e.AllergyName).HasMaxLength(255);
            entity.Property(e => e.Created)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedEmpId).HasColumnName("CreatedEmpID");
            entity.Property(e => e.Dosdate)
                .HasColumnType("datetime")
                .HasColumnName("DOSDate");
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(40)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedEmpId).HasColumnName("LastModifiedEmpID");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.Reaction).HasMaxLength(100);
            entity.Property(e => e.Rxcui)
                .HasMaxLength(50)
                .HasColumnName("RXCUI");
            entity.Property(e => e.Severity).HasMaxLength(100);
            entity.Property(e => e.Snomed)
                .HasMaxLength(50)
                .HasColumnName("SNOMED");
            entity.Property(e => e.Snomedtype)
                .HasMaxLength(50)
                .HasColumnName("SNOMEDType");
            entity.Property(e => e.StartDate).HasMaxLength(50);
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<EmrvisitContactLense>(entity =>
        {
            entity.HasKey(e => e.ContactLensId);

            entity.ToTable("EMRVisitContactLenses");

            entity.HasIndex(e => new { e.PtId, e.VisitId }, "IX_EMRVisitContactLenses")
                .IsDescending()
                .HasFillFactor(90);

            entity.Property(e => e.ContactLensId).HasColumnName("ContactLensID");
            entity.Property(e => e.AddOd)
                .HasMaxLength(50)
                .HasColumnName("Add_OD");
            entity.Property(e => e.AddOs)
                .HasMaxLength(50)
                .HasColumnName("Add_OS");
            entity.Property(e => e.Axis2Od)
                .HasMaxLength(50)
                .HasColumnName("Axis2_OD");
            entity.Property(e => e.Axis2Os)
                .HasMaxLength(50)
                .HasColumnName("Axis2_OS");
            entity.Property(e => e.AxisOd)
                .HasMaxLength(50)
                .HasColumnName("Axis_OD");
            entity.Property(e => e.AxisOs)
                .HasMaxLength(50)
                .HasColumnName("Axis_OS");
            entity.Property(e => e.Bc2Od)
                .HasMaxLength(50)
                .HasColumnName("BC2_OD");
            entity.Property(e => e.Bc2Os)
                .HasMaxLength(50)
                .HasColumnName("BC2_OS");
            entity.Property(e => e.BcOd)
                .HasMaxLength(50)
                .HasColumnName("BC_OD");
            entity.Property(e => e.BcOs)
                .HasMaxLength(50)
                .HasColumnName("BC_OS");
            entity.Property(e => e.BlendOd)
                .HasMaxLength(50)
                .HasColumnName("Blend_OD");
            entity.Property(e => e.BlendOs)
                .HasMaxLength(50)
                .HasColumnName("Blend_OS");
            entity.Property(e => e.CatalogBrandIdOd)
                .HasMaxLength(50)
                .HasColumnName("CatalogBrandID_OD");
            entity.Property(e => e.CatalogBrandIdOs)
                .HasMaxLength(50)
                .HasColumnName("CatalogBrandID_OS");
            entity.Property(e => e.CatalogManufacturerIdOd)
                .HasMaxLength(50)
                .HasColumnName("CatalogManufacturerID_OD");
            entity.Property(e => e.CatalogManufacturerIdOs)
                .HasMaxLength(50)
                .HasColumnName("CatalogManufacturerID_OS");
            entity.Property(e => e.CatalogProductIdOd)
                .HasMaxLength(50)
                .HasColumnName("CatalogProductID_OD");
            entity.Property(e => e.CatalogProductIdOs)
                .HasMaxLength(50)
                .HasColumnName("CatalogProductID_OS");
            entity.Property(e => e.CenterThicknessOd)
                .HasMaxLength(50)
                .HasColumnName("CenterThickness_OD");
            entity.Property(e => e.CenterThicknessOs)
                .HasMaxLength(50)
                .HasColumnName("CenterThickness_OS");
            entity.Property(e => e.CentrationOd)
                .HasMaxLength(50)
                .HasColumnName("Centration_OD");
            entity.Property(e => e.CentrationOs)
                .HasMaxLength(50)
                .HasColumnName("Centration_OS");
            entity.Property(e => e.ColorOd)
                .HasMaxLength(50)
                .HasColumnName("Color_OD");
            entity.Property(e => e.ColorOs)
                .HasMaxLength(50)
                .HasColumnName("Color_OS");
            entity.Property(e => e.ComfortOd)
                .HasMaxLength(50)
                .HasColumnName("Comfort_OD");
            entity.Property(e => e.ComfortOs)
                .HasMaxLength(50)
                .HasColumnName("Comfort_OS");
            entity.Property(e => e.ContactClass).HasMaxLength(50);
            entity.Property(e => e.CoverageOd)
                .HasMaxLength(50)
                .HasColumnName("Coverage_OD");
            entity.Property(e => e.CoverageOs)
                .HasMaxLength(50)
                .HasColumnName("Coverage_OS");
            entity.Property(e => e.Cylinder2Od)
                .HasMaxLength(50)
                .HasColumnName("Cylinder2_OD");
            entity.Property(e => e.Cylinder2Os)
                .HasMaxLength(50)
                .HasColumnName("Cylinder2_OS");
            entity.Property(e => e.CylinderOd)
                .HasMaxLength(50)
                .HasColumnName("Cylinder_OD");
            entity.Property(e => e.CylinderOs)
                .HasMaxLength(50)
                .HasColumnName("Cylinder_OS");
            entity.Property(e => e.Diameter2Od)
                .HasMaxLength(50)
                .HasColumnName("Diameter2_OD");
            entity.Property(e => e.Diameter2Os)
                .HasMaxLength(50)
                .HasColumnName("Diameter2_OS");
            entity.Property(e => e.DiameterOd)
                .HasMaxLength(50)
                .HasColumnName("Diameter_OD");
            entity.Property(e => e.DiameterOs)
                .HasMaxLength(50)
                .HasColumnName("Diameter_OS");
            entity.Property(e => e.DistNearOd)
                .HasMaxLength(10)
                .HasColumnName("Dist_Near_OD");
            entity.Property(e => e.DistNearOs)
                .HasMaxLength(10)
                .HasColumnName("Dist_Near_OS");
            entity.Property(e => e.DkOd)
                .HasMaxLength(50)
                .HasColumnName("Dk_OD");
            entity.Property(e => e.DkOs)
                .HasMaxLength(50)
                .HasColumnName("Dk_OS");
            entity.Property(e => e.Dosdate)
                .HasColumnType("datetime")
                .HasColumnName("DOSDate");
            entity.Property(e => e.EdgeLiftOd)
                .HasMaxLength(50)
                .HasColumnName("Edge_Lift_OD");
            entity.Property(e => e.EdgeLiftOs)
                .HasMaxLength(50)
                .HasColumnName("Edge_Lift_OS");
            entity.Property(e => e.EdgeOd)
                .HasMaxLength(50)
                .HasColumnName("Edge_OD");
            entity.Property(e => e.EdgeOs)
                .HasMaxLength(50)
                .HasColumnName("Edge_OS");
            entity.Property(e => e.EquivalentCurveOd)
                .HasMaxLength(50)
                .HasColumnName("EquivalentCurve_OD");
            entity.Property(e => e.EquivalentCurveOs)
                .HasMaxLength(50)
                .HasColumnName("EquivalentCurve_OS");
            entity.Property(e => e.Expires).HasMaxLength(50);
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.KOd)
                .HasMaxLength(50)
                .HasColumnName("K_OD");
            entity.Property(e => e.KOs)
                .HasMaxLength(50)
                .HasColumnName("K_OS");
            entity.Property(e => e.LensDesignOd)
                .HasMaxLength(50)
                .HasColumnName("LensDesign_OD");
            entity.Property(e => e.LensDesignOs)
                .HasMaxLength(50)
                .HasColumnName("LensDesign_OS");
            entity.Property(e => e.LensType).HasMaxLength(50);
            entity.Property(e => e.MaterialOd)
                .HasMaxLength(50)
                .HasColumnName("Material_OD");
            entity.Property(e => e.MaterialOs)
                .HasMaxLength(50)
                .HasColumnName("Material_OS");
            entity.Property(e => e.MovementOd)
                .HasMaxLength(50)
                .HasColumnName("Movement_OD");
            entity.Property(e => e.MovementOs)
                .HasMaxLength(50)
                .HasColumnName("Movement_OS");
            entity.Property(e => e.NaFlPatternOd)
                .HasMaxLength(50)
                .HasColumnName("NaFlPattern_OD");
            entity.Property(e => e.NaFlPatternOs)
                .HasMaxLength(50)
                .HasColumnName("NaFlPattern_OS");
            entity.Property(e => e.OpticalZoneDiaOd)
                .HasMaxLength(50)
                .HasColumnName("OpticalZoneDia_OD");
            entity.Property(e => e.OpticalZoneDiaOs)
                .HasMaxLength(50)
                .HasColumnName("OpticalZoneDia_OS");
            entity.Property(e => e.OrAxisOd)
                .HasMaxLength(50)
                .HasColumnName("OR_Axis_OD");
            entity.Property(e => e.OrAxisOs)
                .HasMaxLength(50)
                .HasColumnName("OR_Axis_OS");
            entity.Property(e => e.OrCylinderOd)
                .HasMaxLength(50)
                .HasColumnName("OR_Cylinder_OD");
            entity.Property(e => e.OrCylinderOs)
                .HasMaxLength(50)
                .HasColumnName("OR_Cylinder_OS");
            entity.Property(e => e.OrSphereOd)
                .HasMaxLength(50)
                .HasColumnName("OR_Sphere_OD");
            entity.Property(e => e.OrSphereOs)
                .HasMaxLength(50)
                .HasColumnName("OR_Sphere_OS");
            entity.Property(e => e.OrVaDOd)
                .HasMaxLength(50)
                .HasColumnName("OR_VaD_OD");
            entity.Property(e => e.OrVaDOs)
                .HasMaxLength(50)
                .HasColumnName("OR_VaD_OS");
            entity.Property(e => e.OrVaNOd)
                .HasMaxLength(50)
                .HasColumnName("OR_VaN_OD");
            entity.Property(e => e.OrVaNOs)
                .HasMaxLength(50)
                .HasColumnName("OR_VaN_OS");
            entity.Property(e => e.PeriphCurve2Od)
                .HasMaxLength(50)
                .HasColumnName("PeriphCurve2_OD");
            entity.Property(e => e.PeriphCurve2Os)
                .HasMaxLength(50)
                .HasColumnName("PeriphCurve2_OS");
            entity.Property(e => e.PeriphCurveOd)
                .HasMaxLength(50)
                .HasColumnName("PeriphCurve_OD");
            entity.Property(e => e.PeriphCurveOs)
                .HasMaxLength(50)
                .HasColumnName("PeriphCurve_OS");
            entity.Property(e => e.Power2Od)
                .HasMaxLength(50)
                .HasColumnName("Power2_OD");
            entity.Property(e => e.Power2Os)
                .HasMaxLength(50)
                .HasColumnName("Power2_OS");
            entity.Property(e => e.PowerOd)
                .HasMaxLength(50)
                .HasColumnName("Power_OD");
            entity.Property(e => e.PowerOs)
                .HasMaxLength(50)
                .HasColumnName("Power_OS");
            entity.Property(e => e.ProductOd)
                .HasMaxLength(255)
                .HasColumnName("Product_OD");
            entity.Property(e => e.ProductOs)
                .HasMaxLength(255)
                .HasColumnName("Product_OS");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.PtInsertedRemoved).HasColumnName("Pt_InsertedRemoved");
            entity.Property(e => e.PupilOd)
                .HasMaxLength(50)
                .HasColumnName("Pupil_OD");
            entity.Property(e => e.PupilOs)
                .HasMaxLength(50)
                .HasColumnName("Pupil_OS");
            entity.Property(e => e.ReplacementSchedule).HasMaxLength(50);
            entity.Property(e => e.RgpLayoutOd).HasColumnName("RGP_Layout_OD");
            entity.Property(e => e.RgpLayoutOs).HasColumnName("RGP_Layout_OS");
            entity.Property(e => e.RotationDegOd)
                .HasMaxLength(20)
                .HasColumnName("Rotation_Deg_OD");
            entity.Property(e => e.RotationDegOs)
                .HasMaxLength(20)
                .HasColumnName("Rotation_Deg_OS");
            entity.Property(e => e.RotationDirectionOd)
                .HasMaxLength(50)
                .HasColumnName("Rotation_Direction_OD");
            entity.Property(e => e.RotationDirectionOs)
                .HasMaxLength(50)
                .HasColumnName("Rotation_Direction_OS");
            entity.Property(e => e.RxId).HasColumnName("RxID");
            entity.Property(e => e.SecondaryCurveOd)
                .HasMaxLength(20)
                .HasColumnName("SecondaryCurve_OD");
            entity.Property(e => e.SecondaryCurveOs)
                .HasMaxLength(20)
                .HasColumnName("SecondaryCurve_OS");
            entity.Property(e => e.SegHeightOd)
                .HasMaxLength(50)
                .HasColumnName("Seg_Height_OD");
            entity.Property(e => e.SegHeightOs)
                .HasMaxLength(50)
                .HasColumnName("Seg_Height_OS");
            entity.Property(e => e.Solution).HasMaxLength(50);
            entity.Property(e => e.SpecialInstructionsOd)
                .HasMaxLength(100)
                .HasColumnName("SpecialInstructions_OD");
            entity.Property(e => e.SpecialInstructionsOs)
                .HasMaxLength(100)
                .HasColumnName("SpecialInstructions_OS");
            entity.Property(e => e.SurfaceWettingOd)
                .HasMaxLength(50)
                .HasColumnName("SurfaceWetting_OD");
            entity.Property(e => e.SurfaceWettingOs)
                .HasMaxLength(50)
                .HasColumnName("SurfaceWetting_OS");
            entity.Property(e => e.TreeviewTableIdOd).HasColumnName("TreeviewTableID_OD");
            entity.Property(e => e.TreeviewTableIdOs).HasColumnName("TreeviewTableID_OS");
            entity.Property(e => e.TrialNumber).HasMaxLength(100);
            entity.Property(e => e.UpcOd)
                .HasMaxLength(50)
                .HasColumnName("UPC_OD");
            entity.Property(e => e.UpcOs)
                .HasMaxLength(50)
                .HasColumnName("UPC_OS");
            entity.Property(e => e.VaDOd)
                .HasMaxLength(50)
                .HasColumnName("VaD_OD");
            entity.Property(e => e.VaDOs)
                .HasMaxLength(50)
                .HasColumnName("VaD_OS");
            entity.Property(e => e.VaDOu)
                .HasMaxLength(50)
                .HasColumnName("VaD_OU");
            entity.Property(e => e.VaIOd)
                .HasMaxLength(50)
                .HasColumnName("VaI_OD");
            entity.Property(e => e.VaIOs)
                .HasMaxLength(50)
                .HasColumnName("VaI_OS");
            entity.Property(e => e.VaIOu)
                .HasMaxLength(50)
                .HasColumnName("VaI_OU");
            entity.Property(e => e.VaNOd)
                .HasMaxLength(50)
                .HasColumnName("VaN_OD");
            entity.Property(e => e.VaNOs)
                .HasMaxLength(50)
                .HasColumnName("VaN_OS");
            entity.Property(e => e.VaNOu)
                .HasMaxLength(50)
                .HasColumnName("VaN_OU");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
            entity.Property(e => e.WAgeOd)
                .HasMaxLength(50)
                .HasColumnName("W_Age_OD");
            entity.Property(e => e.WAgeOs)
                .HasMaxLength(50)
                .HasColumnName("W_Age_OS");
            entity.Property(e => e.WAvgWearTimeOd)
                .HasMaxLength(50)
                .HasColumnName("W_Avg_WearTime_OD");
            entity.Property(e => e.WAvgWearTimeOs)
                .HasMaxLength(50)
                .HasColumnName("W_Avg_WearTime_OS");
            entity.Property(e => e.WTimeTodayOd)
                .HasMaxLength(50)
                .HasColumnName("W_TimeToday_OD");
            entity.Property(e => e.WTimeTodayOs)
                .HasMaxLength(50)
                .HasColumnName("W_TimeToday_OS");
            entity.Property(e => e.WearingInstructions).HasMaxLength(255);
        });

        modelBuilder.Entity<EmrvisitDiagCodePool>(entity =>
        {
            entity.HasKey(e => e.VisitDiagCodePoolId)
                .HasName("aaaaaEMRVisitDiagCodePool_PK")
                .IsClustered(false);

            entity.ToTable("EMRVisitDiagCodePool");

            entity.HasIndex(e => e.Code, "Code").HasFillFactor(90);

            entity.HasIndex(e => e.PtId, "CodeICD10").HasFillFactor(90);

            entity.HasIndex(e => e.ControlId, "ControlID").HasFillFactor(90);

            entity.HasIndex(e => e.RequestedProcedureId, "IX_VisitDiagCodePool_RequestedProcedureID").HasFillFactor(90);

            entity.HasIndex(e => e.PtId, "PTID").HasFillFactor(90);

            entity.HasIndex(e => e.VisitId, "VisitID").HasFillFactor(90);

            entity.HasIndex(e => e.VisitDiagCodePoolId, "VisitTechID")
                .IsUnique()
                .HasFillFactor(90);

            entity.Property(e => e.VisitDiagCodePoolId).HasColumnName("VisitDiagCodePoolID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CodeIcd10)
                .HasMaxLength(50)
                .HasColumnName("CodeICD10");
            entity.Property(e => e.CodeSnomed)
                .HasMaxLength(50)
                .HasColumnName("CodeSNOMED");
            entity.Property(e => e.ConditionId).HasColumnName("ConditionID");
            entity.Property(e => e.ControlId).HasColumnName("ControlID");
            entity.Property(e => e.Created)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedEmpId).HasColumnName("CreatedEmpID");
            entity.Property(e => e.Dosdate)
                .HasColumnType("datetime")
                .HasColumnName("DOSDate");
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedEmpId).HasColumnName("LastModifiedEmpID");
            entity.Property(e => e.Location1).HasMaxLength(50);
            entity.Property(e => e.Location2).HasMaxLength(50);
            entity.Property(e => e.Location2OnsetVisitId).HasColumnName("Location2OnsetVisitID");
            entity.Property(e => e.Modifier).HasMaxLength(50);
            entity.Property(e => e.OnsetDay1).HasMaxLength(10);
            entity.Property(e => e.OnsetDay2).HasMaxLength(10);
            entity.Property(e => e.OnsetMonth1).HasMaxLength(10);
            entity.Property(e => e.OnsetMonth2).HasMaxLength(10);
            entity.Property(e => e.OnsetYear1).HasMaxLength(10);
            entity.Property(e => e.OnsetYear2).HasMaxLength(10);
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.RequestedProcedureId).HasColumnName("RequestedProcedureID");
            entity.Property(e => e.ResolveType1).HasMaxLength(75);
            entity.Property(e => e.ResolveType2).HasMaxLength(75);
            entity.Property(e => e.ResolvedDate1).HasColumnType("datetime");
            entity.Property(e => e.ResolvedDate2).HasColumnType("datetime");
            entity.Property(e => e.ResolvedRequestedProcedureId1).HasColumnName("ResolvedRequestedProcedureID1");
            entity.Property(e => e.ResolvedRequestedProcedureId2).HasColumnName("ResolvedRequestedProcedureID2");
            entity.Property(e => e.ResolvedVisitId1).HasColumnName("ResolvedVisitID1");
            entity.Property(e => e.ResolvedVisitId2).HasColumnName("ResolvedVisitID2");
            entity.Property(e => e.SourceField).HasMaxLength(50);
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<EmrvisitDiagCodePoolStatus>(entity =>
        {
            entity.HasKey(e => e.VisitDiagCodePoolStatusId);

            entity.ToTable("EMRVisitDiagCodePoolStatus");

            entity.HasIndex(e => e.PtId, "IX_PtID").HasFillFactor(90);

            entity.HasIndex(e => e.VisitDiagCodePoolId, "VisitDiagCodePoolID").HasFillFactor(90);

            entity.Property(e => e.VisitDiagCodePoolStatusId).HasColumnName("VisitDiagCodePoolStatusID");
            entity.Property(e => e.CareEpisode).HasMaxLength(5);
            entity.Property(e => e.CodeIcd10final)
                .HasMaxLength(50)
                .HasColumnName("CodeICD10Final");
            entity.Property(e => e.Dosdate)
                .HasColumnType("datetime")
                .HasColumnName("DOSDate");
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.RequestedProcedureId).HasColumnName("RequestedProcedureID");
            entity.Property(e => e.VisitDiagCodePoolId).HasColumnName("VisitDiagCodePoolID");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<EmrvisitDiagTest>(entity =>
        {
            entity.HasKey(e => e.VisitDiagTestId)
                .HasName("aaaaaEMRVisitDiagTest_PK")
                .IsClustered(false);

            entity.ToTable("EMRVisitDiagTest");

            entity.HasIndex(e => e.PtId, "PTID").HasFillFactor(90);

            entity.HasIndex(e => e.VisitId, "VisitID").HasFillFactor(90);

            entity.HasIndex(e => e.VisitDiagTestId, "VisitTechID")
                .IsUnique()
                .HasFillFactor(90);

            entity.Property(e => e.VisitDiagTestId).HasColumnName("VisitDiagTestID");
            entity.Property(e => e.Dosdate)
                .HasColumnType("datetime")
                .HasColumnName("DOSDate");
            entity.Property(e => e.GonioAngleDepthInOd)
                .HasMaxLength(50)
                .HasColumnName("GonioAngleDepth_In_OD");
            entity.Property(e => e.GonioAngleDepthInOs)
                .HasMaxLength(50)
                .HasColumnName("GonioAngleDepth_In_OS");
            entity.Property(e => e.GonioAngleDepthMedialOd)
                .HasMaxLength(50)
                .HasColumnName("GonioAngleDepth_Medial_OD");
            entity.Property(e => e.GonioAngleDepthMedialOs)
                .HasMaxLength(50)
                .HasColumnName("GonioAngleDepth_Medial_OS");
            entity.Property(e => e.GonioAngleDepthSuOd)
                .HasMaxLength(50)
                .HasColumnName("GonioAngleDepth_Su_OD");
            entity.Property(e => e.GonioAngleDepthSuOs)
                .HasMaxLength(50)
                .HasColumnName("GonioAngleDepth_Su_OS");
            entity.Property(e => e.GonioAngleDepthTemporalOd)
                .HasMaxLength(50)
                .HasColumnName("GonioAngleDepth_Temporal_OD");
            entity.Property(e => e.GonioAngleDepthTemporalOs)
                .HasMaxLength(50)
                .HasColumnName("GonioAngleDepth_Temporal_OS");
            entity.Property(e => e.GonioAngleStructureInOd)
                .HasMaxLength(50)
                .HasColumnName("GonioAngleStructure_In_OD");
            entity.Property(e => e.GonioAngleStructureInOs)
                .HasMaxLength(50)
                .HasColumnName("GonioAngleStructure_In_OS");
            entity.Property(e => e.GonioAngleStructureMedialOd)
                .HasMaxLength(50)
                .HasColumnName("GonioAngleStructure_Medial_OD");
            entity.Property(e => e.GonioAngleStructureMedialOs)
                .HasMaxLength(50)
                .HasColumnName("GonioAngleStructure_Medial_OS");
            entity.Property(e => e.GonioAngleStructureSuOd)
                .HasMaxLength(50)
                .HasColumnName("GonioAngleStructure_Su_OD");
            entity.Property(e => e.GonioAngleStructureSuOs)
                .HasMaxLength(50)
                .HasColumnName("GonioAngleStructure_Su_OS");
            entity.Property(e => e.GonioAngleStructureTemporalOd)
                .HasMaxLength(50)
                .HasColumnName("GonioAngleStructure_Temporal_OD");
            entity.Property(e => e.GonioAngleStructureTemporalOs)
                .HasMaxLength(50)
                .HasColumnName("GonioAngleStructure_Temporal_OS");
            entity.Property(e => e.GonioPigmentOd)
                .HasMaxLength(255)
                .HasColumnName("GonioPigment_OD");
            entity.Property(e => e.GonioPigmentOs)
                .HasMaxLength(255)
                .HasColumnName("GonioPigment_OS");
            entity.Property(e => e.MbalanceCcOrtho).HasColumnName("MBalance_CC_Ortho");
            entity.Property(e => e.MbalanceCcType)
                .HasMaxLength(255)
                .HasColumnName("MBalance_CC_Type");
            entity.Property(e => e.MbalanceHorizCcDownGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceHoriz_CC_DownGaze");
            entity.Property(e => e.MbalanceHorizCcDownLtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceHoriz_CC_DownLtGaze");
            entity.Property(e => e.MbalanceHorizCcDownRtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceHoriz_CC_DownRtGaze");
            entity.Property(e => e.MbalanceHorizCcLtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceHoriz_CC_LtGaze");
            entity.Property(e => e.MbalanceHorizCcPriGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceHoriz_CC_PriGaze");
            entity.Property(e => e.MbalanceHorizCcRtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceHoriz_CC_RtGaze");
            entity.Property(e => e.MbalanceHorizCcUpGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceHoriz_CC_UpGaze");
            entity.Property(e => e.MbalanceHorizCcUpLtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceHoriz_CC_UpLtGaze");
            entity.Property(e => e.MbalanceHorizCcUpRtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceHoriz_CC_UpRtGaze");
            entity.Property(e => e.MbalanceHorizScDownGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceHoriz_SC_DownGaze");
            entity.Property(e => e.MbalanceHorizScDownLtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceHoriz_SC_DownLtGaze");
            entity.Property(e => e.MbalanceHorizScDownRtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceHoriz_SC_DownRtGaze");
            entity.Property(e => e.MbalanceHorizScLtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceHoriz_SC_LtGaze");
            entity.Property(e => e.MbalanceHorizScPriGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceHoriz_SC_PriGaze");
            entity.Property(e => e.MbalanceHorizScRtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceHoriz_SC_RtGaze");
            entity.Property(e => e.MbalanceHorizScUpGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceHoriz_SC_UpGaze");
            entity.Property(e => e.MbalanceHorizScUpLtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceHoriz_SC_UpLtGaze");
            entity.Property(e => e.MbalanceHorizScUpRtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceHoriz_SC_UpRtGaze");
            entity.Property(e => e.MbalanceHorizTypeCcDownGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceHorizType_CC_DownGaze");
            entity.Property(e => e.MbalanceHorizTypeCcDownLtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceHorizType_CC_DownLtGaze");
            entity.Property(e => e.MbalanceHorizTypeCcDownRtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceHorizType_CC_DownRtGaze");
            entity.Property(e => e.MbalanceHorizTypeCcLtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceHorizType_CC_LtGaze");
            entity.Property(e => e.MbalanceHorizTypeCcPriGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceHorizType_CC_PriGaze");
            entity.Property(e => e.MbalanceHorizTypeCcRtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceHorizType_CC_RtGaze");
            entity.Property(e => e.MbalanceHorizTypeCcUpGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceHorizType_CC_UpGaze");
            entity.Property(e => e.MbalanceHorizTypeCcUpLtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceHorizType_CC_UpLtGaze");
            entity.Property(e => e.MbalanceHorizTypeCcUpRtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceHorizType_CC_UpRtGaze");
            entity.Property(e => e.MbalanceHorizTypeScDownGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceHorizType_SC_DownGaze");
            entity.Property(e => e.MbalanceHorizTypeScDownLtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceHorizType_SC_DownLtGaze");
            entity.Property(e => e.MbalanceHorizTypeScDownRtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceHorizType_SC_DownRtGaze");
            entity.Property(e => e.MbalanceHorizTypeScLtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceHorizType_SC_LtGaze");
            entity.Property(e => e.MbalanceHorizTypeScPriGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceHorizType_SC_PriGaze");
            entity.Property(e => e.MbalanceHorizTypeScRtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceHorizType_SC_RtGaze");
            entity.Property(e => e.MbalanceHorizTypeScUpGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceHorizType_SC_UpGaze");
            entity.Property(e => e.MbalanceHorizTypeScUpLtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceHorizType_SC_UpLtGaze");
            entity.Property(e => e.MbalanceHorizTypeScUpRtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceHorizType_SC_UpRtGaze");
            entity.Property(e => e.MbalanceMethod)
                .HasMaxLength(50)
                .HasColumnName("MBalanceMethod");
            entity.Property(e => e.MbalanceMethodCc)
                .HasMaxLength(50)
                .HasColumnName("MBalanceMethod_CC");
            entity.Property(e => e.MbalanceMethodSc)
                .HasMaxLength(50)
                .HasColumnName("MBalanceMethod_SC");
            entity.Property(e => e.MbalanceScOrtho).HasColumnName("MBalance_SC_Ortho");
            entity.Property(e => e.MbalanceScType)
                .HasMaxLength(255)
                .HasColumnName("MBalance_SC_Type");
            entity.Property(e => e.MbalanceVertCcDownGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceVert_CC_DownGaze");
            entity.Property(e => e.MbalanceVertCcDownLtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceVert_CC_DownLtGaze");
            entity.Property(e => e.MbalanceVertCcDownRtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceVert_CC_DownRtGaze");
            entity.Property(e => e.MbalanceVertCcLtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceVert_CC_LtGaze");
            entity.Property(e => e.MbalanceVertCcPriGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceVert_CC_PriGaze");
            entity.Property(e => e.MbalanceVertCcRtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceVert_CC_RtGaze");
            entity.Property(e => e.MbalanceVertCcUpGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceVert_CC_UpGaze");
            entity.Property(e => e.MbalanceVertCcUpLtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceVert_CC_UpLtGaze");
            entity.Property(e => e.MbalanceVertCcUpRtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceVert_CC_UpRtGaze");
            entity.Property(e => e.MbalanceVertScDownGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceVert_SC_DownGaze");
            entity.Property(e => e.MbalanceVertScDownLtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceVert_SC_DownLtGaze");
            entity.Property(e => e.MbalanceVertScDownRtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceVert_SC_DownRtGaze");
            entity.Property(e => e.MbalanceVertScLtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceVert_SC_LtGaze");
            entity.Property(e => e.MbalanceVertScPriGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceVert_SC_PriGaze");
            entity.Property(e => e.MbalanceVertScRtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceVert_SC_RtGaze");
            entity.Property(e => e.MbalanceVertScUpGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceVert_SC_UpGaze");
            entity.Property(e => e.MbalanceVertScUpLtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceVert_SC_UpLtGaze");
            entity.Property(e => e.MbalanceVertScUpRtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceVert_SC_UpRtGaze");
            entity.Property(e => e.MbalanceVertTypeCcDownGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceVertType_CC_DownGaze");
            entity.Property(e => e.MbalanceVertTypeCcDownLtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceVertType_CC_DownLtGaze");
            entity.Property(e => e.MbalanceVertTypeCcDownRtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceVertType_CC_DownRtGaze");
            entity.Property(e => e.MbalanceVertTypeCcLtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceVertType_CC_LtGaze");
            entity.Property(e => e.MbalanceVertTypeCcPriGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceVertType_CC_PriGaze");
            entity.Property(e => e.MbalanceVertTypeCcRtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceVertType_CC_RtGaze");
            entity.Property(e => e.MbalanceVertTypeCcUpGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceVertType_CC_UpGaze");
            entity.Property(e => e.MbalanceVertTypeCcUpLtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceVertType_CC_UpLtGaze");
            entity.Property(e => e.MbalanceVertTypeCcUpRtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceVertType_CC_UpRtGaze");
            entity.Property(e => e.MbalanceVertTypeScDownGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceVertType_SC_DownGaze");
            entity.Property(e => e.MbalanceVertTypeScDownLtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceVertType_SC_DownLtGaze");
            entity.Property(e => e.MbalanceVertTypeScDownRtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceVertType_SC_DownRtGaze");
            entity.Property(e => e.MbalanceVertTypeScLtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceVertType_SC_LtGaze");
            entity.Property(e => e.MbalanceVertTypeScPriGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceVertType_SC_PriGaze");
            entity.Property(e => e.MbalanceVertTypeScRtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceVertType_SC_RtGaze");
            entity.Property(e => e.MbalanceVertTypeScUpGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceVertType_SC_UpGaze");
            entity.Property(e => e.MbalanceVertTypeScUpLtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceVertType_SC_UpLtGaze");
            entity.Property(e => e.MbalanceVertTypeScUpRtGaze)
                .HasMaxLength(50)
                .HasColumnName("MBalanceVertType_SC_UpRtGaze");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.SmotorAbute)
                .HasDefaultValue((short)0)
                .HasColumnName("SMotor_ABUTE");
            entity.Property(e => e.SmotorAvpattern)
                .HasMaxLength(255)
                .HasColumnName("SMotorAVPattern");
            entity.Property(e => e.SmotorColorVisionOd)
                .HasMaxLength(100)
                .HasColumnName("SMotorColorVision_OD");
            entity.Property(e => e.SmotorColorVisionOs)
                .HasMaxLength(100)
                .HasColumnName("SMotorColorVision_OS");
            entity.Property(e => e.SmotorColorVisionType)
                .HasMaxLength(100)
                .HasColumnName("SMotorColorVision_Type");
            entity.Property(e => e.SmotorComments).HasColumnName("SMotorComments");
            entity.Property(e => e.SmotorDirectionOd)
                .HasMaxLength(50)
                .HasColumnName("SMotorDirection_OD");
            entity.Property(e => e.SmotorDirectionOs)
                .HasMaxLength(50)
                .HasColumnName("SMotorDirection_OS");
            entity.Property(e => e.SmotorDistStereo)
                .HasMaxLength(255)
                .HasColumnName("SMotorDistStereo");
            entity.Property(e => e.SmotorDistVectograph)
                .HasMaxLength(255)
                .HasColumnName("SMotorDistVectograph");
            entity.Property(e => e.SmotorDmadRodOd)
                .HasMaxLength(50)
                .HasColumnName("SMotorDMadRod_OD");
            entity.Property(e => e.SmotorDmadRodOs)
                .HasMaxLength(50)
                .HasColumnName("SMotorDMadRod_OS");
            entity.Property(e => e.SmotorDmadRodTorsionOd)
                .HasMaxLength(100)
                .HasColumnName("SMotorDMadRodTorsion_OD");
            entity.Property(e => e.SmotorDmadRodTorsionOs)
                .HasMaxLength(100)
                .HasColumnName("SMotorDMadRodTorsion_OS");
            entity.Property(e => e.SmotorFixPrefDist)
                .HasMaxLength(255)
                .HasColumnName("SMotorFixPref_Dist");
            entity.Property(e => e.SmotorFixPrefNear)
                .HasMaxLength(255)
                .HasColumnName("SMotorFixPref_Near");
            entity.Property(e => e.SmotorFrisby)
                .HasMaxLength(255)
                .HasColumnName("SMotorFrisby");
            entity.Property(e => e.SmotorHorizCcDist)
                .HasMaxLength(50)
                .HasColumnName("SMotorHoriz_CC_Dist");
            entity.Property(e => e.SmotorHorizCcNear)
                .HasMaxLength(50)
                .HasColumnName("SMotorHoriz_CC_Near");
            entity.Property(e => e.SmotorHorizCcNear3Plus)
                .HasMaxLength(50)
                .HasColumnName("SMotorHoriz_CC_Near3Plus");
            entity.Property(e => e.SmotorHorizScDist)
                .HasMaxLength(50)
                .HasColumnName("SMotorHoriz_SC_Dist");
            entity.Property(e => e.SmotorHorizScNear)
                .HasMaxLength(50)
                .HasColumnName("SMotorHoriz_SC_Near");
            entity.Property(e => e.SmotorHorizTypeCcDist)
                .HasMaxLength(50)
                .HasColumnName("SMotorHorizType_CC_Dist");
            entity.Property(e => e.SmotorHorizTypeCcNear)
                .HasMaxLength(50)
                .HasColumnName("SMotorHorizType_CC_Near");
            entity.Property(e => e.SmotorHorizTypeCcNear3Plus)
                .HasMaxLength(50)
                .HasColumnName("SMotorHorizType_CC_Near3Plus");
            entity.Property(e => e.SmotorHorizTypeScDist)
                .HasMaxLength(50)
                .HasColumnName("SMotorHorizType_SC_Dist");
            entity.Property(e => e.SmotorHorizTypeScNear)
                .HasMaxLength(50)
                .HasColumnName("SMotorHorizType_SC_Near");
            entity.Property(e => e.SmotorHorizVergBiBreak)
                .HasMaxLength(100)
                .HasColumnName("SMotorHorizVerg_BI_Break");
            entity.Property(e => e.SmotorHorizVergBiRecover)
                .HasMaxLength(100)
                .HasColumnName("SMotorHorizVerg_BI_Recover");
            entity.Property(e => e.SmotorHorizVergBoBreak)
                .HasMaxLength(100)
                .HasColumnName("SMotorHorizVerg_BO_Break");
            entity.Property(e => e.SmotorHorizVergBoRecover)
                .HasMaxLength(100)
                .HasColumnName("SMotorHorizVerg_BO_Recover");
            entity.Property(e => e.SmotorHtLtHorizCc)
                .HasMaxLength(50)
                .HasColumnName("SMotor_HT_LtHoriz_CC");
            entity.Property(e => e.SmotorHtLtHorizSc)
                .HasMaxLength(50)
                .HasColumnName("SMotor_HT_LtHoriz_SC");
            entity.Property(e => e.SmotorHtLtHorizTypeCc)
                .HasMaxLength(50)
                .HasColumnName("SMotor_HT_LtHorizType_CC");
            entity.Property(e => e.SmotorHtLtHorizTypeSc)
                .HasMaxLength(50)
                .HasColumnName("SMotor_HT_LtHorizType_SC");
            entity.Property(e => e.SmotorHtLtVertCc)
                .HasMaxLength(50)
                .HasColumnName("SMotor_HT_LtVert_CC");
            entity.Property(e => e.SmotorHtLtVertSc)
                .HasMaxLength(50)
                .HasColumnName("SMotor_HT_LtVert_SC");
            entity.Property(e => e.SmotorHtLtVertTypeCc)
                .HasMaxLength(50)
                .HasColumnName("SMotor_HT_LtVertType_CC");
            entity.Property(e => e.SmotorHtLtVertTypeSc)
                .HasMaxLength(50)
                .HasColumnName("SMotor_HT_LtVertType_SC");
            entity.Property(e => e.SmotorHtRtHorizCc)
                .HasMaxLength(50)
                .HasColumnName("SMotor_HT_RtHoriz_CC");
            entity.Property(e => e.SmotorHtRtHorizSc)
                .HasMaxLength(50)
                .HasColumnName("SMotor_HT_RtHoriz_SC");
            entity.Property(e => e.SmotorHtRtHorizTypeCc)
                .HasMaxLength(50)
                .HasColumnName("SMotor_HT_RtHorizType_CC");
            entity.Property(e => e.SmotorHtRtHorizTypeSc)
                .HasMaxLength(50)
                .HasColumnName("SMotor_HT_RtHorizType_SC");
            entity.Property(e => e.SmotorHtRtVertCc)
                .HasMaxLength(50)
                .HasColumnName("SMotor_HT_RtVert_CC");
            entity.Property(e => e.SmotorHtRtVertSc)
                .HasMaxLength(50)
                .HasColumnName("SMotor_HT_RtVert_SC");
            entity.Property(e => e.SmotorHtRtVertTypeCc)
                .HasMaxLength(50)
                .HasColumnName("SMotor_HT_RtVertType_CC");
            entity.Property(e => e.SmotorHtRtVertTypeSc)
                .HasMaxLength(50)
                .HasColumnName("SMotor_HT_RtVertType_SC");
            entity.Property(e => e.SmotorLang)
                .HasMaxLength(255)
                .HasColumnName("SMotorLang");
            entity.Property(e => e.SmotorNpc)
                .HasMaxLength(255)
                .HasColumnName("SMotorNPC");
            entity.Property(e => e.SmotorNystagmus)
                .HasMaxLength(255)
                .HasColumnName("SMotorNystagmus");
            entity.Property(e => e.SmotorPrismOd)
                .HasMaxLength(50)
                .HasColumnName("SMotorPrism_OD");
            entity.Property(e => e.SmotorPrismOs)
                .HasMaxLength(50)
                .HasColumnName("SMotorPrism_OS");
            entity.Property(e => e.SmotorRandotCircles)
                .HasMaxLength(255)
                .HasColumnName("SMotorRandotCircles");
            entity.Property(e => e.SmotorTitmusStereoAnimals)
                .HasMaxLength(255)
                .HasColumnName("SMotorTitmusStereoAnimals");
            entity.Property(e => e.SmotorTitmusStereoCircles)
                .HasMaxLength(255)
                .HasColumnName("SMotorTitmusStereoCircles");
            entity.Property(e => e.SmotorTitmusStereoFly)
                .HasMaxLength(255)
                .HasColumnName("SMotorTitmusStereoFly");
            entity.Property(e => e.SmotorVertCcDist)
                .HasMaxLength(50)
                .HasColumnName("SMotorVert_CC_Dist");
            entity.Property(e => e.SmotorVertCcNear)
                .HasMaxLength(50)
                .HasColumnName("SMotorVert_CC_Near");
            entity.Property(e => e.SmotorVertCcNear3Plus)
                .HasMaxLength(50)
                .HasColumnName("SMotorVert_CC_Near3Plus");
            entity.Property(e => e.SmotorVertScDist)
                .HasMaxLength(50)
                .HasColumnName("SMotorVert_SC_Dist");
            entity.Property(e => e.SmotorVertScNear)
                .HasMaxLength(50)
                .HasColumnName("SMotorVert_SC_Near");
            entity.Property(e => e.SmotorVertTypeCcDist)
                .HasMaxLength(50)
                .HasColumnName("SMotorVertType_CC_Dist");
            entity.Property(e => e.SmotorVertTypeCcNear)
                .HasMaxLength(50)
                .HasColumnName("SMotorVertType_CC_Near");
            entity.Property(e => e.SmotorVertTypeCcNear3Plus)
                .HasMaxLength(50)
                .HasColumnName("SMotorVertType_CC_Near3Plus");
            entity.Property(e => e.SmotorVertTypeScDist)
                .HasMaxLength(50)
                .HasColumnName("SMotorVertType_SC_Dist");
            entity.Property(e => e.SmotorVertTypeScNear)
                .HasMaxLength(50)
                .HasColumnName("SMotorVertType_SC_Near");
            entity.Property(e => e.SmotorVertVergBdBreak)
                .HasMaxLength(100)
                .HasColumnName("SMotorVertVerg_BD_Break");
            entity.Property(e => e.SmotorVertVergBdRecover)
                .HasMaxLength(100)
                .HasColumnName("SMotorVertVerg_BD_Recover");
            entity.Property(e => e.SmotorVertVergBuBreak)
                .HasMaxLength(100)
                .HasColumnName("SMotorVertVerg_BU_Break");
            entity.Property(e => e.SmotorVertVergBuRecover)
                .HasMaxLength(100)
                .HasColumnName("SMotorVertVerg_BU_Recover");
            entity.Property(e => e.SmotorWorth4DotDist)
                .HasMaxLength(255)
                .HasColumnName("SMotorWorth4Dot_Dist");
            entity.Property(e => e.SmotorWorth4DotNear)
                .HasMaxLength(255)
                .HasColumnName("SMotorWorth4Dot_Near");
            entity.Property(e => e.UpsizeTs)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("upsize_ts");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<EmrvisitDoctor>(entity =>
        {
            entity.HasKey(e => e.VisitDoctorId)
                .HasName("aaaaaEMRVisitDoctor_PK")
                .IsClustered(false);

            entity.ToTable("EMRVisitDoctor");

            entity.HasIndex(e => e.CodingChargesSent, "IX_CodingChargesSent").HasFillFactor(90);

            entity.HasIndex(e => e.PtId, "PTID").HasFillFactor(90);

            entity.HasIndex(e => e.VisitId, "VisitID").HasFillFactor(90);

            entity.HasIndex(e => e.VisitDoctorId, "VisitTechID")
                .IsUnique()
                .HasFillFactor(90);

            entity.Property(e => e.VisitDoctorId).HasColumnName("VisitDoctorID");
            entity.Property(e => e.CodingAdditionalProcedures).HasMaxLength(255);
            entity.Property(e => e.CodingC3emlevel).HasColumnName("CodingC3EMLevel");
            entity.Property(e => e.CodingC3eyeCareLevel).HasColumnName("CodingC3EyeCareLevel");
            entity.Property(e => e.CodingMdm).HasColumnName("CodingMDM");
            entity.Property(e => e.CodingQrautoCheckStatus)
                .HasDefaultValue((short)0)
                .HasColumnName("CodingQRAutoCheckStatus");
            entity.Property(e => e.DfeCdratioHorizOd)
                .HasMaxLength(255)
                .HasColumnName("DFE_CDRatio_Horiz_OD");
            entity.Property(e => e.DfeCdratioHorizOs)
                .HasMaxLength(255)
                .HasColumnName("DFE_CDRatio_Horiz_OS");
            entity.Property(e => e.DfeCdratioVertOd)
                .HasMaxLength(255)
                .HasColumnName("DFE_CDRatio_Vert_OD");
            entity.Property(e => e.DfeCdratioVertOs)
                .HasMaxLength(255)
                .HasColumnName("DFE_CDRatio_Vert_OS");
            entity.Property(e => e.DfeDiagOd).HasColumnName("DFE_Diag_OD");
            entity.Property(e => e.DfeDiagOs).HasColumnName("DFE_Diag_OS");
            entity.Property(e => e.Dfecomments).HasColumnName("DFEComments");
            entity.Property(e => e.DfedilatedPupilSizeOd)
                .HasMaxLength(50)
                .HasColumnName("DFEDilatedPupilSize_OD");
            entity.Property(e => e.DfedilatedPupilSizeOs)
                .HasMaxLength(50)
                .HasColumnName("DFEDilatedPupilSize_OS");
            entity.Property(e => e.DfeextOpth).HasColumnName("DFEExtOpth");
            entity.Property(e => e.DfelensUsed)
                .HasMaxLength(255)
                .HasColumnName("DFELensUsed");
            entity.Property(e => e.Dosdate)
                .HasColumnType("datetime")
                .HasColumnName("DOSDate");
            entity.Property(e => e.PdDistOu)
                .HasMaxLength(50)
                .HasColumnName("PD_Dist_OU");
            entity.Property(e => e.PdNearOu)
                .HasMaxLength(50)
                .HasColumnName("PD_Near_OU");
            entity.Property(e => e.PlanNextScheduledAppt).HasMaxLength(255);
            entity.Property(e => e.PlanRtoreason)
                .HasMaxLength(255)
                .HasColumnName("PlanRTOReason");
            entity.Property(e => e.PlanRtowhen)
                .HasMaxLength(255)
                .HasColumnName("PlanRTOWhen");
            entity.Property(e => e.PlanTargetIopOd)
                .HasMaxLength(50)
                .HasColumnName("PlanTargetIOP_OD");
            entity.Property(e => e.PlanTargetIopOs)
                .HasMaxLength(50)
                .HasColumnName("PlanTargetIOP_OS");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.ScribeEmpId).HasColumnName("ScribeEmpID");
            entity.Property(e => e.SleAbutehl)
                .HasDefaultValue((short)0)
                .HasColumnName("SLE_ABUTEHL");
            entity.Property(e => e.SleDiagOd).HasColumnName("SLE_Diag_OD");
            entity.Property(e => e.SleDiagOs).HasColumnName("SLE_Diag_OS");
            entity.Property(e => e.Slecomments).HasColumnName("SLEComments");
            entity.Property(e => e.UpsizeTs)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("upsize_ts");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<EmrvisitExamCondition>(entity =>
        {
            entity.HasKey(e => e.ExamConditionId);

            entity.ToTable("EMRVisitExamConditions");

            entity.HasIndex(e => new { e.PtId, e.VisitId }, "IX_EMRVisitExamConditions")
                .IsDescending()
                .HasFillFactor(90);

            entity.HasIndex(e => e.VisitId, "IX_EMRVisitExamConditions_VisitID").HasFillFactor(90);

            entity.Property(e => e.ExamConditionId).HasColumnName("ExamConditionID");
            entity.Property(e => e.ConditionId).HasColumnName("ConditionID");
            entity.Property(e => e.Dosdate)
                .HasColumnType("datetime")
                .HasColumnName("DOSDate");
            entity.Property(e => e.Laterality).HasMaxLength(10);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.Snomed)
                .HasMaxLength(50)
                .HasColumnName("SNOMED");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<EmrvisitFamilyHistory>(entity =>
        {
            entity.HasKey(e => e.VisitFamilyHistoryId);

            entity.ToTable("EMRVisitFamilyHistory");

            entity.HasIndex(e => e.VisitId, "IX_VisitFamilyHistory_VisitID").HasFillFactor(90);

            entity.Property(e => e.VisitFamilyHistoryId).HasColumnName("VisitFamilyHistoryID");
            entity.Property(e => e.Age).HasMaxLength(50);
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CodeIcd10)
                .HasMaxLength(50)
                .HasColumnName("CodeICD10");
            entity.Property(e => e.CodeSnomed)
                .HasMaxLength(50)
                .HasColumnName("CodeSNOMED");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Dosdate)
                .HasColumnType("datetime")
                .HasColumnName("DOSDate");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.Relation).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<EmrvisitImmunization>(entity =>
        {
            entity.HasKey(e => e.VisitImmunizationId).HasName("PK__EMRVisitImmuniza__2C345F27");

            entity.ToTable("EMRVisitImmunizations");

            entity.Property(e => e.VisitImmunizationId).HasColumnName("VisitImmunizationID");
            entity.Property(e => e.AdministeredAmount).HasMaxLength(50);
            entity.Property(e => e.AdministeredUnits).HasMaxLength(100);
            entity.Property(e => e.DateTimeAdministered).HasColumnType("datetime");
            entity.Property(e => e.DateTimeAdministeredEnd).HasColumnType("datetime");
            entity.Property(e => e.Dosdate)
                .HasColumnType("datetime")
                .HasColumnName("DOSDate");
            entity.Property(e => e.LotNumber).HasMaxLength(100);
            entity.Property(e => e.ManufacturerMvxcode)
                .HasMaxLength(50)
                .HasColumnName("ManufacturerMVXCode");
            entity.Property(e => e.ManufacturerName).HasMaxLength(255);
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.Status).HasDefaultValue(1);
            entity.Property(e => e.SubstanceCvxcode)
                .HasMaxLength(100)
                .HasColumnName("SubstanceCVXCode");
            entity.Property(e => e.SubstanceName).HasMaxLength(255);
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<EmrvisitIop>(entity =>
        {
            entity.HasKey(e => e.TableId).HasName("PK__EMRVisitIOP__67E9567B");

            entity.ToTable("EMRVisitIOP");

            entity.HasIndex(e => e.PtId, "IX_VisitIOP_PtID").HasFillFactor(90);

            entity.HasIndex(e => e.VisitId, "IX_VisitIOP_VisitID").HasFillFactor(90);

            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.CornealHysteresisOd)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("CornealHysteresis_OD");
            entity.Property(e => e.CornealHysteresisOs)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("CornealHysteresis_OS");
            entity.Property(e => e.Dosdate)
                .HasColumnType("datetime")
                .HasColumnName("DOSDate");
            entity.Property(e => e.IopOd)
                .HasMaxLength(50)
                .HasColumnName("IOP_OD");
            entity.Property(e => e.IopOs)
                .HasMaxLength(50)
                .HasColumnName("IOP_OS");
            entity.Property(e => e.IopccOd)
                .HasMaxLength(50)
                .HasColumnName("IOPCC_OD");
            entity.Property(e => e.IopccOs)
                .HasMaxLength(50)
                .HasColumnName("IOPCC_OS");
            entity.Property(e => e.IopdeviceUsed)
                .HasMaxLength(50)
                .HasColumnName("IOPDeviceUsed");
            entity.Property(e => e.Iopnotes).HasColumnName("IOPNotes");
            entity.Property(e => e.IoptimeTaken)
                .HasColumnType("datetime")
                .HasColumnName("IOPTimeTaken");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<EmrvisitMedicalHistory>(entity =>
        {
            entity.HasKey(e => e.VisitMedicalHistoryId);

            entity.ToTable("EMRVisitMedicalHistory");

            entity.HasIndex(e => e.PtId, "IX_PtID").HasFillFactor(90);

            entity.HasIndex(e => new { e.PtId, e.VisitId, e.OrigVisitMedicalHistoryId }, "IX_PtID_VisitID_OrigVisitMedicalHistoryID").HasFillFactor(90);

            entity.HasIndex(e => e.VisitId, "IX_VisitMedicalHistory_VisitID").HasFillFactor(90);

            entity.Property(e => e.VisitMedicalHistoryId).HasColumnName("VisitMedicalHistoryID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CodeIcd10)
                .HasMaxLength(50)
                .HasColumnName("CodeICD10");
            entity.Property(e => e.CodeSnomed)
                .HasMaxLength(50)
                .HasColumnName("CodeSNOMED");
            entity.Property(e => e.ControlId).HasColumnName("ControlID");
            entity.Property(e => e.Created)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedEmpId).HasColumnName("CreatedEmpID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Dosdate)
                .HasColumnType("datetime")
                .HasColumnName("DOSDate");
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.IsResolved1).HasDefaultValue((short)0);
            entity.Property(e => e.IsResolved2).HasDefaultValue((short)0);
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedEmpId).HasColumnName("LastModifiedEmpID");
            entity.Property(e => e.Location1).HasMaxLength(50);
            entity.Property(e => e.Location2).HasMaxLength(50);
            entity.Property(e => e.Location2OnsetVisitId).HasColumnName("Location2OnsetVisitID");
            entity.Property(e => e.Modifier).HasMaxLength(50);
            entity.Property(e => e.OnsetDay1).HasMaxLength(10);
            entity.Property(e => e.OnsetDay2).HasMaxLength(10);
            entity.Property(e => e.OnsetMonth1).HasMaxLength(10);
            entity.Property(e => e.OnsetMonth2).HasMaxLength(10);
            entity.Property(e => e.OnsetYear1).HasMaxLength(10);
            entity.Property(e => e.OnsetYear2).HasMaxLength(10);
            entity.Property(e => e.OrigDosdate)
                .HasColumnType("datetime")
                .HasColumnName("OrigDOSDate");
            entity.Property(e => e.OrigVisitDiagCodePoolId).HasColumnName("OrigVisitDiagCodePoolID");
            entity.Property(e => e.OrigVisitMedicalHistoryId).HasColumnName("OrigVisitMedicalHistoryID");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.ResolveType1).HasMaxLength(75);
            entity.Property(e => e.ResolveType2).HasMaxLength(75);
            entity.Property(e => e.ResolvedDate1).HasColumnType("datetime");
            entity.Property(e => e.ResolvedDate2).HasColumnType("datetime");
            entity.Property(e => e.ResolvedRequestedProcedureId1).HasColumnName("ResolvedRequestedProcedureID1");
            entity.Property(e => e.ResolvedRequestedProcedureId2).HasColumnName("ResolvedRequestedProcedureID2");
            entity.Property(e => e.ResolvedVisitId1).HasColumnName("ResolvedVisitID1");
            entity.Property(e => e.ResolvedVisitId2).HasColumnName("ResolvedVisitID2");
            entity.Property(e => e.TypeId).HasColumnName("TypeID");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<EmrvisitOrder>(entity =>
        {
            entity.HasKey(e => e.VisitOrderId)
                .HasName("aaaaaEMRVisitOrders_PK")
                .IsClustered(false);

            entity.ToTable("EMRVisitOrders", tb => tb.HasTrigger("FF_TRIGGER_NEW_ORDER"));

            entity.HasIndex(e => e.PtId, "PTID").HasFillFactor(90);

            entity.HasIndex(e => e.VisitId, "VisitID").HasFillFactor(90);

            entity.HasIndex(e => e.VisitOrderId, "VisitTechID")
                .IsUnique()
                .HasFillFactor(90);

            entity.Property(e => e.VisitOrderId).HasColumnName("VisitOrderID");
            entity.Property(e => e.AddedbyFastPlanId).HasColumnName("AddedbyFastPlanID");
            entity.Property(e => e.CodeCpt)
                .HasMaxLength(50)
                .HasColumnName("CodeCPT");
            entity.Property(e => e.CodeLoinc)
                .HasMaxLength(20)
                .HasColumnName("CodeLOINC");
            entity.Property(e => e.CodeSnomed)
                .HasMaxLength(50)
                .HasColumnName("CodeSNOMED");
            entity.Property(e => e.DicomrequestedProcedureId)
                .HasMaxLength(50)
                .HasColumnName("DICOMRequestedProcedureID");
            entity.Property(e => e.DicomscheduledProcedureStepId)
                .HasMaxLength(50)
                .HasColumnName("DICOMScheduledProcedureStepID");
            entity.Property(e => e.Dosdate)
                .HasColumnType("datetime")
                .HasColumnName("DOSDate");
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.OrderLabResultFulfilledDate).HasColumnType("datetime");
            entity.Property(e => e.OrderLabResultId).HasColumnName("OrderLabResultID");
            entity.Property(e => e.OrderModalityId).HasColumnName("OrderModalityID");
            entity.Property(e => e.OrderRemarks).HasMaxLength(255);
            entity.Property(e => e.OrderScheduledDate).HasMaxLength(50);
            entity.Property(e => e.OrderSpecimenId).HasColumnName("OrderSpecimenID");
            entity.Property(e => e.OrderTypeId).HasColumnName("OrderTypeID");
            entity.Property(e => e.OrderWhen).HasMaxLength(255);
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.RefProviderFirstName).HasMaxLength(50);
            entity.Property(e => e.RefProviderId)
                .HasMaxLength(20)
                .HasColumnName("RefProviderID");
            entity.Property(e => e.RefProviderLastName).HasMaxLength(50);
            entity.Property(e => e.RefProviderOrganizationName).HasMaxLength(100);
            entity.Property(e => e.ScheduledAe)
                .HasMaxLength(65)
                .HasColumnName("ScheduledAE");
            entity.Property(e => e.StudyInstanceUid)
                .HasMaxLength(65)
                .HasColumnName("StudyInstanceUID");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<EmrvisitOrdersDiag>(entity =>
        {
            entity.HasKey(e => e.VisitOrderDiagId);

            entity.ToTable("EMRVisitOrdersDiag");

            entity.HasIndex(e => e.VisitOrderId, "IX_VisitOrdersDiag_VisitOrderID").HasFillFactor(90);

            entity.Property(e => e.VisitOrderDiagId).HasColumnName("VisitOrderDiagID");
            entity.Property(e => e.Dosdate)
                .HasColumnType("datetime")
                .HasColumnName("DOSDate");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.VisitDiagCodePoolId).HasColumnName("VisitDiagCodePoolID");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
            entity.Property(e => e.VisitOrderId).HasColumnName("VisitOrderID");
        });

        modelBuilder.Entity<EmrvisitPlanNarrative>(entity =>
        {
            entity.HasKey(e => e.EmrvisitPlanNarrativesId);

            entity.ToTable("EMRVisitPlanNarratives");

            entity.HasIndex(e => new { e.VisitId, e.PtId }, "IX_EMRVisitPlanNarratives")
                .IsDescending()
                .HasFillFactor(90);

            entity.Property(e => e.EmrvisitPlanNarrativesId).HasColumnName("EMRVisitPlanNarrativesID");
            entity.Property(e => e.Dosdate)
                .HasColumnType("datetime")
                .HasColumnName("DOSDate");
            entity.Property(e => e.Icd10code)
                .HasMaxLength(50)
                .HasColumnName("ICD10Code");
            entity.Property(e => e.Icd9code)
                .HasMaxLength(50)
                .HasColumnName("ICD9Code");
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.NarrativeHeader).HasMaxLength(255);
            entity.Property(e => e.NarrativeType).HasMaxLength(50);
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.Snomedcode)
                .HasMaxLength(50)
                .HasColumnName("SNOMEDCode");
            entity.Property(e => e.VisitDiagCodePoolId).HasColumnName("VisitDiagCodePoolID");
            entity.Property(e => e.VisitDoctorId).HasColumnName("VisitDoctorID");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<EmrvisitPlanNarrativeFragment>(entity =>
        {
            entity.HasKey(e => e.VisitPlanNarrativeFragmentId);

            entity.ToTable("EMRVisitPlanNarrativeFragment");

            entity.HasIndex(e => e.EmrvisitPlanNarrativesId, "IX_EMRVisitPlanNarrativeFragment").HasFillFactor(90);

            entity.Property(e => e.VisitPlanNarrativeFragmentId).HasColumnName("VisitPlanNarrativeFragmentID");
            entity.Property(e => e.Created)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedEmpId).HasColumnName("CreatedEmpID");
            entity.Property(e => e.EmrvisitPlanNarrativesId).HasColumnName("EMRVisitPlanNarrativesID");
            entity.Property(e => e.FastPlanNarrativeFragmentId).HasColumnName("FastPlanNarrativeFragmentID");
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedEmpId).HasColumnName("LastModifiedEmpID");
            entity.Property(e => e.NarrativeType).HasMaxLength(50);
            entity.Property(e => e.ShortHand).HasMaxLength(20);
            entity.Property(e => e.Snomedcode)
                .HasMaxLength(50)
                .HasColumnName("SNOMEDCode");
        });

        modelBuilder.Entity<EmrvisitProc>(entity =>
        {
            entity.HasKey(e => e.VisitProcId)
                .HasName("aaaaaEMRVisitProc_PK")
                .IsClustered(false);

            entity.ToTable("EMRVisitProc");

            entity.HasIndex(e => e.MdreviewedEmpId, "MDReviewedEmpID").HasFillFactor(90);

            entity.HasIndex(e => e.PtId, "PtID").HasFillFactor(90);

            entity.HasIndex(e => e.VisitId, "VisitID").HasFillFactor(90);

            entity.HasIndex(e => e.VisitProcId, "VisitTechID")
                .IsUnique()
                .HasFillFactor(90);

            entity.Property(e => e.VisitProcId).HasColumnName("VisitProcID");
            entity.Property(e => e.Dosdate)
                .HasColumnType("datetime")
                .HasColumnName("DOSDate");
            entity.Property(e => e.GlobalPodays).HasColumnName("GlobalPODays");
            entity.Property(e => e.GlobalPoendDate)
                .HasColumnType("datetime")
                .HasColumnName("GlobalPOEndDate");
            entity.Property(e => e.GlobalPostartDate)
                .HasColumnType("datetime")
                .HasColumnName("GlobalPOStartDate");
            entity.Property(e => e.HasGlobal).HasDefaultValue((short)0);
            entity.Property(e => e.Mdreviewed).HasColumnName("MDReviewed");
            entity.Property(e => e.MdreviewedDate)
                .HasColumnType("datetime")
                .HasColumnName("MDReviewedDate");
            entity.Property(e => e.MdreviewedEmpId).HasColumnName("MDReviewedEmpID");
            entity.Property(e => e.ProcCustom10Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom11Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom12Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom13Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom14Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom15Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom16Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom17Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom18Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom19Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom1Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom20Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom21Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom22Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom2Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom3Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom4Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom5Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom6Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom7Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom8Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom9Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustomDateData).HasMaxLength(50);
            entity.Property(e => e.ProcCustomDateDesc).HasMaxLength(50);
            entity.Property(e => e.ProcDescription).HasMaxLength(255);
            entity.Property(e => e.ProcNoteDescription).HasMaxLength(255);
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<EmrvisitProcCodePool>(entity =>
        {
            entity.HasKey(e => e.VisitProcCodePoolId)
                .HasName("aaaaaEMRVisitProcCodePool_PK")
                .IsClustered(false);

            entity.ToTable("EMRVisitProcCodePool");

            entity.HasIndex(e => e.Code, "Code").HasFillFactor(90);

            entity.HasIndex(e => e.ControlId, "ControlID").HasFillFactor(90);

            entity.HasIndex(e => new { e.IsBilled, e.IsHidden }, "IX_CodingSent").HasFillFactor(90);

            entity.HasIndex(e => new { e.InsertGuid, e.VisitProcCodePoolId }, "IX_EMRVisitProcCodePool_9_1947870006__K29_K1").HasFillFactor(90);

            entity.HasIndex(e => e.PtId, "PTID").HasFillFactor(90);

            entity.HasIndex(e => e.VisitId, "VisitID").HasFillFactor(90);

            entity.HasIndex(e => e.VisitProcCodePoolId, "VisitTechID")
                .IsUnique()
                .HasFillFactor(90);

            entity.Property(e => e.VisitProcCodePoolId).HasColumnName("VisitProcCodePoolID");
            entity.Property(e => e.AdditionalModifier).HasMaxLength(50);
            entity.Property(e => e.BillMultiProcControlId).HasColumnName("BillMultiProcControlID");
            entity.Property(e => e.BillMultiProcId).HasColumnName("BillMultiProcID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.ControlId).HasColumnName("ControlID");
            entity.Property(e => e.Dosdate)
                .HasColumnType("datetime")
                .HasColumnName("DOSDate");
            entity.Property(e => e.EyeMdqrnum)
                .HasMaxLength(50)
                .HasColumnName("EyeMDQRNum");
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.IsQr).HasColumnName("IsQR");
            entity.Property(e => e.Location).HasMaxLength(50);
            entity.Property(e => e.Modifier).HasMaxLength(50);
            entity.Property(e => e.NotPorelated)
                .HasDefaultValue((short)0)
                .HasColumnName("NotPORelated");
            entity.Property(e => e.Nqfnum)
                .HasMaxLength(50)
                .HasColumnName("NQFNum");
            entity.Property(e => e.OriginalModifier).HasMaxLength(50);
            entity.Property(e => e.Pqrsnum)
                .HasMaxLength(50)
                .HasColumnName("PQRSNum");
            entity.Property(e => e.ProcDiagTestComponents).HasComment("True = Can Split Technical & Professional Components");
            entity.Property(e => e.ProcLocationType).HasComment("1 = Not Location Specific, 2 = Unilateral/Lid Specific - Add Location Modifiers,  3=Bilateral - Do not add Location Modifiers, 4 = Bilateral - Add Location and 52 if not both eyes.");
            entity.Property(e => e.ProcText).HasMaxLength(255);
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.Qrcomponent)
                .HasMaxLength(50)
                .HasColumnName("QRComponent");
            entity.Property(e => e.RequestedProcedureId).HasColumnName("RequestedProcedureID");
            entity.Property(e => e.SourceField).HasMaxLength(50);
            entity.Property(e => e.SourceRecordId).HasColumnName("SourceRecordID");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<EmrvisitProcCodePoolDiag>(entity =>
        {
            entity.HasKey(e => e.VisitProcCodePoolDiagId)
                .HasName("aaaaaEMRVisitProcCodePoolDiag_PK")
                .IsClustered(false);

            entity.ToTable("EMRVisitProcCodePoolDiag");

            entity.HasIndex(e => e.ControlId, "ControlID").HasFillFactor(90);

            entity.HasIndex(e => e.PtId, "PTID").HasFillFactor(90);

            entity.HasIndex(e => e.VisitId, "VisitID").HasFillFactor(90);

            entity.HasIndex(e => e.VisitProcCodePoolId, "VisitProcCodePoolID").HasFillFactor(90);

            entity.HasIndex(e => e.VisitDiagCodePoolId, "VisitProcCodePoolID1").HasFillFactor(90);

            entity.HasIndex(e => e.VisitProcCodePoolDiagId, "VisitTechID")
                .IsUnique()
                .HasFillFactor(90);

            entity.Property(e => e.VisitProcCodePoolDiagId).HasColumnName("VisitProcCodePoolDiagID");
            entity.Property(e => e.ControlId).HasColumnName("ControlID");
            entity.Property(e => e.Dosdate)
                .HasColumnType("datetime")
                .HasColumnName("DOSDate");
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.RequestedProcedureId).HasColumnName("RequestedProcedureID");
            entity.Property(e => e.VisitDiagCodePoolId).HasColumnName("VisitDiagCodePoolID");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
            entity.Property(e => e.VisitProcCodePoolId).HasColumnName("VisitProcCodePoolID");
        });

        modelBuilder.Entity<EmrvisitRefraction>(entity =>
        {
            entity.HasKey(e => e.RefractionId);

            entity.ToTable("EMRVisitRefractions");

            entity.HasIndex(e => new { e.PtId, e.VisitId }, "IX_EMRVisitRefractions")
                .IsDescending()
                .HasFillFactor(90);

            entity.HasIndex(e => e.VisitId, "IX_EMRVisitRefractions_VisitID").HasFillFactor(90);

            entity.Property(e => e.RefractionId).HasColumnName("RefractionID");
            entity.Property(e => e.Age).HasMaxLength(50);
            entity.Property(e => e.AxisOd)
                .HasMaxLength(50)
                .HasColumnName("Axis_OD");
            entity.Property(e => e.AxisOs)
                .HasMaxLength(50)
                .HasColumnName("Axis_OS");
            entity.Property(e => e.BifocalAddOd)
                .HasMaxLength(50)
                .HasColumnName("Bifocal_Add_OD");
            entity.Property(e => e.BifocalAddOs)
                .HasMaxLength(50)
                .HasColumnName("Bifocal_Add_OS");
            entity.Property(e => e.CylinderOd)
                .HasMaxLength(50)
                .HasColumnName("Cylinder_OD");
            entity.Property(e => e.CylinderOs)
                .HasMaxLength(50)
                .HasColumnName("Cylinder_OS");
            entity.Property(e => e.DirectionOd)
                .HasMaxLength(50)
                .HasColumnName("Direction_OD");
            entity.Property(e => e.DirectionOs)
                .HasMaxLength(50)
                .HasColumnName("Direction_OS");
            entity.Property(e => e.Dosdate)
                .HasColumnType("datetime")
                .HasColumnName("DOSDate");
            entity.Property(e => e.EnteredBy).HasMaxLength(200);
            entity.Property(e => e.Expires).HasMaxLength(50);
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(40)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.PdDistOd)
                .HasMaxLength(50)
                .HasColumnName("PD_Dist_OD");
            entity.Property(e => e.PdDistOs)
                .HasMaxLength(50)
                .HasColumnName("PD_Dist_OS");
            entity.Property(e => e.PdNearOd)
                .HasMaxLength(50)
                .HasColumnName("PD_Near_OD");
            entity.Property(e => e.PdNearOs)
                .HasMaxLength(50)
                .HasColumnName("PD_Near_OS");
            entity.Property(e => e.Prism360Od)
                .HasMaxLength(50)
                .HasColumnName("Prism_360_OD");
            entity.Property(e => e.Prism360Os)
                .HasMaxLength(50)
                .HasColumnName("Prism_360_OS");
            entity.Property(e => e.PrismTypeOd)
                .HasMaxLength(255)
                .HasColumnName("PrismType_OD");
            entity.Property(e => e.PrismTypeOs)
                .HasMaxLength(255)
                .HasColumnName("PrismType_OS");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.RefractionClass).HasMaxLength(5);
            entity.Property(e => e.RefractionType).HasMaxLength(50);
            entity.Property(e => e.SphereOd)
                .HasMaxLength(50)
                .HasColumnName("Sphere_OD");
            entity.Property(e => e.SphereOs)
                .HasMaxLength(50)
                .HasColumnName("Sphere_OS");
            entity.Property(e => e.VaDOd)
                .HasMaxLength(50)
                .HasColumnName("VaD_OD");
            entity.Property(e => e.VaDOs)
                .HasMaxLength(50)
                .HasColumnName("VaD_OS");
            entity.Property(e => e.VaDOu)
                .HasMaxLength(50)
                .HasColumnName("VaD_OU");
            entity.Property(e => e.VaIOd)
                .HasMaxLength(50)
                .HasColumnName("VaI_OD");
            entity.Property(e => e.VaIOs)
                .HasMaxLength(50)
                .HasColumnName("VaI_OS");
            entity.Property(e => e.VaIOu)
                .HasMaxLength(50)
                .HasColumnName("VaI_OU");
            entity.Property(e => e.VaNOd)
                .HasMaxLength(50)
                .HasColumnName("VaN_OD");
            entity.Property(e => e.VaNOs)
                .HasMaxLength(50)
                .HasColumnName("VaN_OS");
            entity.Property(e => e.VaNOu)
                .HasMaxLength(50)
                .HasColumnName("VaN_OU");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<EmrvisitRxMedication>(entity =>
        {
            entity.HasKey(e => e.VisitMedicationId)
                .HasName("aaaaaEMRVisitRxMedications_PK")
                .IsClustered(false);

            entity.ToTable("EMRVisitRxMedications");

            entity.HasIndex(e => new { e.PtId, e.ErxPendingTransmit }, "IX_EMRVisitRxMedications").HasFillFactor(90);

            entity.HasIndex(e => new { e.VisitId, e.PtId, e.MedName }, "IX_EMRVisitRxMedications_9_2059870405__K2_K3_K5_1").HasFillFactor(90);

            entity.HasIndex(e => new { e.PtId, e.Dosdate }, "IX_EMRVisitRxMedications_9_2059870405__K3_K4_2").HasFillFactor(90);

            entity.HasIndex(e => e.PtId, "PTID").HasFillFactor(90);

            entity.HasIndex(e => e.VisitId, "VisitID").HasFillFactor(90);

            entity.HasIndex(e => e.VisitMedicationId, "VisitTechID")
                .IsUnique()
                .HasFillFactor(90);

            entity.Property(e => e.VisitMedicationId).HasColumnName("VisitMedicationID");
            entity.Property(e => e.CalledInLocationId).HasColumnName("CalledInLocationID");
            entity.Property(e => e.CalledInProviderEmpId).HasColumnName("CalledInProviderEmpID");
            entity.Property(e => e.Created)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedEmpId).HasColumnName("CreatedEmpID");
            entity.Property(e => e.Dosdate)
                .HasColumnType("datetime")
                .HasColumnName("DOSDate");
            entity.Property(e => e.DrugAltMappingId)
                .HasMaxLength(100)
                .HasColumnName("DrugAltMappingID");
            entity.Property(e => e.DrugDeaclass)
                .HasMaxLength(25)
                .HasColumnName("DrugDEAClass");
            entity.Property(e => e.DrugFdastatus)
                .HasMaxLength(50)
                .HasColumnName("DrugFDAStatus");
            entity.Property(e => e.DrugForm).HasMaxLength(100);
            entity.Property(e => e.DrugMappingId)
                .HasMaxLength(100)
                .HasColumnName("DrugMappingID");
            entity.Property(e => e.DrugName).HasMaxLength(200);
            entity.Property(e => e.DrugNameId)
                .HasMaxLength(100)
                .HasColumnName("DrugNameID");
            entity.Property(e => e.DrugRoute).HasMaxLength(100);
            entity.Property(e => e.DrugStrength).HasMaxLength(100);
            entity.Property(e => e.ErxGuid)
                .HasMaxLength(50)
                .HasColumnName("ERxGUID");
            entity.Property(e => e.ErxPendingTransmit).HasColumnName("ERxPendingTransmit");
            entity.Property(e => e.ErxStatus)
                .HasMaxLength(100)
                .HasColumnName("ERxStatus");
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedEmpId).HasColumnName("LastModifiedEmpID");
            entity.Property(e => e.MedDisp).HasMaxLength(255);
            entity.Property(e => e.MedDispUnitType).HasMaxLength(100);
            entity.Property(e => e.MedName).HasMaxLength(255);
            entity.Property(e => e.MedRefill).HasMaxLength(255);
            entity.Property(e => e.MedSig).HasMaxLength(255);
            entity.Property(e => e.MedTableId).HasColumnName("MedTableID");
            entity.Property(e => e.MedType).HasComment("1 = Eye Medications, 2 =Systemic Medications");
            entity.Property(e => e.OriginalMedicationDate).HasMaxLength(50);
            entity.Property(e => e.OriginalMedicationId)
                .HasMaxLength(255)
                .HasColumnName("OriginalMedicationID");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.RxEndDate).HasColumnType("datetime");
            entity.Property(e => e.RxRemarks).HasMaxLength(255);
            entity.Property(e => e.RxStartDate).HasColumnType("datetime");
            entity.Property(e => e.Rxcui)
                .HasMaxLength(50)
                .HasColumnName("RXCUI");
            entity.Property(e => e.SentViaErx).HasColumnName("SentViaERx");
            entity.Property(e => e.Snomed)
                .HasMaxLength(50)
                .HasColumnName("SNOMED");
            entity.Property(e => e.VisitDiagCodePoolId).HasColumnName("VisitDiagCodePoolID");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<EmrvisitSurgicalHistory>(entity =>
        {
            entity.HasKey(e => e.VisitSurgicalHistoryId);

            entity.ToTable("EMRVisitSurgicalHistory");

            entity.HasIndex(e => e.PtId, "IX_PtID").HasFillFactor(90);

            entity.HasIndex(e => e.VisitId, "IX_VisitSurgicalHistory_VisitID").HasFillFactor(90);

            entity.Property(e => e.VisitSurgicalHistoryId).HasColumnName("VisitSurgicalHistoryID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CodeIcd10)
                .HasMaxLength(50)
                .HasColumnName("CodeICD10");
            entity.Property(e => e.CodeId).HasColumnName("CodeID");
            entity.Property(e => e.CodeSnomed)
                .HasMaxLength(50)
                .HasColumnName("CodeSNOMED");
            entity.Property(e => e.ComanageEmpId1).HasColumnName("ComanageEmpID1");
            entity.Property(e => e.ComanageEmpId2).HasColumnName("ComanageEmpID2");
            entity.Property(e => e.ComanageFullName1).HasMaxLength(100);
            entity.Property(e => e.ComanageFullName2).HasMaxLength(100);
            entity.Property(e => e.ComanageRefProviderId1).HasColumnName("ComanageRefProviderID1");
            entity.Property(e => e.ComanageRefProviderId2).HasColumnName("ComanageRefProviderID2");
            entity.Property(e => e.ControlId).HasColumnName("ControlID");
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.CreatedEmpId).HasColumnName("CreatedEmpID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedEmpId).HasColumnName("LastModifiedEmpID");
            entity.Property(e => e.Location1).HasMaxLength(50);
            entity.Property(e => e.Location2).HasMaxLength(50);
            entity.Property(e => e.Modifier).HasMaxLength(50);
            entity.Property(e => e.OrigVisitDate).HasColumnType("datetime");
            entity.Property(e => e.OrigVisitSurgicalHistoryId).HasColumnName("OrigVisitSurgicalHistoryID");
            entity.Property(e => e.PerformedbyEmpId1).HasColumnName("PerformedbyEmpID1");
            entity.Property(e => e.PerformedbyEmpId2).HasColumnName("PerformedbyEmpID2");
            entity.Property(e => e.PerformedbyFullName1).HasMaxLength(100);
            entity.Property(e => e.PerformedbyFullName2).HasMaxLength(100);
            entity.Property(e => e.PerformedbyRefProviderId1).HasColumnName("PerformedbyRefProviderID1");
            entity.Property(e => e.PerformedbyRefProviderId2).HasColumnName("PerformedbyRefProviderID2");
            entity.Property(e => e.ProcedureDay1).HasMaxLength(10);
            entity.Property(e => e.ProcedureDay2).HasMaxLength(10);
            entity.Property(e => e.ProcedureMonth1).HasMaxLength(10);
            entity.Property(e => e.ProcedureMonth2).HasMaxLength(10);
            entity.Property(e => e.ProcedureYear1).HasMaxLength(10);
            entity.Property(e => e.ProcedureYear2).HasMaxLength(10);
            entity.Property(e => e.PtDeviceId).HasColumnName("PtDeviceID");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.TypeId).HasColumnName("TypeID");
            entity.Property(e => e.VisitDate).HasColumnType("datetime");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<EmrvisitTech>(entity =>
        {
            entity.HasKey(e => e.VisitTechId)
                .HasName("aaaaaEMRVisitTech_PK")
                .IsClustered(false);

            entity.ToTable("EMRVisitTech");

            entity.HasIndex(e => e.VisitTechId, "EMRVisitTechID")
                .IsUnique()
                .HasFillFactor(90);

            entity.HasIndex(e => new { e.PtId, e.Dosdate, e.WudilatedTime, e.Wudilated }, "IX_EMRVisitTech_PatientFlowIndex").HasFillFactor(90);

            entity.HasIndex(e => e.PtId, "PTID").HasFillFactor(90);

            entity.HasIndex(e => e.VisitId, "VisitID").HasFillFactor(90);

            entity.Property(e => e.VisitTechId).HasColumnName("VisitTechID");
            entity.Property(e => e.Created)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedEmpId).HasColumnName("CreatedEmpID");
            entity.Property(e => e.Dosdate)
                .HasColumnType("datetime")
                .HasColumnName("DOSDate");
            entity.Property(e => e.HistoryMdreviewed).HasColumnName("HistoryMDReviewed");
            entity.Property(e => e.HistoryMdreviewedDate)
                .HasColumnType("datetime")
                .HasColumnName("HistoryMDReviewedDate");
            entity.Property(e => e.HistoryMdreviewedEmpId).HasColumnName("HistoryMDReviewedEmpID");
            entity.Property(e => e.Hpi1letterText).HasColumnName("HPI1LetterText");
            entity.Property(e => e.HpiadditionalComments1).HasColumnName("HPIAdditionalComments1");
            entity.Property(e => e.HpiassoSignsSymp1)
                .HasMaxLength(255)
                .HasColumnName("HPIAssoSignsSymp1");
            entity.Property(e => e.HpichiefComplaint)
                .HasMaxLength(255)
                .HasColumnName("HPIChiefComplaint");
            entity.Property(e => e.Hpicontext1)
                .HasMaxLength(255)
                .HasColumnName("HPIContext1");
            entity.Property(e => e.Hpiduration1)
                .HasMaxLength(255)
                .HasColumnName("HPIDuration1");
            entity.Property(e => e.Hpilocation1)
                .HasMaxLength(255)
                .HasColumnName("HPILocation1");
            entity.Property(e => e.HpimodFactors1)
                .HasMaxLength(255)
                .HasColumnName("HPIModFactors1");
            entity.Property(e => e.Hpiquality1)
                .HasMaxLength(255)
                .HasColumnName("HPIQuality1");
            entity.Property(e => e.Hpiseverity1)
                .HasMaxLength(255)
                .HasColumnName("HPISeverity1");
            entity.Property(e => e.Hpitiming1)
                .HasMaxLength(255)
                .HasColumnName("HPITiming1");
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedEmpId).HasColumnName("LastModifiedEmpID");
            entity.Property(e => e.Pmhalcohol).HasColumnName("PMHAlcohol");
            entity.Property(e => e.PmhalcoholHowMuch)
                .HasMaxLength(50)
                .HasColumnName("PMHAlcoholHowMuch");
            entity.Property(e => e.Pmhdrugs).HasColumnName("PMHDrugs");
            entity.Property(e => e.PmhdrugsHowLong)
                .HasMaxLength(50)
                .HasColumnName("PMHDrugsHowLong");
            entity.Property(e => e.PmhdrugsHowMuch)
                .HasMaxLength(50)
                .HasColumnName("PMHDrugsHowMuch");
            entity.Property(e => e.PmhdrugsNames).HasColumnName("PMHDrugsNames");
            entity.Property(e => e.PmhdrugsWhenQuit)
                .HasMaxLength(50)
                .HasColumnName("PMHDrugsWhenQuit");
            entity.Property(e => e.Pmhfhother).HasColumnName("PMHFHOther");
            entity.Property(e => e.PmhsmokeHowLong)
                .HasMaxLength(50)
                .HasColumnName("PMHSmokeHowLong");
            entity.Property(e => e.PmhsmokeHowMuch)
                .HasMaxLength(50)
                .HasColumnName("PMHSmokeHowMuch");
            entity.Property(e => e.PmhsmokeWhenQuit)
                .HasMaxLength(50)
                .HasColumnName("PMHSmokeWhenQuit");
            entity.Property(e => e.Pmhsmoking).HasColumnName("PMHSmoking");
            entity.Property(e => e.PmhsmokingStatus)
                .HasMaxLength(100)
                .HasColumnName("PMHSmokingStatus");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.UpsizeTs)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("upsize_ts");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
            entity.Property(e => e.VitalsBgl)
                .HasMaxLength(50)
                .HasColumnName("VitalsBGL");
            entity.Property(e => e.VitalsBglunits)
                .HasMaxLength(50)
                .HasColumnName("VitalsBGLUnits");
            entity.Property(e => e.VitalsBmi)
                .HasMaxLength(50)
                .HasColumnName("VitalsBMI");
            entity.Property(e => e.VitalsBmipercentile)
                .HasColumnType("decimal(9, 8)")
                .HasColumnName("VitalsBMIPercentile");
            entity.Property(e => e.VitalsBpdia)
                .HasMaxLength(50)
                .HasColumnName("VitalsBPDia");
            entity.Property(e => e.VitalsBpsys)
                .HasMaxLength(50)
                .HasColumnName("VitalsBPSys");
            entity.Property(e => e.VitalsHeight).HasMaxLength(50);
            entity.Property(e => e.VitalsHeightUnits).HasMaxLength(50);
            entity.Property(e => e.VitalsHofcpercentile)
                .HasColumnType("decimal(9, 8)")
                .HasColumnName("VitalsHOFCPercentile");
            entity.Property(e => e.VitalsInhaled02Concentration).HasColumnType("decimal(9, 8)");
            entity.Property(e => e.VitalsPulse).HasMaxLength(50);
            entity.Property(e => e.VitalsPulseOximetry).HasColumnType("decimal(9, 8)");
            entity.Property(e => e.VitalsRespRate).HasMaxLength(255);
            entity.Property(e => e.VitalsTemp).HasMaxLength(50);
            entity.Property(e => e.VitalsTempUnits).HasMaxLength(50);
            entity.Property(e => e.VitalsWeight).HasMaxLength(50);
            entity.Property(e => e.VitalsWeightUnits).HasMaxLength(50);
            entity.Property(e => e.VitalsWflpercentile)
                .HasColumnType("decimal(9, 8)")
                .HasColumnName("VitalsWFLPercentile");
            entity.Property(e => e.WorkupMdreviewed).HasColumnName("WorkupMDReviewed");
            entity.Property(e => e.WorkupMdreviewedDate)
                .HasColumnType("datetime")
                .HasColumnName("WorkupMDReviewedDate");
            entity.Property(e => e.WorkupMdreviewedEmpId).HasColumnName("WorkupMDReviewedEmpID");
            entity.Property(e => e.WuamslerOd)
                .HasMaxLength(255)
                .HasColumnName("WUAmsler_OD");
            entity.Property(e => e.WuamslerOs)
                .HasMaxLength(255)
                .HasColumnName("WUAmsler_OS");
            entity.Property(e => e.WucvfAbute)
                .HasDefaultValue((short)0)
                .HasColumnName("WUCVF_ABUTE");
            entity.Property(e => e.WucvfdiagOd).HasColumnName("WUCVFDiag_OD");
            entity.Property(e => e.WucvfdiagOs).HasColumnName("WUCVFDiag_OS");
            entity.Property(e => e.Wudilated).HasColumnName("WUDilated");
            entity.Property(e => e.WudilatedAgent)
                .HasMaxLength(255)
                .HasColumnName("WUDilatedAgent");
            entity.Property(e => e.WudilatedEye)
                .HasMaxLength(50)
                .HasColumnName("WUDilatedEye");
            entity.Property(e => e.WudilatedFrequency)
                .HasMaxLength(255)
                .HasColumnName("WUDilatedFrequency");
            entity.Property(e => e.WudilatedTime)
                .HasColumnType("datetime")
                .HasColumnName("WUDilatedTime");
            entity.Property(e => e.WudilatedTimeZone).HasColumnName("WUDilatedTimeZone");
            entity.Property(e => e.WudomEye)
                .HasMaxLength(50)
                .HasColumnName("WUDomEye");
            entity.Property(e => e.WueomInNaOd)
                .HasMaxLength(50)
                .HasColumnName("WUEOM_In_Na_OD");
            entity.Property(e => e.WueomInNaOs)
                .HasMaxLength(50)
                .HasColumnName("WUEOM_In_Na_OS");
            entity.Property(e => e.WueomInTmOd)
                .HasMaxLength(50)
                .HasColumnName("WUEOM_In_Tm_OD");
            entity.Property(e => e.WueomInTmOs)
                .HasMaxLength(50)
                .HasColumnName("WUEOM_In_Tm_OS");
            entity.Property(e => e.WueomMedialOd)
                .HasMaxLength(50)
                .HasColumnName("WUEOM_Medial_OD");
            entity.Property(e => e.WueomMedialOs)
                .HasMaxLength(50)
                .HasColumnName("WUEOM_Medial_OS");
            entity.Property(e => e.WueomSuNaOd)
                .HasMaxLength(50)
                .HasColumnName("WUEOM_Su_Na_OD");
            entity.Property(e => e.WueomSuNaOs)
                .HasMaxLength(50)
                .HasColumnName("WUEOM_Su_Na_OS");
            entity.Property(e => e.WueomSuTmOd)
                .HasMaxLength(50)
                .HasColumnName("WUEOM_Su_Tm_OD");
            entity.Property(e => e.WueomSuTmOs)
                .HasMaxLength(50)
                .HasColumnName("WUEOM_Su_Tm_OS");
            entity.Property(e => e.WueomTemporalOd)
                .HasMaxLength(50)
                .HasColumnName("WUEOM_Temporal_OD");
            entity.Property(e => e.WueomTemporalOs)
                .HasMaxLength(50)
                .HasColumnName("WUEOM_Temporal_OS");
            entity.Property(e => e.WueomType)
                .HasMaxLength(255)
                .HasColumnName("WUEOM_Type");
            entity.Property(e => e.Wuextlids).HasColumnName("WUEXTLids");
            entity.Property(e => e.Wuextorbits).HasColumnName("WUEXTOrbits");
            entity.Property(e => e.Wuextpan).HasColumnName("WUEXTPAN");
            entity.Property(e => e.WuiopAbute)
                .HasDefaultValue((short)0)
                .HasColumnName("WUIOP_ABUTE");
            entity.Property(e => e.Wumood).HasColumnName("WUMood");
            entity.Property(e => e.WunCcOd)
                .HasMaxLength(50)
                .HasColumnName("WUN_CC_OD");
            entity.Property(e => e.WunCcOs)
                .HasMaxLength(50)
                .HasColumnName("WUN_CC_OS");
            entity.Property(e => e.WunCcOu)
                .HasMaxLength(50)
                .HasColumnName("WUN_CC_OU");
            entity.Property(e => e.WunScOd)
                .HasMaxLength(50)
                .HasColumnName("WUN_SC_OD");
            entity.Property(e => e.WunScOs)
                .HasMaxLength(50)
                .HasColumnName("WUN_SC_OS");
            entity.Property(e => e.WunScOu)
                .HasMaxLength(50)
                .HasColumnName("WUN_SC_OU");
            entity.Property(e => e.Wunotes).HasColumnName("WUNotes");
            entity.Property(e => e.WuorientPerson).HasColumnName("WUOrientPerson");
            entity.Property(e => e.WuorientPlace).HasColumnName("WUOrientPlace");
            entity.Property(e => e.WuorientSituation).HasColumnName("WUOrientSituation");
            entity.Property(e => e.WuorientTime).HasColumnName("WUOrientTime");
            entity.Property(e => e.WupupilApdOd)
                .HasMaxLength(50)
                .HasColumnName("WUPupilAPD_OD");
            entity.Property(e => e.WupupilApdOs)
                .HasMaxLength(50)
                .HasColumnName("WUPupilAPD_OS");
            entity.Property(e => e.WupupilDarkSizeOd)
                .HasMaxLength(50)
                .HasColumnName("WUPupilDarkSize_OD");
            entity.Property(e => e.WupupilDarkSizeOs)
                .HasMaxLength(50)
                .HasColumnName("WUPupilDarkSize_OS");
            entity.Property(e => e.WupupilLightSizeOd)
                .HasMaxLength(50)
                .HasColumnName("WUPupilLightSize_OD");
            entity.Property(e => e.WupupilLightSizeOs)
                .HasMaxLength(50)
                .HasColumnName("WUPupilLightSize_OS");
            entity.Property(e => e.WupupilNearOd)
                .HasMaxLength(50)
                .HasColumnName("WUPupilNear_OD");
            entity.Property(e => e.WupupilNearOs)
                .HasMaxLength(50)
                .HasColumnName("WUPupilNear_OS");
            entity.Property(e => e.WupupilReactionOd)
                .HasMaxLength(50)
                .HasColumnName("WUPupilReaction_OD");
            entity.Property(e => e.WupupilReactionOs)
                .HasMaxLength(50)
                .HasColumnName("WUPupilReaction_OS");
            entity.Property(e => e.WupupilShapeOd)
                .HasMaxLength(50)
                .HasColumnName("WUPupilShape_OD");
            entity.Property(e => e.WupupilShapeOs)
                .HasMaxLength(50)
                .HasColumnName("WUPupilShape_OS");
            entity.Property(e => e.WutcvfOd)
                .HasMaxLength(50)
                .HasColumnName("WUTCVF_OD");
            entity.Property(e => e.WutcvfOs)
                .HasMaxLength(50)
                .HasColumnName("WUTCVF_OS");
            entity.Property(e => e.WuvaCcOd)
                .HasMaxLength(50)
                .HasColumnName("WUVA_CC_OD");
            entity.Property(e => e.WuvaCcOs)
                .HasMaxLength(50)
                .HasColumnName("WUVA_CC_OS");
            entity.Property(e => e.WuvaCcOu)
                .HasMaxLength(50)
                .HasColumnName("WUVA_CC_OU");
            entity.Property(e => e.WuvaCcType)
                .HasDefaultValue(1)
                .HasComment("1=Spectacles, 2=Contact Lens")
                .HasColumnName("WUVA_CC_Type");
            entity.Property(e => e.WuvaPhOd)
                .HasMaxLength(50)
                .HasColumnName("WUVA_PH_OD");
            entity.Property(e => e.WuvaPhOs)
                .HasMaxLength(50)
                .HasColumnName("WUVA_PH_OS");
            entity.Property(e => e.WuvaScOd)
                .HasMaxLength(50)
                .HasColumnName("WUVA_SC_OD");
            entity.Property(e => e.WuvaScOs)
                .HasMaxLength(50)
                .HasColumnName("WUVA_SC_OS");
            entity.Property(e => e.WuvaScOu)
                .HasMaxLength(50)
                .HasColumnName("WUVA_SC_OU");
            entity.Property(e => e.WuvaTestUsed)
                .HasMaxLength(50)
                .HasColumnName("WUVA_TestUsed");
        });

        modelBuilder.Entity<EmrvisitTech2>(entity =>
        {
            entity.HasKey(e => e.VisitTech2Id)
                .HasName("aaaaaEMRVisitTech2_PK")
                .IsClustered(false);

            entity.ToTable("EMRVisitTech2");

            entity.HasIndex(e => e.PtId, "PtID").HasFillFactor(90);

            entity.HasIndex(e => e.VisitId, "VisitID").HasFillFactor(90);

            entity.HasIndex(e => e.VisitTech2Id, "VisitTechID")
                .IsUnique()
                .HasFillFactor(90);

            entity.Property(e => e.VisitTech2Id).HasColumnName("VisitTech2ID");
            entity.Property(e => e.Dosdate)
                .HasColumnType("datetime")
                .HasColumnName("DOSDate");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.UpsizeTs)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("upsize_ts");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
            entity.Property(e => e.Wu2GlareHighOd)
                .HasMaxLength(50)
                .HasColumnName("WU2_Glare_High_OD");
            entity.Property(e => e.Wu2GlareHighOs)
                .HasMaxLength(50)
                .HasColumnName("WU2_Glare_High_OS");
            entity.Property(e => e.Wu2GlareLowOd)
                .HasMaxLength(50)
                .HasColumnName("WU2_Glare_Low_OD");
            entity.Property(e => e.Wu2GlareLowOs)
                .HasMaxLength(50)
                .HasColumnName("WU2_Glare_Low_OS");
            entity.Property(e => e.Wu2GlareMedOd)
                .HasMaxLength(50)
                .HasColumnName("WU2_Glare_Med_OD");
            entity.Property(e => e.Wu2GlareMedOs)
                .HasMaxLength(50)
                .HasColumnName("WU2_Glare_Med_OS");
            entity.Property(e => e.Wu2GlareType)
                .HasMaxLength(50)
                .HasColumnName("WU2_Glare_Type");
            entity.Property(e => e.Wu2custom10Data).HasColumnName("WU2Custom10Data");
            entity.Property(e => e.Wu2custom10Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom10Desc");
            entity.Property(e => e.Wu2custom11Data).HasColumnName("WU2Custom11Data");
            entity.Property(e => e.Wu2custom11Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom11Desc");
            entity.Property(e => e.Wu2custom12Data).HasColumnName("WU2Custom12Data");
            entity.Property(e => e.Wu2custom12Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom12Desc");
            entity.Property(e => e.Wu2custom13Data).HasColumnName("WU2Custom13Data");
            entity.Property(e => e.Wu2custom13Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom13Desc");
            entity.Property(e => e.Wu2custom14Data).HasColumnName("WU2Custom14Data");
            entity.Property(e => e.Wu2custom14Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom14Desc");
            entity.Property(e => e.Wu2custom15Data).HasColumnName("WU2Custom15Data");
            entity.Property(e => e.Wu2custom15Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom15Desc");
            entity.Property(e => e.Wu2custom16Data).HasColumnName("WU2Custom16Data");
            entity.Property(e => e.Wu2custom16Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom16Desc");
            entity.Property(e => e.Wu2custom17Data).HasColumnName("WU2Custom17Data");
            entity.Property(e => e.Wu2custom17Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom17Desc");
            entity.Property(e => e.Wu2custom18Data).HasColumnName("WU2Custom18Data");
            entity.Property(e => e.Wu2custom18Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom18Desc");
            entity.Property(e => e.Wu2custom19Data).HasColumnName("WU2Custom19Data");
            entity.Property(e => e.Wu2custom19Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom19Desc");
            entity.Property(e => e.Wu2custom1Data).HasColumnName("WU2Custom1Data");
            entity.Property(e => e.Wu2custom1Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom1Desc");
            entity.Property(e => e.Wu2custom20Data).HasColumnName("WU2Custom20Data");
            entity.Property(e => e.Wu2custom20Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom20Desc");
            entity.Property(e => e.Wu2custom21Data).HasColumnName("WU2Custom21Data");
            entity.Property(e => e.Wu2custom21Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom21Desc");
            entity.Property(e => e.Wu2custom22Data).HasColumnName("WU2Custom22Data");
            entity.Property(e => e.Wu2custom22Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom22Desc");
            entity.Property(e => e.Wu2custom2Data).HasColumnName("WU2Custom2Data");
            entity.Property(e => e.Wu2custom2Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom2Desc");
            entity.Property(e => e.Wu2custom3Data).HasColumnName("WU2Custom3Data");
            entity.Property(e => e.Wu2custom3Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom3Desc");
            entity.Property(e => e.Wu2custom4Data).HasColumnName("WU2Custom4Data");
            entity.Property(e => e.Wu2custom4Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom4Desc");
            entity.Property(e => e.Wu2custom5Data).HasColumnName("WU2Custom5Data");
            entity.Property(e => e.Wu2custom5Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom5Desc");
            entity.Property(e => e.Wu2custom6Data).HasColumnName("WU2Custom6Data");
            entity.Property(e => e.Wu2custom6Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom6Desc");
            entity.Property(e => e.Wu2custom7Data).HasColumnName("WU2Custom7Data");
            entity.Property(e => e.Wu2custom7Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom7Desc");
            entity.Property(e => e.Wu2custom8Data).HasColumnName("WU2Custom8Data");
            entity.Property(e => e.Wu2custom8Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom8Desc");
            entity.Property(e => e.Wu2custom9Data).HasColumnName("WU2Custom9Data");
            entity.Property(e => e.Wu2custom9Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom9Desc");
            entity.Property(e => e.Wu2hertelBase)
                .HasMaxLength(100)
                .HasColumnName("WU2Hertel_Base");
            entity.Property(e => e.Wu2hertelOd)
                .HasMaxLength(100)
                .HasColumnName("WU2Hertel_OD");
            entity.Property(e => e.Wu2hertelOs)
                .HasMaxLength(100)
                .HasColumnName("WU2Hertel_OS");
            entity.Property(e => e.Wu2kmaxDegOd).HasColumnName("WU2KMaxDeg_OD");
            entity.Property(e => e.Wu2kmaxDegOs).HasColumnName("WU2KMaxDeg_OS");
            entity.Property(e => e.Wu2kmaxOd).HasColumnName("WU2KMax_OD");
            entity.Property(e => e.Wu2kmaxOs).HasColumnName("WU2KMax_OS");
            entity.Property(e => e.Wu2kminDegOd).HasColumnName("WU2KMinDeg_OD");
            entity.Property(e => e.Wu2kminDegOs).HasColumnName("WU2KMinDeg_OS");
            entity.Property(e => e.Wu2kminOd).HasColumnName("WU2KMin_OD");
            entity.Property(e => e.Wu2kminOs).HasColumnName("WU2KMin_OS");
            entity.Property(e => e.Wu2ktype)
                .HasMaxLength(255)
                .HasColumnName("WU2KType");
            entity.Property(e => e.Wu2pachCctOd)
                .HasMaxLength(50)
                .HasColumnName("WU2PachCCT_OD");
            entity.Property(e => e.Wu2pachCctOs)
                .HasMaxLength(50)
                .HasColumnName("WU2PachCCT_OS");
            entity.Property(e => e.Wu2tearOsmolarityCollectionDifficult).HasColumnName("WU2TearOsmolarityCollectionDifficult");
            entity.Property(e => e.Wu2tearOsmolarityOd)
                .HasMaxLength(50)
                .HasColumnName("WU2TearOsmolarity_OD");
            entity.Property(e => e.Wu2tearOsmolarityOs)
                .HasMaxLength(50)
                .HasColumnName("WU2TearOsmolarity_OS");
            entity.Property(e => e.Wu2ttvOd)
                .HasMaxLength(50)
                .HasColumnName("WU2TTV_OD");
            entity.Property(e => e.Wu2ttvOs)
                .HasMaxLength(50)
                .HasColumnName("WU2TTV_OS");
            entity.Property(e => e.Wu2ttvtype).HasColumnName("WU2TTVType");
            entity.Property(e => e.Wu2vaOrxOd)
                .HasMaxLength(50)
                .HasColumnName("WU2VA_ORx_OD");
            entity.Property(e => e.Wu2vaOrxOs)
                .HasMaxLength(50)
                .HasColumnName("WU2VA_ORx_OS");
            entity.Property(e => e.Wu2vaPamOd)
                .HasMaxLength(50)
                .HasColumnName("WU2VA_PAM_OD");
            entity.Property(e => e.Wu2vaPamOs)
                .HasMaxLength(50)
                .HasColumnName("WU2VA_PAM_OS");
        });

        modelBuilder.Entity<EmrvisitTechRo>(entity =>
        {
            entity.HasKey(e => e.VisitTechRosid)
                .HasName("aaaaaEMRVisitTechROS_PK")
                .IsClustered(false);

            entity.ToTable("EMRVisitTechROS");

            entity.HasIndex(e => e.VisitTechRosid, "EMRVisitTechID")
                .IsUnique()
                .HasFillFactor(90);

            entity.HasIndex(e => e.PtId, "PTID").HasFillFactor(90);

            entity.HasIndex(e => e.VisitId, "VisitID").HasFillFactor(90);

            entity.Property(e => e.VisitTechRosid).HasColumnName("VisitTechROSID");
            entity.Property(e => e.Dosdate)
                .HasColumnType("datetime")
                .HasColumnName("DOSDate");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.RosbloodCustomDesc1)
                .HasMaxLength(50)
                .HasColumnName("ROSBloodCustomDesc1");
            entity.Property(e => e.RosbloodCustomDesc2)
                .HasMaxLength(50)
                .HasColumnName("ROSBloodCustomDesc2");
            entity.Property(e => e.RosbloodCustomValue1).HasColumnName("ROSBloodCustomValue1");
            entity.Property(e => e.RosbloodCustomValue2).HasColumnName("ROSBloodCustomValue2");
            entity.Property(e => e.RosbloodEasyBruise).HasColumnName("ROSBloodEasyBruise");
            entity.Property(e => e.RosbloodGumsBleed).HasColumnName("ROSBloodGumsBleed");
            entity.Property(e => e.RosbloodHeavyAsprin).HasColumnName("ROSBloodHeavyAsprin");
            entity.Property(e => e.RosbloodProlongedBleed).HasColumnName("ROSBloodProlongedBleed");
            entity.Property(e => e.RoscardioChestPain).HasColumnName("ROSCardioChestPain");
            entity.Property(e => e.RoscardioCustomDesc1)
                .HasMaxLength(50)
                .HasColumnName("ROSCardioCustomDesc1");
            entity.Property(e => e.RoscardioCustomDesc2)
                .HasMaxLength(50)
                .HasColumnName("ROSCardioCustomDesc2");
            entity.Property(e => e.RoscardioCustomValue1).HasColumnName("ROSCardioCustomValue1");
            entity.Property(e => e.RoscardioCustomValue2).HasColumnName("ROSCardioCustomValue2");
            entity.Property(e => e.RoscardioDiffLyingFlat).HasColumnName("ROSCardioDiffLyingFlat");
            entity.Property(e => e.RoscardioDizziness).HasColumnName("ROSCardioDizziness");
            entity.Property(e => e.RoscardioFainting).HasColumnName("ROSCardioFainting");
            entity.Property(e => e.RoscardioIrreHeartBeat).HasColumnName("ROSCardioIrreHeartBeat");
            entity.Property(e => e.RoscardioShortBreath).HasColumnName("ROSCardioShortBreath");
            entity.Property(e => e.RosconsCustomDesc1)
                .HasMaxLength(50)
                .HasColumnName("ROSConsCustomDesc1");
            entity.Property(e => e.RosconsCustomDesc2)
                .HasMaxLength(50)
                .HasColumnName("ROSConsCustomDesc2");
            entity.Property(e => e.RosconsCustomValue1).HasColumnName("ROSConsCustomValue1");
            entity.Property(e => e.RosconsCustomValue2).HasColumnName("ROSConsCustomValue2");
            entity.Property(e => e.RosconsFatigue).HasColumnName("ROSConsFatigue");
            entity.Property(e => e.RosconsFever).HasColumnName("ROSConsFever");
            entity.Property(e => e.RosconsWeightGainLoss).HasColumnName("ROSConsWeightGainLoss");
            entity.Property(e => e.RosendoCustomDesc1)
                .HasMaxLength(50)
                .HasColumnName("ROSEndoCustomDesc1");
            entity.Property(e => e.RosendoCustomDesc2)
                .HasMaxLength(50)
                .HasColumnName("ROSEndoCustomDesc2");
            entity.Property(e => e.RosendoCustomValue1).HasColumnName("ROSEndoCustomValue1");
            entity.Property(e => e.RosendoCustomValue2).HasColumnName("ROSEndoCustomValue2");
            entity.Property(e => e.RosendoHunger).HasColumnName("ROSEndoHunger");
            entity.Property(e => e.RosendoNailChanges).HasColumnName("ROSEndoNailChanges");
            entity.Property(e => e.RosendoSweating).HasColumnName("ROSEndoSweating");
            entity.Property(e => e.RosendoThirst).HasColumnName("ROSEndoThirst");
            entity.Property(e => e.RosendoUrination).HasColumnName("ROSEndoUrination");
            entity.Property(e => e.RosentcustomDesc1)
                .HasMaxLength(50)
                .HasColumnName("ROSENTCustomDesc1");
            entity.Property(e => e.RosentcustomDesc2)
                .HasMaxLength(50)
                .HasColumnName("ROSENTCustomDesc2");
            entity.Property(e => e.RosentcustomValue1).HasColumnName("ROSENTCustomValue1");
            entity.Property(e => e.RosentcustomValue2).HasColumnName("ROSENTCustomValue2");
            entity.Property(e => e.RosenthardHearing).HasColumnName("ROSENTHardHearing");
            entity.Property(e => e.RosentringingEars).HasColumnName("ROSENTRingingEars");
            entity.Property(e => e.Rosentvertigo).HasColumnName("ROSENTVertigo");
            entity.Property(e => e.RoseyeCataracts).HasColumnName("ROSEyeCataracts");
            entity.Property(e => e.RoseyeContactLens).HasColumnName("ROSEyeContactLens");
            entity.Property(e => e.RoseyeCustomDesc1)
                .HasMaxLength(50)
                .HasColumnName("ROSEyeCustomDesc1");
            entity.Property(e => e.RoseyeCustomDesc2)
                .HasMaxLength(50)
                .HasColumnName("ROSEyeCustomDesc2");
            entity.Property(e => e.RoseyeCustomDesc3)
                .HasMaxLength(50)
                .HasColumnName("ROSEyeCustomDesc3");
            entity.Property(e => e.RoseyeCustomDesc4)
                .HasMaxLength(50)
                .HasColumnName("ROSEyeCustomDesc4");
            entity.Property(e => e.RoseyeCustomValue1).HasColumnName("ROSEyeCustomValue1");
            entity.Property(e => e.RoseyeCustomValue2).HasColumnName("ROSEyeCustomValue2");
            entity.Property(e => e.RoseyeCustomValue3).HasColumnName("ROSEyeCustomValue3");
            entity.Property(e => e.RoseyeCustomValue4).HasColumnName("ROSEyeCustomValue4");
            entity.Property(e => e.RoseyeDblVision).HasColumnName("ROSEyeDblVision");
            entity.Property(e => e.RoseyeDryEyes).HasColumnName("ROSEyeDryEyes");
            entity.Property(e => e.RoseyeGlaucoma).HasColumnName("ROSEyeGlaucoma");
            entity.Property(e => e.RoseyeMacDegen).HasColumnName("ROSEyeMacDegen");
            entity.Property(e => e.RoseyePain).HasColumnName("ROSEyePain");
            entity.Property(e => e.RoseyePrevSurg).HasColumnName("ROSEyePrevSurg");
            entity.Property(e => e.RosgasCustomDesc1)
                .HasMaxLength(50)
                .HasColumnName("ROSGasCustomDesc1");
            entity.Property(e => e.RosgasCustomDesc2)
                .HasMaxLength(50)
                .HasColumnName("ROSGasCustomDesc2");
            entity.Property(e => e.RosgasCustomValue1).HasColumnName("ROSGasCustomValue1");
            entity.Property(e => e.RosgasCustomValue2).HasColumnName("ROSGasCustomValue2");
            entity.Property(e => e.RosgasHeartBurn).HasColumnName("ROSGasHeartBurn");
            entity.Property(e => e.RosgasJaundiceHepa).HasColumnName("ROSGasJaundiceHepa");
            entity.Property(e => e.RosgasNausea).HasColumnName("ROSGasNausea");
            entity.Property(e => e.RosimmuCustomDesc1)
                .HasMaxLength(50)
                .HasColumnName("ROSImmuCustomDesc1");
            entity.Property(e => e.RosimmuCustomDesc2)
                .HasMaxLength(50)
                .HasColumnName("ROSImmuCustomDesc2");
            entity.Property(e => e.RosimmuCustomValue1).HasColumnName("ROSImmuCustomValue1");
            entity.Property(e => e.RosimmuCustomValue2).HasColumnName("ROSImmuCustomValue2");
            entity.Property(e => e.RosimmuHives).HasColumnName("ROSImmuHives");
            entity.Property(e => e.RosimmuItching).HasColumnName("ROSImmuItching");
            entity.Property(e => e.RosimmuRunnyNose).HasColumnName("ROSImmuRunnyNose");
            entity.Property(e => e.RosimmuSinusPressure).HasColumnName("ROSImmuSinusPressure");
            entity.Property(e => e.RosmusSkeArthritis).HasColumnName("ROSMusSkeArthritis");
            entity.Property(e => e.RosmusSkeCustomDesc1)
                .HasMaxLength(50)
                .HasColumnName("ROSMusSkeCustomDesc1");
            entity.Property(e => e.RosmusSkeCustomDesc2)
                .HasMaxLength(50)
                .HasColumnName("ROSMusSkeCustomDesc2");
            entity.Property(e => e.RosmusSkeCustomValue1).HasColumnName("ROSMusSkeCustomValue1");
            entity.Property(e => e.RosmusSkeCustomValue2).HasColumnName("ROSMusSkeCustomValue2");
            entity.Property(e => e.RosmusSkeJointPain).HasColumnName("ROSMusSkeJointPain");
            entity.Property(e => e.RosmusSkeStiffness).HasColumnName("ROSMusSkeStiffness");
            entity.Property(e => e.RosneuroCustomDesc1)
                .HasMaxLength(50)
                .HasColumnName("ROSNeuroCustomDesc1");
            entity.Property(e => e.RosneuroCustomDesc2)
                .HasMaxLength(50)
                .HasColumnName("ROSNeuroCustomDesc2");
            entity.Property(e => e.RosneuroCustomValue1).HasColumnName("ROSNeuroCustomValue1");
            entity.Property(e => e.RosneuroCustomValue2).HasColumnName("ROSNeuroCustomValue2");
            entity.Property(e => e.RosneuroNumbness).HasColumnName("ROSNeuroNumbness");
            entity.Property(e => e.RosneuroSeizures).HasColumnName("ROSNeuroSeizures");
            entity.Property(e => e.RosneuroTremors).HasColumnName("ROSNeuroTremors");
            entity.Property(e => e.RosneuroWeakParalysis).HasColumnName("ROSNeuroWeakParalysis");
            entity.Property(e => e.Rosnotes).HasColumnName("ROSNotes");
            entity.Property(e => e.RospsycAnxiety).HasColumnName("ROSPsycAnxiety");
            entity.Property(e => e.RospsycCustomDesc1)
                .HasMaxLength(50)
                .HasColumnName("ROSPsycCustomDesc1");
            entity.Property(e => e.RospsycCustomDesc2)
                .HasMaxLength(50)
                .HasColumnName("ROSPsycCustomDesc2");
            entity.Property(e => e.RospsycCustomValue1).HasColumnName("ROSPsycCustomValue1");
            entity.Property(e => e.RospsycCustomValue2).HasColumnName("ROSPsycCustomValue2");
            entity.Property(e => e.RospsycDiffSleeping).HasColumnName("ROSPsycDiffSleeping");
            entity.Property(e => e.RospsycMoodSwings).HasColumnName("ROSPsycMoodSwings");
            entity.Property(e => e.RosrespAsthma).HasColumnName("ROSRespAsthma");
            entity.Property(e => e.RosrespCongestion).HasColumnName("ROSRespCongestion");
            entity.Property(e => e.RosrespCough).HasColumnName("ROSRespCough");
            entity.Property(e => e.RosrespCustomDesc1)
                .HasMaxLength(50)
                .HasColumnName("ROSRespCustomDesc1");
            entity.Property(e => e.RosrespCustomDesc2)
                .HasMaxLength(50)
                .HasColumnName("ROSRespCustomDesc2");
            entity.Property(e => e.RosrespCustomValue1).HasColumnName("ROSRespCustomValue1");
            entity.Property(e => e.RosrespCustomValue2).HasColumnName("ROSRespCustomValue2");
            entity.Property(e => e.RosrespWeezing).HasColumnName("ROSRespWeezing");
            entity.Property(e => e.RosskinCustomDesc1)
                .HasMaxLength(50)
                .HasColumnName("ROSSkinCustomDesc1");
            entity.Property(e => e.RosskinCustomDesc2)
                .HasMaxLength(50)
                .HasColumnName("ROSSkinCustomDesc2");
            entity.Property(e => e.RosskinCustomValue1).HasColumnName("ROSSkinCustomValue1");
            entity.Property(e => e.RosskinCustomValue2).HasColumnName("ROSSkinCustomValue2");
            entity.Property(e => e.RosskinHivesEczema).HasColumnName("ROSSkinHivesEczema");
            entity.Property(e => e.RosskinLesions).HasColumnName("ROSSkinLesions");
            entity.Property(e => e.RosskinRashSores).HasColumnName("ROSSkinRashSores");
            entity.Property(e => e.RosurinaryBloodIn).HasColumnName("ROSUrinaryBloodIn");
            entity.Property(e => e.RosurinaryCustomDesc1)
                .HasMaxLength(50)
                .HasColumnName("ROSUrinaryCustomDesc1");
            entity.Property(e => e.RosurinaryCustomDesc2)
                .HasMaxLength(50)
                .HasColumnName("ROSUrinaryCustomDesc2");
            entity.Property(e => e.RosurinaryCustomValue1).HasColumnName("ROSUrinaryCustomValue1");
            entity.Property(e => e.RosurinaryCustomValue2).HasColumnName("ROSUrinaryCustomValue2");
            entity.Property(e => e.RosurinaryKidneyStones).HasColumnName("ROSUrinaryKidneyStones");
            entity.Property(e => e.RosurinaryPainDifficulty).HasColumnName("ROSUrinaryPainDifficulty");
            entity.Property(e => e.RosurinaryStd).HasColumnName("ROSUrinarySTD");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
        });

        modelBuilder.Entity<EmrvisitType>(entity =>
        {
            entity.HasKey(e => e.VisitTypeId);

            entity.ToTable("EMRVisitTypes");

            entity.Property(e => e.VisitTypeId).HasColumnName("VisitTypeID");
            entity.Property(e => e.CodeId).HasColumnName("CodeID");
            entity.Property(e => e.DefaultServiceType).HasDefaultValue(0);
            entity.Property(e => e.ExcludeVisit).HasDefaultValue((short)0);
            entity.Property(e => e.GlobalPodays).HasColumnName("GlobalPODays");
            entity.Property(e => e.HasGlobal).HasDefaultValue((short)0);
            entity.Property(e => e.HlcchpiassoSigns).HasColumnName("HLCCHPIAssoSigns");
            entity.Property(e => e.Hlcchpicc).HasColumnName("HLCCHPICC");
            entity.Property(e => e.Hlcchpicontext).HasColumnName("HLCCHPIContext");
            entity.Property(e => e.Hlcchpiduration).HasColumnName("HLCCHPIDuration");
            entity.Property(e => e.Hlcchpilocation).HasColumnName("HLCCHPILocation");
            entity.Property(e => e.HlcchpimodFactors).HasColumnName("HLCCHPIModFactors");
            entity.Property(e => e.Hlcchpiquality).HasColumnName("HLCCHPIQuality");
            entity.Property(e => e.Hlcchpiseverity).HasColumnName("HLCCHPISeverity");
            entity.Property(e => e.Hlcchpitiming).HasColumnName("HLCCHPITiming");
            entity.Property(e => e.HlcognitiveStatus).HasColumnName("HLCognitiveStatus");
            entity.Property(e => e.HlfunctionalStatus).HasColumnName("HLFunctionalStatus");
            entity.Property(e => e.Hlpohallergies).HasColumnName("HLPOHAllergies");
            entity.Property(e => e.HlpohcurrentEyeMeds).HasColumnName("HLPOHCurrentEyeMeds");
            entity.Property(e => e.HlpohcurrentSysMeds).HasColumnName("HLPOHCurrentSysMeds");
            entity.Property(e => e.HlpohfamilyHis).HasColumnName("HLPOHFamilyHis");
            entity.Property(e => e.HlpohpastMedHis).HasColumnName("HLPOHPastMedHis");
            entity.Property(e => e.HlpohpastOcularHis).HasColumnName("HLPOHPastOcularHis");
            entity.Property(e => e.HlpohpastOcularSurgeries).HasColumnName("HLPOHPastOcularSurgeries");
            entity.Property(e => e.HlpohpastSurgeries).HasColumnName("HLPOHPastSurgeries");
            entity.Property(e => e.HlpohsocialHis).HasColumnName("HLPOHSocialHis");
            entity.Property(e => e.HlprocCustom1).HasColumnName("HLProcCustom1");
            entity.Property(e => e.HlprocCustom10).HasColumnName("HLProcCustom10");
            entity.Property(e => e.HlprocCustom11).HasColumnName("HLProcCustom11");
            entity.Property(e => e.HlprocCustom12).HasColumnName("HLProcCustom12");
            entity.Property(e => e.HlprocCustom13).HasColumnName("HLProcCustom13");
            entity.Property(e => e.HlprocCustom14).HasColumnName("HLProcCustom14");
            entity.Property(e => e.HlprocCustom15).HasColumnName("HLProcCustom15");
            entity.Property(e => e.HlprocCustom16).HasColumnName("HLProcCustom16");
            entity.Property(e => e.HlprocCustom17).HasColumnName("HLProcCustom17");
            entity.Property(e => e.HlprocCustom18).HasColumnName("HLProcCustom18");
            entity.Property(e => e.HlprocCustom19).HasColumnName("HLProcCustom19");
            entity.Property(e => e.HlprocCustom2).HasColumnName("HLProcCustom2");
            entity.Property(e => e.HlprocCustom20).HasColumnName("HLProcCustom20");
            entity.Property(e => e.HlprocCustom21).HasColumnName("HLProcCustom21");
            entity.Property(e => e.HlprocCustom22).HasColumnName("HLProcCustom22");
            entity.Property(e => e.HlprocCustom3).HasColumnName("HLProcCustom3");
            entity.Property(e => e.HlprocCustom4).HasColumnName("HLProcCustom4");
            entity.Property(e => e.HlprocCustom5).HasColumnName("HLProcCustom5");
            entity.Property(e => e.HlprocCustom6).HasColumnName("HLProcCustom6");
            entity.Property(e => e.HlprocCustom7).HasColumnName("HLProcCustom7");
            entity.Property(e => e.HlprocCustom8).HasColumnName("HLProcCustom8");
            entity.Property(e => e.HlprocCustom9).HasColumnName("HLProcCustom9");
            entity.Property(e => e.Hlrosblood).HasColumnName("HLROSBlood");
            entity.Property(e => e.Hlroscardio).HasColumnName("HLROSCardio");
            entity.Property(e => e.Hlroscons).HasColumnName("HLROSCons");
            entity.Property(e => e.Hlrosendo).HasColumnName("HLROSEndo");
            entity.Property(e => e.Hlrosent).HasColumnName("HLROSENT");
            entity.Property(e => e.Hlroseyes).HasColumnName("HLROSEyes");
            entity.Property(e => e.Hlrosgas).HasColumnName("HLROSGas");
            entity.Property(e => e.Hlrosimmu).HasColumnName("HLROSImmu");
            entity.Property(e => e.Hlrosmus).HasColumnName("HLROSMus");
            entity.Property(e => e.Hlrosneuro).HasColumnName("HLROSNeuro");
            entity.Property(e => e.Hlrospsyc).HasColumnName("HLROSPsyc");
            entity.Property(e => e.Hlrosresp).HasColumnName("HLROSResp");
            entity.Property(e => e.Hlrosskin).HasColumnName("HLROSSkin");
            entity.Property(e => e.Hlrosurinary).HasColumnName("HLROSUrinary");
            entity.Property(e => e.HlvitalsBgl).HasColumnName("HLVitalsBGL");
            entity.Property(e => e.HlvitalsBp).HasColumnName("HLVitalsBP");
            entity.Property(e => e.HlvitalsHeight).HasColumnName("HLVitalsHeight");
            entity.Property(e => e.HlvitalsInhaled02Concentration).HasColumnName("HLVitalsInhaled02Concentration");
            entity.Property(e => e.HlvitalsPulse).HasColumnName("HLVitalsPulse");
            entity.Property(e => e.HlvitalsPulseOximetry).HasColumnName("HLVitalsPulseOximetry");
            entity.Property(e => e.HlvitalsRespRate).HasColumnName("HLVitalsRespRate");
            entity.Property(e => e.HlvitalsTemp).HasColumnName("HLVitalsTemp");
            entity.Property(e => e.HlvitalsWeight).HasColumnName("HLVitalsWeight");
            entity.Property(e => e.Hlwu2custom1).HasColumnName("HLWU2Custom1");
            entity.Property(e => e.Hlwu2custom10).HasColumnName("HLWU2Custom10");
            entity.Property(e => e.Hlwu2custom11).HasColumnName("HLWU2Custom11");
            entity.Property(e => e.Hlwu2custom12).HasColumnName("HLWU2Custom12");
            entity.Property(e => e.Hlwu2custom13).HasColumnName("HLWU2Custom13");
            entity.Property(e => e.Hlwu2custom14).HasColumnName("HLWU2Custom14");
            entity.Property(e => e.Hlwu2custom15).HasColumnName("HLWU2Custom15");
            entity.Property(e => e.Hlwu2custom16).HasColumnName("HLWU2Custom16");
            entity.Property(e => e.Hlwu2custom17).HasColumnName("HLWU2Custom17");
            entity.Property(e => e.Hlwu2custom18).HasColumnName("HLWU2Custom18");
            entity.Property(e => e.Hlwu2custom19).HasColumnName("HLWU2Custom19");
            entity.Property(e => e.Hlwu2custom2).HasColumnName("HLWU2Custom2");
            entity.Property(e => e.Hlwu2custom20).HasColumnName("HLWU2Custom20");
            entity.Property(e => e.Hlwu2custom21).HasColumnName("HLWU2Custom21");
            entity.Property(e => e.Hlwu2custom22).HasColumnName("HLWU2Custom22");
            entity.Property(e => e.Hlwu2custom3).HasColumnName("HLWU2Custom3");
            entity.Property(e => e.Hlwu2custom4).HasColumnName("HLWU2Custom4");
            entity.Property(e => e.Hlwu2custom5).HasColumnName("HLWU2Custom5");
            entity.Property(e => e.Hlwu2custom6).HasColumnName("HLWU2Custom6");
            entity.Property(e => e.Hlwu2custom7).HasColumnName("HLWU2Custom7");
            entity.Property(e => e.Hlwu2custom8).HasColumnName("HLWU2Custom8");
            entity.Property(e => e.Hlwu2custom9).HasColumnName("HLWU2Custom9");
            entity.Property(e => e.Hlwu2hertel).HasColumnName("HLWU2Hertel");
            entity.Property(e => e.Hlwu2ks).HasColumnName("HLWU2Ks");
            entity.Property(e => e.Hlwu2mrx2).HasColumnName("HLWU2MRx2");
            entity.Property(e => e.Hlwu2mrx3).HasColumnName("HLWU2MRx3");
            entity.Property(e => e.Hlwu2nwcontacts).HasColumnName("HLWU2NWContacts");
            entity.Property(e => e.Hlwu2orx).HasColumnName("HLWU2ORx");
            entity.Property(e => e.Hlwu2p).HasColumnName("HLWU2P");
            entity.Property(e => e.Hlwu2pam).HasColumnName("HLWU2PAM");
            entity.Property(e => e.Hlwu2tearOsmolarity).HasColumnName("HLWU2TearOsmolarity");
            entity.Property(e => e.Hlwu2tvt).HasColumnName("HLWU2TVT");
            entity.Property(e => e.Hlwuamsler).HasColumnName("HLWUAmsler");
            entity.Property(e => e.Hlwuarx).HasColumnName("HLWUARx");
            entity.Property(e => e.Hlwucvf).HasColumnName("HLWUCVF");
            entity.Property(e => e.Hlwudilated).HasColumnName("HLWUDilated");
            entity.Property(e => e.Hlwudom).HasColumnName("HLWUDOM");
            entity.Property(e => e.Hlwueom).HasColumnName("HLWUEOM");
            entity.Property(e => e.Hlwuext).HasColumnName("HLWUExt");
            entity.Property(e => e.Hlwujcc).HasColumnName("HLWUJCC");
            entity.Property(e => e.Hlwujsc).HasColumnName("HLWUJSC");
            entity.Property(e => e.Hlwumood).HasColumnName("HLWUMood");
            entity.Property(e => e.Hlwumrx).HasColumnName("HLWUMRx");
            entity.Property(e => e.HlwumrxGlare).HasColumnName("HLWUMRxGlare");
            entity.Property(e => e.Hlwunw).HasColumnName("HLWUNW");
            entity.Property(e => e.Hlwuorientation).HasColumnName("HLWUOrientation");
            entity.Property(e => e.Hlwupupils).HasColumnName("HLWUPupils");
            entity.Property(e => e.Hlwut).HasColumnName("HLWUT");
            entity.Property(e => e.HlwuvaCc).HasColumnName("HLWUVaCC");
            entity.Property(e => e.HlwuvaPh).HasColumnName("HLWUVaPH");
            entity.Property(e => e.HlwuvaSc).HasColumnName("HLWUVaSC");
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.ProcCustom10Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom11Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom12Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom13Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom14Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom15Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom16Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom17Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom18Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom19Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom1Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom20Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom21Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom22Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom2Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom3Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom4Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom5Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom6Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom7Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom8Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustom9Desc).HasMaxLength(50);
            entity.Property(e => e.ProcCustomDateDesc).HasMaxLength(50);
            entity.Property(e => e.ProcDescription).HasMaxLength(255);
            entity.Property(e => e.ProcNoteDescription).HasMaxLength(255);
            entity.Property(e => e.ShowOdosou).HasColumnName("ShowODOSOU");
            entity.Property(e => e.TabCchpi).HasColumnName("TabCCHPI");
            entity.Property(e => e.TabDfe).HasColumnName("TabDFE");
            entity.Property(e => e.TabMbalance).HasColumnName("TabMBalance");
            entity.Property(e => e.TabPohpmh).HasColumnName("TabPOHPMH");
            entity.Property(e => e.TabRos).HasColumnName("TabROS");
            entity.Property(e => e.TabSle).HasColumnName("TabSLE");
            entity.Property(e => e.TestimonialTreeSubmit).HasDefaultValue((short)0);
            entity.Property(e => e.VisitClassId).HasColumnName("VisitClassID");
            entity.Property(e => e.Wu2custom10Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom10Desc");
            entity.Property(e => e.Wu2custom11Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom11Desc");
            entity.Property(e => e.Wu2custom12Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom12Desc");
            entity.Property(e => e.Wu2custom13Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom13Desc");
            entity.Property(e => e.Wu2custom14Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom14Desc");
            entity.Property(e => e.Wu2custom15Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom15Desc");
            entity.Property(e => e.Wu2custom16Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom16Desc");
            entity.Property(e => e.Wu2custom17Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom17Desc");
            entity.Property(e => e.Wu2custom18Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom18Desc");
            entity.Property(e => e.Wu2custom19Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom19Desc");
            entity.Property(e => e.Wu2custom1Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom1Desc");
            entity.Property(e => e.Wu2custom20Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom20Desc");
            entity.Property(e => e.Wu2custom21Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom21Desc");
            entity.Property(e => e.Wu2custom22Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom22Desc");
            entity.Property(e => e.Wu2custom2Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom2Desc");
            entity.Property(e => e.Wu2custom3Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom3Desc");
            entity.Property(e => e.Wu2custom4Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom4Desc");
            entity.Property(e => e.Wu2custom5Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom5Desc");
            entity.Property(e => e.Wu2custom6Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom6Desc");
            entity.Property(e => e.Wu2custom7Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom7Desc");
            entity.Property(e => e.Wu2custom8Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom8Desc");
            entity.Property(e => e.Wu2custom9Desc)
                .HasMaxLength(50)
                .HasColumnName("WU2Custom9Desc");
        });

        modelBuilder.Entity<IntakeConsentForm>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ConsentFormId)
                .HasMaxLength(50)
                .HasColumnName("ConsentFormID");
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<SchemaVersion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SchemaVersions_Id");

            entity.Property(e => e.Applied).HasColumnType("datetime");
            entity.Property(e => e.Notes).HasMaxLength(350);
            entity.Property(e => e.ScriptName).HasMaxLength(255);
        });

        modelBuilder.Entity<TrigOrder>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AccountNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Account_Number");
            entity.Property(e => e.CreatedTime).HasColumnType("datetime");
            entity.Property(e => e.Isprocessed).HasColumnName("ISPROCESSED");
            entity.Property(e => e.PtId).HasColumnName("PtID");
            entity.Property(e => e.ReplyProcessed).HasColumnName("ReplyPROCESSED");
            entity.Property(e => e.ReplyTime).HasColumnType("datetime");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
            entity.Property(e => e.VisitOrderId).HasColumnName("VisitOrderID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
