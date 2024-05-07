using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class Staff
{
    public long StaffId { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public long? LoginId { get; set; }

    public string? ProviderCode { get; set; }

    public bool? Active { get; set; }

    public int? LevelId { get; set; }

    public int? StaffTypeId { get; set; }

    public bool? ManageSchedulingOperators { get; set; }

    public bool ProcessClaims { get; set; }

    public bool Finalize { get; set; }

    public bool ProcessMonthEnd { get; set; }

    public bool ProcessYearEnd { get; set; }

    public bool ProcessAnalysisReports { get; set; }

    public bool SendStatements { get; set; }

    public bool ManageStatementParameters { get; set; }

    public bool ViewProductPickUp { get; set; }

    public bool SendChargeToCcb { get; set; }

    public bool ManageWebSchedule { get; set; }

    public bool AssignToOrder { get; set; }

    public bool CanUpdateStaffOnOrder { get; set; }

    public bool ManageOpenEdgeSettings { get; set; }

    public bool ManageDashboardPermissions { get; set; }

    public bool NavigateToScreenEnabled { get; set; }

    public bool ManageLmscatalogSettings { get; set; }

    public bool ManageLmsmaintenance { get; set; }
}
