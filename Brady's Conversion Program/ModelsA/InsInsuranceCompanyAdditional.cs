using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class InsInsuranceCompanyAdditional
{
    public int InsInsuranceCompanyAdditionalId { get; set; }

    public int? InsCompanyId { get; set; }

    public int? InsAddlInsCompanyId { get; set; }

    public long? AddedBy { get; set; }

    public DateTime? AddedDate { get; set; }

    public long? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }
}
