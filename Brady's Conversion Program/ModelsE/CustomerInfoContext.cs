using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsE;

public partial class CustomerInfoContext : DbContext
{
    private readonly string _connectionString;
    public CustomerInfoContext(string connectionString) {
        _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public CustomerInfoContext(DbContextOptions<CustomerInfoContext> options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        : base(options)
    {
    }

    public virtual DbSet<AccessLog> AccessLogs { get; set; }

    public DbSet<AccountXref> AccountXrefs { get; set; }

    public virtual DbSet<AppointmentLocationXref> AppointmentLocationXrefs { get; set; }

    public virtual DbSet<AppointmentProviderXref> AppointmentProviderXrefs { get; set; }

    public virtual DbSet<AppointmentTypeXref> AppointmentTypeXrefs { get; set; }

    public virtual DbSet<BillingLocationXref> BillingLocationXrefs { get; set; }

    public virtual DbSet<BillingProviderXref> BillingProviderXrefs { get; set; }

    public virtual DbSet<ButtonSetup> ButtonSetups { get; set; }

    public virtual DbSet<Clinic> Clinics { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<EmployerXref> EmployerXrefs { get; set; }

    public virtual DbSet<Error> Errors { get; set; }

    public virtual DbSet<ImageEyeMdXref> ImageEyeMdXrefs { get; set; }

    public virtual DbSet<ImageFfpmXref> ImageFfpmXrefs { get; set; }

    public virtual DbSet<ImageXref> ImageXrefs { get; set; }

    public virtual DbSet<InitialSetup> InitialSetups { get; set; }

    public virtual DbSet<InsuranceXref> InsuranceXrefs { get; set; }

    public virtual DbSet<MaritalStatusXref> MaritalStatusXrefs { get; set; }

    public virtual DbSet<RecallLocationXref> RecallLocationXrefs { get; set; }

    public virtual DbSet<RecallProviderXref> RecallProviderXrefs { get; set; }

    public virtual DbSet<RecallTypeXref> RecallTypeXrefs { get; set; }

    public virtual DbSet<ReferralXref> ReferralXrefs { get; set; }

    public virtual DbSet<RelationshipXref> RelationshipXrefs { get; set; }

    public virtual DbSet<StateXref> StateXrefs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccessLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("AccessLog");

            entity.Property(e => e.AccessDate).HasColumnType("datetime");
            entity.Property(e => e.Area)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Note)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.UserCode)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AppointmentLocationXref>(entity =>
        {
            entity.HasKey(e => e.AppointmentLocId).HasName("PK__Appointm__C3CF3CF776969D2E");

            entity.ToTable("Appointment_Location_Xref");

            entity.Property(e => e.AppointmentLocId).HasColumnName("AppointmentLocID");
            entity.Property(e => e.Address1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Address2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LocationId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LocationID");
            entity.Property(e => e.LocationName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Location_Name");
            entity.Property(e => e.NavCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Phone_Number");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ZipCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Zip_Code");
        });

        modelBuilder.Entity<AppointmentProviderXref>(entity =>
        {
            entity.HasKey(e => e.ProvId).HasName("PK__Appointm__13196A3257DD0BE4");

            entity.ToTable("Appointment_Provider_Xref");

            entity.Property(e => e.ProvId).HasColumnName("ProvID");
            entity.Property(e => e.Address1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Address2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.NavCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Npi)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NPI");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Phone_Number");
            entity.Property(e => e.ProvCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ZipCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Zip_Code");
        });

        modelBuilder.Entity<AppointmentTypeXref>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__Appointm__8ECDFCC221EBF29D");

            entity.ToTable("Appointment_Type_Xref");

            entity.Property(e => e.AppointmentMonths)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Appointment_months");
            entity.Property(e => e.AppointmentName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Appointment_name");
            entity.Property(e => e.AppointmentNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Appointment_no");
            entity.Property(e => e.NavCode)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BillingLocationXref>(entity =>
        {
            entity.HasKey(e => e.BillingLocId).HasName("PK__Billing___7394C58402084FDA");

            entity.ToTable("Billing_Location_Xref");

            entity.Property(e => e.BillingLocId).HasColumnName("BillingLocID");
            entity.Property(e => e.Address1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Address2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LocationId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LocationID");
            entity.Property(e => e.LocationName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Location_Name");
            entity.Property(e => e.NavCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Phone_Number");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ZipCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Zip_Code");
        });

        modelBuilder.Entity<BillingProviderXref>(entity =>
        {
            entity.HasKey(e => e.ProvId).HasName("PK__Billing___13196A324F47C5E3");

            entity.ToTable("Billing_Provider_Xref");

            entity.Property(e => e.ProvId).HasColumnName("ProvID");
            entity.Property(e => e.Address1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Address2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.NavCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Npi)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NPI");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Phone_Number");
            entity.Property(e => e.ProvCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ZipCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Zip_Code");
        });

        modelBuilder.Entity<ButtonSetup>(entity =>
        {
            entity.HasKey(e => e.ButtonId).HasName("PK__button_s__EF873A436442E2C9");

            entity.ToTable("button_setup");

            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Description)
                .HasMaxLength(39)
                .IsUnicode(false);
            entity.Property(e => e.Emails)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("emails");
            entity.Property(e => e.Finalized).HasColumnName("finalized");
            entity.Property(e => e.SecondTitle)
                .HasMaxLength(130)
                .IsUnicode(false)
                .HasColumnName("secondTitle");
            entity.Property(e => e.Stage).HasColumnName("stage");
        });

        modelBuilder.Entity<Clinic>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Clinic");

            entity.Property(e => e.Address1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Address2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AfterHours)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("After_Hours");
            entity.Property(e => e.Cell)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fax)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FedId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Fed_Id");
            entity.Property(e => e.LegalName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Legal_Name");
            entity.Property(e => e.MainPhone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Main_Phone");
            entity.Property(e => e.MarketingName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Marketing_Name");
            entity.Property(e => e.State)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.WhoseCell)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Whose_Cell");
            entity.Property(e => e.WhoseEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Whose_Email");
            entity.Property(e => e.Zip)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PK_contacts");

            entity.Property(e => e.ContactId).HasColumnName("Contact_Id");
            entity.Property(e => e.Cell)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Hours)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Notes)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EmployerXref>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__Employer__AF2DBA7910566F31");

            entity.ToTable("Employer_Xref");

            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.Address1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Address2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmployerId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EmployerID");
            entity.Property(e => e.EmployerName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Employer_Name");
            entity.Property(e => e.NavCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Phone_Number");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ZipCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Zip_Code");
        });

        modelBuilder.Entity<Error>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CustomerNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("customerNumber");
            entity.Property(e => e.ErrorDate)
                .HasColumnType("datetime")
                .HasColumnName("errorDate");
            entity.Property(e => e.ErrorMessage)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("errorMessage");
            entity.Property(e => e.ErrorStackTrace)
                .IsUnicode(false)
                .HasColumnName("errorStackTrace");
            entity.Property(e => e.Errorlevel).HasColumnName("errorlevel");
            entity.Property(e => e.Location)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("location");
            entity.Property(e => e.Programid)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("programid");
            entity.Property(e => e.UserLoggedIn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("userLoggedIn");
        });

        modelBuilder.Entity<ImageEyeMdXref>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Image_EyeMD_Xref");

            entity.Property(e => e.EyeMdControlId).HasColumnName("EyeMd_Control_ID");
            entity.Property(e => e.EyeMdDocumentClass).HasColumnName("EyeMd_Document_Class");
            entity.Property(e => e.EyeMdImageCategory)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EyeMD_Image_Category");
            entity.Property(e => e.EyeMdImageType).HasColumnName("EyeMd_Image_Type");
            entity.Property(e => e.ImageCatId)
                .ValueGeneratedOnAdd()
                .HasColumnName("ImageCatID");
        });

        modelBuilder.Entity<ImageFfpmXref>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Image_FFPM_Xref");

            entity.Property(e => e.FfpmImageCategory)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FFPM_Image_Category");
            entity.Property(e => e.FfpmSettingId).HasColumnName("FFPM_SettingID");
            entity.Property(e => e.ImageCatId)
                .ValueGeneratedOnAdd()
                .HasColumnName("ImageCatID");
        });

