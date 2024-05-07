using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class NavFoxOpticalInterface
{
    public string CustomerNumber { get; set; } = null!;

    public string? CustomerName { get; set; }

    public string FoxOpticalFolder { get; set; } = null!;

    public string NavDownloadFolder { get; set; } = null!;

    public string? NavUploadFolder { get; set; }

    public string NavFtpserver { get; set; } = null!;

    public string NavFtpuser { get; set; } = null!;

    public string NavFtppassword { get; set; } = null!;

    public long? LocationId { get; set; }

    public bool Active { get; set; }
}
