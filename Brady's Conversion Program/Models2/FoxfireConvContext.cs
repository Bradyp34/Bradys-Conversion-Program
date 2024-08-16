using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.Models2;

public partial class FoxfireConvContext : DbContext
{
    private readonly string _connectionString;
    public FoxfireConvContext(string connectionString) {
        _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public FoxfireConvContext(DbContextOptions<FoxfireConvContext> options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        : base(options)
    {
    }

    public virtual DbSet<AccountXref> AccountXrefs { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<AppointmentType> AppointmentTypes { get; set; }

    public virtual DbSet<Guarantor> Guarantors { get; set; }

    public virtual DbSet<Insurance> Insurances { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<MaritalStatusXref> MaritalStatusXrefs { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PatientAlert> PatientAlerts { get; set; }

    public virtual DbSet<PatientDocument> PatientDocuments { get; set; }

    public virtual DbSet<PatientInsurance> PatientInsurances { get; set; }

    public virtual DbSet<PatientNote> PatientNotes { get; set; }

    public virtual DbSet<Phone> Phones { get; set; }

    public virtual DbSet<PolicyHolder> PolicyHolders { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<Recall> Recalls { get; set; }

    public virtual DbSet<RecallType> RecallTypes { get; set; }

    public virtual DbSet<Referral> Referrals { get; set; }

    public virtual DbSet<RelationshipXref> RelationshipXrefs { get; set; }

    public virtual DbSet<SchedCode> SchedCodes { get; set; }

    public virtual DbSet<StateXref> StateXrefs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<AppointmentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Appointment_Type");
        });

        modelBuilder.Entity<Guarantor>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Insurance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Insuranc__3214EC272E239185");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Location__3214EC271FD118FE");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<PatientAlert>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Patient___3214EC275728D617");
        });

        modelBuilder.Entity<PatientDocument>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Patient___3214EC27F490DA5D");
        });

        modelBuilder.Entity<PatientInsurance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Patient___3214EC270CE887D3");
        });

        modelBuilder.Entity<PatientNote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Patient___3214EC270F6E5652");
        });

        modelBuilder.Entity<Phone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Phone__3214EC2780DCD4C4");
        });

        modelBuilder.Entity<PolicyHolder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Name__3214EC27967A86F2");
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Provider__3214EC27641CD647");
        });

        modelBuilder.Entity<Recall>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Recall__3214EC27BCF9BB8B");
        });

        modelBuilder.Entity<RecallType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Recall_T__3214EC27E218B230");
        });

        modelBuilder.Entity<Referral>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Referral__3214EC27FEA59D0A");
        });

        modelBuilder.Entity<SchedCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sched_Co__3214EC27A405DDD5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