        modelBuilder.Entity<ImageXref>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Image_Xref");

            entity.Property(e => e.EyeMdImageSetting).HasColumnName("EyeMD_Image_Setting");
            entity.Property(e => e.FfpmImageSetting).HasColumnName("FFPM_Image_Setting");
            entity.Property(e => e.ImageCount).HasColumnName("Image_Count");
            entity.Property(e => e.ImageId)
                .ValueGeneratedOnAdd()
                .HasColumnName("ImageID");
            entity.Property(e => e.ImageTypeOld)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<InitialSetup>(entity =>
        {
            entity.HasKey(e => e.IsId).HasName("PK__InitialS__C738A190151B244E");

            entity.ToTable("InitialSetup");

            entity.Property(e => e.IsId).HasColumnName("IS_Id");
            entity.Property(e => e.CompanyAcctCode)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<InsuranceXref>(entity =>
        {
            entity.HasKey(e => e.InsId).HasName("PK__Insuranc__9D104DEF256F241D");

            entity.ToTable("Insurance_Xref");

            entity.Property(e => e.Address1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Address2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BriefName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CarrierName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.InsCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MedicalVision)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Medical_Vision");
            entity.Property(e => e.NavCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PayerId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Payer_ID");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Phone_Number");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ZipCode)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MaritalStatusXref>(entity =>
        {
            entity.HasKey(e => e.Msid).HasName("PK__MaritalS__6CB36003232CBAAF");

            entity.ToTable("MaritalStatus_Xref");

            entity.Property(e => e.Msid).HasColumnName("MSID");
            entity.Property(e => e.Ms)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MS");
            entity.Property(e => e.NavCode)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RecallLocationXref>(entity =>
        {
            entity.HasKey(e => e.RecallLocId).HasName("PK__Recall_L__195292AD1CBC4616");

            entity.ToTable("Recall_Location_Xref");

            entity.Property(e => e.RecallLocId).HasColumnName("RecallLocID");
            entity.Property(e => e.Address1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Address2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LocationId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LocationID");
            entity.Property(e => e.LocationName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Location_Name");
            entity.Property(e => e.NavCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Phone_Number");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ZipCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Zip_Code");
        });

        modelBuilder.Entity<RecallProviderXref>(entity =>
        {
            entity.HasKey(e => e.ProvId).HasName("PK__Recall_P__13196A32245D67DE");

            entity.ToTable("Recall_Provider_Xref");

            entity.Property(e => e.ProvId).HasColumnName("ProvID");
            entity.Property(e => e.Address1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Address2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.NavCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Npi)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NPI");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Phone_Number");
            entity.Property(e => e.ProvCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ZipCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Zip_Code");
        });

        modelBuilder.Entity<RecallTypeXref>(entity =>
        {
            entity.HasKey(e => e.RecallId).HasName("PK__Recall_T__DB233983208CD6FA");

            entity.ToTable("Recall_Type_Xref");

            entity.Property(e => e.NavCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RecallMonths)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("recall_months");
            entity.Property(e => e.RecallName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("recall_name");
            entity.Property(e => e.RecallNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("recall_no");
        });

        modelBuilder.Entity<ReferralXref>(entity =>
        {
            entity.HasKey(e => e.RefId).HasName("PK__Referral__2D2A2CD1282DF8C2");

            entity.ToTable("Referral_Xref");

            entity.Property(e => e.RefId).HasColumnName("RefID");
            entity.Property(e => e.Address1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Address2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.NavCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Npi)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NPI");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Phone_Number");
            entity.Property(e => e.RefCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ZipCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Zip_Code");
        });

        modelBuilder.Entity<RelationshipXref>(entity =>
        {
            entity.HasKey(e => e.RelId).HasName("PK__Relation__2DA9EE4EFA157DB9");

            entity.ToTable("Relationship_Xref");

            entity.Property(e => e.RelId).HasColumnName("RelID");
            entity.Property(e => e.NavCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Relationship)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StateXref>(entity =>
        {
            entity.HasKey(e => e.StateId).HasName("PK__State_Xr__C3BA3B5ACDF89601");

            entity.ToTable("State_Xref");

            entity.Property(e => e.StateId).HasColumnName("StateID");
            entity.Property(e => e.NavCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
