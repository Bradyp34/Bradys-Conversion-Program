using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class ImgDocTemplate
{
    public int TemplateId { get; set; }

    public string? TemplateName { get; set; }

    public string? TemplateDescription { get; set; }

    public byte[]? TemplateRtf { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public long? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsEditable { get; set; }

    public bool? SignConsent { get; set; }

    public bool? SignNpp { get; set; }

    public bool IsSchedulingRelatedTemplate { get; set; }
}
