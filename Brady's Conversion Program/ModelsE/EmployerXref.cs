using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsE;

public partial class EmployerXref
{
    public int EmpId { get; set; }

    public string? EmployerId { get; set; }

    public string? NavCode { get; set; }

    public string? EmployerName { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? ZipCode { get; set; }

    public string? PhoneNumber { get; set; }
}
