using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class VwLensType
{
    public long LensTypeId { get; set; }

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int CatalogId { get; set; }

    public virtual VwSupplierCatalog Catalog { get; set; } = null!;
}
