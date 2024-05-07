using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class VwSupplierCatalog
{
    public int SupplierId { get; set; }

    public string SupplierName { get; set; } = null!;

    public string Supplier { get; set; } = null!;

    public string LabName { get; set; } = null!;

    public long LabId { get; set; }

    public string Address { get; set; } = null!;

    public string Address2 { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Country { get; set; } = null!;

    public DateTime? LastUpdated { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? RefId { get; set; }

    public string? Type { get; set; }

    public string? Supid { get; set; }

    public TimeOnly? LastUpdateStartTime { get; set; }

    public TimeOnly? LastUpdateEndTime { get; set; }

    public virtual ICollection<VwDesign> VwDesigns { get; set; } = new List<VwDesign>();

    public virtual ICollection<VwFrameType> VwFrameTypes { get; set; } = new List<VwFrameType>();

    public virtual ICollection<VwIncompatibleTreatmentsMaster> VwIncompatibleTreatmentsMasters { get; set; } = new List<VwIncompatibleTreatmentsMaster>();

    public virtual ICollection<VwLensMaster> VwLensMasters { get; set; } = new List<VwLensMaster>();

    public virtual ICollection<VwLensType> VwLensTypes { get; set; } = new List<VwLensType>();

    public virtual ICollection<VwMaterial> VwMaterials { get; set; } = new List<VwMaterial>();

    public virtual ICollection<VwTreatment> VwTreatments { get; set; } = new List<VwTreatment>();
}
