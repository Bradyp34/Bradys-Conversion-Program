using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class ImportManufacturer
{
    public long ImportManufacturersId { get; set; }

    public string ManufacturerId { get; set; } = null!;

    public string ManufacturerName { get; set; } = null!;

    public string? BrandName { get; set; }

    public DateTime? LastImportedDate { get; set; }

    public bool NewImport { get; set; }
}
