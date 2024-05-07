using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class VwIncompatibleTreatmentsMaster
{
    public long Id { get; set; }

    public long TreatmentId { get; set; }

    public long IncompatibleTreatmentId { get; set; }

    public int CatalogId { get; set; }

    public virtual VwSupplierCatalog Catalog { get; set; } = null!;

    public virtual VwTreatment IncompatibleTreatment { get; set; } = null!;

    public virtual VwTreatment Treatment { get; set; } = null!;
}
