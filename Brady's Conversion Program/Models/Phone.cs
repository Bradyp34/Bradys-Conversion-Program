using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.Models;

public partial class Phone
{
    public int Id { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Extension { get; set; }

    public string? PrimaryId { get; set; }

    public string? PrimaryFile { get; set; }

    public string? TypeOfPhone { get; set; }

    public string? Note { get; set; }
}
