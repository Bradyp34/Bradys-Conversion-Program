using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class RptUnpaidClaimsReport
{
    public long RptUnpaidClmsReportId { get; set; }

    public string? RptUnpaidClmsReportName { get; set; }

    public DateTime? RptUnpaidClmsReportCreatedDate { get; set; }

    public string? RptUnpaidClmsReportUser { get; set; }

    public DateTime? RptUnpaidClmsReportLastUpdDate { get; set; }

    public string? RptUnpaidClaimsReportRemarks { get; set; }

    public string? RptUnpaidClaimsReportParamsProv { get; set; }

    public string? RptUnpaidClaimsReportParamsLoc { get; set; }

    public string? RrptUnpaidClaimsReportParamsIns { get; set; }

    public string? RptUnpaidClaimsReportParamsInsGrps { get; set; }

    public string? RptUnpaidClaimsReportParamsDepts { get; set; }

    public string? RptUnpaidClaimsReportParamsBillGrps { get; set; }

    public string? RptUnpaidClaimsReportParamsSortOps { get; set; }

    public string? RptUnpaidClaimsReportParamsSrvDateRange { get; set; }

    public DateTime? RptUnpaidClaimsReportParamsSrvStart { get; set; }

    public DateTime? RptUnpaidClaimsReportParamsSrvEnd { get; set; }

    public string? RptUnpaidClaimsReportParamsBillDateRange { get; set; }

    public DateTime? RptUnpaidClaimsReportParamsBillStart { get; set; }

    public DateTime? RptUnpaidClaimsReportParamsBillEnd { get; set; }

    public string? RptUnpaidClaimsReportParamsAccAssn { get; set; }

    public string? RptUnpaidClaimsReportParamsBalFrom { get; set; }

    public string? RptUnpaidClaimsReportParamsBalTo { get; set; }

    public bool? RptUnpaidClaimsReportParamsZeroBal { get; set; }

    public bool? RptUnpaidClaimsReportIsComplete { get; set; }

    public bool? RptUnpaidClaimsReportIsLocked { get; set; }

    public bool? RptUnpaidClaimsReportIsActive { get; set; }
}
