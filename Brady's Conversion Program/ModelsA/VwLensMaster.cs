using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class VwLensMaster
{
    public long Id { get; set; }

    public long MaterialId { get; set; }

    public long DesignId { get; set; }

    public string LensDescription { get; set; } = null!;

    public long TreatmentId { get; set; }

    public int Selectability { get; set; }

    public int CatalogId { get; set; }

    public virtual VwSupplierCatalog Catalog { get; set; } = null!;

    public virtual VwDesign Design { get; set; } = null!;

    public virtual VwMaterial Material { get; set; } = null!;

    public virtual VwTreatment Treatment { get; set; } = null!;
}
