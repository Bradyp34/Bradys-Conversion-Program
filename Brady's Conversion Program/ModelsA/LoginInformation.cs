using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LoginInformation
{
    public long LogonId { get; set; }

    public string Username { get; set; } = null!;

    public string LoginPassword { get; set; } = null!;

    public int UnsuccessfulAttempts { get; set; }

    public bool PasswordRequired { get; set; }
}
