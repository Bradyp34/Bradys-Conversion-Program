using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LocationToLab
{
    public long LocationLabId { get; set; }

    public long LocationId { get; set; }

    public long LabId { get; set; }

    public string? Account { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? WebId { get; set; }

    public bool? DefaultLab { get; set; }

    public bool? Active { get; set; }

    public bool? IsVisionWebLab { get; set; }

    public bool? IsDvilab { get; set; }

    public bool InHouseLab { get; set; }

    public bool HasEquipmentInterface { get; set; }

    public bool IsLmslab { get; set; }

    public bool AddChargesToNewOrder { get; set; }

    public int Charge1Cptid { get; set; }

    public int Charge2Cptid { get; set; }

    public int Charge3Cptid { get; set; }

    public int Charge4Cptid { get; set; }

    public int Charge5Cptid { get; set; }

    public int Charge6Cptid { get; set; }

    public int Charge7Cptid { get; set; }

    public int Charge8Cptid { get; set; }
}
