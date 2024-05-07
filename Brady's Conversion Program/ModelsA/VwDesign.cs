using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class VwDesign
{
    public long DesignId { get; set; }

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public long ParameterId { get; set; }

    public long LensTypeId { get; set; }

    public int CatalogId { get; set; }

    public virtual VwSupplierCatalog Catalog { get; set; } = null!;

    public virtual ICollection<VwLensMaster> VwLensMasters { get; set; } = new List<VwLensMaster>();
}
