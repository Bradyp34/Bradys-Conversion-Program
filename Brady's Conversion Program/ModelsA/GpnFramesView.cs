using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnFramesView
{
    public long FrameId { get; set; }

    public string? FrameFpc { get; set; }

    public string FrameUpc { get; set; } = null!;

    public int FrameStyleId { get; set; }

    public string? FrameStyleName { get; set; }

    public int? Eye { get; set; }

    public int? Bridge { get; set; }

    public int? Temple { get; set; }

    public decimal? Dbl { get; set; }

    public decimal? A { get; set; }

    public decimal? B { get; set; }

    public decimal? Ed { get; set; }

    public decimal? Circumference { get; set; }

    public decimal? Edangle { get; set; }

    public decimal? FrontPrice { get; set; }

    public decimal? HalfTemplesPrice { get; set; }

    public decimal? TemplesPrice { get; set; }

    public decimal? CompletePrice { get; set; }

    public bool? StyleNew { get; set; }

    public bool? ChangedPrice { get; set; }

    public string? Sku { get; set; }

    public string? YearIntroduced { get; set; }

    public long? ManufacturerId { get; set; }

    public long? VendorId { get; set; }

    public long? BrandId { get; set; }

    public long? CollectionId { get; set; }

    public int? FrameCategoryId { get; set; }

    public int? FrameShapeId { get; set; }

    public int? FrameMaterialId { get; set; }

    public int? FrameMountId { get; set; }

    public long? FrameColorId { get; set; }

    public long? LocationId { get; set; }

    public int? CptId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? DateAdded { get; set; }

    public DateTime? LastUpdated { get; set; }
}
