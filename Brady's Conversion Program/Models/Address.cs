using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.Models;

public partial class Address
{
    public int Id { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zip { get; set; }

    public string? Zip4 { get; set; }

    public string? PrimaryId { get; set; }

    public string? PrimaryFile { get; set; }

    public string? TypeOfAddress { get; set; }

    public string? Note { get; set; }
}
