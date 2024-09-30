using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsE;

public partial class Error
{
    public string? Programid { get; set; }

    public int? Errorlevel { get; set; }

    public DateTime? ErrorDate { get; set; }

    public string? ErrorMessage { get; set; }

    public string? ErrorStackTrace { get; set; }

    public string? UserLoggedIn { get; set; }

    public string? Location { get; set; }

    public string? CustomerNumber { get; set; }
}
