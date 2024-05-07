using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnFrameInventoryView
{
    public long InventoryId { get; set; }

    public long FrameId { get; set; }

    public long LocationId { get; set; }

    public string? InvoiceNumber { get; set; }

    public int? QuantityOrdered { get; set; }

    public decimal? Cost { get; set; }

    public decimal? WholeSale { get; set; }

    public decimal? Retail { get; set; }

    public int? Received { get; set; }

    public int? OnHand { get; set; }

    public int? Dispensed { get; set; }

    public int? ReturnedToVendor { get; set; }

    public int? Scrapped { get; set; }

    public int? ReturnedByCustomer { get; set; }

    public int? Lost { get; set; }

    public int? Donation { get; set; }

    public bool? Consignment { get; set; }

    public int? TransferredIn { get; set; }

    public int? TransferredOut { get; set; }

    public string? Note { get; set; }

    public DateTime? InvoiceDate { get; set; }

    public string? Barcode { get; set; }

    public bool? ValidInventory { get; set; }

    public DateTime? DateAdded { get; set; }
}
