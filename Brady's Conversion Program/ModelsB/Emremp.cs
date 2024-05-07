using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class Emremp
{
    public int EmpId { get; set; }

    public int? ExtEmpId { get; set; }

    public string? EmpAbbr { get; set; }

    /// <summary>
    /// False = Inactive
    /// </summary>
    public short EmpIsActive { get; set; }

    public string? EmpNameFirst { get; set; }

    public string? EmpNameLast { get; set; }

    public string? EmpNameMiddle { get; set; }

    public string? EmpNameFull { get; set; }

    public string? EmpPassword { get; set; }

    public string? EmpRxPassword { get; set; }

    public int? EmpRoleId { get; set; }

    public string? EmpSecuritySettings { get; set; }

    public byte[]? EmpSignature { get; set; }

    public int? EmpSignatureSize { get; set; }

    public string? EmpSignOnBehalf { get; set; }

    public string? EmpRxLicenseNum { get; set; }

    public string? EmpRxDeanum { get; set; }

    public string? EmpRxNpinum { get; set; }

    public byte[]? UpsizeTs { get; set; }

    public int? EmpIncomingFaxAlert { get; set; }

    public string? Pmhl7empId { get; set; }

    public string? EmpFlowStatusFilter { get; set; }

    public int? EmpDefaultVisitHistory { get; set; }

    public short? EmpActivateErx { get; set; }

    public string? EmpQualityReportingConfig { get; set; }

    public short? EmpQualityReportingAfterMdmc { get; set; }

    public string? EmpQualityReportingMedicareFilter { get; set; }

    public short? EmpNoEm { get; set; }

    public string? PmintUserName { get; set; }

    public string? PmintPassword { get; set; }

    public string? HidproxAtr { get; set; }

    public string? InsertGuid { get; set; }

    public string? AuthorizedChartFilters { get; set; }

    public string? AuthorizedVisitProviders { get; set; }

    public string? VisitListColor { get; set; }

    public short? C3enable { get; set; }

    public string? DirectMessageAddress { get; set; }

    public int? EmpQualityReportingEdition { get; set; }

    public short? TestimonialTreeEnable { get; set; }

    public int? SecurityGroupId { get; set; }

    public string? EmailAddress { get; set; }

    public string? MobilePhone { get; set; }

    public string? GroupNpi { get; set; }

    public bool ForcePasswordChange { get; set; }

    public DateTime LastPasswordChanged { get; set; }

    public int DefaultHistorySubTab { get; set; }

    public string? EmpNameSuffix { get; set; }

    public string? AzureAdUserId { get; set; }

    public string? PatientEngagementAccessKey { get; set; }

    public bool AllowPatientEngagementAccess { get; set; }
}
