using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsD;

public partial class ClInventory
{
    public int Id { get; set; }

    public int ContactLensId { get; set; }

    public string? Barcode { get; set; }

    public string? InvoiceNumber { get; set; }

    public string? ItemCost { get; set; }

    public string? WholesalePrice { get; set; }

    public string? RetailPrice { get; set; }

    public string? QuantityOrdered { get; set; }

    public string? Received { get; set; }

    public string? OnHand { get; set; }

    public string? Dispensed { get; set; }

    public string? Notes { get; set; }

    public string? AddedBy { get; set; }

    public string? AddedDate { get; set; }

    public string? InvoiceDate { get; set; }

    public string? ExpiryDate { get; set; }

    public string? UpdatedBy { get; set; }

    public string? UpdatedDate { get; set; }

    public string? IsTrials { get; set; }

    public string? IsActive { get; set; }

    public string? LocationId { get; set; }
}
