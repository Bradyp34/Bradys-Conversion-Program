using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class Ecp1GetProductPickupOrdersView
{
    public long OrderId { get; set; }

    public string StaffLocation { get; set; } = null!;

    public long PatientId { get; set; }

    public long ProviderId { get; set; }

    public long? StaffLocationId { get; set; }

    public DateTime OrderDate { get; set; }

    public string? OrderStatus { get; set; }

    public DateTime? StatusChangedDateTime { get; set; }

    public DateTime? ReceivedDateTime { get; set; }

    public DateTime? NotifiedDateTime { get; set; }

    public DateTime? PickedUpDateTime { get; set; }

    public DateTime? CancelledDateTime { get; set; }

    public string ProductType { get; set; } = null!;

    public string Manufacturer { get; set; } = null!;

    public string ProductBrand { get; set; } = null!;

    public DateTime? LastModifiedDateTime { get; set; }

    public bool? OrderActive { get; set; }

    public bool? PatientNotifiedByEcp { get; set; }
}
