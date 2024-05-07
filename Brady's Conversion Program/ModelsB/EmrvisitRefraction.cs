using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrvisitRefraction
{
    public int RefractionId { get; set; }

    public int? VisitId { get; set; }

    public int PtId { get; set; }

    public DateTime Dosdate { get; set; }

    public string RefractionClass { get; set; } = null!;

    public string? RefractionType { get; set; }

    public string? SphereOd { get; set; }

    public string? SphereOs { get; set; }

    public string? CylinderOd { get; set; }

    public string? CylinderOs { get; set; }

    public string? AxisOd { get; set; }

    public string? AxisOs { get; set; }

    public string? BifocalAddOd { get; set; }

    public string? BifocalAddOs { get; set; }

    public string? PrismTypeOd { get; set; }

    public string? PrismTypeOs { get; set; }

    public string? Prism360Od { get; set; }

    public string? Prism360Os { get; set; }

    public string? DirectionOd { get; set; }

    public string? DirectionOs { get; set; }

    public string? PdDistOd { get; set; }

    public string? PdDistOs { get; set; }

    public string? PdNearOd { get; set; }

    public string? PdNearOs { get; set; }

    public string? Age { get; set; }

    public string? VaDOd { get; set; }

    public string? VaDOs { get; set; }

    public string? VaDOu { get; set; }

    public string? VaNOd { get; set; }

    public string? VaNOs { get; set; }

    public string? VaNOu { get; set; }

    public string? VaIOd { get; set; }

    public string? VaIOs { get; set; }

    public string? VaIOu { get; set; }

    public string? Expires { get; set; }

    public string? Remarks { get; set; }

    public string? InsertGuid { get; set; }

    public bool Printed { get; set; }

    public bool SentToOptical { get; set; }

    public string? EnteredBy { get; set; }
}
