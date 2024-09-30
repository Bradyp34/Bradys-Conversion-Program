﻿using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsE;

public partial class AppointmentProviderXref
{
    public int ProvId { get; set; }

    public string? ProvCode { get; set; }

    public string? NavCode { get; set; }

    public string? Npi { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? ZipCode { get; set; }

    public string? PhoneNumber { get; set; }
}
