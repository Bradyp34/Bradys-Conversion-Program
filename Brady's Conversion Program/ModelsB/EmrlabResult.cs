using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrlabResult
{
    public int LabResultId { get; set; }

    public short? IsObservationRequest { get; set; }

    public int? ParentLabResultId { get; set; }

    public int? PtId { get; set; }

    public int? OrderedEmpId { get; set; }

    public int? VisitOrderId { get; set; }

    public string? PlacerOrderId { get; set; }

    public string? FillerOrderId { get; set; }

    public string? ServiceId { get; set; }

    public DateTime? ItemDate { get; set; }

    public string? ItemName { get; set; }

    public string? ResultValue { get; set; }

    public string? ResultUnits { get; set; }

    public string? ResultRange { get; set; }

    public string? ResultFlag { get; set; }

    public string? ResultNumber { get; set; }

    public string? ResultStatus { get; set; }

    public string? ImportedOrderedDocName { get; set; }

    public string? ItemNotes { get; set; }

    public short? Mdreviewed { get; set; }

    public DateTime? MdreviewedDate { get; set; }

    public int? MdreviewedEmpId { get; set; }

    public DateTime? TestEntered { get; set; }

    public string? ServiceIdtype { get; set; }

    public string? RelevantInfo { get; set; }

    public string? FillerInfo { get; set; }

    public string? SpecimenSource { get; set; }

    public string? SpecimenSourceCode { get; set; }

    public string? InsertGuid { get; set; }

    public string? ImportOrderedDocId { get; set; }

    public string? ImportOrderedDocNamespace { get; set; }

    public string? ImportOrderedDocNameTypeCode { get; set; }

    public string? ImportOrderedDocIdtypeCode { get; set; }

    public DateTime? SpecimenCollectionStart { get; set; }

    public string? SpecimenCollectionStartTimeZone { get; set; }

    public string? SpecimenCondition { get; set; }

    public string? SpecimenActionCode { get; set; }

    public string? SpecimenRejectReason { get; set; }

    public string? Hl7ptId { get; set; }

    public string? Hl7ptIdnameSpace { get; set; }

    public string? Hl7ptIdtypeCode { get; set; }

    public string? Hl7ptName { get; set; }

    public string? Hl7ptDob { get; set; }

    public string? Hl7ptGender { get; set; }

    public string? Hl7ptRace { get; set; }

    public string? Hl7ptRaceAlt { get; set; }

    public string? ItemDateTimeZone { get; set; }

    public string? PerfOrgName { get; set; }

    public string? PerfOrgAddr { get; set; }

    public string? PerfOrgCity { get; set; }

    public string? PerfOrgState { get; set; }

    public string? PerfOrgZip { get; set; }

    public string? PerfOrgCountry { get; set; }

    public string? PerfOrgCountyCode { get; set; }

    public string? PerfOrgIdentifier { get; set; }

    public string? PerfOrgIdentifierNameSpace { get; set; }

    public string? PerfOrgIdentifierTypeCode { get; set; }

    public string? PerfOrgMedDirName { get; set; }

    public string? PerfOrgMedDirId { get; set; }

    public string? PlacerOrderNamespace { get; set; }

    public string? FillerOrderNamespace { get; set; }

    public string? PlacerGroupNumber { get; set; }

    public string? PlacerGroupNamespace { get; set; }

    public string? ResultsReportStatusChangeDateTime { get; set; }

    public string? ResultsReportStatusChangeTimeZone { get; set; }

    public string? SubId { get; set; }

    public string? ParentServiceId { get; set; }

    public string? ParentFillerOrderId { get; set; }

    public string? ParentFillerOrderNamespace { get; set; }

    public string? ParentSubId { get; set; }

    public string? InterpretationNarrative { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? LastModified { get; set; }

    public int? CreatedEmpId { get; set; }

    public int? LastModifiedEmpId { get; set; }
}
