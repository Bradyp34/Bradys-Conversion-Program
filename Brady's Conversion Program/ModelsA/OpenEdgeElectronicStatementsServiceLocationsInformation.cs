using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class OpenEdgeElectronicStatementsServiceLocationsInformation
{
    public int Id { get; set; }

    public int GroupId { get; set; }

    public string RequestData { get; set; } = null!;

    public string ResponseData { get; set; } = null!;

    public DateTime CreatedDateTime { get; set; }

    public int StaffId { get; set; }

    public string Type { get; set; } = null!;
}
