using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class ClnsInventory
{
    public long InventoryId { get; set; }

    public long ContactLensId { get; set; }

    public string? Barcode { get; set; }

    public string? InvoiceNumber { get; set; }

    public string? ItemCost { get; set; }

    public string? WholesalePrice { get; set; }

    public string? RetailPrice { get; set; }

    public int? QuantityOrdered { get; set; }

    public int? Received { get; set; }

    public int? OnHand { get; set; }

    public int? Dispensed { get; set; }

    public string? Notes { get; set; }

    public long? AddedBy { get; set; }

    public DateTime? AddedDate { get; set; }

    public DateTime? InvoiceDate { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsTrials { get; set; }

    public bool? IsActive { get; set; }

    public long? LocationId { get; set; }
}
