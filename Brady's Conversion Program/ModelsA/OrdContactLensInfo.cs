using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class OrdContactLensInfo
{
    public long OrderContactLensInfoId { get; set; }

    public long? OrderId { get; set; }

    public string? BaseCurveOd { get; set; }

    public string? BaseCurveOs { get; set; }

    public string? DiameterOd { get; set; }

    public string? DiameterOs { get; set; }

    public string? SphereOd { get; set; }

    public string? SphereOs { get; set; }

    public string? CylinderOd { get; set; }

    public string? CylinderOs { get; set; }

    public string? AxisOd { get; set; }

    public string? AxisOs { get; set; }

    public string? AddPowerOd { get; set; }

    public string? AddPowerOs { get; set; }

    public string? AddPowerNameOd { get; set; }

    public string? AddPowerNameOs { get; set; }

    public string? PupilDiameterOd { get; set; }

    public string? PupilDiameterOs { get; set; }

    public string? MultiFocalOd { get; set; }

    public string? MultiFocalOs { get; set; }

    public string? ColorOd { get; set; }

    public string? ColorOs { get; set; }

    public string? VaDistanceOd { get; set; }

    public string? VaDistanceOs { get; set; }

    public string? VaNearOd { get; set; }

    public string? VaNearOs { get; set; }

    public int? QuantityOd { get; set; }

    public int? QuantityOs { get; set; }

    public bool? IsSoftContacts { get; set; }

    public long? ClxOrderId { get; set; }

    public long? ContactLensInventoryId { get; set; }

    public bool? DispensedFromInventory { get; set; }

    public string? Notes { get; set; }

    public DateTime? AddedDate { get; set; }

    public long? AddedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public long? UpdatedBy { get; set; }

    public bool? IsActive { get; set; }
}
