using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsD;

public partial class FrameInventory
{
    public long Id { get; set; }

    public string? OldInventoryId { get; set; }

    public string? OldFrameId { get; set; }

    public string? OldLocationId { get; set; }

    public string? InvoiceNumber { get; set; }

    public string? QuantityOrdered { get; set; }

    public string? Cost { get; set; }

    public string? WholeSale { get; set; }

    public string? Retail { get; set; }

    public string? Received { get; set; }

    public string? OnHand { get; set; }

    public string? Dispensed { get; set; }

    public string? ReturnedToVendor { get; set; }

    public string? Scrapped { get; set; }

    public string? ReturnedByCustomer { get; set; }

    public string? Lost { get; set; }

    public string? Donation { get; set; }

    public string? Consignment { get; set; }

    public string? TransferredIn { get; set; }

    public string? TransferredOut { get; set; }

    public string? Note { get; set; }

    public string? InvoiceDate { get; set; }

    public string? Barcode { get; set; }

    public string? ValidInventory { get; set; }

    public string? DateAdded { get; set; }

    public string? Active { get; set; }
}
