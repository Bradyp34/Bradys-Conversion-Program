using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class VwOrderInfo
{
    public long VworderInfoId { get; set; }

    public long OrderId { get; set; }

    public int JobTypeId { get; set; }

    public int LensTypeId { get; set; }

    public int? LensDesignId { get; set; }

    public int? LensMaterialId { get; set; }

    public string? TreatmentComments { get; set; }

    public long LocationId { get; set; }

    public long? FrameBrandId { get; set; }

    public long? FrameModelId { get; set; }

    public long? FrameTypeId { get; set; }

    public string? Odrxadd { get; set; }

    public string? Osrxadd { get; set; }

    public string? OdrxsegHt { get; set; }

    public string? OsrxsegHt { get; set; }

    public bool? IsOrderSent { get; set; }

    public DateTime? OrderSentDateTime { get; set; }

    public string? SpecialInstructions { get; set; }

    public string? FrameModelText { get; set; }

    public bool? IsOdeyeSelected { get; set; }

    public bool? IsOseyeSelected { get; set; }

    public string? Cape { get; set; }

    public string? DominantHand { get; set; }

    public string? DominantEye { get; set; }

    public string? HeCoefficient { get; set; }

    public string? LeftErcd { get; set; }

    public string? LeftVertexDistance { get; set; }

    public string? PantoAngle { get; set; }

    public string? ProgressionLength { get; set; }

    public string? ReadingDistance { get; set; }

    public string? RightErcd { get; set; }

    public string? RightVertexDistance { get; set; }

    public string? StCoefficient { get; set; }

    public string? WrapAngle { get; set; }

    public string? PatientInitials { get; set; }

    public int OrderTypeId { get; set; }

    public string Shape { get; set; } = null!;

    public string Manufacturer { get; set; } = null!;

    public string Size { get; set; } = null!;

    public int TintTypeId { get; set; }

    public int TintId { get; set; }

    public int LmsframeTypeId { get; set; }

    public string Nvb { get; set; } = null!;
}
