using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsD;

public partial class InvDbContext : DbContext {
    private readonly string _connectionString;

    public InvDbContext(string connectionString) {
        _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public InvDbContext(DbContextOptions<InvDbContext> options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        : base(options) {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Clbrand> Clbrands { get; set; }

    public virtual DbSet<Clinventory> Clinventories { get; set; }

    public virtual DbSet<Cllense> Cllenses { get; set; }

    public virtual DbSet<Cpt> Cpts { get; set; }

    public virtual DbSet<Cptdept> Cptdepts { get; set; }

    public virtual DbSet<Cptmapping> Cptmappings { get; set; }

    public virtual DbSet<Frame> Frames { get; set; }

    public virtual DbSet<FrameBrand> FrameBrands { get; set; }

    public virtual DbSet<FrameCategory> FrameCategories { get; set; }

    public virtual DbSet<FrameCollection> FrameCollections { get; set; }

    public virtual DbSet<FrameColor> FrameColors { get; set; }

    public virtual DbSet<FrameEtype> FrameEtypes { get; set; }

    public virtual DbSet<FrameFtype> FrameFtypes { get; set; }

    public virtual DbSet<FrameInventory> FrameInventories { get; set; }

    public virtual DbSet<FrameLensColor> FrameLensColors { get; set; }

    public virtual DbSet<FrameManufacturer> FrameManufacturers { get; set; }

    public virtual DbSet<FrameMaterial> FrameMaterials { get; set; }

    public virtual DbSet<FrameMount> FrameMounts { get; set; }

    public virtual DbSet<FrameOrder> FrameOrders { get; set; }

    public virtual DbSet<FrameShape> FrameShapes { get; set; }

    public virtual DbSet<FrameStatus> FrameStatuses { get; set; }

    public virtual DbSet<FrameTemple> FrameTemples { get; set; }

    public virtual DbSet<FrameVendor> FrameVendors { get; set; }

    public virtual DbSet<Phone> Phones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlServer(_connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Address");

            entity.Property(e => e.Active)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Address1)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Address2)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Note).IsUnicode(false);
            entity.Property(e => e.PrimaryFile)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PrimaryFileId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PrimaryFileID");
            entity.Property(e => e.State)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TypeOfAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Zip)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Clbrand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CL Brand__3214EC27135F657C");

