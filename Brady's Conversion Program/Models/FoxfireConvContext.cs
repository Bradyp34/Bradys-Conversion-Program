using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.Models;

public partial class FoxfireConvContext : DbContext
{
    public FoxfireConvContext()
    {
    }

    public FoxfireConvContext(DbContextOptions<FoxfireConvContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccountXref> AccountXrefs { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<AppointmentType> AppointmentTypes { get; set; }

    public virtual DbSet<Employer> Employers { get; set; }

    public virtual DbSet<Insurance> Insurances { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Name> Names { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PatientAlert> PatientAlerts { get; set; }

    public virtual DbSet<PatientDocument> PatientDocuments { get; set; }

    public virtual DbSet<PatientInsurance> PatientInsurances { get; set; }

    public virtual DbSet<PatientNote> PatientNotes { get; set; }

    public virtual DbSet<Phone> Phones { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<Recall> Recalls { get; set; }

    public virtual DbSet<RecallType> RecallTypes { get; set; }

    public virtual DbSet<Referral> Referrals { get; set; }

    public virtual DbSet<SchedCode> SchedCodes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=FoxDevSql19;Database=Foxfire_Conv;Integrated Security=True;TrustServerCertificate=True;");

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

        modelBuilder.Entity<Address>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Address");

            entity.Property(e => e.Address1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Address 1");
            entity.Property(e => e.Address2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Address 2");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Note).IsUnicode(false);
            entity.Property(e => e.PrimaryFile)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Primary File");
            entity.Property(e => e.PrimaryId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Primary_ID");
            entity.Property(e => e.State)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TypeOfAddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Type of Address");
            entity.Property(e => e.Zip)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Zip4)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Zip+4");
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Appointm__3214EC27025AD3C9");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AppointmentId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AppointmentID");
            entity.Property(e => e.AppointmentTypeId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AppointmentTypeID");
            entity.Property(e => e.BillingLocationId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BillingLocationID");
            entity.Property(e => e.CheckInDateTime)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CheckOutDateTime)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Confirmed)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DateTimeCreated)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DateTimeUpdated)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Duration)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.EndDate)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LinkedAppointmentId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LinkedAppointmentID");
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PatientId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PatientID");
            entity.Property(e => e.PriorAppointmentId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PriorAppointmentID");
            entity.Property(e => e.RecallId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RecallID");
            entity.Property(e => e.RequestId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ResourceId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ResourceID");
            entity.Property(e => e.SchedulingCodeId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SchedulingCodeID");
            entity.Property(e => e.SchedulingCodeNotes)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Sequence)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.StartDate)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TakeBackDateTime)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.WaitingListId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WaitingListID");
        });

        modelBuilder.Entity<AppointmentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Appointm__3214EC27F2B69485");

            entity.ToTable("Appointment_Type");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.AppointmentTypeId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AppointmentTypeID");
            entity.Property(e => e.CanSchedule)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DefaultDuration)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.IsExamType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PatientRequired)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employer__3214EC2766BE9B47");

            entity.ToTable("Employer");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EmployerName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Insurance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Insuranc__3214EC272E239185");

            entity.ToTable("Insurance");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.InsCompanyAddress1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Address_1");
            entity.Property(e => e.InsCompanyAddress2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Address_2");
            entity.Property(e => e.InsCompanyCarrierType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Carrier_Type");
            entity.Property(e => e.InsCompanyCity)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_City");
            entity.Property(e => e.InsCompanyClaimType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Claim_Type");
            entity.Property(e => e.InsCompanyCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Code");
            entity.Property(e => e.InsCompanyEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Email");
            entity.Property(e => e.InsCompanyFax)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Fax");
            entity.Property(e => e.InsCompanyId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Id");
            entity.Property(e => e.InsCompanyName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Name");
            entity.Property(e => e.InsCompanyPayerId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Payer_Id");
            entity.Property(e => e.InsCompanyPhone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Phone");
            entity.Property(e => e.InsCompanyPolicyType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Policy_Type");
            entity.Property(e => e.InsCompanyState)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_State");
            entity.Property(e => e.InsCompanyZip)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Zip");
            entity.Property(e => e.IsActive)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Is_Active");
            entity.Property(e => e.IsCollections)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Is_Collections");
            entity.Property(e => e.IsDmerc)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Is_DMERC");
            entity.Property(e => e.MedicalVision)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Medical-Vision");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Location__3214EC271FD118FE");

            entity.ToTable("Location");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AlternateTaxonomy10Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_10_Id");
            entity.Property(e => e.AlternateTaxonomy11Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_11_Id");
            entity.Property(e => e.AlternateTaxonomy12Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_12_Id");
            entity.Property(e => e.AlternateTaxonomy13Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_13_Id");
            entity.Property(e => e.AlternateTaxonomy14Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_14_Id");
            entity.Property(e => e.AlternateTaxonomy15Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_15_Id");
            entity.Property(e => e.AlternateTaxonomy16Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_16_Id");
            entity.Property(e => e.AlternateTaxonomy17Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_17_Id");
            entity.Property(e => e.AlternateTaxonomy18Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_18_Id");
            entity.Property(e => e.AlternateTaxonomy19Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_19_Id");
            entity.Property(e => e.AlternateTaxonomy1Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_1_Id");
            entity.Property(e => e.AlternateTaxonomy20Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_20_Id");
            entity.Property(e => e.AlternateTaxonomy2Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_2_Id");
            entity.Property(e => e.AlternateTaxonomy3Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_3_Id");
            entity.Property(e => e.AlternateTaxonomy4Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_4_Id");
            entity.Property(e => e.AlternateTaxonomy5Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_5_Id");
            entity.Property(e => e.AlternateTaxonomy6Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_6_Id");
            entity.Property(e => e.AlternateTaxonomy7Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_7_Id");
            entity.Property(e => e.AlternateTaxonomy8Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_8_Id");
            entity.Property(e => e.AlternateTaxonomy9Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_9_Id");
            entity.Property(e => e.Clia)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CLIA");
            entity.Property(e => e.FederalEin)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Federal_EIN");
            entity.Property(e => e.IsBilling)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Is_Billing");
            entity.Property(e => e.IsScheduling)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Is_Scheduling");
            entity.Property(e => e.LocationId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LocationID");
            entity.Property(e => e.LocationName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Location_Name");
            entity.Property(e => e.Npi)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NPI");
            entity.Property(e => e.PlaceOfTreatment)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Place Of Treatment");
            entity.Property(e => e.PrimaryTaxonomyId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Primary_Taxonomy_Id");
        });

        modelBuilder.Entity<Name>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Name__3214EC27967A86F2");

            entity.ToTable("Name");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AccountNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Account_Number");
            entity.Property(e => e.Dob)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DOB");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First Name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last Name");
            entity.Property(e => e.MaritalStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Marital Status");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Middle Name");
            entity.Property(e => e.Note)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PrimaryFile)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Primary File");
            entity.Property(e => e.PrimaryId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Primary_ID");
            entity.Property(e => e.Rank)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Relationship)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Sex)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Ssn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SSN");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Patients__3214EC2718309894");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Consent)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ConsentDate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Consent Date");
            entity.Property(e => e.DateOfDeath)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Date of Death");
            entity.Property(e => e.DeceasedFlag)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Deceased Flag");
            entity.Property(e => e.DriversLicense)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Drivers License");
            entity.Property(e => e.DriversLicenseState)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Drivers License State");
            entity.Property(e => e.LastExamDate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Last Exam Date");
            entity.Property(e => e.LastExamLocation)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last Exam Location");
            entity.Property(e => e.LastExamProvider)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last Exam Provider");
            entity.Property(e => e.LastExamType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last Exam Type");
            entity.Property(e => e.MedicareSecondaryCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Medicare Secondary Code");
            entity.Property(e => e.MedicareSecondaryNotes)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Medicare Secondary Notes");
            entity.Property(e => e.NoticeOfPrivPractice)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Notice of Priv Practice");
            entity.Property(e => e.NoticeOfPrivPracticeDate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Notice of Priv Practice Date");
            entity.Property(e => e.PatientAccountNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Patient_Account_Number");
            entity.Property(e => e.PatientAltAccountNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Patient alt account number");
            entity.Property(e => e.PatientAssignedProviderCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Patient Assigned Provider Code");
            entity.Property(e => e.PatientChartNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Patient Chart Number");
            entity.Property(e => e.PatientDob)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Patient DOB");
            entity.Property(e => e.PatientEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Patient Email");
            entity.Property(e => e.PatientEthnicity)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Patient Ethnicity");
            entity.Property(e => e.PatientFirst)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Patient First");
            entity.Property(e => e.PatientLast)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Patient Last");
            entity.Property(e => e.PatientMaritalStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Patient Marital Status");
            entity.Property(e => e.PatientMiddle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Patient Middle");
            entity.Property(e => e.PatientPreferredContact1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Patient Preferred Contact 1");
            entity.Property(e => e.PatientPreferredContact2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Patient Preferred Contact 2");
            entity.Property(e => e.PatientPreferredContact3)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Patient Preferred Contact 3");
            entity.Property(e => e.PatientPreferredContact4)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Patient Preferred Contact 4");
            entity.Property(e => e.PatientPreferredContact5)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Patient Preferred Contact 5");
            entity.Property(e => e.PatientPreferredName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Patient Preferred Name");
            entity.Property(e => e.PatientRace)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Patient Race");
            entity.Property(e => e.PatientReferralProviderCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Patient Referral Provider Code");
            entity.Property(e => e.PatientSex)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Patient Sex");
            entity.Property(e => e.PatientSsn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Patient SSN");
            entity.Property(e => e.ReleaseOfInfo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Release of Info");
            entity.Property(e => e.Suffix)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PatientAlert>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Patient___3214EC275728D617");

            entity.ToTable("Patient_Alert");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AlertCreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Alert_Created_By");
            entity.Property(e => e.AlertCreatedDate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Alert_Created_Date");
            entity.Property(e => e.AlertExpiryDate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Alert_Expiry_Date");
            entity.Property(e => e.AlertFlash)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Alert_flash");
            entity.Property(e => e.AlertMessage)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Alert_Message");
            entity.Property(e => e.IsActive)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Is_Active");
            entity.Property(e => e.PatientId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Patient_Id");
            entity.Property(e => e.PriorityId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Priority_Id");
        });

        modelBuilder.Entity<PatientDocument>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Patient___3214EC27F490DA5D");

            entity.ToTable("Patient_Documents");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Date)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DocumentDescription)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Document Description");
            entity.Property(e => e.DocumentImageType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Document-Image Type");
            entity.Property(e => e.DocumentNotes)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Document Notes");
            entity.Property(e => e.FilePathName)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("File Path-Name");
            entity.Property(e => e.PatientId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Patient_Id");
            entity.Property(e => e.PatientInsuranceCompany)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Patient Insurance Company");
        });

        modelBuilder.Entity<PatientInsurance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Patient___3214EC270CE887D3");

            entity.ToTable("Patient_Insurance");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cert)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Copay)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Deductible)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EndDate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("End Date");
            entity.Property(e => e.Group)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MedicalVision)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Medical-Vision");
            entity.Property(e => e.PatientId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Patient_Id");
            entity.Property(e => e.Plan)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PrimaryFile)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Primary File");
            entity.Property(e => e.PrimaryId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Primary_ID");
            entity.Property(e => e.Rank)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.StartDate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Start Date");
        });

        modelBuilder.Entity<PatientNote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Patient___3214EC270F6E5652");

            entity.ToTable("Patient_Note");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Created_By");
            entity.Property(e => e.CreatedDate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Created_Date");
            entity.Property(e => e.IsActive)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Is_Active");
            entity.Property(e => e.LastUpdated)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Last_Updated");
            entity.Property(e => e.Note)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PatientId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Patient_Id");
        });

        modelBuilder.Entity<Phone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Phone__3214EC2780DCD4C4");

            entity.ToTable("Phone");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Extension)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Note)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Phone Number");
            entity.Property(e => e.PrimaryFile)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Primary File");
            entity.Property(e => e.PrimaryId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Primary_ID");
            entity.Property(e => e.TypeOfPhone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Type of Phone");
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Provider__3214EC27641CD647");

            entity.ToTable("Provider");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AlternateTaxonomy10Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_10_Id");
            entity.Property(e => e.AlternateTaxonomy11Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_11_Id");
            entity.Property(e => e.AlternateTaxonomy12Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_12_Id");
            entity.Property(e => e.AlternateTaxonomy13Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_13_Id");
            entity.Property(e => e.AlternateTaxonomy14Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_14_Id");
            entity.Property(e => e.AlternateTaxonomy15Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_15_Id");
            entity.Property(e => e.AlternateTaxonomy16Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_16_Id");
            entity.Property(e => e.AlternateTaxonomy17Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_17_Id");
            entity.Property(e => e.AlternateTaxonomy18Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_18_Id");
            entity.Property(e => e.AlternateTaxonomy19Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_19_Id");
            entity.Property(e => e.AlternateTaxonomy1Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_1_Id");
            entity.Property(e => e.AlternateTaxonomy20Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_20_Id");
            entity.Property(e => e.AlternateTaxonomy2Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_2_Id");
            entity.Property(e => e.AlternateTaxonomy3Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_3_Id");
            entity.Property(e => e.AlternateTaxonomy4Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_4_Id");
            entity.Property(e => e.AlternateTaxonomy5Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_5_Id");
            entity.Property(e => e.AlternateTaxonomy6Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_6_Id");
            entity.Property(e => e.AlternateTaxonomy7Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_7_Id");
            entity.Property(e => e.AlternateTaxonomy8Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_8_Id");
            entity.Property(e => e.AlternateTaxonomy9Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_9_Id");
            entity.Property(e => e.ClExpiration)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CL_Expiration");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.IsActive)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Is_Active");
            entity.Property(e => e.IsBilling)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Is_Billing");
            entity.Property(e => e.IsScheduling)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Is_Scheduling");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.LicenseIssuingCountryId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("License_Issuing_Country_Id");
            entity.Property(e => e.LicenseIssuingStateId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("License_Issuing_State_Id");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Middle_Name");
            entity.Property(e => e.PrimaryTaxonomyId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Primary_Taxonomy_Id");
            entity.Property(e => e.ProviderCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Provider_Code");
            entity.Property(e => e.ProviderDeaNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Provider_DEA_Number");
            entity.Property(e => e.ProviderDob)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Provider_DOB");
            entity.Property(e => e.ProviderEin)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Provider_EIN");
            entity.Property(e => e.ProviderId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Provider_Id");
            entity.Property(e => e.ProviderLicenseNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Provider_License_No");
            entity.Property(e => e.ProviderMedicaidNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Provider_Medicaid_Number");
            entity.Property(e => e.ProviderNpi)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Provider_NPI");
            entity.Property(e => e.ProviderSpecialityId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Provider_Speciality_Id");
            entity.Property(e => e.ProviderSsn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Provider_SSN");
            entity.Property(e => e.ProviderUpin)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Provider_UPIN");
            entity.Property(e => e.SpectacleExpiration)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Spectacle_Expiration");
            entity.Property(e => e.Suffix)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Recall>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Recall__3214EC27BCF9BB8B");

            entity.ToTable("Recall");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.BillingLocationId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BillingLocationID");
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PatientId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PatientID");
            entity.Property(e => e.RecallDate)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RecallId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RecallID");
            entity.Property(e => e.RecallTypeId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RecallTypeID");
            entity.Property(e => e.ResourceId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ResourceID");
        });

        modelBuilder.Entity<RecallType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Recall_T__3214EC27E218B230");

            entity.ToTable("Recall_Type");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DefaultDuration)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.RecallTypeId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RecallTypeID");
        });

        modelBuilder.Entity<Referral>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Referral__3214EC27FEA59D0A");

            entity.ToTable("Referral");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AlternateTaxonomy10Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_10_Id");
            entity.Property(e => e.AlternateTaxonomy11Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_11_Id");
            entity.Property(e => e.AlternateTaxonomy12Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_12_Id");
            entity.Property(e => e.AlternateTaxonomy13Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_13_Id");
            entity.Property(e => e.AlternateTaxonomy14Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_14_Id");
            entity.Property(e => e.AlternateTaxonomy15Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_15_Id");
            entity.Property(e => e.AlternateTaxonomy16Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_16_Id");
            entity.Property(e => e.AlternateTaxonomy17Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_17_Id");
            entity.Property(e => e.AlternateTaxonomy18Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_18_Id");
            entity.Property(e => e.AlternateTaxonomy19Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_19_Id");
            entity.Property(e => e.AlternateTaxonomy1Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_1_Id");
            entity.Property(e => e.AlternateTaxonomy20Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_20_Id");
            entity.Property(e => e.AlternateTaxonomy2Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_2_Id");
            entity.Property(e => e.AlternateTaxonomy3Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_3_Id");
            entity.Property(e => e.AlternateTaxonomy4Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_4_Id");
            entity.Property(e => e.AlternateTaxonomy5Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_5_Id");
            entity.Property(e => e.AlternateTaxonomy6Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_6_Id");
            entity.Property(e => e.AlternateTaxonomy7Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_7_Id");
            entity.Property(e => e.AlternateTaxonomy8Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_8_Id");
            entity.Property(e => e.AlternateTaxonomy9Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alternate_Taxonomy_9_Id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.IsActive)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Is_Active");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.LicenseIssuingCountryId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("License_Issuing_Country_Id");
            entity.Property(e => e.LicenseIssuingStateId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("License_Issuing_State_Id");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Middle_Name");
            entity.Property(e => e.PrimaryTaxonomyId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Primary_Taxonomy_Id");
            entity.Property(e => e.ReferralCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Referral_Code");
            entity.Property(e => e.ReferralDeaNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Referral_DEA_Number");
            entity.Property(e => e.ReferralDob)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Referral_DOB");
            entity.Property(e => e.ReferralEin)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Referral_EIN");
            entity.Property(e => e.ReferralId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Referral_Id");
            entity.Property(e => e.ReferralLicenseNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Referral_License_No");
            entity.Property(e => e.ReferralMedicaidNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Referral_Medicaid_Number");
            entity.Property(e => e.ReferralNpi)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Referral_NPI");
            entity.Property(e => e.ReferralSpecialityId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Referral_Speciality_Id");
            entity.Property(e => e.ReferralSsn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Referral_SSN");
            entity.Property(e => e.ReferralUpin)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Referral_UPIN");
            entity.Property(e => e.Suffix)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SchedCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sched_Co__3214EC27A405DDD5");

            entity.ToTable("Sched_Code");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.IsNoShow)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.SchedulingCodeId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SchedulingCodeID");
            entity.Property(e => e.TypeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("TypeID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
