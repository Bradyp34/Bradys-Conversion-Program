using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnPatientOrdersView
{
    public long OrderId { get; set; }

    public long PatientId { get; set; }

    public int OrderStatusId { get; set; }

    public long OrderLabId { get; set; }

    public int OrderPackageId { get; set; }

    public long OrderProviderId { get; set; }

    public int OrderStaffId { get; set; }

    public decimal? SphereOd { get; set; }

    public decimal? CylinderOd { get; set; }

    public int? AxisOd { get; set; }

    public decimal? DistanceOd { get; set; }

    public decimal? NearOd { get; set; }

    public string FormOd { get; set; } = null!;

    public string IoOd { get; set; } = null!;

    public decimal? IoPrismOd { get; set; }

    public string UdOd { get; set; } = null!;

    public decimal? UdPrismOd { get; set; }

    public int? BsizeOd { get; set; }

    public decimal? BaseOd { get; set; }

    public decimal? SphereOs { get; set; }

    public decimal? CylinderOs { get; set; }

    public int? AxisOs { get; set; }

    public decimal? DistanceOs { get; set; }

    public decimal? NearOs { get; set; }

    public string FormOs { get; set; } = null!;

    public string IoOs { get; set; } = null!;

    public decimal? IoPrismOs { get; set; }

    public string UdOs { get; set; } = null!;

    public decimal? UdPrismOs { get; set; }

    public int? BsizeOs { get; set; }

    public decimal? BaseOs { get; set; }

    public long? OdLensMaterialId { get; set; }

    public int? OdLensStyleId { get; set; }

    public long? OdLensColorId { get; set; }

    public int? OdLensAdd { get; set; }

    public decimal? OdLensSegHt { get; set; }

    public decimal? OdLensThickness { get; set; }

    public string? OdLensEc { get; set; }

    public decimal? OdLensOcHt { get; set; }

    public string? OdLensMode { get; set; }

    public int? OdLensAdd2 { get; set; }

    public string? OdLensEnc { get; set; }

    public long? OsLensMaterialId { get; set; }

    public int? OsLensStyleId { get; set; }

    public long? OsLensColorId { get; set; }

    public int? OsLensAdd { get; set; }

    public decimal? OsLensSegHt { get; set; }

    public decimal? OsLensThickness { get; set; }

    public string? OsLensEc { get; set; }

    public decimal? OsLensOcHt { get; set; }

    public string? OsLensMode { get; set; }

    public int? OsLensAdd2 { get; set; }

    public string? OsLensEnc { get; set; }

    public long? OdLensArCoatId { get; set; }

    public long? OdLensUvCoatId { get; set; }

    public long? OdLensScrCoatId { get; set; }

    public long? OsLensArCoatId { get; set; }

    public long? OsLensUvCoatId { get; set; }

    public long? OsLensScrCoatId { get; set; }

    public int? OdLensTintId { get; set; }

    public int? OsLensTintId { get; set; }

    public int? OdLensService1Id { get; set; }

    public int? OsLensService1Id { get; set; }

    public int? OdLensService2Id { get; set; }

    public int? OsLensService2Id { get; set; }

    public int? OdLensService3Id { get; set; }

    public int? OsLensService3Id { get; set; }

    public string? OrderFrameName { get; set; }

    public long? OrderFrameInventoryId { get; set; }

    public long? OrderFrameId { get; set; }

    public int? OrderFrameMaterialId { get; set; }

    public long? OrderFrameManufacturerId { get; set; }

    public int? OrderFrameStatusId { get; set; }

    public int? OrderFrameCptId { get; set; }

    public int? OrderFrameEtypeId { get; set; }

    public int? OrderFrameFtypeId { get; set; }

    public string? OrderFrameColor { get; set; }

    public int? OrderFrameEye { get; set; }

    public int? OrderFrameBridge { get; set; }

    public decimal? OrderFrameA { get; set; }

    public decimal? OrderFrameB { get; set; }

    public decimal? OrderFrameEd { get; set; }

    public decimal? OrderFrameDbl { get; set; }

    public decimal? OrderFrameCsize { get; set; }

    public int? OrderFrameTempleSize { get; set; }

    public int? OrderFrameTempleStyleId { get; set; }

    public decimal? OrderFrameRetailPrice { get; set; }

    public string? OrderVwJobType { get; set; }

    public int? OrderVwLensTypeId { get; set; }

    public int? OrderVwLensDesignId { get; set; }

    public int? OrderVwLensMaterialId { get; set; }

    public long? OrderVwFrameBrandId { get; set; }

    public long? OrderVwFrameModelId { get; set; }

    public long? OrderVwFrameTypeId { get; set; }

    public int? OdContactLensBrandId { get; set; }

    public string? OdContactLensPower { get; set; }

    public string? OdContactLensBaseCurve { get; set; }

    public string? OdContactLensDiameter { get; set; }

    public string? OdContactLensCylinder { get; set; }

    public string? OdContactLensAxis { get; set; }

    public string? OdContactLensAddPower { get; set; }

    public string? OdContactLensColor { get; set; }

    public string? OdContactLensPupil { get; set; }

    public string? OdContactLensVaDist { get; set; }

    public string? OdContactLensVaNear { get; set; }

    public int? OsContactLensBrandId { get; set; }

    public string? OsContactLensPower { get; set; }

    public string? OsContactLensBaseCurve { get; set; }

    public string? OsContactLensDiameter { get; set; }

    public string? OsContactLensCylinder { get; set; }

    public string? OsContactLensAxis { get; set; }

    public string? OsContactLensAddPower { get; set; }

    public string? OsContactLensColor { get; set; }

    public string? OsContactLensPupil { get; set; }

    public string? OsContactLensVaDist { get; set; }

    public string? OsContactLensVaNear { get; set; }

    public string OrderVwSentYn { get; set; } = null!;

    public DateTime? OrderVwSentDateTime { get; set; }

    public DateTime OrderEnteredDate { get; set; }

    public DateTime? OrderLastUpdatedDate { get; set; }

    public bool OrderSentToPmYn { get; set; }

    public bool? OrderStatus { get; set; }

    public string? OrderBatchName { get; set; }

    public long? OrderLocationId { get; set; }
}