            entity.ToTable("CLBrands");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.AddedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.AddedDate)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.BrandCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.BrandName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LocationId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LocationID");
            entity.Property(e => e.OldClnsbrandId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OldCLNSBrandID");
        });

        modelBuilder.Entity<Clinventory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CL Inven__3214EC2737241797");

            entity.ToTable("CLInventory");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AddedDate)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Barcode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ContactLensId).HasColumnName("ContactLensID");
            entity.Property(e => e.Dispensed)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ExpiryDate)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.InvoiceDate)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.InvoiceNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsActive)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.IsTrials)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ItemCost)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LocationId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LocationID");
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OnHand)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.QuantityOrdered)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Received)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.RetailPrice)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.WholesalePrice)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cllense>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CL Lense__3214EC2758F913D4");

            entity.ToTable("CLLenses");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.AddPower)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.AddPowerName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.AddedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("AddedBY");
            entity.Property(e => e.AddedDate)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Axis)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.BaseCurve)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ClndbrandId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CLNDBrandID");
            entity.Property(e => e.ClnslensTypeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CLNSLensTypeID");
            entity.Property(e => e.ClnsmanufacturerId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CLNSManufacturerID");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CptId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CptID");
            entity.Property(e => e.Cylinder)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Diameter)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.IsLensFromClxcatalog)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("IsLensFromCLXCatalog");
            entity.Property(e => e.IsSoftContact)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LensPerBox)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LocationId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LocationID");
            entity.Property(e => e.Multifocal)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sphere)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Upc)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("UPC");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate)
                .HasMaxLength(20)
                .IsUnicode(false);
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
            entity.Property(e => e.CptId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CptID");
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
            entity.Property(e => e.Ndcactive)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("NDCActive");
            entity.Property(e => e.Ndccode)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("NDCCode");
            entity.Property(e => e.Ndccost)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("NDCCost");
            entity.Property(e => e.Ndcquantity)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("NDCQuantity");
            entity.Property(e => e.NdcunitsMeasurementId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("NDCUnitsMeasurementId");
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

        modelBuilder.Entity<Cptdept>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CPT Dept__3214EC275E27AEF6");

            entity.ToTable("CPTDept");

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
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cptmapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CPT Mapp__3214EC271E548074");

            entity.ToTable("CPTMapping");

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
            entity.HasKey(e => e.Id).HasName("PK__Frames__3214EC27FBFB4B9D");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.A)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.AgeGroupId)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("AgeGroupID");
            entity.Property(e => e.B)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.BrandId)
                .HasMaxLength(500)
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
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("CollectionID");
            entity.Property(e => e.CompletePrice)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CountryId)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("CountryID");
            entity.Property(e => e.Cptid)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("CPTID");
            entity.Property(e => e.DateAdded)
                .HasMaxLength(100)
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
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FrameCategoryID");
            entity.Property(e => e.FrameColorId)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FrameColorID");
            entity.Property(e => e.FrameMountId)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FrameMountID");
            entity.Property(e => e.FrameShapeId)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FrameShapeID");
            entity.Property(e => e.FrontPrice)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.GenderId)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("GenderID");
            entity.Property(e => e.HalfTemplesPrice)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdated)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LensColorId)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("LensColorID");
            entity.Property(e => e.LocationId)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("LocationID");
            entity.Property(e => e.ManufacturerId)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ManufacturerID");
            entity.Property(e => e.MaterialId)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("MaterialID");
            entity.Property(e => e.OldFrameId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("OldFrameID");
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
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("VendorID");
            entity.Property(e => e.YearIntroduced)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FrameBrand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FrameBrand__0BC6C43E");

            entity.ToTable("FrameBrand");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.BrandName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.LocationId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LocationID");
            entity.Property(e => e.OldBrandId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("OldBrandID");
        });

        modelBuilder.Entity<FrameCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Frame Ca__3214EC2768763AEA");

            entity.ToTable("FrameCategory");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CategoryDescription)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LocationId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LocationID");
            entity.Property(e => e.OldCategoryId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OldCategoryID");
            entity.Property(e => e.SortOrder)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FrameCollection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Frame Co__3214EC27BEAFFFB2");

            entity.ToTable("FrameCollection");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CollectionName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LocationId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LocationID");
            entity.Property(e => e.OldCollectionId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OldCollectionID");
        });

        modelBuilder.Entity<FrameColor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FrameCol__3214EC279F3D6839");

            entity.ToTable("FrameColor");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ColorCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ColorDescription)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.LocationId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LocationID");
            entity.Property(e => e.OldFrameColorId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OldFrameColorID");
        });

        modelBuilder.Entity<FrameEtype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FrameETy__3214EC27D2B41AE4");

            entity.ToTable("FrameEType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Etype)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EType");
            entity.Property(e => e.LabCode)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.OldEtypeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OldETypeID");
        });

        modelBuilder.Entity<FrameFtype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FrameFTy__3214EC279363411F");

            entity.ToTable("FrameFType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Ftype)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FType");
            entity.Property(e => e.LabCode)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.OldFtypeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OldFTypeID");
        });

        modelBuilder.Entity<FrameInventory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Inventory__1CF15040");

            entity.ToTable("FrameInventory");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Barcode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Consignment)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cost)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateAdded)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Dispensed)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Donation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FrameId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FrameID");
            entity.Property(e => e.InvoiceDate)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.InvoiceNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Lost)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Note).IsUnicode(false);
            entity.Property(e => e.OldFrameId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("OldFrameID");
            entity.Property(e => e.OldInventoryId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("OldInventoryID");
            entity.Property(e => e.OldLocationId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("OldLocationID");
            entity.Property(e => e.OnHand)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.QuantityOrdered)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Received)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Retail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReturnedByCustomer)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReturnedToVendor)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Scrapped)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TransferredIn)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TransferredOut)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ValidInventory)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WholeSale)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FrameLensColor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FrameLen__3214EC2721B8551A");

            entity.ToTable("FrameLensColor");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ColorCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ColorDescription)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.LocationId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LocationID");
            entity.Property(e => e.OldLensColorId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OldLensColorID");
            entity.Property(e => e.StatusId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("StatusID");
        });

        modelBuilder.Entity<FrameManufacturer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FrameManufacturers__7C8480AE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AccountNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AccountRep1)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AccountRep2)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AccountRep3)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AccountRep4)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Active).HasColumnName("ACTIVE");
            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.ContactId).HasColumnName("ContactID");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.ManufacturerName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.OldManufacturerId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("OldManufacturerID");
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.Website)
                .HasMaxLength(255)
                .IsUnicode(false);
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
            entity.Property(e => e.MaterialName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OldMaterialId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OldMaterialID");
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
            entity.Property(e => e.LocationId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LocationID");
            entity.Property(e => e.MountDescription)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OldFrameMountId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OldFrameMountID");
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
            entity.Property(e => e.Active)
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
            entity.Property(e => e.OldFrameOrderInfoId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OldFrameOrderInfoID");
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

            entity.ToTable("FrameShape");

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
            entity.Property(e => e.OldShapeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OldShapeID");
            entity.Property(e => e.ShapeDescription)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SortOrder)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FrameStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Frame St__3214EC27182C7233");

            entity.ToTable("FrameStatus");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LabCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.OldStatusId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OldStatusID");
        });

        modelBuilder.Entity<FrameTemple>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Frame Te__3214EC27B51FE5E6");

            entity.ToTable("FrameTemple");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LabCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.OldTempleId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OldTempleID");
        });

        modelBuilder.Entity<FrameVendor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FrameVendor__0BC6C43E");

            entity.ToTable("FrameVendor");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LocationId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LocationID");
            entity.Property(e => e.OldVendorId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("OldVendorID");
            entity.Property(e => e.VendorAccount)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VendorAgent)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VendorEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VendorName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.VendorWebSite)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Phone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Phone__3214EC2780DCD4C4");

            entity.ToTable("Phone");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Extension)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Note)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PrimaryFile)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PrimaryFileId).HasColumnName("PrimaryFileID");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
