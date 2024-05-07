using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrscheduledTask
{
    public int EmrscheduledTaskId { get; set; }

    public int? OmsscheduledTaskId { get; set; }

    public string? ScheduledTaskName { get; set; }

    public string? ScheduledTaskDescription { get; set; }

    public int ScheduledTaskTypeId { get; set; }

    public int ScheduledTaskResultTypeId { get; set; }

    public string? CommandText { get; set; }

    public short IsEncrypted { get; set; }

    public DateTime ScheduledExecution { get; set; }

    public DateTime? LastAttemptedExecution { get; set; }

    public short? IsSuccessful { get; set; }

    public string? Result { get; set; }

    public DateTime? ResultsReportedAt { get; set; }

    public short ReturnResultsAsap { get; set; }

    public string? ExecutionOutput { get; set; }

    public short? MaintenanceTaskId { get; set; }

    public int? ExecutionDurationSeconds { get; set; }

    public int? ExecutionTimeoutOverrideSeconds { get; set; }

    public short RunOnSubscribers { get; set; }

    public short IsExecuting { get; set; }
}
