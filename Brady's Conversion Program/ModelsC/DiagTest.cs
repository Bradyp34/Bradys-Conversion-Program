using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsC2;

[Table("DiagTest")]
public partial class DiagTest
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("PtID")]
    public int PtId { get; set; }

    [Column("VisitID")]
    public int? VisitId { get; set; }

    [Column("DOSDate")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Dosdate { get; set; }

    [Column("GonioAngleDepthSuOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? GonioAngleDepthSuOd { get; set; }

    [Column("GonioAngleDepthMedialOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? GonioAngleDepthMedialOd { get; set; }

    [Column("GonioAngleDepthInOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? GonioAngleDepthInOd { get; set; }

    [Column("GonioAngleDepthTemporalOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? GonioAngleDepthTemporalOd { get; set; }

    [Column("GonioAngleStructureSuOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? GonioAngleStructureSuOd { get; set; }

    [Column("GonioAngleStructureMedialOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? GonioAngleStructureMedialOd { get; set; }

    [Column("GonioAngleStructureInOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? GonioAngleStructureInOd { get; set; }

    [Column("GonioAngleStructureTemporalOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? GonioAngleStructureTemporalOd { get; set; }

    [Column("GonioAngleDepthSuOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? GonioAngleDepthSuOs { get; set; }

    [Column("GonioAngleDepthMedialOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? GonioAngleDepthMedialOs { get; set; }

    [Column("GonioAngleDepthInOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? GonioAngleDepthInOs { get; set; }

    [Column("GonioAngleDepthTemporalOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? GonioAngleDepthTemporalOs { get; set; }

    [Column("GonioAngleStructureSuOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? GonioAngleStructureSuOs { get; set; }

    [Column("GonioAngleStructureMedialOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? GonioAngleStructureMedialOs { get; set; }

    [Column("GonioAngleStructureInOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? GonioAngleStructureInOs { get; set; }

    [Column("GonioAngleStructureTemporalOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? GonioAngleStructureTemporalOs { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? GonioComments { get; set; }

    [Column("MBalanceSCOrtho")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceScortho { get; set; }

    [Column("MBalanceHorizSCPriGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceHorizScpriGaze { get; set; }

    [Column("MBalanceHorizTypeSCPriGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceHorizTypeScpriGaze { get; set; }

    [Column("MBalanceVertSCPriGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceVertScpriGaze { get; set; }

    [Column("MBalanceVertTypeSCPriGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceVertTypeScpriGaze { get; set; }

    [Column("MBalanceHorizSCUpGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceHorizScupGaze { get; set; }

    [Column("MBalanceHorizTypeSCUpGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceHorizTypeScupGaze { get; set; }

    [Column("MBalanceVertSCUpGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceVertScupGaze { get; set; }

    [Column("MBalanceVertTypeSCUpGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceVertTypeScupGaze { get; set; }

    [Column("MBalanceHorizSCDownGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceHorizScdownGaze { get; set; }

    [Column("MBalanceHorizTypeSCDownGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceHorizTypeScdownGaze { get; set; }

    [Column("MBalanceVertSCDownGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceVertScdownGaze { get; set; }

    [Column("MBalanceVertTypeSCDownGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceVertTypeScdownGaze { get; set; }

    [Column("MBalanceHorizSCRtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceHorizScrtGaze { get; set; }

    [Column("MBalanceHorizTypeSCRtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceHorizTypeScrtGaze { get; set; }

    [Column("MBalanceVertSCRtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceVertScrtGaze { get; set; }

    [Column("MBalanceVertTypeSCRtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceVertTypeScrtGaze { get; set; }

    [Column("MBalanceHorizSCLtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceHorizScltGaze { get; set; }

    [Column("MBalanceHorizTypeSCLtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceHorizTypeScltGaze { get; set; }

    [Column("MBalanceVertSCLtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceVertScltGaze { get; set; }

    [Column("MBalanceVertTypeSCLtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceVertTypeScltGaze { get; set; }

    [Column("MBalanceCCOrtho")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceCcortho { get; set; }

    [Column("MBalanceHorizCCPriGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceHorizCcpriGaze { get; set; }

    [Column("MBalanceHorizTypeCCPriGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceHorizTypeCcpriGaze { get; set; }

    [Column("MBalanceVertCCPriGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceVertCcpriGaze { get; set; }

    [Column("MBalanceVertTypeCCPriGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceVertTypeCcpriGaze { get; set; }

    [Column("MBalanceHorizCCUpGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceHorizCcupGaze { get; set; }

    [Column("MBalanceHorizTypeCCUpGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceHorizTypeCcupGaze { get; set; }

    [Column("MBalanceVertCCUpGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceVertCcupGaze { get; set; }

    [Column("MBalanceVertTypeCCUpGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceVertTypeCcupGaze { get; set; }

    [Column("MBalanceHorizCCDownGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceHorizCcdownGaze { get; set; }

    [Column("MBalanceHorizTypeCCDownGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceHorizTypeCcdownGaze { get; set; }

    [Column("MBalanceVertCCDownGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceVertCcdownGaze { get; set; }

    [Column("MBalanceVertTypeCCDownGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceVertTypeCcdownGaze { get; set; }

    [Column("MBalanceHorizCCRtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceHorizCcrtGaze { get; set; }

    [Column("MBalanceHorizTypeCCRtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceHorizTypeCcrtGaze { get; set; }

    [Column("MBalanceVertCCRtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceVertCcrtGaze { get; set; }

    [Column("MBalanceVertTypeCCRtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceVertTypeCcrtGaze { get; set; }

    [Column("MBalanceHorizCCLtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceHorizCcltGaze { get; set; }

    [Column("MBalanceHorizTypeCCLtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceHorizTypeCcltGaze { get; set; }

    [Column("MBalanceVertCCLtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceVertCcltGaze { get; set; }

    [Column("MBalanceVertTypeCCLtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceVertTypeCcltGaze { get; set; }

    [Column("MBalanceMethod")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceMethod { get; set; }

    [Column("GonioPigmentOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? GonioPigmentOd { get; set; }

    [Column("GonioPigmentOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? GonioPigmentOs { get; set; }

    [Column("MBalanceSCType")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceSctype { get; set; }

    [Column("MBalanceCCType")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceCctype { get; set; }

    [Column("MBalanceHorizSCUpRtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceHorizScupRtGaze { get; set; }

    [Column("MBalanceHorizTypeSCUpRtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceHorizTypeScupRtGaze { get; set; }

    [Column("MBalanceVertSCUpRtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceVertScupRtGaze { get; set; }

    [Column("MBalanceVertTypeSCUpRtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceVertTypeScupRtGaze { get; set; }

    [Column("MBalanceHorizSCDownRtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceHorizScdownRtGaze { get; set; }

    [Column("MBalanceHorizTypeSCDownRtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceHorizTypeScdownRtGaze { get; set; }

    [Column("MBalanceVertSCDownRtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceVertScdownRtGaze { get; set; }

    [Column("MBalanceVertTypeSCDownRtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceVertTypeScdownRtGaze { get; set; }

    [Column("MBalanceHorizSCUpLtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceHorizScupLtGaze { get; set; }

    [Column("MBalanceHorizTypeSCUpLtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceHorizTypeScupLtGaze { get; set; }

    [Column("MBalanceVertSCUpLtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceVertScupLtGaze { get; set; }

    [Column("MBalanceVertTypeSCUpLtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceVertTypeScupLtGaze { get; set; }

    [Column("MBalanceHorizSCDownLtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceHorizScdownLtGaze { get; set; }

    [Column("MBalanceHorizTypeSCDownLtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceHorizTypeScdownLtGaze { get; set; }

    [Column("MBalanceVertSCDownLtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceVertScdownLtGaze { get; set; }

    [Column("MBalanceVertTypeSCDownLtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceVertTypeScdownLtGaze { get; set; }

    [Column("MBalanceHorizCCUpRtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceHorizCcupRtGaze { get; set; }

    [Column("MBalanceHorizTypeCCUpRtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceHorizTypeCcupRtGaze { get; set; }

    [Column("MBalanceVertCCUpRtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceVertCcupRtGaze { get; set; }

    [Column("MBalanceVertTypeCCUpRtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceVertTypeCcupRtGaze { get; set; }

    [Column("MBalanceHorizCCDownRtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceHorizCcdownRtGaze { get; set; }

    [Column("MBalanceHorizTypeCCDownRtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceHorizTypeCcdownRtGaze { get; set; }

    [Column("MBalanceVertCCDownRtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceVertCcdownRtGaze { get; set; }

    [Column("MBalanceVertTypeCCDownRtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceVertTypeCcdownRtGaze { get; set; }

    [Column("MBalanceHorizCCUpLtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceHorizCcupLtGaze { get; set; }

    [Column("MBalanceHorizTypeCCUpLtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceHorizTypeCcupLtGaze { get; set; }

    [Column("MBalanceVertCCUpLtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceVertCcupLtGaze { get; set; }

    [Column("MBalanceVertTypeCCUpLtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceVertTypeCcupLtGaze { get; set; }

    [Column("MBalanceHorizCCDownLtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceHorizCcdownLtGaze { get; set; }

    [Column("MBalanceHorizTypeCCDownLtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceHorizTypeCcdownLtGaze { get; set; }

    [Column("MBalanceVertCCDownLtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceVertCcdownLtGaze { get; set; }

    [Column("MBalanceVertTypeCCDownLtGaze")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceVertTypeCcdownLtGaze { get; set; }

    [Column("SMotorFixPrefDist")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorFixPrefDist { get; set; }

    [Column("SMotorFixPrefNear")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorFixPrefNear { get; set; }

    [Column("SMotorNystagmus")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorNystagmus { get; set; }

    [Column("SMotorFrisby")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorFrisby { get; set; }

    [Column("SMotorLang")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorLang { get; set; }

    [Column("SMotorTitmusStereoFly")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorTitmusStereoFly { get; set; }

    [Column("SMotorTitmusStereoAnimals")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorTitmusStereoAnimals { get; set; }

    [Column("SMotorTitmusStereoCircles")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorTitmusStereoCircles { get; set; }

    [Column("SMotorRandotCircles")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorRandotCircles { get; set; }

    [Column("SMotorWorth4DotDist")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorWorth4DotDist { get; set; }

    [Column("SMotorWorth4DotNear")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorWorth4DotNear { get; set; }

    [Column("SMotorAVPattern")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorAvpattern { get; set; }

    [Column("SMotorDistStereo")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorDistStereo { get; set; }

    [Column("SMotorDistVectograph")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorDistVectograph { get; set; }

    [Column("SMotorNPC")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorNpc { get; set; }

    [Column("SMotorHorizVergBOBreak")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorHorizVergBobreak { get; set; }

    [Column("SMotorHorizVergBORecover")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorHorizVergBorecover { get; set; }

    [Column("SMotorHorizVergBIBreak")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorHorizVergBibreak { get; set; }

    [Column("SMotorHorizVergBIRecover")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorHorizVergBirecover { get; set; }

    [Column("SMotorVertVergBUBreak")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorVertVergBubreak { get; set; }

    [Column("SMotorVertVergBURecover")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorVertVergBurecover { get; set; }

    [Column("SMotorVertVergBDBreak")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorVertVergBdbreak { get; set; }

    [Column("SMotorVertVergBDRecover")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorVertVergBdrecover { get; set; }

    [Column("SMotorDMadRodOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorDmadRodOd { get; set; }

    [Column("SMotorDMadRodTorsionOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorDmadRodTorsionOd { get; set; }

    [Column("SMotorDMadRodOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorDmadRodOs { get; set; }

    [Column("SMotorDMadRodTorsionOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorDmadRodTorsionOs { get; set; }

    [Column("SMotorColorVisionOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorColorVisionOd { get; set; }

    [Column("SMotorColorVisionOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorColorVisionOs { get; set; }

    [Column("SMotorColorVisionType")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorColorVisionType { get; set; }

    [Column("SMotorABUTE")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorAbute { get; set; }

    [Column("SMotorHTRtHorizSC")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorHtrtHorizSc { get; set; }

    [Column("SMotorHTRtHorizTypeSC")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorHtrtHorizTypeSc { get; set; }

    [Column("SMotorHTRtVertSC")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorHtrtVertSc { get; set; }

    [Column("SMotorHTRtVertTypeSC")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorHtrtVertTypeSc { get; set; }

    [Column("SMotorHTLtHorizSC")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorHtltHorizSc { get; set; }

    [Column("SMotorHTLtHorizTypeSC")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorHtltHorizTypeSc { get; set; }

    [Column("SMotorHTLtVertSC")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorHtltVertSc { get; set; }

    [Column("SMotorHTLtVertTypeSC")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorHtltVertTypeSc { get; set; }

    [Column("SMotorHTRtHorizCC")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorHtrtHorizCc { get; set; }

    [Column("SMotorHTRtHorizTypeCC")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorHtrtHorizTypeCc { get; set; }

    [Column("SMotorHTRtVertCC")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorHtrtVertCc { get; set; }

    [Column("SMotorHTRtVertTypeCC")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorHtrtVertTypeCc { get; set; }

    [Column("SMotorHTLtHorizTypeCC")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorHtltHorizTypeCc { get; set; }

    [Column("SMotorHTLtVertCC")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorHtltVertCc { get; set; }

    [Column("SMotorHTLtVertTypeCC")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorHtltVertTypeCc { get; set; }

    [Column("SMotorHTLtHorizCC")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorHtltHorizCc { get; set; }

    [Column("SMotorHorizSCNear")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorHorizScnear { get; set; }

    [Column("SMotorHorizTypeSCNear")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorHorizTypeScnear { get; set; }

    [Column("SMotorVertSCNear")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorVertScnear { get; set; }

    [Column("SMotorVertTypeSCNear")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorVertTypeScnear { get; set; }

    [Column("SMotorHorizCCNear")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorHorizCcnear { get; set; }

    [Column("SMotorHorizTypeCCNear")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorHorizTypeCcnear { get; set; }

    [Column("SMotorVertCCNear")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorVertCcnear { get; set; }

    [Column("SMotorVertTypeCCNear")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorVertTypeCcnear { get; set; }

    [Column("SMotorHorizSCDist")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorHorizScdist { get; set; }

    [Column("SMotorHorizTypeSCDist")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorHorizTypeScdist { get; set; }

    [Column("SMotorVertSCDist")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorVertScdist { get; set; }

    [Column("SMotorVertTypeSCDist")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorVertTypeScdist { get; set; }

    [Column("SMotorHorizCCDist")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorHorizCcdist { get; set; }

    [Column("SMotorHorizTypeCCDist")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorHorizTypeCcdist { get; set; }

    [Column("SMotorVertCCDist")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorVertCcdist { get; set; }

    [Column("SMotorVertTypeCCDist")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorVertTypeCcdist { get; set; }

    [Column("SMotorHorizCCNear3Plus")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorHorizCcnear3Plus { get; set; }

    [Column("SMotorHorizTypeCCNear3Plus")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorHorizTypeCcnear3Plus { get; set; }

    [Column("SMotorVertCCNear3Plus")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorVertCcnear3Plus { get; set; }

    [Column("SMotorVertTypeCCNear3Plus")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorVertTypeCcnear3Plus { get; set; }

    [Column("MBalanceMethodSC")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceMethodSc { get; set; }

    [Column("MBalanceMethodCC")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MbalanceMethodCc { get; set; }

    [Column("SMotorPrismOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorPrismOd { get; set; }

    [Column("SMotorDirectionOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorDirectionOd { get; set; }

    [Column("SMotorPrismOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorPrismOs { get; set; }

    [Column("SMotorDirectionOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SmotorDirectionOs { get; set; }

    [Column("SMotorComments")]
    [StringLength(500)]
    [Unicode(false)]
    public string? SmotorComments { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }
}
