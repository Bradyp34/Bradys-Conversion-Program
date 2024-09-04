using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsD;

public partial class Phone
{
    public int Id { get; set; }

    public int PrimaryFileId { get; set; }

    public string? PrimaryFile { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Extension { get; set; }

    public string? Type { get; set; }

    public string? Note { get; set; }

    public string? Active { get; set; }
}
