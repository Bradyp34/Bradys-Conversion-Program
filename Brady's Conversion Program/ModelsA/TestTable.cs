using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class TestTable
{
    public long OrderId { get; set; }

    public string? OrderDate { get; set; }

    public string? OrderStatus { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? AccountNo { get; set; }

    public string? ServiceDate { get; set; }

    public bool Billed { get; set; }

    public decimal? Charges { get; set; }

    public decimal? Payments { get; set; }

    public decimal? Adjustments { get; set; }

    public decimal? Balance { get; set; }
}
