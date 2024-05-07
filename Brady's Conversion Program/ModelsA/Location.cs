using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class Location
{
    public long LocationId { get; set; }

    public string LocationName { get; set; } = null!;

    public long CompanyId { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zip { get; set; }

    public string? Phone { get; set; }

    public string? Fax { get; set; }

    public string? LabelPath { get; set; }

    public string? LabelPrinter { get; set; }

    public int StatusId { get; set; }

    public bool? ViewFramesDb { get; set; }

    public bool? InventoryOnly { get; set; }

    public bool? ExternalEmr { get; set; }

    public string? FsgaccountingCode { get; set; }

    public string? MendsVolume { get; set; }

    public string? MendsLocationCode { get; set; }

    public string? LabOrderFilePath { get; set; }

    public string? LabOrderXsdPath { get; set; }

    public string? LabOrderExecutablePath { get; set; }

    public string? OrderTemplate { get; set; }

    public string? OrderLogo { get; set; }

    public bool? AcceleratedPayments { get; set; }

    public bool? IncludeCompanyName { get; set; }

    public bool? IsGiftCardsActive { get; set; }

    public bool? IsFramesDbdefaultSearch { get; set; }

    public bool UseCcalias { get; set; }

    public bool TaxActive { get; set; }

    public string? Website { get; set; }

    public string? TaxId { get; set; }

    public bool? DisplayContactOnReceipt { get; set; }

    public string? XgiftStoreId { get; set; }

    public string? XgiftRegId { get; set; }

    public bool SchedulingActive { get; set; }

    public bool SchedulingEmailActive { get; set; }

    public bool? Is4PatientCareRecallsActive { get; set; }

    public bool ShowWaitingRxorders { get; set; }

    public bool ShowBalanceDueOrders { get; set; }

    public bool? SignatureTablet { get; set; }

    public bool? SignatureTopaz { get; set; }

    public bool? SignatureIsc250 { get; set; }

    public int AppointmentFetchDays { get; set; }

    public string Odmodifier { get; set; } = null!;

    public string Osmodifier { get; set; } = null!;

    public bool ContactLensActive { get; set; }

    public bool Clxactive { get; set; }

    public string? Clxemployee { get; set; }

    public string? Clxoffice { get; set; }

    public string? ClxclientId { get; set; }

    public bool Is4PatientCareProductPickUpActive { get; set; }

    public bool ProductPickUpActive { get; set; }

    public bool Is4pcWebSchedulingActive { get; set; }

    public bool Is4pcCreateAppointmentsAutomaticallyActive { get; set; }

    public bool Is4pcAppointmentsRemindersAndCancellationsActive { get; set; }

    public bool Is4pcRecallRemindersActive { get; set; }

    public bool Is4pcProductPickUpActive { get; set; }

    public bool IsEyeCareProWebSchedulingActive { get; set; }

    public bool IsEyeCareProCreateAppointmentsAutomaticallyActive { get; set; }

    public bool IsEyeCareProAppointmentsRemindersAndCancellationsActive { get; set; }

    public bool IsEyeCareProRecallRemindersActive { get; set; }

    public bool IsEyeCareProProductPickUpActive { get; set; }

    public bool SchedulingDisplayAppointmentSummaryAndInsuranceInformationActive { get; set; }

    public bool OrderOdAndOsRxToProcedureXref { get; set; }

    public bool OrderPackages { get; set; }

    public bool PrismChargeSettings { get; set; }

    public bool IncludeZeroDollarChargesOnOrderReceipt { get; set; }

    public bool ChargesEligibleForStatementAfterProductNotified { get; set; }
}
