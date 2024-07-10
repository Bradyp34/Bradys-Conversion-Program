using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsD;

public partial class InvDbContext : DbContext
{
    private readonly string _connectionString;

    public InvDbContext(string connectionString) {
        _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public InvDbContext(DbContextOptions<InvDbContext> options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        : base(options)
    {
    }

    public virtual DbSet<ClBrand> ClBrands { get; set; }

    public virtual DbSet<ClInventory> ClInventories { get; set; }

    public virtual DbSet<ClLense> ClLenses { get; set; }

    public virtual DbSet<Cpt> Cpts { get; set; }

    public virtual DbSet<CptDept> CptDepts { get; set; }

    public virtual DbSet<CptMapping> CptMappings { get; set; }

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
        => optionsBuilder.UseSqlServer(_connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClBrand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CL Brand__3214EC27135F657C");

            entity.ToTable("CL Brands");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddedBy)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ADDED_BY");
            entity.Property(e => e.AddedDate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ADDED_DATE");
            entity.Property(e => e.BrandCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BRAND_CODE");
            entity.Property(e => e.BrandName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BRAND_NAME");
            entity.Property(e => e.ClnsBrandId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CLNS_BRAND_ID");
            entity.Property(e => e.IsActive)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("IS_ACTIVE");
            entity.Property(e => e.LocationId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LOCATION_ID");
        });

        modelBuilder.Entity<ClInventory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CL Inven__3214EC2737241797");

            entity.ToTable("CL Inventory");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ADDED_BY");
            entity.Property(e => e.AddedDate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ADDED_DATE");
            entity.Property(e => e.Barcode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("BARCODE");
            entity.Property(e => e.ContactLensId).HasColumnName("CONTACT_LENS_ID");
            entity.Property(e => e.Dispensed)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DISPENSED");
            entity.Property(e => e.ExpiryDate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EXPIRY_DATE");
            entity.Property(e => e.InvoiceDate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("INVOICE_DATE");
            entity.Property(e => e.InvoiceNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("INVOICE_NUMBER");
            entity.Property(e => e.IsActive)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("IS_ACTIVE");
            entity.Property(e => e.IsTrials)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("IS_TRIALS");
            entity.Property(e => e.ItemCost)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ITEM_COST");
            entity.Property(e => e.LocationId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LOCATION_ID");
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.OnHand)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ON_HAND");
            entity.Property(e => e.QuantityOrdered)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("QUANTITY_ORDERED");
            entity.Property(e => e.Received)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("RECEIVED");
            entity.Property(e => e.RetailPrice)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RETAIL_PRICE");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("UPDATED_BY");
            entity.Property(e => e.UpdatedDate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPDATED_DATE");
            entity.Property(e => e.WholesalePrice)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WHOLESALE_PRICE");
        });

        modelBuilder.Entity<ClLense>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CL Lense__3214EC2758F913D4");

            entity.ToTable("CL Lenses");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddPower)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ADD_POWER");
            entity.Property(e => e.AddPowerName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ADD_POWER_NAME");
            entity.Property(e => e.AddedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ADDED_BY");
            entity.Property(e => e.AddedDate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ADDED_DATE");
            entity.Property(e => e.Axis)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("AXIS");
            entity.Property(e => e.BaseCurve)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("BASE_CURVE");
            entity.Property(e => e.ClnsBrandId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CLNS_BRAND_ID");
            entity.Property(e => e.ClnsLensTypeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CLNS_LENS_TYPE_ID");
            entity.Property(e => e.ClnsManufacturerId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CLNS_MANUFACTURER_ID");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("COLOR");
            entity.Property(e => e.CptId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CPT_ID");
            entity.Property(e => e.Cylinder)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CYLINDER");
            entity.Property(e => e.Diameter)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DIAMETER");
            entity.Property(e => e.IsActive)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("IS_ACTIVE");
            entity.Property(e => e.IsLensFromClxCatalog)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("IS_LENS_FROM_CLX_CATALOG");
            entity.Property(e => e.IsSoftContact)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("IS_SOFT_CONTACT");
            entity.Property(e => e.LensPerBox)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LENS_PER_BOX");
            entity.Property(e => e.LocationId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LOCATION_ID");
            entity.Property(e => e.Multifocal)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MULTIFOCAL");
            entity.Property(e => e.Sphere)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SPHERE");
            entity.Property(e => e.Upc)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("UPC");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPDATED_BY");
            entity.Property(e => e.UpdatedDate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPDATED_DATE");
        });

        modelBuilder.Entity<Cpt>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CPTs__3214EC270DCDCDAD");

            entity.ToTable("CPTs");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.AlternateCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.AutoUpdateReferringProvider)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Cpt1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CPT");
            entity.Property(e => e.Cptid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CPTID");
            entity.Property(e => e.DepartmentId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DepartmentID");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Fee)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LocationId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LocationID");
            entity.Property(e => e.NdcActive)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("NDC_Active");
            entity.Property(e => e.NdcCode)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("NDC_Code");
            entity.Property(e => e.NdcCost)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("NDC_Cost");
            entity.Property(e => e.NdcQuantity)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("NDC_Quantity");
            entity.Property(e => e.NdcUnitsMeasurementId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("NDC_Units_Measurement_Id");
            entity.Property(e => e.PrivateStatementDescription)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.SortOrder)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TaxTypeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("TaxTypeID");
            entity.Property(e => e.Taxable)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TypeOfServiceId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("TypeOfServiceID");
            entity.Property(e => e.Units)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UseClianumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("UseCLIANumber");
        });

        modelBuilder.Entity<CptDept>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CPT Dept__3214EC275E27AEF6");

            entity.ToTable("CPT Dept");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DepartmentId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DepartmentID");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.LocationId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LocationID");
            entity.Property(e => e.SortNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Sort_Number");
        });

        modelBuilder.Entity<CptMapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CPT Mapp__3214EC271E548074");

            entity.ToTable("CPT Mapping");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CptId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.GroupId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LocationId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LocationID");
            entity.Property(e => e.MappingId)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Frame>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Frames__3214EC275587845C");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.A)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.AgeGroupId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("AgeGroupID");
            entity.Property(e => e.B)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.BrandId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("BrandID");
            entity.Property(e => e.Bridge)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ChangedPrice)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Circumference)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CollectionId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CollectionID");
            entity.Property(e => e.CompletePrice)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CountryId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CountryID");
            entity.Property(e => e.Cptid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CPTID");
            entity.Property(e => e.DateAdded)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Dbl)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DBL");
            entity.Property(e => e.Ed)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ED");
            entity.Property(e => e.Edangle)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EDAngle");
            entity.Property(e => e.Eye)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Fpc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FPC");
            entity.Property(e => e.FrameCategoryId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("FrameCategoryID");
            entity.Property(e => e.FrameColorId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("FrameColorID");
            entity.Property(e => e.FrameId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FrameID");
            entity.Property(e => e.FrameMountId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("FrameMountID");
            entity.Property(e => e.FrameShapeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("FrameShapeID");
            entity.Property(e => e.FrontPrice)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.GenderId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("GenderID");
            entity.Property(e => e.HalfTemplesPrice)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdated)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LensColorId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LensColorID");
            entity.Property(e => e.LocationId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LocationID");
            entity.Property(e => e.ManufacturerId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ManufacturerID");
            entity.Property(e => e.MaterialId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaterialID");
            entity.Property(e => e.Sku)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SKU");
            entity.Property(e => e.StyleId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("StyleID");
            entity.Property(e => e.StyleName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StyleNew)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Temple)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TemplesPrice)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Upc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("UPC");
            entity.Property(e => e.VendorId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VendorID");
            entity.Property(e => e.YearIntroduced)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FrameCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Frame Ca__3214EC2768763AEA");

            entity.ToTable("Frame Category");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CategoryDescription)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CategoryId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LocationId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LocationID");
            entity.Property(e => e.SortOrder)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FrameCollection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Frame Co__3214EC27BEAFFFB2");

            entity.ToTable("Frame Collection");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CollectionId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CollectionID");
            entity.Property(e => e.CollectionName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LocationId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LocationID");
        });

        modelBuilder.Entity<FrameColor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Frame Co__3214EC2721C54F85");

            entity.ToTable("Frame Color");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ColorCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ColorDescription)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FrameColorId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("FrameColorID");
            entity.Property(e => e.LocationId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LocationID");
        });

        modelBuilder.Entity<FrameEtype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FrameETy__3214EC27D2B41AE4");

            entity.ToTable("FrameEType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Etype)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EType");
            entity.Property(e => e.EtypeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ETypeID");
            entity.Property(e => e.LabCode)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FrameFtype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FrameFTy__3214EC279363411F");

            entity.ToTable("FrameFType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Ftype)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FType");
            entity.Property(e => e.FtypeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("FTypeID");
            entity.Property(e => e.LabCode)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FrameLensColor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FrameLen__3214EC2721B8551A");

            entity.ToTable("FrameLensColor");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ColorCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ColorDescription)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.LensColorId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LensColorID");
            entity.Property(e => e.LocationId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LocationID");
            entity.Property(e => e.StatusId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("StatusID");
        });

        modelBuilder.Entity<FrameMaterial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FrameMat__3214EC27A01B8FA6");

            entity.ToTable("FrameMaterial");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LocationId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LocationID");
            entity.Property(e => e.MaterialDescription)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.MaterialId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaterialID");
            entity.Property(e => e.MaterialName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SortOrder)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FrameMount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FrameMou__3214EC277B1B6CED");

            entity.ToTable("FrameMount");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FrameMount1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FrameMount");
            entity.Property(e => e.FrameMountId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("FrameMountID");
            entity.Property(e => e.LocationId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LocationID");
            entity.Property(e => e.MountDescription)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.SortOrder)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FrameOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FrameOrd__3214EC270ADB0589");

            entity.ToTable("FrameOrder");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.A)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.B)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Bridge)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Color)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CptId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Csize)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CSize");
            entity.Property(e => e.Dbl)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Ed)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.EtypId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ETypId");
            entity.Property(e => e.Eye)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FrameOrderInfoId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FtypId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("FTypId");
            entity.Property(e => e.InventoryId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("[InventoryId");
            entity.Property(e => e.IsLmsframe)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("IsLMSFrame");
            entity.Property(e => e.ManufacturerId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaterialId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Retail)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.StatusId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TempleSize)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TempleStyleId)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FrameShape>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Frame Sh__3214EC27F1C2EE64");

            entity.ToTable("Frame Shape");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FrameShape1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("FrameShape");
            entity.Property(e => e.LocationId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LocationID");
            entity.Property(e => e.ShapeDescription)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ShapeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ShapeID");
            entity.Property(e => e.SortOrder)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FrameStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Frame St__3214EC27182C7233");

            entity.ToTable("Frame Status");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LabCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.StatusId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("StatusID");
        });

        modelBuilder.Entity<FrameTemple>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Frame Te__3214EC27B51FE5E6");

            entity.ToTable("Frame Temple");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LabCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TempleId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("TempleID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
