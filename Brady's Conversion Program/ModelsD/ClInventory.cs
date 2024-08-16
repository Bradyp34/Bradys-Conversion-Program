using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsD;

[Table("CLInventory")]
public partial class Clinventory
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("ContactLensID")]
    public int ContactLensId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Barcode { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? InvoiceNumber { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ItemCost { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? WholesalePrice { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? RetailPrice { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? QuantityOrdered { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Received { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? OnHand { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Dispensed { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Notes { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? AddedBy { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? AddedDate { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? InvoiceDate { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? ExpiryDate { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? UpdatedDate { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? IsTrials { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? IsActive { get; set; }

    [Column("LocationID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? LocationId { get; set; }
}
