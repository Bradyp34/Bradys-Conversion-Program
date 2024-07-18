using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class FfpmContext : DbContext
{
    private readonly string _connectionString;

    public FfpmContext(string connectionString) {
        _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public FfpmContext(DbContextOptions<FfpmContext> options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        : base(options)
    {
    }

    public virtual DbSet<AccountNumberTemp11aug2023124818510> AccountNumberTemp11aug2023124818510s { get; set; }

    public virtual DbSet<AccountXref> AccountXrefs { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<AgeGroup> AgeGroups { get; set; }

    public virtual DbSet<BatchNumber> BatchNumbers { get; set; }

    public virtual DbSet<BillingLocation> BillingLocations { get; set; }

    public virtual DbSet<BillingLocation1> BillingLocations1 { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<CallpopPatientProfile> CallpopPatientProfiles { get; set; }

    public virtual DbSet<CcbChargesInformation> CcbChargesInformations { get; set; }

    public virtual DbSet<CcbChargesReportsInformation> CcbChargesReportsInformations { get; set; }

    public virtual DbSet<CcbTemp> CcbTemps { get; set; }

    public virtual DbSet<ChargeInsuranceTransfer> ChargeInsuranceTransfers { get; set; }

    public virtual DbSet<ChargeNote> ChargeNotes { get; set; }

    public virtual DbSet<ChargePaymentsAdditionalInformation> ChargePaymentsAdditionalInformations { get; set; }

    public virtual DbSet<ChargeTransaction> ChargeTransactions { get; set; }

    public virtual DbSet<ChargeTransactionCategory> ChargeTransactionCategories { get; set; }

    public virtual DbSet<ChargeTransactionCode> ChargeTransactionCodes { get; set; }

    public virtual DbSet<ChargeTransactionToGiftCardTransactionMapping> ChargeTransactionToGiftCardTransactionMappings { get; set; }

    public virtual DbSet<ChargeTransactionType> ChargeTransactionTypes { get; set; }

    public virtual DbSet<ClnsBrand> ClnsBrands { get; set; }

    public virtual DbSet<ClnsBrandCptXref> ClnsBrandCptXrefs { get; set; }

    public virtual DbSet<ClnsContactLen> ClnsContactLens { get; set; }

    public virtual DbSet<ClnsInventory> ClnsInventories { get; set; }

    public virtual DbSet<ClnsLensType> ClnsLensTypes { get; set; }

    public virtual DbSet<ClnsManufacturer> ClnsManufacturers { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<ContactInfo> ContactInfos { get; set; }

    public virtual DbSet<ContactLense> ContactLenses { get; set; }

    public virtual DbSet<ConvFfpmAccount> ConvFfpmAccounts { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<CptDepartment> CptDepartments { get; set; }

    public virtual DbSet<CptFfo> CptFfos { get; set; }

    public virtual DbSet<CptGroupMapping> CptGroupMappings { get; set; }

    public virtual DbSet<CptStaging> CptStagings { get; set; }

    public virtual DbSet<CptTypeOfService> CptTypeOfServices { get; set; }

    public virtual DbSet<Cptid> Cptids { get; set; }

    public virtual DbSet<CpttempTable> CpttempTables { get; set; }

    public virtual DbSet<CurrentMonth20210118162803> CurrentMonth20210118162803s { get; set; }

    public virtual DbSet<CurrentYear20210118162803> CurrentYear20210118162803s { get; set; }

    public virtual DbSet<DashUserPermission> DashUserPermissions { get; set; }

    public virtual DbSet<DiagnosisCode> DiagnosisCodes { get; set; }

    public virtual DbSet<DiagnosisCodesNew> DiagnosisCodesNews { get; set; }

    public virtual DbSet<DiagnosisGroupMapping> DiagnosisGroupMappings { get; set; }

    public virtual DbSet<DiagnosisStaging> DiagnosisStagings { get; set; }

    public virtual DbSet<DmeOrdersTempTable02apr2024162959457> DmeOrdersTempTable02apr2024162959457s { get; set; }

    public virtual DbSet<DmeOrdersTempTable02apr2024163026943> DmeOrdersTempTable02apr2024163026943s { get; set; }

    public virtual DbSet<DmeOrdersTempTable02apr2024163232143> DmeOrdersTempTable02apr2024163232143s { get; set; }

    public virtual DbSet<DmeOrdersTempTable02apr2024164139327> DmeOrdersTempTable02apr2024164139327s { get; set; }

    public virtual DbSet<DmeOrdersTempTable02apr2024164217510> DmeOrdersTempTable02apr2024164217510s { get; set; }

    public virtual DbSet<DmgGroup> DmgGroups { get; set; }

    public virtual DbSet<DmgGuarantor> DmgGuarantors { get; set; }

    public virtual DbSet<DmgHl7Event> DmgHl7Events { get; set; }

    public virtual DbSet<DmgOtherAddress> DmgOtherAddresses { get; set; }

    public virtual DbSet<DmgPatient> DmgPatients { get; set; }

    public virtual DbSet<DmgPatientAdditionalDetail> DmgPatientAdditionalDetails { get; set; }

    public virtual DbSet<DmgPatientAddress> DmgPatientAddresses { get; set; }

    public virtual DbSet<DmgPatientAlert> DmgPatientAlerts { get; set; }

    public virtual DbSet<DmgPatientConsentDetail> DmgPatientConsentDetails { get; set; }

    public virtual DbSet<DmgPatientFormsImagesDetail> DmgPatientFormsImagesDetails { get; set; }

    public virtual DbSet<DmgPatientHippaReleaseContactDetail> DmgPatientHippaReleaseContactDetails { get; set; }

    public virtual DbSet<DmgPatientInsurance> DmgPatientInsurances { get; set; }

    public virtual DbSet<DmgPatientMedicalHistoryDetail> DmgPatientMedicalHistoryDetails { get; set; }

    public virtual DbSet<DmgPatientRelatedPatient> DmgPatientRelatedPatients { get; set; }

    public virtual DbSet<DmgPatientRemark> DmgPatientRemarks { get; set; }

    public virtual DbSet<DmgPatientRosDetail> DmgPatientRosDetails { get; set; }

    public virtual DbSet<DmgPatientStatementInformation> DmgPatientStatementInformations { get; set; }

    public virtual DbSet<DmgProvider> DmgProviders { get; set; }

    public virtual DbSet<DmgProvider2> DmgProvider2s { get; set; }

    public virtual DbSet<DmgProviderExtra> DmgProviderExtras { get; set; }

    public virtual DbSet<DmgSubscriber> DmgSubscribers { get; set; }

    public virtual DbSet<DmgTransactionHistory> DmgTransactionHistories { get; set; }

    public virtual DbSet<Dupframe> Dupframes { get; set; }

    public virtual DbSet<Ecp1GetAppointmentAndRecallTypesView> Ecp1GetAppointmentAndRecallTypesViews { get; set; }

    public virtual DbSet<Ecp1GetAppointmentsByRulesView> Ecp1GetAppointmentsByRulesViews { get; set; }

    public virtual DbSet<Ecp1GetAppointmentsView> Ecp1GetAppointmentsViews { get; set; }

    public virtual DbSet<Ecp1GetLocationsView> Ecp1GetLocationsViews { get; set; }

    public virtual DbSet<Ecp1GetOrderStatusView> Ecp1GetOrderStatusViews { get; set; }

    public virtual DbSet<Ecp1GetPatientInsuranceView> Ecp1GetPatientInsuranceViews { get; set; }

    public virtual DbSet<Ecp1GetPatientProvidersView> Ecp1GetPatientProvidersViews { get; set; }

    public virtual DbSet<Ecp1GetPatientsView> Ecp1GetPatientsViews { get; set; }

    public virtual DbSet<Ecp1GetProductPickupOrdersView> Ecp1GetProductPickupOrdersViews { get; set; }

    public virtual DbSet<Ecp1GetProviderAndResourcesView> Ecp1GetProviderAndResourcesViews { get; set; }

    public virtual DbSet<Ecp1GetRecallsView> Ecp1GetRecallsViews { get; set; }

    public virtual DbSet<Ecp1GetSettingsView> Ecp1GetSettingsViews { get; set; }

    public virtual DbSet<Ecp1GetVersionInformationView> Ecp1GetVersionInformationViews { get; set; }

    public virtual DbSet<EdiClaimFile> EdiClaimFiles { get; set; }

    public virtual DbSet<EdiClaimFileTransaction> EdiClaimFileTransactions { get; set; }

    public virtual DbSet<EdiClaimFileTransactionIndClaim> EdiClaimFileTransactionIndClaims { get; set; }

    public virtual DbSet<EdiClaimFileTransactionIndClaimStatus> EdiClaimFileTransactionIndClaimStatuses { get; set; }

    public virtual DbSet<EdiClaimFileTransactionIndClmCharge> EdiClaimFileTransactionIndClmCharges { get; set; }

    public virtual DbSet<EdiClaimHcfaPrintQueue> EdiClaimHcfaPrintQueues { get; set; }

    public virtual DbSet<EdiEligibilityFile> EdiEligibilityFiles { get; set; }

    public virtual DbSet<EdiEligibilityPatEligDetail> EdiEligibilityPatEligDetails { get; set; }

    public virtual DbSet<EdiMntClmEntityCode> EdiMntClmEntityCodes { get; set; }

    public virtual DbSet<EdiMntClmStatus> EdiMntClmStatuses { get; set; }

    public virtual DbSet<EdiMntHcfaPrinter> EdiMntHcfaPrinters { get; set; }

    public virtual DbSet<EdiMntRemitGroupCode> EdiMntRemitGroupCodes { get; set; }

    public virtual DbSet<EdiMntRemitReasonCode> EdiMntRemitReasonCodes { get; set; }

    public virtual DbSet<EdiMntRemitReasonCodeXref> EdiMntRemitReasonCodeXrefs { get; set; }

    public virtual DbSet<EdiMntRemitRemCode> EdiMntRemitRemCodes { get; set; }

    public virtual DbSet<EdiRemitFile> EdiRemitFiles { get; set; }

    public virtual DbSet<EdiRemitFollowUpPayment> EdiRemitFollowUpPayments { get; set; }

    public virtual DbSet<EdiRemitIndClmPayment> EdiRemitIndClmPayments { get; set; }

    public virtual DbSet<EdiRemitIndClmPmtAdjustment> EdiRemitIndClmPmtAdjustments { get; set; }

    public virtual DbSet<EdiRemitIndClmPmtRemark> EdiRemitIndClmPmtRemarks { get; set; }

    public virtual DbSet<EdiRemitIndClmPmtServiceLine> EdiRemitIndClmPmtServiceLines { get; set; }

    public virtual DbSet<EdiRemitIndClmSrvLineAdjustment> EdiRemitIndClmSrvLineAdjustments { get; set; }

    public virtual DbSet<EdiRemitIndClmSrvLineRemark> EdiRemitIndClmSrvLineRemarks { get; set; }

    public virtual DbSet<EdiSetting> EdiSettings { get; set; }

    public virtual DbSet<EdiStatementFile> EdiStatementFiles { get; set; }

    public virtual DbSet<EdiStatementFilePatXref> EdiStatementFilePatXrefs { get; set; }

    public virtual DbSet<Ehrcharge> Ehrcharges { get; set; }

    public virtual DbSet<Ehrorder> Ehrorders { get; set; }

    public virtual DbSet<EmrtreeViewControlListOld> EmrtreeViewControlListOlds { get; set; }

    public virtual DbSet<EobInformation> EobInformations { get; set; }

    public virtual DbSet<EobToPayment> EobToPayments { get; set; }

    public virtual DbSet<ExternalSystemChargesList> ExternalSystemChargesLists { get; set; }

    public virtual DbSet<EyeCareProInformation> EyeCareProInformations { get; set; }

    public virtual DbSet<FinalizeAndClaimEvent> FinalizeAndClaimEvents { get; set; }

    public virtual DbSet<FinalizeAndClaimEventsTempEoyFix> FinalizeAndClaimEventsTempEoyFixes { get; set; }

    public virtual DbSet<FinalizeAndClaimEventsWholeTableTempEoyFix> FinalizeAndClaimEventsWholeTableTempEoyFixes { get; set; }

    public virtual DbSet<FinalizeClaimAndDepositSlipReportDetail> FinalizeClaimAndDepositSlipReportDetails { get; set; }

    public virtual DbSet<FourPatientCareInformation> FourPatientCareInformations { get; set; }

    public virtual DbSet<FoxOpticalVersionHistory> FoxOpticalVersionHistories { get; set; }

    public virtual DbSet<Frame> Frames { get; set; }

    public virtual DbSet<FrameCategory> FrameCategories { get; set; }

    public virtual DbSet<FrameCollection> FrameCollections { get; set; }

    public virtual DbSet<FrameColor> FrameColors { get; set; }

    public virtual DbSet<FrameDblensColor> FrameDblensColors { get; set; }

    public virtual DbSet<FrameEtype> FrameEtypes { get; set; }

    public virtual DbSet<FrameFtype> FrameFtypes { get; set; }

    public virtual DbSet<FrameMaterial> FrameMaterials { get; set; }

    public virtual DbSet<FrameMount> FrameMounts { get; set; }

    public virtual DbSet<FrameOrderInfo> FrameOrderInfos { get; set; }

    public virtual DbSet<FrameShape> FrameShapes { get; set; }

    public virtual DbSet<FrameStatus> FrameStatuses { get; set; }

    public virtual DbSet<FrameTempleStyle> FrameTempleStyles { get; set; }

    public virtual DbSet<GenderGroup> GenderGroups { get; set; }

    public virtual DbSet<GeneralId> GeneralIds { get; set; }

    public virtual DbSet<GeneralOption> GeneralOptions { get; set; }

    public virtual DbSet<GeneralOptionsTempEoyFix> GeneralOptionsTempEoyFixes { get; set; }

    public virtual DbSet<GetBalanceDueOrdersView> GetBalanceDueOrdersViews { get; set; }

    public virtual DbSet<GetLocationInformationAndCountsView> GetLocationInformationAndCountsViews { get; set; }

    public virtual DbSet<GetOrderchargesDatesCount> GetOrderchargesDatesCounts { get; set; }

    public virtual DbSet<GpnChargeTransactionCodesView> GpnChargeTransactionCodesViews { get; set; }

    public virtual DbSet<GpnChargeTransactionTypesView> GpnChargeTransactionTypesViews { get; set; }

    public virtual DbSet<GpnContactLensBrandsView> GpnContactLensBrandsViews { get; set; }

    public virtual DbSet<GpnContactLensManufacturersView> GpnContactLensManufacturersViews { get; set; }

    public virtual DbSet<GpnCptDepartmentsView> GpnCptDepartmentsViews { get; set; }

    public virtual DbSet<GpnCptTypeOfSerivcesView> GpnCptTypeOfSerivcesViews { get; set; }

    public virtual DbSet<GpnCptView> GpnCptViews { get; set; }

    public virtual DbSet<GpnFrameBrandView> GpnFrameBrandViews { get; set; }

    public virtual DbSet<GpnFrameCategoryView> GpnFrameCategoryViews { get; set; }

    public virtual DbSet<GpnFrameCollectionView> GpnFrameCollectionViews { get; set; }

    public virtual DbSet<GpnFrameColorsView> GpnFrameColorsViews { get; set; }

    public virtual DbSet<GpnFrameEtypeView> GpnFrameEtypeViews { get; set; }

    public virtual DbSet<GpnFrameFtypeView> GpnFrameFtypeViews { get; set; }

    public virtual DbSet<GpnFrameInventoryView> GpnFrameInventoryViews { get; set; }

    public virtual DbSet<GpnFrameManufacturerView> GpnFrameManufacturerViews { get; set; }

    public virtual DbSet<GpnFrameMaterialView> GpnFrameMaterialViews { get; set; }

    public virtual DbSet<GpnFrameMountsView> GpnFrameMountsViews { get; set; }

    public virtual DbSet<GpnFrameShapesView> GpnFrameShapesViews { get; set; }

    public virtual DbSet<GpnFrameStatusView> GpnFrameStatusViews { get; set; }

    public virtual DbSet<GpnFrameTempleStylesView> GpnFrameTempleStylesViews { get; set; }

    public virtual DbSet<GpnFrameVendorView> GpnFrameVendorViews { get; set; }

    public virtual DbSet<GpnFramesView> GpnFramesViews { get; set; }

    public virtual DbSet<GpnIhFrameTypeView> GpnIhFrameTypeViews { get; set; }

    public virtual DbSet<GpnIhLensDesignView> GpnIhLensDesignViews { get; set; }

    public virtual DbSet<GpnIhLensMaterialView> GpnIhLensMaterialViews { get; set; }

    public virtual DbSet<GpnIhLensTypesView> GpnIhLensTypesViews { get; set; }

    public virtual DbSet<GpnIhTreatmentsView> GpnIhTreatmentsViews { get; set; }

    public virtual DbSet<GpnInformation> GpnInformations { get; set; }

    public virtual DbSet<GpnInsuranceCompaniesView> GpnInsuranceCompaniesViews { get; set; }

    public virtual DbSet<GpnInsurancePlansView> GpnInsurancePlansViews { get; set; }

    public virtual DbSet<GpnLabsView> GpnLabsViews { get; set; }

    public virtual DbSet<GpnLensCoatsView> GpnLensCoatsViews { get; set; }

    public virtual DbSet<GpnLensColorsView> GpnLensColorsViews { get; set; }

    public virtual DbSet<GpnLensMaterialsView> GpnLensMaterialsViews { get; set; }

    public virtual DbSet<GpnLensServiceView> GpnLensServiceViews { get; set; }

    public virtual DbSet<GpnLensStylesView> GpnLensStylesViews { get; set; }

    public virtual DbSet<GpnLensTintsView> GpnLensTintsViews { get; set; }

    public virtual DbSet<GpnLocationsView> GpnLocationsViews { get; set; }

    public virtual DbSet<GpnOrderChargeTransactionsView> GpnOrderChargeTransactionsViews { get; set; }

    public virtual DbSet<GpnOrderChargesView> GpnOrderChargesViews { get; set; }

    public virtual DbSet<GpnOrderPackageView> GpnOrderPackageViews { get; set; }

    public virtual DbSet<GpnOrderStatusView> GpnOrderStatusViews { get; set; }

    public virtual DbSet<GpnPatientMedicalInsuranceView> GpnPatientMedicalInsuranceViews { get; set; }

    public virtual DbSet<GpnPatientOrderVwTreatment> GpnPatientOrderVwTreatments { get; set; }

    public virtual DbSet<GpnPatientOrdersView> GpnPatientOrdersViews { get; set; }

    public virtual DbSet<GpnPatientVisionInsuranceView> GpnPatientVisionInsuranceViews { get; set; }

    public virtual DbSet<GpnPatientsView> GpnPatientsViews { get; set; }

    public virtual DbSet<GpnPaymentTypesView> GpnPaymentTypesViews { get; set; }

    public virtual DbSet<GpnProviderView> GpnProviderViews { get; set; }

    public virtual DbSet<GpnStaffView> GpnStaffViews { get; set; }

    public virtual DbSet<GpnTaxTypesView> GpnTaxTypesViews { get; set; }

    public virtual DbSet<GpnVwFrameTypeView> GpnVwFrameTypeViews { get; set; }

    public virtual DbSet<GpnVwLensDesignView> GpnVwLensDesignViews { get; set; }

    public virtual DbSet<GpnVwLensMaterialView> GpnVwLensMaterialViews { get; set; }

    public virtual DbSet<GpnVwLensTypesView> GpnVwLensTypesViews { get; set; }

    public virtual DbSet<GpnVwTreatmentsView> GpnVwTreatmentsViews { get; set; }

    public virtual DbSet<GuarantorsPatientIdsTempTable> GuarantorsPatientIdsTempTables { get; set; }

    public virtual DbSet<ImgDocTemplate> ImgDocTemplates { get; set; }

    public virtual DbSet<ImgImageSetting> ImgImageSettings { get; set; }

    public virtual DbSet<ImgPatientDocument> ImgPatientDocuments { get; set; }

    public virtual DbSet<ImgPatientIdentificationCard> ImgPatientIdentificationCards { get; set; }

    public virtual DbSet<ImgPatientInsuranceCard> ImgPatientInsuranceCards { get; set; }

    public virtual DbSet<ImgPatientPhoto> ImgPatientPhotos { get; set; }

    public virtual DbSet<ImportError> ImportErrors { get; set; }

    public virtual DbSet<ImportManufacturer> ImportManufacturers { get; set; }

    public virtual DbSet<ImportTrace> ImportTraces { get; set; }

    public virtual DbSet<InfInterfaceSetting> InfInterfaceSettings { get; set; }

    public virtual DbSet<InfLogStatus> InfLogStatuses { get; set; }

    public virtual DbSet<InsFoxFire> InsFoxFires { get; set; }

    public virtual DbSet<InsInsuranceCarrierType> InsInsuranceCarrierTypes { get; set; }

    public virtual DbSet<InsInsuranceCategory> InsInsuranceCategories { get; set; }

    public virtual DbSet<InsInsuranceCmpTest> InsInsuranceCmpTests { get; set; }

    public virtual DbSet<InsInsuranceCompany> InsInsuranceCompanies { get; set; }

    public virtual DbSet<InsInsuranceCompanyAdditional> InsInsuranceCompanyAdditionals { get; set; }

    public virtual DbSet<InsInsurancePlan> InsInsurancePlans { get; set; }

    public virtual DbSet<InsInsurancePlansCptInformation> InsInsurancePlansCptInformations { get; set; }

    public virtual DbSet<InsuranceCompany> InsuranceCompanies { get; set; }

    public virtual DbSet<InsuranceInformation> InsuranceInformations { get; set; }

    public virtual DbSet<InsuranceXref> InsuranceXrefs { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<InventoryAudit> InventoryAudits { get; set; }

    public virtual DbSet<InventoryAuditDatum> InventoryAuditData { get; set; }

    public virtual DbSet<InventoryAuditReport> InventoryAuditReports { get; set; }

    public virtual DbSet<InventoryId> InventoryIds { get; set; }

    public virtual DbSet<Lab> Labs { get; set; }

    public virtual DbSet<LabColor> LabColors { get; set; }

    public virtual DbSet<LabFrameMaterial> LabFrameMaterials { get; set; }

    public virtual DbSet<LabOrder> LabOrders { get; set; }

    public virtual DbSet<LabOrderBackupV> LabOrderBackupVs { get; set; }

    public virtual DbSet<LabOrderBackupVineel> LabOrderBackupVineels { get; set; }

    public virtual DbSet<LabToArLensCoat> LabToArLensCoats { get; set; }

    public virtual DbSet<LabToFrameEtype> LabToFrameEtypes { get; set; }

    public virtual DbSet<LabToFrameFtype> LabToFrameFtypes { get; set; }

    public virtual DbSet<LabToFrameManufacturer> LabToFrameManufacturers { get; set; }

    public virtual DbSet<LabToFrameStatus> LabToFrameStatuses { get; set; }

    public virtual DbSet<LabToFrameTemple> LabToFrameTemples { get; set; }

    public virtual DbSet<LabToLabFrameMaterial> LabToLabFrameMaterials { get; set; }

    public virtual DbSet<LabToLensColor> LabToLensColors { get; set; }

    public virtual DbSet<LabToLensMaterial> LabToLensMaterials { get; set; }

    public virtual DbSet<LabToLensOrderService> LabToLensOrderServices { get; set; }

    public virtual DbSet<LabToLensStyle> LabToLensStyles { get; set; }

    public virtual DbSet<LabToLensTint> LabToLensTints { get; set; }

    public virtual DbSet<LabToOtherLensCoat> LabToOtherLensCoats { get; set; }

    public virtual DbSet<LabToScrLensCoat> LabToScrLensCoats { get; set; }

    public virtual DbSet<LabToUvLensCoat> LabToUvLensCoats { get; set; }

    public virtual DbSet<LabelPrinter> LabelPrinters { get; set; }

    public virtual DbSet<LastMonth20210118162803> LastMonth20210118162803s { get; set; }

    public virtual DbSet<LastYear20210118162803> LastYear20210118162803s { get; set; }

    public virtual DbSet<LensAvailability> LensAvailabilities { get; set; }

    public virtual DbSet<LensCoat> LensCoats { get; set; }

    public virtual DbSet<LensInformation> LensInformations { get; set; }

    public virtual DbSet<LensMaterial> LensMaterials { get; set; }

    public virtual DbSet<LensMaterialCategory> LensMaterialCategories { get; set; }

    public virtual DbSet<LensOrderInfo> LensOrderInfos { get; set; }

    public virtual DbSet<LensOrderService> LensOrderServices { get; set; }

    public virtual DbSet<LensRxInfo> LensRxInfos { get; set; }

    public virtual DbSet<LensStyle> LensStyles { get; set; }

    public virtual DbSet<LensStyleCategory> LensStyleCategories { get; set; }

    public virtual DbSet<LensTint> LensTints { get; set; }

    public virtual DbSet<LmsDesignToProcedureXref> LmsDesignToProcedureXrefs { get; set; }

    public virtual DbSet<LmsFrameMaster> LmsFrameMasters { get; set; }

    public virtual DbSet<LmsJobType> LmsJobTypes { get; set; }

    public virtual DbSet<LmsLabInformation> LmsLabInformations { get; set; }

    public virtual DbSet<LmsLensDesign> LmsLensDesigns { get; set; }

    public virtual DbSet<LmsLensMaterial> LmsLensMaterials { get; set; }

    public virtual DbSet<LmsLensType> LmsLensTypes { get; set; }

    public virtual DbSet<LmsMaterialToProcedureXref> LmsMaterialToProcedureXrefs { get; set; }

    public virtual DbSet<LmsOrderType> LmsOrderTypes { get; set; }

    public virtual DbSet<LmsOrderTypeToLensStyleXref> LmsOrderTypeToLensStyleXrefs { get; set; }

    public virtual DbSet<LmsOrderTypeToTintTypeXref> LmsOrderTypeToTintTypeXrefs { get; set; }

    public virtual DbSet<LmsOrderTypeToTintsXref> LmsOrderTypeToTintsXrefs { get; set; }

    public virtual DbSet<LmsPackage> LmsPackages { get; set; }

    public virtual DbSet<LmsPackagesToTreatment> LmsPackagesToTreatments { get; set; }

    public virtual DbSet<LmsTint> LmsTints { get; set; }

    public virtual DbSet<LmsTintType> LmsTintTypes { get; set; }

    public virtual DbSet<LmsTreatment> LmsTreatments { get; set; }

    public virtual DbSet<LmsTreatmentsToProcedureXref> LmsTreatmentsToProcedureXrefs { get; set; }

    public virtual DbSet<Loc> Locs { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<LocationArLensCoatInformation> LocationArLensCoatInformations { get; set; }

    public virtual DbSet<LocationLensServiceInformation> LocationLensServiceInformations { get; set; }

    public virtual DbSet<LocationLensTintInformation> LocationLensTintInformations { get; set; }

    public virtual DbSet<LocationOtherLensCoatInformation> LocationOtherLensCoatInformations { get; set; }

    public virtual DbSet<LocationScrLensCoatInformation> LocationScrLensCoatInformations { get; set; }

    public virtual DbSet<LocationToLab> LocationToLabs { get; set; }

    public virtual DbSet<LocationUvLensCoatInformation> LocationUvLensCoatInformations { get; set; }

    public virtual DbSet<LocationVwtreatment> LocationVwtreatments { get; set; }

    public virtual DbSet<LoginInformation> LoginInformations { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<MappingGroup> MappingGroups { get; set; }

    public virtual DbSet<MntAccountNumberFormat> MntAccountNumberFormats { get; set; }

    public virtual DbSet<MntAddressType> MntAddressTypes { get; set; }

    public virtual DbSet<MntContactPreference> MntContactPreferences { get; set; }

    public virtual DbSet<MntCountry> MntCountries { get; set; }

    public virtual DbSet<MntEmploymentStatus> MntEmploymentStatuses { get; set; }

    public virtual DbSet<MntEthnicity> MntEthnicities { get; set; }

    public virtual DbSet<MntGender> MntGenders { get; set; }

    public virtual DbSet<MntHl7Event> MntHl7Events { get; set; }

    public virtual DbSet<MntInsuranceType> MntInsuranceTypes { get; set; }

    public virtual DbSet<MntLanguage> MntLanguages { get; set; }

    public virtual DbSet<MntMaritalStatus> MntMaritalStatuses { get; set; }

    public virtual DbSet<MntMedicareSecondary> MntMedicareSecondaries { get; set; }

    public virtual DbSet<MntPriority> MntPriorities { get; set; }

    public virtual DbSet<MntRace> MntRaces { get; set; }

    public virtual DbSet<MntRelationship> MntRelationships { get; set; }

    public virtual DbSet<MntSpeciality> MntSpecialities { get; set; }

    public virtual DbSet<MntState> MntStates { get; set; }

    public virtual DbSet<MntSuffix> MntSuffixes { get; set; }

    public virtual DbSet<MntTitle> MntTitles { get; set; }

    public virtual DbSet<MntZipcode> MntZipcodes { get; set; }

    public virtual DbSet<MonthAndYearEndDate> MonthAndYearEndDates { get; set; }

    public virtual DbSet<MonthAndYearEndDatesTempEoyFix> MonthAndYearEndDatesTempEoyFixes { get; set; }

    public virtual DbSet<MonthAndYearEndReport> MonthAndYearEndReports { get; set; }

    public virtual DbSet<NavFoxOpticalInterface> NavFoxOpticalInterfaces { get; set; }

    public virtual DbSet<NavGuar> NavGuars { get; set; }

    public virtual DbSet<OfficeMateBillingLocationsTempTable> OfficeMateBillingLocationsTempTables { get; set; }

    public virtual DbSet<OpenEdgeAccountDonationsInformation> OpenEdgeAccountDonationsInformations { get; set; }

    public virtual DbSet<OpenEdgeAccountReceiptMessage> OpenEdgeAccountReceiptMessages { get; set; }

    public virtual DbSet<OpenEdgeElectronicStatementPaymentsInformaitonToOrderCharge> OpenEdgeElectronicStatementPaymentsInformaitonToOrderCharges { get; set; }

    public virtual DbSet<OpenEdgeElectronicStatementsPatientsInformation> OpenEdgeElectronicStatementsPatientsInformations { get; set; }

    public virtual DbSet<OpenEdgeElectronicStatementsPaymentsReportsInformation> OpenEdgeElectronicStatementsPaymentsReportsInformations { get; set; }

    public virtual DbSet<OpenEdgeElectronicStatementsServiceLocationsInformation> OpenEdgeElectronicStatementsServiceLocationsInformations { get; set; }

    public virtual DbSet<OpenEdgeForm> OpenEdgeForms { get; set; }

    public virtual DbSet<OpenEdgeFormsPatientsInformation> OpenEdgeFormsPatientsInformations { get; set; }

    public virtual DbSet<OpenEdgeFormsRequestInformation> OpenEdgeFormsRequestInformations { get; set; }

    public virtual DbSet<OpenEdgeFormsRulesInformation> OpenEdgeFormsRulesInformations { get; set; }

    public virtual DbSet<OpenEdgeInforamation> OpenEdgeInforamations { get; set; }

    public virtual DbSet<OpenEdgeInforamationOld> OpenEdgeInforamationOlds { get; set; }

    public virtual DbSet<OpenEdgeInforamationPre505> OpenEdgeInforamationPre505s { get; set; }

    public virtual DbSet<OpenEdgeInforamationToStaffLocation> OpenEdgeInforamationToStaffLocations { get; set; }

    public virtual DbSet<OpticalTrace> OpticalTraces { get; set; }

    public virtual DbSet<OrdContactLensInfo> OrdContactLensInfos { get; set; }

    public virtual DbSet<OrderCharge> OrderCharges { get; set; }

    public virtual DbSet<OrderChargeTaxDetail> OrderChargeTaxDetails { get; set; }

    public virtual DbSet<OrderChargesAccidentState> OrderChargesAccidentStates { get; set; }

    public virtual DbSet<OrderClxPurchaseInfo> OrderClxPurchaseInfos { get; set; }

    public virtual DbSet<OrderContactLensInfo> OrderContactLensInfos { get; set; }

    public virtual DbSet<OrderLensCoat> OrderLensCoats { get; set; }

    public virtual DbSet<OrderLensTint> OrderLensTints { get; set; }

    public virtual DbSet<OrderNote> OrderNotes { get; set; }

    public virtual DbSet<OrderPackage> OrderPackages { get; set; }

    public virtual DbSet<OrderPackagesToTreatment> OrderPackagesToTreatments { get; set; }

    public virtual DbSet<OrderService> OrderServices { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PatientCardDetail> PatientCardDetails { get; set; }

    public virtual DbSet<PatientGiftCard> PatientGiftCards { get; set; }

    public virtual DbSet<PatientGiftCardTransaction> PatientGiftCardTransactions { get; set; }

    public virtual DbSet<PatientPayment> PatientPayments { get; set; }

    public virtual DbSet<PatientPaymentToOrderCharge> PatientPaymentToOrderCharges { get; set; }

    public virtual DbSet<PatientsTempTable31may2022131413230> PatientsTempTable31may2022131413230s { get; set; }

    public virtual DbSet<PaymentType> PaymentTypes { get; set; }

    public virtual DbSet<PlaceOfTreatment> PlaceOfTreatments { get; set; }

    public virtual DbSet<PrismSetting> PrismSettings { get; set; }

    public virtual DbSet<ProductPuckupOrderStatusInformation> ProductPuckupOrderStatusInformations { get; set; }

    public virtual DbSet<ReceiptAdNote> ReceiptAdNotes { get; set; }

    public virtual DbSet<ReceiptOrFinancialSummaryReportInformation> ReceiptOrFinancialSummaryReportInformations { get; set; }

    public virtual DbSet<ReferralXref> ReferralXrefs { get; set; }

    public virtual DbSet<ReferringProvider> ReferringProviders { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<ReportCategory> ReportCategories { get; set; }

    public virtual DbSet<RptUnpaidClaimsReport> RptUnpaidClaimsReports { get; set; }

    public virtual DbSet<RptUnpaidClaimsReportCharge> RptUnpaidClaimsReportCharges { get; set; }

    public virtual DbSet<RxInformationToProcedureXref> RxInformationToProcedureXrefs { get; set; }

    public virtual DbSet<RxPrintInformation> RxPrintInformations { get; set; }

    public virtual DbSet<SatArTest> SatArTests { get; set; }

    public virtual DbSet<SchedulingAppointment> SchedulingAppointments { get; set; }

    public virtual DbSet<SchedulingAppointmentType> SchedulingAppointmentTypes { get; set; }

    public virtual DbSet<SchedulingAppointmentTypesGrouping> SchedulingAppointmentTypesGroupings { get; set; }

    public virtual DbSet<SchedulingAppointmentTypesToResource> SchedulingAppointmentTypesToResources { get; set; }

    public virtual DbSet<SchedulingCode> SchedulingCodes { get; set; }

    public virtual DbSet<SchedulingCodeType> SchedulingCodeTypes { get; set; }

    public virtual DbSet<SchedulingEvent> SchedulingEvents { get; set; }

    public virtual DbSet<SchedulingHistory> SchedulingHistories { get; set; }

    public virtual DbSet<SchedulingOperator> SchedulingOperators { get; set; }

    public virtual DbSet<SchedulingOperatorDefaultResourcesByLocation> SchedulingOperatorDefaultResourcesByLocations { get; set; }

    public virtual DbSet<SchedulingOperatorGeneralOptionsByLocation> SchedulingOperatorGeneralOptionsByLocations { get; set; }

    public virtual DbSet<SchedulingOperatorPermissionsBySchedulingLocation> SchedulingOperatorPermissionsBySchedulingLocations { get; set; }

    public virtual DbSet<SchedulingPatientRecallList> SchedulingPatientRecallLists { get; set; }

    public virtual DbSet<SchedulingPatientWaitingList> SchedulingPatientWaitingLists { get; set; }

    public virtual DbSet<SchedulingRecallInformationBySequence> SchedulingRecallInformationBySequences { get; set; }

    public virtual DbSet<SchedulingRecallsInformation> SchedulingRecallsInformations { get; set; }

    public virtual DbSet<SchedulingResource> SchedulingResources { get; set; }

    public virtual DbSet<SchedulingRule> SchedulingRules { get; set; }

    public virtual DbSet<SchedulingRuleDate> SchedulingRuleDates { get; set; }

    public virtual DbSet<SchedulingRuleDetail> SchedulingRuleDetails { get; set; }

    public virtual DbSet<SchedulingSpecialty> SchedulingSpecialties { get; set; }

    public virtual DbSet<SearchOperator> SearchOperators { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<StaffIdtoLocation> StaffIdtoLocations { get; set; }

    public virtual DbSet<StaffLevel> StaffLevels { get; set; }

    public virtual DbSet<StaffLoginOption> StaffLoginOptions { get; set; }

    public virtual DbSet<StaffPrintOption> StaffPrintOptions { get; set; }

    public virtual DbSet<StaffType> StaffTypes { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<StatementPaidOffChargesInformation> StatementPaidOffChargesInformations { get; set; }

    public virtual DbSet<StatementParameter> StatementParameters { get; set; }

    public virtual DbSet<StatementPaymentsInformaiton> StatementPaymentsInformaitons { get; set; }

    public virtual DbSet<StatementReportsInformation> StatementReportsInformations { get; set; }

    public virtual DbSet<StatusId> StatusIds { get; set; }

    public virtual DbSet<TaxAndInsuranceCrossReference> TaxAndInsuranceCrossReferences { get; set; }

    public virtual DbSet<TaxAndProcedureCrossReference> TaxAndProcedureCrossReferences { get; set; }

    public virtual DbSet<TaxCrossReference> TaxCrossReferences { get; set; }

    public virtual DbSet<TaxTable> TaxTables { get; set; }

    public virtual DbSet<TaxType> TaxTypes { get; set; }

    public virtual DbSet<TaxesList> TaxesLists { get; set; }

    public virtual DbSet<TaxonomyCode> TaxonomyCodes { get; set; }

    public virtual DbSet<TempDiagTable> TempDiagTables { get; set; }

    public virtual DbSet<TempDiagTable2> TempDiagTable2s { get; set; }

    public virtual DbSet<TempPatient> TempPatients { get; set; }

    public virtual DbSet<TestTable> TestTables { get; set; }

    public virtual DbSet<Testum> Testa { get; set; }

    public virtual DbSet<TransactFoxFire> TransactFoxFires { get; set; }

    public virtual DbSet<TransactionCodesResponsibilityTempTable> TransactionCodesResponsibilityTempTables { get; set; }

    public virtual DbSet<TransactionHistory> TransactionHistories { get; set; }

    public virtual DbSet<TransactionTempTable> TransactionTempTables { get; set; }

    public virtual DbSet<TransactionTotalByOrderChargeTempTable> TransactionTotalByOrderChargeTempTables { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    public virtual DbSet<VendorToManufacturer> VendorToManufacturers { get; set; }

    public virtual DbSet<VwDesign> VwDesigns { get; set; }

    public virtual DbSet<VwDesignToProcedureXref> VwDesignToProcedureXrefs { get; set; }

    public virtual DbSet<VwEssilorInterfaceLog> VwEssilorInterfaceLogs { get; set; }

    public virtual DbSet<VwFrameType> VwFrameTypes { get; set; }

    public virtual DbSet<VwGetVwOrderDetail> VwGetVwOrderDetails { get; set; }

    public virtual DbSet<VwIncompatibleTreatmentsMaster> VwIncompatibleTreatmentsMasters { get; set; }

    public virtual DbSet<VwInhouseFrameType> VwInhouseFrameTypes { get; set; }

    public virtual DbSet<VwInhouseLensDesign> VwInhouseLensDesigns { get; set; }

    public virtual DbSet<VwInhouseLensMaterial> VwInhouseLensMaterials { get; set; }

    public virtual DbSet<VwInhouseLensType> VwInhouseLensTypes { get; set; }

    public virtual DbSet<VwInhouseTreatment> VwInhouseTreatments { get; set; }

    public virtual DbSet<VwLabAccountInfo> VwLabAccountInfos { get; set; }

    public virtual DbSet<VwLensMaster> VwLensMasters { get; set; }

    public virtual DbSet<VwLensType> VwLensTypes { get; set; }

    public virtual DbSet<VwMaterial> VwMaterials { get; set; }

    public virtual DbSet<VwMaterialToProcedureXref> VwMaterialToProcedureXrefs { get; set; }

    public virtual DbSet<VwOrderDetail> VwOrderDetails { get; set; }

    public virtual DbSet<VwOrderInfo> VwOrderInfos { get; set; }

    public virtual DbSet<VwSelectedMaterialCptsOfOrder> VwSelectedMaterialCptsOfOrders { get; set; }

    public virtual DbSet<VwSelectedTreatmentsOfOrder> VwSelectedTreatmentsOfOrders { get; set; }

    public virtual DbSet<VwSupplierCatalog> VwSupplierCatalogs { get; set; }

    public virtual DbSet<VwTreatment> VwTreatments { get; set; }

    public virtual DbSet<VwTreatmentsToProcedureXref> VwTreatmentsToProcedureXrefs { get; set; }

    public virtual DbSet<VwtempDiagnosisTable> VwtempDiagnosisTables { get; set; }

    public virtual DbSet<WebAppointmentRequestInformation> WebAppointmentRequestInformations { get; set; }

    public virtual DbSet<XchargeUser> XchargeUsers { get; set; }

    public virtual DbSet<_4pc1GetAppointmentAndRecallTypesView> _4pc1GetAppointmentAndRecallTypesViews { get; set; }

    public virtual DbSet<_4pc1GetAppointmentsByRulesView> _4pc1GetAppointmentsByRulesViews { get; set; }

    public virtual DbSet<_4pc1GetAppointmentsView> _4pc1GetAppointmentsViews { get; set; }

    public virtual DbSet<_4pc1GetLocationsView> _4pc1GetLocationsViews { get; set; }

    public virtual DbSet<_4pc1GetOrderStatusView> _4pc1GetOrderStatusViews { get; set; }

    public virtual DbSet<_4pc1GetPatientInsuranceView> _4pc1GetPatientInsuranceViews { get; set; }

    public virtual DbSet<_4pc1GetPatientProvidersView> _4pc1GetPatientProvidersViews { get; set; }

    public virtual DbSet<_4pc1GetPatientsView> _4pc1GetPatientsViews { get; set; }

    public virtual DbSet<_4pc1GetProductPickupOrdersView> _4pc1GetProductPickupOrdersViews { get; set; }

    public virtual DbSet<_4pc1GetProviderAndResourcesView> _4pc1GetProviderAndResourcesViews { get; set; }

    public virtual DbSet<_4pc1GetRecallsView> _4pc1GetRecallsViews { get; set; }

    public virtual DbSet<_4pc1GetSettingsView> _4pc1GetSettingsViews { get; set; }

    public virtual DbSet<_4pc1GetVersionInformationView> _4pc1GetVersionInformationViews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountNumberTemp11aug2023124818510>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ACCOUNT_NUMBER_TEMP_11AUG2023124818510");

            entity.HasIndex(e => e.AccountNumber, "Account_Number_Index");

            entity.HasIndex(e => e.PatientId, "Patient_Id_Index");

            entity.Property(e => e.AccountNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Account_Number");
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
        });

        modelBuilder.Entity<AccountXref>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Account_Xref");

            entity.Property(e => e.NewAccount).HasColumnName("New_Account");
            entity.Property(e => e.OldAccount).HasColumnName("Old_Account");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__Addresses__173876EA");

            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Line1)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Line2)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Line3)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.State)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Zip)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.ZipPlus4)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AgeGroup>(entity =>
        {
            entity.HasKey(e => e.GroupId).HasName("PK__AgeGroup__0DAF0CB0");

            entity.ToTable("AgeGroup");

            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.GroupDescription)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.GroupName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BatchNumber>(entity =>
        {
            entity.ToTable("Batch_Numbers");

            entity.Property(e => e.BatchNumberId).HasColumnName("Batch_Number_Id");
            entity.Property(e => e.BatchDate).HasColumnName("Batch_Date");
            entity.Property(e => e.BatchNumber1)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("Batch_Number");
            entity.Property(e => e.FfpmUserName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FFPM_User_Name");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("");
        });

        modelBuilder.Entity<BillingLocation>(entity =>
        {
            entity.ToTable("Billing_Locations");

            entity.Property(e => e.BillingLocationId).HasColumnName("Billing_Location_Id");
            entity.Property(e => e.Abbreviation)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.AddressId).HasColumnName("Address_Id");
            entity.Property(e => e.AlternateTaxonomy10Id).HasColumnName("Alternate_Taxonomy_10_Id");
            entity.Property(e => e.AlternateTaxonomy11Id).HasColumnName("Alternate_Taxonomy_11_Id");
            entity.Property(e => e.AlternateTaxonomy12Id).HasColumnName("Alternate_Taxonomy_12_Id");
            entity.Property(e => e.AlternateTaxonomy13Id).HasColumnName("Alternate_Taxonomy_13_Id");
            entity.Property(e => e.AlternateTaxonomy14Id).HasColumnName("Alternate_Taxonomy_14_Id");
            entity.Property(e => e.AlternateTaxonomy15Id).HasColumnName("Alternate_Taxonomy_15_Id");
            entity.Property(e => e.AlternateTaxonomy16Id).HasColumnName("Alternate_Taxonomy_16_Id");
            entity.Property(e => e.AlternateTaxonomy17Id).HasColumnName("Alternate_Taxonomy_17_Id");
            entity.Property(e => e.AlternateTaxonomy18Id).HasColumnName("Alternate_Taxonomy_18_Id");
            entity.Property(e => e.AlternateTaxonomy19Id).HasColumnName("Alternate_Taxonomy_19_Id");
            entity.Property(e => e.AlternateTaxonomy1Id).HasColumnName("Alternate_Taxonomy_1_Id");
            entity.Property(e => e.AlternateTaxonomy20Id).HasColumnName("Alternate_Taxonomy_20_Id");
            entity.Property(e => e.AlternateTaxonomy2Id).HasColumnName("Alternate_Taxonomy_2_Id");
            entity.Property(e => e.AlternateTaxonomy3Id).HasColumnName("Alternate_Taxonomy_3_Id");
            entity.Property(e => e.AlternateTaxonomy4Id).HasColumnName("Alternate_Taxonomy_4_Id");
            entity.Property(e => e.AlternateTaxonomy5Id).HasColumnName("Alternate_Taxonomy_5_Id");
            entity.Property(e => e.AlternateTaxonomy6Id).HasColumnName("Alternate_Taxonomy_6_Id");
            entity.Property(e => e.AlternateTaxonomy7Id).HasColumnName("Alternate_Taxonomy_7_Id");
            entity.Property(e => e.AlternateTaxonomy8Id).HasColumnName("Alternate_Taxonomy_8_Id");
            entity.Property(e => e.AlternateTaxonomy9Id).HasColumnName("Alternate_Taxonomy_9_Id");
            entity.Property(e => e.CaculateTaxOnEstimatedPatientBalance).HasColumnName("Caculate_Tax_On_Estimated_Patient_Balance");
            entity.Property(e => e.CaculateTaxOnTotalFee)
                .HasDefaultValue(true)
                .HasColumnName("Caculate_Tax_On_Total_Fee");
            entity.Property(e => e.CliaIdNo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CLIA_Id_No");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FederalIdNo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Federal_ID_No");
            entity.Property(e => e.GroupId).HasColumnName("Group_Id");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.IsBillingLocation)
                .HasDefaultValue(true)
                .HasColumnName("Is_Billing_Location");
            entity.Property(e => e.IsDefaultLocation).HasColumnName("Is_Default_Location");
            entity.Property(e => e.IsSchedulingLocation).HasColumnName("Is_Scheduling_Location");
            entity.Property(e => e.LocationId).HasColumnName("Location_Id");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Npi)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("NPI");
            entity.Property(e => e.PlaceOfTreatmentId).HasColumnName("Place_Of_Treatment_Id");
            entity.Property(e => e.PrimaryTaxonomyId).HasColumnName("Primary_Taxonomy_Id");
            entity.Property(e => e.SalesTaxCptId).HasColumnName("Sales_Tax_CPT_Id");
            entity.Property(e => e.TaxActive).HasColumnName("Tax_Active");
        });

        modelBuilder.Entity<BillingLocation1>(entity =>
        {
            entity.HasKey(e => e.BillingLocationId);

            entity.ToTable("BillingLocations");

            entity.Property(e => e.BillingLocationId).HasColumnName("BillingLocationID");
            entity.Property(e => e.BillingLocationCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BillingLocationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.TaxActive).HasDefaultValue(false);
            entity.Property(e => e.TaxProcedure).HasDefaultValue(0);
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BrandId).HasName("PK__Brands__0BC6C43E");

            entity.HasIndex(e => e.BrandId, "IX_Brands").IsUnique();

            entity.Property(e => e.BrandId).HasColumnName("BrandID");
            entity.Property(e => e.BrandName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
        });

        modelBuilder.Entity<CallpopPatientProfile>(entity =>
        {
            entity.ToTable("CALLPOP_PATIENT_PROFILES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AccountNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ACCOUNT_NUMBER");
            entity.Property(e => e.AddedDatetime)
                .HasColumnType("datetime")
                .HasColumnName("ADDED_DATETIME");
            entity.Property(e => e.ErrorMessage)
                .HasMaxLength(5000)
                .IsUnicode(false)
                .HasColumnName("ERROR_MESSAGE");
            entity.Property(e => e.GroupId).HasColumnName("GROUP_ID");
            entity.Property(e => e.Processed).HasColumnName("PROCESSED");
            entity.Property(e => e.ProcessedDatetime)
                .HasColumnType("datetime")
                .HasColumnName("PROCESSED_DATETIME");
            entity.Property(e => e.StaffId).HasColumnName("STAFF_ID");
            entity.Property(e => e.StaffLocationId).HasColumnName("STAFF_LOCATION_ID");
        });

        modelBuilder.Entity<CcbChargesInformation>(entity =>
        {
            entity.ToTable("CCB_CHARGES_INFORMATION");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ChargeAddedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("CHARGE_ADDED_DATE_TIME");
            entity.Property(e => e.ChargeRemoved).HasColumnName("CHARGE_REMOVED");
            entity.Property(e => e.ChargeRemovedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("CHARGE_REMOVED_DATE_TIME");
            entity.Property(e => e.ChargeSentToCcb).HasColumnName("CHARGE_SENT_TO_CCB");
            entity.Property(e => e.FinalNoticeSent).HasColumnName("FINAL_NOTICE_SENT");
            entity.Property(e => e.OrderChargeId).HasColumnName("ORDER_CHARGE_ID");
        });

        modelBuilder.Entity<CcbChargesReportsInformation>(entity =>
        {
            entity.ToTable("CCB_CHARGES_REPORTS_INFORMATION");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ExcelFilePath)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("EXCEL_FILE_PATH");
            entity.Property(e => e.ReportDateTime)
                .HasColumnType("datetime")
                .HasColumnName("REPORT_DATE_TIME");
            entity.Property(e => e.ReportFilePath)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("REPORT_FILE_PATH");
            entity.Property(e => e.StaffId).HasColumnName("STAFF_ID");
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CcbTemp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CCB_Temp");

            entity.Property(e => e.InsuranceId).HasColumnName("InsuranceID");
            entity.Property(e => e.OrderChargeId).HasColumnName("OrderChargeID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.PatientId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Patient_ID");
        });

        modelBuilder.Entity<ChargeInsuranceTransfer>(entity =>
        {
            entity.HasKey(e => e.ChargeInsuranceTransferId).HasName("PK__CHARGE_INSURANCE_TRANSFER__117F9D94");

            entity.ToTable("CHARGE_INSURANCE_TRANSFER");

            entity.Property(e => e.ChargeInsuranceTransferId).HasColumnName("CHARGE_INSURANCE_TRANSFER_ID");
            entity.Property(e => e.AcceptAssignment).HasColumnName("ACCEPT_ASSIGNMENT");
            entity.Property(e => e.AmountTransfered)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AMOUNT_TRANSFERED");
            entity.Property(e => e.GenerateClaim)
                .HasDefaultValue(true)
                .HasColumnName("GENERATE_CLAIM");
            entity.Property(e => e.NewInsuranceId).HasColumnName("NEW_INSURANCE_ID");
            entity.Property(e => e.OldInsuranceId).HasColumnName("OLD_INSURANCE_ID");
            entity.Property(e => e.OrderChargeId).HasColumnName("ORDER_CHARGE_ID");
        });

        modelBuilder.Entity<ChargeNote>(entity =>
        {
            entity.Property(e => e.Notes).IsUnicode(false);
            entity.Property(e => e.OrderChargeId).HasColumnName("OrderChargeID");
        });

        modelBuilder.Entity<ChargePaymentsAdditionalInformation>(entity =>
        {
            entity.HasKey(e => e.ChargePaymentsAdditionalInformationId).HasName("PK__CHARGE_PAYMENTS_ADDITIONAL_INFORMATION__117F9D94");

            entity.ToTable("CHARGE_PAYMENTS_ADDITIONAL_INFORMATION");

            entity.Property(e => e.ChargePaymentsAdditionalInformationId).HasColumnName("CHARGE_PAYMENTS_ADDITIONAL_INFORMATION_ID");
            entity.Property(e => e.Adjustment1TransactionId).HasColumnName("ADJUSTMENT_1_TRANSACTION_ID");
            entity.Property(e => e.Adjustment2TransactionId).HasColumnName("ADJUSTMENT_2_TRANSACTION_ID");
            entity.Property(e => e.Adjustment3TransactionId).HasColumnName("ADJUSTMENT_3_TRANSACTION_ID");
            entity.Property(e => e.Adjustment4TransactionId).HasColumnName("ADJUSTMENT_4_TRANSACTION_ID");
            entity.Property(e => e.Allowed)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("ALLOWED");
            entity.Property(e => e.Coinsurance)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("COINSURANCE");
            entity.Property(e => e.Copay)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("COPAY");
            entity.Property(e => e.Deductable)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("DEDUCTABLE");
            entity.Property(e => e.InsuranceId).HasColumnName("INSURANCE_ID");
            entity.Property(e => e.Payment1TransactionId).HasColumnName("PAYMENT_1_TRANSACTION_ID");
            entity.Property(e => e.Payment2TransactionId).HasColumnName("PAYMENT_2_TRANSACTION_ID");
        });

        modelBuilder.Entity<ChargeTransaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK_Transactions");

            entity.HasIndex(e => e.OrderChargeId, "ChargeId");

            entity.Property(e => e.BatchNumber)
                .HasMaxLength(35)
                .IsUnicode(false);
            entity.Property(e => e.CheckNumber)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateDeleted).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.DeletedUser)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.InsuranceId).HasColumnName("InsuranceID");
            entity.Property(e => e.Operator)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.ReasonAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ReferenceNumber)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.TransactionAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.TransactionCode).WithMany(p => p.ChargeTransactions)
                .HasForeignKey(d => d.TransactionCodeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChargeTransactions_ChargeTransactionCodes");

            entity.HasOne(d => d.TransactionType).WithMany(p => p.ChargeTransactions)
                .HasForeignKey(d => d.TransactionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChargeTransactions_ChargeTransactionTypes");
        });

        modelBuilder.Entity<ChargeTransactionCategory>(entity =>
        {
            entity.ToTable("CHARGE_TRANSACTION_CATEGORY");

            entity.Property(e => e.ChargeTransactionCategoryId).HasColumnName("Charge_Transaction_Category_Id");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.SortNumber)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("Sort_Number");
        });

        modelBuilder.Entity<ChargeTransactionCode>(entity =>
        {
            entity.HasKey(e => e.TransactionCodeId).HasName("PK_TransactionCodes");

            entity.HasIndex(e => e.TransactionCodeCd, "NonClusteredIndex-20190214-101516");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CreditDebitDescriptionId).HasColumnName("Credit_Debit_Description_ID");
            entity.Property(e => e.PaymentTypeId).HasColumnName("PaymentTypeID");
            entity.Property(e => e.ResponsibilityId).HasColumnName("ResponsibilityID");
            entity.Property(e => e.TransactionCodeCd)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TransactionCodeDescription)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TransactionCodeName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.TransactionType).WithMany(p => p.ChargeTransactionCodes)
                .HasForeignKey(d => d.TransactionTypeId)
                .HasConstraintName("FK_ChargeTransactionCodes_ChargeTransactionTypes");
        });

        modelBuilder.Entity<ChargeTransactionToGiftCardTransactionMapping>(entity =>
        {
            entity.HasKey(e => e.MappingId);

            entity.ToTable("ChargeTransactionToGiftCardTransactionMapping");
        });

        modelBuilder.Entity<ChargeTransactionType>(entity =>
        {
            entity.HasKey(e => e.TransactionTypeId);

            entity.Property(e => e.TransactionTypeCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TransactionTypeDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TransactionTypeName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ClnsBrand>(entity =>
        {
            entity.ToTable("CLNS_BRANDS");

            entity.Property(e => e.ClnsBrandId).HasColumnName("CLNS_BRAND_ID");
            entity.Property(e => e.AddedBy).HasColumnName("ADDED_BY");
            entity.Property(e => e.AddedDate)
                .HasColumnType("datetime")
                .HasColumnName("ADDED_DATE");
            entity.Property(e => e.BrandCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("BRAND_CODE");
            entity.Property(e => e.BrandName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BRAND_NAME");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(e => e.LocationId).HasColumnName("LOCATION_ID");
        });

        modelBuilder.Entity<ClnsBrandCptXref>(entity =>
        {
            entity.HasKey(e => e.BrandCptXrfId);

            entity.ToTable("CLNS_Brand_CPT_Xref");

            entity.Property(e => e.BrandId).HasColumnName("BrandID");
            entity.Property(e => e.CptId).HasColumnName("CptID");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
        });

        modelBuilder.Entity<ClnsContactLen>(entity =>
        {
            entity.HasKey(e => e.ContactLensId);

            entity.ToTable("CLNS_CONTACT_LENS");

            entity.HasIndex(e => new { e.ContactLensId, e.ClnsBrandId, e.Sphere, e.BaseCurve, e.Diameter, e.Upc }, "NonClusteredIndex-20180310-083144");

            entity.Property(e => e.ContactLensId).HasColumnName("CONTACT_LENS_ID");
            entity.Property(e => e.AddPower)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ADD_POWER");
            entity.Property(e => e.AddPowerName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ADD_POWER_NAME");
            entity.Property(e => e.AddedBy).HasColumnName("ADDED_BY");
            entity.Property(e => e.AddedDate)
                .HasColumnType("datetime")
                .HasColumnName("ADDED_DATE");
            entity.Property(e => e.Axis)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("AXIS");
            entity.Property(e => e.BaseCurve)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("BASE_CURVE");
            entity.Property(e => e.ClnsBrandId).HasColumnName("CLNS_BRAND_ID");
            entity.Property(e => e.ClnsLensTypeId).HasColumnName("CLNS_LENS_TYPE_ID");
            entity.Property(e => e.ClnsManufacturerId).HasColumnName("CLNS_MANUFACTURER_ID");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("COLOR");
            entity.Property(e => e.CptId).HasColumnName("CPT_ID");
            entity.Property(e => e.Cylinder)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CYLINDER");
            entity.Property(e => e.Diameter)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DIAMETER");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(e => e.IsLensFromClxCatalog).HasColumnName("IS_LENS_FROM_CLX_CATALOG");
            entity.Property(e => e.IsSoftContact).HasColumnName("IS_SOFT_CONTACT");
            entity.Property(e => e.LensPerBox).HasColumnName("LENS_PER_BOX");
            entity.Property(e => e.LocationId).HasColumnName("LOCATION_ID");
            entity.Property(e => e.Multifocal)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MULTIFOCAL");
            entity.Property(e => e.Sphere)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SPHERE");
            entity.Property(e => e.Upc)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("UPC");
            entity.Property(e => e.UpdatedBy).HasColumnName("UPDATED_BY");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_DATE");
        });

        modelBuilder.Entity<ClnsInventory>(entity =>
        {
            entity.HasKey(e => e.InventoryId);

            entity.ToTable("CLNS_INVENTORY");

            entity.Property(e => e.InventoryId).HasColumnName("INVENTORY_ID");
            entity.Property(e => e.AddedBy).HasColumnName("ADDED_BY");
            entity.Property(e => e.AddedDate)
                .HasColumnType("datetime")
                .HasColumnName("ADDED_DATE");
            entity.Property(e => e.Barcode)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("BARCODE");
            entity.Property(e => e.ContactLensId).HasColumnName("CONTACT_LENS_ID");
            entity.Property(e => e.Dispensed).HasColumnName("DISPENSED");
            entity.Property(e => e.ExpiryDate)
                .HasColumnType("datetime")
                .HasColumnName("EXPIRY_DATE");
            entity.Property(e => e.InvoiceDate)
                .HasColumnType("datetime")
                .HasColumnName("INVOICE_DATE");
            entity.Property(e => e.InvoiceNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("INVOICE_NUMBER");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(e => e.IsTrials).HasColumnName("IS_TRIALS");
            entity.Property(e => e.ItemCost)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ITEM_COST");
            entity.Property(e => e.LocationId).HasColumnName("LOCATION_ID");
            entity.Property(e => e.Notes)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.OnHand).HasColumnName("ON_HAND");
            entity.Property(e => e.QuantityOrdered).HasColumnName("QUANTITY_ORDERED");
            entity.Property(e => e.Received).HasColumnName("RECEIVED");
            entity.Property(e => e.RetailPrice)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("RETAIL_PRICE");
            entity.Property(e => e.UpdatedBy).HasColumnName("UPDATED_BY");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_DATE");
            entity.Property(e => e.WholesalePrice)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WHOLESALE_PRICE");
        });

        modelBuilder.Entity<ClnsLensType>(entity =>
        {
            entity.HasKey(e => e.ClnsLensTypeId).HasName("CLNS_LENS_TYPE");

            entity.ToTable("CLNS_LENS_TYPES");

            entity.Property(e => e.ClnsLensTypeId).HasColumnName("CLNS_LENS_TYPE_ID");
            entity.Property(e => e.AddedBy).HasColumnName("ADDED_BY");
            entity.Property(e => e.AddedDate)
                .HasColumnType("datetime")
                .HasColumnName("ADDED_DATE");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(e => e.LensTypeCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LENS_TYPE_CODE");
            entity.Property(e => e.LensTypeName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LENS_TYPE_NAME");
            entity.Property(e => e.LocationId).HasColumnName("LOCATION_ID");
        });

        modelBuilder.Entity<ClnsManufacturer>(entity =>
        {
            entity.ToTable("CLNS_MANUFACTURERS");

            entity.Property(e => e.ClnsManufacturerId).HasColumnName("CLNS_MANUFACTURER_ID");
            entity.Property(e => e.AddedBy).HasColumnName("ADDED_BY");
            entity.Property(e => e.AddedDate)
                .HasColumnType("datetime")
                .HasColumnName("ADDED_DATE");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(e => e.LocationId).HasColumnName("LOCATION_ID");
            entity.Property(e => e.ManufacturerCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MANUFACTURER_CODE");
            entity.Property(e => e.ManufacturerName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MANUFACTURER_NAME");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CompanyId).ValueGeneratedOnAdd();
            entity.Property(e => e.CompanyName)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ContactInfo>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PK__ContactInfo__1920BF5C");

            entity.ToTable("ContactInfo");

            entity.HasIndex(e => e.ContactId, "IX_ContactInfo").IsUnique();

            entity.HasIndex(e => new { e.ContactId, e.LocationId }, "IX_ContactInfo_IdLocation").IsUnique();

            entity.Property(e => e.ContactId).HasColumnName("ContactID");
            entity.Property(e => e.CellPhone)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Fax)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.HomePhone)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.WorkExtension)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.WorkPhone)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ContactLense>(entity =>
        {
            entity.HasKey(e => e.LensId);

            entity.Property(e => e.AddPower).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.Base).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.Brand)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cost).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.CptId).HasColumnName("CptID");
            entity.Property(e => e.Cylinder).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.Diameter).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.Sphere).HasColumnType("decimal(6, 2)");
        });

        modelBuilder.Entity<ConvFfpmAccount>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CONV_FFPM_Account");

            entity.Property(e => e.ConvAccount)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CONV_Account");
            entity.Property(e => e.FfpmAccount)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FFPM_Account");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.CountryName)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CptDepartment>(entity =>
        {
            entity.HasKey(e => e.DepartmentId);

            entity.ToTable("CPT_Departments");

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.SortNumber)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("Sort_Number");
        });

        modelBuilder.Entity<CptFfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CPT_FFO");

            entity.Property(e => e.Column0)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Column 0");
            entity.Property(e => e.Column1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Column 1");
            entity.Property(e => e.Column2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Column 2");
            entity.Property(e => e.Column3)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Column 3");
            entity.Property(e => e.Column4)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Column 4");
            entity.Property(e => e.Column5)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Column 5");
            entity.Property(e => e.Column6)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Column 6");
            entity.Property(e => e.Column7)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Column 7");
        });

        modelBuilder.Entity<CptGroupMapping>(entity =>
        {
            entity.HasKey(e => e.MappingId);

            entity.ToTable("CptGroupMapping");

            entity.Property(e => e.Active).HasDefaultValue(false);
        });

        modelBuilder.Entity<CptStaging>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CptStaging");

            entity.Property(e => e.Dp)
                .HasMaxLength(255)
                .HasColumnName("DP");
            entity.Property(e => e.F1proc).HasColumnName("F1PROC");
            entity.Property(e => e.Privdesc)
                .HasMaxLength(255)
                .HasColumnName("PRIVDESC");
            entity.Property(e => e.Procdesc)
                .HasMaxLength(255)
                .HasColumnName("PROCDESC");
            entity.Property(e => e.Procid)
                .HasMaxLength(255)
                .HasColumnName("PROCID");
            entity.Property(e => e.Srchdesc)
                .HasMaxLength(255)
                .HasColumnName("SRCHDESC");
            entity.Property(e => e.Stdfee).HasColumnName("STDFEE");
        });

        modelBuilder.Entity<CptTypeOfService>(entity =>
        {
            entity.HasKey(e => e.TypeOfServiceId);

            entity.ToTable("CPT_TypeOfServices");

            entity.Property(e => e.TypeOfServiceId).HasColumnName("TypeOfServiceID");
            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
        });

        modelBuilder.Entity<Cptid>(entity =>
        {
            entity.HasKey(e => e.Cptid1);

            entity.ToTable("CPTIDS");

            entity.HasIndex(e => e.Cpt, "NonClusteredIndex-20190214-101505");

            entity.Property(e => e.Cptid1).HasColumnName("CPTID");
            entity.Property(e => e.AlternateCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.Cpt)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CPT");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Fee).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.NdcActive).HasColumnName("NDC_Active");
            entity.Property(e => e.NdcCode)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("NDC_Code");
            entity.Property(e => e.NdcCost)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("NDC_Cost");
            entity.Property(e => e.NdcQuantity)
                .HasColumnType("decimal(11, 3)")
                .HasColumnName("NDC_Quantity");
            entity.Property(e => e.NdcUnitsMeasurementId).HasColumnName("NDC_Units_Measurement_Id");
            entity.Property(e => e.PrivateStatementDescription)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.TaxTypeId).HasColumnName("TaxTypeID");
            entity.Property(e => e.TypeOfServiceId).HasColumnName("TypeOfServiceID");
            entity.Property(e => e.Units).HasDefaultValue(1);
            entity.Property(e => e.UseClianumber).HasColumnName("UseCLIANumber");
        });

        modelBuilder.Entity<CpttempTable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CPTTempTable");

            entity.Property(e => e.AlternateCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Cpt)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CPT");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Fee).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Invalidcol)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("INVALIDCOL");
            entity.Property(e => e.TypeOfServiceId).HasColumnName("TypeOfServiceID");
        });

        modelBuilder.Entity<CurrentMonth20210118162803>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CURRENT_MONTH_20210118162803");

            entity.Property(e => e.Amount).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.BillingLocationId).HasColumnName("Billing_Location_Id");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.EventCategory)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Event_Category");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.GroupId).HasColumnName("Group_Id");
            entity.Property(e => e.InsCategoryId).HasColumnName("Ins_Category_Id");
            entity.Property(e => e.InsCompanyId).HasColumnName("Ins_Company_Id");
            entity.Property(e => e.InsuranceId).HasColumnName("Insurance_Id");
            entity.Property(e => e.ProcedureId).HasColumnName("Procedure_ID");
            entity.Property(e => e.ProviderId).HasColumnName("Provider_Id");
            entity.Property(e => e.RowNum).HasColumnName("Row_Num");
            entity.Property(e => e.Tax).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.TranCategoryId).HasColumnName("Tran_Category_Id");
            entity.Property(e => e.TransactionCodeId).HasColumnName("Transaction_Code_Id");
        });

        modelBuilder.Entity<CurrentYear20210118162803>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CURRENT_YEAR_20210118162803");

            entity.Property(e => e.Amount).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.BillingLocationId).HasColumnName("Billing_Location_Id");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.EventCategory)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Event_Category");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.GroupId).HasColumnName("Group_Id");
            entity.Property(e => e.InsCategoryId).HasColumnName("Ins_Category_Id");
            entity.Property(e => e.InsCompanyId).HasColumnName("Ins_Company_Id");
            entity.Property(e => e.InsuranceId).HasColumnName("Insurance_Id");
            entity.Property(e => e.ProcedureId).HasColumnName("Procedure_ID");
            entity.Property(e => e.ProviderId).HasColumnName("Provider_Id");
            entity.Property(e => e.RowNum).HasColumnName("Row_Num");
            entity.Property(e => e.Tax).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.TranCategoryId).HasColumnName("Tran_Category_Id");
            entity.Property(e => e.TransactionCodeId).HasColumnName("Transaction_Code_Id");
        });

        modelBuilder.Entity<DashUserPermission>(entity =>
        {
            entity.HasKey(e => e.DashUserPermissingId);

            entity.ToTable("DASH_USER_PERMISSIONS");

            entity.Property(e => e.DashUserPermissingId).HasColumnName("Dash_User_Permissing_Id");
            entity.Property(e => e.PanelApptsToday).HasColumnName("Panel_Appts_Today");
            entity.Property(e => e.PanelCcbDetails).HasColumnName("Panel_CCB_Details");
            entity.Property(e => e.PanelClRx).HasColumnName("Panel_CL_Rx");
            entity.Property(e => e.PanelClaimSatus).HasColumnName("Panel_Claim_Satus");
            entity.Property(e => e.PanelElecRemits).HasColumnName("Panel_Elec_Remits");
            entity.Property(e => e.PanelEligDetails).HasColumnName("Panel_Elig_Details");
            entity.Property(e => e.PanelEomDetails).HasColumnName("Panel_EOM_Details");
            entity.Property(e => e.PanelFinalize).HasColumnName("Panel_Finalize");
            entity.Property(e => e.PanelHcfaPrintQueue).HasColumnName("Panel_Hcfa_Print_Queue");
            entity.Property(e => e.PanelProcClaims).HasColumnName("Panel_Proc_Claims");
            entity.Property(e => e.PanelProductPickup).HasColumnName("Panel_Product_Pickup");
            entity.Property(e => e.PanelSpecRx).HasColumnName("Panel_SpecRx");
            entity.Property(e => e.PanelStatements).HasColumnName("Panel_Statements");
            entity.Property(e => e.PanelUnapplied).HasColumnName("Panel_Unapplied");
            entity.Property(e => e.PanelWebApptDetails).HasColumnName("Panel_Web_Appt_Details");
            entity.Property(e => e.StaffId).HasColumnName("Staff_Id");
        });

        modelBuilder.Entity<DiagnosisCode>(entity =>
        {
            entity.Property(e => e.DiagnosisCodeId).HasColumnName("DiagnosisCodeID");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.DiagnosisCode1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DiagnosisCode");
            entity.Property(e => e.Icd9code)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("ICD9Code");
            entity.Property(e => e.IsIcd10).HasColumnName("IsICD10");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
        });

        modelBuilder.Entity<DiagnosisCodesNew>(entity =>
        {
            entity.HasKey(e => e.DiagnosisCodeId);

            entity.ToTable("DiagnosisCodesNew");

            entity.Property(e => e.DiagnosisCodeId)
                .ValueGeneratedNever()
                .HasColumnName("DiagnosisCodeID");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.DiagnosisCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
        });

        modelBuilder.Entity<DiagnosisGroupMapping>(entity =>
        {
            entity.HasKey(e => e.MappingId);

            entity.ToTable("DiagnosisGroupMapping");
        });

        modelBuilder.Entity<DiagnosisStaging>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DiagnosisStaging");

            entity.Property(e => e.Altdesc)
                .HasMaxLength(255)
                .HasColumnName("ALTDESC");
            entity.Property(e => e.Desc)
                .HasMaxLength(255)
                .HasColumnName("DESC");
            entity.Property(e => e.Diag1)
                .HasMaxLength(255)
                .HasColumnName("DIAG1");
            entity.Property(e => e.F5).HasMaxLength(255);
            entity.Property(e => e.Key)
                .HasMaxLength(255)
                .HasColumnName("KEY");
        });

        modelBuilder.Entity<DmeOrdersTempTable02apr2024162959457>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DME_ORDERS_TEMP_TABLE_02APR2024162959457");
        });

        modelBuilder.Entity<DmeOrdersTempTable02apr2024163026943>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DME_ORDERS_TEMP_TABLE_02APR2024163026943");
        });

        modelBuilder.Entity<DmeOrdersTempTable02apr2024163232143>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DME_ORDERS_TEMP_TABLE_02APR2024163232143");
        });

        modelBuilder.Entity<DmeOrdersTempTable02apr2024164139327>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DME_ORDERS_TEMP_TABLE_02APR2024164139327");
        });

        modelBuilder.Entity<DmeOrdersTempTable02apr2024164217510>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DME_ORDERS_TEMP_TABLE_02APR2024164217510");
        });

        modelBuilder.Entity<DmgGroup>(entity =>
        {
            entity.HasKey(e => e.GroupId);

            entity.ToTable("DMG_GROUPS");

            entity.Property(e => e.GroupId).HasColumnName("Group_Id");
            entity.Property(e => e.AddressId).HasColumnName("Address_Id");
            entity.Property(e => e.AlternateTaxonomy10Id).HasColumnName("Alternate_Taxonomy_10_Id");
            entity.Property(e => e.AlternateTaxonomy11Id).HasColumnName("Alternate_Taxonomy_11_Id");
            entity.Property(e => e.AlternateTaxonomy12Id).HasColumnName("Alternate_Taxonomy_12_Id");
            entity.Property(e => e.AlternateTaxonomy13Id).HasColumnName("Alternate_Taxonomy_13_Id");
            entity.Property(e => e.AlternateTaxonomy14Id).HasColumnName("Alternate_Taxonomy_14_Id");
            entity.Property(e => e.AlternateTaxonomy15Id).HasColumnName("Alternate_Taxonomy_15_Id");
            entity.Property(e => e.AlternateTaxonomy16Id).HasColumnName("Alternate_Taxonomy_16_Id");
            entity.Property(e => e.AlternateTaxonomy17Id).HasColumnName("Alternate_Taxonomy_17_Id");
            entity.Property(e => e.AlternateTaxonomy18Id).HasColumnName("Alternate_Taxonomy_18_Id");
            entity.Property(e => e.AlternateTaxonomy19Id).HasColumnName("Alternate_Taxonomy_19_Id");
            entity.Property(e => e.AlternateTaxonomy1Id).HasColumnName("Alternate_Taxonomy_1_Id");
            entity.Property(e => e.AlternateTaxonomy20Id).HasColumnName("Alternate_Taxonomy_20_Id");
            entity.Property(e => e.AlternateTaxonomy2Id).HasColumnName("Alternate_Taxonomy_2_Id");
            entity.Property(e => e.AlternateTaxonomy3Id).HasColumnName("Alternate_Taxonomy_3_Id");
            entity.Property(e => e.AlternateTaxonomy4Id).HasColumnName("Alternate_Taxonomy_4_Id");
            entity.Property(e => e.AlternateTaxonomy5Id).HasColumnName("Alternate_Taxonomy_5_Id");
            entity.Property(e => e.AlternateTaxonomy6Id).HasColumnName("Alternate_Taxonomy_6_Id");
            entity.Property(e => e.AlternateTaxonomy7Id).HasColumnName("Alternate_Taxonomy_7_Id");
            entity.Property(e => e.AlternateTaxonomy8Id).HasColumnName("Alternate_Taxonomy_8_Id");
            entity.Property(e => e.AlternateTaxonomy9Id).HasColumnName("Alternate_Taxonomy_9_Id");
            entity.Property(e => e.BillingQuestionsPhoneNumber)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("Billing_Questions_Phone_Number");
            entity.Property(e => e.CallPopActive).HasColumnName("CallPop_Active");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FederalIdNo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Federal_ID_No");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.IsIndividual).HasColumnName("Is_Individual");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Npi)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("NPI");
            entity.Property(e => e.OpenEdgeExternalId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("OPEN_EDGE_EXTERNAL_ID");
            entity.Property(e => e.PrimaryTaxonomyId).HasColumnName("Primary_Taxonomy_Id");
            entity.Property(e => e.ProcessingAccountId).HasColumnName("Processing_Account_Id");
            entity.Property(e => e.ProfessionalName)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Professional_Name");
            entity.Property(e => e.RemitAddressId).HasColumnName("Remit_Address_Id");
            entity.Property(e => e.RemitGroupName)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("Remit_Group_Name");
            entity.Property(e => e.Ssn)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SSN");
            entity.Property(e => e.StatementAddressId).HasColumnName("Statement_Address_Id");
            entity.Property(e => e.StatementGroupName)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("Statement_Group_Name");
            entity.Property(e => e.UseGroupCellNumberForBillingQuestions)
                .HasDefaultValue(true)
                .HasColumnName("Use_Group_Cell_Number_For_Billing_Questions");
            entity.Property(e => e.UseGroupNameAndAddressForRemitOnStatement)
                .HasDefaultValue(true)
                .HasColumnName("Use_Group_Name_And_Address_For_Remit_On_Statement");
            entity.Property(e => e.UseGroupNameAndAddressOnStatement)
                .HasDefaultValue(true)
                .HasColumnName("Use_Group_Name_And_Address_On_Statement");
        });

        modelBuilder.Entity<DmgGuarantor>(entity =>
        {
            entity.HasKey(e => e.GuarantorId).HasName("PK_DMG_GUARANTOR_DETAIL");

            entity.ToTable("DMG_GUARANTOR");

            entity.HasIndex(e => new { e.PatientId, e.IsActive }, "PID_ACT");

            entity.Property(e => e.GuarantorId).HasColumnName("Guarantor_Id");
            entity.Property(e => e.AddedDate)
                .HasColumnType("datetime")
                .HasColumnName("Added_Date");
            entity.Property(e => e.AddressId).HasColumnName("Address_Id");
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("DOB");
            entity.Property(e => e.EmploymentStatusId).HasColumnName("Employment_Status_Id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.GenderId).HasColumnName("Gender_Id");
            entity.Property(e => e.GuarantorExistingPatientId).HasColumnName("Guarantor_Existing_Patient_Id");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.IsGuarantorExistingPatient).HasColumnName("Is_Guarantor_Existing_Patient");
            entity.Property(e => e.LastModifiedBy).HasColumnName("Last_Modified_By");
            entity.Property(e => e.LastModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Modified_Date");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Middle_Name");
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
            entity.Property(e => e.RelationId).HasColumnName("Relation_Id");
            entity.Property(e => e.RemovedDate)
                .HasColumnType("datetime")
                .HasColumnName("Removed_Date");
            entity.Property(e => e.Ssn)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SSN");
            entity.Property(e => e.SuffixId).HasColumnName("Suffix_Id");
            entity.Property(e => e.TitleId).HasColumnName("Title_Id");
        });

        modelBuilder.Entity<DmgHl7Event>(entity =>
        {
            entity.ToTable("DMG_HL7_EVENTS");

            entity.Property(e => e.DmgHl7EventId).HasColumnName("Dmg_HL7_Event_Id");
            entity.Property(e => e.DmgEventDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Dmg_Event_DateTime");
            entity.Property(e => e.DmgEventType)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Dmg_Event_Type");
            entity.Property(e => e.DmgPatientId).HasColumnName("Dmg_Patient_Id");
            entity.Property(e => e.DmgStaffId).HasColumnName("Dmg_Staff_Id");
            entity.Property(e => e.FormId).HasColumnName("Form_Id");
            entity.Property(e => e.ProcessedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Processed_DateTime");
        });

        modelBuilder.Entity<DmgOtherAddress>(entity =>
        {
            entity.HasKey(e => e.AddressId);

            entity.ToTable("DMG_OTHER_ADDRESS");

            entity.Property(e => e.AddressId).HasColumnName("Address_Id");
            entity.Property(e => e.Address1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Address_1");
            entity.Property(e => e.Address2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Address_2");
            entity.Property(e => e.AddressType).HasColumnName("Address_Type");
            entity.Property(e => e.AptSte)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CellPhone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Cell_Phone");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CountryId).HasColumnName("Country_Id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Extension)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Fax)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.HomePhone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Home_Phone");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.OwnerId).HasColumnName("Owner_Id");
            entity.Property(e => e.OwnerType).HasColumnName("Owner_Type");
            entity.Property(e => e.PreferredContact)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Preferred_Contact");
            entity.Property(e => e.StateId).HasColumnName("State_Id");
            entity.Property(e => e.WorkPhone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Work_Phone");
            entity.Property(e => e.Zip)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ZipExt)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DmgPatient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK_DMG_PATIENT_DETAIL");

            entity.ToTable("DMG_PATIENT");

            entity.HasIndex(e => new { e.AccountNumber, e.AltAccountNumber, e.AddressId }, "NonClusteredIndex-20171030-144450");

            entity.HasIndex(e => e.PatientId, "Patient_ID").IsUnique();

            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
            entity.Property(e => e.AccountBalenceExists).HasColumnName("Account_Balence_Exists");
            entity.Property(e => e.AccountNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Account_Number");
            entity.Property(e => e.AddressId).HasColumnName("Address_Id");
            entity.Property(e => e.AltAccountNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Alt_Account_Number");
            entity.Property(e => e.AsssignedPhysicianId).HasColumnName("Asssigned_Physician_Id");
            entity.Property(e => e.BalanceLastUpdatedDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Balance_Last_Updated_Date_Time");
            entity.Property(e => e.ConversionDetailId).HasColumnName("Conversion_Detail_Id");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("Date_Created");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("datetime")
                .HasColumnName("Date_Of_Birth");
            entity.Property(e => e.DeceasedDate).HasColumnName("Deceased_Date");
            entity.Property(e => e.DoNotSendStatements).HasColumnName("Do_Not_Send_Statements");
            entity.Property(e => e.EmailNotApplicable).HasColumnName("Email_Not_Applicable");
            entity.Property(e => e.EmailStatements).HasColumnName("Email_Statements");
            entity.Property(e => e.EmploymentStatusId).HasColumnName("Employment_Status_Id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.GenderId).HasColumnName("Gender_Id");
            entity.Property(e => e.HasAlerts).HasColumnName("Has_Alerts");
            entity.Property(e => e.HasRemarks).HasColumnName("Has_Remarks");
            entity.Property(e => e.InsuranceBalance)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("Insurance_Balance");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.IsDeceased).HasColumnName("Is_Deceased");
            entity.Property(e => e.IsMerge).HasColumnName("Is_Merge");
            entity.Property(e => e.IsTestPatient).HasColumnName("Is_Test_Patient");
            entity.Property(e => e.LastExamAppointmentTypeId)
                .HasDefaultValue(0)
                .HasColumnName("Last_Exam_Appointment_Type_Id");
            entity.Property(e => e.LastExamBillingLocationId)
                .HasDefaultValue(0)
                .HasColumnName("Last_Exam_Billing_Location_Id");
            entity.Property(e => e.LastExamDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Exam_Date");
            entity.Property(e => e.LastExamResourceId)
                .HasDefaultValue(0)
                .HasColumnName("Last_Exam_Resource_Id");
            entity.Property(e => e.LastExamStaffLocationId)
                .HasDefaultValue(0)
                .HasColumnName("Last_Exam_Staff_Location_Id");
            entity.Property(e => e.LastModifiedBy).HasColumnName("Last_Modified_By");
            entity.Property(e => e.LastModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Modified_Date");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.LocationId).HasColumnName("Location_Id");
            entity.Property(e => e.MaritialStatusId).HasColumnName("Maritial_Status_Id");
            entity.Property(e => e.MergeDetailId).HasColumnName("Merge_Detail_Id");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Middle_Name");
            entity.Property(e => e.OnHold).HasColumnName("On_Hold");
            entity.Property(e => e.OpenEdgeCustomerId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("OpenEdge_Customer_ID");
            entity.Property(e => e.OtherBalance)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("Other_Balance");
            entity.Property(e => e.PatientBalance)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("Patient_Balance");
            entity.Property(e => e.PreferredName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Preferred_Name");
            entity.Property(e => e.ReferringProviderId).HasColumnName("Referring_Provider_Id");
            entity.Property(e => e.Ssn)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SSN");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SuffixId).HasColumnName("Suffix_Id");
            entity.Property(e => e.TextStatements).HasColumnName("Text_Statements");
            entity.Property(e => e.TitleId).HasColumnName("Title_Id");
            entity.Property(e => e.UserId).HasColumnName("User_Id");
        });

        modelBuilder.Entity<DmgPatientAdditionalDetail>(entity =>
        {
            entity.HasKey(e => e.PatientAdditionalDetailsId).HasName("PK_DMG_PATIENT_ADDITIONAL_DETAILS_1");

            entity.ToTable("DMG_PATIENT_ADDITIONAL_DETAILS");

            entity.Property(e => e.PatientAdditionalDetailsId).HasColumnName("Patient_Additional_Details_Id");
            entity.Property(e => e.DoNotContactAutomatedPhone).HasColumnName("Do_Not_Contact_Automated_Phone");
            entity.Property(e => e.DoNotContactEmail).HasColumnName("Do_Not_Contact_Email");
            entity.Property(e => e.DoNotContactHumanPhone).HasColumnName("Do_Not_Contact_Human_Phone");
            entity.Property(e => e.DoNotContactPostal).HasColumnName("Do_Not_Contact_Postal");
            entity.Property(e => e.DriversLicenseNumber)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Drivers_License_Number");
            entity.Property(e => e.DriversLicenseStateId).HasColumnName("Drivers_License_State_Id");
            entity.Property(e => e.EmergencyAddressId).HasColumnName("Emergency_Address_Id");
            entity.Property(e => e.EmergencyFirst)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Emergency_First");
            entity.Property(e => e.EmergencyLast)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Emergency_Last");
            entity.Property(e => e.EmergencyPatientId).HasColumnName("Emergency_Patient_Id");
            entity.Property(e => e.EmergencyRelationId).HasColumnName("Emergency_Relation_Id");
            entity.Property(e => e.EmployerAddressId).HasColumnName("Employer_Address_Id");
            entity.Property(e => e.EmployerName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Employer_Name");
            entity.Property(e => e.EmployerWebsite)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Employer_Website");
            entity.Property(e => e.EthnicityId).HasColumnName("Ethnicity_Id");
            entity.Property(e => e.HippaConsent).HasColumnName("Hippa_Consent");
            entity.Property(e => e.HippaConsentDate)
                .HasColumnType("datetime")
                .HasColumnName("Hippa_Consent_Date");
            entity.Property(e => e.IsEmployed).HasColumnName("Is_Employed");
            entity.Property(e => e.IsStudent).HasColumnName("Is_Student");
            entity.Property(e => e.MedicareSecondaryId).HasColumnName("Medicare_Secondary_Id");
            entity.Property(e => e.MedicareSecondaryNotes)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Medicare_Secondary_Notes");
            entity.Property(e => e.Npp).HasColumnName("NPP");
            entity.Property(e => e.NppDate)
                .HasColumnType("datetime")
                .HasColumnName("NPP_Date");
            entity.Property(e => e.OrganizationId).HasColumnName("Organization_Id");
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
            entity.Property(e => e.PreferredContactFirstId).HasColumnName("Preferred_Contact_First_Id");
            entity.Property(e => e.PreferredContactNotes)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Preferred_Contact_Notes");
            entity.Property(e => e.PreferredContactSecondId).HasColumnName("Preferred_Contact_Second_Id");
            entity.Property(e => e.PreferredContactThirdId).HasColumnName("Preferred_Contact_Third_Id");
            entity.Property(e => e.PreferredDoNotContact).HasColumnName("Preferred_Do_Not_Contact");
            entity.Property(e => e.PreferredLangaugeId).HasColumnName("Preferred_Langauge_Id");
            entity.Property(e => e.RaceId).HasColumnName("Race_Id");
        });

        modelBuilder.Entity<DmgPatientAddress>(entity =>
        {
            entity.HasKey(e => e.PatientAddressId);

            entity.ToTable("DMG_PATIENT_ADDRESS");

            entity.Property(e => e.PatientAddressId).HasColumnName("Patient_Address_Id");
            entity.Property(e => e.Address1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Address_1");
            entity.Property(e => e.Address2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Address_2");
            entity.Property(e => e.AptSte)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CellPhone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Cell_Phone");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CountryId).HasColumnName("Country_Id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Extension)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Fax)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.HomePhone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Home_Phone");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.IsAlternateAddress).HasColumnName("Is_Alternate_Address");
            entity.Property(e => e.IsEmergencyContactAddress).HasColumnName("Is_Emergency_Contact_Address");
            entity.Property(e => e.IsPreferred).HasColumnName("Is_Preferred");
            entity.Property(e => e.IsPrimary).HasColumnName("Is_Primary");
            entity.Property(e => e.Notes)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
            entity.Property(e => e.PreferredContact)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Preferred_Contact");
            entity.Property(e => e.StateId).HasColumnName("State_Id");
            entity.Property(e => e.WorkPhone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Work_Phone");
            entity.Property(e => e.Zip)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ZipExt)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DmgPatientAlert>(entity =>
        {
            entity.HasKey(e => e.AlertId);

            entity.ToTable("DMG_PATIENT_ALERTS");

            entity.Property(e => e.AlertId).HasColumnName("Alert_Id");
            entity.Property(e => e.AlertCreatedBy).HasColumnName("Alert_Created_By");
            entity.Property(e => e.AlertCreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Alert_Created_Date");
            entity.Property(e => e.AlertExpiryDate)
                .HasColumnType("datetime")
                .HasColumnName("Alert_Expiry_Date");
            entity.Property(e => e.AlertFlash).HasColumnName("Alert_flash");
            entity.Property(e => e.AlertMessage)
                .IsUnicode(false)
                .HasColumnName("Alert_Message");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
            entity.Property(e => e.PriorityId).HasColumnName("Priority_Id");
        });

        modelBuilder.Entity<DmgPatientConsentDetail>(entity =>
        {
            entity.ToTable("DMG_PATIENT_CONSENT_DETAILS");

            entity.Property(e => e.ConsentMarkDown).HasColumnName("Consent_Mark_Down");
            entity.Property(e => e.FormId).HasColumnName("Form_Id");
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
            entity.Property(e => e.RecordAddedDatetime)
                .HasColumnType("datetime")
                .HasColumnName("Record_Added_Datetime");
        });

        modelBuilder.Entity<DmgPatientFormsImagesDetail>(entity =>
        {
            entity.ToTable("DMG_PATIENT_FORMS_IMAGES_DETAILS");

            entity.Property(e => e.DriversLicensePath)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Drivers_License_Path");
            entity.Property(e => e.MedicalInsurance1PdfPath)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Medical_Insurance_1_PDF_Path");
            entity.Property(e => e.MedicalInsurance2PdfPath)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Medical_Insurance_2_PDF_Path");
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
            entity.Property(e => e.RecordAddedDatetime)
                .HasColumnType("datetime")
                .HasColumnName("Record_Added_Datetime");
            entity.Property(e => e.VisionInsurance1PdfPath)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Vision_Insurance_1_PDF_Path");
        });

        modelBuilder.Entity<DmgPatientHippaReleaseContactDetail>(entity =>
        {
            entity.ToTable("DMG_PATIENT_HIPPA_RELEASE_CONTACT_DETAILS");

            entity.Property(e => e.Contact1FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Contact_1_First_Name");
            entity.Property(e => e.Contact1LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Contact_1_Last_Name");
            entity.Property(e => e.Contact1PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Contact_1_Phone_Number");
            entity.Property(e => e.Contact2FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Contact_2_First_Name");
            entity.Property(e => e.Contact2LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Contact_2_Last_Name");
            entity.Property(e => e.Contact2PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Contact_2_Phone_Number");
            entity.Property(e => e.Contact3FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Contact_3_First_Name");
            entity.Property(e => e.Contact3LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Contact_3_Last_Name");
            entity.Property(e => e.Contact3PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Contact_3_Phone_Number");
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
        });

        modelBuilder.Entity<DmgPatientInsurance>(entity =>
        {
            entity.HasKey(e => e.PatientInsuranceId);

            entity.ToTable("DMG_PATIENT_INSURANCE");

            entity.HasIndex(e => new { e.PatientId, e.InsuranceCompanyId }, "PatientIdAndInsuranceCompanyIdIndex");

            entity.HasIndex(e => e.PatientId, "PatientIdIndex");

            entity.HasIndex(e => new { e.PatientId, e.IsActive }, "PatinetIdAndActiveIndex");

            entity.Property(e => e.PatientInsuranceId).HasColumnName("Patient_Insurance_Id");
            entity.Property(e => e.AddedTime).HasColumnType("datetime");
            entity.Property(e => e.AssignmentOfBenefits).HasColumnName("Assignment_of_Benefits");
            entity.Property(e => e.AssignmentOfBenefitsDate)
                .HasColumnType("datetime")
                .HasColumnName("Assignment_of_Benefits_Date");
            entity.Property(e => e.Copay).HasColumnType("numeric(7, 2)");
            entity.Property(e => e.Deductible).HasColumnType("numeric(7, 2)");
            entity.Property(e => e.GroupId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Group_Id");
            entity.Property(e => e.InsuranceCompanyId).HasColumnName("Insurance_Company_Id");
            entity.Property(e => e.InsurancePolicyType).HasColumnName("Insurance_Policy_Type");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.IsAdditionalInsurance).HasColumnName("Is_Additional_Insurance");
            entity.Property(e => e.IsMedicalInsurance).HasColumnName("Is_Medical_Insurance");
            entity.Property(e => e.IsSubscriberExistingPatient).HasColumnName("Is_Subscriber_Existing_Patient");
            entity.Property(e => e.IsVerified).HasColumnName("Is_Verified");
            entity.Property(e => e.IsVisionInsurance).HasColumnName("Is_Vision_Insurance");
            entity.Property(e => e.OldRecord)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Old_Record");
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
            entity.Property(e => e.PlanId).HasColumnName("Plan_Id");
            entity.Property(e => e.PolicyNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Policy_Number");
            entity.Property(e => e.RelationId).HasColumnName("Relation_Id");
            entity.Property(e => e.RemovedTime).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.SubscriberId).HasColumnName("Subscriber_Id");
            entity.Property(e => e.VerificationDate)
                .HasColumnType("datetime")
                .HasColumnName("Verification_Date");
        });

        modelBuilder.Entity<DmgPatientMedicalHistoryDetail>(entity =>
        {
            entity.ToTable("DMG_PATIENT_MEDICAL_HISTORY_DETAILS");

            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
            entity.Property(e => e.PehHaveCataract)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PEH_Have_Cataract");
            entity.Property(e => e.PehHaveGlaucoma)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PEH_Have_Glaucoma");
            entity.Property(e => e.PehHaveInfections)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PEH_Have_Infections");
            entity.Property(e => e.PehHaveLazyEye)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PEH_Have_Lazy_Eye");
            entity.Property(e => e.PehHaveMuscleProblems)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PEH_Have_Muscle_Problems");
            entity.Property(e => e.PehHaveNoSignificantEyeHistory)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PEH_Have_No_Significant_Eye_History");
            entity.Property(e => e.PehHaveOtherPastEyeHistory)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PEH_Have_Other_Past_Eye_History");
            entity.Property(e => e.PehHaveRetinalDetachment)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PEH_Have_Retinal_Detachment");
            entity.Property(e => e.PehHaveTrauma)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PEH_Have_Trauma");
            entity.Property(e => e.PehOtherPastEyeHistoryDescription)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("PEH_Other_Past_Eye_History_Description");
            entity.Property(e => e.PesHaveCataracts)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PES_Have_Cataracts");
            entity.Property(e => e.PesHaveEyelidSurgery)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PES_Have_Eyelid_Surgery");
            entity.Property(e => e.PesHaveGlaucoma)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PES_Have_Glaucoma");
            entity.Property(e => e.PesHaveMuscleSurgery)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PES_Have_Muscle_Surgery");
            entity.Property(e => e.PesHaveNoSignificantEyeSurgery)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PES_Have_No_Significant_Eye_Surgery");
            entity.Property(e => e.PesHaveOtherPastEyeSurgery)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PES_Have_Other_Past_Eye_Surgery");
            entity.Property(e => e.PesHaveRefractiveSurgery)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PES_Have_Refractive_Surgery");
            entity.Property(e => e.PesHaveRetinalSurgery)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PES_Have_Retinal_Surgery");
            entity.Property(e => e.PesOtherPastEyeSurgeryDescription)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("PES_Other_Past_Eye_Surgery_Description");
            entity.Property(e => e.PmhHaveCancer)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PMH_Have_Cancer");
            entity.Property(e => e.PmhHaveDiabetes)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PMH_Have_Diabetes");
            entity.Property(e => e.PmhHaveHeartProblems)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PMH_Have_Heart_Problems");
            entity.Property(e => e.PmhHaveHighBloodPressure)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PMH_Have_High_Blood_Pressure");
            entity.Property(e => e.PmhHaveLungProblems)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PMH_Have_Lung_Problems");
            entity.Property(e => e.PmhHaveNeurological)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PMH_Have_Neurological");
            entity.Property(e => e.PmhHaveNoSignificantMedicalHistory)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PMH_Have_No_Significant_Medical_History");
            entity.Property(e => e.PmhHaveOtherPastMedical)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PMH_Have_Other_Past_Medical");
            entity.Property(e => e.PmhHaveStroke)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PMH_Have_Stroke");
            entity.Property(e => e.PmhHaveThyroid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PMH_Have_Thyroid");
            entity.Property(e => e.PmhOtherPastMedicalDescription)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("PMH_Other_Past_Medical_Description");
            entity.Property(e => e.PsHaveBrainSurgery)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PS_Have_Brain_Surgery");
            entity.Property(e => e.PsHaveCancerSurgery)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PS_Have_Cancer_Surgery");
            entity.Property(e => e.PsHaveHeartBloodVesselSurgery)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PS_Have_Heart_Blood_Vessel_Surgery");
            entity.Property(e => e.PsHaveJointOrthoSurgery)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PS_Have_Joint_Ortho_Surgery");
            entity.Property(e => e.PsHaveNoSignificantSurgeries)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PS_Have_No_Significant_Surgeries");
            entity.Property(e => e.PsHaveOtherPastSurgery)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PS_Have_Other_Past_Surgery");
            entity.Property(e => e.PsOtherPastSurgeryDescription)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("PS_Other_Past_Surgery_Description");
            entity.Property(e => e.RecordAddedDatetime)
                .HasColumnType("datetime")
                .HasColumnName("Record_Added_Datetime");
            entity.Property(e => e.RecordUpdatedDatetime)
                .HasColumnType("datetime")
                .HasColumnName("Record_Updated_Datetime");
        });

        modelBuilder.Entity<DmgPatientRelatedPatient>(entity =>
        {
            entity.HasKey(e => e.PatientRelationId);

            entity.ToTable("DMG_PATIENT_RELATED_PATIENTS");

            entity.Property(e => e.PatientRelationId).HasColumnName("Patient_Relation_Id");
            entity.Property(e => e.AddedBy).HasColumnName("Added_By");
            entity.Property(e => e.AddedDate)
                .HasColumnType("datetime")
                .HasColumnName("Added_Date");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
            entity.Property(e => e.RelationId).HasColumnName("Relation_Id");
            entity.Property(e => e.SecondaryPatientId).HasColumnName("Secondary_Patient_Id");
        });

        modelBuilder.Entity<DmgPatientRemark>(entity =>
        {
            entity.HasKey(e => e.RemarkId);

            entity.ToTable("DMG_PATIENT_REMARKS");

            entity.Property(e => e.RemarkId).HasColumnName("Remark_Id");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.LastUpdated)
                .HasColumnType("datetime")
                .HasColumnName("Last_Updated");
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
            entity.Property(e => e.Remarks).IsUnicode(false);
        });

        modelBuilder.Entity<DmgPatientRosDetail>(entity =>
        {
            entity.ToTable("DMG_PATIENT_ROS_DETAILS");

            entity.Property(e => e.HaveAllergicConditions)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Have_Allergic_Conditions");
            entity.Property(e => e.HaveBloodLymphSystemIssues)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Have_Blood_Lymph_System_Issues");
            entity.Property(e => e.HaveCardiovascularIssues)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Have_Cardiovascular_Issues");
            entity.Property(e => e.HaveDiabetesThyroidIssues)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Have_Diabetes_Thyroid_Issues");
            entity.Property(e => e.HaveEntIssues)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Have_ENT_Issues");
            entity.Property(e => e.HaveGastrointestinalIssues)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Have_Gastrointestinal_Issues");
            entity.Property(e => e.HaveGenitoUrinaryIssues)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Have_Genito_Urinary_Issues");
            entity.Property(e => e.HaveMusculoskeletalIssues)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Have_Musculoskeletal_Issues");
            entity.Property(e => e.HaveNeurologicalIssues)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Have_Neurological_Issues");
            entity.Property(e => e.HaveRespiratoryIssues)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Have_Respiratory_Issues");
            entity.Property(e => e.HaveSkinIssues)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Have_Skin_Issues");
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
            entity.Property(e => e.RecordAddedDatetime)
                .HasColumnType("datetime")
                .HasColumnName("Record_Added_Datetime");
            entity.Property(e => e.RecordUpdatedDatetime)
                .HasColumnType("datetime")
                .HasColumnName("Record_Updated_Datetime");
        });

        modelBuilder.Entity<DmgPatientStatementInformation>(entity =>
        {
            entity.HasKey(e => e.PatientStatementId).HasName("PK_PATIENT_STATEMENT_INFORMATION");

            entity.ToTable("DMG_PATIENT_STATEMENT_INFORMATION");

            entity.Property(e => e.PatientStatementId).HasColumnName("Patient_Statement_ID");
            entity.Property(e => e.InvalidStatement).HasColumnName("Invalid_Statement");
            entity.Property(e => e.InvalidStatementMessage)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("Invalid_Statement_Message");
            entity.Property(e => e.PatientId).HasColumnName("Patient_ID");
            entity.Property(e => e.StatementDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Statement_Date_Time");
            entity.Property(e => e.StatementFilePath)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Statement_File_Path");
        });

        modelBuilder.Entity<DmgProvider>(entity =>
        {
            entity.HasKey(e => e.ProviderId);

            entity.ToTable("DMG_PROVIDER");

            entity.Property(e => e.ProviderId).HasColumnName("Provider_Id");
            entity.Property(e => e.AlternateTaxonomy10Id).HasColumnName("Alternate_Taxonomy_10_Id");
            entity.Property(e => e.AlternateTaxonomy11Id).HasColumnName("Alternate_Taxonomy_11_Id");
            entity.Property(e => e.AlternateTaxonomy12Id).HasColumnName("Alternate_Taxonomy_12_Id");
            entity.Property(e => e.AlternateTaxonomy13Id).HasColumnName("Alternate_Taxonomy_13_Id");
            entity.Property(e => e.AlternateTaxonomy14Id).HasColumnName("Alternate_Taxonomy_14_Id");
            entity.Property(e => e.AlternateTaxonomy15Id).HasColumnName("Alternate_Taxonomy_15_Id");
            entity.Property(e => e.AlternateTaxonomy16Id).HasColumnName("Alternate_Taxonomy_16_Id");
            entity.Property(e => e.AlternateTaxonomy17Id).HasColumnName("Alternate_Taxonomy_17_Id");
            entity.Property(e => e.AlternateTaxonomy18Id).HasColumnName("Alternate_Taxonomy_18_Id");
            entity.Property(e => e.AlternateTaxonomy19Id).HasColumnName("Alternate_Taxonomy_19_Id");
            entity.Property(e => e.AlternateTaxonomy1Id).HasColumnName("Alternate_Taxonomy_1_Id");
            entity.Property(e => e.AlternateTaxonomy20Id).HasColumnName("Alternate_Taxonomy_20_Id");
            entity.Property(e => e.AlternateTaxonomy2Id).HasColumnName("Alternate_Taxonomy_2_Id");
            entity.Property(e => e.AlternateTaxonomy3Id).HasColumnName("Alternate_Taxonomy_3_Id");
            entity.Property(e => e.AlternateTaxonomy4Id).HasColumnName("Alternate_Taxonomy_4_Id");
            entity.Property(e => e.AlternateTaxonomy5Id).HasColumnName("Alternate_Taxonomy_5_Id");
            entity.Property(e => e.AlternateTaxonomy6Id).HasColumnName("Alternate_Taxonomy_6_Id");
            entity.Property(e => e.AlternateTaxonomy7Id).HasColumnName("Alternate_Taxonomy_7_Id");
            entity.Property(e => e.AlternateTaxonomy8Id).HasColumnName("Alternate_Taxonomy_8_Id");
            entity.Property(e => e.AlternateTaxonomy9Id).HasColumnName("Alternate_Taxonomy_9_Id");
            entity.Property(e => e.ClExpiration).HasColumnName("CL_Expiration");
            entity.Property(e => e.ClExpirationTypeId).HasColumnName("CL_Expiration_Type_ID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.GroupId).HasColumnName("Group_Id");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.IsReferringProvider).HasColumnName("Is_Referring_Provider");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.LicenseIssuingCountryId).HasColumnName("License_Issuing_Country_Id");
            entity.Property(e => e.LicenseIssuingStateId).HasColumnName("License_Issuing_State_Id");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Middle_Name");
            entity.Property(e => e.PrimaryTaxonomyId).HasColumnName("Primary_Taxonomy_Id");
            entity.Property(e => e.ProviderAddressId).HasColumnName("Provider_Address_Id");
            entity.Property(e => e.ProviderCode)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Provider_Code");
            entity.Property(e => e.ProviderDeaNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Provider_DEA_Number");
            entity.Property(e => e.ProviderDob)
                .HasColumnType("datetime")
                .HasColumnName("Provider_DOB");
            entity.Property(e => e.ProviderEin)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Provider_EIN");
            entity.Property(e => e.ProviderExternalPmCode)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Provider_External_PM_Code");
            entity.Property(e => e.ProviderLicenseNo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Provider_License_No");
            entity.Property(e => e.ProviderMedicaidNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Provider_Medicaid_Number");
            entity.Property(e => e.ProviderNpi)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Provider_NPI");
            entity.Property(e => e.ProviderSpecialityId).HasColumnName("Provider_Speciality_Id");
            entity.Property(e => e.ProviderSsn)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Provider_SSN");
            entity.Property(e => e.ProviderUpin)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Provider_UPIN");
            entity.Property(e => e.ProviderUserId).HasColumnName("Provider_User_Id");
            entity.Property(e => e.SignatureUrl)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("Signature_URL");
            entity.Property(e => e.SpectacleExpiration).HasColumnName("Spectacle_Expiration");
            entity.Property(e => e.SpectacleExpirationTypeId).HasColumnName("Spectacle_Expiration_Type_ID");
            entity.Property(e => e.SuffixId).HasColumnName("Suffix_Id");
            entity.Property(e => e.TitleId).HasColumnName("Title_Id");
        });

        modelBuilder.Entity<DmgProvider2>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DMG_PROVIDER2");

            entity.Property(e => e.AlternateTaxonomy10Id).HasColumnName("Alternate_Taxonomy_10_Id");
            entity.Property(e => e.AlternateTaxonomy11Id).HasColumnName("Alternate_Taxonomy_11_Id");
            entity.Property(e => e.AlternateTaxonomy12Id).HasColumnName("Alternate_Taxonomy_12_Id");
            entity.Property(e => e.AlternateTaxonomy13Id).HasColumnName("Alternate_Taxonomy_13_Id");
            entity.Property(e => e.AlternateTaxonomy14Id).HasColumnName("Alternate_Taxonomy_14_Id");
            entity.Property(e => e.AlternateTaxonomy15Id).HasColumnName("Alternate_Taxonomy_15_Id");
            entity.Property(e => e.AlternateTaxonomy16Id).HasColumnName("Alternate_Taxonomy_16_Id");
            entity.Property(e => e.AlternateTaxonomy17Id).HasColumnName("Alternate_Taxonomy_17_Id");
            entity.Property(e => e.AlternateTaxonomy18Id).HasColumnName("Alternate_Taxonomy_18_Id");
            entity.Property(e => e.AlternateTaxonomy19Id).HasColumnName("Alternate_Taxonomy_19_Id");
            entity.Property(e => e.AlternateTaxonomy1Id).HasColumnName("Alternate_Taxonomy_1_Id");
            entity.Property(e => e.AlternateTaxonomy20Id).HasColumnName("Alternate_Taxonomy_20_Id");
            entity.Property(e => e.AlternateTaxonomy2Id).HasColumnName("Alternate_Taxonomy_2_Id");
            entity.Property(e => e.AlternateTaxonomy3Id).HasColumnName("Alternate_Taxonomy_3_Id");
            entity.Property(e => e.AlternateTaxonomy4Id).HasColumnName("Alternate_Taxonomy_4_Id");
            entity.Property(e => e.AlternateTaxonomy5Id).HasColumnName("Alternate_Taxonomy_5_Id");
            entity.Property(e => e.AlternateTaxonomy6Id).HasColumnName("Alternate_Taxonomy_6_Id");
            entity.Property(e => e.AlternateTaxonomy7Id).HasColumnName("Alternate_Taxonomy_7_Id");
            entity.Property(e => e.AlternateTaxonomy8Id).HasColumnName("Alternate_Taxonomy_8_Id");
            entity.Property(e => e.AlternateTaxonomy9Id).HasColumnName("Alternate_Taxonomy_9_Id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.GroupId).HasColumnName("Group_Id");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.IsReferringProvider).HasColumnName("Is_Referring_Provider");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.LicenseIssuingCountryId).HasColumnName("License_Issuing_Country_Id");
            entity.Property(e => e.LicenseIssuingStateId).HasColumnName("License_Issuing_State_Id");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Middle_Name");
            entity.Property(e => e.PrimaryTaxonomyId).HasColumnName("Primary_Taxonomy_Id");
            entity.Property(e => e.ProviderAddressId).HasColumnName("Provider_Address_Id");
            entity.Property(e => e.ProviderCode)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Provider_Code");
            entity.Property(e => e.ProviderDeaNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Provider_DEA_Number");
            entity.Property(e => e.ProviderDob)
                .HasColumnType("datetime")
                .HasColumnName("Provider_DOB");
            entity.Property(e => e.ProviderEin)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Provider_EIN");
            entity.Property(e => e.ProviderExternalPmCode)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Provider_External_PM_Code");
            entity.Property(e => e.ProviderId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Provider_Id");
            entity.Property(e => e.ProviderLicenseNo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Provider_License_No");
            entity.Property(e => e.ProviderMedicaidNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Provider_Medicaid_Number");
            entity.Property(e => e.ProviderNpi)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Provider_NPI");
            entity.Property(e => e.ProviderSpecialityId).HasColumnName("Provider_Speciality_Id");
            entity.Property(e => e.ProviderSsn)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Provider_SSN");
            entity.Property(e => e.ProviderUpin)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Provider_UPIN");
            entity.Property(e => e.ProviderUserId).HasColumnName("Provider_User_Id");
            entity.Property(e => e.SuffixId).HasColumnName("Suffix_Id");
            entity.Property(e => e.TitleId).HasColumnName("Title_Id");
        });

        modelBuilder.Entity<DmgProviderExtra>(entity =>
        {
            entity.HasKey(e => e.ProviderExtraId);

            entity.ToTable("DMG_PROVIDER_EXTRA");

            entity.Property(e => e.ProviderExtraId).HasColumnName("Provider_Extra_ID");
            entity.Property(e => e.ProviderId).HasColumnName("Provider_Id");
            entity.Property(e => e.ProviderNpi)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Provider_NPI");
        });

        modelBuilder.Entity<DmgSubscriber>(entity =>
        {
            entity.HasKey(e => e.SubscriberId);

            entity.ToTable("DMG_SUBSCRIBER");

            entity.Property(e => e.SubscriberId).HasColumnName("Subscriber_Id");
            entity.Property(e => e.AddedDate)
                .HasColumnType("datetime")
                .HasColumnName("Added_Date");
            entity.Property(e => e.AddressId).HasColumnName("Address_Id");
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("DOB");
            entity.Property(e => e.EmploymentStatusId).HasColumnName("Employment_Status_Id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.GenderId).HasColumnName("Gender_Id");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.LastModifiedBy).HasColumnName("Last_Modified_By");
            entity.Property(e => e.LastModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Modified_Date");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Middle_Name");
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
            entity.Property(e => e.RelationshipId).HasColumnName("Relationship_Id");
            entity.Property(e => e.RemovedDate)
                .HasColumnType("datetime")
                .HasColumnName("Removed_Date");
            entity.Property(e => e.Ssn)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SSN");
            entity.Property(e => e.SuffixId).HasColumnName("Suffix_Id");
            entity.Property(e => e.TitleId).HasColumnName("Title_Id");
        });

        modelBuilder.Entity<DmgTransactionHistory>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK_DMG_Transaction_History");

            entity.ToTable("DMG_TRANSACTION_HISTORY");

            entity.HasIndex(e => new { e.PatientId, e.OrderId, e.SecondaryActorId }, "NonClusteredIndex-20171030-144533");

            entity.Property(e => e.TransactionId).HasColumnName("Transaction_Id");
            entity.Property(e => e.Notes)
                .HasMaxLength(1500)
                .IsUnicode(false);
            entity.Property(e => e.OrderId).HasColumnName("Order_Id");
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
            entity.Property(e => e.SecondaryActorId).HasColumnName("Secondary_Actor_Id");
            entity.Property(e => e.StaffId).HasColumnName("Staff_Id");
            entity.Property(e => e.TransactionDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Transaction_DateTime");
            entity.Property(e => e.TransactionDetails)
                .HasMaxLength(1500)
                .IsUnicode(false)
                .HasColumnName("Transaction_Details");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Transaction_Type");
        });

        modelBuilder.Entity<Dupframe>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("dupframes");

            entity.Property(e => e.A).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.AgeGroupId).HasColumnName("AgeGroupID");
            entity.Property(e => e.B).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.BrandId).HasColumnName("BrandID");
            entity.Property(e => e.Circumference).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.CollectionId).HasColumnName("CollectionID");
            entity.Property(e => e.CompletePrice).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.Cptid).HasColumnName("CPTID");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.Dbl)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("DBL");
            entity.Property(e => e.Ed)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("ED");
            entity.Property(e => e.Edangle)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("EDAngle");
            entity.Property(e => e.Fpc)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("FPC");
            entity.Property(e => e.FrameCategoryId).HasColumnName("FrameCategoryID");
            entity.Property(e => e.FrameColorId).HasColumnName("FrameColorID");
            entity.Property(e => e.FrameId)
                .ValueGeneratedOnAdd()
                .HasColumnName("FrameID");
            entity.Property(e => e.FrameMountId).HasColumnName("FrameMountID");
            entity.Property(e => e.FrameShapeId).HasColumnName("FrameShapeID");
            entity.Property(e => e.FrontPrice).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.GenderId).HasColumnName("GenderID");
            entity.Property(e => e.HalfTemplesPrice).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.LastUpdated).HasColumnType("datetime");
            entity.Property(e => e.LensColorId).HasColumnName("LensColorID");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");
            entity.Property(e => e.MaterialId).HasColumnName("MaterialID");
            entity.Property(e => e.Sku)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("SKU");
            entity.Property(e => e.StyleId).HasColumnName("StyleID");
            entity.Property(e => e.StyleName)
                .HasMaxLength(37)
                .IsUnicode(false);
            entity.Property(e => e.TemplesPrice).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.Upc)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("UPC");
            entity.Property(e => e.VendorId).HasColumnName("VendorID");
            entity.Property(e => e.YearIntroduced)
                .HasMaxLength(4)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ecp1GetAppointmentAndRecallTypesView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ECP_1_GET_APPOINTMENT_AND_RECALL_TYPES_VIEW");

            entity.Property(e => e.AppointmentTypeCode)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Appointment_Type_Code");
            entity.Property(e => e.AppointmentTypeDescription)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Appointment_Type_Description");
            entity.Property(e => e.AppointmentTypeId).HasColumnName("Appointment_Type_ID");
            entity.Property(e => e.CanSchedule).HasColumnName("Can_Schedule");
            entity.Property(e => e.DefaultAppointmentType).HasColumnName("Default_Appointment_Type");
            entity.Property(e => e.DefaultDuration).HasColumnName("Default_Duration");
            entity.Property(e => e.IsAppointmentType).HasColumnName("Is_Appointment_Type");
            entity.Property(e => e.IsExamType).HasColumnName("Is_Exam_Type");
            entity.Property(e => e.IsGroup)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.IsRecallType).HasColumnName("Is_Recall_Type");
            entity.Property(e => e.PatientRequired).HasColumnName("Patient_Required");
            entity.Property(e => e.StaffLocationId).HasColumnName("Staff_Location_ID");
            entity.Property(e => e.StaffLocationName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Staff_Location_Name");
            entity.Property(e => e.WebSchedulingType).HasColumnName("Web_Scheduling_Type");
        });

        modelBuilder.Entity<Ecp1GetAppointmentsByRulesView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ECP_1_GET_APPOINTMENTS_BY_RULES_VIEW");

            entity.Property(e => e.AppointmentDescription)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Appointment_Description");
            entity.Property(e => e.AppointmentSubject)
                .HasMaxLength(212)
                .IsUnicode(false)
                .HasColumnName("Appointment_Subject");
            entity.Property(e => e.AppointmentType)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Appointment_Type");
            entity.Property(e => e.AppointmentTypeId).HasColumnName("Appointment_Type_ID");
            entity.Property(e => e.CanSchedule).HasColumnName("Can_Schedule");
            entity.Property(e => e.DefaultAppointmentType).HasColumnName("Default_Appointment_Type");
            entity.Property(e => e.EndTime)
                .HasColumnType("datetime")
                .HasColumnName("End_Time");
            entity.Property(e => e.IsExamType).HasColumnName("Is_Exam_Type");
            entity.Property(e => e.IsGroup)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("Is_Group");
            entity.Property(e => e.PatientRequired).HasColumnName("Patient_Required");
            entity.Property(e => e.Resource)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ResourceId).HasColumnName("Resource_ID");
            entity.Property(e => e.RuleId).HasColumnName("Rule_ID");
            entity.Property(e => e.RuleName)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Rule_Name");
            entity.Property(e => e.SchedulingLocation)
                .HasMaxLength(553)
                .IsUnicode(false)
                .HasColumnName("Scheduling_Location");
            entity.Property(e => e.SchedulingLocationId).HasColumnName("Scheduling_Location_ID");
            entity.Property(e => e.StaffLocationId).HasColumnName("Staff_Location_ID");
            entity.Property(e => e.StaffLocationName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Staff_Location_Name");
            entity.Property(e => e.StartTime)
                .HasColumnType("datetime")
                .HasColumnName("Start_Time");
            entity.Property(e => e.WebSchedule).HasColumnName("Web_Schedule");
        });

        modelBuilder.Entity<Ecp1GetAppointmentsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ECP_1_GET_APPOINTMENTS_VIEW");

            entity.Property(e => e.AppointmentConfirmed).HasColumnName("Appointment_Confirmed");
            entity.Property(e => e.AppointmentCreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Appointment_Created_Date");
            entity.Property(e => e.AppointmentDate).HasColumnName("Appointment_Date");
            entity.Property(e => e.AppointmentId).HasColumnName("Appointment_ID");
            entity.Property(e => e.AppointmentLength).HasColumnName("Appointment_Length");
            entity.Property(e => e.AppointmentLocation)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Appointment_Location");
            entity.Property(e => e.AppointmentModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("Appointment_Modified_Date");
            entity.Property(e => e.AppointmentProvider)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Appointment_Provider");
            entity.Property(e => e.AppointmentReason)
                .HasMaxLength(2000)
                .HasColumnName("Appointment_Reason");
            entity.Property(e => e.AppointmentStatus)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("Appointment_Status");
            entity.Property(e => e.AppointmentTime).HasColumnName("Appointment_Time");
            entity.Property(e => e.AppointmentType)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Appointment_Type");
            entity.Property(e => e.AppointmentTypeId).HasColumnName("Appointment_Type_ID");
            entity.Property(e => e.EyecareproAppointmentKey).HasColumnName("EYECAREPRO_APPOINTMENT_KEY");
            entity.Property(e => e.IsNoShow).HasColumnName("Is_No_Show");
            entity.Property(e => e.PatientId).HasColumnName("Patient_ID");
            entity.Property(e => e.PatientShowedUp).HasColumnName("Patient_Showed_Up");
            entity.Property(e => e.PriorAppointmentId).HasColumnName("Prior_Appointment_ID");
            entity.Property(e => e.ResourceId).HasColumnName("Resource_ID");
            entity.Property(e => e.SchedulingLocationId).HasColumnName("Scheduling_Location_ID");
            entity.Property(e => e.StaffLocationId).HasColumnName("Staff_Location_ID");
        });

        modelBuilder.Entity<Ecp1GetLocationsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ECP_1_GET_LOCATIONS_VIEW");

            entity.Property(e => e.IsSchedulingLocation).HasColumnName("Is_Scheduling_Location");
            entity.Property(e => e.SchedulingLocationCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Scheduling_Location_Code");
            entity.Property(e => e.SchedulingLocationId).HasColumnName("Scheduling_Location_ID");
            entity.Property(e => e.SchedulingLocationName)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Scheduling_Location_Name");
            entity.Property(e => e.StaffLocationActive).HasColumnName("Staff_Location_Active");
            entity.Property(e => e.StaffLocationId).HasColumnName("Staff_Location_ID");
            entity.Property(e => e.StaffLocationName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Staff_Location_Name");
        });

        modelBuilder.Entity<Ecp1GetOrderStatusView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ECP_1_GET_ORDER_STATUS_VIEW");

            entity.Property(e => e.IsDefaultStatus).HasColumnName("Is_Default_Status");
            entity.Property(e => e.ProductPickUpXrefStatusType)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("Product_PickUP_XREF_Status_Type");
            entity.Property(e => e.Status)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.StatusId).HasColumnName("Status_Id");
        });

        modelBuilder.Entity<Ecp1GetPatientInsuranceView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ECP_1_GET_PATIENT_INSURANCE_VIEW");

            entity.Property(e => e.InsCompanyCode)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Code");
            entity.Property(e => e.InsCompanyName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Name");
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
            entity.Property(e => e.PatientInsuranceId).HasColumnName("Patient_Insurance_Id");
        });

        modelBuilder.Entity<Ecp1GetPatientProvidersView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ECP_1_GET_PATIENT_PROVIDERS_VIEW");

            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.IsReferringProvider).HasColumnName("Is_Referring_Provider");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Middle_Name");
            entity.Property(e => e.PatientProviderId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Patient_Provider_ID");
            entity.Property(e => e.ProviderCode)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Provider_Code");
        });

        modelBuilder.Entity<Ecp1GetPatientsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ECP_1_GET_PATIENTS_VIEW");

            entity.Property(e => e.AccountNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Account_Number");
            entity.Property(e => e.Address1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ADDRESS_1");
            entity.Property(e => e.Address2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ADDRESS_2");
            entity.Property(e => e.CellPhone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Cell_Phone");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DoNotContactAutomatedPhone).HasColumnName("Do_Not_Contact_Automated_Phone");
            entity.Property(e => e.DoNotContactEmail).HasColumnName("Do_Not_Contact_Email");
            entity.Property(e => e.DoNotContactHumanPhone).HasColumnName("Do_Not_Contact_Human_Phone");
            entity.Property(e => e.DoNotContactPostal).HasColumnName("Do_Not_Contact_Postal");
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HomePhone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Home_Phone");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.IsDeceased).HasColumnName("Is_Deceased");
            entity.Property(e => e.Language)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastExamAppointmentTypeId).HasColumnName("Last_Exam_Appointment_Type_Id");
            entity.Property(e => e.LastExamBillingLocationId).HasColumnName("Last_Exam_Billing_Location_Id");
            entity.Property(e => e.LastExamResourceId).HasColumnName("Last_Exam_Resource_Id");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Middle_Name");
            entity.Property(e => e.PatientCommunicationPreference1)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Patient_Communication_Preference1");
            entity.Property(e => e.PatientCommunicationPreference2)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Patient_Communication_Preference2");
            entity.Property(e => e.PatientCommunicationPreference3)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Patient_Communication_Preference3");
            entity.Property(e => e.PatientCreateDate)
                .HasColumnType("datetime")
                .HasColumnName("Patient_Create_Date");
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
            entity.Property(e => e.PatientLastExamDate).HasColumnName("Patient_Last_Exam_Date");
            entity.Property(e => e.PatientLastModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("Patient_Last_Modified_Date");
            entity.Property(e => e.PatientProviderId).HasColumnName("Patient_Provider_ID");
            entity.Property(e => e.PreferredDoNotContact).HasColumnName("Preferred_Do_Not_Contact");
            entity.Property(e => e.Ssn)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SSN");
            entity.Property(e => e.State)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.WorkPhone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Work_Phone");
            entity.Property(e => e.Zip)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ecp1GetProductPickupOrdersView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ECP_1_GET_PRODUCT_PICKUP_ORDERS_VIEW");

            entity.Property(e => e.CancelledDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Cancelled_Date_Time");
            entity.Property(e => e.LastModifiedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Last_Modified_Date_Time");
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.NotifiedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Notified_Date_Time");
            entity.Property(e => e.OrderActive).HasColumnName("Order_Active");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("Order_Date");
            entity.Property(e => e.OrderId).HasColumnName("Order_Id");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Order_Status");
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
            entity.Property(e => e.PatientNotifiedByEcp).HasColumnName("Patient_Notified_By_ECP");
            entity.Property(e => e.PickedUpDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Picked_Up_Date_Time");
            entity.Property(e => e.ProductBrand)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Product_Brand");
            entity.Property(e => e.ProductType)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("Product_Type");
            entity.Property(e => e.ProviderId).HasColumnName("Provider_Id");
            entity.Property(e => e.ReceivedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Received_Date_Time");
            entity.Property(e => e.StaffLocation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Staff_Location");
            entity.Property(e => e.StaffLocationId).HasColumnName("Staff_Location_ID");
            entity.Property(e => e.StatusChangedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Status_Changed_Date_Time");
        });

        modelBuilder.Entity<Ecp1GetProviderAndResourcesView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ECP_1_GET_PROVIDER_AND_RESOURCES_VIEW");

            entity.Property(e => e.ResourceCode)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Resource_Code");
            entity.Property(e => e.ResourceId).HasColumnName("Resource_ID");
            entity.Property(e => e.ResourceName)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Resource_Name");
            entity.Property(e => e.SpecialtyCode)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Specialty_Code");
            entity.Property(e => e.SpecialtyDescription)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Specialty_Description");
            entity.Property(e => e.StaffLocationId).HasColumnName("Staff_Location_ID");
            entity.Property(e => e.StaffLocationName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Staff_Location_Name");
        });

        modelBuilder.Entity<Ecp1GetRecallsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ECP_1_GET_RECALLS_VIEW");

            entity.Property(e => e.AppointmentTypeId).HasColumnName("Appointment_Type_ID");
            entity.Property(e => e.PatientId).HasColumnName("Patient_ID");
            entity.Property(e => e.RecallCreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Recall_Created_Date_Time");
            entity.Property(e => e.RecallDate).HasColumnName("Recall_Date");
            entity.Property(e => e.RecallId).HasColumnName("Recall_ID");
            entity.Property(e => e.RecallLocation)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Recall_Location");
            entity.Property(e => e.RecallModifiedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Recall_Modified_Date_Time");
            entity.Property(e => e.RecallProvider)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Recall_Provider");
            entity.Property(e => e.RecallReason)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Recall_Reason");
            entity.Property(e => e.ResourceId).HasColumnName("Resource_ID");
            entity.Property(e => e.SchedulingLocationId).HasColumnName("Scheduling_Location_ID");
            entity.Property(e => e.StaffLocationId).HasColumnName("Staff_Location_ID");
        });

        modelBuilder.Entity<Ecp1GetSettingsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ECP_1_GET_SETTINGS_VIEW");

            entity.Property(e => e.AppointmentsReminderAndCancellationActive).HasColumnName("Appointments_Reminder_And_Cancellation_Active");
            entity.Property(e => e.AutomaticallyConvertRequestToAppointment).HasColumnName("Automatically_Convert_Request_To_Appointment");
            entity.Property(e => e.ProductPickUpActive).HasColumnName("Product_PickUp_Active");
            entity.Property(e => e.RecallsActive).HasColumnName("Recalls_Active");
            entity.Property(e => e.StaffLocationId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Staff_Location_ID");
            entity.Property(e => e.StaffLocationName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Staff_Location_Name");
            entity.Property(e => e.WebScheduleActive).HasColumnName("Web_Schedule_Active");
        });

        modelBuilder.Entity<Ecp1GetVersionInformationView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ECP_1_GET_VERSION_INFORMATION_VIEW");

            entity.Property(e => e.EcpApplicationLastUpdatedDateTime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ECP_Application_Last_Updated_DateTime");
            entity.Property(e => e.EcpVersionNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ECP_Version_Number");
            entity.Property(e => e.FfpmLastUpdatedDateTime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FFPM_Last_Updated_DateTime");
            entity.Property(e => e.FfpmVersionNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FFPM_Version_Number");
        });

        modelBuilder.Entity<EdiClaimFile>(entity =>
        {
            entity.HasKey(e => e.EdiClaimFileId).HasName("PK_EDI_CLAIMS");

            entity.ToTable("EDI_CLAIM_FILES");

            entity.Property(e => e.EdiClaimFileId).HasColumnName("EDI_CLAIM_FILE_ID");
            entity.Property(e => e.EdiClaim277AcceptedAmt)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("EDI_CLAIM_277_ACCEPTED_AMT");
            entity.Property(e => e.EdiClaim277AcceptedCount).HasColumnName("EDI_CLAIM_277_ACCEPTED_COUNT");
            entity.Property(e => e.EdiClaim277LastUpdated)
                .HasColumnType("datetime")
                .HasColumnName("EDI_CLAIM_277_LAST_UPDATED");
            entity.Property(e => e.EdiClaim277Output)
                .IsUnicode(false)
                .HasColumnName("EDI_CLAIM_277_OUTPUT");
            entity.Property(e => e.EdiClaim277ProcDate)
                .HasColumnType("datetime")
                .HasColumnName("EDI_CLAIM_277_PROC_DATE");
            entity.Property(e => e.EdiClaim277RecDate)
                .HasColumnType("datetime")
                .HasColumnName("EDI_CLAIM_277_REC_DATE");
            entity.Property(e => e.EdiClaim277RejectedAmt)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("EDI_CLAIM_277_REJECTED_AMT");
            entity.Property(e => e.EdiClaim277RejectedCount).HasColumnName("EDI_CLAIM_277_REJECTED_COUNT");
            entity.Property(e => e.EdiClaim277Response)
                .IsUnicode(false)
                .HasColumnName("EDI_CLAIM_277_RESPONSE");
            entity.Property(e => e.EdiClaim999Output)
                .IsUnicode(false)
                .HasColumnName("EDI_CLAIM_999_OUTPUT");
            entity.Property(e => e.EdiClaimBatchNumber)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EDI_CLAIM_BATCH_NUMBER");
            entity.Property(e => e.EdiClaimControlNumber)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("EDI_CLAIM_CONTROL_NUMBER");
            entity.Property(e => e.EdiClaimDateCreated)
                .HasColumnType("datetime")
                .HasColumnName("EDI_CLAIM_DATE_CREATED");
            entity.Property(e => e.EdiClaimFileContent)
                .IsUnicode(false)
                .HasColumnName("EDI_CLAIM_FILE_CONTENT");
            entity.Property(e => e.EdiClaimInterchangeNumber)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("EDI_CLAIM_INTERCHANGE_NUMBER");
            entity.Property(e => e.EdiClaimIsFileRejected).HasColumnName("EDI_CLAIM_IS_FILE_REJECTED");
            entity.Property(e => e.EdiClaimReceiverIdentifier)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EDI_CLAIM_RECEIVER_IDENTIFIER");
            entity.Property(e => e.EdiClaimResponseMessage)
                .IsUnicode(false)
                .HasColumnName("EDI_CLAIM_RESPONSE_MESSAGE");
            entity.Property(e => e.EdiTotalClaimAmount)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EDI_TOTAL_CLAIM_AMOUNT");
            entity.Property(e => e.EdiTotalClaimCount).HasColumnName("EDI_TOTAL_CLAIM_COUNT");
        });

        modelBuilder.Entity<EdiClaimFileTransaction>(entity =>
        {
            entity.HasKey(e => e.EdiClaimFileTransactionId).HasName("PK_EDI_CLAIM_CHARGE_RELATION");

            entity.ToTable("EDI_CLAIM_FILE_TRANSACTIONS");

            entity.Property(e => e.EdiClaimFileTransactionId).HasColumnName("EDI_CLAIM_FILE_TRANSACTION_ID");
            entity.Property(e => e.EdiClaimFileId).HasColumnName("EDI_CLAIM_FILE_ID");
            entity.Property(e => e.EdiClaimFileTransBatchNumber)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EDI_CLAIM_FILE_TRANS_BATCH_NUMBER");
            entity.Property(e => e.EdiClaimFileTransChargeCount).HasColumnName("EDI_CLAIM_FILE_TRANS_CHARGE_COUNT");
            entity.Property(e => e.EdiClaimFileTransDate)
                .HasColumnType("datetime")
                .HasColumnName("EDI_CLAIM_FILE_TRANS_DATE");
            entity.Property(e => e.EdiClaimFileTransInsCompanyId).HasColumnName("EDI_CLAIM_FILE_TRANS_INS_COMPANY_ID");
            entity.Property(e => e.EdiClaimFileTransNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EDI_CLAIM_FILE_TRANS_NUMBER");
            entity.Property(e => e.EdiClaimFileTransStatusDesc)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("EDI_CLAIM_FILE_TRANS_STATUS_DESC");
            entity.Property(e => e.EdiClaimFileTransStatusId).HasColumnName("EDI_CLAIM_FILE_TRANS_STATUS_ID");
            entity.Property(e => e.EdiClaimFileTransTotalAmount)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("EDI_CLAIM_FILE_TRANS_TOTAL_AMOUNT");
        });

        modelBuilder.Entity<EdiClaimFileTransactionIndClaim>(entity =>
        {
            entity.HasKey(e => e.EdiClaimFileTransIndClaimId);

            entity.ToTable("EDI_CLAIM_FILE_TRANSACTION_IND_CLAIMS");

            entity.Property(e => e.EdiClaimFileTransIndClaimId).HasColumnName("EDI_CLAIM_FILE_TRANS_IND_CLAIM_ID");
            entity.Property(e => e.EdiClaimFileId).HasColumnName("EDI_CLAIM_FILE_ID");
            entity.Property(e => e.EdiClaimTransIndClmBatchNum)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EDI_CLAIM_TRANS_IND_CLM_BATCH_NUM");
            entity.Property(e => e.EdiClaimTransIndClmChargeCount).HasColumnName("EDI_CLAIM_TRANS_IND_CLM_CHARGE_COUNT");
            entity.Property(e => e.EdiClaimTransIndClmCtrllNum)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("EDI_CLAIM_TRANS_IND_CLM_CTRLL_NUM");
            entity.Property(e => e.EdiClaimTransIndClmDate)
                .HasColumnType("datetime")
                .HasColumnName("EDI_CLAIM_TRANS_IND_CLM_DATE");
            entity.Property(e => e.EdiClaimTransIndClmInfFlag).HasColumnName("EDI_CLAIM_TRANS_IND_CLM_INF_FLAG");
            entity.Property(e => e.EdiClaimTransIndClmLastUpdate)
                .HasColumnType("datetime")
                .HasColumnName("EDI_CLAIM_TRANS_IND_CLM_LAST_UPDATE");
            entity.Property(e => e.EdiClaimTransIndClmPatId).HasColumnName("EDI_CLAIM_TRANS_IND_CLM_PAT_ID");
            entity.Property(e => e.EdiClaimTransIndClmPayerLatestStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EDI_CLAIM_TRANS_IND_CLM_PAYER_LATEST_STATUS");
            entity.Property(e => e.EdiClaimTransIndClmStatus).HasColumnName("EDI_CLAIM_TRANS_IND_CLM_STATUS");
            entity.Property(e => e.EdiClaimTransIndClmStatusDesc)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EDI_CLAIM_TRANS_IND_CLM_STATUS_DESC");
            entity.Property(e => e.EdiClaimTransIndClmTotalAmt)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("EDI_CLAIM_TRANS_IND_CLM_TOTAL_AMT");
            entity.Property(e => e.EdiClaimTransactionId).HasColumnName("EDI_CLAIM_TRANSACTION_ID");
        });

        modelBuilder.Entity<EdiClaimFileTransactionIndClaimStatus>(entity =>
        {
            entity.ToTable("EDI_CLAIM_FILE_TRANSACTION_IND_CLAIM_STATUS");

            entity.Property(e => e.EdiClaimFileTransactionIndClaimStatusId).HasColumnName("EDI_CLAIM_FILE_TRANSACTION_IND_CLAIM_STATUS_ID");
            entity.Property(e => e.EdiClaimFileTransIndClaimId).HasColumnName("EDI_CLAIM_FILE_TRANS_IND_CLAIM_ID");
            entity.Property(e => e.EdiClaimFileTransIndClmLastUpdated)
                .HasColumnType("datetime")
                .HasColumnName("EDI_CLAIM_FILE_TRANS_IND_CLM_LAST_UPDATED");
            entity.Property(e => e.EdiClaimFileTransIndClmLatestStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EDI_CLAIM_FILE_TRANS_IND_CLM_LATEST_STATUS");
            entity.Property(e => e.EdiClaimFileTransIndClmStatusRecCreated)
                .HasColumnType("datetime")
                .HasColumnName("EDI_CLAIM_FILE_TRANS_IND_CLM_STATUS_REC_CREATED");
            entity.Property(e => e.EdiClaimFileTransIndClmStatusRecDatasource)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EDI_CLAIM_FILE_TRANS_IND_CLM_STATUS_REC_DATASOURCE");
            entity.Property(e => e.EdiClaimFileTransIndClmStatusRecId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EDI_CLAIM_FILE_TRANS_IND_CLM_STATUS_REC_ID");
            entity.Property(e => e.EdiClaimFileTransIndClmStatusRecMsg)
                .IsUnicode(false)
                .HasColumnName("EDI_CLAIM_FILE_TRANS_IND_CLM_STATUS_REC_MSG");
            entity.Property(e => e.EdiClaimFileTransIndClmStatusRecMsg2)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("EDI_CLAIM_FILE_TRANS_IND_CLM_STATUS_REC_MSG_2");
            entity.Property(e => e.EdiClaimFileTransIndClmStatusRecMsgLevel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EDI_CLAIM_FILE_TRANS_IND_CLM_STATUS_REC_MSG_LEVEL");
            entity.Property(e => e.EdiClaimFileTransIndClmStatusRecStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EDI_CLAIM_FILE_TRANS_IND_CLM_STATUS_REC_STATUS");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
        });

        modelBuilder.Entity<EdiClaimFileTransactionIndClmCharge>(entity =>
        {
            entity.HasKey(e => e.EdiClaimFileTransIndClmChargeId).HasName("PK_EDI_CLAIM_CHARGE_MASTER_ID");

            entity.ToTable("EDI_CLAIM_FILE_TRANSACTION_IND_CLM_CHARGES");

            entity.Property(e => e.EdiClaimFileTransIndClmChargeId).HasColumnName("EDI_CLAIM_FILE_TRANS_IND_CLM_CHARGE_ID");
            entity.Property(e => e.EdiClaimChargeResponse)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EDI_CLAIM_CHARGE_RESPONSE");
            entity.Property(e => e.EdiClaimFileId).HasColumnName("EDI_CLAIM_FILE_ID");
            entity.Property(e => e.EdiClaimFileTransId).HasColumnName("EDI_CLAIM_FILE_TRANS_ID");
            entity.Property(e => e.EdiClaimFileTransIndClmChgStatusDesc)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EDI_CLAIM_FILE_TRANS_IND_CLM_CHG_STATUS_DESC");
            entity.Property(e => e.EdiClaimFileTransIndClmChgStatusId).HasColumnName("EDI_CLAIM_FILE_TRANS_IND_CLM_CHG_STATUS_ID");
            entity.Property(e => e.EdiClaimFileTransIndClmEventId).HasColumnName("EDI_CLAIM_FILE_TRANS_IND_CLM_EVENT_ID");
            entity.Property(e => e.EdiClaimFileTransIndClmId).HasColumnName("EDI_CLAIM_FILE_TRANS_IND_CLM_ID");
            entity.Property(e => e.EdiClaimFileTransIndClmOrderChargeId).HasColumnName("EDI_CLAIM_FILE_TRANS_IND_CLM_ORDER_CHARGE_ID");
            entity.Property(e => e.EdiClaimFileTransIndClmPatInsId).HasColumnName("EDI_CLAIM_FILE_TRANS_IND_CLM_PAT_INS_ID");
            entity.Property(e => e.EdiClaimFileTransIndClmPatInsRank).HasColumnName("EDI_CLAIM_FILE_TRANS_IND_CLM_PAT_INS_RANK");
        });

        modelBuilder.Entity<EdiClaimHcfaPrintQueue>(entity =>
        {
            entity.HasKey(e => e.EdiClaimHcfaPrintQueueItemId);

            entity.ToTable("EDI_CLAIM_HCFA_PRINT_QUEUE");

            entity.Property(e => e.EdiClaimHcfaPrintQueueItemId).HasColumnName("EDI_CLAIM_HCFA_PRINT_QUEUE_ITEM_ID");
            entity.Property(e => e.AddedBy).HasColumnName("ADDED_BY");
            entity.Property(e => e.AddedDate)
                .HasColumnType("datetime")
                .HasColumnName("ADDED_DATE");
            entity.Property(e => e.EdiClaimFileIsPrintJobSuccess).HasColumnName("EDI_CLAIM_FILE_IS_PRINT_JOB_SUCCESS");
            entity.Property(e => e.EdiClaimFileTransIndClaimId).HasColumnName("EDI_CLAIM_FILE_TRANS_IND_CLAIM_ID");
            entity.Property(e => e.EdiClaimHcfaClaimAmt)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("EDI_CLAIM_HCFA_CLAIM_AMT");
            entity.Property(e => e.EdiClaimHcfaClmChargeCt).HasColumnName("EDI_CLAIM_HCFA_CLM_CHARGE_CT");
            entity.Property(e => e.EdiClaimHcfaClmDos)
                .HasColumnType("datetime")
                .HasColumnName("EDI_CLAIM_HCFA_CLM_DOS");
            entity.Property(e => e.EdiClaimHcfaFileContent)
                .IsUnicode(false)
                .HasColumnName("EDI_CLAIM_HCFA_FILE_CONTENT");
            entity.Property(e => e.EdiClaimHcfaInsCompanyId).HasColumnName("EDI_CLAIM_HCFA_INS_COMPANY_ID");
            entity.Property(e => e.EdiClaimHcfaInsPolicyNum)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("EDI_CLAIM_HCFA_INS_POLICY_NUM");
            entity.Property(e => e.EdiClaimHcfaPrintQuePatId).HasColumnName("EDI_CLAIM_HCFA_PRINT_QUE_PAT_ID");
            entity.Property(e => e.EdiClaimHcfaPrintQueueItemStatus).HasColumnName("EDI_CLAIM_HCFA_PRINT_QUEUE_ITEM_STATUS");
            entity.Property(e => e.LastModifiedBy).HasColumnName("LAST_MODIFIED_BY");
            entity.Property(e => e.LastModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("LAST_MODIFIED_DATE");
            entity.Property(e => e.Notes)
                .IsUnicode(false)
                .HasColumnName("NOTES");
        });

        modelBuilder.Entity<EdiEligibilityFile>(entity =>
        {
            entity.HasKey(e => e.EdiEligibityFileId).HasName("PK_EDI_ELIGIBLITY_FILES");

            entity.ToTable("EDI_ELIGIBILITY_FILES");

            entity.HasIndex(e => e.EdiEligibilityPatientInsuranceRank, "INSRANK");

            entity.Property(e => e.EdiEligibityFileId).HasColumnName("EDI_ELIGIBITY_FILE_ID");
            entity.Property(e => e.EdiEligibiityRequestTime)
                .HasColumnType("datetime")
                .HasColumnName("EDI_ELIGIBIITY_REQUEST_TIME");
            entity.Property(e => e.EdiEligibiityResponseFile)
                .IsUnicode(false)
                .HasColumnName("EDI_ELIGIBIITY_RESPONSE_FILE");
            entity.Property(e => e.EdiEligibilityFileActive).HasColumnName("EDI_ELIGIBILITY_FILE_ACTIVE");
            entity.Property(e => e.EdiEligibilityPatientId).HasColumnName("EDI_ELIGIBILITY_PATIENT_ID");
            entity.Property(e => e.EdiEligibilityPatientInsuranceId).HasColumnName("EDI_ELIGIBILITY_PATIENT_INSURANCE_ID");
            entity.Property(e => e.EdiEligibilityPatientInsuranceRank).HasColumnName("EDI_ELIGIBILITY_PATIENT_INSURANCE_RANK");
            entity.Property(e => e.EdiEligibilityProviderId).HasColumnName("EDI_ELIGIBILITY_PROVIDER_ID");
            entity.Property(e => e.EdiEligibilityReqSuccess).HasColumnName("EDI_ELIGIBILITY_REQ_SUCCESS");
            entity.Property(e => e.EdiEligibilityRequestFile)
                .IsUnicode(false)
                .HasColumnName("EDI_ELIGIBILITY_REQUEST_FILE");
            entity.Property(e => e.EdiEligibilityResponseTime)
                .HasColumnType("datetime")
                .HasColumnName("EDI_ELIGIBILITY_RESPONSE_TIME");
        });

        modelBuilder.Entity<EdiEligibilityPatEligDetail>(entity =>
        {
            entity.HasKey(e => e.EdiEligibiltyPatDetailId).HasName("PK_EDI_ELIGIBLITY_PAT_ELIG_DETAILS");

            entity.ToTable("EDI_ELIGIBILITY_PAT_ELIG_DETAILS");

            entity.Property(e => e.EdiEligibiltyPatDetailId).HasColumnName("EDI_ELIGIBILTY_PAT_DETAIL_ID");
            entity.Property(e => e.EdiEligibilityDetailCoverageType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EDI_ELIGIBILITY_DETAIL_COVERAGE_TYPE");
            entity.Property(e => e.EdiEligibilityDetailStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EDI_ELIGIBILITY_DETAIL_STATUS");
            entity.Property(e => e.EdiEligibilityFileId).HasColumnName("EDI_ELIGIBILITY_FILE_ID");
            entity.Property(e => e.EdiEligibilityPatInsId).HasColumnName("EDI_ELIGIBILITY_PAT_INS_ID");
            entity.Property(e => e.EdiEligibilityPatInsRank).HasColumnName("EDI_ELIGIBILITY_PAT_INS_RANK");
            entity.Property(e => e.EdiEligibilityPatientId).HasColumnName("EDI_ELIGIBILITY_PATIENT_ID");
            entity.Property(e => e.EdiEligibiltyPatDetailType).HasColumnName("EDI_ELIGIBILTY_PAT_DETAIL_TYPE");
            entity.Property(e => e.InNetworkCoinsurance)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("IN_NETWORK_COINSURANCE");
            entity.Property(e => e.InNetworkCopay)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("IN_NETWORK_COPAY");
            entity.Property(e => e.InNetworkDeductibleFamCalyear)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("IN_NETWORK_DEDUCTIBLE_FAM_CALYEAR");
            entity.Property(e => e.InNetworkDeductibleFamRemaining)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("IN_NETWORK_DEDUCTIBLE_FAM_REMAINING");
            entity.Property(e => e.InNetworkDeductibleIndCalyear)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("IN_NETWORK_DEDUCTIBLE_IND_CALYEAR");
            entity.Property(e => e.InNetworkDeductibleIndRemaining)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("IN_NETWORK_DEDUCTIBLE_IND_REMAINING");
            entity.Property(e => e.InNetworkOtpMaxFamCalyear)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("IN_NETWORK_OTP_MAX_FAM_CALYEAR");
            entity.Property(e => e.InNetworkOtpMaxFamRemaining)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("IN_NETWORK_OTP_MAX_FAM_REMAINING");
            entity.Property(e => e.InNetworkOtpMaxIndCalyear)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("IN_NETWORK_OTP_MAX_IND_CALYEAR");
            entity.Property(e => e.InNetworkOtpMaxIndRemaining)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("IN_NETWORK_OTP_MAX_IND_REMAINING");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(e => e.NaNetworkCoinsurance)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("NA_NETWORK_COINSURANCE");
            entity.Property(e => e.NaNetworkCopay)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("NA_NETWORK_COPAY");
            entity.Property(e => e.NaNetworkDeductibleFamCalyear)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("NA_NETWORK_DEDUCTIBLE_FAM_CALYEAR");
            entity.Property(e => e.NaNetworkDeductibleFamRemaining)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("NA_NETWORK_DEDUCTIBLE_FAM_REMAINING");
            entity.Property(e => e.NaNetworkDeductibleIndCalyear)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("NA_NETWORK_DEDUCTIBLE_IND_CALYEAR");
            entity.Property(e => e.NaNetworkDeductibleIndRemaining)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("NA_NETWORK_DEDUCTIBLE_IND_REMAINING");
            entity.Property(e => e.NaNetworkOtpMaxFamCalyear)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("NA_NETWORK_OTP_MAX_FAM_CALYEAR");
            entity.Property(e => e.NaNetworkOtpMaxFamRemaining)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("NA_NETWORK_OTP_MAX_FAM_REMAINING");
            entity.Property(e => e.NaNetworkOtpMaxIndCalyear)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("NA_NETWORK_OTP_MAX_IND_CALYEAR");
            entity.Property(e => e.NaNetworkOtpMaxIndRemaining)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("NA_NETWORK_OTP_MAX_IND_REMAINING");
            entity.Property(e => e.OutNetworkCoinsurance)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("OUT_NETWORK_COINSURANCE");
            entity.Property(e => e.OutNetworkCopay)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("OUT_NETWORK_COPAY");
            entity.Property(e => e.OutNetworkDeductibleFamCalyear)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("OUT_NETWORK_DEDUCTIBLE_FAM_CALYEAR");
            entity.Property(e => e.OutNetworkDeductibleFamRemaining)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("OUT_NETWORK_DEDUCTIBLE_FAM_REMAINING");
            entity.Property(e => e.OutNetworkDeductibleIndCalyear)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("OUT_NETWORK_DEDUCTIBLE_IND_CALYEAR");
            entity.Property(e => e.OutNetworkDeductibleIndRemaining)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("OUT_NETWORK_DEDUCTIBLE_IND_REMAINING");
            entity.Property(e => e.OutNetworkOtpMaxFamCalyear)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("OUT_NETWORK_OTP_MAX_FAM_CALYEAR");
            entity.Property(e => e.OutNetworkOtpMaxFamRemaining)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("OUT_NETWORK_OTP_MAX_FAM_REMAINING");
            entity.Property(e => e.OutNetworkOtpMaxIndCalyear)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("OUT_NETWORK_OTP_MAX_IND_CALYEAR");
            entity.Property(e => e.OutNetworkOtpMaxIndRemaining)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("OUT_NETWORK_OTP_MAX_IND_REMAINING");
            entity.Property(e => e.RecordUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("RECORD_UPDATE_DATE");
        });

        modelBuilder.Entity<EdiMntClmEntityCode>(entity =>
        {
            entity.ToTable("EDI_MNT_CLM_ENTITY_CODES");

            entity.Property(e => e.EdiMntClmEntityCodeId).HasColumnName("EDI_MNT_CLM_ENTITY_CODE_ID");
            entity.Property(e => e.EdiMntClmEntityCode1)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EDI_MNT_CLM_ENTITY_CODE");
            entity.Property(e => e.EdiMntClmEntityCodeDesc)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("EDI_MNT_CLM_ENTITY_CODE_DESC");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
        });

        modelBuilder.Entity<EdiMntClmStatus>(entity =>
        {
            entity.ToTable("EDI_MNT_CLM_STATUS");

            entity.Property(e => e.EdiMntClmStatusId).HasColumnName("EDI_MNT_CLM_STATUS_ID");
            entity.Property(e => e.EdiMntClmStatusCd)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EDI_MNT_CLM_STATUS_CD");
            entity.Property(e => e.EdiMntClmStatusDesc)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("EDI_MNT_CLM_STATUS_DESC");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
        });

        modelBuilder.Entity<EdiMntHcfaPrinter>(entity =>
        {
            entity.HasKey(e => e.EdiHcfaPrinterId);

            entity.ToTable("EDI_MNT_HCFA_PRINTERS");

            entity.Property(e => e.EdiHcfaPrinterId).HasColumnName("EDI_HCFA_PRINTER_ID");
            entity.Property(e => e.EdiHcfaPrinterAddedBy).HasColumnName("EDI_HCFA_PRINTER_ADDED_BY");
            entity.Property(e => e.EdiHcfaPrinterAddedTime)
                .HasColumnType("datetime")
                .HasColumnName("EDI_HCFA_PRINTER_ADDED_TIME");
            entity.Property(e => e.EdiHcfaPrinterAssignedName)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("EDI_HCFA_PRINTER_ASSIGNED_NAME");
            entity.Property(e => e.EdiHcfaPrinterLine10Box10dXOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_10_BOX_10D_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine10Box10dYOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_10_BOX_10D_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine10Box11dXOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_10_BOX_11D_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine10Box11dYOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_10_BOX_11D_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine10Box9dXOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_10_BOX_9D_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine10Box9dYOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_10_BOX_9D_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine11Box12XOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_11_BOX_12_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine11Box12YOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_11_BOX_12_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine11Box13XOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_11_BOX_13_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine11Box13YOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_11_BOX_13_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine12Box14XOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_12_BOX_14_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine12Box14YOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_12_BOX_14_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine12Box15XOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_12_BOX_15_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine12Box15YOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_12_BOX_15_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine12Box16XOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_12_BOX_16_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine12Box16YOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_12_BOX_16_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine13Box17AbXOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_13_BOX_17_AB_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine13Box17AbYOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_13_BOX_17_AB_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine13Box17XOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_13_BOX_17_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine13Box17YOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_13_BOX_17_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine13Box18XOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_13_BOX_18_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine13Box18YOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_13_BOX_18_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine14Box19XOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_14_BOX_19_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine14Box19YOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_14_BOX_19_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine14Box20ChgXOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_14_BOX_20_CHG_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine14Box20ChgYOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_14_BOX_20_CHG_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine14Box20XOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_14_BOX_20_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine14Box20YOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_14_BOX_20_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine15Box21XOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_15_BOX_21_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine15Box21YOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_15_BOX_21_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine15Box22RefXOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_15_BOX_22_REF_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine15Box22RefYOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_15_BOX_22_REF_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine15Box22XOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_15_BOX_22_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine15Box22YOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_15_BOX_22_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine16Box21XOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_16_BOX_21_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine16Box21YOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_16_BOX_21_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine16Box23XOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_16_BOX_23_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine16Box23YOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_16_BOX_23_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine17Box25XOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_17_BOX_25_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine17Box25YOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_17_BOX_25_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine17Box26XOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_17_BOX_26_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine17Box26YOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_17_BOX_26_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine17Box28XOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_17_BOX_28_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine17Box28YOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_17_BOX_28_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine18Box31XOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_18_BOX_31_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine18Box31YOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_18_BOX_31_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine18Box32XOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_18_BOX_32_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine18Box32YOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_18_BOX_32_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine18Box33XOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_18_BOX_33_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine18Box33YOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_18_BOX_33_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine19Box31aXOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_19_BOX_31A_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine19Box31aYOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_19_BOX_31A_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine19Box32aXOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_19_BOX_32A_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine19Box32aYOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_19_BOX_32A_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine19Box33aXOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_19_BOX_33A_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine19Box33aYOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_19_BOX_33A_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine1Box1XOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_1_BOX_1_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine1Box1YOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_1_BOX_1_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine1Box1aXOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_1_BOX_1A_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine1Box1aYOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_1_BOX_1A_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine2Box2XOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_2_BOX_2_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine2Box2YOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_2_BOX_2_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine2Box3XOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_2_BOX_3_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine2Box3YOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_2_BOX_3_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine2Box4XOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_2_BOX_4_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine2Box4YOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_2_BOX_4_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine3Box5XOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_3_BOX_5_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine3Box5YOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_3_BOX_5_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine3Box6XOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_3_BOX_6_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine3Box6YOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_3_BOX_6_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine3Box7XOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_3_BOX_7_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine3Box7YOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_3_BOX_7_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine4Box5CtyStateXOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_4_BOX_5_CTY_STATE_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine4Box5CtyStateYOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_4_BOX_5_CTY_STATE_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine4Box7CtyStateXOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_4_BOX_7_CTY_STATE_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine4Box7CtyStateYOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_4_BOX_7_CTY_STATE_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine5Box5ZipPhoneXOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_5_BOX_5_ZIP_PHONE_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine5Box5ZipPhoneYOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_5_BOX_5_ZIP_PHONE_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine5Box7ZipPhoneXOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_5_BOX_7_ZIP_PHONE_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine5Box7ZipPhoneYOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_5_BOX_7_ZIP_PHONE_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine6Box11XOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_6_BOX_11_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine6Box11YOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_6_BOX_11_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine6Box9XOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_6_BOX_9_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine6Box9YOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_6_BOX_9_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine7Box10aXOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_7_BOX_10A_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine7Box10aYOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_7_BOX_10A_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine7Box11aXOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_7_BOX_11A_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine7Box11aYOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_7_BOX_11A_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine7Box9aXOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_7_BOX_9A_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine7Box9aYOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_7_BOX_9A_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine8Box10bXOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_8_BOX_10B_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine8Box10bYOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_8_BOX_10B_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine8Box11bXOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_8_BOX_11B_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine8Box11bYOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_8_BOX_11B_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine8Box9bXOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_8_BOX_9B_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine8Box9bYOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_8_BOX_9B_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine9Box10cXOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_9_BOX_10C_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine9Box10cYOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_9_BOX_10C_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine9Box11cXOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_9_BOX_11C_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine9Box11cYOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_9_BOX_11C_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine9Box9cXOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_9_BOX_9C_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLine9Box9cYOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_9_BOX_9C_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLineSrvPartAXOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_SRV_PART_A_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLineSrvPartAYOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_SRV_PART_A_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLineSrvPartBXOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_SRV_PART_B_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLineSrvPartBYOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_SRV_PART_B_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLineSrvPartCXOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_SRV_PART_C_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLineSrvPartCYOffset)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_LINE_SRV_PART_C_Y_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterLocationId).HasColumnName("EDI_HCFA_PRINTER_LOCATION_ID");
            entity.Property(e => e.EdiHcfaPrinterModifiedBy).HasColumnName("EDI_HCFA_PRINTER_MODIFIED_BY");
            entity.Property(e => e.EdiHcfaPrinterModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("EDI_HCFA_PRINTER_MODIFIED_DATE");
            entity.Property(e => e.EdiHcfaPrinterName)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("EDI_HCFA_PRINTER_NAME");
            entity.Property(e => e.EdiHcfaPrinterXOffset)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_X_OFFSET");
            entity.Property(e => e.EdiHcfaPrinterYOffset)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_PRINTER_Y_OFFSET");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
        });

        modelBuilder.Entity<EdiMntRemitGroupCode>(entity =>
        {
            entity.ToTable("EDI_MNT_REMIT_GROUP_CODES");

            entity.Property(e => e.EdiMntRemitGroupCodeId).HasColumnName("EDI_MNT_REMIT_GROUP_CODE_ID");
            entity.Property(e => e.EdiMntRemitGroupCode1)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EDI_MNT_REMIT_GROUP_CODE");
            entity.Property(e => e.EdiMntRemitGroupDesc)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("EDI_MNT_REMIT_GROUP_DESC");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
        });

        modelBuilder.Entity<EdiMntRemitReasonCode>(entity =>
        {
            entity.ToTable("EDI_MNT_REMIT_REASON_CODES");

            entity.Property(e => e.EdiMntRemitReasonCodeId).HasColumnName("EDI_MNT_REMIT_REASON_CODE_ID");
            entity.Property(e => e.EdiMntRemitReasonCode1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EDI_MNT_REMIT_REASON_CODE");
            entity.Property(e => e.EdiMntRemitReasonCodeDesc)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("EDI_MNT_REMIT_REASON_CODE_DESC");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
        });

        modelBuilder.Entity<EdiMntRemitReasonCodeXref>(entity =>
        {
            entity.ToTable("EDI_MNT_REMIT_REASON_CODE_XREF");

            entity.Property(e => e.EdiMntRemitReasonCodeXrefId).HasColumnName("EDI_MNT_REMIT_REASON_CODE_XREF_ID");
            entity.Property(e => e.EdiMntRemitGroupCodeId).HasColumnName("EDI_MNT_REMIT_GROUP_CODE_ID");
            entity.Property(e => e.EdiMntRemitReasonCodeId).HasColumnName("EDI_MNT_REMIT_REASON_CODE_ID");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
        });

        modelBuilder.Entity<EdiMntRemitRemCode>(entity =>
        {
            entity.ToTable("EDI_MNT_REMIT_REM_CODES");

            entity.Property(e => e.EdiMntRemitRemCodeId).HasColumnName("EDI_MNT_REMIT_REM_CODE_ID");
            entity.Property(e => e.EdiMntRemitRemCode1)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("EDI_MNT_REMIT_REM_CODE");
            entity.Property(e => e.EdiMntRemitRemCodeDesc)
                .IsUnicode(false)
                .HasColumnName("EDI_MNT_REMIT_REM_CODE_DESC");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
        });

        modelBuilder.Entity<EdiRemitFile>(entity =>
        {
            entity.ToTable("EDI_REMIT_FILES");

            entity.Property(e => e.EdiRemitFileId).HasColumnName("EDI_REMIT_FILE_ID");
            entity.Property(e => e.EdiRemitCheckEftNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_CHECK_EFT_NUMBER");
            entity.Property(e => e.EdiRemitContactPayerBusinessName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_CONTACT_PAYER_BUSINESS_NAME");
            entity.Property(e => e.EdiRemitContactPayerBusinessPhone)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_CONTACT_PAYER_BUSINESS_PHONE");
            entity.Property(e => e.EdiRemitContactPayerTechinicalPhone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_CONTACT_PAYER_TECHINICAL_PHONE");
            entity.Property(e => e.EdiRemitContactPayerTechnicalName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_CONTACT_PAYER_TECHNICAL_NAME");
            entity.Property(e => e.EdiRemitControlNumber)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_CONTROL_NUMBER");
            entity.Property(e => e.EdiRemitCreditOrDebit)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_CREDIT_OR_DEBIT");
            entity.Property(e => e.EdiRemitFileContent)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_FILE_CONTENT");
            entity.Property(e => e.EdiRemitFileName)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_FILE_NAME");
            entity.Property(e => e.EdiRemitFileReceivedDate)
                .HasColumnType("datetime")
                .HasColumnName("EDI_REMIT_FILE_RECEIVED_DATE");
            entity.Property(e => e.EdiRemitHandlingType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_HANDLING_TYPE");
            entity.Property(e => e.EdiRemitIssueDate)
                .HasColumnType("datetime")
                .HasColumnName("EDI_REMIT_ISSUE_DATE");
            entity.Property(e => e.EdiRemitMonetaryAmount)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_MONETARY_AMOUNT");
            entity.Property(e => e.EdiRemitPayeeAddress1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_PAYEE_ADDRESS_1");
            entity.Property(e => e.EdiRemitPayeeAddress2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_PAYEE_ADDRESS_2");
            entity.Property(e => e.EdiRemitPayeeCity)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_PAYEE_CITY");
            entity.Property(e => e.EdiRemitPayeeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_PAYEE_ID");
            entity.Property(e => e.EdiRemitPayeeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_PAYEE_NAME");
            entity.Property(e => e.EdiRemitPayeeState)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_PAYEE_STATE");
            entity.Property(e => e.EdiRemitPayeeZip)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_PAYEE_ZIP");
            entity.Property(e => e.EdiRemitPayerAddress1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_PAYER_ADDRESS_1");
            entity.Property(e => e.EdiRemitPayerAddress2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_PAYER_ADDRESS_2");
            entity.Property(e => e.EdiRemitPayerCity)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_PAYER_CITY");
            entity.Property(e => e.EdiRemitPayerId)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_PAYER_ID");
            entity.Property(e => e.EdiRemitPayerName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_PAYER_NAME");
            entity.Property(e => e.EdiRemitPayerState)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_PAYER_STATE");
            entity.Property(e => e.EdiRemitPayerWebsite)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_PAYER_WEBSITE");
            entity.Property(e => e.EdiRemitPayerZip)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_PAYER_ZIP");
            entity.Property(e => e.EdiRemitPaymentCount).HasColumnName("EDI_REMIT_PAYMENT_COUNT");
            entity.Property(e => e.EdiRemitPaymentMethod)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_PAYMENT_METHOD");
            entity.Property(e => e.EdiRemitProdDate)
                .HasColumnType("datetime")
                .HasColumnName("EDI_REMIT_PROD_DATE");
            entity.Property(e => e.EdiRemitTotalAmount)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_TOTAL_AMOUNT");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(e => e.IsPosted).HasColumnName("IS_POSTED");
        });

        modelBuilder.Entity<EdiRemitFollowUpPayment>(entity =>
        {
            entity.HasKey(e => e.EdiRemitFlwUpPmtId);

            entity.ToTable("EDI_REMIT_FOLLOW_UP_PAYMENTS");

            entity.Property(e => e.EdiRemitFlwUpPmtId).HasColumnName("EDI_REMIT_FLW_UP_PMT_ID");
            entity.Property(e => e.EdiRemitFlwUpAddedBy).HasColumnName("EDI_REMIT_FLW_UP_ADDED_BY");
            entity.Property(e => e.EdiRemitFlwUpAddedDate)
                .HasColumnType("datetime")
                .HasColumnName("EDI_REMIT_FLW_UP_ADDED_DATE");
            entity.Property(e => e.EdiRemitFlwUpAdjCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_FLW_UP_ADJ_CODE");
            entity.Property(e => e.EdiRemitFlwUpBatchNum)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_FLW_UP_BATCH_NUM");
            entity.Property(e => e.EdiRemitFlwUpModifedDate)
                .HasColumnType("datetime")
                .HasColumnName("EDI_REMIT_FLW_UP_MODIFED_DATE");
            entity.Property(e => e.EdiRemitFlwUpModifiedBy).HasColumnName("EDI_REMIT_FLW_UP_MODIFIED_BY");
            entity.Property(e => e.EdiRemitFlwUpNotes)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_FLW_UP_NOTES");
            entity.Property(e => e.EdiRemitFlwUpPmtCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_FLW_UP_PMT_CODE");
            entity.Property(e => e.EdiRemitFlwUpReason)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_FLW_UP_REASON");
            entity.Property(e => e.EdiRemitFlwUpSentFromSys).HasColumnName("EDI_REMIT_FLW_UP_SENT_FROM_SYS");
            entity.Property(e => e.EdiRemitFlwUpStatusId).HasColumnName("EDI_REMIT_FLW_UP_STATUS_ID");
            entity.Property(e => e.EdiRemitIndClmPmtSrvLineId).HasColumnName("EDI_REMIT_IND_CLM_PMT_SRV_LINE_ID");
        });

        modelBuilder.Entity<EdiRemitIndClmPayment>(entity =>
        {
            entity.HasKey(e => e.EdiRemitIndClaimPaymentId);

            entity.ToTable("EDI_REMIT_IND_CLM_PAYMENTS");

            entity.Property(e => e.EdiRemitIndClaimPaymentId).HasColumnName("EDI_REMIT_IND_CLAIM_PAYMENT_ID");
            entity.Property(e => e.EdiRemitClaimPaymentClaimId)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_CLAIM_PAYMENT_CLAIM_ID");
            entity.Property(e => e.EdiRemitClaimPaymentClaimIdUpdated)
                .HasDefaultValue(false)
                .HasColumnName("EDI_REMIT_CLAIM_PAYMENT_CLAIM_ID_UPDATED");
            entity.Property(e => e.EdiRemitClaimPaymentStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_CLAIM_PAYMENT_STATUS");
            entity.Property(e => e.EdiRemitFileId).HasColumnName("EDI_REMIT_FILE_ID");
            entity.Property(e => e.EdiRemitIndClmBilledAmt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_BILLED_AMT");
            entity.Property(e => e.EdiRemitIndClmClaimType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_CLAIM_TYPE");
            entity.Property(e => e.EdiRemitIndClmCorrectedName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_CORRECTED_NAME");
            entity.Property(e => e.EdiRemitIndClmCoveredAmt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_COVERED_AMT");
            entity.Property(e => e.EdiRemitIndClmCrossoverCarrier)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_CROSSOVER_CARRIER");
            entity.Property(e => e.EdiRemitIndClmFacilityName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_FACILITY_NAME");
            entity.Property(e => e.EdiRemitIndClmInsuredName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_INSURED_NAME");
            entity.Property(e => e.EdiRemitIndClmInterestAmt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_INTEREST_AMT");
            entity.Property(e => e.EdiRemitIndClmMonetaryAmt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_MONETARY_AMT");
            entity.Property(e => e.EdiRemitIndClmPaidAmt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_PAID_AMT");
            entity.Property(e => e.EdiRemitIndClmPatRespAmt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_PAT_RESP_AMT");
            entity.Property(e => e.EdiRemitIndClmPatientName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_PATIENT_NAME");
            entity.Property(e => e.EdiRemitIndClmPayerCtrlNum)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_PAYER_CTRL_NUM");
            entity.Property(e => e.EdiRemitIndClmPmtDnyCovExpDate)
                .HasColumnType("datetime")
                .HasColumnName("EDI_REMIT_IND_CLM_PMT_DNY_COV_EXP_DATE");
            entity.Property(e => e.EdiRemitIndClmPolicyNumber)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_POLICY_NUMBER");
            entity.Property(e => e.EdiRemitIndClmProviderName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_PROVIDER_NAME");
            entity.Property(e => e.EdiRemitIndClmReceivedDate)
                .HasColumnType("datetime")
                .HasColumnName("EDI_REMIT_IND_CLM_RECEIVED_DATE");
            entity.Property(e => e.EdiRemitPmtIsClmSentFromSys).HasColumnName("EDI_REMIT_PMT_IS_CLM_SENT_FROM_SYS");
            entity.Property(e => e.EdiRemitTransactionId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_TRANSACTION_ID");
        });

        modelBuilder.Entity<EdiRemitIndClmPmtAdjustment>(entity =>
        {
            entity.HasKey(e => e.EdiRemitIndClmAdjId);

            entity.ToTable("EDI_REMIT_IND_CLM_PMT_ADJUSTMENTS");

            entity.Property(e => e.EdiRemitIndClmAdjId).HasColumnName("EDI_REMIT_IND_CLM_ADJ_ID");
            entity.Property(e => e.EdiRemitIndClmAdjGrpCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_ADJ_GRP_CODE");
            entity.Property(e => e.EdiRemitIndClmAdjGrpCodeDesc)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_ADJ_GRP_CODE_DESC");
            entity.Property(e => e.EdiRemitIndClmAdjMonetaryAmt)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_ADJ_MONETARY_AMT");
            entity.Property(e => e.EdiRemitIndClmAdjMonetaryQty)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_ADJ_MONETARY_QTY");
            entity.Property(e => e.EdiRemitIndClmAdjReasonCode)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_ADJ_REASON_CODE");
            entity.Property(e => e.EdiRemitIndClmAdjReasonDesc)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_ADJ_REASON_DESC");
            entity.Property(e => e.EdiRemitIndClmPmtId).HasColumnName("EDI_REMIT_IND_CLM_PMT_ID");
        });

        modelBuilder.Entity<EdiRemitIndClmPmtRemark>(entity =>
        {
            entity.ToTable("EDI_REMIT_IND_CLM_PMT_REMARKS");

            entity.Property(e => e.EdiRemitIndClmPmtRemarkId).HasColumnName("EDI_REMIT_IND_CLM_PMT_REMARK_ID");
            entity.Property(e => e.AddedDate)
                .HasColumnType("datetime")
                .HasColumnName("ADDED_DATE");
            entity.Property(e => e.EdiMntRemitRemCodeId).HasColumnName("EDI_MNT_REMIT_REM_CODE_ID");
            entity.Property(e => e.EdiRemitIndClmMonetaryAmt)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_MONETARY_AMT");
            entity.Property(e => e.EdiRemitIndClmPmtId).HasColumnName("EDI_REMIT_IND_CLM_PMT_ID");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
        });

        modelBuilder.Entity<EdiRemitIndClmPmtServiceLine>(entity =>
        {
            entity.HasKey(e => e.EdiRemitIndClmPmtSrvLineId);

            entity.ToTable("EDI_REMIT_IND_CLM_PMT_SERVICE_LINES");

            entity.Property(e => e.EdiRemitIndClmPmtSrvLineId).HasColumnName("EDI_REMIT_IND_CLM_PMT_SRV_LINE_ID");
            entity.Property(e => e.EdiRemitIndClmPmtSrvLineAlwdAmt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_PMT_SRV_LINE_ALWD_AMT");
            entity.Property(e => e.EdiRemitIndClmPmtSrvLineBilledAmt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_PMT_SRV_LINE_BILLED_AMT");
            entity.Property(e => e.EdiRemitIndClmPmtSrvLineChargeId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_PMT_SRV_LINE_CHARGE_ID");
            entity.Property(e => e.EdiRemitIndClmPmtSrvLineClmPmtId).HasColumnName("EDI_REMIT_IND_CLM_PMT_SRV_LINE_CLM_PMT_ID");
            entity.Property(e => e.EdiRemitIndClmPmtSrvLineDos)
                .HasColumnType("datetime")
                .HasColumnName("EDI_REMIT_IND_CLM_PMT_SRV_LINE_DOS");
            entity.Property(e => e.EdiRemitIndClmPmtSrvLineEventId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_PMT_SRV_LINE_EVENT_ID");
            entity.Property(e => e.EdiRemitIndClmPmtSrvLineIdentifier)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_PMT_SRV_LINE_IDENTIFIER");
            entity.Property(e => e.EdiRemitIndClmPmtSrvLineIsFlwUp).HasColumnName("EDI_REMIT_IND_CLM_PMT_SRV_LINE_IS_FLW_UP");
            entity.Property(e => e.EdiRemitIndClmPmtSrvLineIsPmtPosted).HasColumnName("EDI_REMIT_IND_CLM_PMT_SRV_LINE_IS_PMT_POSTED");
            entity.Property(e => e.EdiRemitIndClmPmtSrvLineMd1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_PMT_SRV_LINE_MD1");
            entity.Property(e => e.EdiRemitIndClmPmtSrvLineMd2)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_PMT_SRV_LINE_MD2");
            entity.Property(e => e.EdiRemitIndClmPmtSrvLineMd3)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_PMT_SRV_LINE_MD3");
            entity.Property(e => e.EdiRemitIndClmPmtSrvLineMd4)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_PMT_SRV_LINE_MD4");
            entity.Property(e => e.EdiRemitIndClmPmtSrvLinePaidAmt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_PMT_SRV_LINE_PAID_AMT");
            entity.Property(e => e.EdiRemitIndClmPmtSrvLineProcCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_PMT_SRV_LINE_PROC_CODE");
        });

        modelBuilder.Entity<EdiRemitIndClmSrvLineAdjustment>(entity =>
        {
            entity.HasKey(e => e.EdiRemitIndClmSrvLineAdjId).HasName("PK_EDI_REMIT_IND_CLM_PMT_SRV_LINE_ADJUSTMENTS");

            entity.ToTable("EDI_REMIT_IND_CLM_SRV_LINE_ADJUSTMENTS");

            entity.Property(e => e.EdiRemitIndClmSrvLineAdjId).HasColumnName("EDI_REMIT_IND_CLM_SRV_LINE_ADJ_ID");
            entity.Property(e => e.EdiRemitIndClmSrvLineAdjGrpCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_SRV_LINE_ADJ_GRP_CODE");
            entity.Property(e => e.EdiRemitIndClmSrvLineAdjGrpCodeDesc)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_SRV_LINE_ADJ_GRP_CODE_DESC");
            entity.Property(e => e.EdiRemitIndClmSrvLineAdjMonetaryAmt)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_SRV_LINE_ADJ_MONETARY_AMT");
            entity.Property(e => e.EdiRemitIndClmSrvLineAdjMonetaryQty)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_SRV_LINE_ADJ_MONETARY_QTY");
            entity.Property(e => e.EdiRemitIndClmSrvLineAdjReasonCode)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_SRV_LINE_ADJ_REASON_CODE");
            entity.Property(e => e.EdiRemitIndClmSrvLineAdjReasonDesc)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_IND_CLM_SRV_LINE_ADJ_REASON_DESC");
            entity.Property(e => e.EdiRemitIndClmSrvLineId).HasColumnName("EDI_REMIT_IND_CLM_SRV_LINE_ID");
        });

        modelBuilder.Entity<EdiRemitIndClmSrvLineRemark>(entity =>
        {
            entity.HasKey(e => e.EdiRemitIndClmSrvLineRmkId);

            entity.ToTable("EDI_REMIT_IND_CLM_SRV_LINE_REMARKS");

            entity.Property(e => e.EdiRemitIndClmSrvLineRmkId).HasColumnName("EDI_REMIT_IND_CLM_SRV_LINE_RMK_ID");
            entity.Property(e => e.AddedDate)
                .HasColumnType("datetime")
                .HasColumnName("ADDED_DATE");
            entity.Property(e => e.EdiMntRemitRemCodeId).HasColumnName("EDI_MNT_REMIT_REM_CODE_ID");
            entity.Property(e => e.EdiRemitIndClmSrvLineId).HasColumnName("EDI_REMIT_IND_CLM_SRV_LINE_ID");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
        });

        modelBuilder.Entity<EdiSetting>(entity =>
        {
            entity.ToTable("EDI_SETTINGS");

            entity.Property(e => e.EdiSettingId).HasColumnName("EDI_SETTING_ID");
            entity.Property(e => e.EdiApiTurnedOff).HasColumnName("EDI_API_TURNED_OFF");
            entity.Property(e => e.EdiClaimStatusLastUpdatedInf)
                .HasColumnType("datetime")
                .HasColumnName("EDI_CLAIM_STATUS_LAST_UPDATED_INF");
            entity.Property(e => e.EdiCoinsTransCode)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("EDI_COINS_TRANS_CODE");
            entity.Property(e => e.EdiCopayTransCode)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("EDI_COPAY_TRANS_CODE");
            entity.Property(e => e.EdiDeductTransCode)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("EDI_DEDUCT_TRANS_CODE");
            entity.Property(e => e.EdiEligibilityDefaultProvId).HasColumnName("EDI_ELIGIBILITY_DEFAULT_PROV_ID");
            entity.Property(e => e.EdiFtpPassword)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("EDI_FTP_PASSWORD");
            entity.Property(e => e.EdiFtpServer)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EDI_FTP_SERVER");
            entity.Property(e => e.EdiFtpUserName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("EDI_FTP_USER_NAME");
            entity.Property(e => e.EdiHcfaPrinterName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EDI_HCFA_PRINTER_NAME");
            entity.Property(e => e.EdiHcfaXOffset)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_X_OFFSET");
            entity.Property(e => e.EdiHcfaYOffset)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("EDI_HCFA_Y_OFFSET");
            entity.Property(e => e.EdiRemitVspActive)
                .HasDefaultValue(false)
                .HasColumnName("EDI_REMIT_VSP_ACTIVE");
            entity.Property(e => e.EdiRemitVspLocation)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("EDI_REMIT_VSP_LOCATION");
            entity.Property(e => e.EdiSearchEnabled).HasColumnName("EDI_SEARCH_ENABLED");
            entity.Property(e => e.EdiStmtWatermarkDefaultS).HasColumnName("EDI_STMT_WATERMARK_DEFAULT_S");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(e => e.LocationId).HasColumnName("LOCATION_ID");
            entity.Property(e => e.ReceivingEntityCode)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("RECEIVING_ENTITY_CODE");
            entity.Property(e => e.ReceivingEntityName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("RECEIVING_ENTITY_NAME");
            entity.Property(e => e.SubmitterName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SUBMITTER_NAME");
            entity.Property(e => e.SubmittingEntityCode)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("SUBMITTING_ENTITY_CODE");
            entity.Property(e => e.SubmittingEntityContactEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SUBMITTING_ENTITY_CONTACT_EMAIL");
            entity.Property(e => e.SubmittingEntityContactFax)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("SUBMITTING_ENTITY_CONTACT_FAX");
            entity.Property(e => e.SubmittingEntityContactName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SUBMITTING_ENTITY_CONTACT_NAME");
            entity.Property(e => e.SubmittingEntityContactPhone)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("SUBMITTING_ENTITY_CONTACT_PHONE");
        });

        modelBuilder.Entity<EdiStatementFile>(entity =>
        {
            entity.HasKey(e => e.EdiStmtFileId);

            entity.ToTable("EDI_STATEMENT_FILES");

            entity.Property(e => e.EdiStmtFileId).HasColumnName("EDI_STMT_FILE_ID");
            entity.Property(e => e.EdiStmtFileContent)
                .IsUnicode(false)
                .HasColumnName("EDI_STMT_FILE_CONTENT");
            entity.Property(e => e.EdiStmtFileName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("EDI_STMT_FILE_NAME");
            entity.Property(e => e.EdiStmtFileNotes)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("EDI_STMT_FILE_NOTES");
            entity.Property(e => e.EdiStmtFileSentBy).HasColumnName("EDI_STMT_FILE_SENT_BY");
            entity.Property(e => e.EdiStmtFileSentDate)
                .HasColumnType("datetime")
                .HasColumnName("EDI_STMT_FILE_SENT_DATE");
            entity.Property(e => e.EdiStmtFileStatus).HasColumnName("EDI_STMT_FILE_STATUS");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
        });

        modelBuilder.Entity<EdiStatementFilePatXref>(entity =>
        {
            entity.HasKey(e => e.EdiStmtFilePatXrefId);

            entity.ToTable("EDI_STATEMENT_FILE_PAT_XREF");

            entity.Property(e => e.EdiStmtFilePatXrefId).HasColumnName("EDI_STMT_FILE_PAT_XREF_ID");
            entity.Property(e => e.EdiStmtFileId).HasColumnName("EDI_STMT_FILE_ID");
            entity.Property(e => e.EdiStmtFilePatientId).HasColumnName("EDI_STMT_FILE_PATIENT_ID");
            entity.Property(e => e.ResponseDate)
                .HasColumnType("datetime")
                .HasColumnName("RESPONSE_DATE");
            entity.Property(e => e.ResponseStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("RESPONSE_STATUS");
            entity.Property(e => e.ResponseStatusMessage)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("RESPONSE_STATUS_MESSAGE");
            entity.Property(e => e.StatusId).HasColumnName("STATUS_ID");
        });

        modelBuilder.Entity<Ehrcharge>(entity =>
        {
            entity.ToTable("EHRCharges");

            entity.Property(e => e.EhrchargeId).HasColumnName("EHRChargeID");
            entity.Property(e => e.Amount).HasColumnType("decimal(9, 2)");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.DateOfService).HasColumnType("datetime");
            entity.Property(e => e.DateReceived).HasColumnType("datetime");
            entity.Property(e => e.Dg1)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("DG1");
            entity.Property(e => e.Evn)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("EVN");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ft1)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("FT1");
            entity.Property(e => e.IsEyeMdcharge).HasColumnName("IsEyeMDCharge");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Msh)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("MSH");
            entity.Property(e => e.Pid)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("PID");
            entity.Property(e => e.Pr1)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("PR1");
            entity.Property(e => e.ProcedureCodeAndDescription)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Provider)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Pv1)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("PV1");
        });

        modelBuilder.Entity<Ehrorder>(entity =>
        {
            entity.ToTable("EHROrders");

            entity.Property(e => e.EhrorderId).HasColumnName("EHROrderID");
            entity.Property(e => e.AccountNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Account_Number");
            entity.Property(e => e.AddedbyFastPlanId).HasColumnName("AddedbyFastPlanID");
            entity.Property(e => e.CodeCpt)
                .HasMaxLength(50)
                .HasColumnName("CodeCPT");
            entity.Property(e => e.CodeLoinc)
                .HasMaxLength(20)
                .HasColumnName("CodeLOINC");
            entity.Property(e => e.CodeSnomed)
                .HasMaxLength(50)
                .HasColumnName("CodeSNOMED");
            entity.Property(e => e.DicomrequestedProcedureId)
                .HasMaxLength(50)
                .HasColumnName("DICOMRequestedProcedureID");
            entity.Property(e => e.DicomscheduledProcedureStepId)
                .HasMaxLength(50)
                .HasColumnName("DICOMScheduledProcedureStepID");
            entity.Property(e => e.Dosdate)
                .HasColumnType("datetime")
                .HasColumnName("DOSDate");
            entity.Property(e => e.EhrPtId).HasColumnName("EHR_PtID");
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.OrderLabResultFulfilledDate).HasColumnType("datetime");
            entity.Property(e => e.OrderLabResultId).HasColumnName("OrderLabResultID");
            entity.Property(e => e.OrderModalityId).HasColumnName("OrderModalityID");
            entity.Property(e => e.OrderRemarks).HasMaxLength(255);
            entity.Property(e => e.OrderScheduledDate).HasMaxLength(50);
            entity.Property(e => e.OrderSpecimenId).HasColumnName("OrderSpecimenID");
            entity.Property(e => e.OrderTypeId)
                .HasMaxLength(50)
                .HasColumnName("OrderTypeID");
            entity.Property(e => e.OrderWhen).HasMaxLength(255);
            entity.Property(e => e.ProvId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ProvID");
            entity.Property(e => e.Provider)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RefProviderFirstName).HasMaxLength(50);
            entity.Property(e => e.RefProviderId)
                .HasMaxLength(20)
                .HasColumnName("RefProviderID");
            entity.Property(e => e.RefProviderLastName).HasMaxLength(50);
            entity.Property(e => e.RefProviderOrganizationName).HasMaxLength(100);
            entity.Property(e => e.ScheduledAe)
                .HasMaxLength(65)
                .HasColumnName("ScheduledAE");
            entity.Property(e => e.StudyInstanceUid)
                .HasMaxLength(65)
                .HasColumnName("StudyInstanceUID");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");
            entity.Property(e => e.VisitOrderId).HasColumnName("VisitOrderID");
        });

        modelBuilder.Entity<EmrtreeViewControlListOld>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("EMRTreeViewControlList_old");

            entity.Property(e => e.BillMultiProcId).HasColumnName("BillMultiProcID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CodeIcd10)
                .HasMaxLength(50)
                .HasColumnName("CodeICD10");
            entity.Property(e => e.CodeId).HasColumnName("CodeID");
            entity.Property(e => e.CodeSnomed)
                .HasMaxLength(50)
                .HasColumnName("CodeSNOMED");
            entity.Property(e => e.ControlId).HasColumnName("ControlID");
            entity.Property(e => e.InsertGuid)
                .HasMaxLength(50)
                .HasColumnName("InsertGUID");
            entity.Property(e => e.Itlevel).HasColumnName("ITLevel");
            entity.Property(e => e.ModalityId).HasColumnName("ModalityID");
            entity.Property(e => e.Modifier).HasMaxLength(50);
            entity.Property(e => e.OrderModalityId).HasColumnName("OrderModalityID");
            entity.Property(e => e.ParentId).HasColumnName("ParentID");
            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.Text).HasMaxLength(255);
            entity.Property(e => e.UpsizeTs)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("upsize_ts");
            entity.Property(e => e.VisitTypeId).HasColumnName("VisitTypeID");
        });

        modelBuilder.Entity<EobInformation>(entity =>
        {
            entity.HasKey(e => e.EobId).HasName("PK__EOB_INFORMATION__117F9D94");

            entity.ToTable("EOB_INFORMATION");

            entity.Property(e => e.EobId).HasColumnName("EOB_ID");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("ACTIVE");
            entity.Property(e => e.Batch)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("BATCH");
            entity.Property(e => e.CheckAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("CHECK_AMOUNT");
            entity.Property(e => e.CheckNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CHECK_NUMBER");
            entity.Property(e => e.IssuedDate).HasColumnName("ISSUED_DATE");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.NpiNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NPI_NUMBER");
            entity.Property(e => e.PaymentDate).HasColumnName("PAYMENT_DATE");
            entity.Property(e => e.ReceivedDate).HasColumnName("RECEIVED_DATE");
            entity.Property(e => e.Reference)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("REFERENCE");
        });

        modelBuilder.Entity<EobToPayment>(entity =>
        {
            entity.HasKey(e => e.EobToPaymentsId).HasName("PK__EOB_TO_PAYMENT__117F9D94");

            entity.ToTable("EOB_TO_PAYMENT");

            entity.Property(e => e.EobToPaymentsId).HasColumnName("EOB_TO_PAYMENTS_ID");
            entity.Property(e => e.AmountApplied)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AMOUNT_APPLIED");
            entity.Property(e => e.Batch)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("BATCH");
            entity.Property(e => e.EobId).HasColumnName("EOB_ID");
            entity.Property(e => e.InsuranceId).HasColumnName("INSURANCE_ID");
            entity.Property(e => e.PaymentDateTime)
                .HasColumnType("datetime")
                .HasColumnName("PAYMENT_DATE_TIME");
            entity.Property(e => e.StaffId).HasColumnName("STAFF_ID");
            entity.Property(e => e.TransactionId).HasColumnName("TRANSACTION_ID");
        });

        modelBuilder.Entity<ExternalSystemChargesList>(entity =>
        {
            entity.ToTable("External_System_Charges_List");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EventDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Event_DateTime");
            entity.Property(e => e.OrderId).HasColumnName("Order_ID");
            entity.Property(e => e.ProcessedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Processed_DateTime");
        });

        modelBuilder.Entity<EyeCareProInformation>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("EYE_CARE_PRO_INFORMATION");

            entity.Property(e => e.ApplicationLastUpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Application_Last_Updated_DateTime");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("Create_Date");
            entity.Property(e => e.EyeCareProLoginName)
                .HasMaxLength(550)
                .IsUnicode(false)
                .HasColumnName("EyeCare_Pro_Login_Name");
            entity.Property(e => e.EyeCareProPassword)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("EyeCare_Pro_Password");
            entity.Property(e => e.VersionNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("Version_Number");
        });

        modelBuilder.Entity<FinalizeAndClaimEvent>(entity =>
        {
            entity.HasKey(e => e.EventId);

            entity.ToTable("FINALIZE_AND_CLAIM_EVENTS");

            entity.HasIndex(e => e.EventCategory, "EC");

            entity.HasIndex(e => e.EventSponsorId, "ESI");

            entity.HasIndex(e => e.InsuranceId, "InsId");

            entity.HasIndex(e => e.ChargeOnhold, "OnHold");

            entity.Property(e => e.EventId).HasColumnName("Event_Id");
            entity.Property(e => e.Amount).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.Batch)
                .HasMaxLength(35)
                .IsUnicode(false);
            entity.Property(e => e.BillingLocationId).HasColumnName("Billing_Location_Id");
            entity.Property(e => e.ChargeOnhold).HasColumnName("CHARGE_ONHOLD");
            entity.Property(e => e.ClaimProcessedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Claim_Processed_DateTime");
            entity.Property(e => e.ClaimProcessedStaffId).HasColumnName("Claim_Processed_Staff_Id");
            entity.Property(e => e.Diagnosis1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("Diagnosis_1");
            entity.Property(e => e.Diagnosis2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("Diagnosis_2");
            entity.Property(e => e.Diagnosis3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("Diagnosis_3");
            entity.Property(e => e.Diagnosis4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("Diagnosis_4");
            entity.Property(e => e.EstimatedInsurance)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("Estimated_Insurance");
            entity.Property(e => e.EstimatedPatientBalance)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("Estimated_Patient_Balance");
            entity.Property(e => e.EventCategory)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Event_Category");
            entity.Property(e => e.EventDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Event_DateTime");
            entity.Property(e => e.EventSponsorId).HasColumnName("Event_Sponsor_Id");
            entity.Property(e => e.EventStaffId).HasColumnName("Event_Staff_Id");
            entity.Property(e => e.EventType)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Event_Type");
            entity.Property(e => e.FinalizedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Finalized_DateTime");
            entity.Property(e => e.FinalizedStaffId).HasColumnName("Finalized_Staff_Id");
            entity.Property(e => e.GroupId).HasColumnName("Group_Id");
            entity.Property(e => e.InsuranceId).HasColumnName("Insurance_Id");
            entity.Property(e => e.IsClaimProcessed).HasColumnName("Is_Claim_Processed");
            entity.Property(e => e.IsFinalized).HasColumnName("Is_Finalized");
            entity.Property(e => e.M1)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.M2)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.M3)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.M4)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.ProcedureId).HasColumnName("Procedure_Id");
            entity.Property(e => e.ProcedureOrTransactionCodeId).HasColumnName("Procedure_Or_Transaction_Code_Id");
            entity.Property(e => e.ProviderId).HasColumnName("Provider_Id");
            entity.Property(e => e.RemovedFromReadyToBill).HasColumnName("REMOVED_FROM_READY_TO_BILL");
            entity.Property(e => e.RemovedFromReadyToBillByStaffId).HasColumnName("REMOVED_FROM_READY_TO_BILL_BY_STAFF_ID");
            entity.Property(e => e.RemovedFromReadyToBillDateTime)
                .HasColumnType("datetime")
                .HasColumnName("REMOVED_FROM_READY_TO_BILL_DATE_TIME");
            entity.Property(e => e.ServiceOrPaymentDate).HasColumnName("Service_Or_Payment_Date");
            entity.Property(e => e.Tax).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.Units).HasColumnName("UNITS");
        });

        modelBuilder.Entity<FinalizeAndClaimEventsTempEoyFix>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("FINALIZE_AND_CLAIM_EVENTS_TEMP_EOY_FIX");

            entity.Property(e => e.EventId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Event_Id");
            entity.Property(e => e.FinalizedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Finalized_DateTime");
        });

        modelBuilder.Entity<FinalizeAndClaimEventsWholeTableTempEoyFix>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("FINALIZE_AND_CLAIM_EVENTS_WHOLE_TABLE_TEMP_EOY_FIX");

            entity.Property(e => e.Amount).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.Batch)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.BillingLocationId).HasColumnName("Billing_Location_Id");
            entity.Property(e => e.ClaimProcessedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Claim_Processed_DateTime");
            entity.Property(e => e.ClaimProcessedStaffId).HasColumnName("Claim_Processed_Staff_Id");
            entity.Property(e => e.Diagnosis1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Diagnosis_1");
            entity.Property(e => e.Diagnosis2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Diagnosis_2");
            entity.Property(e => e.Diagnosis3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Diagnosis_3");
            entity.Property(e => e.Diagnosis4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Diagnosis_4");
            entity.Property(e => e.EstimatedInsurance)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("Estimated_Insurance");
            entity.Property(e => e.EstimatedPatientBalance)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("Estimated_Patient_Balance");
            entity.Property(e => e.EventCategory)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Event_Category");
            entity.Property(e => e.EventDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Event_DateTime");
            entity.Property(e => e.EventId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Event_Id");
            entity.Property(e => e.EventSponsorId).HasColumnName("Event_Sponsor_Id");
            entity.Property(e => e.EventStaffId).HasColumnName("Event_Staff_Id");
            entity.Property(e => e.EventType)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Event_Type");
            entity.Property(e => e.FinalizedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Finalized_DateTime");
            entity.Property(e => e.FinalizedStaffId).HasColumnName("Finalized_Staff_Id");
            entity.Property(e => e.GroupId).HasColumnName("Group_Id");
            entity.Property(e => e.InsuranceId).HasColumnName("Insurance_Id");
            entity.Property(e => e.IsClaimProcessed).HasColumnName("Is_Claim_Processed");
            entity.Property(e => e.IsFinalized).HasColumnName("Is_Finalized");
            entity.Property(e => e.M1)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.M2)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.M3)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.M4)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.ProcedureId).HasColumnName("Procedure_Id");
            entity.Property(e => e.ProcedureOrTransactionCodeId).HasColumnName("Procedure_Or_Transaction_Code_Id");
            entity.Property(e => e.ProviderId).HasColumnName("Provider_Id");
            entity.Property(e => e.ServiceOrPaymentDate).HasColumnName("Service_Or_Payment_Date");
            entity.Property(e => e.Tax).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.Units).HasColumnName("UNITS");
        });

        modelBuilder.Entity<FinalizeClaimAndDepositSlipReportDetail>(entity =>
        {
            entity.ToTable("FINALIZE_CLAIM_AND_DEPOSIT_SLIP_REPORT_DETAILS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DepositSlipFilePath)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Deposit_Slip_File_Path");
            entity.Property(e => e.IsFinalizeReport).HasColumnName("Is_Finalize_Report");
            entity.Property(e => e.ReportDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Report_Date_Time");
            entity.Property(e => e.ReportFilePath)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Report_File_Path");
            entity.Property(e => e.StaffId).HasColumnName("Staff_ID");
        });

        modelBuilder.Entity<FourPatientCareInformation>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("FOUR_PATIENT_CARE_INFORMATION");

            entity.Property(e => e.ApplicationLastUpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Application_Last_Updated_DateTime");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("Create_Date");
            entity.Property(e => e.VersionNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("Version_Number");
            entity.Property(e => e._4pcLoginName)
                .HasMaxLength(550)
                .IsUnicode(false)
                .HasColumnName("4PC_Login_Name");
            entity.Property(e => e._4pcLoginPassword)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("4PC_Login_Password");
        });

        modelBuilder.Entity<FoxOpticalVersionHistory>(entity =>
        {
            entity.HasKey(e => e.FoxOpticalVersionId);

            entity.ToTable("FoxOpticalVersionHistory");

            entity.Property(e => e.VersionCopyright)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.VersionDate).HasColumnType("datetime");
            entity.Property(e => e.VersionNo)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Frame>(entity =>
        {
            entity.HasKey(e => e.FrameId).HasName("PK__Frames__1B0907CE");

            entity.HasIndex(e => new { e.StyleName, e.Eye, e.Temple, e.Bridge, e.ManufacturerId, e.BrandId, e.FrameColorId }, "IX_Frames");

            entity.Property(e => e.FrameId).HasColumnName("FrameID");
            entity.Property(e => e.A).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.AgeGroupId).HasColumnName("AgeGroupID");
            entity.Property(e => e.B).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.BrandId).HasColumnName("BrandID");
            entity.Property(e => e.Circumference).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.CollectionId).HasColumnName("CollectionID");
            entity.Property(e => e.CompletePrice).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.Cptid).HasColumnName("CPTID");
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Dbl)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("DBL");
            entity.Property(e => e.Ed)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("ED");
            entity.Property(e => e.Edangle)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("EDAngle");
            entity.Property(e => e.Fpc)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("FPC");
            entity.Property(e => e.FrameCategoryId).HasColumnName("FrameCategoryID");
            entity.Property(e => e.FrameColorId).HasColumnName("FrameColorID");
            entity.Property(e => e.FrameMountId).HasColumnName("FrameMountID");
            entity.Property(e => e.FrameShapeId).HasColumnName("FrameShapeID");
            entity.Property(e => e.FrontPrice).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.GenderId).HasColumnName("GenderID");
            entity.Property(e => e.HalfTemplesPrice).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.LastUpdated).HasColumnType("datetime");
            entity.Property(e => e.LensColorId).HasColumnName("LensColorID");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");
            entity.Property(e => e.MaterialId).HasColumnName("MaterialID");
            entity.Property(e => e.Sku)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("SKU");
            entity.Property(e => e.StyleId).HasColumnName("StyleID");
            entity.Property(e => e.StyleName)
                .HasMaxLength(37)
                .IsUnicode(false);
            entity.Property(e => e.TemplesPrice).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.Upc)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("UPC");
            entity.Property(e => e.VendorId).HasColumnName("VendorID");
            entity.Property(e => e.YearIntroduced)
                .HasMaxLength(4)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FrameCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__FrameStyle__00551192");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryDescription)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CategoryName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
        });

        modelBuilder.Entity<FrameCollection>(entity =>
        {
            entity.HasKey(e => e.CollectionId);

            entity.Property(e => e.CollectionId).HasColumnName("CollectionID");
            entity.Property(e => e.CollectionName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
        });

        modelBuilder.Entity<FrameColor>(entity =>
        {
            entity.Property(e => e.FrameColorId).HasColumnName("FrameColorID");
            entity.Property(e => e.ColorCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ColorDescription)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
        });

        modelBuilder.Entity<FrameDblensColor>(entity =>
        {
            entity.HasKey(e => e.LensColorId).HasName("PK_LensColors");

            entity.ToTable("FrameDBLensColors");

            entity.Property(e => e.LensColorId).HasColumnName("LensColorID");
            entity.Property(e => e.ColorCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ColorDescription)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
        });

        modelBuilder.Entity<FrameEtype>(entity =>
        {
            entity.HasKey(e => e.EtypeId);

            entity.ToTable("FrameETypes");

            entity.Property(e => e.EtypeId).HasColumnName("ETypeId");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Etype)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EType");
            entity.Property(e => e.LabCode)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FrameFtype>(entity =>
        {
            entity.HasKey(e => e.FtypeId);

            entity.ToTable("FrameFTypes");

            entity.Property(e => e.FtypeId).HasColumnName("FTypeId");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Ftype)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FType");
            entity.Property(e => e.LabCode)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FrameMaterial>(entity =>
        {
            entity.HasKey(e => e.MaterialId).HasName("PK__FrameMaterial__07F6335A");

            entity.ToTable("FrameMaterial");

            entity.Property(e => e.MaterialId).HasColumnName("MaterialID");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.MaterialDescription)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.MaterialName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FrameMount>(entity =>
        {
            entity.Property(e => e.FrameMountId).HasColumnName("FrameMountID");
            entity.Property(e => e.FrameMount1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FrameMount");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.MountDescription)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FrameOrderInfo>(entity =>
        {
            entity.ToTable("FrameOrderInfo");

            entity.Property(e => e.A).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.B).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Color)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Csize)
                .HasColumnType("decimal(8, 1)")
                .HasColumnName("CSize");
            entity.Property(e => e.Dbl).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Ed).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.EtypId).HasColumnName("ETypId");
            entity.Property(e => e.FtypId).HasColumnName("FTypId");
            entity.Property(e => e.IsLmsframe).HasColumnName("IsLMSFrame");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Retail).HasColumnType("money");
        });

        modelBuilder.Entity<FrameShape>(entity =>
        {
            entity.HasKey(e => e.ShapeId);

            entity.Property(e => e.ShapeId).HasColumnName("ShapeID");
            entity.Property(e => e.FrameShape1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FrameShape");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.ShapeDescription)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FrameStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId);

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LabCode)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FrameTempleStyle>(entity =>
        {
            entity.HasKey(e => e.TempleId);

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LabCode)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Temple)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GenderGroup>(entity =>
        {
            entity.HasKey(e => e.GenderId).HasName("PK__GenderGroup__7E6CC920");

            entity.ToTable("GenderGroup");

            entity.Property(e => e.GenderId).HasColumnName("GenderID");
            entity.Property(e => e.GenderDescription)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.GenderName)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GeneralId>(entity =>
        {
            entity.HasKey(e => e.GeneralId1);

            entity.ToTable("GeneralIDs");

            entity.Property(e => e.GeneralId1).HasColumnName("GeneralID");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.DisplayValue)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GeneralOption>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.AcctNumberFormat).HasDefaultValue(1);
            entity.Property(e => e.AddNewPatient).HasDefaultValue(true);
            entity.Property(e => e.AllowTransactionCodesEdit).HasColumnName("Allow_Transaction_Codes_Edit");
            entity.Property(e => e.AltAccountNumLabel)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Alt_Account_Num_Label");
            entity.Property(e => e.BackupFilePath)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("Backup_File_Path");
            entity.Property(e => e.BillByProvider).HasColumnName("Bill_By_Provider");
            entity.Property(e => e.CcbChargeEligibilityDaysAfterFinalNotice).HasColumnName("CCB_CHARGE_ELIGIBILITY_DAYS_AFTER_FINAL_NOTICE");
            entity.Property(e => e.CcbInsuranceId).HasColumnName("CCB_INSURANCE_ID");
            entity.Property(e => e.CcbServerName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("CCB_SERVER_NAME");
            entity.Property(e => e.CcbServerPassword)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("CCB_SERVER_PASSWORD");
            entity.Property(e => e.CcbServerPortNumber).HasColumnName("CCB_SERVER_PORT_NUMBER");
            entity.Property(e => e.CcbServerUserName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("CCB_SERVER_USER_NAME");
            entity.Property(e => e.CcbUpdatePatientOnholdValue).HasColumnName("CCB_UPDATE_PATIENT_ONHOLD_VALUE");
            entity.Property(e => e.DisplayEhrChargesReversalQuestion).HasColumnName("DISPLAY_EHR_CHARGES_REVERSAL_QUESTION");
            entity.Property(e => e.EhrOrders).HasColumnName("EHR_ORDERS");
            entity.Property(e => e.ElectronicStatements)
                .HasDefaultValue(true)
                .HasColumnName("Electronic_Statements");
            entity.Property(e => e.EmailStatements).HasColumnName("Email_Statements");
            entity.Property(e => e.EomAndEoyDatabaseBackupEnabled)
                .HasDefaultValue(true)
                .HasColumnName("EOM_And_EOY_Database_Backup_Enabled");
            entity.Property(e => e.Icd10only).HasColumnName("ICD10Only");
            entity.Property(e => e.Icd9only).HasColumnName("ICD9Only");
            entity.Property(e => e.IncludePreFfpm50Orders)
                .HasDefaultValue(false)
                .HasColumnName("Include_Pre_FFPM_50_Orders");
            entity.Property(e => e.IncludeTransactionsWithChargesToExternalSystem).HasColumnName("Include_Transactions_With_Charges_To_External_System");
            entity.Property(e => e.IsBillingCustomer).HasColumnName("IS_BILLING_CUSTOMER");
            entity.Property(e => e.IsCcbActive).HasColumnName("IS_CCB_ACTIVE");
            entity.Property(e => e.IsLmsActive).HasColumnName("IS_LMS_ACTIVE");
            entity.Property(e => e.LockDownSendChargesToExternalSystemButtonAndOrderChargesAndTransactions).HasColumnName("LOCK_DOWN_SEND_CHARGES_TO_EXTERNAL_SYSTEM_BUTTON_AND_ORDER_CHARGES_AND_TRANSACTIONS");
            entity.Property(e => e.LockDownSendChargesToExternalSystemButtonOnly).HasColumnName("LOCK_DOWN_SEND_CHARGES_TO_EXTERNAL_SYSTEM_BUTTON_ONLY");
            entity.Property(e => e.MonthEndReminderDays).HasColumnName("Month_End_Reminder_Days");
            entity.Property(e => e.NextStatementDueDays)
                .HasDefaultValue(30)
                .HasColumnName("Next_Statement_Due_Days");
            entity.Property(e => e.OpenEdgeApiKey)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("OPEN_EDGE_API_KEY");
            entity.Property(e => e.OpenEdgeApiSecret)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("OPEN_EDGE_API_SECRET");
            entity.Property(e => e.OpenEdgeAutomaticallyAddCompletedFormsActive).HasColumnName("OPEN_EDGE_AUTOMATICALLY_ADD_COMPLETED_FORMS_ACTIVE");
            entity.Property(e => e.OpenEdgeBaseUrl)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("OPEN_EDGE_BASE_URL");
            entity.Property(e => e.OpenEdgeCallpopActive).HasColumnName("OPEN_EDGE_CALLPOP_ACTIVE");
            entity.Property(e => e.OpenEdgeElectronicStatementAdditionallySendStatementToEdiAgingBucketValue).HasColumnName("OPEN_EDGE_ELECTRONIC_STATEMENT_ADDITIONALLY_SEND_STATEMENT_TO_EDI_AGING_BUCKET_VALUE");
            entity.Property(e => e.OpenEdgeElectronicStatementPaymentsProcessingInterval)
                .HasDefaultValue(15)
                .HasColumnName("OPEN_EDGE_ELECTRONIC_STATEMENT_PAYMENTS_PROCESSING_INTERVAL");
            entity.Property(e => e.OpenEdgeElectronicStatements).HasColumnName("OPEN_EDGE_ELECTRONIC_STATEMENTS");
            entity.Property(e => e.OpenEdgeFormsActive).HasColumnName("OPEN_EDGE_FORMS_ACTIVE");
            entity.Property(e => e.OpenEdgeFormsDemographicsOndemandFormOnly).HasColumnName("OPEN_EDGE_FORMS_DEMOGRAPHICS_ONDEMAND_FORM_ONLY");
            entity.Property(e => e.SelectEmailOrTextStatementAutomatically).HasColumnName("SELECT_EMAIL_OR_TEXT_STATEMENT_AUTOMATICALLY");
            entity.Property(e => e.SendChargeToExternalSystem).HasColumnName("Send_Charge_To_External_System");
            entity.Property(e => e.SendDemographicPaymentsToExternalSystem).HasDefaultValue(true);
            entity.Property(e => e.SendToPmactive)
                .HasDefaultValue(true)
                .HasColumnName("SendToPMActive");
            entity.Property(e => e.ShowAltAccountNumber).HasDefaultValue(false);
            entity.Property(e => e.UpdatePatient).HasDefaultValue(true);
            entity.Property(e => e.UpdatePatientInScheduling).HasDefaultValue(true);
            entity.Property(e => e.VmMigrated).HasColumnName("VM_MIGRATED");
            entity.Property(e => e.YearEndMonth)
                .HasDefaultValue(12)
                .HasColumnName("Year_End_Month");
        });

        modelBuilder.Entity<GeneralOptionsTempEoyFix>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("GeneralOptions_TEMP_EOY_FIX");

            entity.Property(e => e.AllowTransactionCodesEdit).HasColumnName("Allow_Transaction_Codes_Edit");
            entity.Property(e => e.AltAccountNumLabel)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Alt_Account_Num_Label");
            entity.Property(e => e.BackupFilePath)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Backup_File_Path");
            entity.Property(e => e.BillByProvider).HasColumnName("Bill_By_Provider");
            entity.Property(e => e.ElectronicStatements).HasColumnName("Electronic_Statements");
            entity.Property(e => e.EmailStatements).HasColumnName("Email_Statements");
            entity.Property(e => e.EomAndEoyDatabaseBackupEnabled).HasColumnName("EOM_And_EOY_Database_Backup_Enabled");
            entity.Property(e => e.Icd10only).HasColumnName("ICD10Only");
            entity.Property(e => e.Icd9only).HasColumnName("ICD9Only");
            entity.Property(e => e.IncludePreFfpm50Orders).HasColumnName("Include_Pre_FFPM_50_Orders");
            entity.Property(e => e.IncludeTransactionsWithChargesToExternalSystem).HasColumnName("Include_Transactions_With_Charges_To_External_System");
            entity.Property(e => e.MonthEndReminderDays).HasColumnName("Month_End_Reminder_Days");
            entity.Property(e => e.NextStatementDueDays).HasColumnName("Next_Statement_Due_Days");
            entity.Property(e => e.SendChargeToExternalSystem).HasColumnName("Send_Charge_To_External_System");
            entity.Property(e => e.SendToPmactive).HasColumnName("SendToPMActive");
            entity.Property(e => e.YearEndMonth).HasColumnName("Year_End_Month");
        });

        modelBuilder.Entity<GetBalanceDueOrdersView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetBalanceDueOrdersView");

            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Balance).HasColumnName("BALANCE");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
        });

        modelBuilder.Entity<GetLocationInformationAndCountsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetLocationInformationAndCountsView");

            entity.Property(e => e.Companyname)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("COMPANYNAME");
            entity.Property(e => e.Fsgaccountingcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FSGACCOUNTINGCODE");
            entity.Property(e => e.Last4pcEventDate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last 4PC EventDate");
            entity.Property(e => e.Locationname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOCATIONNAME");
            entity.Property(e => e.TotalAppointments).HasColumnName("Total Appointments");
            entity.Property(e => e.TotalAppointmentsWithRecallsAttached).HasColumnName("Total Appointments With Recalls Attached");
            entity.Property(e => e.TotalEhrCharges).HasColumnName("Total EHR Charges");
            entity.Property(e => e.TotalPositiveBalanceDueOrders).HasColumnName("Total Positive Balance Due Orders");
            entity.Property(e => e.TotalRecalls).HasColumnName("Total Recalls");
            entity.Property(e => e.TotalUnAttachedEhrCharges).HasColumnName("Total UnAttached EHR Charges");
            entity.Property(e => e.TotalZeroBalanceDueOrders).HasColumnName("Total Zero Balance Due Orders");
            entity.Property(e => e.Version)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("VERSION");
        });

        modelBuilder.Entity<GetOrderchargesDatesCount>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GET_ORDERCHARGES_DATES_COUNT");

            entity.Property(e => e.AccountNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Account_Number");
            entity.Property(e => e.AdmitDate).HasColumnType("datetime");
            entity.Property(e => e.Cause)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CauseDate).HasColumnType("datetime");
            entity.Property(e => e.ChargeName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DischargeDate).HasColumnType("datetime");
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
        });

        modelBuilder.Entity<GpnChargeTransactionCodesView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_CHARGE_TRANSACTION_CODES_VIEW");

            entity.Property(e => e.CreditOrDebitOrDesc)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Credit_Or_Debit_Or_Desc");
            entity.Property(e => e.IsPatientPayment).HasColumnName("Is_Patient_Payment");
            entity.Property(e => e.LocationId).HasColumnName("Location_Id");
            entity.Property(e => e.PaymentTypeId).HasColumnName("Payment_Type_Id");
            entity.Property(e => e.TransactionCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Transaction_Code");
            entity.Property(e => e.TransactionCodeDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Transaction_Code_Description");
            entity.Property(e => e.TransactionCodeId).HasColumnName("Transaction_Code_Id");
            entity.Property(e => e.TransactionCodeName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Transaction_Code_Name");
            entity.Property(e => e.TransactionTypeActive).HasColumnName("Transaction_Type_Active");
            entity.Property(e => e.TransactionTypeId).HasColumnName("Transaction_Type_Id");
        });

        modelBuilder.Entity<GpnChargeTransactionTypesView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_CHARGE_TRANSACTION_TYPES_VIEW");

            entity.Property(e => e.TransactionType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Transaction_Type");
            entity.Property(e => e.TransactionTypeActive).HasColumnName("Transaction_Type_Active");
            entity.Property(e => e.TransactionTypeDescripton)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Transaction_Type_Descripton");
            entity.Property(e => e.TransactionTypeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Transaction_Type_Id");
        });

        modelBuilder.Entity<GpnContactLensBrandsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_CONTACT_LENS_BRANDS_VIEW");

            entity.Property(e => e.BrandId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Brand_Id");
            entity.Property(e => e.BrandName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Brand_Name");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.LocationId).HasColumnName("Location_Id");
        });

        modelBuilder.Entity<GpnContactLensManufacturersView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_CONTACT_LENS_MANUFACTURERS_VIEW");

            entity.Property(e => e.ContactLensManufacturerCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Contact_Lens_Manufacturer_Code");
            entity.Property(e => e.ContactLensManufacturerId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Contact_Lens_Manufacturer_Id");
            entity.Property(e => e.ContactLensManufacturerName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Contact_Lens_Manufacturer_Name");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.LocationId).HasColumnName("Location_Id");
        });

        modelBuilder.Entity<GpnCptDepartmentsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_CPT_DEPARTMENTS_VIEW");

            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DepartmentId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Department_Id");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.LocationId).HasColumnName("Location_Id");
        });

        modelBuilder.Entity<GpnCptTypeOfSerivcesView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_CPT_TYPE_OF_SERIVCES_VIEW");

            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.LocationId).HasColumnName("Location_Id");
            entity.Property(e => e.TypeOfServiceDescription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Type_Of_Service_Description");
            entity.Property(e => e.TypeOfServiceId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Type_Of_Service_Id");
        });

        modelBuilder.Entity<GpnCptView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_CPT_VIEW");

            entity.Property(e => e.Cpt)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CPT");
            entity.Property(e => e.CptFee)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("CPT_Fee");
            entity.Property(e => e.CptId)
                .ValueGeneratedOnAdd()
                .HasColumnName("CPT_ID");
            entity.Property(e => e.DepartmentId).HasColumnName("Department_Id");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.IsTaxable).HasColumnName("Is_Taxable");
            entity.Property(e => e.LocationId).HasColumnName("Location_Id");
            entity.Property(e => e.TaxTypeId).HasColumnName("Tax_Type_Id");
            entity.Property(e => e.TypeOfServiceId).HasColumnName("Type_Of_Service_Id");
        });

        modelBuilder.Entity<GpnFrameBrandView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_FRAME_BRAND_VIEW");

            entity.Property(e => e.FrameBrandId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Frame_BRAND_Id");
            entity.Property(e => e.FrameBrandName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("FRAME_BRAND_NAME");
            entity.Property(e => e.LocationId).HasColumnName("Location_Id");
        });

        modelBuilder.Entity<GpnFrameCategoryView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_FRAME_CATEGORY_VIEW");

            entity.Property(e => e.FrameCategoryId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Frame_Category_Id");
            entity.Property(e => e.FrameCategoryName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Frame_Category_Name");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.LocationId).HasColumnName("Location_Id");
        });

        modelBuilder.Entity<GpnFrameCollectionView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_FRAME_COLLECTION_VIEW");

            entity.Property(e => e.FrameCollectionId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Frame_Collection_Id");
            entity.Property(e => e.FrameCollectionName)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Frame_Collection_Name");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.LocationId).HasColumnName("Location_Id");
        });

        modelBuilder.Entity<GpnFrameColorsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_FRAME_COLORS_VIEW");

            entity.Property(e => e.FrameColor)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Frame_Color");
            entity.Property(e => e.FrameColorId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Frame_Color_Id");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.LocationId).HasColumnName("Location_Id");
        });

        modelBuilder.Entity<GpnFrameEtypeView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_FRAME_ETYPE_VIEW");

            entity.Property(e => e.FrameEtype)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Frame_Etype");
            entity.Property(e => e.FrameEtypeCode)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Frame_Etype_Code");
            entity.Property(e => e.FrameEtypeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Frame_Etype_Id");
        });

        modelBuilder.Entity<GpnFrameFtypeView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_FRAME_FTYPE_VIEW");

            entity.Property(e => e.FrameFtype)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Frame_Ftype");
            entity.Property(e => e.FrameFtypeCode)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Frame_Ftype_Code");
            entity.Property(e => e.FrameFtypeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Frame_Ftype_Id");
        });

        modelBuilder.Entity<GpnFrameInventoryView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_FRAME_INVENTORY_VIEW");

            entity.Property(e => e.Barcode)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.Cost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.FrameId).HasColumnName("FRAME_ID");
            entity.Property(e => e.InventoryId)
                .ValueGeneratedOnAdd()
                .HasColumnName("INVENTORY_ID");
            entity.Property(e => e.InvoiceDate).HasColumnType("datetime");
            entity.Property(e => e.InvoiceNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LocationId).HasColumnName("LOCATION_ID");
            entity.Property(e => e.Note).IsUnicode(false);
            entity.Property(e => e.Retail).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.WholeSale).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<GpnFrameManufacturerView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_FRAME_MANUFACTURER_VIEW");

            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(e => e.LocationId).HasColumnName("Location_Id");
            entity.Property(e => e.ManufacturerId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Manufacturer_Id");
            entity.Property(e => e.ManufacturerName)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Manufacturer_Name");
        });

        modelBuilder.Entity<GpnFrameMaterialView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_FRAME_MATERIAL_VIEW");

            entity.Property(e => e.FrameColor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Frame_Color");
            entity.Property(e => e.FrameMaterialId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Frame_Material_Id");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.LocationId).HasColumnName("Location_Id");
        });

        modelBuilder.Entity<GpnFrameMountsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_FRAME_MOUNTS_VIEW");

            entity.Property(e => e.FrameMount)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Frame_Mount");
            entity.Property(e => e.FrameMountId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Frame_Mount_Id");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.LocationId).HasColumnName("Location_Id");
        });

        modelBuilder.Entity<GpnFrameShapesView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_FRAME_SHAPES_VIEW");

            entity.Property(e => e.FrameShape)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Frame_Shape");
            entity.Property(e => e.FrameShapeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Frame_Shape_Id");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.LocationId).HasColumnName("Location_Id");
        });

        modelBuilder.Entity<GpnFrameStatusView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_FRAME_STATUS_VIEW");

            entity.Property(e => e.FrameStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Frame_Status");
            entity.Property(e => e.FrameStatusId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Frame_Status_Id");
            entity.Property(e => e.FrameStatusLabCode)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Frame_Status_Lab_Code");
        });

        modelBuilder.Entity<GpnFrameTempleStylesView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_FRAME_TEMPLE_STYLES_VIEW");

            entity.Property(e => e.FrameTempleCode)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Frame_Temple_Code");
            entity.Property(e => e.FrameTempleStyle)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Frame_Temple_Style");
            entity.Property(e => e.FrameTempleStyleId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Frame_Temple_Style_Id");
        });

        modelBuilder.Entity<GpnFrameVendorView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_FRAME_VENDOR_VIEW");

            entity.Property(e => e.LocationId).HasColumnName("Location_Id");
            entity.Property(e => e.ManufacturerId).HasColumnName("Manufacturer_Id");
            entity.Property(e => e.VendorAccountRep)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Vendor_Account_Rep");
            entity.Property(e => e.VendorId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Vendor_Id");
            entity.Property(e => e.VendorName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Vendor_Name");
        });

        modelBuilder.Entity<GpnFramesView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_FRAMES_VIEW");

            entity.Property(e => e.A).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.B).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.BrandId).HasColumnName("Brand_Id");
            entity.Property(e => e.Circumference).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.CollectionId).HasColumnName("Collection_Id");
            entity.Property(e => e.CompletePrice).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.CptId).HasColumnName("Cpt_Id");
            entity.Property(e => e.DateAdded)
                .HasColumnType("datetime")
                .HasColumnName("Date_Added");
            entity.Property(e => e.Dbl)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("DBL");
            entity.Property(e => e.Ed)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("ED");
            entity.Property(e => e.Edangle)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("EDAngle");
            entity.Property(e => e.FrameCategoryId).HasColumnName("Frame_Category_Id");
            entity.Property(e => e.FrameColorId).HasColumnName("Frame_Color_Id");
            entity.Property(e => e.FrameFpc)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("Frame_FPC");
            entity.Property(e => e.FrameId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Frame_Id");
            entity.Property(e => e.FrameMaterialId).HasColumnName("Frame_Material_Id");
            entity.Property(e => e.FrameMountId).HasColumnName("Frame_Mount_Id");
            entity.Property(e => e.FrameShapeId).HasColumnName("Frame_Shape_Id");
            entity.Property(e => e.FrameStyleId).HasColumnName("Frame_Style_Id");
            entity.Property(e => e.FrameStyleName)
                .HasMaxLength(37)
                .IsUnicode(false)
                .HasColumnName("Frame_Style_Name");
            entity.Property(e => e.FrameUpc)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("Frame_UPC");
            entity.Property(e => e.FrontPrice).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.HalfTemplesPrice).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.LastUpdated)
                .HasColumnType("datetime")
                .HasColumnName("Last_Updated");
            entity.Property(e => e.LocationId).HasColumnName("Location_Id");
            entity.Property(e => e.ManufacturerId).HasColumnName("Manufacturer_Id");
            entity.Property(e => e.Sku)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("SKU");
            entity.Property(e => e.TemplesPrice).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.VendorId).HasColumnName("Vendor_Id");
            entity.Property(e => e.YearIntroduced)
                .HasMaxLength(4)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GpnIhFrameTypeView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_IH_FRAME_TYPE_VIEW");

            entity.Property(e => e.IhFrameTypeCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("IH_Frame_Type_Code");
            entity.Property(e => e.IhFrameTypeDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("IH_FRAME_TYPE_Description");
            entity.Property(e => e.IhFrameTypeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("IH_Frame_Type_Id");
        });

        modelBuilder.Entity<GpnIhLensDesignView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_IH_LENS_DESIGN_VIEW");

            entity.Property(e => e.IhLensDesignCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("IH_Lens_Design_Code");
            entity.Property(e => e.IhLensDesignDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("IH_Lens_Design_Description");
            entity.Property(e => e.IhLensDesignId)
                .ValueGeneratedOnAdd()
                .HasColumnName("IH_Lens_Design_Id");
            entity.Property(e => e.IhLensTypeId).HasColumnName("IH_Lens_Type_Id");
        });

        modelBuilder.Entity<GpnIhLensMaterialView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_IH_LENS_MATERIAL_VIEW");

            entity.Property(e => e.IhLensMaterialCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("IH_Lens_Material_Code");
            entity.Property(e => e.IhLensMaterialDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("IH_Lens_Material_Description");
            entity.Property(e => e.IhLensMaterialId)
                .ValueGeneratedOnAdd()
                .HasColumnName("IH_Lens_Material_Id");
        });

        modelBuilder.Entity<GpnIhLensTypesView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_IH_LENS_TYPES_VIEW");

            entity.Property(e => e.IhLensTypeCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("IH_Lens_Type_Code");
            entity.Property(e => e.IhLensTypeDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("IH_Lens_Type_Description");
            entity.Property(e => e.IhLensTypeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("IH_Lens_Type_Id");
        });

        modelBuilder.Entity<GpnIhTreatmentsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_IH_TREATMENTS_VIEW");

            entity.Property(e => e.IhTreatmentCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("IH_TREATMENT_Code");
            entity.Property(e => e.IhTreatmentDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("IH_TREATMENT_Description");
            entity.Property(e => e.IhTreatmentId)
                .ValueGeneratedOnAdd()
                .HasColumnName("IH_TREATMENT_Id");
        });

        modelBuilder.Entity<GpnInformation>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("GPN_INFORMATION");

            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("Create_Date");
            entity.Property(e => e.GpnLoginName)
                .HasMaxLength(550)
                .IsUnicode(false)
                .HasColumnName("GPN_Login_Name");
            entity.Property(e => e.GpnLoginPassword)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("GPN_Login_Password");
        });

        modelBuilder.Entity<GpnInsuranceCompaniesView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_INSURANCE_COMPANIES_VIEW");

            entity.Property(e => e.AdjustmentTransactionCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Adjustment_Transaction_Code");
            entity.Property(e => e.InsCompanyAddress1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Address_1");
            entity.Property(e => e.InsCompanyAddress2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Address_2");
            entity.Property(e => e.InsCompanyCity)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_City");
            entity.Property(e => e.InsCompanyCode)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Code");
            entity.Property(e => e.InsCompanyCountryId).HasColumnName("Ins_Company_Country_Id");
            entity.Property(e => e.InsCompanyEmail)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Email");
            entity.Property(e => e.InsCompanyId).HasColumnName("Ins_Company_Id");
            entity.Property(e => e.InsCompanyName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Name");
            entity.Property(e => e.InsCompanyPayerId)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Payer_Id");
            entity.Property(e => e.InsCompanyPhone)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Phone");
            entity.Property(e => e.InsCompanyState)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_State");
            entity.Property(e => e.InsCompanyWebsite)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Website");
            entity.Property(e => e.InsCompanyZip)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Zip");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.IsCollectionsInsurance).HasColumnName("Is_Collections_Insurance");
            entity.Property(e => e.IsCompanyInsurance).HasColumnName("Is_Company_Insurance");
            entity.Property(e => e.PaymentTransactionCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Payment_Transaction_Code");
            entity.Property(e => e.PmCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PM_Code");
            entity.Property(e => e.Responsibility)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GpnInsurancePlansView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_INSURANCE_PLANS_VIEW");

            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.PlanCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Plan_Code");
            entity.Property(e => e.PlanDescription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Plan_Description");
            entity.Property(e => e.PlanId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Plan_Id");
            entity.Property(e => e.PlanInsCompanyId).HasColumnName("Plan_Ins_Company_Id");
            entity.Property(e => e.PlanStartDate).HasColumnName("Plan_Start_Date");
        });

        modelBuilder.Entity<GpnLabsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_LABS_VIEW");

            entity.Property(e => e.InHouseVisionWebLab).HasColumnName("In_House_Vision_Web_Lab");
            entity.Property(e => e.LabActive).HasColumnName("Lab_Active");
            entity.Property(e => e.LabId).HasColumnName("Lab_Id");
            entity.Property(e => e.LabName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Lab_Name");
            entity.Property(e => e.LocationId).HasColumnName("Location_Id");
        });

        modelBuilder.Entity<GpnLensCoatsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_LENS_COATS_VIEW");

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LensCoat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Lens_Coat");
            entity.Property(e => e.LensCoatCode)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Lens_Coat_Code");
            entity.Property(e => e.LensCoatId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Lens_Coat_Id");
        });

        modelBuilder.Entity<GpnLensColorsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_LENS_COLORS_VIEW");

            entity.Property(e => e.Color)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ColorCode)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Color_Code");
            entity.Property(e => e.ColorDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Color_Description");
            entity.Property(e => e.ColorId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Color_Id");
        });

        modelBuilder.Entity<GpnLensMaterialsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_LENS_MATERIALS_VIEW");

            entity.Property(e => e.LensMaterial)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Lens_Material");
            entity.Property(e => e.LensMaterialCode)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Lens_Material_Code");
            entity.Property(e => e.LensMaterialDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Lens_Material_Description");
            entity.Property(e => e.LensMaterialId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Lens_Material_Id");
            entity.Property(e => e.LensMaterialInde)
                .HasColumnType("decimal(6, 3)")
                .HasColumnName("Lens_Material_Inde");
        });

        modelBuilder.Entity<GpnLensServiceView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_LENS_SERVICE_VIEW");

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LensService)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Lens_Service");
            entity.Property(e => e.LensServiceId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Lens_Service_Id");
            entity.Property(e => e.LensTintCode)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Lens_Tint_Code");
        });

        modelBuilder.Entity<GpnLensStylesView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_LENS_STYLES_VIEW");

            entity.Property(e => e.LensStyleCode)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Lens_Style_Code");
            entity.Property(e => e.LensStyleId).HasColumnName("Lens_Style_Id");
            entity.Property(e => e.LensStyleName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Lens_Style_Name");
        });

        modelBuilder.Entity<GpnLensTintsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_LENS_TINTS_VIEW");

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LensTint)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Lens_Tint");
            entity.Property(e => e.LensTintCode)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Lens_Tint_Code");
            entity.Property(e => e.LensTintId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Lens_Tint_Id");
        });

        modelBuilder.Entity<GpnLocationsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_LOCATIONS_VIEW");

            entity.Property(e => e.Address1)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Address2)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ContactName)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Contact_Name");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Display_Name");
            entity.Property(e => e.Fax)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.LocationId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Location_Id");
            entity.Property(e => e.LocationName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Location_Name");
            entity.Property(e => e.LocationType).HasColumnName("Location_Type");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.ZiPcode)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("ZiPCode");
        });

        modelBuilder.Entity<GpnOrderChargeTransactionsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_ORDER_CHARGE_TRANSACTIONS_VIEW");

            entity.Property(e => e.ChargeTransactionAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Charge_Transaction_Amount");
            entity.Property(e => e.ChargeTransactionBatchNumber)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("Charge_Transaction_Batch_Number");
            entity.Property(e => e.ChargeTransactionCodeId).HasColumnName("Charge_Transaction_Code_Id");
            entity.Property(e => e.ChargeTransactionCreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Charge_Transaction_Created_Date");
            entity.Property(e => e.ChargeTransactionId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Charge_Transaction_Id");
            entity.Property(e => e.ChargeTransactionModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("Charge_Transaction_Modified_Date");
            entity.Property(e => e.ChargeTransactionReference)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("Charge_Transaction_Reference");
            entity.Property(e => e.ChargeTransactionSequence).HasColumnName("Charge_Transaction_Sequence");
            entity.Property(e => e.ChargeTransactionTypeId).HasColumnName("Charge_Transaction_Type_Id");
            entity.Property(e => e.IsDeleted).HasColumnName("Is_Deleted");
            entity.Property(e => e.OrderChargeId).HasColumnName("Order_Charge_Id");
            entity.Property(e => e.PatientInsuranceId).HasColumnName("Patient_Insurance_Id");
        });

        modelBuilder.Entity<GpnOrderChargesView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_ORDER_CHARGES_VIEW");

            entity.Property(e => e.AcceptedAssignment).HasColumnName("Accepted_Assignment");
            entity.Property(e => e.ChargeRefProviderId).HasColumnName("Charge_Ref_Provider_Id");
            entity.Property(e => e.EstimatedInsuranceBalance)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("Estimated_Insurance_Balance");
            entity.Property(e => e.EstimatedPatientBalance)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("Estimated_Patient_Balance");
            entity.Property(e => e.IsChargeDeleted).HasColumnName("Is_Charge_Deleted");
            entity.Property(e => e.OrderChargeBillingLocationId).HasColumnName("Order_Charge_Billing_Location_Id");
            entity.Property(e => e.OrderChargeCategory)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Order_Charge_Category");
            entity.Property(e => e.OrderChargeCptId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Order_Charge_Cpt_Id");
            entity.Property(e => e.OrderChargeDate)
                .HasColumnType("datetime")
                .HasColumnName("Order_Charge_Date");
            entity.Property(e => e.OrderChargeDescription)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Order_Charge_Description");
            entity.Property(e => e.OrderChargeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Order_Charge_Id");
            entity.Property(e => e.OrderChargeInsuraceName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Order_Charge_Insurace_Name");
            entity.Property(e => e.OrderChargeIsTax).HasColumnName("Order_Charge_Is_Tax");
            entity.Property(e => e.OrderChargePlanId).HasColumnName("Order_Charge_Plan_Id");
            entity.Property(e => e.OrderChargeProviderId).HasColumnName("Order_Charge_Provider_Id");
            entity.Property(e => e.OrderChargeTotalCost)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Order_Charge_Total_Cost");
            entity.Property(e => e.OrderChargeUnitCost)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Order_Charge_Unit_Cost");
            entity.Property(e => e.OrderChargeUnits).HasColumnName("Order_Charge_Units");
            entity.Property(e => e.OrderId).HasColumnName("Order_Id");
            entity.Property(e => e.PatientInsuranceId).HasColumnName("Patient_Insurance_Id");
            entity.Property(e => e.ProcessClaimYesNo).HasColumnName("Process_Claim_Yes_No");
        });

        modelBuilder.Entity<GpnOrderPackageView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_ORDER_PACKAGE_VIEW");

            entity.Property(e => e.OrderPackage)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Order_Package");
            entity.Property(e => e.OrderPackageDescription)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Order_Package_Description");
            entity.Property(e => e.OrderPackageId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Order_Package_Id");
            entity.Property(e => e.OrderStatusActive).HasColumnName("Order_Status_Active");
        });

        modelBuilder.Entity<GpnOrderStatusView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_ORDER_STATUS_VIEW");

            entity.Property(e => e.OrderStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Order_Status");
            entity.Property(e => e.OrderStatusActive).HasColumnName("Order_Status_Active");
            entity.Property(e => e.OrderStatusDescription)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Order_Status_Description");
            entity.Property(e => e.OrderStatusId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Order_Status_Id");
        });

        modelBuilder.Entity<GpnPatientMedicalInsuranceView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_PATIENT_MEDICAL_INSURANCE_VIEW");

            entity.Property(e => e.InsCompanyId).HasColumnName("Ins_Company_Id");
            entity.Property(e => e.InsuranceRank).HasColumnName("Insurance_Rank");
            entity.Property(e => e.IsPolicyActive).HasColumnName("Is_Policy_Active");
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
            entity.Property(e => e.PatientInsuranceId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Patient_Insurance_Id");
            entity.Property(e => e.PolicyEndDate).HasColumnName("Policy_End_Date");
            entity.Property(e => e.PolicyNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Policy_Number");
            entity.Property(e => e.PolicyStartDate)
                .HasColumnType("datetime")
                .HasColumnName("Policy_Start_Date");
        });

        modelBuilder.Entity<GpnPatientOrderVwTreatment>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_PATIENT_ORDER_VW_TREATMENTS");

            entity.Property(e => e.LocationId).HasColumnName("Location_Id");
            entity.Property(e => e.OrderId).HasColumnName("Order_Id");
            entity.Property(e => e.TreatmentId).HasColumnName("Treatment_ID");
        });

        modelBuilder.Entity<GpnPatientOrdersView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_PATIENT_ORDERS_VIEW");

            entity.Property(e => e.AxisOd).HasColumnName("Axis_OD");
            entity.Property(e => e.AxisOs).HasColumnName("Axis_OS");
            entity.Property(e => e.BaseOd)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("Base_OD");
            entity.Property(e => e.BaseOs)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("Base_OS");
            entity.Property(e => e.BsizeOd).HasColumnName("BSize_OD");
            entity.Property(e => e.BsizeOs).HasColumnName("BSize_OS");
            entity.Property(e => e.CylinderOd)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("Cylinder_OD");
            entity.Property(e => e.CylinderOs)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("Cylinder_OS");
            entity.Property(e => e.DistanceOd)
                .HasColumnType("decimal(8, 1)")
                .HasColumnName("Distance_OD");
            entity.Property(e => e.DistanceOs)
                .HasColumnType("decimal(8, 1)")
                .HasColumnName("Distance_OS");
            entity.Property(e => e.FormOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Form_OD");
            entity.Property(e => e.FormOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Form_OS");
            entity.Property(e => e.IoOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IO_OD");
            entity.Property(e => e.IoOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IO_OS");
            entity.Property(e => e.IoPrismOd)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("IO_PRISM_OD");
            entity.Property(e => e.IoPrismOs)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("IO_PRISM_OS");
            entity.Property(e => e.NearOd)
                .HasColumnType("decimal(8, 1)")
                .HasColumnName("Near_OD");
            entity.Property(e => e.NearOs)
                .HasColumnType("decimal(8, 1)")
                .HasColumnName("Near_OS");
            entity.Property(e => e.OdContactLensAddPower)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OD_Contact_Lens_Add_Power");
            entity.Property(e => e.OdContactLensAxis)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OD_Contact_Lens_Axis");
            entity.Property(e => e.OdContactLensBaseCurve)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OD_Contact_Lens_Base_Curve");
            entity.Property(e => e.OdContactLensBrandId).HasColumnName("OD_Contact_Lens_Brand_Id");
            entity.Property(e => e.OdContactLensColor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("OD_Contact_Lens_Color");
            entity.Property(e => e.OdContactLensCylinder)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OD_Contact_Lens_Cylinder");
            entity.Property(e => e.OdContactLensDiameter)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OD_Contact_Lens_Diameter");
            entity.Property(e => e.OdContactLensPower)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OD_Contact_Lens_Power");
            entity.Property(e => e.OdContactLensPupil)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OD_Contact_Lens_Pupil");
            entity.Property(e => e.OdContactLensVaDist)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OD_Contact_Lens_VA_Dist");
            entity.Property(e => e.OdContactLensVaNear)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OD_Contact_Lens_VA_Near");
            entity.Property(e => e.OdLensAdd).HasColumnName("OD_Lens_Add");
            entity.Property(e => e.OdLensAdd2).HasColumnName("OD_Lens_Add_2");
            entity.Property(e => e.OdLensArCoatId).HasColumnName("OD_Lens_AR_Coat_Id");
            entity.Property(e => e.OdLensColorId).HasColumnName("OD_Lens_Color_Id");
            entity.Property(e => e.OdLensEc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("OD_Lens_EC");
            entity.Property(e => e.OdLensEnc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("OD_Lens_ENC");
            entity.Property(e => e.OdLensMaterialId).HasColumnName("OD_Lens_Material_Id");
            entity.Property(e => e.OdLensMode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("OD_Lens_Mode");
            entity.Property(e => e.OdLensOcHt)
                .HasColumnType("decimal(5, 1)")
                .HasColumnName("OD_Lens_OC_HT");
            entity.Property(e => e.OdLensScrCoatId).HasColumnName("OD_Lens_SCR_Coat_Id");
            entity.Property(e => e.OdLensSegHt)
                .HasColumnType("decimal(5, 1)")
                .HasColumnName("OD_Lens_Seg_Ht");
            entity.Property(e => e.OdLensService1Id).HasColumnName("OD_Lens_Service_1_Id");
            entity.Property(e => e.OdLensService2Id).HasColumnName("OD_Lens_Service_2_Id");
            entity.Property(e => e.OdLensService3Id).HasColumnName("OD_Lens_Service_3_Id");
            entity.Property(e => e.OdLensStyleId).HasColumnName("OD_Lens_Style_Id");
            entity.Property(e => e.OdLensThickness)
                .HasColumnType("decimal(5, 1)")
                .HasColumnName("OD_Lens_Thickness");
            entity.Property(e => e.OdLensTintId).HasColumnName("OD_Lens_Tint_Id");
            entity.Property(e => e.OdLensUvCoatId).HasColumnName("OD_Lens_UV_Coat_Id");
            entity.Property(e => e.OrderBatchName)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("Order_Batch_Name");
            entity.Property(e => e.OrderEnteredDate)
                .HasColumnType("datetime")
                .HasColumnName("Order_Entered_Date");
            entity.Property(e => e.OrderFrameA)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("Order_Frame_A");
            entity.Property(e => e.OrderFrameB)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("Order_Frame_B");
            entity.Property(e => e.OrderFrameBridge).HasColumnName("Order_Frame_Bridge");
            entity.Property(e => e.OrderFrameColor)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Order_Frame_Color");
            entity.Property(e => e.OrderFrameCptId).HasColumnName("Order_Frame_Cpt_Id");
            entity.Property(e => e.OrderFrameCsize)
                .HasColumnType("decimal(8, 1)")
                .HasColumnName("Order_Frame_CSize");
            entity.Property(e => e.OrderFrameDbl)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("Order_Frame_DBL");
            entity.Property(e => e.OrderFrameEd)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("Order_Frame_ED");
            entity.Property(e => e.OrderFrameEtypeId).HasColumnName("Order_Frame_EType_Id");
            entity.Property(e => e.OrderFrameEye).HasColumnName("Order_Frame_Eye");
            entity.Property(e => e.OrderFrameFtypeId).HasColumnName("Order_Frame_FType_Id");
            entity.Property(e => e.OrderFrameId).HasColumnName("Order_Frame_Id");
            entity.Property(e => e.OrderFrameInventoryId).HasColumnName("Order_Frame_Inventory_Id");
            entity.Property(e => e.OrderFrameManufacturerId).HasColumnName("Order_Frame_Manufacturer_Id");
            entity.Property(e => e.OrderFrameMaterialId).HasColumnName("Order_Frame_Material_Id");
            entity.Property(e => e.OrderFrameName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Order_Frame_Name");
            entity.Property(e => e.OrderFrameRetailPrice)
                .HasColumnType("money")
                .HasColumnName("Order_Frame_Retail_Price");
            entity.Property(e => e.OrderFrameStatusId).HasColumnName("Order_Frame_Status_Id");
            entity.Property(e => e.OrderFrameTempleSize).HasColumnName("Order_Frame_Temple_Size");
            entity.Property(e => e.OrderFrameTempleStyleId).HasColumnName("Order_Frame_Temple_Style_Id");
            entity.Property(e => e.OrderId).HasColumnName("Order_Id");
            entity.Property(e => e.OrderLabId).HasColumnName("Order_Lab_Id");
            entity.Property(e => e.OrderLastUpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Order_Last_Updated_Date");
            entity.Property(e => e.OrderLocationId).HasColumnName("Order_Location_Id");
            entity.Property(e => e.OrderPackageId).HasColumnName("Order_Package_Id");
            entity.Property(e => e.OrderProviderId).HasColumnName("Order_Provider_Id");
            entity.Property(e => e.OrderSentToPmYn).HasColumnName("Order_Sent_To_PM_YN");
            entity.Property(e => e.OrderStaffId).HasColumnName("Order_Staff_Id");
            entity.Property(e => e.OrderStatus).HasColumnName("Order_Status");
            entity.Property(e => e.OrderStatusId).HasColumnName("Order_Status_Id");
            entity.Property(e => e.OrderVwFrameBrandId).HasColumnName("Order_VW_Frame_Brand_Id");
            entity.Property(e => e.OrderVwFrameModelId).HasColumnName("Order_Vw_Frame_Model_Id");
            entity.Property(e => e.OrderVwFrameTypeId).HasColumnName("Order_Vw_Frame_Type_Id");
            entity.Property(e => e.OrderVwJobType)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("Order_VW_Job_Type");
            entity.Property(e => e.OrderVwLensDesignId).HasColumnName("Order_VW_Lens_Design_Id");
            entity.Property(e => e.OrderVwLensMaterialId).HasColumnName("Order_VW_Lens_Material_Id");
            entity.Property(e => e.OrderVwLensTypeId).HasColumnName("Order_VW_Lens_Type_Id");
            entity.Property(e => e.OrderVwSentDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Order_VW_Sent_DateTime");
            entity.Property(e => e.OrderVwSentYn)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("Order_VW_Sent_YN");
            entity.Property(e => e.OsContactLensAddPower)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OS_Contact_Lens_Add_Power");
            entity.Property(e => e.OsContactLensAxis)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OS_Contact_Lens_Axis");
            entity.Property(e => e.OsContactLensBaseCurve)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OS_Contact_Lens_Base_Curve");
            entity.Property(e => e.OsContactLensBrandId).HasColumnName("OS_Contact_Lens_Brand_Id");
            entity.Property(e => e.OsContactLensColor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("OS_Contact_Lens_Color");
            entity.Property(e => e.OsContactLensCylinder)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OS_Contact_Lens_Cylinder");
            entity.Property(e => e.OsContactLensDiameter)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OS_Contact_Lens_Diameter");
            entity.Property(e => e.OsContactLensPower)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OS_Contact_Lens_Power");
            entity.Property(e => e.OsContactLensPupil)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OS_Contact_Lens_Pupil");
            entity.Property(e => e.OsContactLensVaDist)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OS_Contact_Lens_VA_Dist");
            entity.Property(e => e.OsContactLensVaNear)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OS_Contact_Lens_VA_Near");
            entity.Property(e => e.OsLensAdd).HasColumnName("OS_Lens_Add");
            entity.Property(e => e.OsLensAdd2).HasColumnName("OS_Lens_Add_2");
            entity.Property(e => e.OsLensArCoatId).HasColumnName("OS_Lens_AR_Coat_Id");
            entity.Property(e => e.OsLensColorId).HasColumnName("OS_Lens_Color_Id");
            entity.Property(e => e.OsLensEc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("OS_Lens_EC");
            entity.Property(e => e.OsLensEnc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("OS_Lens_ENC");
            entity.Property(e => e.OsLensMaterialId).HasColumnName("OS_Lens_Material_Id");
            entity.Property(e => e.OsLensMode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("OS_Lens_Mode");
            entity.Property(e => e.OsLensOcHt)
                .HasColumnType("decimal(5, 1)")
                .HasColumnName("OS_Lens_OC_HT");
            entity.Property(e => e.OsLensScrCoatId).HasColumnName("OS_Lens_SCR_Coat_Id");
            entity.Property(e => e.OsLensSegHt)
                .HasColumnType("decimal(5, 1)")
                .HasColumnName("OS_Lens_Seg_Ht");
            entity.Property(e => e.OsLensService1Id).HasColumnName("OS_Lens_Service_1_Id");
            entity.Property(e => e.OsLensService2Id).HasColumnName("OS_Lens_Service_2_Id");
            entity.Property(e => e.OsLensService3Id).HasColumnName("OS_Lens_Service_3_Id");
            entity.Property(e => e.OsLensStyleId).HasColumnName("OS_Lens_Style_Id");
            entity.Property(e => e.OsLensThickness)
                .HasColumnType("decimal(5, 1)")
                .HasColumnName("OS_Lens_Thickness");
            entity.Property(e => e.OsLensTintId).HasColumnName("OS_Lens_Tint_Id");
            entity.Property(e => e.OsLensUvCoatId).HasColumnName("OS_Lens_UV_Coat_Id");
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
            entity.Property(e => e.SphereOd)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("Sphere_OD");
            entity.Property(e => e.SphereOs)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("Sphere_OS");
            entity.Property(e => e.UdOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UD_OD");
            entity.Property(e => e.UdOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UD_OS");
            entity.Property(e => e.UdPrismOd)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("UD_PRISM_OD");
            entity.Property(e => e.UdPrismOs)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("UD_PRISM_OS");
        });

        modelBuilder.Entity<GpnPatientVisionInsuranceView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_PATIENT_VISION_INSURANCE_VIEW");

            entity.Property(e => e.InsCompanyId).HasColumnName("Ins_Company_Id");
            entity.Property(e => e.InsuranceRank).HasColumnName("Insurance_Rank");
            entity.Property(e => e.IsPolicyActive).HasColumnName("Is_Policy_Active");
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
            entity.Property(e => e.PatientInsuranceId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Patient_Insurance_Id");
            entity.Property(e => e.PolicyEndDate).HasColumnName("Policy_End_Date");
            entity.Property(e => e.PolicyNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Policy_Number");
            entity.Property(e => e.PolicyStartDate)
                .HasColumnType("datetime")
                .HasColumnName("Policy_Start_Date");
        });

        modelBuilder.Entity<GpnPatientsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_PATIENTS_VIEW");

            entity.Property(e => e.AccountNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Account_Number");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.LocationId).HasColumnName("Location_Id");
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
        });

        modelBuilder.Entity<GpnPaymentTypesView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_PAYMENT_TYPES_VIEW");

            entity.Property(e => e.PaymentTypeCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Payment_Type_Code");
            entity.Property(e => e.PaymentTypeDescription)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Payment_Type_Description");
            entity.Property(e => e.PaymentTypeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Payment_Type_Id");
            entity.Property(e => e.PaymentTypeLocationId).HasColumnName("Payment_Type_Location_Id");
        });

        modelBuilder.Entity<GpnProviderView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_PROVIDER_VIEW");

            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.FullName)
                .HasMaxLength(102)
                .IsUnicode(false)
                .HasColumnName("Full_Name");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.MiddleInitial)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.ProviderCode)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Provider_Code");
            entity.Property(e => e.ProviderId).HasColumnName("Provider_Id");
            entity.Property(e => e.State)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Zip)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GpnStaffView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_STAFF_VIEW");

            entity.Property(e => e.Address)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.FullName)
                .HasMaxLength(102)
                .IsUnicode(false)
                .HasColumnName("Full_Name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.MiddleInitial)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.StaffCode)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("Staff_Code");
            entity.Property(e => e.StaffId).HasColumnName("Staff_Id");
            entity.Property(e => e.State)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Zip)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GpnTaxTypesView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_TAX_TYPES_VIEW");

            entity.Property(e => e.Code)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.LocationId).HasColumnName("Location_Id");
            entity.Property(e => e.TaxTypeDescription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Tax_Type_Description");
            entity.Property(e => e.TaxTypeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Tax_Type_Id");
        });

        modelBuilder.Entity<GpnVwFrameTypeView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_VW_FRAME_TYPE_VIEW");

            entity.Property(e => e.VwFrameTypeCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("VW_Frame_Type_Code");
            entity.Property(e => e.VwFrameTypeDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("VW_FRAME_TYPE_Description");
            entity.Property(e => e.VwFrameTypeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("VW_Frame_Type_Id");
        });

        modelBuilder.Entity<GpnVwLensDesignView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_VW_LENS_DESIGN_VIEW");

            entity.Property(e => e.VwLensDesignCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("VW_Lens_Design_Code");
            entity.Property(e => e.VwLensDesignDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("VW_Lens_Design_Description");
            entity.Property(e => e.VwLensDesignId)
                .ValueGeneratedOnAdd()
                .HasColumnName("VW_Lens_Design_Id");
            entity.Property(e => e.VwLensTypeId).HasColumnName("VW_Lens_Type_Id");
        });

        modelBuilder.Entity<GpnVwLensMaterialView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_VW_LENS_MATERIAL_VIEW");

            entity.Property(e => e.VwLensMaterialCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("VW_Lens_Material_Code");
            entity.Property(e => e.VwLensMaterialDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("VW_Lens_Material_Description");
            entity.Property(e => e.VwLensMaterialId)
                .ValueGeneratedOnAdd()
                .HasColumnName("VW_Lens_Material_Id");
        });

        modelBuilder.Entity<GpnVwLensTypesView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_VW_LENS_TYPES_VIEW");

            entity.Property(e => e.VwLensTypeCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("VW_Lens_Type_Code");
            entity.Property(e => e.VwLensTypeDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("VW_Lens_Type_Description");
            entity.Property(e => e.VwLensTypeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("VW_Lens_Type_Id");
        });

        modelBuilder.Entity<GpnVwTreatmentsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GPN_VW_TREATMENTS_VIEW");

            entity.Property(e => e.VwTreatmentCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("VW_TREATMENT_Code");
            entity.Property(e => e.VwTreatmentDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("VW_TREATMENT_Description");
            entity.Property(e => e.VwTreatmentId)
                .ValueGeneratedOnAdd()
                .HasColumnName("VW_TREATMENT_Id");
        });

        modelBuilder.Entity<GuarantorsPatientIdsTempTable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("GuarantorsPatientIdsTempTable");

            entity.HasIndex(e => e.PatientId, "Patient_Id_Index");

            entity.Property(e => e.AccountNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Account_Number");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.GuarantorPatientIds)
                .HasMaxLength(1011)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Middle_Name");
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
        });

        modelBuilder.Entity<ImgDocTemplate>(entity =>
        {
            entity.HasKey(e => e.TemplateId);

            entity.ToTable("IMG_DOC_TEMPLATES");

            entity.Property(e => e.TemplateId).HasColumnName("Template_Id");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_Time");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.IsEditable).HasColumnName("Is_Editable");
            entity.Property(e => e.IsSchedulingRelatedTemplate).HasColumnName("Is_Scheduling_Related_Template");
            entity.Property(e => e.LastModifiedBy).HasColumnName("Last_Modified_By");
            entity.Property(e => e.LastModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Modified_Date");
            entity.Property(e => e.SignConsent).HasColumnName("Sign_Consent");
            entity.Property(e => e.SignNpp).HasColumnName("Sign_NPP");
            entity.Property(e => e.TemplateDescription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Template_Description");
            entity.Property(e => e.TemplateName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Template_Name");
            entity.Property(e => e.TemplateRtf)
                .HasColumnType("image")
                .HasColumnName("Template_RTF");
        });

        modelBuilder.Entity<ImgImageSetting>(entity =>
        {
            entity.HasKey(e => e.SettingId);

            entity.ToTable("IMG_IMAGE_SETTINGS");

            entity.Property(e => e.SettingId).HasColumnName("Setting_Id");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.SettingImageCategory)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Setting_Image_Category");
            entity.Property(e => e.SettingImageLocation)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValue("\\\\FoxEyeMD5\\FFPM_EQ10\\IMAGES\\")
                .HasColumnName("Setting_Image_Location");
            entity.Property(e => e.SettingImageRoot)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("\\\\FoxEyeMD5\\FFPM_EQ10\\IMAGES\\")
                .HasColumnName("Setting_Image_Root");
            entity.Property(e => e.SettingImageType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Setting_Image_Type");
        });

        modelBuilder.Entity<ImgPatientDocument>(entity =>
        {
            entity.HasKey(e => e.DocumentId);

            entity.ToTable("IMG_PATIENT_DOCUMENTS");

            entity.Property(e => e.DocumentId).HasColumnName("Document_Id");
            entity.Property(e => e.AddedBy).HasColumnName("Added_By");
            entity.Property(e => e.AddedDate)
                .HasColumnType("datetime")
                .HasColumnName("Added_Date");
            entity.Property(e => e.DocumentLocation)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Document_Location");
            entity.Property(e => e.DocumentName)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Document_Name");
            entity.Property(e => e.DocumentOwnerId).HasColumnName("Document_Owner_Id");
            entity.Property(e => e.DocumentRemarks)
                .IsUnicode(false)
                .HasColumnName("Document_Remarks");
            entity.Property(e => e.DocumentRoot)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Document_Root");
            entity.Property(e => e.DocumentType).HasColumnName("Document_Type");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
        });

        modelBuilder.Entity<ImgPatientIdentificationCard>(entity =>
        {
            entity.HasKey(e => e.IdentificationCardId).HasName("PK_IMG_PATIENT_INDENTIFICATION_CARDS");

            entity.ToTable("IMG_PATIENT_IDENTIFICATION_CARDS");

            entity.Property(e => e.IdentificationCardId).HasColumnName("Identification_Card_Id");
            entity.Property(e => e.AddedBy).HasColumnName("Added_By");
            entity.Property(e => e.AddedDate)
                .HasColumnType("datetime")
                .HasColumnName("Added_Date");
            entity.Property(e => e.CardOwnerId).HasColumnName("Card_Owner_Id");
            entity.Property(e => e.IdentificationCardLocation)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Identification_Card_Location");
            entity.Property(e => e.IdentificationCardName)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Identification_Card_Name");
            entity.Property(e => e.IdentificationCardRemarks)
                .IsUnicode(false)
                .HasColumnName("Identification_Card_Remarks");
            entity.Property(e => e.IdentificationCardRoot)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Identification_Card_Root");
            entity.Property(e => e.IdentificationCardType).HasColumnName("Identification_Card_Type");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
        });

        modelBuilder.Entity<ImgPatientInsuranceCard>(entity =>
        {
            entity.HasKey(e => e.InsuranceCardId);

            entity.ToTable("IMG_PATIENT_INSURANCE_CARDS");

            entity.Property(e => e.InsuranceCardId).HasColumnName("Insurance_Card_Id");
            entity.Property(e => e.AddedBy).HasColumnName("Added_By");
            entity.Property(e => e.AddedDate)
                .HasColumnType("datetime")
                .HasColumnName("Added_Date");
            entity.Property(e => e.InsuranceCarLocation)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Insurance_Car_Location");
            entity.Property(e => e.InsuranceCardRoot)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Insurance_Card_Root");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
            entity.Property(e => e.PatientInsuranceId).HasColumnName("Patient_Insurance_Id");
        });

        modelBuilder.Entity<ImgPatientPhoto>(entity =>
        {
            entity.HasKey(e => e.PhotoId).HasName("PK_DMG_PATIENT_PHOTO");

            entity.ToTable("IMG_PATIENT_PHOTO");

            entity.Property(e => e.PhotoId).HasColumnName("Photo_Id");
            entity.Property(e => e.AddedBy).HasColumnName("Added_By");
            entity.Property(e => e.AddedDate)
                .HasColumnType("datetime")
                .HasColumnName("Added_Date");
            entity.Property(e => e.InfProcessed)
                .HasDefaultValue(false)
                .HasColumnName("Inf_Processed");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
            entity.Property(e => e.PhotoLocation)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Photo_Location");
            entity.Property(e => e.PhotoLocationRoot)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Photo_Location_Root");
        });

        modelBuilder.Entity<ImportError>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ErrorMessage).IsUnicode(false);
            entity.Property(e => e.ErrorTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Identifier)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.ImportType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Uid)
                .ValueGeneratedOnAdd()
                .HasColumnName("UID");
        });

        modelBuilder.Entity<ImportManufacturer>(entity =>
        {
            entity.HasKey(e => e.ImportManufacturersId).HasName("PK_ImportCompanies");

            entity.Property(e => e.BrandName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastImportedDate).HasColumnType("datetime");
            entity.Property(e => e.ManufacturerId)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.ManufacturerName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ImportTrace>(entity =>
        {
            entity.HasKey(e => e.RowNumber).HasName("PK__tmp_ms_x__AAAC09D85D719815");

            entity.ToTable("ImportTrace");

            entity.Property(e => e.ApplicationName).HasMaxLength(128);
            entity.Property(e => e.BinaryData).HasColumnType("image");
            entity.Property(e => e.ClientProcessId).HasColumnName("ClientProcessID");
            entity.Property(e => e.Cpu).HasColumnName("CPU");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.LoginName).HasMaxLength(128);
            entity.Property(e => e.NtuserName)
                .HasMaxLength(128)
                .HasColumnName("NTUserName");
            entity.Property(e => e.Spid).HasColumnName("SPID");
            entity.Property(e => e.StartTime).HasColumnType("datetime");
            entity.Property(e => e.TextData).HasColumnType("ntext");
        });

        modelBuilder.Entity<InfInterfaceSetting>(entity =>
        {
            entity.HasKey(e => e.InterfaceSettingId).HasName("PK_Inf_Interface_Settings");

            entity.ToTable("INF_INTERFACE_SETTINGS");

            entity.Property(e => e.InterfaceSettingId).HasColumnName("Interface_Setting_Id");
            entity.Property(e => e.InfChgEyeMdDropoffFolder)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Inf_Chg_EyeMd_Dropoff_Folder");
            entity.Property(e => e.InfChgEyeMdToFfpm).HasColumnName("Inf_Chg_EyeMd_To_FFPM");
            entity.Property(e => e.InfChgFfpmDropoffFolder)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Inf_Chg_FFPM_Dropoff_Folder");
            entity.Property(e => e.InfChgFfpmToNav).HasColumnName("Inf_Chg_FFPM_To_Nav");
            entity.Property(e => e.InfChgNavDropoffFolder)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Inf_Chg_Nav_Dropoff_Folder");
            entity.Property(e => e.InfClxClientId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Inf_CLX_Client_Id");
            entity.Property(e => e.InfConfiguratorVersion)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Inf_Configurator_Version");
            entity.Property(e => e.InfContactLensRxInterface).HasColumnName("Inf_Contact_Lens_Rx_Interface");
            entity.Property(e => e.InfCustomerAcctCode)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Inf_Customer_Acct_Code");
            entity.Property(e => e.InfCustomerName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Inf_Customer_Name");
            entity.Property(e => e.InfDeleteFiles).HasColumnName("Inf_Delete_Files");
            entity.Property(e => e.InfDmgEyeMdDropoffFolder)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Inf_Dmg_EyeMd_Dropoff_Folder");
            entity.Property(e => e.InfDmgFfpmToEyeMd).HasColumnName("Inf_Dmg_FFPM_To_EyeMd");
            entity.Property(e => e.InfDmgFfpmToNav).HasColumnName("Inf_Dmg_FFPM_To_Nav");
            entity.Property(e => e.InfDmgNavDropoffFolder)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Inf_Dmg_Nav_Dropoff_Folder");
            entity.Property(e => e.InfDmgNavFtpPassword)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Inf_Dmg_Nav_Ftp_Password");
            entity.Property(e => e.InfDmgNavFtpServer)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Inf_Dmg_Nav_Ftp_Server");
            entity.Property(e => e.InfDmgNavFtpUserName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Inf_Dmg_Nav_Ftp_UserName");
            entity.Property(e => e.InfDmgNavPickupFolder)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Inf_Dmg_Nav_Pickup_Folder");
            entity.Property(e => e.InfDmgNavToEyeMd).HasColumnName("Inf_Dmg_Nav_To_EyeMd");
            entity.Property(e => e.InfDmgNavToFfpm).HasColumnName("Inf_Dmg_Nav_To_FFPM");
            entity.Property(e => e.InfDmgOutgoingFiles)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Inf_Dmg_Outgoing_Files");
            entity.Property(e => e.InfEdiClaimStatus).HasColumnName("Inf_Edi_Claim_Status");
            entity.Property(e => e.InfEdiClaimStatusDownloadDays)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Inf_Edi_Claim_Status_Download_Days");
            entity.Property(e => e.InfEdiClaimStatusDownloadTime)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Inf_Edi_Claim_Status_Download_Time");
            entity.Property(e => e.InfEdiEligibility).HasColumnName("Inf_Edi_Eligibility");
            entity.Property(e => e.InfEdiEligibilityDownloadDaysPrior)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Inf_Edi_Eligibility_Download_Days_Prior");
            entity.Property(e => e.InfEdiEligibilityDownloadTime)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Inf_Edi_Eligibility_Download_Time");
            entity.Property(e => e.InfEdiFtpPassword)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Inf_Edi_FTP_Password");
            entity.Property(e => e.InfEdiFtpServer)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Inf_Edi_FTP_Server");
            entity.Property(e => e.InfEdiFtpUserName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Inf_Edi_FTP_UserName");
            entity.Property(e => e.InfEdiRemits).HasColumnName("Inf_Edi_Remits");
            entity.Property(e => e.InfEhrVisitType).HasColumnName("Inf_EHR_Visit_Type");
            entity.Property(e => e.InfEmailActive).HasColumnName("Inf_Email_Active");
            entity.Property(e => e.InfEmailSendFrom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Inf_Email_Send_From");
            entity.Property(e => e.InfEmailSendTo)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Inf_Email_Send_To");
            entity.Property(e => e.InfEmailSmtpServer)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Inf_Email_Smtp_Server");
            entity.Property(e => e.InfEndTime)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Inf_End_Time");
            entity.Property(e => e.InfEssilorDeviceDeleteFiles).HasColumnName("Inf_Essilor_Device_Delete_Files");
            entity.Property(e => e.InfEssilorDeviceExportFolder)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Inf_Essilor_Device_Export_Folder");
            entity.Property(e => e.InfEssilorDeviceImportFolder)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Inf_Essilor_Device_Import_Folder");
            entity.Property(e => e.InfEssilorInterfaceActive).HasColumnName("Inf_Essilor_Interface_Active");
            entity.Property(e => e.InfEyeMdDatabase)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Inf_EyeMd_Database");
            entity.Property(e => e.InfEyeMdServer)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Inf_EyeMd_Server");
            entity.Property(e => e.InfFfpmDatabase)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Inf_FFPM_Database");
            entity.Property(e => e.InfFfpmServer)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Inf_FFPM_Server");
            entity.Property(e => e.InfGpiFormsActive).HasColumnName("Inf_GPI_Forms_Active");
            entity.Property(e => e.InfInterfaceVersion)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Inf_Interface_Version");
            entity.Property(e => e.InfLogFileLocation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Inf_Log_File_Location");
            entity.Property(e => e.InfOptEyeMdDropoffFolder)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Inf_Opt_EyeMd_Dropoff_Folder");
            entity.Property(e => e.InfOrderEyeMdToFfpm).HasColumnName("Inf_Order_EyeMd_To_FFPM");
            entity.Property(e => e.InfOrderReplyFfpmToEyeMd).HasColumnName("Inf_Order_Reply_FFPM_To_EyeMd");
            entity.Property(e => e.InfProcessingFolder)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Inf_Processing_Folder");
            entity.Property(e => e.InfReceivingFacility)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Inf_Receiving_Facility");
            entity.Property(e => e.InfRxInterfaceActive).HasColumnName("Inf_Rx_Interface_Active");
            entity.Property(e => e.InfRxInterfaceDefaultLab).HasColumnName("Inf_Rx_Interface_Default_Lab");
            entity.Property(e => e.InfSchdEyeMdDropoffFolder)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Inf_Schd_EyeMd_Dropoff_Folder");
            entity.Property(e => e.InfSchdFfpmEyeMd).HasColumnName("Inf_Schd_FFPM_EyeMd");
            entity.Property(e => e.InfSendingFacility)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Inf_Sending_Facility");
            entity.Property(e => e.InfStartTime)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Inf_Start_Time");
            entity.Property(e => e.InfTimerInterval).HasColumnName("Inf_Timer_Interval");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
        });

        modelBuilder.Entity<InfLogStatus>(entity =>
        {
            entity.HasKey(e => e.InterfaceLogId);

            entity.ToTable("INF_LOG_STATUS");

            entity.Property(e => e.InterfaceLogId).HasColumnName("Interface_Log_Id");
            entity.Property(e => e.InerfaceFileType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Inerface_File_Type");
            entity.Property(e => e.InterfaceEntityName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Interface_Entity_Name");
            entity.Property(e => e.InterfaceLog)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Interface_Log");
            entity.Property(e => e.InterfaceLogDescription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Interface_Log_Description");
            entity.Property(e => e.InterfaceLogDestination)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Interface_Log_Destination");
            entity.Property(e => e.InterfaceLogFileConent)
                .HasMaxLength(5000)
                .IsUnicode(false)
                .HasColumnName("Interface_Log_File_Conent");
            entity.Property(e => e.InterfaceLogNotes)
                .HasMaxLength(5000)
                .IsUnicode(false)
                .HasColumnName("Interface_Log_Notes");
            entity.Property(e => e.InterfaceLogResend).HasColumnName("Interface_Log_Resend");
            entity.Property(e => e.InterfaceLogSource)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Interface_Log_Source");
            entity.Property(e => e.InterfaceLogTime)
                .HasColumnType("datetime")
                .HasColumnName("Interface_Log_Time");
            entity.Property(e => e.InterfaceLogType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Interface_Log_Type");
            entity.Property(e => e.InterfacePatientAccount)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Interface_Patient_Account");
        });

        modelBuilder.Entity<InsFoxFire>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Ins_FoxFire");

            entity.Property(e => e.Column0)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Column 0");
            entity.Property(e => e.Column1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Column 1");
            entity.Property(e => e.Column10)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Column 10");
            entity.Property(e => e.Column11)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Column 11");
            entity.Property(e => e.Column12)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Column 12");
            entity.Property(e => e.Column2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Column 2");
            entity.Property(e => e.Column3)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Column 3");
            entity.Property(e => e.Column4)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Column 4");
            entity.Property(e => e.Column5)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Column 5");
            entity.Property(e => e.Column6)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Column 6");
            entity.Property(e => e.Column7)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Column 7");
            entity.Property(e => e.Column8)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Column 8");
            entity.Property(e => e.Column9)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Column 9");
        });

        modelBuilder.Entity<InsInsuranceCarrierType>(entity =>
        {
            entity.HasKey(e => e.CarrierTypeId);

            entity.ToTable("INS_INSURANCE_CARRIER_TYPES");

            entity.Property(e => e.CarrierTypeId).HasColumnName("Carrier_Type_Id");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<InsInsuranceCategory>(entity =>
        {
            entity.HasKey(e => e.InsuranceCategoryId);

            entity.ToTable("INS_INSURANCE_CATEGORY");

            entity.Property(e => e.InsuranceCategoryId).HasColumnName("Insurance_Category_Id");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<InsInsuranceCmpTest>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Ins_Insurance_Cmp_Test");

            entity.Property(e => e.InsCompanyAddress1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Address_1");
            entity.Property(e => e.InsCompanyAddress2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Address_2");
            entity.Property(e => e.InsCompanyCarrierTypeId).HasColumnName("Ins_Company_Carrier_Type_Id");
            entity.Property(e => e.InsCompanyCity)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_City");
            entity.Property(e => e.InsCompanyClaimTypeId).HasColumnName("Ins_Company_Claim_Type_Id");
            entity.Property(e => e.InsCompanyCode)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Code");
            entity.Property(e => e.InsCompanyCountryId).HasColumnName("Ins_Company_Country_Id");
            entity.Property(e => e.InsCompanyEmail)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Email");
            entity.Property(e => e.InsCompanyId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Ins_Company_Id");
            entity.Property(e => e.InsCompanyName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Name");
            entity.Property(e => e.InsCompanyPayerId)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Payer_Id");
            entity.Property(e => e.InsCompanyPayerTypeId).HasColumnName("Ins_Company_Payer_Type_Id");
            entity.Property(e => e.InsCompanyPhone)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Phone");
            entity.Property(e => e.InsCompanyPolicyTypeId).HasColumnName("Ins_Company_Policy_Type_Id");
            entity.Property(e => e.InsCompanyStateId).HasColumnName("Ins_Company_State_Id");
            entity.Property(e => e.InsCompanyWebsite)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Website");
            entity.Property(e => e.InsCompanyZip)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Zip");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.LastModifiedBy).HasColumnName("Last_Modified_By");
            entity.Property(e => e.LastModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Modified_Date");
            entity.Property(e => e.PmCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PM_Code");
        });

        modelBuilder.Entity<InsInsuranceCompany>(entity =>
        {
            entity.HasKey(e => e.InsCompanyId);

            entity.ToTable("INS_INSURANCE_COMPANY");

            entity.Property(e => e.InsCompanyId).HasColumnName("Ins_Company_Id");
            entity.Property(e => e.AcceptAssignment).HasColumnName("Accept_Assignment");
            entity.Property(e => e.AdjustmentTransaction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("Adjustment_Transaction");
            entity.Property(e => e.AllowEligibilityChecks).HasColumnName("Allow_Eligibility_Checks");
            entity.Property(e => e.ApplyShiftLogic).HasColumnName("Apply_Shift_Logic");
            entity.Property(e => e.CategoryId).HasColumnName("Category_Id");
            entity.Property(e => e.ElectornicEnabled).HasColumnName("Electornic_Enabled");
            entity.Property(e => e.InsCompanyAddress1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Address_1");
            entity.Property(e => e.InsCompanyAddress2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Address_2");
            entity.Property(e => e.InsCompanyCarrierTypeId).HasColumnName("Ins_Company_Carrier_Type_Id");
            entity.Property(e => e.InsCompanyCity)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_City");
            entity.Property(e => e.InsCompanyClaimTypeId).HasColumnName("Ins_Company_Claim_Type_Id");
            entity.Property(e => e.InsCompanyCode)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Code");
            entity.Property(e => e.InsCompanyCountryId).HasColumnName("Ins_Company_Country_Id");
            entity.Property(e => e.InsCompanyEmail)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Email");
            entity.Property(e => e.InsCompanyFax)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Fax");
            entity.Property(e => e.InsCompanyName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Name");
            entity.Property(e => e.InsCompanyPayerId)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Payer_Id");
            entity.Property(e => e.InsCompanyPayerTypeId).HasColumnName("Ins_Company_Payer_Type_Id");
            entity.Property(e => e.InsCompanyPhone)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Phone");
            entity.Property(e => e.InsCompanyPolicyTypeId).HasColumnName("Ins_Company_Policy_Type_Id");
            entity.Property(e => e.InsCompanyStateId).HasColumnName("Ins_Company_State_Id");
            entity.Property(e => e.InsCompanyWebsite)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Website");
            entity.Property(e => e.InsCompanyZip)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Zip");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.IsCollectionsInsurance).HasColumnName("Is_Collections_Insurance");
            entity.Property(e => e.IsCompanyInsurance).HasColumnName("Is_Company_Insurance");
            entity.Property(e => e.IsDmercPlaceOfService).HasColumnName("Is_DMERC_Place_Of_Service");
            entity.Property(e => e.LastModifiedBy).HasColumnName("Last_Modified_By");
            entity.Property(e => e.LastModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Modified_Date");
            entity.Property(e => e.PaperClaimsOnly).HasColumnName("Paper_Claims_Only");
            entity.Property(e => e.PaymentTransaction)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("Payment_Transaction");
            entity.Property(e => e.PmCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PM_Code");
            entity.Property(e => e.PrintAsOtherInsurance).HasColumnName("Print_As_Other_Insurance");
            entity.Property(e => e.ResponsibilityId).HasColumnName("Responsibility_Id");
        });

        modelBuilder.Entity<InsInsuranceCompanyAdditional>(entity =>
        {
            entity.ToTable("INS_INSURANCE_COMPANY_ADDITIONALS");

            entity.Property(e => e.InsInsuranceCompanyAdditionalId).HasColumnName("INS_INSURANCE_COMPANY_ADDITIONAL_ID");
            entity.Property(e => e.AddedBy).HasColumnName("ADDED_BY");
            entity.Property(e => e.AddedDate)
                .HasColumnType("datetime")
                .HasColumnName("ADDED_DATE");
            entity.Property(e => e.InsAddlInsCompanyId).HasColumnName("INS_ADDL_INS_COMPANY_ID");
            entity.Property(e => e.InsCompanyId).HasColumnName("INS_COMPANY_ID");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(e => e.ModifiedBy).HasColumnName("MODIFIED_BY");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_DATE");
        });

        modelBuilder.Entity<InsInsurancePlan>(entity =>
        {
            entity.HasKey(e => e.PlanId).HasName("PK__INS_INSU__9BAF9B03E5E9F61F");

            entity.ToTable("INS_INSURANCE_PLANS");

            entity.Property(e => e.PlanId).HasColumnName("Plan_Id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DefaultPlan).HasColumnName("Default_Plan");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.InsCompanyId).HasColumnName("Ins_Company_Id");
            entity.Property(e => e.PlanStartDate).HasColumnName("Plan_Start_Date");
        });

        modelBuilder.Entity<InsInsurancePlansCptInformation>(entity =>
        {
            entity.HasKey(e => e.PlanCptId).HasName("PK__INS_INSU__89925471F2FBE25F");

            entity.ToTable("INS_INSURANCE_PLANS_CPT_INFORMATION");

            entity.Property(e => e.PlanCptId).HasColumnName("Plan_CPT_Id");
            entity.Property(e => e.AppliedTypeId)
                .HasDefaultValue(0)
                .HasColumnName("AppliedTypeID");
            entity.Property(e => e.AppliedValue).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.CopayTypeId)
                .HasDefaultValue(0)
                .HasColumnName("CopayTypeID");
            entity.Property(e => e.CopayValue).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.CptId).HasColumnName("Cpt_Id");
            entity.Property(e => e.PlanId).HasColumnName("Plan_Id");
        });

        modelBuilder.Entity<InsuranceCompany>(entity =>
        {
            entity.HasKey(e => e.InsuranceId);

            entity.ToTable("InsuranceCompany");

            entity.Property(e => e.InsuranceId).HasColumnName("InsuranceID");
            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.InsuranceCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.InsuranceName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.PayorId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PayorID");
        });

        modelBuilder.Entity<InsuranceInformation>(entity =>
        {
            entity.HasKey(e => e.InsuranceRecordId);

            entity.ToTable("InsuranceInformation");

            entity.Property(e => e.InsuranceRecordId).HasColumnName("InsuranceRecordID");
            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.Copay).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Extension)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.FaxNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.GroupId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GroupID");
            entity.Property(e => e.InsuranceCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.InsuranceCompany)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.InsuranceId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("InsuranceID");
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.PayorId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.RxgroupId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RXGroupID");
            entity.Property(e => e.Website)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<InsuranceXref>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Insurance_Xref");

            entity.Property(e => e.InsuranceDesc)
                .HasMaxLength(263)
                .IsUnicode(false);
            entity.Property(e => e.InsuranceId).HasColumnName("InsuranceID");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.InventoryId).HasName("PK__Inventory__1CF15040");

            entity.ToTable("Inventory");

            entity.Property(e => e.InventoryId).HasColumnName("InventoryID");
            entity.Property(e => e.Barcode)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.Cost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FrameId).HasColumnName("FrameID");
            entity.Property(e => e.InvoiceDate).HasColumnType("datetime");
            entity.Property(e => e.InvoiceNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Note).IsUnicode(false);
            entity.Property(e => e.Retail).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.WholeSale).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<InventoryAudit>(entity =>
        {
            entity.HasKey(e => e.AuditId);

            entity.ToTable("InventoryAudit");

            entity.Property(e => e.AuditLastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.AuditName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.AuditRemarks).IsUnicode(false);
            entity.Property(e => e.AuditStartDate).HasColumnType("datetime");
            entity.Property(e => e.AuditUsers)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<InventoryAuditDatum>(entity =>
        {
            entity.HasKey(e => e.AuditDataId);

            entity.Property(e => e.User)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Audit).WithMany(p => p.InventoryAuditData)
                .HasForeignKey(d => d.AuditId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryAuditData_InventoryAudit");
        });

        modelBuilder.Entity<InventoryAuditReport>(entity =>
        {
            entity.HasKey(e => e.AuditReportId);

            entity.Property(e => e.AuditReportName)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<InventoryId>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("InventoryId");

            entity.Property(e => e.InventoryId1).HasColumnName("InventoryId");
        });

        modelBuilder.Entity<Lab>(entity =>
        {
            entity.Property(e => e.LabId).HasColumnName("LabID");
            entity.Property(e => e.LabName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LabColor>(entity =>
        {
            entity.HasKey(e => e.ColorId).HasName("PK_LensColors_1");

            entity.Property(e => e.Color)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LabCode)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LabFrameMaterial>(entity =>
        {
            entity.HasKey(e => e.MaterialId);

            entity.ToTable("LabFrameMaterial");

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LabCode)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Material)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LabOrder>(entity =>
        {
            entity.ToTable("LabOrder");

            entity.HasIndex(e => e.Active, "Active");

            entity.HasIndex(e => new { e.PreFfpm50, e.Active }, "ActiveAndPreFFPM50");

            entity.HasIndex(e => new { e.LabOrderId, e.PatientId }, "OrderIDPatientIDIndex").IsUnique();

            entity.HasIndex(e => e.PatientId, "PatientID");

            entity.HasIndex(e => new { e.PatientId, e.LabOrderId, e.StatusId, e.Active }, "PatientIndex");

            entity.HasIndex(e => e.PreFfpm50, "Pre50");

            entity.HasIndex(e => new { e.StatusId, e.Active, e.PreFfpm50 }, "SatusId");

            entity.Property(e => e.AddOnChargeId1).HasColumnName("ADD_ON_CHARGE_ID_1");
            entity.Property(e => e.AddOnChargeId2).HasColumnName("ADD_ON_CHARGE_ID_2");
            entity.Property(e => e.AddOnChargeId3).HasColumnName("ADD_ON_CHARGE_ID_3");
            entity.Property(e => e.AddOnChargeId4).HasColumnName("ADD_ON_CHARGE_ID_4");
            entity.Property(e => e.AddOnChargeId5).HasColumnName("ADD_ON_CHARGE_ID_5");
            entity.Property(e => e.AddOnChargeId6).HasColumnName("ADD_ON_CHARGE_ID_6");
            entity.Property(e => e.AddOnChargeId7).HasColumnName("ADD_ON_CHARGE_ID_7");
            entity.Property(e => e.AddOnChargeId8).HasColumnName("ADD_ON_CHARGE_ID_8");
            entity.Property(e => e.BatchName)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.ChargesSentToExternalSystem).HasColumnName("Charges_Sent_To_External_System");
            entity.Property(e => e.ClExpiration)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CL_Expiration");
            entity.Property(e => e.ClExternalSystemName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CL_External_System_Name");
            entity.Property(e => e.ClIsExternalSystemOrder).HasColumnName("CL_Is_External_System_Order");
            entity.Property(e => e.ClNotes)
                .IsUnicode(false)
                .HasColumnName("CL_Notes");
            entity.Property(e => e.ClRxDate).HasColumnName("CL_RX_Date");
            entity.Property(e => e.ClShipToClinic).HasColumnName("CL_Ship_To_Clinic");
            entity.Property(e => e.ClShipToPatient).HasColumnName("CL_Ship_To_Patient");
            entity.Property(e => e.ClShippingCptId).HasColumnName("CL_Shipping_CPT_ID");
            entity.Property(e => e.ClWearingInstructions)
                .HasMaxLength(5000)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("CL_Wearing_Instructions");
            entity.Property(e => e.DateEntered).HasColumnType("datetime");
            entity.Property(e => e.DateLastUpdated).HasColumnType("datetime");
            entity.Property(e => e.DeleteQuoteDate).HasColumnType("datetime");
            entity.Property(e => e.DiagnosisCodeId).HasColumnName("DiagnosisCodeID");
            entity.Property(e => e.FrameDispensedDateTime).HasColumnType("datetime");
            entity.Property(e => e.FrameReturnedDateTime).HasColumnType("datetime");
            entity.Property(e => e.IsClxorder).HasColumnName("IsCLXOrder");
            entity.Property(e => e.LensOdCptId).HasColumnName("lensOdCptId");
            entity.Property(e => e.OdcontactLensId).HasColumnName("ODContactLensId");
            entity.Property(e => e.OrderPackageId).HasColumnName("ORDER_PACKAGE_ID");
            entity.Property(e => e.OrderSentToClx).HasColumnName("Order_Sent_To_CLX");
            entity.Property(e => e.OrderStatusChangedDateTime).HasColumnType("datetime");
            entity.Property(e => e.OscontactLensId).HasColumnName("OSContactLensId");
            entity.Property(e => e.PreFfpm50).HasColumnName("Pre_FFPM_50");
            entity.Property(e => e.PreFfpm70).HasColumnName("Pre_FFPM_70");
            entity.Property(e => e.PrismNotes)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.ProductCancelledDateTime).HasColumnType("datetime");
            entity.Property(e => e.ProductCancelledOperator)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProductNotifiedBy4Pc).HasColumnName("ProductNotifiedBy4PC");
            entity.Property(e => e.ProductNotifiedByEcp).HasColumnName("ProductNotifiedByECP");
            entity.Property(e => e.ProductNotifiedDateTime).HasColumnType("datetime");
            entity.Property(e => e.ProductNotifiedOperator)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.ProductNotifiedWriteBackId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("ProductNotifiedWriteBackID");
            entity.Property(e => e.ProductPickedUpDateTime).HasColumnType("datetime");
            entity.Property(e => e.ProductPickedUpOperator)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.ProductReceivedDateTime).HasColumnType("datetime");
            entity.Property(e => e.ProductReceivedOperator)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.Remarks)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.RxDate).HasColumnName("RX_Date");
            entity.Property(e => e.RxExpiration)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RX_Expiration");
            entity.Property(e => e.ServiceDate).HasColumnType("datetime");
            entity.Property(e => e.TrayNumber)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasDefaultValue("");
        });

        modelBuilder.Entity<LabOrderBackupV>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LabOrder_Backup_V");

            entity.Property(e => e.BatchName)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.DateEntered).HasColumnType("datetime");
            entity.Property(e => e.DateLastUpdated).HasColumnType("datetime");
            entity.Property(e => e.DeleteQuoteDate).HasColumnType("datetime");
            entity.Property(e => e.DiagnosisCodeId).HasColumnName("DiagnosisCodeID");
            entity.Property(e => e.FrameDispensedDateTime).HasColumnType("datetime");
            entity.Property(e => e.FrameReturnedDateTime).HasColumnType("datetime");
            entity.Property(e => e.LabOrderId).ValueGeneratedOnAdd();
            entity.Property(e => e.LensOdCptId).HasColumnName("lensOdCptId");
            entity.Property(e => e.Remarks)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ServiceDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<LabOrderBackupVineel>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LabOrder_Backup_Vineel");

            entity.Property(e => e.DateEntered).HasColumnType("datetime");
            entity.Property(e => e.DateLastUpdated).HasColumnType("datetime");
            entity.Property(e => e.DeleteQuoteDate).HasColumnType("datetime");
            entity.Property(e => e.DiagnosisCodeId).HasColumnName("DiagnosisCodeID");
            entity.Property(e => e.FrameDispensedDateTime).HasColumnType("datetime");
            entity.Property(e => e.FrameReturnedDateTime).HasColumnType("datetime");
            entity.Property(e => e.LabOrderId).ValueGeneratedOnAdd();
            entity.Property(e => e.LensOdCptId).HasColumnName("lensOdCptId");
            entity.Property(e => e.Remarks)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ServiceDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<LabToFrameEtype>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("PK_LabFrameETypes");

            entity.ToTable("LabToFrameETypes");

            entity.Property(e => e.Uid).HasColumnName("UID");
            entity.Property(e => e.EtypeId).HasColumnName("ETypeId");
        });

        modelBuilder.Entity<LabToFrameFtype>(entity =>
        {
            entity.HasKey(e => e.Uid);

            entity.ToTable("LabToFrameFTypes");

            entity.Property(e => e.Uid).HasColumnName("UID");
            entity.Property(e => e.FtypeId).HasColumnName("FTypeId");
        });

        modelBuilder.Entity<LabToFrameManufacturer>(entity =>
        {
            entity.HasKey(e => e.Uid);

            entity.ToTable("LabToFrameManufacturer");

            entity.Property(e => e.Uid).HasColumnName("UID");
            entity.Property(e => e.LabCode)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LabToFrameStatus>(entity =>
        {
            entity.HasKey(e => e.Uid);

            entity.Property(e => e.Uid).HasColumnName("UID");
        });

        modelBuilder.Entity<LabToFrameTemple>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("PK_LookupLabToFrameTemple");

            entity.ToTable("LabToFrameTemple");

            entity.Property(e => e.Uid).HasColumnName("UID");
        });

        modelBuilder.Entity<LabToLabFrameMaterial>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("PK_LabToLabMaterial");

            entity.ToTable("LabToLabFrameMaterial");

            entity.Property(e => e.Uid).HasColumnName("UID");
        });

        modelBuilder.Entity<LabToLensColor>(entity =>
        {
            entity.HasKey(e => e.Uid);

            entity.Property(e => e.Uid).HasColumnName("UID");
        });

        modelBuilder.Entity<LabToLensMaterial>(entity =>
        {
            entity.HasKey(e => e.Uid);

            entity.ToTable("LabToLensMaterial");

            entity.Property(e => e.Uid).HasColumnName("UID");
        });

        modelBuilder.Entity<LabToLensOrderService>(entity =>
        {
            entity.HasKey(e => e.LabToLensOrderServiceId).HasName("PK_LookupLabToLensOrderService");

            entity.ToTable("LabToLensOrderService");

            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
        });

        modelBuilder.Entity<LabToLensStyle>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("PK_LabToLensStyle");

            entity.Property(e => e.Uid).HasColumnName("UID");
        });

        modelBuilder.Entity<LabToLensTint>(entity =>
        {
            entity.HasKey(e => e.LabToLensTintId).HasName("PK_LookupLabToLensTint");

            entity.ToTable("LabToLensTint");
        });

        modelBuilder.Entity<LabelPrinter>(entity =>
        {
            entity.Property(e => e.Is550OrOlder).HasColumnName("Is_550_or_Older");
            entity.Property(e => e.LabelPrinterName)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.LabelTemplate)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.UserAssignedPrinterName)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LastMonth20210118162803>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LAST_MONTH_20210118162803");

            entity.Property(e => e.Amount).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.BillingLocationId).HasColumnName("Billing_Location_Id");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.EventCategory)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Event_Category");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.GroupId).HasColumnName("Group_Id");
            entity.Property(e => e.InsCategoryId).HasColumnName("Ins_Category_Id");
            entity.Property(e => e.InsCompanyId).HasColumnName("Ins_Company_Id");
            entity.Property(e => e.InsuranceId).HasColumnName("Insurance_Id");
            entity.Property(e => e.ProcedureId).HasColumnName("Procedure_ID");
            entity.Property(e => e.ProviderId).HasColumnName("Provider_Id");
            entity.Property(e => e.RowNum).HasColumnName("Row_Num");
            entity.Property(e => e.Tax).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.TranCategoryId).HasColumnName("Tran_Category_Id");
            entity.Property(e => e.TransactionCodeId).HasColumnName("Transaction_Code_Id");
        });

        modelBuilder.Entity<LastYear20210118162803>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LAST_YEAR_20210118162803");

            entity.Property(e => e.Amount).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.BillingLocationId).HasColumnName("Billing_Location_Id");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.EventCategory)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Event_Category");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.GroupId).HasColumnName("Group_Id");
            entity.Property(e => e.InsCategoryId).HasColumnName("Ins_Category_Id");
            entity.Property(e => e.InsCompanyId).HasColumnName("Ins_Company_Id");
            entity.Property(e => e.InsuranceId).HasColumnName("Insurance_Id");
            entity.Property(e => e.ProcedureId).HasColumnName("Procedure_ID");
            entity.Property(e => e.ProviderId).HasColumnName("Provider_Id");
            entity.Property(e => e.RowNum).HasColumnName("Row_Num");
            entity.Property(e => e.Tax).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.TranCategoryId).HasColumnName("Tran_Category_Id");
            entity.Property(e => e.TransactionCodeId).HasColumnName("Transaction_Code_Id");
        });

        modelBuilder.Entity<LensAvailability>(entity =>
        {
            entity.HasKey(e => e.Uid);

            entity.ToTable("LensAvailability");

            entity.Property(e => e.Uid).HasColumnName("UID");
        });

        modelBuilder.Entity<LensCoat>(entity =>
        {
            entity.HasKey(e => e.CoatId);

            entity.Property(e => e.Coat)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LabCode)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LensInformation>(entity =>
        {
            entity.HasKey(e => e.LensId);

            entity.ToTable("LensInformation");

            entity.Property(e => e.LensId).HasColumnName("LensID");
            entity.Property(e => e.CenterMeasureTypeId).HasColumnName("CenterMeasureTypeID");
            entity.Property(e => e.Cost).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.Cptid).HasColumnName("CPTID");
            entity.Property(e => e.Cylinder).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LensBevelTypeId).HasColumnName("LensBevelTypeID");
            entity.Property(e => e.LensEdgeId).HasColumnName("LensEdgeID");
            entity.Property(e => e.LensMaterialId).HasColumnName("LensMaterialID");
            entity.Property(e => e.LensThickness).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.LensTypeId).HasColumnName("LensTypeID");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");
            entity.Property(e => e.PupilaryDistanceTypeId).HasColumnName("PupilaryDistanceTypeID");
            entity.Property(e => e.SegmentHeightTypeId).HasColumnName("SegmentHeightTypeID");
            entity.Property(e => e.Sphere).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.ThicknessTypeId).HasColumnName("ThicknessTypeID");
            entity.Property(e => e.Upc)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("UPC");
            entity.Property(e => e.VendorId).HasColumnName("VendorID");
        });

        modelBuilder.Entity<LensMaterial>(entity =>
        {
            entity.HasKey(e => e.MaterialId);

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LabCode)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Material)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MaterialIndex).HasColumnType("decimal(6, 3)");
        });

        modelBuilder.Entity<LensMaterialCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId);

            entity.Property(e => e.Category)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LensOrderInfo>(entity =>
        {
            entity.ToTable("LensOrderInfo");

            entity.Property(e => e.ChargeAmount).HasColumnType("money");
            entity.Property(e => e.Ocht).HasColumnType("decimal(5, 1)");
            entity.Property(e => e.SegHt).HasColumnType("decimal(5, 1)");
            entity.Property(e => e.Thck).HasColumnType("decimal(5, 1)");
        });

        modelBuilder.Entity<LensOrderService>(entity =>
        {
            entity.HasKey(e => e.ServiceId);

            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LabCode)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Service)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LensRxInfo>(entity =>
        {
            entity.ToTable("LensRxInfo");

            entity.Property(e => e.Base).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Bsize).HasColumnName("BSize");
            entity.Property(e => e.Cylinder).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Distant).HasColumnType("decimal(8, 1)");
            entity.Property(e => e.IoPrism).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Near).HasColumnType("decimal(8, 1)");
            entity.Property(e => e.PrismFee).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.PrismUnits).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.Sphere).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.UdPrism).HasColumnType("decimal(8, 2)");
        });

        modelBuilder.Entity<LensStyle>(entity =>
        {
            entity.HasKey(e => e.StyleId).HasName("PK_LensStyleNames");

            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.LabCode)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.StyleName)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LensStyleCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId);

            entity.Property(e => e.Category)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LensTint>(entity =>
        {
            entity.HasKey(e => e.TintId);

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LabCode)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Tint)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LmsDesignToProcedureXref>(entity =>
        {
            entity.ToTable("LMS_Design_To_Procedure_Xref");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.Fee).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.ProgressiveCptid).HasColumnName("ProgressiveCPTId");
            entity.Property(e => e.ProgressiveFee).HasColumnType("decimal(6, 2)");
        });

        modelBuilder.Entity<LmsFrameMaster>(entity =>
        {
            entity.ToTable("LMS_Frame_Master");

            entity.Property(e => e.LmsFrameMasterId).HasColumnName("Lms_Frame_Master_Id");
            entity.Property(e => e.A)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.B)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Bridge)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Cost)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Dbl)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("DBL");
            entity.Property(e => e.Ed)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("ED");
            entity.Property(e => e.EyeSize)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.FrameColorId).HasColumnName("Frame_Color_Id");
            entity.Property(e => e.FrameColorImageUrl)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Frame_Color_Image_Url");
            entity.Property(e => e.FrameColorName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Frame_Color_Name");
            entity.Property(e => e.FrameName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Frame_Name");
            entity.Property(e => e.FrameSizeLabId).HasColumnName("Frame_Size_Lab_Id");
            entity.Property(e => e.LmsFrameManufacturerLabId).HasColumnName("Lms_Frame_Manufacturer_Lab_Id");
            entity.Property(e => e.LmsFrameManufacturerName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Lms_Frame_Manufacturer_Name");
            entity.Property(e => e.LmsFrameModelLabId).HasColumnName("Lms_Frame_Model_Lab_Id");
            entity.Property(e => e.LmsFrameModelName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Lms_Frame_Model_Name");
            entity.Property(e => e.LmsFrameTypeLabId).HasColumnName("Lms_Frame_Type_Lab_Id");
            entity.Property(e => e.LmsFrameTypeName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Lms_Frame_Type_Name");
            entity.Property(e => e.Retail)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Temple)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Upc)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("UPC");
            entity.Property(e => e.Wholesale)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LmsJobType>(entity =>
        {
            entity.HasKey(e => e.JobTypeId).HasName("PK_LMS_Frame_Types");

            entity.ToTable("LMS_Job_Types");

            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FrameSelection).HasColumnName("Frame_Selection");
            entity.Property(e => e.FrameSupplierId).HasColumnName("Frame_Supplier_Id");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.IsUpdated).HasColumnName("Is_Updated");
            entity.Property(e => e.JobClassId).HasColumnName("Job_Class_Id");
            entity.Property(e => e.LmsLabId).HasColumnName("Lms_Lab_Id");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
        });

        modelBuilder.Entity<LmsLabInformation>(entity =>
        {
            entity.HasKey(e => e.LmsLabId);

            entity.ToTable("LMS_LAB_INFORMATION");

            entity.Property(e => e.LmsLabId).HasColumnName("LMS_LAB_ID");
            entity.Property(e => e.CurrentRevisionFrameCatalog)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CURRENT_REVISION_FRAME_CATALOG");
            entity.Property(e => e.CurrentRevisionLensCatalog)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CURRENT_REVISION_LENS_CATALOG");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(e => e.LabId).HasColumnName("LAB_ID");
            entity.Property(e => e.LmsLabAccountNum)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("LMS_LAB_ACCOUNT_NUM");
            entity.Property(e => e.LmsLabLastDownloadFrameCatalog)
                .HasColumnType("datetime")
                .HasColumnName("LMS_LAB_LAST_DOWNLOAD_FRAME_CATALOG");
            entity.Property(e => e.LmsLabLastDownloadLensCatalog)
                .HasColumnType("datetime")
                .HasColumnName("LMS_LAB_LAST_DOWNLOAD_LENS_CATALOG");
            entity.Property(e => e.LmsLabName)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("LMS_LAB_NAME");
            entity.Property(e => e.LmsLabPassword)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LMS_LAB_PASSWORD");
            entity.Property(e => e.LmsLabUrl)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("LMS_LAB_URL");
            entity.Property(e => e.LmsLabUserName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LMS_LAB_USER_NAME");
        });

        modelBuilder.Entity<LmsLensDesign>(entity =>
        {
            entity.HasKey(e => e.DesignId);

            entity.ToTable("LMS_Lens_Designs");

            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.IsUpdated).HasColumnName("Is_Updated");
            entity.Property(e => e.LmsLabId).HasColumnName("Lms_Lab_Id");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
        });

        modelBuilder.Entity<LmsLensMaterial>(entity =>
        {
            entity.HasKey(e => e.MaterialId);

            entity.ToTable("LMS_Lens_Materials");

            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.IsUpdated).HasColumnName("Is_Updated");
            entity.Property(e => e.LabLensCoatingId).HasColumnName("Lab_Lens_Coating_Id");
            entity.Property(e => e.LabLensColorId).HasColumnName("Lab_Lens_Color_Id");
            entity.Property(e => e.LabLensLensId).HasColumnName("Lab_Lens_Lens_Id");
            entity.Property(e => e.LabLensMaterialId).HasColumnName("Lab_Lens_Material_Id");
            entity.Property(e => e.LabLensTypeId).HasColumnName("Lab_Lens_Type_Id");
            entity.Property(e => e.LmsLabId).HasColumnName("Lms_Lab_Id");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
        });

        modelBuilder.Entity<LmsLensType>(entity =>
        {
            entity.HasKey(e => e.LensTypeId);

            entity.ToTable("LMS_Lens_Types");

            entity.Property(e => e.BasicStyle).HasColumnName("Basic_Style");
            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.IsUpdated).HasColumnName("Is_Updated");
            entity.Property(e => e.LmsLabId).HasColumnName("Lms_Lab_Id");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
        });

        modelBuilder.Entity<LmsMaterialToProcedureXref>(entity =>
        {
            entity.ToTable("LMS_Material_To_Procedure_Xref");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.Fee).HasColumnType("decimal(6, 2)");
        });

        modelBuilder.Entity<LmsOrderType>(entity =>
        {
            entity.HasKey(e => e.OrderTypeId);

            entity.ToTable("LMS_Order_Types");

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.IsUpdated).HasColumnName("Is_Updated");
            entity.Property(e => e.LabOrderTypeId).HasColumnName("Lab_Order_Type_Id");
            entity.Property(e => e.LmsLabId).HasColumnName("Lms_Lab_Id");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
        });

        modelBuilder.Entity<LmsOrderTypeToLensStyleXref>(entity =>
        {
            entity.HasKey(e => e.LmsOrderTypeToLensTypeXrefId);

            entity.ToTable("Lms_OrderType_To_LensStyle_Xref");

            entity.Property(e => e.LmsOrderTypeToLensTypeXrefId).HasColumnName("Lms_OrderType_To_LensType_Xref_Id");
        });

        modelBuilder.Entity<LmsOrderTypeToTintTypeXref>(entity =>
        {
            entity.ToTable("LMS_OrderType_To_TintType_Xref");

            entity.Property(e => e.LmsOrderTypeToTintTypeXrefId).HasColumnName("Lms_OrderType_To_TintType_Xref_Id");
        });

        modelBuilder.Entity<LmsOrderTypeToTintsXref>(entity =>
        {
            entity.HasKey(e => e.LmsOrderTypeTintXrefId);

            entity.ToTable("LMS_OrderType_To_Tints_Xref");

            entity.Property(e => e.LmsOrderTypeTintXrefId).HasColumnName("Lms_OrderType_Tint_Xref_Id");
        });

        modelBuilder.Entity<LmsPackage>(entity =>
        {
            entity.HasKey(e => e.PackageId);

            entity.ToTable("LMS_PACKAGES");

            entity.Property(e => e.PackageId).HasColumnName("PACKAGE_ID");
            entity.Property(e => e.Active).HasColumnName("ACTIVE");
            entity.Property(e => e.CptId).HasColumnName("CPT_ID");
            entity.Property(e => e.DesignId).HasColumnName("DESIGN_ID");
            entity.Property(e => e.DoNotUsePackageCpt).HasColumnName("DO_NOT_USE_PACKAGE_CPT");
            entity.Property(e => e.Fee)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("FEE");
            entity.Property(e => e.FrameIncluded).HasColumnName("FRAME_INCLUDED");
            entity.Property(e => e.FramesNotes)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("FRAMES_NOTES");
            entity.Property(e => e.LabId).HasColumnName("LAB_ID");
            entity.Property(e => e.LensTypeId).HasColumnName("LENS_TYPE_ID");
            entity.Property(e => e.LocationId).HasColumnName("LOCATION_ID");
            entity.Property(e => e.MaterialId).HasColumnName("MATERIAL_ID");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.OrderTypeId).HasColumnName("ORDER_TYPE_ID");
            entity.Property(e => e.SpecialInstructions)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("SPECIAL_INSTRUCTIONS");
            entity.Property(e => e.TintId).HasColumnName("TINT_ID");
            entity.Property(e => e.TintTypeId).HasColumnName("TINT_TYPE_ID");
        });

        modelBuilder.Entity<LmsPackagesToTreatment>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LMS_PACKAGES_TO_TREATMENTS");

            entity.Property(e => e.PackageId).HasColumnName("PACKAGE_ID");
            entity.Property(e => e.TreatmentId).HasColumnName("TREATMENT_ID");
        });

        modelBuilder.Entity<LmsTint>(entity =>
        {
            entity.HasKey(e => e.TintId);

            entity.ToTable("LMS_Tints");

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.IsUpdated).HasColumnName("Is_Updated");
            entity.Property(e => e.LabTintId).HasColumnName("Lab_Tint_Id");
            entity.Property(e => e.LmsLabId).HasColumnName("Lms_Lab_Id");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
        });

        modelBuilder.Entity<LmsTintType>(entity =>
        {
            entity.HasKey(e => e.TintTypeId);

            entity.ToTable("LMS_Tint_Types");

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.IsUpdated).HasColumnName("Is_Updated");
            entity.Property(e => e.LabTintTypeId).HasColumnName("Lab_Tint_Type_Id");
            entity.Property(e => e.LmsLabId).HasColumnName("Lms_Lab_Id");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.RequiresPercent).HasColumnName("Requires_Percent");
        });

        modelBuilder.Entity<LmsTreatment>(entity =>
        {
            entity.HasKey(e => e.TreatmentId).HasName("LNS_Treatments");

            entity.ToTable("LMS_Treatments");

            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.IsUpdated).HasColumnName("Is_Updated");
            entity.Property(e => e.LmsLabId).HasColumnName("Lms_Lab_Id");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.MiscChargeId).HasColumnName("Misc_Charge_Id");
        });

        modelBuilder.Entity<LmsTreatmentsToProcedureXref>(entity =>
        {
            entity.ToTable("LMS_Treatments_To_Procedure_Xref");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Fee).HasColumnType("decimal(6, 2)");
        });

        modelBuilder.Entity<Loc>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("loc");

            entity.Property(e => e.Add)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ADD");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CITY");
            entity.Property(e => e.Gn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GN");
            entity.Property(e => e.Lkey)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LKEY");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PHONE");
            entity.Property(e => e.Pla)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PLA");
            entity.Property(e => e.Pname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PNAME");
            entity.Property(e => e.St)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ST");
            entity.Property(e => e.Zip)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ZIP");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Address)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.AppointmentFetchDays).HasDefaultValue(15);
            entity.Property(e => e.ChargesEligibleForStatementAfterProductNotified).HasColumnName("CHARGES_ELIGIBLE_FOR_STATEMENT_AFTER_PRODUCT_NOTIFIED");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Clxactive).HasColumnName("CLXActive");
            entity.Property(e => e.ClxclientId)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("CLXClientId");
            entity.Property(e => e.Clxemployee)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CLXEmployee");
            entity.Property(e => e.Clxoffice)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CLXOffice");
            entity.Property(e => e.DisplayContactOnReceipt).HasDefaultValue(true);
            entity.Property(e => e.ExternalEmr).HasColumnName("ExternalEMR");
            entity.Property(e => e.Fax)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.FsgaccountingCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FSGAccountingCode");
            entity.Property(e => e.IncludeZeroDollarChargesOnOrderReceipt).HasColumnName("INCLUDE_ZERO_DOLLAR_CHARGES_ON_ORDER_RECEIPT");
            entity.Property(e => e.Is4PatientCareRecallsActive).HasDefaultValue(false);
            entity.Property(e => e.Is4pcAppointmentsRemindersAndCancellationsActive).HasColumnName("IS_4PC_APPOINTMENTS_REMINDERS_AND_CANCELLATIONS_ACTIVE");
            entity.Property(e => e.Is4pcCreateAppointmentsAutomaticallyActive).HasColumnName("IS_4PC_CREATE_APPOINTMENTS_AUTOMATICALLY_ACTIVE");
            entity.Property(e => e.Is4pcProductPickUpActive).HasColumnName("IS_4PC_PRODUCT_PICK_UP_ACTIVE");
            entity.Property(e => e.Is4pcRecallRemindersActive).HasColumnName("IS_4PC_RECALL_REMINDERS_ACTIVE");
            entity.Property(e => e.Is4pcWebSchedulingActive).HasColumnName("IS_4PC_WEB_SCHEDULING_ACTIVE");
            entity.Property(e => e.IsEyeCareProAppointmentsRemindersAndCancellationsActive).HasColumnName("IS_EYE_CARE_PRO_APPOINTMENTS_REMINDERS_AND_CANCELLATIONS_ACTIVE");
            entity.Property(e => e.IsEyeCareProCreateAppointmentsAutomaticallyActive).HasColumnName("IS_EYE_CARE_PRO_CREATE_APPOINTMENTS_AUTOMATICALLY_ACTIVE");
            entity.Property(e => e.IsEyeCareProProductPickUpActive).HasColumnName("IS_EYE_CARE_PRO_PRODUCT_PICK_UP_ACTIVE");
            entity.Property(e => e.IsEyeCareProRecallRemindersActive).HasColumnName("IS_EYE_CARE_PRO_RECALL_REMINDERS_ACTIVE");
            entity.Property(e => e.IsEyeCareProWebSchedulingActive).HasColumnName("IS_EYE_CARE_PRO_WEB_SCHEDULING_ACTIVE");
            entity.Property(e => e.IsFramesDbdefaultSearch).HasColumnName("IsFramesDBDefaultSearch");
            entity.Property(e => e.LabOrderExecutablePath)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.LabOrderFilePath)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.LabOrderXsdPath)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.LabelPath)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.LabelPrinter)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LocationName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MendsLocationCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MendsVolume)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Odmodifier)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("ODModifier");
            entity.Property(e => e.OrderLogo)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.OrderOdAndOsRxToProcedureXref).HasColumnName("ORDER_OD_AND_OS_RX_TO_PROCEDURE_XREF");
            entity.Property(e => e.OrderPackages).HasColumnName("ORDER_PACKAGES");
            entity.Property(e => e.OrderTemplate)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Osmodifier)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("OSModifier");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.PrismChargeSettings).HasColumnName("PRISM_CHARGE_SETTINGS");
            entity.Property(e => e.SchedulingDisplayAppointmentSummaryAndInsuranceInformationActive).HasColumnName("SCHEDULING_DISPLAY_APPOINTMENT_SUMMARY_AND_INSURANCE_INFORMATION_ACTIVE");
            entity.Property(e => e.ShowWaitingRxorders).HasColumnName("ShowWaitingRXOrders");
            entity.Property(e => e.SignatureIsc250)
                .HasDefaultValue(false)
                .HasColumnName("SignatureISC250");
            entity.Property(e => e.SignatureTablet).HasDefaultValue(false);
            entity.Property(e => e.SignatureTopaz).HasDefaultValue(false);
            entity.Property(e => e.State)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.TaxId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TaxID");
            entity.Property(e => e.UseCcalias)
                .HasDefaultValue(true)
                .HasColumnName("UseCCAlias");
            entity.Property(e => e.ViewFramesDb).HasColumnName("ViewFramesDB");
            entity.Property(e => e.Website)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.XgiftRegId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("XGiftRegId");
            entity.Property(e => e.XgiftStoreId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("XGiftStoreId");
            entity.Property(e => e.Zip)
                .HasMaxLength(12)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LocationArLensCoatInformation>(entity =>
        {
            entity.HasKey(e => e.LocationArLensCoatId);

            entity.ToTable("LocationArLensCoatInformation");

            entity.Property(e => e.Charge).HasColumnType("decimal(8, 2)");
        });

        modelBuilder.Entity<LocationLensServiceInformation>(entity =>
        {
            entity.HasKey(e => e.LocationLensServiceId);

            entity.ToTable("LocationLensServiceInformation");

            entity.Property(e => e.Charge).HasColumnType("decimal(8, 2)");
        });

        modelBuilder.Entity<LocationLensTintInformation>(entity =>
        {
            entity.HasKey(e => e.LocationLensTintId);

            entity.ToTable("LocationLensTintInformation");

            entity.Property(e => e.Charge).HasColumnType("decimal(8, 2)");
        });

        modelBuilder.Entity<LocationOtherLensCoatInformation>(entity =>
        {
            entity.HasKey(e => e.LocationOtherLensCoatId);

            entity.ToTable("LocationOtherLensCoatInformation");

            entity.Property(e => e.Charge).HasColumnType("decimal(8, 2)");
        });

        modelBuilder.Entity<LocationScrLensCoatInformation>(entity =>
        {
            entity.HasKey(e => e.LocationScrLensCoatId);

            entity.ToTable("LocationScrLensCoatInformation");

            entity.Property(e => e.Charge).HasColumnType("decimal(8, 2)");
        });

        modelBuilder.Entity<LocationToLab>(entity =>
        {
            entity.HasKey(e => e.LocationLabId);

            entity.ToTable("LocationToLab");

            entity.Property(e => e.Account)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Charge1Cptid).HasColumnName("Charge1CPTID");
            entity.Property(e => e.Charge2Cptid).HasColumnName("Charge2CPTID");
            entity.Property(e => e.Charge3Cptid).HasColumnName("Charge3CPTID");
            entity.Property(e => e.Charge4Cptid).HasColumnName("Charge4CPTID");
            entity.Property(e => e.Charge5Cptid).HasColumnName("Charge5CPTID");
            entity.Property(e => e.Charge6Cptid).HasColumnName("Charge6CPTID");
            entity.Property(e => e.Charge7Cptid).HasColumnName("Charge7CPTID");
            entity.Property(e => e.Charge8Cptid).HasColumnName("Charge8CPTID");
            entity.Property(e => e.IsDvilab).HasColumnName("IsDVILab");
            entity.Property(e => e.IsLmslab).HasColumnName("IsLMSLab");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WebId)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LocationUvLensCoatInformation>(entity =>
        {
            entity.HasKey(e => e.LocationUvLensId);

            entity.ToTable("LocationUvLensCoatInformation");

            entity.Property(e => e.Charge).HasColumnType("decimal(8, 2)");
        });

        modelBuilder.Entity<LocationVwtreatment>(entity =>
        {
            entity.ToTable("LocationVWTreatments");

            entity.Property(e => e.LocationVwtreatmentId).HasColumnName("LocationVWTreatmentId");
            entity.Property(e => e.Charge).HasColumnType("decimal(6, 2)");
        });

        modelBuilder.Entity<LoginInformation>(entity =>
        {
            entity.HasKey(e => e.LogonId).HasName("PK__LoginInformation__117F9D94");

            entity.ToTable("LoginInformation");

            entity.Property(e => e.LogonId).HasColumnName("LogonID");
            entity.Property(e => e.LoginPassword)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.PasswordRequired).HasDefaultValue(true);
            entity.Property(e => e.Username)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.ManufacturerId).HasName("PK__Manufacturers__7C8480AE");

            entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");
            entity.Property(e => e.AccountNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AccountRep1)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AccountRep2)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AccountRep3)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AccountRep4)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("ACTIVE");
            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.ContactId).HasColumnName("ContactID");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.ManufacturerName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.Website)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MappingGroup>(entity =>
        {
            entity.Property(e => e.Active).HasDefaultValue(false);
            entity.Property(e => e.GroupDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GroupName)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MntAccountNumberFormat>(entity =>
        {
            entity.HasKey(e => e.FormatId);

            entity.ToTable("MNT_ACCOUNT_NUMBER_FORMAT");

            entity.Property(e => e.FormatId).HasColumnName("Format_Id");
            entity.Property(e => e.Format)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FormatAdditionalParameter)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Format_Additional_Parameter");
            entity.Property(e => e.FormatDescription)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Format_Description");
            entity.Property(e => e.FormatExample)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Format_Example");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
        });

        modelBuilder.Entity<MntAddressType>(entity =>
        {
            entity.HasKey(e => e.AddressTypeId);

            entity.ToTable("MNT_ADDRESS_TYPES");

            entity.Property(e => e.AddressTypeId).HasColumnName("Address_Type_Id");
            entity.Property(e => e.AddressTypeCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Address_Type_Code");
            entity.Property(e => e.AddressTypeName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Address_Type_Name");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
        });

        modelBuilder.Entity<MntContactPreference>(entity =>
        {
            entity.HasKey(e => e.ContactPreferenceId);

            entity.ToTable("MNT_CONTACT_PREFERENCES");

            entity.Property(e => e.ContactPreferenceId).HasColumnName("Contact_Preference_Id");
            entity.Property(e => e.ContactPreferenceCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Contact_Preference_Code");
            entity.Property(e => e.ContactPreferenceName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Contact_Preference_Name");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
        });

        modelBuilder.Entity<MntCountry>(entity =>
        {
            entity.HasKey(e => e.CountryId);

            entity.ToTable("MNT_COUNTRY");

            entity.Property(e => e.CountryId).HasColumnName("Country_Id");
            entity.Property(e => e.CountryName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MntEmploymentStatus>(entity =>
        {
            entity.HasKey(e => e.EmploymentStatusId);

            entity.ToTable("MNT_EMPLOYMENT_STATUS");

            entity.Property(e => e.EmploymentStatusId)
                .ValueGeneratedNever()
                .HasColumnName("Employment_Status_Id");
            entity.Property(e => e.EmploymentStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Employment_Status");
            entity.Property(e => e.EmploymentStatusCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Employment_Status_Code");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
        });

        modelBuilder.Entity<MntEthnicity>(entity =>
        {
            entity.HasKey(e => e.EthnicityId).HasName("PK_ETHNICITY_RACE");

            entity.ToTable("MNT_ETHNICITY");

            entity.Property(e => e.EthnicityId).HasColumnName("Ethnicity_Id");
            entity.Property(e => e.Ethnicity)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
        });

        modelBuilder.Entity<MntGender>(entity =>
        {
            entity.HasKey(e => e.GenderId);

            entity.ToTable("MNT_GENDER");

            entity.Property(e => e.GenderId)
                .ValueGeneratedNever()
                .HasColumnName("Gender_Id");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MntHl7Event>(entity =>
        {
            entity.ToTable("MNT_HL7_EVENTS");

            entity.Property(e => e.MntHl7EventId).HasColumnName("Mnt_HL7_Event_Id");
            entity.Property(e => e.MntEventCategory)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Mnt_Event_Category");
            entity.Property(e => e.MntEventDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Mnt_Event_DateTime");
            entity.Property(e => e.MntEventSponsorId).HasColumnName("Mnt_Event_Sponsor_ID");
            entity.Property(e => e.MntEventType)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Mnt_Event_Type");
            entity.Property(e => e.ProcessedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Processed_DateTime");
        });

        modelBuilder.Entity<MntInsuranceType>(entity =>
        {
            entity.HasKey(e => e.InsuranceTypeId);

            entity.ToTable("MNT_INSURANCE_TYPES");

            entity.Property(e => e.InsuranceTypeId)
                .ValueGeneratedNever()
                .HasColumnName("Insurance_Type_Id");
            entity.Property(e => e.InsuranceTypeCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Insurance_Type_Code");
            entity.Property(e => e.InsuranceTypeName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Insurance_Type_Name");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
        });

        modelBuilder.Entity<MntLanguage>(entity =>
        {
            entity.HasKey(e => e.LanguageId).HasName("PK_MNT_LANGUAGE");

            entity.ToTable("MNT_LANGUAGES");

            entity.Property(e => e.LanguageId).HasColumnName("Language_Id");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.Language)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MntMaritalStatus>(entity =>
        {
            entity.HasKey(e => e.MaritalStatusId);

            entity.ToTable("MNT_MARITAL_STATUS");

            entity.Property(e => e.MaritalStatusId)
                .ValueGeneratedNever()
                .HasColumnName("Marital_Status_Id");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.MaritalStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Marital_Status");
            entity.Property(e => e.MaritalStatusCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Marital_Status_Code");
        });

        modelBuilder.Entity<MntMedicareSecondary>(entity =>
        {
            entity.HasKey(e => e.MedicareSecondaryId);

            entity.ToTable("MNT_MEDICARE_SECONDARY");

            entity.Property(e => e.MedicareSecondaryId).HasColumnName("Medicare_Secondary_Id");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.MedicareSecondarryCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Medicare_Secondarry_Code");
            entity.Property(e => e.MedicareSecondaryDescription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Medicare_Secondary_Description");
            entity.Property(e => e.MedicareSecondaryName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Medicare_Secondary_Name");
        });

        modelBuilder.Entity<MntPriority>(entity =>
        {
            entity.HasKey(e => e.PriorityId);

            entity.ToTable("MNT_PRIORITY");

            entity.Property(e => e.PriorityId).HasColumnName("Priority_Id");
            entity.Property(e => e.PriorityCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Priority_Code");
            entity.Property(e => e.PriorityColor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Priority_Color");
            entity.Property(e => e.PriorityName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Priority_Name");
        });

        modelBuilder.Entity<MntRace>(entity =>
        {
            entity.HasKey(e => e.RaceId);

            entity.ToTable("MNT_RACE");

            entity.Property(e => e.RaceId).HasColumnName("Race_Id");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.Race)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MntRelationship>(entity =>
        {
            entity.HasKey(e => e.RelationshipId);

            entity.ToTable("MNT_RELATIONSHIPS");

            entity.Property(e => e.RelationshipId).HasColumnName("Relationship_Id");
            entity.Property(e => e.Relationship)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RelationshipCode)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MntSpeciality>(entity =>
        {
            entity.HasKey(e => e.SpecialityId);

            entity.ToTable("MNT_SPECIALITY");

            entity.Property(e => e.SpecialityId).HasColumnName("Speciality_Id");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.SpecialityCode)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Speciality_Code");
            entity.Property(e => e.SpecialityDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Speciality_Description");
            entity.Property(e => e.SpecialityName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Speciality_Name");
            entity.Property(e => e.TaxonomyCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Taxonomy_Code");
        });

        modelBuilder.Entity<MntState>(entity =>
        {
            entity.HasKey(e => e.StateId);

            entity.ToTable("MNT_STATE");

            entity.Property(e => e.StateId).HasColumnName("State_Id");
            entity.Property(e => e.CountryId).HasColumnName("Country_Id");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.State)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StateCode)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MntSuffix>(entity =>
        {
            entity.HasKey(e => e.SuffixId);

            entity.ToTable("MNT_SUFFIX");

            entity.Property(e => e.SuffixId).HasColumnName("Suffix_Id");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.Suffix)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MntTitle>(entity =>
        {
            entity.HasKey(e => e.TitleId);

            entity.ToTable("MNT_TITLE");

            entity.Property(e => e.TitleId).HasColumnName("Title_Id");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.Title)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MntZipcode>(entity =>
        {
            entity.HasKey(e => e.ZipCodeId);

            entity.ToTable("MNT_ZIPCODE");

            entity.Property(e => e.ZipCodeId).HasColumnName("Zip_Code_Id");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.ZipCity)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Zip_City");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Zip_Code");
            entity.Property(e => e.ZipCounty)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Zip_County");
            entity.Property(e => e.ZipLatitude)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Zip_Latitude");
            entity.Property(e => e.ZipLongitude)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Zip_Longitude");
            entity.Property(e => e.ZipStateCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Zip_State_Code");
            entity.Property(e => e.ZipStateId).HasColumnName("Zip_State_Id");
        });

        modelBuilder.Entity<MonthAndYearEndDate>(entity =>
        {
            entity.ToTable("MONTH_AND_YEAR_END_DATES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateTime)
                .HasColumnType("datetime")
                .HasColumnName("DATE_TIME");
            entity.Property(e => e.EomMonth).HasColumnName("EOM_MONTH");
            entity.Property(e => e.EomYear).HasColumnName("EOM_YEAR");
            entity.Property(e => e.EoyYear).HasColumnName("EOY_YEAR");
            entity.Property(e => e.StaffId).HasColumnName("STAFF_ID");
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TYPE");
        });

        modelBuilder.Entity<MonthAndYearEndDatesTempEoyFix>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MONTH_AND_YEAR_END_DATES_TEMP_EOY_FIX");

            entity.Property(e => e.DateTime)
                .HasColumnType("datetime")
                .HasColumnName("DATE_TIME");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.StaffId).HasColumnName("STAFF_ID");
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TYPE");
        });

        modelBuilder.Entity<MonthAndYearEndReport>(entity =>
        {
            entity.ToTable("MONTH_AND_YEAR_END_REPORTS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateTime)
                .HasColumnType("datetime")
                .HasColumnName("DATE_TIME");
            entity.Property(e => e.ReportPath)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("REPORT_PATH");
            entity.Property(e => e.StaffId).HasColumnName("STAFF_ID");
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TYPE");
        });

        modelBuilder.Entity<NavFoxOpticalInterface>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("NavFoxOpticalInterface");

            entity.Property(e => e.CustomerName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CustomerNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.FoxOpticalFolder)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.NavDownloadFolder)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.NavFtppassword)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NavFTPPassword");
            entity.Property(e => e.NavFtpserver)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("NavFTPServer");
            entity.Property(e => e.NavFtpuser)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NavFTPUser");
            entity.Property(e => e.NavUploadFolder)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<NavGuar>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("NavGuar");

            entity.Property(e => e.Patient)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PATIENT");
        });

        modelBuilder.Entity<OfficeMateBillingLocationsTempTable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OfficeMateBillingLocationsTempTable");

            entity.Property(e => e.LocationId)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("LocationID");
            entity.Property(e => e.LocationName)
                .HasMaxLength(550)
                .IsUnicode(false);
            entity.Property(e => e.NavCode)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OpenEdgeAccountDonationsInformation>(entity =>
        {
            entity.ToTable("OPEN_EDGE_ACCOUNT_DONATIONS_INFORMATION");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("AMOUNT");
            entity.Property(e => e.ProcessingAccountId).HasColumnName("PROCESSING_ACCOUNT_ID");
        });

        modelBuilder.Entity<OpenEdgeAccountReceiptMessage>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OPEN_EDGE_ACCOUNT_RECEIPT_MESSAGES");

            entity.Property(e => e.Message1)
                .HasMaxLength(110)
                .IsUnicode(false)
                .HasColumnName("MESSAGE_1");
            entity.Property(e => e.Message2)
                .HasMaxLength(110)
                .IsUnicode(false)
                .HasColumnName("MESSAGE_2");
            entity.Property(e => e.Message3)
                .HasMaxLength(110)
                .IsUnicode(false)
                .HasColumnName("MESSAGE_3");
            entity.Property(e => e.Message4)
                .HasMaxLength(110)
                .IsUnicode(false)
                .HasColumnName("MESSAGE_4");
            entity.Property(e => e.ProcessingAccountId).HasColumnName("PROCESSING_ACCOUNT_ID");
        });

        modelBuilder.Entity<OpenEdgeElectronicStatementPaymentsInformaitonToOrderCharge>(entity =>
        {
            entity.ToTable("OPEN_EDGE_ELECTRONIC_STATEMENT_PAYMENTS_INFORMAITON_TO_ORDER_CHARGE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ActionRequired).HasColumnName("ACTION_REQUIRED");
            entity.Property(e => e.AmountAppliedToCharge)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("AMOUNT_APPLIED_TO_CHARGE");
            entity.Property(e => e.IssueDetails)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ISSUE_DETAILS");
            entity.Property(e => e.OrderChargeId).HasColumnName("ORDER_CHARGE_ID");
            entity.Property(e => e.PatientPaymentId).HasColumnName("PATIENT_PAYMENT_ID");
            entity.Property(e => e.TransactionId).HasColumnName("TRANSACTION_ID");
        });

        modelBuilder.Entity<OpenEdgeElectronicStatementsPatientsInformation>(entity =>
        {
            entity.ToTable("OPEN_EDGE_ELECTRONIC_STATEMENTS_PATIENTS_INFORMATION");

            entity.HasIndex(e => e.PatientId, "PatientId");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE_TIME");
            entity.Property(e => e.GroupId).HasColumnName("GROUP_ID");
            entity.Property(e => e.OpenEdgeCustomerId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("OPEN_EDGE_CUSTOMER_ID");
            entity.Property(e => e.PatientId).HasColumnName("PATIENT_ID");
            entity.Property(e => e.RequestData).HasColumnName("REQUEST_DATA");
            entity.Property(e => e.ResponseData).HasColumnName("RESPONSE_DATA");
            entity.Property(e => e.StaffId).HasColumnName("STAFF_ID");
            entity.Property(e => e.StaffLocationId).HasColumnName("STAFF_LOCATION_ID");
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TYPE");
        });

        modelBuilder.Entity<OpenEdgeElectronicStatementsPaymentsReportsInformation>(entity =>
        {
            entity.ToTable("OPEN_EDGE_ELECTRONIC_STATEMENTS_PAYMENTS_REPORTS_INFORMATION");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ElectronicPaymentId).HasColumnName("ELECTRONIC_PAYMENT_ID");
            entity.Property(e => e.ReportDateTime)
                .HasColumnType("datetime")
                .HasColumnName("REPORT_DATE_TIME");
            entity.Property(e => e.ReportFilePath)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("REPORT_FILE_PATH");
        });

        modelBuilder.Entity<OpenEdgeElectronicStatementsServiceLocationsInformation>(entity =>
        {
            entity.ToTable("OPEN_EDGE_ELECTRONIC_STATEMENTS_SERVICE_LOCATIONS_INFORMATION");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE_TIME");
            entity.Property(e => e.GroupId).HasColumnName("GROUP_ID");
            entity.Property(e => e.RequestData)
                .HasMaxLength(5000)
                .IsUnicode(false)
                .HasColumnName("REQUEST_DATA");
            entity.Property(e => e.ResponseData)
                .HasMaxLength(5000)
                .IsUnicode(false)
                .HasColumnName("RESPONSE_DATA");
            entity.Property(e => e.StaffId).HasColumnName("STAFF_ID");
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TYPE");
        });

        modelBuilder.Entity<OpenEdgeForm>(entity =>
        {
            entity.HasKey(e => e.FormId);

            entity.ToTable("OPEN_EDGE_FORMS");

            entity.Property(e => e.FormId).HasColumnName("FORM_ID");
            entity.Property(e => e.Active).HasColumnName("ACTIVE");
            entity.Property(e => e.ConsentText)
                .HasDefaultValue("")
                .HasColumnName("CONSENT_TEXT");
            entity.Property(e => e.FormName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("FORM_NAME");
            entity.Property(e => e.FormTypeId).HasColumnName("FORM_TYPE_ID");
            entity.Property(e => e.GroupId).HasColumnName("GROUP_ID");
            entity.Property(e => e.IsConsentForm).HasColumnName("IS_CONSENT_FORM");
            entity.Property(e => e.OpenedgeFormTypeId)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("OPENEDGE_FORM_TYPE_ID");
            entity.Property(e => e.RequestFormWithExistingData).HasColumnName("REQUEST_FORM_WITH_EXISTING_DATA");
        });

        modelBuilder.Entity<OpenEdgeFormsPatientsInformation>(entity =>
        {
            entity.ToTable("OPEN_EDGE_FORMS_PATIENTS_INFORMATION");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active).HasColumnName("ACTIVE");
            entity.Property(e => e.DateTime)
                .HasColumnType("datetime")
                .HasColumnName("DATE_TIME");
            entity.Property(e => e.FormId).HasColumnName("FORM_ID");
            entity.Property(e => e.GroupId).HasColumnName("GROUP_ID");
            entity.Property(e => e.InactivatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("INACTIVATED_DATE_TIME");
            entity.Property(e => e.InactivatedOperator)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("INACTIVATED_OPERATOR");
            entity.Property(e => e.PatientId).HasColumnName("PATIENT_ID");
            entity.Property(e => e.Processed).HasColumnName("PROCESSED");
            entity.Property(e => e.ProcessedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("PROCESSED_DATE_TIME");
            entity.Property(e => e.ProcessedStaff)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PROCESSED_STAFF");
            entity.Property(e => e.RequestData).HasColumnName("REQUEST_DATA");
            entity.Property(e => e.ResponseData).HasColumnName("RESPONSE_DATA");
            entity.Property(e => e.StaffId).HasColumnName("STAFF_ID");
            entity.Property(e => e.StaffLocationId).HasColumnName("STAFF_LOCATION_ID");
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TYPE");
        });

        modelBuilder.Entity<OpenEdgeFormsRequestInformation>(entity =>
        {
            entity.ToTable("OPEN_EDGE_FORMS_REQUEST_INFORMATION");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active).HasColumnName("ACTIVE");
            entity.Property(e => e.AppointmentId).HasColumnName("APPOINTMENT_ID");
            entity.Property(e => e.FormId).HasColumnName("FORM_ID");
            entity.Property(e => e.PatientId).HasColumnName("PATIENT_ID");
            entity.Property(e => e.Processed).HasColumnName("PROCESSED");
            entity.Property(e => e.ProcessedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("PROCESSED_DATE_TIME");
            entity.Property(e => e.RecordAddedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("RECORD_ADDED_DATE_TIME");
            entity.Property(e => e.SchedulingResourceId).HasColumnName("SCHEDULING_RESOURCE_ID");
            entity.Property(e => e.StaffId).HasColumnName("STAFF_ID");
            entity.Property(e => e.StaffLocationId).HasColumnName("STAFF_LOCATION_ID");
            entity.Property(e => e.TriggerDateTime)
                .HasColumnType("datetime")
                .HasColumnName("TRIGGER_DATE_TIME");
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TYPE");
        });

        modelBuilder.Entity<OpenEdgeFormsRulesInformation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OPEN_EDG__3214EC2722964E7C");

            entity.ToTable("OPEN_EDGE_FORMS_RULES_INFORMATION");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AppointmentTypeId).HasColumnName("APPOINTMENT_TYPE_ID");
            entity.Property(e => e.FormId).HasColumnName("FORM_ID");
            entity.Property(e => e.FormSameDayTriggerTypeId).HasColumnName("FORM_SAME_DAY_TRIGGER_TYPE_ID");
            entity.Property(e => e.LocationId).HasColumnName("LOCATION_ID");
            entity.Property(e => e.TriggerFormTypeId).HasColumnName("TRIGGER_FORM_TYPE_ID");
            entity.Property(e => e.TriggerFormValue).HasColumnName("TRIGGER_FORM_VALUE");
        });

        modelBuilder.Entity<OpenEdgeInforamation>(entity =>
        {
            entity.HasKey(e => e.ProcessingAccountId).HasName("tmp_ms_xx_constraint_PK_OPEN_EDGE_INFORAMATION1");

            entity.ToTable("OPEN_EDGE_INFORAMATION");

            entity.Property(e => e.ProcessingAccountId).HasColumnName("PROCESSING_ACCOUNT_ID");
            entity.Property(e => e.AccountCredential)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("ACCOUNT_CREDENTIAL");
            entity.Property(e => e.Active).HasColumnName("ACTIVE");
            entity.Property(e => e.DonationNameOnPpd)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("DONATION_NAME_ON_PPD");
            entity.Property(e => e.HideReceiptSignatureBoxIfBlank).HasColumnName("HIDE_RECEIPT_SIGNATURE_BOX_IF_BLANK");
            entity.Property(e => e.MinimumAmountForSignature)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("MINIMUM_AMOUNT_FOR_SIGNATURE");
            entity.Property(e => e.ProcessingAccountName)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("PROCESSING_ACCOUNT_NAME");
            entity.Property(e => e.ProcessingAccountNumber)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("PROCESSING_ACCOUNT_NUMBER");
            entity.Property(e => e.ProcessingAccountType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PROCESSING_ACCOUNT_TYPE");
            entity.Property(e => e.SignatureRequiredOnPurchase).HasColumnName("SIGNATURE_REQUIRED_ON_PURCHASE");
            entity.Property(e => e.SignatureRequiredOnReturn).HasColumnName("SIGNATURE_REQUIRED_ON_RETURN");
            entity.Property(e => e.SignatureRequiredOnVoid).HasColumnName("SIGNATURE_REQUIRED_ON_VOID");
            entity.Property(e => e.UseCreditCardAlias).HasColumnName("USE_CREDIT_CARD_ALIAS");
            entity.Property(e => e.XwebAuthKey)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("XWEB_AUTH_KEY");
            entity.Property(e => e.XwebId)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("XWEB_ID");
            entity.Property(e => e.XwebTerminalId)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("XWEB_TERMINAL_ID");
        });

        modelBuilder.Entity<OpenEdgeInforamationOld>(entity =>
        {
            entity.ToTable("OPEN_EDGE_INFORAMATION_OLD");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.LocationId).HasColumnName("LOCATION_ID");
            entity.Property(e => e.MinimumAmountForSignature)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("MINIMUM_AMOUNT_FOR_SIGNATURE");
            entity.Property(e => e.Password)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.ProcessingAccountName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PROCESSING_ACCOUNT_NAME");
            entity.Property(e => e.SignatureRequiredOnPurchase).HasColumnName("SIGNATURE_REQUIRED_ON_PURCHASE");
            entity.Property(e => e.SignatureRequiredOnReturn).HasColumnName("SIGNATURE_REQUIRED_ON_RETURN");
            entity.Property(e => e.SignatureRequiredOnVoid).HasColumnName("SIGNATURE_REQUIRED_ON_VOID");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USER_NAME");
        });

        modelBuilder.Entity<OpenEdgeInforamationPre505>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_OPEN_EDGE_INFORAMATION");

            entity.ToTable("OPEN_EDGE_INFORAMATION_PRE_505");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.LocationId).HasColumnName("LOCATION_ID");
            entity.Property(e => e.MinimumAmountForSignature)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("MINIMUM_AMOUNT_FOR_SIGNATURE");
            entity.Property(e => e.Password)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.ProcessingAccountName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PROCESSING_ACCOUNT_NAME");
            entity.Property(e => e.SignatureRequiredOnPurchase).HasColumnName("SIGNATURE_REQUIRED_ON_PURCHASE");
            entity.Property(e => e.SignatureRequiredOnReturn).HasColumnName("SIGNATURE_REQUIRED_ON_RETURN");
            entity.Property(e => e.SignatureRequiredOnVoid).HasColumnName("SIGNATURE_REQUIRED_ON_VOID");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USER_NAME");
        });

        modelBuilder.Entity<OpenEdgeInforamationToStaffLocation>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OPEN_EDGE_INFORAMATION_TO_STAFF_LOCATIONS");

            entity.Property(e => e.LocationId).HasColumnName("LOCATION_ID");
            entity.Property(e => e.ProcessingAccountId).HasColumnName("PROCESSING_ACCOUNT_ID");
        });

        modelBuilder.Entity<OpticalTrace>(entity =>
        {
            entity.HasKey(e => e.RowNumber).HasName("PK__OpticalT__AAAC09D82E9BC6B0");

            entity.ToTable("OpticalTrace");

            entity.Property(e => e.ApplicationName).HasMaxLength(128);
            entity.Property(e => e.BinaryData).HasColumnType("image");
            entity.Property(e => e.ClientProcessId).HasColumnName("ClientProcessID");
            entity.Property(e => e.Cpu).HasColumnName("CPU");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.LoginName).HasMaxLength(128);
            entity.Property(e => e.NtuserName)
                .HasMaxLength(128)
                .HasColumnName("NTUserName");
            entity.Property(e => e.Spid).HasColumnName("SPID");
            entity.Property(e => e.StartTime).HasColumnType("datetime");
            entity.Property(e => e.TextData).HasColumnType("ntext");
        });

        modelBuilder.Entity<OrdContactLensInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ORD_CONTACT_LENS_INFO");

            entity.Property(e => e.AddPowerNameOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Add_Power_Name_Od");
            entity.Property(e => e.AddPowerNameOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Add_Power_Name_Os");
            entity.Property(e => e.AddPowerOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Add_Power_Od");
            entity.Property(e => e.AddPowerOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Add_Power_Os");
            entity.Property(e => e.AddedBy).HasColumnName("Added_By");
            entity.Property(e => e.AddedDate)
                .HasColumnType("datetime")
                .HasColumnName("Added_Date");
            entity.Property(e => e.AxisOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Axis_Od");
            entity.Property(e => e.AxisOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Axis_Os");
            entity.Property(e => e.BaseCurveOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Base_Curve_Od");
            entity.Property(e => e.BaseCurveOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Base_Curve_Os");
            entity.Property(e => e.ClxOrderId).HasColumnName("Clx_Order_Id");
            entity.Property(e => e.ColorOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Color_Od");
            entity.Property(e => e.ColorOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Color_Os");
            entity.Property(e => e.ContactLensInventoryId).HasColumnName("Contact_Lens_Inventory_Id");
            entity.Property(e => e.CylinderOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Cylinder_Od");
            entity.Property(e => e.CylinderOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Cylinder_Os");
            entity.Property(e => e.DiameterOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Diameter_Od");
            entity.Property(e => e.DiameterOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Diameter_Os");
            entity.Property(e => e.DispensedFromInventory).HasColumnName("Dispensed_From_Inventory");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.IsSoftContacts).HasColumnName("Is_Soft_Contacts");
            entity.Property(e => e.MultiFocalOd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MultiFocal_Od");
            entity.Property(e => e.MultiFocalOs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MultiFocal_Os");
            entity.Property(e => e.Notes).IsUnicode(false);
            entity.Property(e => e.OrderContactLensInfoId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Order_Contact_Lens_Info_Id");
            entity.Property(e => e.OrderId).HasColumnName("Order_Id");
            entity.Property(e => e.PupilDiameterOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Pupil_Diameter_Od");
            entity.Property(e => e.PupilDiameterOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Pupil_Diameter_Os");
            entity.Property(e => e.QuantityOd).HasColumnName("Quantity_Od");
            entity.Property(e => e.QuantityOs).HasColumnName("Quantity_Os");
            entity.Property(e => e.SphereOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Sphere_Od");
            entity.Property(e => e.SphereOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Sphere_Os");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");
            entity.Property(e => e.VaDistanceOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VA_Distance_Od");
            entity.Property(e => e.VaDistanceOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VA_Distance_Os");
            entity.Property(e => e.VaNearOd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VA_Near_Od");
            entity.Property(e => e.VaNearOs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VA_Near_Os");
        });

        modelBuilder.Entity<OrderCharge>(entity =>
        {
            entity.HasIndex(e => e.Deleted, "Deleted");

            entity.HasIndex(e => new { e.OrderId, e.OrderChargeId }, "OrderIDIndex").IsUnique();

            entity.HasIndex(e => e.OrderId, "OrderId");

            entity.Property(e => e.AdmitDate).HasColumnType("datetime");
            entity.Property(e => e.Applied).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.Batch)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.CarePlanOverSightNumber)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.Cause)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CauseDate).HasColumnType("datetime");
            entity.Property(e => e.ChargeCost)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ChargeCptId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ChargeDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ChargeDiagnosisId1).HasColumnName("ChargeDiagnosisID1");
            entity.Property(e => e.ChargeDiagnosisId2).HasColumnName("ChargeDiagnosisID2");
            entity.Property(e => e.ChargeDiagnosisId3).HasColumnName("ChargeDiagnosisID3");
            entity.Property(e => e.ChargeDiagnosisId4).HasColumnName("ChargeDiagnosisID4");
            entity.Property(e => e.ChargeDiagnosisId5).HasColumnName("ChargeDiagnosisID5");
            entity.Property(e => e.ChargeDiagnosisId6).HasColumnName("ChargeDiagnosisID6");
            entity.Property(e => e.ChargeDiagnosisId7).HasColumnName("ChargeDiagnosisID7");
            entity.Property(e => e.ChargeDiagnosisId8).HasColumnName("ChargeDiagnosisID8");
            entity.Property(e => e.ChargeInsurance)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ChargeModifier1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ChargeModifier2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ChargeModifier3)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ChargeModifier4)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ChargeName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ChargeNote)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ChargeTotalCost)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Clianumber)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("CLIANumber");
            entity.Property(e => e.Copay).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateOfService).HasColumnType("datetime");
            entity.Property(e => e.Deleted).HasDefaultValue(false);
            entity.Property(e => e.DeletedDateTime).HasColumnType("datetime");
            entity.Property(e => e.DeletedUser)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DischargeDate).HasColumnType("datetime");
            entity.Property(e => e.EhrchargeId).HasColumnName("EHRChargeID");
            entity.Property(e => e.EstimatedInsurance).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.EstimatedPatientBalance).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.HearingAndVisionRxdate).HasColumnName("HearingAndVisionRXDate");
            entity.Property(e => e.ImmunizationBatchNumber)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.InsuranceId).HasColumnName("InsuranceID");
            entity.Property(e => e.IsEhrcharge).HasColumnName("IsEHRCharge");
            entity.Property(e => e.MandatoryMedicareCrossoverIndicator)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.PriorAuthorizationNumber)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.ProcessClaim).HasDefaultValue(true);
            entity.Property(e => e.ReferenceProviderId).HasColumnName("ReferenceProviderID");
            entity.Property(e => e.ReferralNumber)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.ReferringCliafacilityIdentifier)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("ReferringCLIAFacilityIdentifier");
            entity.Property(e => e.SendToPm).HasColumnName("SendToPM");
            entity.Property(e => e.SeriveAuthExcepionCode)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.Tax).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.TaxListId).HasColumnName("TaxListID");
            entity.Property(e => e.TaxOnTotalFee).HasDefaultValue(true);
            entity.Property(e => e.TaxTypeId).HasColumnName("TaxTypeID");
        });

        modelBuilder.Entity<OrderChargeTaxDetail>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ChargeCost).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.OrderChargeId).HasColumnName("OrderChargeID");
            entity.Property(e => e.TaxAmount).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.TaxPercentage).HasColumnType("decimal(7, 2)");
        });

        modelBuilder.Entity<OrderChargesAccidentState>(entity =>
        {
            entity.ToTable("ORDER_CHARGES_ACCIDENT_STATE");

            entity.Property(e => e.OrderChargesAccidentStateId).HasColumnName("ORDER_CHARGES_ACCIDENT_STATE_ID");
            entity.Property(e => e.AddedBy).HasColumnName("Added_By");
            entity.Property(e => e.AddedDate)
                .HasColumnType("datetime")
                .HasColumnName("Added_Date");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(e => e.OrderChargeId).HasColumnName("ORDER_CHARGE_ID");
            entity.Property(e => e.StateId).HasColumnName("STATE_ID");
        });

        modelBuilder.Entity<OrderClxPurchaseInfo>(entity =>
        {
            entity.ToTable("ORDER_CLX_PURCHASE_INFO");

            entity.Property(e => e.OrderClxPurchaseInfoId).HasColumnName("ORDER_CLX_PURCHASE_INFO_ID");
            entity.Property(e => e.ClxOrderId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CLX_ORDER_ID");
            entity.Property(e => e.OrderId).HasColumnName("ORDER_ID");
            entity.Property(e => e.PatientName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PATIENT_NAME");
            entity.Property(e => e.SentBy).HasColumnName("SENT_BY");
            entity.Property(e => e.SentTime)
                .HasColumnType("datetime")
                .HasColumnName("SENT_TIME");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("STATUS");
            entity.Property(e => e.XmlRequestString)
                .IsUnicode(false)
                .HasColumnName("XML_REQUEST_STRING");
            entity.Property(e => e.XmlResponseString)
                .IsUnicode(false)
                .HasColumnName("XML_RESPONSE_STRING");
        });

        modelBuilder.Entity<OrderContactLensInfo>(entity =>
        {
            entity.ToTable("ORDER_CONTACT_LENS_INFO");

            entity.Property(e => e.OrderContactLensInfoId).HasColumnName("Order_Contact_Lens_Info_Id");
            entity.Property(e => e.AddDescription).HasColumnName("Add_Description");
            entity.Property(e => e.AddPower)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Add_Power");
            entity.Property(e => e.Axis)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.BaseCurve)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Base_Curve");
            entity.Property(e => e.BrandId).HasColumnName("Brand_Id");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ContactLensDispensed).HasColumnName("Contact_Lens_Dispensed");
            entity.Property(e => e.ContactLensDispensedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Contact_Lens_Dispensed_Date_Time");
            entity.Property(e => e.CptId).HasColumnName("CPT_Id");
            entity.Property(e => e.Cylinder)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Diameter)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.InventoryId).HasColumnName("Inventory_Id");
            entity.Property(e => e.Power)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Pupil)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.VaDistance)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VA_Distance");
            entity.Property(e => e.VaNear)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("VA_Near");
        });

        modelBuilder.Entity<OrderLensCoat>(entity =>
        {
            entity.HasKey(e => e.OrderLensCoatsId);

            entity.Property(e => e.LensCoatType)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OrderLensTint>(entity =>
        {
            entity.HasKey(e => e.OrderLensTintsId).HasName("PK_OrderTints");

            entity.Property(e => e.TintDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OrderNote>(entity =>
        {
            entity.HasKey(e => e.NoteId);

            entity.HasIndex(e => e.OrderId, "OrderId");

            entity.Property(e => e.NoteId).HasColumnName("NoteID");
            entity.Property(e => e.Note).IsUnicode(false);
            entity.Property(e => e.NoteDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.StaffId).HasColumnName("StaffID");
        });

        modelBuilder.Entity<OrderPackage>(entity =>
        {
            entity.HasKey(e => e.PackageId);

            entity.ToTable("ORDER_PACKAGES");

            entity.Property(e => e.PackageId).HasColumnName("PACKAGE_ID");
            entity.Property(e => e.Active).HasColumnName("ACTIVE");
            entity.Property(e => e.CptId).HasColumnName("CPT_ID");
            entity.Property(e => e.DesignId).HasColumnName("DESIGN_ID");
            entity.Property(e => e.DoNotUsePackageCpt).HasColumnName("DO_NOT_USE_PACKAGE_CPT");
            entity.Property(e => e.Fee)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("FEE");
            entity.Property(e => e.FrameIncluded).HasColumnName("FRAME_INCLUDED");
            entity.Property(e => e.FramesNotes)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("FRAMES_NOTES");
            entity.Property(e => e.LabId).HasColumnName("LAB_ID");
            entity.Property(e => e.LensTypeId).HasColumnName("LENS_TYPE_ID");
            entity.Property(e => e.LocationId).HasColumnName("LOCATION_ID");
            entity.Property(e => e.MaterialId).HasColumnName("MATERIAL_ID");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.SpecialInstructions)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("SPECIAL_INSTRUCTIONS");
            entity.Property(e => e.TreatmentComments)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("TREATMENT_COMMENTS");
        });

        modelBuilder.Entity<OrderPackagesToTreatment>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ORDER_PACKAGES_TO_TREATMENTS");

            entity.Property(e => e.PackageId).HasColumnName("PACKAGE_ID");
            entity.Property(e => e.TreatmentId).HasColumnName("TREATMENT_ID");
        });

        modelBuilder.Entity<OrderService>(entity =>
        {
            entity.HasKey(e => e.OrderServicesId);

            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patients__060DEAE8");

            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.ContactId).HasColumnName("ContactID");
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("DOB");
            entity.Property(e => e.Employer)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.EmployerAddressId).HasColumnName("EmployerAddressID");
            entity.Property(e => e.EmploymentStatusId).HasColumnName("EmploymentStatusID");
            entity.Property(e => e.EmrId)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("EmrID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GenderId).HasColumnName("GenderID");
            entity.Property(e => e.GuarantorId).HasColumnName("GuarantorID");
            entity.Property(e => e.Hipaaconsent).HasColumnName("HIPAAConsent");
            entity.Property(e => e.HipaaconsentDate)
                .HasColumnType("datetime")
                .HasColumnName("HIPAAConsentDate");
            entity.Property(e => e.LastExamDate).HasColumnType("datetime");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MaritalStatusId).HasColumnName("MaritalStatusID");
            entity.Property(e => e.MiddleInitial)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Ssn)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("SSN");
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.StudentStatusId).HasColumnName("StudentStatusID");
            entity.Property(e => e.Suffix)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PatientCardDetail>(entity =>
        {
            entity.HasKey(e => e.PatientCardId);

            entity.Property(e => e.PatientCardId).HasColumnName("PatientCardID");
            entity.Property(e => e.CardAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CardHolderName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CardNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CardType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CardZipCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CheckAccountNumber)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.CheckAccountType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.CheckRoutingNumber)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.ExpirationDate)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.PaymentType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.XcaccountId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("XCAccountID");
        });

        modelBuilder.Entity<PatientGiftCard>(entity =>
        {
            entity.HasKey(e => e.GiftCardId);

            entity.Property(e => e.GiftCardAccountNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.GiftCardOrderId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.IssuedAmmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.IssuedTime).HasColumnType("datetime");
            entity.Property(e => e.ReferenceNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TerminalId)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PatientGiftCardTransaction>(entity =>
        {
            entity.HasKey(e => e.GiftCardTransactionId);

            entity.Property(e => e.BeginningBalance).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.EndingBalance).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.GiftCardNotes)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.ProcessedAmt).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ResponseCode)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.ResponseCodeDesc)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TransactionCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TransactionCodeDesc)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.TransactionDateTime).HasColumnType("datetime");
            entity.Property(e => e.XgiftReciptNo)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.XgiftReferenceNo)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.XgiftRequestString)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("XGiftRequestString");
            entity.Property(e => e.XgiftResponseString)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("XGiftResponseString");
            entity.Property(e => e.XgiftTransactionId)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("XGiftTransactionId");
        });

        modelBuilder.Entity<PatientPayment>(entity =>
        {
            entity.HasIndex(e => e.PaymentTransactionId, "PTID");

            entity.HasIndex(e => e.PurchaseTransactionId, "PUTID");

            entity.Property(e => e.PatientPaymentId).HasColumnName("PatientPaymentID");
            entity.Property(e => e.Ac)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("AC");
            entity.Property(e => e.Aid)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("AID");
            entity.Property(e => e.Aidname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("AIDName");
            entity.Property(e => e.ApprovalCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ApprovedAmount).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.Atc)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("ATC");
            entity.Property(e => e.Avsresult)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("AVSResult");
            entity.Property(e => e.BatchName)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.CheckNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.Cvresult)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CVResult");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.EntryLegend)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.EntryMethod)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.EntryType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.Eobid).HasColumnName("EOBId");
            entity.Property(e => e.FileSent)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Operator)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PatientCardId).HasColumnName("PatientCardID");
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentReceiptNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PaymentTransactionId)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("PaymentTransactionID");
            entity.Property(e => e.PaymentType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PurchaseTransactionId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("PurchaseTransactionID");
            entity.Property(e => e.RegularPatientPaymentId).HasColumnName("RegularPatientPaymentID");
            entity.Property(e => e.RespCd)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("RespCD");
            entity.Property(e => e.SignatureUrl)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("SignatureURL");
            entity.Property(e => e.StatementPaymentId).HasColumnName("StatementPaymentID");
            entity.Property(e => e.Swiped)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TerminalId)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.TransactionCodeId).HasColumnName("TransactionCodeID");
            entity.Property(e => e.TransactionReferenceNumber)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.TransactionResult)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Tsi)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("TSI");
            entity.Property(e => e.Tvr)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("TVR");
            entity.Property(e => e.XchargeTransaction).HasColumnName("XChargeTransaction");
        });

        modelBuilder.Entity<PatientPaymentToOrderCharge>(entity =>
        {
            entity.HasKey(e => e.PatientPaymentToChargeId);

            entity.ToTable("PatientPaymentToOrderCharge");

            entity.HasIndex(e => e.TransactionId, "<Name of Missing Index, sysname,>");

            entity.Property(e => e.PatientPaymentToChargeId).HasColumnName("PatientPaymentToChargeID");
            entity.Property(e => e.AmountAppliedToCharge).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.OrderChargeId).HasColumnName("OrderChargeID");
            entity.Property(e => e.PatientPaymentId).HasColumnName("PatientPaymentID");
            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

            entity.HasOne(d => d.PatientPayment).WithMany(p => p.PatientPaymentToOrderCharges)
                .HasForeignKey(d => d.PatientPaymentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PatientPa__Patie__741A2336");
        });

        modelBuilder.Entity<PatientsTempTable31may2022131413230>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PATIENTS_TEMP_TABLE_31MAY2022131413230");

            entity.HasIndex(e => e.PatientId, "Patient_Id_Index");

            entity.Property(e => e.AccountNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Account_Number");
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
        });

        modelBuilder.Entity<PaymentType>(entity =>
        {
            entity.ToTable("PaymentType");

            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LocationId)
                .HasDefaultValue(3L)
                .HasColumnName("LocationID");
            entity.Property(e => e.PaymentTypeCode)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PlaceOfTreatment>(entity =>
        {
            entity.HasKey(e => e.PlaceOfTreatmentId).HasName("PK__Place_Of__2DFDFE6C1A8DC778");

            entity.ToTable("Place_Of_Treatments");

            entity.Property(e => e.PlaceOfTreatmentId).HasColumnName("Place_Of_Treatment_Id");
            entity.Property(e => e.Code)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(5000)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PrismSetting>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PRISM_SETTINGS");

            entity.Property(e => e.CategoryId).HasColumnName("Category_ID");
            entity.Property(e => e.Fee).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.LocationId).HasColumnName("Location_ID");
            entity.Property(e => e.ProcedureId).HasColumnName("Procedure_ID");
            entity.Property(e => e.TypeId).HasColumnName("Type_ID");
        });

        modelBuilder.Entity<ProductPuckupOrderStatusInformation>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PRODUCT_PUCKUP_ORDER_STATUS_INFORMATION");

            entity.Property(e => e.ClProductCancelledOrderStatusId).HasColumnName("CL_Product_Cancelled_Order_Status_ID");
            entity.Property(e => e.ClProductNotifiedOrderStatusId).HasColumnName("CL_Product_Notified_Order_Status_ID");
            entity.Property(e => e.ClProductPickedUpOrderStatusId).HasColumnName("CL_Product_Picked_Up_Order_Status_ID");
            entity.Property(e => e.ClProductReceivedOrderStatusId).HasColumnName("CL_Product_Received_Order_Status_ID");
            entity.Property(e => e.DefaultOrdersStartDate).HasColumnName("Default_Orders_Start_Date");
            entity.Property(e => e.ProductCancelledOrderStatusId).HasColumnName("Product_Cancelled_Order_Status_ID");
            entity.Property(e => e.ProductNotifiedOrderStatusId).HasColumnName("Product_Notified_Order_Status_ID");
            entity.Property(e => e.ProductPickedUpOrderStatusId).HasColumnName("Product_Picked_Up_Order_Status_ID");
            entity.Property(e => e.ProductReceivedOrderStatusId).HasColumnName("Product_Received_Order_Status_ID");
        });

        modelBuilder.Entity<ReceiptAdNote>(entity =>
        {
            entity.HasKey(e => e.ReceiptAdId);

            entity.Property(e => e.AdNote).IsUnicode(false);
        });

        modelBuilder.Entity<ReceiptOrFinancialSummaryReportInformation>(entity =>
        {
            entity.ToTable("RECEIPT_OR_FINANCIAL_SUMMARY_REPORT_INFORMATION");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PatientId).HasColumnName("PATIENT_ID");
            entity.Property(e => e.ReportDateTime)
                .HasColumnType("datetime")
                .HasColumnName("REPORT_DATE_TIME");
            entity.Property(e => e.ReportFilePath)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("REPORT_FILE_PATH");
            entity.Property(e => e.StaffId).HasColumnName("STAFF_ID");
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ReferralXref>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Referral_Xref");

            entity.Property(e => e.Address1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Address2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.NavCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Npi)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NPI");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Phone_Number");
            entity.Property(e => e.RefCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RefId).HasColumnName("RefID");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ZipCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Zip_Code");
        });

        modelBuilder.Entity<ReferringProvider>(entity =>
        {
            entity.HasKey(e => e.RefProviderId).HasName("PK_ReferingProvider");

            entity.ToTable("ReferringProvider");

            entity.Property(e => e.RefProviderId).HasColumnName("RefProviderID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.RefProviderCode)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.Property(e => e.ReportId).HasColumnName("ReportID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Parameters)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ReportPath)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ReportCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId);

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RptUnpaidClaimsReport>(entity =>
        {
            entity.HasKey(e => e.RptUnpaidClmsReportId);

            entity.ToTable("RPT_UNPAID_CLAIMS_REPORT");

            entity.Property(e => e.RptUnpaidClmsReportId).HasColumnName("RPT_UNPAID_CLMS_REPORT_ID");
            entity.Property(e => e.RptUnpaidClaimsReportIsActive).HasColumnName("RPT_UNPAID_CLAIMS_REPORT_IS_ACTIVE");
            entity.Property(e => e.RptUnpaidClaimsReportIsComplete).HasColumnName("RPT_UNPAID_CLAIMS_REPORT_IS_COMPLETE");
            entity.Property(e => e.RptUnpaidClaimsReportIsLocked).HasColumnName("RPT_UNPAID_CLAIMS_REPORT_IS_LOCKED");
            entity.Property(e => e.RptUnpaidClaimsReportParamsAccAssn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RPT_UNPAID_CLAIMS_REPORT_PARAMS_ACC_ASSN");
            entity.Property(e => e.RptUnpaidClaimsReportParamsBalFrom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RPT_UNPAID_CLAIMS_REPORT_PARAMS_BAL_FROM");
            entity.Property(e => e.RptUnpaidClaimsReportParamsBalTo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RPT_UNPAID_CLAIMS_REPORT_PARAMS_BAL_TO");
            entity.Property(e => e.RptUnpaidClaimsReportParamsBillDateRange)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RPT_UNPAID_CLAIMS_REPORT_PARAMS_BILL_DATE_RANGE");
            entity.Property(e => e.RptUnpaidClaimsReportParamsBillEnd)
                .HasColumnType("datetime")
                .HasColumnName("RPT_UNPAID_CLAIMS_REPORT_PARAMS_BILL_END");
            entity.Property(e => e.RptUnpaidClaimsReportParamsBillGrps)
                .IsUnicode(false)
                .HasColumnName("RPT_UNPAID_CLAIMS_REPORT_PARAMS_BILL_GRPS");
            entity.Property(e => e.RptUnpaidClaimsReportParamsBillStart)
                .HasColumnType("datetime")
                .HasColumnName("RPT_UNPAID_CLAIMS_REPORT_PARAMS_BILL_START");
            entity.Property(e => e.RptUnpaidClaimsReportParamsDepts)
                .IsUnicode(false)
                .HasColumnName("RPT_UNPAID_CLAIMS_REPORT_PARAMS_DEPTS");
            entity.Property(e => e.RptUnpaidClaimsReportParamsInsGrps)
                .IsUnicode(false)
                .HasColumnName("RPT_UNPAID_CLAIMS_REPORT_PARAMS_INS_GRPS");
            entity.Property(e => e.RptUnpaidClaimsReportParamsLoc)
                .IsUnicode(false)
                .HasColumnName("RPT_UNPAID_CLAIMS_REPORT_PARAMS_LOC");
            entity.Property(e => e.RptUnpaidClaimsReportParamsProv)
                .IsUnicode(false)
                .HasColumnName("RPT_UNPAID_CLAIMS_REPORT_PARAMS_PROV");
            entity.Property(e => e.RptUnpaidClaimsReportParamsSortOps)
                .IsUnicode(false)
                .HasColumnName("RPT_UNPAID_CLAIMS_REPORT_PARAMS_SORT_OPS");
            entity.Property(e => e.RptUnpaidClaimsReportParamsSrvDateRange)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RPT_UNPAID_CLAIMS_REPORT_PARAMS_SRV_DATE_RANGE");
            entity.Property(e => e.RptUnpaidClaimsReportParamsSrvEnd)
                .HasColumnType("datetime")
                .HasColumnName("RPT_UNPAID_CLAIMS_REPORT_PARAMS_SRV_END");
            entity.Property(e => e.RptUnpaidClaimsReportParamsSrvStart)
                .HasColumnType("datetime")
                .HasColumnName("RPT_UNPAID_CLAIMS_REPORT_PARAMS_SRV_START");
            entity.Property(e => e.RptUnpaidClaimsReportParamsZeroBal).HasColumnName("RPT_UNPAID_CLAIMS_REPORT_PARAMS_ZERO_BAL");
            entity.Property(e => e.RptUnpaidClaimsReportRemarks)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("RPT_UNPAID_CLAIMS_REPORT_REMARKS");
            entity.Property(e => e.RptUnpaidClmsReportCreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("RPT_UNPAID_CLMS_REPORT_CREATED_DATE");
            entity.Property(e => e.RptUnpaidClmsReportLastUpdDate)
                .HasColumnType("datetime")
                .HasColumnName("RPT_UNPAID_CLMS_REPORT_LAST_UPD_DATE");
            entity.Property(e => e.RptUnpaidClmsReportName)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("RPT_UNPAID_CLMS_REPORT_NAME");
            entity.Property(e => e.RptUnpaidClmsReportUser)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("RPT_UNPAID_CLMS_REPORT_USER");
            entity.Property(e => e.RrptUnpaidClaimsReportParamsIns)
                .IsUnicode(false)
                .HasColumnName("RRPT_UNPAID_CLAIMS_REPORT_PARAMS_INS");
        });

        modelBuilder.Entity<RptUnpaidClaimsReportCharge>(entity =>
        {
            entity.HasKey(e => e.RptUnpaidClmsRptChargeId);

            entity.ToTable("RPT_UNPAID_CLAIMS_REPORT_CHARGES");

            entity.Property(e => e.RptUnpaidClmsRptChargeId).HasColumnName("RPT_UNPAID_CLMS_RPT_CHARGE_ID");
            entity.Property(e => e.IsCompleted).HasColumnName("IS_COMPLETED");
            entity.Property(e => e.OrderChargeId).HasColumnName("ORDER_CHARGE_ID");
            entity.Property(e => e.Remarks)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("REMARKS");
            entity.Property(e => e.RptUnpaidClmsReportId).HasColumnName("RPT_UNPAID_CLMS_REPORT_ID");
        });

        modelBuilder.Entity<RxInformationToProcedureXref>(entity =>
        {
            entity.ToTable("RX_INFORMATION_TO_PROCEDURE_XREF");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CylinderMax)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Cylinder_Max");
            entity.Property(e => e.CylinderMin)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Cylinder_Min");
            entity.Property(e => e.SphereMax)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Sphere_Max");
            entity.Property(e => e.SphereMin)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Sphere_Min");
        });

        modelBuilder.Entity<RxPrintInformation>(entity =>
        {
            entity.HasKey(e => e.RxPrintId);

            entity.ToTable("RX_PRINT_INFORMATION");

            entity.Property(e => e.RxPrintId).HasColumnName("RX_PRINT_ID");
            entity.Property(e => e.OrderId).HasColumnName("Order_ID");
            entity.Property(e => e.RxFilePath)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("RX_File_Path");
            entity.Property(e => e.RxPrintedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("RX_Printed_Date_Time");
            entity.Property(e => e.StaffId).HasColumnName("Staff_ID");
        });

        modelBuilder.Entity<SatArTest>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SAT_AR_TEST");

            entity.Property(e => e.Amount).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.BillingLocationId).HasColumnName("Billing_Location_Id");
            entity.Property(e => e.CDR)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("C_D_R");
            entity.Property(e => e.EstimatedInsurance)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("Estimated_Insurance");
            entity.Property(e => e.EstimatedPatientBalance)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("Estimated_Patient_Balance");
            entity.Property(e => e.EventCategory)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Event_Category");
            entity.Property(e => e.EventId).HasColumnName("Event_Id");
            entity.Property(e => e.EventSponsorId).HasColumnName("Event_Sponsor_Id");
            entity.Property(e => e.EventType)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Event_Type");
            entity.Property(e => e.GroupId).HasColumnName("Group_Id");
            entity.Property(e => e.Iad).HasColumnName("IAD");
            entity.Property(e => e.InsuranceId).HasColumnName("Insurance_Id");
            entity.Property(e => e.Pad).HasColumnName("PAD");
            entity.Property(e => e.ProcedureOrTransactionCodeId).HasColumnName("Procedure_Or_Transaction_Code_Id");
            entity.Property(e => e.ProviderId).HasColumnName("Provider_Id");
            entity.Property(e => e.Responsibility)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.RowNum).HasColumnName("Row_Num");
            entity.Property(e => e.Tax).HasColumnType("decimal(7, 2)");
        });

        modelBuilder.Entity<SchedulingAppointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK_Appointments");

            entity.ToTable("Scheduling_Appointments");

            entity.HasIndex(e => e.PatientId, "PatientId");

            entity.HasIndex(e => e.RecallId, "RecallID");

            entity.HasIndex(e => e.RequestId, "RequestID");

            entity.Property(e => e.AppointmentId).HasColumnName("AppointmentID");
            entity.Property(e => e.AllDay).HasDefaultValue(false);
            entity.Property(e => e.AppointmentTypeId).HasColumnName("AppointmentTypeID");
            entity.Property(e => e.BillingLocationId).HasColumnName("BillingLocationID");
            entity.Property(e => e.CheckInDateTime).HasColumnType("datetime");
            entity.Property(e => e.CheckOutDateTime).HasColumnType("datetime");
            entity.Property(e => e.DateTimeCreated).HasColumnType("datetime");
            entity.Property(e => e.DateTimeUpdated).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.LinkedAppointmentId).HasColumnName("LinkedAppointmentID");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Notes).HasMaxLength(2000);
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.PriorAppointmentId)
                .HasDefaultValue(0L)
                .HasColumnName("PriorAppointmentID");
            entity.Property(e => e.RecallId).HasColumnName("RecallID");
            entity.Property(e => e.ResourceId).HasColumnName("ResourceID");
            entity.Property(e => e.SchedulingCodeId)
                .HasDefaultValue(0)
                .HasColumnName("SchedulingCodeID");
            entity.Property(e => e.SchedulingCodeNotes).HasMaxLength(2000);
            entity.Property(e => e.Sequence).HasDefaultValue(1);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.TakeBackDateTime).HasColumnType("datetime");
            entity.Property(e => e.WaitingListId).HasColumnName("WaitingListID");
        });

        modelBuilder.Entity<SchedulingAppointmentType>(entity =>
        {
            entity.HasKey(e => e.AppointmentTypeId);

            entity.ToTable("Scheduling_AppointmentTypes");

            entity.Property(e => e.AppointmentTypeId).HasColumnName("AppointmentTypeID");
            entity.Property(e => e.BackgroundColor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Code)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ConflictColor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DefaultAppointmentType).HasDefaultValue(false);
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.ForegroundColor)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.IsAppointmentType).HasDefaultValue(true);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Notes)
                .HasMaxLength(5000)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.PatientRequired).HasDefaultValue(true);
            entity.Property(e => e.WebAppointmentColor)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SchedulingAppointmentTypesGrouping>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Scheduling_AppointmentTypes_Grouping");

            entity.Property(e => e.ChildAppointmentTypeId).HasColumnName("ChildAppointmentTypeID");
            entity.Property(e => e.ParentAppointmentTypeId).HasColumnName("ParentAppointmentTypeID");
        });

        modelBuilder.Entity<SchedulingAppointmentTypesToResource>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Scheduling_AppointmentTypes_To_Resources");

            entity.Property(e => e.AppointmentTypeId).HasColumnName("AppointmentTypeID");
            entity.Property(e => e.ResourceId).HasColumnName("ResourceID");
        });

        modelBuilder.Entity<SchedulingCode>(entity =>
        {
            entity.ToTable("Scheduling_Codes");

            entity.Property(e => e.SchedulingCodeId).HasColumnName("SchedulingCodeID");
            entity.Property(e => e.Code)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.TypeId).HasColumnName("TypeID");
        });

        modelBuilder.Entity<SchedulingCodeType>(entity =>
        {
            entity.HasKey(e => e.TypeId);

            entity.ToTable("Scheduling_Code_Types");

            entity.Property(e => e.TypeId).HasColumnName("TypeID");
            entity.Property(e => e.Code)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SchedulingEvent>(entity =>
        {
            entity.ToTable("Scheduling_Events");

            entity.Property(e => e.SchedulingEventId).HasColumnName("Scheduling_Event_ID");
            entity.Property(e => e.AppointmentId).HasColumnName("Appointment_ID");
            entity.Property(e => e.EventDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Event_DateTime");
            entity.Property(e => e.EventType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Event_Type");
            entity.Property(e => e.PatientId).HasColumnName("Patient_ID");
            entity.Property(e => e.ProcessedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Processed_DateTime");
            entity.Property(e => e.StaffId).HasColumnName("Staff_ID");
        });

        modelBuilder.Entity<SchedulingHistory>(entity =>
        {
            entity.HasKey(e => e.SchedulingHistoryId).HasName("PK_AppointmentsHistory");

            entity.ToTable("Scheduling_History");

            entity.HasIndex(e => new { e.EventSponsorId, e.EventCategory }, "EventSpnosorIDAndEventCategoryIndex");

            entity.Property(e => e.SchedulingHistoryId).HasColumnName("SchedulingHistoryID");
            entity.Property(e => e.EventCategory)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EventDateTime).HasColumnType("datetime");
            entity.Property(e => e.EventDetails).IsUnicode(false);
            entity.Property(e => e.EventSponsorId).HasColumnName("EventSponsorID");
            entity.Property(e => e.EventType)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Notes)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.StaffId).HasColumnName("StaffID");
        });

        modelBuilder.Entity<SchedulingOperator>(entity =>
        {
            entity.HasKey(e => e.OperatorId);

            entity.ToTable("Scheduling_Operators");

            entity.Property(e => e.OperatorId).HasColumnName("OperatorID");
            entity.Property(e => e.StaffId).HasColumnName("StaffID");
        });

        modelBuilder.Entity<SchedulingOperatorDefaultResourcesByLocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Scheduling_Staff_Default_Resources");

            entity.ToTable("Scheduling_Operator_Default_Resources_By_Location");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.ResourceId).HasColumnName("ResourceID");
            entity.Property(e => e.StaffId).HasColumnName("StaffID");
        });

        modelBuilder.Entity<SchedulingOperatorGeneralOptionsByLocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Scheduling_Staff_General_Options");

            entity.ToTable("Scheduling_Operator_General_Options_By_Location");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IntervalEndTypeId).HasColumnName("IntervalEndTypeID");
            entity.Property(e => e.IntervalStartTypeId).HasColumnName("IntervalStartTypeID");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.TimeIntervalId).HasColumnName("TimeIntervalID");
        });

        modelBuilder.Entity<SchedulingOperatorPermissionsBySchedulingLocation>(entity =>
        {
            entity.HasKey(e => e.OperatorToBillingLocationId).HasName("PK_Schecduling_Operators_To_BillingLocations");

            entity.ToTable("Scheduling_Operator_Permissions_By_Scheduling_Location");

            entity.Property(e => e.OperatorToBillingLocationId).HasColumnName("OperatorToBillingLocationID");
            entity.Property(e => e.BillingLocationId).HasColumnName("BillingLocationID");
            entity.Property(e => e.StaffId).HasColumnName("StaffID");
        });

        modelBuilder.Entity<SchedulingPatientRecallList>(entity =>
        {
            entity.HasKey(e => e.RecallId);

            entity.ToTable("Scheduling_Patient_Recall_List");

            entity.Property(e => e.RecallId).HasColumnName("RecallID");
            entity.Property(e => e.AppointmentTypeId).HasColumnName("AppointmentTypeID");
            entity.Property(e => e.BillingLocationId).HasColumnName("BillingLocationID");
            entity.Property(e => e.DateTimeAdded).HasColumnType("datetime");
            entity.Property(e => e.DateTimeUpdated).HasColumnType("datetime");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Notes)
                .HasMaxLength(5000)
                .IsUnicode(false);
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.ResourceId).HasColumnName("ResourceID");
        });

        modelBuilder.Entity<SchedulingPatientWaitingList>(entity =>
        {
            entity.HasKey(e => e.WaitingListId);

            entity.ToTable("Scheduling_Patient_Waiting_List");

            entity.Property(e => e.WaitingListId).HasColumnName("WaitingListID");
            entity.Property(e => e.AppointmentTypeId).HasColumnName("AppointmentTypeID");
            entity.Property(e => e.BillingLocationId).HasColumnName("BillingLocationID");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Notes)
                .HasMaxLength(5000)
                .IsUnicode(false);
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.PriorityId).HasColumnName("PriorityID");
            entity.Property(e => e.ResourceId).HasColumnName("ResourceID");
        });

        modelBuilder.Entity<SchedulingRecallInformationBySequence>(entity =>
        {
            entity.ToTable("Scheduling_Recall_Information_By_Sequence");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AppointmentTypeId).HasColumnName("AppointmentTypeID");
            entity.Property(e => e.IntervalTypeId).HasColumnName("IntervalTypeID");
            entity.Property(e => e.IntervalTypeId2).HasColumnName("IntervalTypeID2");
            entity.Property(e => e.RecallNotes).IsUnicode(false);
        });

        modelBuilder.Entity<SchedulingRecallsInformation>(entity =>
        {
            entity.HasKey(e => e.RecallInformationId);

            entity.ToTable("Scheduling_Recalls_Information");

            entity.Property(e => e.RecallInformationId).HasColumnName("RecallInformationID");
            entity.Property(e => e.AppointmentTypeId).HasColumnName("AppointmentTypeID");
            entity.Property(e => e.EqualIntervalRecallNotes)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.IntervalTypeId).HasColumnName("IntervalTypeID");
            entity.Property(e => e.RecallTypeId).HasColumnName("RecallTypeID");
        });

        modelBuilder.Entity<SchedulingResource>(entity =>
        {
            entity.HasKey(e => e.ResourceId);

            entity.ToTable("Scheduling_Resources");

            entity.Property(e => e.ResourceId).HasColumnName("ResourceID");
            entity.Property(e => e.Code)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Contact)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.EmailId)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("EmailID");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.SpecialtyId).HasColumnName("SpecialtyID");
        });

        modelBuilder.Entity<SchedulingRule>(entity =>
        {
            entity.HasKey(e => e.RuleId);

            entity.ToTable("Scheduling_Rules");

            entity.Property(e => e.RuleId).HasColumnName("RuleID");
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ResourceId).HasColumnName("ResourceID");
        });

        modelBuilder.Entity<SchedulingRuleDate>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Scheduling_Rule_Dates");

            entity.Property(e => e.RuleId).HasColumnName("RuleID");
        });

        modelBuilder.Entity<SchedulingRuleDetail>(entity =>
        {
            entity.HasKey(e => e.RuleDetailId);

            entity.ToTable("Scheduling_Rule_Details");

            entity.Property(e => e.RuleDetailId).HasColumnName("RuleDetailID");
            entity.Property(e => e.AppointmentTypeId).HasColumnName("AppointmentTypeID");
            entity.Property(e => e.BillingLocationId).HasColumnName("BillingLocationID");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.RuleId).HasColumnName("RuleID");
            entity.Property(e => e.WebSchedule).HasDefaultValue(true);
        });

        modelBuilder.Entity<SchedulingSpecialty>(entity =>
        {
            entity.HasKey(e => e.SpecialtyId);

            entity.ToTable("Scheduling_Specialty");

            entity.Property(e => e.SpecialtyId).HasColumnName("SpecialtyID");
            entity.Property(e => e.Code)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
        });

        modelBuilder.Entity<SearchOperator>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Operator)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OperatorId)
                .ValueGeneratedOnAdd()
                .HasColumnName("OperatorID");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__0425A276");

            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LevelId).HasColumnName("LevelID");
            entity.Property(e => e.LoginId).HasColumnName("LoginID");
            entity.Property(e => e.ManageLmscatalogSettings).HasColumnName("ManageLMSCatalogSettings");
            entity.Property(e => e.ManageLmsmaintenance).HasColumnName("ManageLMSMaintenance");
            entity.Property(e => e.NavigateToScreenEnabled).HasDefaultValue(true);
            entity.Property(e => e.ProviderCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SendChargeToCcb).HasColumnName("SendChargeToCCB");
            entity.Property(e => e.StaffTypeId).HasColumnName("StaffTypeID");
        });

        modelBuilder.Entity<StaffIdtoLocation>(entity =>
        {
            entity.HasKey(e => e.Uid);

            entity.ToTable("StaffIDToLocations");

            entity.Property(e => e.Uid).HasColumnName("UID");
            entity.Property(e => e.DoNotPrintReceipt).HasDefaultValue(false);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.PrintNonCcpaymentsReceipt)
                .HasDefaultValue(true)
                .HasColumnName("PrintNonCCPaymentsReceipt");
            entity.Property(e => e.PrinterName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.StaffId).HasColumnName("StaffID");
        });

        modelBuilder.Entity<StaffLevel>(entity =>
        {
            entity.HasKey(e => e.LevelId);

            entity.Property(e => e.LevelId)
                .ValueGeneratedNever()
                .HasColumnName("LevelID");
            entity.Property(e => e.LevelName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
        });

        modelBuilder.Entity<StaffLoginOption>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NavigateScreenName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.StaffId).HasColumnName("StaffID");
        });

        modelBuilder.Entity<StaffPrintOption>(entity =>
        {
            entity.ToTable("STAFF_PRINT_OPTIONS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IncludeAdjustments).HasColumnName("INCLUDE_ADJUSTMENTS");
            entity.Property(e => e.IncludeCharges).HasColumnName("INCLUDE_CHARGES");
            entity.Property(e => e.IncludeChargesCpt).HasColumnName("INCLUDE_CHARGES_CPT");
            entity.Property(e => e.IncludeChargesPrimaryDiagnosisCode).HasColumnName("INCLUDE_CHARGES_PRIMARY_DIAGNOSIS_CODE");
            entity.Property(e => e.IncludeDescriptions).HasColumnName("INCLUDE_DESCRIPTIONS");
            entity.Property(e => e.IncludeEstimatedInsurance).HasColumnName("INCLUDE_ESTIMATED_INSURANCE");
            entity.Property(e => e.IncludeEstimatedPatientBalance).HasColumnName("INCLUDE_ESTIMATED_PATIENT_BALANCE");
            entity.Property(e => e.IncludeFamilyCharges).HasColumnName("INCLUDE_FAMILY_CHARGES");
            entity.Property(e => e.IncludeOrderNotes).HasColumnName("INCLUDE_ORDER_NOTES");
            entity.Property(e => e.IncludePayments).HasColumnName("INCLUDE_PAYMENTS");
            entity.Property(e => e.IncludeProvider).HasColumnName("INCLUDE_PROVIDER");
            entity.Property(e => e.IncludeRefunds).HasColumnName("INCLUDE_REFUNDS");
            entity.Property(e => e.IncludeTransfers).HasColumnName("INCLUDE_TRANSFERS");
            entity.Property(e => e.StaffId).HasColumnName("STAFF_ID");
        });

        modelBuilder.Entity<StaffType>(entity =>
        {
            entity.Property(e => e.StaffTypeId).HasColumnName("StaffTypeID");
            entity.Property(e => e.StaffType1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("StaffType");
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.Property(e => e.StateId).HasColumnName("StateID");
            entity.Property(e => e.Abbreviation)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.State1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("State");
        });

        modelBuilder.Entity<StatementPaidOffChargesInformation>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("STATEMENT_PAID_OFF_CHARGES_INFORMATION");

            entity.Property(e => e.OrderChargeId).HasColumnName("ORDER_CHARGE_ID");
            entity.Property(e => e.StatementDateTime)
                .HasColumnType("datetime")
                .HasColumnName("STATEMENT_DATE_TIME");
        });

        modelBuilder.Entity<StatementParameter>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("STATEMENT_PARAMETERS");

            entity.Property(e => e.CurrentMostRecentPaymentWithinLine1)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("CURRENT_MOST_RECENT_PAYMENT_WITHIN_LINE1");
            entity.Property(e => e.CurrentMostRecentPaymentWithinLine2)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("CURRENT_MOST_RECENT_PAYMENT_WITHIN_LINE2");
            entity.Property(e => e.CurrentMostRecentPaymentWithinLine3)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("CURRENT_MOST_RECENT_PAYMENT_WITHIN_LINE3");
            entity.Property(e => e.CurrentMostRecentPaymentWithinLine4)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("CURRENT_MOST_RECENT_PAYMENT_WITHIN_LINE4");
            entity.Property(e => e.CurrentNoPaymentMadeLine1)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("CURRENT_NO_PAYMENT_MADE_LINE1");
            entity.Property(e => e.CurrentNoPaymentMadeLine2)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("CURRENT_NO_PAYMENT_MADE_LINE2");
            entity.Property(e => e.CurrentNoPaymentMadeLine3)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("CURRENT_NO_PAYMENT_MADE_LINE3");
            entity.Property(e => e.CurrentNoPaymentMadeLine4)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("CURRENT_NO_PAYMENT_MADE_LINE4");
            entity.Property(e => e.ExcludeInsuranceOpenOnlyCharges).HasColumnName("EXCLUDE_INSURANCE_OPEN_ONLY_CHARGES");
            entity.Property(e => e.MaximumBalance)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("MAXIMUM_BALANCE");
            entity.Property(e => e.MinimumBalance)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("MINIMUM_BALANCE");
            entity.Property(e => e.NextStatementDueDays).HasColumnName("NEXT_STATEMENT_DUE_DAYS");
            entity.Property(e => e.NinetyMostRecentPaymentWithinLine1)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("NINETY_MOST_RECENT_PAYMENT_WITHIN_LINE1");
            entity.Property(e => e.NinetyMostRecentPaymentWithinLine2)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("NINETY_MOST_RECENT_PAYMENT_WITHIN_LINE2");
            entity.Property(e => e.NinetyMostRecentPaymentWithinLine3)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("NINETY_MOST_RECENT_PAYMENT_WITHIN_LINE3");
            entity.Property(e => e.NinetyMostRecentPaymentWithinLine4)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("NINETY_MOST_RECENT_PAYMENT_WITHIN_LINE4");
            entity.Property(e => e.NinetyNoPaymentMadeLine1)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("NINETY_NO_PAYMENT_MADE_LINE1");
            entity.Property(e => e.NinetyNoPaymentMadeLine2)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("NINETY_NO_PAYMENT_MADE_LINE2");
            entity.Property(e => e.NinetyNoPaymentMadeLine3)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("NINETY_NO_PAYMENT_MADE_LINE3");
            entity.Property(e => e.NinetyNoPaymentMadeLine4)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("NINETY_NO_PAYMENT_MADE_LINE4");
            entity.Property(e => e.ShowPaidOffChargeOnce).HasColumnName("SHOW_PAID_OFF_CHARGE_ONCE");
            entity.Property(e => e.SixtyMostRecentPaymentWithinLine1)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("SIXTY_MOST_RECENT_PAYMENT_WITHIN_LINE1");
            entity.Property(e => e.SixtyMostRecentPaymentWithinLine2)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("SIXTY_MOST_RECENT_PAYMENT_WITHIN_LINE2");
            entity.Property(e => e.SixtyMostRecentPaymentWithinLine3)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("SIXTY_MOST_RECENT_PAYMENT_WITHIN_LINE3");
            entity.Property(e => e.SixtyMostRecentPaymentWithinLine4)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("SIXTY_MOST_RECENT_PAYMENT_WITHIN_LINE4");
            entity.Property(e => e.SixtyNoPaymentMadeLine1)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("SIXTY_NO_PAYMENT_MADE_LINE1");
            entity.Property(e => e.SixtyNoPaymentMadeLine2)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("SIXTY_NO_PAYMENT_MADE_LINE2");
            entity.Property(e => e.SixtyNoPaymentMadeLine3)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("SIXTY_NO_PAYMENT_MADE_LINE3");
            entity.Property(e => e.SixtyNoPaymentMadeLine4)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("SIXTY_NO_PAYMENT_MADE_LINE4");
            entity.Property(e => e.ThirtyMostRecentPaymentWithinLine1)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("THIRTY_MOST_RECENT_PAYMENT_WITHIN_LINE1");
            entity.Property(e => e.ThirtyMostRecentPaymentWithinLine2)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("THIRTY_MOST_RECENT_PAYMENT_WITHIN_LINE2");
            entity.Property(e => e.ThirtyMostRecentPaymentWithinLine3)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("THIRTY_MOST_RECENT_PAYMENT_WITHIN_LINE3");
            entity.Property(e => e.ThirtyMostRecentPaymentWithinLine4)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("THIRTY_MOST_RECENT_PAYMENT_WITHIN_LINE4");
            entity.Property(e => e.ThirtyNoPaymentMadeLine1)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("THIRTY_NO_PAYMENT_MADE_LINE1");
            entity.Property(e => e.ThirtyNoPaymentMadeLine2)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("THIRTY_NO_PAYMENT_MADE_LINE2");
            entity.Property(e => e.ThirtyNoPaymentMadeLine3)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("THIRTY_NO_PAYMENT_MADE_LINE3");
            entity.Property(e => e.ThirtyNoPaymentMadeLine4)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("THIRTY_NO_PAYMENT_MADE_LINE4");
        });

        modelBuilder.Entity<StatementPaymentsInformaiton>(entity =>
        {
            entity.HasKey(e => e.StatementPaymentsId);

            entity.ToTable("STATEMENT_PAYMENTS_INFORMAITON");

            entity.Property(e => e.StatementPaymentsId).HasColumnName("STATEMENT_PAYMENTS_ID");
            entity.Property(e => e.AmountAppliedToCharge).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.Notes)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.OrderChargeId).HasColumnName("ORDER_CHARGE_ID");
            entity.Property(e => e.PatientPaymentId).HasColumnName("PATIENT_PAYMENT_ID");
            entity.Property(e => e.TransactionId).HasColumnName("TRANSACTION_ID");
        });

        modelBuilder.Entity<StatementReportsInformation>(entity =>
        {
            entity.ToTable("STATEMENT_REPORTS_INFORMATION");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ReportDateTime)
                .HasColumnType("datetime")
                .HasColumnName("REPORT_DATE_TIME");
            entity.Property(e => e.ReportFilePath)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("REPORT_FILE_PATH");
            entity.Property(e => e.StaffId).HasColumnName("STAFF_ID");
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StatusId>(entity =>
        {
            entity.HasKey(e => e.StatusId1).HasName("PK__StatusIDs__15502E78");

            entity.ToTable("StatusIDs");

            entity.Property(e => e.StatusId1).HasColumnName("StatusID");
            entity.Property(e => e.StatusName)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TaxAndInsuranceCrossReference>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TaxAndInsuranceCrossReference");
        });

        modelBuilder.Entity<TaxAndProcedureCrossReference>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TaxAndProcedureCrossReference");

            entity.Property(e => e.Cptid).HasColumnName("CPTID");
        });

        modelBuilder.Entity<TaxCrossReference>(entity =>
        {
            entity.HasKey(e => e.TaxCrossReferenceId).HasName("PK__TaxCross__25D5EEE49CCB7742");

            entity.ToTable("TaxCrossReference");

            entity.Property(e => e.TaxCrossReferenceId).HasColumnName("TaxCrossReferenceID");
            entity.Property(e => e.BillingLocationId).HasColumnName("BillingLocationID");
            entity.Property(e => e.TaxPercentage).HasColumnType("decimal(5, 2)");
        });

        modelBuilder.Entity<TaxTable>(entity =>
        {
            entity.HasKey(e => e.TaxId);

            entity.ToTable("TaxTable");

            entity.Property(e => e.TaxId).HasColumnName("TaxID");
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.BillingLocationId).HasColumnName("BillingLocationID");
            entity.Property(e => e.InsuranceId).HasColumnName("InsuranceID");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.TaxPercent).HasColumnType("decimal(7, 4)");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<TaxType>(entity =>
        {
            entity.HasKey(e => e.TaxTypeId).HasName("PK__TaxTypes__B5343F4378A4D8D4");

            entity.Property(e => e.Code)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
        });

        modelBuilder.Entity<TaxesList>(entity =>
        {
            entity.HasKey(e => e.TaxListId).HasName("PK__TaxesLis__FA7B05DCF05478C4");

            entity.ToTable("TaxesList");

            entity.Property(e => e.CptId).HasColumnName("CptID");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TaxonomyCode>(entity =>
        {
            entity.HasKey(e => e.TaxonomyId).HasName("PK__Taxonomy__46220BE861662167");

            entity.ToTable("Taxonomy_Codes");

            entity.Property(e => e.TaxonomyId).HasColumnName("Taxonomy_Id");
            entity.Property(e => e.Classification)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Code)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(5000)
                .IsUnicode(false);
            entity.Property(e => e.ProviderType)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Provider_Type");
            entity.Property(e => e.Specialization)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.SpecialtyCode)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Specialty_Code");
        });

        modelBuilder.Entity<TempDiagTable>(entity =>
        {
            entity.HasKey(e => e.SortOrder).HasName("PK__tempDiag__55A193B635CF2087");

            entity.ToTable("tempDiagTABLE");

            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.DiagnosisCode)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TempDiagTable2>(entity =>
        {
            entity.HasKey(e => e.SortOrder).HasName("PK__tempDiag__55A193B6DEBCAAA6");

            entity.ToTable("tempDiagTABLE2");

            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.DiagnosisCode)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TempPatient>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TempPatient");

            entity.Property(e => e.PatientId).HasColumnName("Patient_ID");
        });

        modelBuilder.Entity<TestTable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TestTable");

            entity.Property(e => e.AccountNo)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Adjustments).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.Balance).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.Charges).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OrderDate)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Payments).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.ServiceDate)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Testum>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TESTA");

            entity.Property(e => e.Value1).HasColumnName("VALUE1");
        });

        modelBuilder.Entity<TransactFoxFire>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Transact_FoxFire");

            entity.Property(e => e.Column0)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Column 0");
            entity.Property(e => e.Column1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Column 1");
            entity.Property(e => e.Column2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Column 2");
            entity.Property(e => e.Column3)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Column 3");
            entity.Property(e => e.Column4)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Column 4");
        });

        modelBuilder.Entity<TransactionCodesResponsibilityTempTable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TransactionCodesResponsibilityTempTable");

            entity.Property(e => e.ResponsibilityId).HasColumnName("ResponsibilityID");
            entity.Property(e => e.TransactionCodeId).HasColumnName("TransactionCodeID");
        });

        modelBuilder.Entity<TransactionHistory>(entity =>
        {
            entity.HasKey(e => e.TransactionId);

            entity.ToTable("TransactionHistory");

            entity.HasIndex(e => new { e.EventCategory, e.EventSponsorId }, "EventCategoryAndSponsorIDIndex");

            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            entity.Property(e => e.EventCategory)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EventDateTime).HasColumnType("datetime");
            entity.Property(e => e.EventDetails).IsUnicode(false);
            entity.Property(e => e.EventSponsorId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EventSponsorID");
            entity.Property(e => e.EventType)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Notes)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.StaffId).HasColumnName("StaffID");
        });

        modelBuilder.Entity<TransactionTempTable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TransactionTempTable");

            entity.Property(e => e.Active)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.CreditDebitDescriptionId).HasColumnName("Credit_Debit_Description_ID");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.TransactionCode)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TransactionTotalByOrderChargeTempTable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TransactionTotalByOrderChargeTempTable");

            entity.HasIndex(e => e.OrderChargeId, "OrderChargeId_Index");

            entity.Property(e => e.Responsibility)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Sum).HasColumnType("decimal(38, 2)");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.VendorId).HasName("PK__Vendors__023D5A04");

            entity.Property(e => e.VendorId).HasColumnName("VendorID");
            entity.Property(e => e.AccountNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AccountRep1)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AccountRep2)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.ContactId).HasColumnName("ContactID");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.VendorName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Website)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VendorToManufacturer>(entity =>
        {
            entity.ToTable("VendorToManufacturer");

            entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");
            entity.Property(e => e.VendorId).HasColumnName("VendorID");
        });

        modelBuilder.Entity<VwDesign>(entity =>
        {
            entity.HasKey(e => e.DesignId);

            entity.ToTable("VW_Designs");

            entity.HasIndex(e => new { e.Code, e.Description, e.CatalogId }, "NonClusteredIndex-20181008-085242");

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Catalog).WithMany(p => p.VwDesigns)
                .HasForeignKey(d => d.CatalogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VW_Designs_VW_Lens_Types");
        });

        modelBuilder.Entity<VwDesignToProcedureXref>(entity =>
        {
            entity.ToTable("VW_Design_To_Procedure_Xref");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Fee).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.ProgressiveCptid).HasColumnName("ProgressiveCPTId");
            entity.Property(e => e.ProgressiveFee).HasColumnType("decimal(6, 2)");
        });

        modelBuilder.Entity<VwEssilorInterfaceLog>(entity =>
        {
            entity.HasKey(e => e.VwInterfaceMsgId);

            entity.ToTable("VW_ESSILOR_INTERFACE_LOG");

            entity.Property(e => e.VwInterfaceMsgId).HasColumnName("VW_INTERFACE_MSG_ID");
            entity.Property(e => e.InterfaceReceivedTime)
                .HasColumnType("datetime")
                .HasColumnName("INTERFACE_RECEIVED_TIME");
            entity.Property(e => e.InterfaceRequestMsg)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("INTERFACE_REQUEST_MSG");
            entity.Property(e => e.InterfaceResponseMsg)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("INTERFACE_RESPONSE_MSG");
            entity.Property(e => e.InterfaceSentTime)
                .HasColumnType("datetime")
                .HasColumnName("INTERFACE_SENT_TIME");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");
            entity.Property(e => e.LabOrderId).HasColumnName("LAB_ORDER_ID");
            entity.Property(e => e.RequestFileName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("REQUEST_FILE_NAME");
            entity.Property(e => e.ResponseFileName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("RESPONSE_FILE_NAME");
            entity.Property(e => e.SentBy).HasColumnName("SENT_BY");
        });

        modelBuilder.Entity<VwFrameType>(entity =>
        {
            entity.HasKey(e => e.FrameTypeId);

            entity.ToTable("VW_Frame_Types");

            entity.HasIndex(e => new { e.Code, e.Description, e.CatalogId }, "NonClusteredIndex-20181008-085410");

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Catalog).WithMany(p => p.VwFrameTypes)
                .HasForeignKey(d => d.CatalogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VW_Frame_Types_VW_Supplier_Catalog");
        });

        modelBuilder.Entity<VwGetVwOrderDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwGet_Vw_Order_Details");

            entity.Property(e => e.PatientName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SentDate).HasColumnType("datetime");
            entity.Property(e => e.SentStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VwOrderId)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwIncompatibleTreatmentsMaster>(entity =>
        {
            entity.ToTable("VW_Incompatible_Treatments_Master");

            entity.Property(e => e.CatalogId).HasColumnName("catalogId");

            entity.HasOne(d => d.Catalog).WithMany(p => p.VwIncompatibleTreatmentsMasters)
                .HasForeignKey(d => d.CatalogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VW_Incompatible_Treatments_Master_VW_Supplier_Catalog");

            entity.HasOne(d => d.IncompatibleTreatment).WithMany(p => p.VwIncompatibleTreatmentsMasterIncompatibleTreatments)
                .HasForeignKey(d => d.IncompatibleTreatmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VW_Incompatible_Treatments_Master_VW_Incompatible_Treatments_Master1");

            entity.HasOne(d => d.Treatment).WithMany(p => p.VwIncompatibleTreatmentsMasterTreatments)
                .HasForeignKey(d => d.TreatmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VW_Incompatible_Treatments_Master_VW_Incompatible_Treatments_Master");
        });

        modelBuilder.Entity<VwInhouseFrameType>(entity =>
        {
            entity.HasKey(e => e.FrameTypeId);

            entity.ToTable("VW_Inhouse_Frame_Types");

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
        });

        modelBuilder.Entity<VwInhouseLensDesign>(entity =>
        {
            entity.HasKey(e => e.DesignId).HasName("PK_VW_Inhoues_Lens_Designs");

            entity.ToTable("VW_Inhouse_Lens_Designs");

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
        });

        modelBuilder.Entity<VwInhouseLensMaterial>(entity =>
        {
            entity.HasKey(e => e.MaterialId);

            entity.ToTable("VW_Inhouse_Lens_Materials");

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
        });

        modelBuilder.Entity<VwInhouseLensType>(entity =>
        {
            entity.HasKey(e => e.LensTypeId);

            entity.ToTable("VW_Inhouse_Lens_Types");

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
        });

        modelBuilder.Entity<VwInhouseTreatment>(entity =>
        {
            entity.HasKey(e => e.TreatmentId);

            entity.ToTable("VW_Inhouse_Treatments");

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
        });

        modelBuilder.Entity<VwLabAccountInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("VW_Lab_Account_Info");

            entity.Property(e => e.BillAccount)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LabPassword)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LabUserName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ShipAccount)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwLensMaster>(entity =>
        {
            entity.ToTable("VW_Lens_Master");

            entity.HasIndex(e => e.DesignId, "DesignId");

            entity.HasIndex(e => e.MaterialId, "MaterialId");

            entity.HasIndex(e => new { e.MaterialId, e.DesignId, e.TreatmentId }, "NonClusteredIndex-20181008-085429");

            entity.HasIndex(e => new { e.MaterialId, e.DesignId }, "NonClusteredIndex-20181008-090321");

            entity.HasIndex(e => new { e.MaterialId, e.DesignId, e.TreatmentId, e.CatalogId }, "NonClusteredIndex-20181008-090350");

            entity.HasIndex(e => new { e.MaterialId, e.DesignId, e.CatalogId }, "NonClusteredIndex-20181008-090432");

            entity.HasIndex(e => e.TreatmentId, "TreatmentId");

            entity.Property(e => e.LensDescription)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Catalog).WithMany(p => p.VwLensMasters)
                .HasForeignKey(d => d.CatalogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VW_Lens_Master_VW_Supplier_Catalog");

            entity.HasOne(d => d.Design).WithMany(p => p.VwLensMasters)
                .HasForeignKey(d => d.DesignId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VW_Lens_Master_VW_Designs");

            entity.HasOne(d => d.Material).WithMany(p => p.VwLensMasters)
                .HasForeignKey(d => d.MaterialId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VW_Lens_Master_VW_Materials");

            entity.HasOne(d => d.Treatment).WithMany(p => p.VwLensMasters)
                .HasForeignKey(d => d.TreatmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VW_Lens_Master_VW_Treatments");
        });

        modelBuilder.Entity<VwLensType>(entity =>
        {
            entity.HasKey(e => e.LensTypeId);

            entity.ToTable("VW_Lens_Types");

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Catalog).WithMany(p => p.VwLensTypes)
                .HasForeignKey(d => d.CatalogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VW_Lens_Types_VW_Supplier_Catalog");
        });

        modelBuilder.Entity<VwMaterial>(entity =>
        {
            entity.HasKey(e => e.MaterialId);

            entity.ToTable("VW_Materials");

            entity.HasIndex(e => new { e.Code, e.Description, e.CatalogId }, "NonClusteredIndex-20181008-090509");

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Catalog).WithMany(p => p.VwMaterials)
                .HasForeignKey(d => d.CatalogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VW_Materials_VW_Supplier_Catalog");
        });

        modelBuilder.Entity<VwMaterialToProcedureXref>(entity =>
        {
            entity.ToTable("VW_Material_To_Procedure_Xref");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Fee).HasColumnType("decimal(6, 2)");
        });

        modelBuilder.Entity<VwOrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailsId);

            entity.ToTable("VW_Order_Details");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.OrderXmlString).IsUnicode(false);
            entity.Property(e => e.PatientName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SentDate).HasColumnType("datetime");
            entity.Property(e => e.SentOrderId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SentStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SupplierName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.VwExchangeId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VwOrderId)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwOrderInfo>(entity =>
        {
            entity.ToTable("VW_OrderInfo");

            entity.HasIndex(e => e.OrderId, "OrderID");

            entity.Property(e => e.VworderInfoId).HasColumnName("VWOrderInfoId");
            entity.Property(e => e.Cape)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DominantEye)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.DominantHand)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.FrameModelText)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.HeCoefficient)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsOdeyeSelected).HasColumnName("IsODEyeSelected");
            entity.Property(e => e.IsOseyeSelected).HasColumnName("IsOSEyeSelected");
            entity.Property(e => e.LeftErcd)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LeftERCD");
            entity.Property(e => e.LeftVertexDistance)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LmsframeTypeId).HasColumnName("LMSFrameTypeID");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.Nvb)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("NVB");
            entity.Property(e => e.Odrxadd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ODRXAdd");
            entity.Property(e => e.OdrxsegHt)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ODRXSegHt");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.OrderSentDateTime).HasColumnType("datetime");
            entity.Property(e => e.Osrxadd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("OSRXAdd");
            entity.Property(e => e.OsrxsegHt)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("OSRXSegHt");
            entity.Property(e => e.PantoAngle)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PatientInitials)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.ProgressionLength)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ReadingDistance)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RightErcd)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("RightERCD");
            entity.Property(e => e.RightVertexDistance)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Shape)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.Size)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.SpecialInstructions)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.StCoefficient)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TreatmentComments)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.WrapAngle)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwSelectedMaterialCptsOfOrder>(entity =>
        {
            entity.ToTable("VW_SelectedMaterialCptsOfOrder");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<VwSelectedTreatmentsOfOrder>(entity =>
        {
            entity.HasKey(e => e.VwselectedTreatmentsId).HasName("PK_VWSelectedTreatments");

            entity.ToTable("VW_SelectedTreatmentsOfOrder");

            entity.HasIndex(e => e.OrderId, "OrderID");

            entity.Property(e => e.VwselectedTreatmentsId).HasColumnName("VWSelectedTreatmentsId");
        });

        modelBuilder.Entity<VwSupplierCatalog>(entity =>
        {
            entity.HasKey(e => e.SupplierId);

            entity.ToTable("VW_Supplier_Catalog");

            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Address2)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LabName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdated).HasColumnType("datetime");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RefId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Supid)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SUPID");
            entity.Property(e => e.Supplier)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SupplierName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwTreatment>(entity =>
        {
            entity.HasKey(e => e.TreatmentId);

            entity.ToTable("VW_Treatments");

            entity.HasIndex(e => new { e.Code, e.Description, e.CatalogId }, "NonClusteredIndex-20181008-090529");

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Catalog).WithMany(p => p.VwTreatments)
                .HasForeignKey(d => d.CatalogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VW_Treatments_VW_Supplier_Catalog");
        });

        modelBuilder.Entity<VwTreatmentsToProcedureXref>(entity =>
        {
            entity.ToTable("VW_Treatments_To_Procedure_Xref");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Fee).HasColumnType("decimal(6, 2)");
        });

        modelBuilder.Entity<VwtempDiagnosisTable>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwtempDiagnosisTABLE");

            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.DiagnosisCode)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WebAppointmentRequestInformation>(entity =>
        {
            entity.HasKey(e => e.RequestId);

            entity.ToTable("WEB_APPOINTMENT_REQUEST_INFORMATION");

            entity.Property(e => e.RequestId).HasColumnName("REQUEST_ID");
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.Address1)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ADDRESS_1");
            entity.Property(e => e.Address2)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ADDRESS_2");
            entity.Property(e => e.AppointmentCreateDate)
                .HasColumnType("datetime")
                .HasColumnName("APPOINTMENT_CREATE_DATE");
            entity.Property(e => e.AppointmentDateTime)
                .HasColumnType("datetime")
                .HasColumnName("APPOINTMENT_DATE_TIME");
            entity.Property(e => e.AppointmentLength).HasColumnName("APPOINTMENT_LENGTH");
            entity.Property(e => e.AppointmentStatus).HasColumnName("APPOINTMENT_STATUS");
            entity.Property(e => e.AppointmentTypeId).HasColumnName("APPOINTMENT_TYPE_ID");
            entity.Property(e => e.BillingLocationId).HasColumnName("BILLING_LOCATION_ID");
            entity.Property(e => e.CellPhone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CELL_PHONE");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CITY");
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FIRST_NAME");
            entity.Property(e => e.Gender)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("GENDER");
            entity.Property(e => e.HomePhone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("HOME_PHONE");
            entity.Property(e => e.InactivatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("INACTIVATED_DATE_TIME");
            entity.Property(e => e.InactivatedOperator)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("INACTIVATED_OPERATOR");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LAST_NAME");
            entity.Property(e => e.Notes)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            entity.Property(e => e.PatientId).HasColumnName("PATIENT_ID");
            entity.Property(e => e.RequestReceivedDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("REQUEST_RECEIVED_DATE_TIME");
            entity.Property(e => e.RequestUpdatedDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("REQUEST_UPDATED_DATE_TIME");
            entity.Property(e => e.ResourceId).HasColumnName("RESOURCE_ID");
            entity.Property(e => e.Ssn)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("SSN");
            entity.Property(e => e.State)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("STATE");
            entity.Property(e => e.Title)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TITLE");
            entity.Property(e => e.WebAppointmentKey).HasColumnName("WEB_APPOINTMENT_KEY");
            entity.Property(e => e.WorkPhone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("WORK_PHONE");
            entity.Property(e => e.Zip)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("ZIP");
        });

        modelBuilder.Entity<XchargeUser>(entity =>
        {
            entity.ToTable("XChargeUsers");

            entity.Property(e => e.XchargeUserId).HasColumnName("XChargeUserID");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.XchargePassword)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("XChargePassword");
            entity.Property(e => e.XchargeProcessingAccountName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("XChargeProcessingAccountName");
            entity.Property(e => e.XchargeUserName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("XChargeUserName");
        });

        modelBuilder.Entity<_4pc1GetAppointmentAndRecallTypesView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("4PC_1_GET_APPOINTMENT_AND_RECALL_TYPES_VIEW");

            entity.Property(e => e.AppointmentTypeCode)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Appointment_Type_Code");
            entity.Property(e => e.AppointmentTypeDescription)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Appointment_Type_Description");
            entity.Property(e => e.AppointmentTypeId).HasColumnName("Appointment_Type_ID");
            entity.Property(e => e.CanSchedule).HasColumnName("Can_Schedule");
            entity.Property(e => e.DefaultAppointmentType).HasColumnName("Default_Appointment_Type");
            entity.Property(e => e.DefaultDuration).HasColumnName("Default_Duration");
            entity.Property(e => e.IsAppointmentType).HasColumnName("Is_Appointment_Type");
            entity.Property(e => e.IsExamType).HasColumnName("Is_Exam_Type");
            entity.Property(e => e.IsGroup)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.IsRecallType).HasColumnName("Is_Recall_Type");
            entity.Property(e => e.PatientRequired).HasColumnName("Patient_Required");
            entity.Property(e => e.StaffLocationId).HasColumnName("Staff_Location_ID");
            entity.Property(e => e.StaffLocationName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Staff_Location_Name");
            entity.Property(e => e.WebSchedulingType).HasColumnName("Web_Scheduling_Type");
        });

        modelBuilder.Entity<_4pc1GetAppointmentsByRulesView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("4PC_1_GET_APPOINTMENTS_BY_RULES_VIEW");

            entity.Property(e => e.AppointmentDescription)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Appointment_Description");
            entity.Property(e => e.AppointmentSubject)
                .HasMaxLength(212)
                .IsUnicode(false)
                .HasColumnName("Appointment_Subject");
            entity.Property(e => e.AppointmentType)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Appointment_Type");
            entity.Property(e => e.AppointmentTypeId).HasColumnName("Appointment_Type_ID");
            entity.Property(e => e.CanSchedule).HasColumnName("Can_Schedule");
            entity.Property(e => e.DefaultAppointmentType).HasColumnName("Default_Appointment_Type");
            entity.Property(e => e.EndTime)
                .HasColumnType("datetime")
                .HasColumnName("End_Time");
            entity.Property(e => e.IsExamType).HasColumnName("Is_Exam_Type");
            entity.Property(e => e.IsGroup)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("Is_Group");
            entity.Property(e => e.PatientRequired).HasColumnName("Patient_Required");
            entity.Property(e => e.Resource)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ResourceId).HasColumnName("Resource_ID");
            entity.Property(e => e.RuleId).HasColumnName("Rule_ID");
            entity.Property(e => e.RuleName)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Rule_Name");
            entity.Property(e => e.SchedulingLocation)
                .HasMaxLength(553)
                .IsUnicode(false)
                .HasColumnName("Scheduling_Location");
            entity.Property(e => e.SchedulingLocationId).HasColumnName("Scheduling_Location_ID");
            entity.Property(e => e.StaffLocationId).HasColumnName("Staff_Location_ID");
            entity.Property(e => e.StaffLocationName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Staff_Location_Name");
            entity.Property(e => e.StartTime)
                .HasColumnType("datetime")
                .HasColumnName("Start_Time");
            entity.Property(e => e.WebSchedule).HasColumnName("Web_Schedule");
        });

        modelBuilder.Entity<_4pc1GetAppointmentsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("4PC_1_GET_APPOINTMENTS_VIEW");

            entity.Property(e => e.AppointmentConfirmed).HasColumnName("Appointment_Confirmed");
            entity.Property(e => e.AppointmentCreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Appointment_Created_Date");
            entity.Property(e => e.AppointmentDate).HasColumnName("Appointment_Date");
            entity.Property(e => e.AppointmentId).HasColumnName("Appointment_ID");
            entity.Property(e => e.AppointmentLength).HasColumnName("Appointment_Length");
            entity.Property(e => e.AppointmentLocation)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Appointment_Location");
            entity.Property(e => e.AppointmentModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("Appointment_Modified_Date");
            entity.Property(e => e.AppointmentProvider)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Appointment_Provider");
            entity.Property(e => e.AppointmentReason)
                .HasMaxLength(2000)
                .HasColumnName("Appointment_Reason");
            entity.Property(e => e.AppointmentStatus)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("Appointment_Status");
            entity.Property(e => e.AppointmentTime).HasColumnName("Appointment_Time");
            entity.Property(e => e.AppointmentType)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Appointment_Type");
            entity.Property(e => e.AppointmentTypeId).HasColumnName("Appointment_Type_ID");
            entity.Property(e => e.IsNoShow).HasColumnName("Is_No_Show");
            entity.Property(e => e.PatientId).HasColumnName("Patient_ID");
            entity.Property(e => e.PatientShowedUp).HasColumnName("Patient_Showed_Up");
            entity.Property(e => e.PriorAppointmentId).HasColumnName("Prior_Appointment_ID");
            entity.Property(e => e.ResourceId).HasColumnName("Resource_ID");
            entity.Property(e => e.SchedulingLocationId).HasColumnName("Scheduling_Location_ID");
            entity.Property(e => e.StaffLocationId).HasColumnName("Staff_Location_ID");
            entity.Property(e => e._4pcAppointmentKey).HasColumnName("4PC_APPOINTMENT_KEY");
        });

        modelBuilder.Entity<_4pc1GetLocationsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("4PC_1_GET_LOCATIONS_VIEW");

            entity.Property(e => e.IsSchedulingLocation).HasColumnName("Is_Scheduling_Location");
            entity.Property(e => e.SchedulingLocationCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Scheduling_Location_Code");
            entity.Property(e => e.SchedulingLocationId).HasColumnName("Scheduling_Location_ID");
            entity.Property(e => e.SchedulingLocationName)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Scheduling_Location_Name");
            entity.Property(e => e.StaffLocationActive).HasColumnName("Staff_Location_Active");
            entity.Property(e => e.StaffLocationId).HasColumnName("Staff_Location_ID");
            entity.Property(e => e.StaffLocationName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Staff_Location_Name");
        });

        modelBuilder.Entity<_4pc1GetOrderStatusView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("4PC_1_GET_ORDER_STATUS_VIEW");

            entity.Property(e => e.IsDefaultStatus).HasColumnName("Is_Default_Status");
            entity.Property(e => e.ProductPickUpXrefStatusType)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("Product_PickUP_XREF_Status_Type");
            entity.Property(e => e.Status)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.StatusId).HasColumnName("Status_Id");
        });

        modelBuilder.Entity<_4pc1GetPatientInsuranceView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("4PC_1_GET_PATIENT_INSURANCE_VIEW");

            entity.Property(e => e.InsCompanyCode)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Code");
            entity.Property(e => e.InsCompanyName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Ins_Company_Name");
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
            entity.Property(e => e.PatientInsuranceId).HasColumnName("Patient_Insurance_Id");
        });

        modelBuilder.Entity<_4pc1GetPatientProvidersView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("4PC_1_GET_PATIENT_PROVIDERS_VIEW");

            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.IsReferringProvider).HasColumnName("Is_Referring_Provider");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Middle_Name");
            entity.Property(e => e.PatientProviderId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Patient_Provider_ID");
            entity.Property(e => e.ProviderCode)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Provider_Code");
        });

        modelBuilder.Entity<_4pc1GetPatientsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("4PC_1_GET_PATIENTS_VIEW");

            entity.Property(e => e.AccountNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Account_Number");
            entity.Property(e => e.Address1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ADDRESS_1");
            entity.Property(e => e.Address2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ADDRESS_2");
            entity.Property(e => e.CellPhone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Cell_Phone");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DoNotContactAutomatedPhone).HasColumnName("Do_Not_Contact_Automated_Phone");
            entity.Property(e => e.DoNotContactEmail).HasColumnName("Do_Not_Contact_Email");
            entity.Property(e => e.DoNotContactHumanPhone).HasColumnName("Do_Not_Contact_Human_Phone");
            entity.Property(e => e.DoNotContactPostal).HasColumnName("Do_Not_Contact_Postal");
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HomePhone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Home_Phone");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.IsDeceased).HasColumnName("Is_Deceased");
            entity.Property(e => e.Language)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastExamAppointmentTypeId).HasColumnName("Last_Exam_Appointment_Type_Id");
            entity.Property(e => e.LastExamBillingLocationId).HasColumnName("Last_Exam_Billing_Location_Id");
            entity.Property(e => e.LastExamResourceId).HasColumnName("Last_Exam_Resource_Id");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Middle_Name");
            entity.Property(e => e.PatientCommunicationPreference1)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Patient_Communication_Preference1");
            entity.Property(e => e.PatientCommunicationPreference2)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Patient_Communication_Preference2");
            entity.Property(e => e.PatientCommunicationPreference3)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Patient_Communication_Preference3");
            entity.Property(e => e.PatientCreateDate)
                .HasColumnType("datetime")
                .HasColumnName("Patient_Create_Date");
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
            entity.Property(e => e.PatientLastExamDate).HasColumnName("Patient_Last_Exam_Date");
            entity.Property(e => e.PatientLastModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("Patient_Last_Modified_Date");
            entity.Property(e => e.PatientProviderId).HasColumnName("Patient_Provider_ID");
            entity.Property(e => e.PreferredDoNotContact).HasColumnName("Preferred_Do_Not_Contact");
            entity.Property(e => e.Ssn)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SSN");
            entity.Property(e => e.State)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.WorkPhone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Work_Phone");
            entity.Property(e => e.Zip)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<_4pc1GetProductPickupOrdersView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("4PC_1_GET_PRODUCT_PICKUP_ORDERS_VIEW");

            entity.Property(e => e.CancelledDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Cancelled_Date_Time");
            entity.Property(e => e.LastModifiedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Last_Modified_Date_Time");
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.NotifiedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Notified_Date_Time");
            entity.Property(e => e.OrderActive).HasColumnName("Order_Active");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("Order_Date");
            entity.Property(e => e.OrderId).HasColumnName("Order_Id");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Order_Status");
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
            entity.Property(e => e.PatientNotifiedBy4pc).HasColumnName("Patient_Notified_By_4PC");
            entity.Property(e => e.PickedUpDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Picked_Up_Date_Time");
            entity.Property(e => e.ProductBrand)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Product_Brand");
            entity.Property(e => e.ProductType)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("Product_Type");
            entity.Property(e => e.ProviderId).HasColumnName("Provider_Id");
            entity.Property(e => e.ReceivedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Received_Date_Time");
            entity.Property(e => e.StaffLocation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Staff_Location");
            entity.Property(e => e.StaffLocationId).HasColumnName("Staff_Location_ID");
            entity.Property(e => e.StatusChangedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Status_Changed_Date_Time");
        });

        modelBuilder.Entity<_4pc1GetProviderAndResourcesView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("4PC_1_GET_PROVIDER_AND_RESOURCES_VIEW");

            entity.Property(e => e.ResourceCode)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Resource_Code");
            entity.Property(e => e.ResourceId).HasColumnName("Resource_ID");
            entity.Property(e => e.ResourceName)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Resource_Name");
            entity.Property(e => e.SpecialtyCode)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Specialty_Code");
            entity.Property(e => e.SpecialtyDescription)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Specialty_Description");
            entity.Property(e => e.StaffLocationId).HasColumnName("Staff_Location_ID");
            entity.Property(e => e.StaffLocationName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Staff_Location_Name");
        });

        modelBuilder.Entity<_4pc1GetRecallsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("4PC_1_GET_RECALLS_VIEW");

            entity.Property(e => e.AppointmentTypeId).HasColumnName("Appointment_Type_ID");
            entity.Property(e => e.PatientId).HasColumnName("Patient_ID");
            entity.Property(e => e.RecallCreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Recall_Created_Date_Time");
            entity.Property(e => e.RecallDate).HasColumnName("Recall_Date");
            entity.Property(e => e.RecallId).HasColumnName("Recall_ID");
            entity.Property(e => e.RecallLocation)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Recall_Location");
            entity.Property(e => e.RecallModifiedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Recall_Modified_Date_Time");
            entity.Property(e => e.RecallProvider)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Recall_Provider");
            entity.Property(e => e.RecallReason)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Recall_Reason");
            entity.Property(e => e.ResourceId).HasColumnName("Resource_ID");
            entity.Property(e => e.SchedulingLocationId).HasColumnName("Scheduling_Location_ID");
            entity.Property(e => e.StaffLocationId).HasColumnName("Staff_Location_ID");
        });

        modelBuilder.Entity<_4pc1GetSettingsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("4PC_1_GET_SETTINGS_VIEW");

            entity.Property(e => e.AppointmentsReminderAndCancellationActive).HasColumnName("Appointments_Reminder_And_Cancellation_Active");
            entity.Property(e => e.AutomaticallyConvertRequestToAppointment).HasColumnName("Automatically_Convert_Request_To_Appointment");
            entity.Property(e => e.ProductPickUpActive).HasColumnName("Product_PickUp_Active");
            entity.Property(e => e.RecallsActive).HasColumnName("Recalls_Active");
            entity.Property(e => e.StaffLocationId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Staff_Location_ID");
            entity.Property(e => e.StaffLocationName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Staff_Location_Name");
            entity.Property(e => e.WebScheduleActive).HasColumnName("Web_Schedule_Active");
        });

        modelBuilder.Entity<_4pc1GetVersionInformationView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("4PC_1_GET_VERSION_INFORMATION_VIEW");

            entity.Property(e => e.FfpmLastUpdatedDateTime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FFPM_Last_Updated_DateTime");
            entity.Property(e => e.FfpmVersionNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FFPM_Version_Number");
            entity.Property(e => e._4pcApplicationLastUpdatedDateTime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("4PC_Application_Last_Updated_DateTime");
            entity.Property(e => e._4pcVersionNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("4PC_Version_Number");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
