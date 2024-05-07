using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrletterTemplate
{
    public int LetterId { get; set; }

    public string? LetterDescription { get; set; }

    public byte[]? LetterRtf { get; set; }

    /// <summary>
    ///  0=Other, 1=Consent Forms, 2=Referral Forms, 3= Surgery Forms, 4=Patient Letters
    /// </summary>
    public int? LetterType { get; set; }

    public byte[]? UpsizeTs { get; set; }

    public string? InsertGuid { get; set; }
}
