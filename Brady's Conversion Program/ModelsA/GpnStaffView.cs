using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnStaffView
{
    public long StaffId { get; set; }

    public string StaffCode { get; set; } = null!;

    public string? FullName { get; set; }

    public string? FirstName { get; set; }

    public string MiddleInitial { get; set; } = null!;

    public string? LastName { get; set; }

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Zip { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int IsOnCommision { get; set; }

    public int SalesPercentage { get; set; }

    public int CommisionType { get; set; }

    public int Inactive { get; set; }

    public int IsDoctor { get; set; }

    public int IsInside { get; set; }
}
