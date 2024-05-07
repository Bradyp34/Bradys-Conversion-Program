using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class ImgPatientInsuranceCard
{
    public long InsuranceCardId { get; set; }

    public long? PatientInsuranceId { get; set; }

    public long? PatientId { get; set; }

    public string? InsuranceCardRoot { get; set; }

    public string? InsuranceCarLocation { get; set; }

    public DateTime? AddedDate { get; set; }

    public long? AddedBy { get; set; }

    public bool? IsActive { get; set; }
}
