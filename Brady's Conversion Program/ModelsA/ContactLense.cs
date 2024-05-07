using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class ContactLense
{
    public long LensId { get; set; }

    public decimal? Sphere { get; set; }

    public decimal? Cylinder { get; set; }

    public decimal? Base { get; set; }

    public decimal? Diameter { get; set; }

    public long? CptId { get; set; }

    public int? Quantity { get; set; }

    public decimal? Cost { get; set; }

    public string? Brand { get; set; }

    public string? Color { get; set; }

    public decimal? AddPower { get; set; }
}
