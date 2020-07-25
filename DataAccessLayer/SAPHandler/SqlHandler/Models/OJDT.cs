﻿using System;
using System.Collections.Generic;

namespace DataAccessLayer.SAPHandler.SqlHandler.Models
{
    public partial class OJDT
    {
        public int? BatchNum { get; set; }
        public int TransId { get; set; }
        public string BtfStatus { get; set; }
        public string TransType { get; set; }
        public string BaseRef { get; set; }
        public DateTime? RefDate { get; set; }
        public string Memo { get; set; }
        public string Ref1 { get; set; }
        public string Ref2 { get; set; }
        public int? CreatedBy { get; set; }
        public decimal? LocTotal { get; set; }
        public decimal? FcTotal { get; set; }
        public decimal? SysTotal { get; set; }
        public string TransCode { get; set; }
        public string OrignCurr { get; set; }
        public decimal? TransRate { get; set; }
        public int? BtfLine { get; set; }
        public string TransCurr { get; set; }
        public string Project { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? TaxDate { get; set; }
        public string PCAddition { get; set; }
        public int? FinncPriod { get; set; }
        public string DataSource { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public short? UserSign { get; set; }
        public short? UserSign2 { get; set; }
        public string RefndRprt { get; set; }
        public int? LogInstanc { get; set; }
        public string ObjType { get; set; }
        public string Indicator { get; set; }
        public string AdjTran { get; set; }
        public string RevSource { get; set; }
        public DateTime? StornoDate { get; set; }
        public int? StornoToTr { get; set; }
        public string AutoStorno { get; set; }
        public string Corisptivi { get; set; }
        public DateTime? VatDate { get; set; }
        public string StampTax { get; set; }
        public short Series { get; set; }
        public int Number { get; set; }
        public string AutoVAT { get; set; }
        public short? DocSeries { get; set; }
        public string FolioPref { get; set; }
        public int? FolioNum { get; set; }
        public short? CreateTime { get; set; }
        public string BlockDunn { get; set; }
        public string ReportEU { get; set; }
        public string Report347 { get; set; }
        public string Printed { get; set; }
        public string DocType { get; set; }
        public int? AttNum { get; set; }
        public string GenRegNo { get; set; }
        public int? RG23APart2 { get; set; }
        public int? RG23CPart2 { get; set; }
        public int? MatType { get; set; }
        public string Creator { get; set; }
        public string Approver { get; set; }
        public int? Location { get; set; }
        public short? SeqCode { get; set; }
        public int? Serial { get; set; }
        public string SeriesStr { get; set; }
        public string SubStr { get; set; }
        public string AutoWT { get; set; }
        public decimal? WTSum { get; set; }
        public decimal? WTSumSC { get; set; }
        public decimal? WTSumFC { get; set; }
        public decimal? WTApplied { get; set; }
        public decimal? WTAppliedS { get; set; }
        public decimal? WTAppliedF { get; set; }
        public decimal? BaseAmnt { get; set; }
        public decimal? BaseAmntSC { get; set; }
        public decimal? BaseAmntFC { get; set; }
        public decimal? BaseVtAt { get; set; }
        public decimal? BaseVtAtSC { get; set; }
        public decimal? BaseVtAtFC { get; set; }
        public string VersionNum { get; set; }
        public int? BaseTrans { get; set; }
        public string ResidenNum { get; set; }
        public string OperatCode { get; set; }
        public string Ref3 { get; set; }
        public string SSIExmpt { get; set; }
        public string SignMsg { get; set; }
        public string SignDigest { get; set; }
        public string CertifNum { get; set; }
        public int? KeyVersion { get; set; }
        public int? CUP { get; set; }
        public int? CIG { get; set; }
        public string SupplCode { get; set; }
        public int? SPSrcType { get; set; }
        public int? SPSrcID { get; set; }
        public int? SPSrcDLN { get; set; }
        public string DeferedTax { get; set; }
        public int? AgrNo { get; set; }
        public int? SeqNum { get; set; }
        public string ECDPosTyp { get; set; }
        public string RptPeriod { get; set; }
        public DateTime? RptMonth { get; set; }
        public int? ExTransId { get; set; }
        public string PrlLinked { get; set; }
        public string PTICode { get; set; }
        public string Letter { get; set; }
        public int? FolNumFrom { get; set; }
        public int? FolNumTo { get; set; }
        public string RepSection { get; set; }
        public string ExclTaxRep { get; set; }
        public string U_B1SYS_WHT { get; set; }
    }
}
