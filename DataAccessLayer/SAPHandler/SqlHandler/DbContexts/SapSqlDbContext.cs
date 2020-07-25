using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DataAccessLayer.SAPHandler.SqlHandler.Models;

namespace DataAccessLayer.SAPHandler.SqlHandler.DbContexts
{
    public partial class SapSqlDbContext : DbContext
    {
        public SapSqlDbContext()
        {
        }

        public SapSqlDbContext(DbContextOptions<SapSqlDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ADM1> ADM1 { get; set; }
        public virtual DbSet<ATC1> ATC1 { get; set; }
        public virtual DbSet<DLN1> DLN1 { get; set; }
        public virtual DbSet<DPI1> DPI1 { get; set; }
        public virtual DbSet<INV1> INV1 { get; set; }
        public virtual DbSet<ITM1> ITM1 { get; set; }
        public virtual DbSet<JDT1> JDT1 { get; set; }
        public virtual DbSet<OADM> OADM { get; set; }
        public virtual DbSet<OADP> OADP { get; set; }
        public virtual DbSet<OCLG> OCLG { get; set; }
        public virtual DbSet<OCLS> OCLS { get; set; }
        public virtual DbSet<OCLT> OCLT { get; set; }
        public virtual DbSet<OCRD> OCRD { get; set; }
        public virtual DbSet<OCRG> OCRG { get; set; }
        public virtual DbSet<ODLN> ODLN { get; set; }
        public virtual DbSet<ODPI> ODPI { get; set; }
        public virtual DbSet<ODSC> ODSC { get; set; }
        public virtual DbSet<OHEM> OHEM { get; set; }
        public virtual DbSet<OHPS> OHPS { get; set; }
        public virtual DbSet<OIDC> OIDC { get; set; }
        public virtual DbSet<OINV> OINV { get; set; }
        public virtual DbSet<OITB> OITB { get; set; }
        public virtual DbSet<OITM> OITM { get; set; }
        public virtual DbSet<OJDT> OJDT { get; set; }
        public virtual DbSet<OOND> OOND { get; set; }
        public virtual DbSet<OQUT> OQUT { get; set; }
        public virtual DbSet<ORDR> ORDR { get; set; }
        public virtual DbSet<ORIN> ORIN { get; set; }
        public virtual DbSet<OSLP> OSLP { get; set; }
        public virtual DbSet<OUDP> OUDP { get; set; }
        public virtual DbSet<QUT1> QUT1 { get; set; }
        public virtual DbSet<RDR1> RDR1 { get; set; }
        public virtual DbSet<RIN1> RIN1 { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ADM1>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("ADM1_PRIMARY");

                entity.Property(e => e.Code).HasDefaultValueSql("((1))");

                entity.Property(e => e.AddrType).HasMaxLength(100);

                entity.Property(e => e.AddrTypeF).HasMaxLength(100);

                entity.Property(e => e.AplShipPch)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ApyDRinAT)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ApyPRinAT)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.AsnBrnchBP)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.AssType).HasMaxLength(100);

                entity.Property(e => e.AuthPwd).HasMaxLength(100);

                entity.Property(e => e.AuthUser).HasMaxLength(100);

                entity.Property(e => e.BZStRegID).HasMaxLength(6);

                entity.Property(e => e.BZStSendID).HasMaxLength(11);

                entity.Property(e => e.Block).HasMaxLength(100);

                entity.Property(e => e.BlockF).HasMaxLength(100);

                entity.Property(e => e.Building).HasMaxLength(100);

                entity.Property(e => e.BuildingF).HasMaxLength(100);

                entity.Property(e => e.CEDivision).HasMaxLength(60);

                entity.Property(e => e.CERange).HasMaxLength(60);

                entity.Property(e => e.CERegNo).HasMaxLength(40);

                entity.Property(e => e.CeComRate).HasMaxLength(60);

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.CityF).HasMaxLength(100);

                entity.Property(e => e.CommerReg).HasMaxLength(60);

                entity.Property(e => e.CompNature).HasDefaultValueSql("((-1))");

                entity.Property(e => e.CompQualif).HasDefaultValueSql("((1))");

                entity.Property(e => e.CompnyType).HasMaxLength(100);

                entity.Property(e => e.CoopAssocT).HasDefaultValueSql("((-1))");

                entity.Property(e => e.Country).HasMaxLength(3);

                entity.Property(e => e.County).HasMaxLength(100);

                entity.Property(e => e.CountyF).HasMaxLength(100);

                entity.Property(e => e.CredCOrig)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CurrPeriod).HasMaxLength(10);

                entity.Property(e => e.DateOfInc).HasColumnType("datetime");

                entity.Property(e => e.DeclType).HasDefaultValueSql("((1))");

                entity.Property(e => e.DfBrnchPh)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.DspIBPDoc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.DspIITMDoc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.EccNo).HasMaxLength(40);

                entity.Property(e => e.EconActT).HasDefaultValueSql("((-1))");

                entity.Property(e => e.ElDigiCert).HasColumnType("ntext");

                entity.Property(e => e.EnbEAInv)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.EnbEATrns)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.EnbInItINC)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.EnbInItIQI)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.EnvTypeNFe).HasDefaultValueSql("((-1))");

                entity.Property(e => e.ExtRevAct)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Free1).HasMaxLength(3);

                entity.Property(e => e.Free2).HasMaxLength(3);

                entity.Property(e => e.GlblLocNum).HasMaxLength(50);

                entity.Property(e => e.IPIPeriod)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IPITaxCon)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ISComDecID).HasMaxLength(32);

                entity.Property(e => e.ISCstRecSt).HasMaxLength(6);

                entity.Property(e => e.ISDfltPath).HasColumnType("ntext");

                entity.Property(e => e.ISDnsce).HasMaxLength(10);

                entity.Property(e => e.ISDocAmLm).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ISDocQtLm).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ISDspNMass)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.ISExlDocAm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ISExlDocQt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ISForceCmp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.ISInstIntr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ISObligLvl)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ISSimpProc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.ISTaxState).HasMaxLength(3);

                entity.Property(e => e.ISVATRegEx).HasMaxLength(10);

                entity.Property(e => e.ISVATRegNo).HasMaxLength(100);

                entity.Property(e => e.ISValidKey).HasMaxLength(35);

                entity.Property(e => e.IntrntAdrs).HasMaxLength(50);

                entity.Property(e => e.IsCUITMndt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsStartup)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Jurisd).HasMaxLength(60);

                entity.Property(e => e.LnMlBrnch)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.LogInstanc).HasDefaultValueSql("((0))");

                entity.Property(e => e.MenuCode).HasMaxLength(60);

                entity.Property(e => e.NatureBiz).HasMaxLength(100);

                entity.Property(e => e.OKDPNum).HasMaxLength(7);

                entity.Property(e => e.Opt4ICMS)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PTLedgeGen)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('M')");

                entity.Property(e => e.PostInVat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ProfTax).HasDefaultValueSql("((-1))");

                entity.Property(e => e.SPEDProf).HasMaxLength(2);

                entity.Property(e => e.SnapShotId).HasDefaultValueSql("((0))");

                entity.Property(e => e.State).HasMaxLength(3);

                entity.Property(e => e.Street).HasMaxLength(100);

                entity.Property(e => e.StreetF).HasMaxLength(100);

                entity.Property(e => e.StreetNo).HasMaxLength(100);

                entity.Property(e => e.StreetNoF).HasMaxLength(100);

                entity.Property(e => e.Suframa).HasMaxLength(100);

                entity.Property(e => e.TaxIdNum4).HasMaxLength(100);

                entity.Property(e => e.TaxIdNum5).HasMaxLength(100);

                entity.Property(e => e.TaxIdNum6).HasMaxLength(100);

                entity.Property(e => e.TaxRptFrm).HasColumnType("datetime");

                entity.Property(e => e.UrlGoods).HasMaxLength(250);

                entity.Property(e => e.UrlInvType).HasMaxLength(250);

                entity.Property(e => e.ZipCode).HasMaxLength(20);

                entity.Property(e => e.ZipCodeF).HasMaxLength(20);
            });

            modelBuilder.Entity<ATC1>(entity =>
            {
                entity.HasKey(e => new { e.AbsEntry, e.Line })
                    .HasName("ATC1_PRIMARY");

                entity.Property(e => e.Copied)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.FileExt).HasMaxLength(8);

                entity.Property(e => e.FileName).HasMaxLength(254);

                entity.Property(e => e.Override)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.srcPath).HasColumnType("ntext");

                entity.Property(e => e.subPath).HasMaxLength(254);

                entity.Property(e => e.trgtPath).HasColumnType("ntext");
            });

            modelBuilder.Entity<DLN1>(entity =>
            {
                entity.HasKey(e => new { e.DocEntry, e.LineNum })
                    .HasName("DLN1_PRIMARY");

                entity.HasIndex(e => e.AcctCode)
                    .HasName("DLN1_ACCOUNT");

                entity.HasIndex(e => e.Currency)
                    .HasName("DLN1_CURRENCY");

                entity.HasIndex(e => e.LineStatus)
                    .HasName("DLN1_STATUS");

                entity.HasIndex(e => e.OwnerCode)
                    .HasName("DLN1_OWNER_CODE");

                entity.HasIndex(e => new { e.DocEntry, e.VisOrder })
                    .HasName("DLN1_VIS_ORDER");

                entity.HasIndex(e => new { e.BaseEntry, e.BaseType, e.BaseLine })
                    .HasName("DLN1_BASE_ENTRY");

                entity.HasIndex(e => new { e.ItemCode, e.WhsCode, e.OpenQty })
                    .HasName("DLN1_ITM_WHS_OQ");

                entity.Property(e => e.AcctCode).HasMaxLength(15);

                entity.Property(e => e.ActDelDate).HasColumnType("datetime");

                entity.Property(e => e.Address).HasMaxLength(254);

                entity.Property(e => e.AllocBinC).HasMaxLength(11);

                entity.Property(e => e.AssblValue).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BackOrdr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BaseAtCard).HasMaxLength(100);

                entity.Property(e => e.BaseCard).HasMaxLength(15);

                entity.Property(e => e.BaseOpnQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BasePrice)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('E')");

                entity.Property(e => e.BaseQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseRef).HasMaxLength(16);

                entity.Property(e => e.BaseType).HasDefaultValueSql("((-1))");

                entity.Property(e => e.BlockNum).HasMaxLength(100);

                entity.Property(e => e.CEECFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('S')");

                entity.Property(e => e.CFOPCode).HasMaxLength(6);

                entity.Property(e => e.CSTCode).HasMaxLength(6);

                entity.Property(e => e.CSTfCOFINS).HasMaxLength(2);

                entity.Property(e => e.CSTfIPI).HasMaxLength(2);

                entity.Property(e => e.CSTfPIS).HasMaxLength(2);

                entity.Property(e => e.ChgAsmBoMW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CiOppLineN).HasDefaultValueSql("((-1))");

                entity.Property(e => e.CodeBars).HasMaxLength(254);

                entity.Property(e => e.CogsAcct).HasMaxLength(15);

                entity.Property(e => e.CogsOcrCo2).HasMaxLength(8);

                entity.Property(e => e.CogsOcrCo3).HasMaxLength(8);

                entity.Property(e => e.CogsOcrCo4).HasMaxLength(8);

                entity.Property(e => e.CogsOcrCo5).HasMaxLength(8);

                entity.Property(e => e.CogsOcrCod).HasMaxLength(8);

                entity.Property(e => e.Commission).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ConsumeFCT)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CountryOrg).HasMaxLength(3);

                entity.Property(e => e.CredOrigin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Currency).HasMaxLength(3);

                entity.Property(e => e.DIOTNat).HasMaxLength(3);

                entity.Property(e => e.DedVatSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DedVatSumF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DedVatSumS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DefBreak).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DeferrTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DelivrdQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DescOW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DetailsOW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DiscPrcnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DistribExp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DistribIS)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DistribSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DocDate).HasColumnType("datetime");

                entity.Property(e => e.DropShip)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Dscription).HasMaxLength(100);

                entity.Property(e => e.DstrbSumFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DstrbSumSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EnSetCost)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.EquVatPer).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EquVatSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EquVatSumF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EquVatSumS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExLineNo).HasMaxLength(10);

                entity.Property(e => e.Excisable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ExciseAmt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpOpType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ExpType).HasMaxLength(4);

                entity.Property(e => e.ExpUUID).HasMaxLength(50);

                entity.Property(e => e.Factor1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Factor2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Factor3).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Factor4).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FisrtBin).HasMaxLength(228);

                entity.Property(e => e.Flags).HasDefaultValueSql("((0))");

                entity.Property(e => e.FreeChrgBP)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FreeTxt).HasMaxLength(100);

                entity.Property(e => e.FromWhsCod).HasMaxLength(8);

                entity.Property(e => e.GPTtlBasPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GTotal).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GTotalFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GTotalSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrossBuyPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrssProfFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrssProfSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrssProfit).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Height1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Height2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.INMPrice).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ISDistrb).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ISDistrbFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ISDistrbSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ImportLog).HasMaxLength(20);

                entity.Property(e => e.Incoterms).HasDefaultValueSql("((0))");

                entity.Property(e => e.InvQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.InvQtyOnly)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.InvntSttus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('O')");

                entity.Property(e => e.IsAqcuistn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsByPrdct)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ItemType).HasDefaultValueSql("((4))");

                entity.Property(e => e.ItmTaxType).HasMaxLength(2);

                entity.Property(e => e.LegalText).HasMaxLength(254);

                entity.Property(e => e.Length1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LicTradNum).HasMaxLength(32);

                entity.Property(e => e.LinManClsd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.LinePoPrss)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.LineStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('O')");

                entity.Property(e => e.LineTotal).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LineType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('R')");

                entity.Property(e => e.LineVat).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LineVatS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LineVatlF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LineVendor).HasMaxLength(15);

                entity.Property(e => e.LnExcised)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LogInstanc).HasDefaultValueSql("((0))");

                entity.Property(e => e.LstBINMPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LstByDsFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LstByDsSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LstByDsSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.MYFtype).HasMaxLength(2);

                entity.Property(e => e.NeedQty)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.NoInvtryMv)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.NumPerMsr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NumPerMsr2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ObjType)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('15')");

                entity.Property(e => e.OcrCode).HasMaxLength(8);

                entity.Property(e => e.OcrCode2).HasMaxLength(8);

                entity.Property(e => e.OcrCode3).HasMaxLength(8);

                entity.Property(e => e.OcrCode4).HasMaxLength(8);

                entity.Property(e => e.OcrCode5).HasMaxLength(8);

                entity.Property(e => e.OpenCreQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OpenInvQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OpenQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OpenRtnQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OpenSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OpenSumFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OpenSumSys).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OrderedQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OrigItem).HasMaxLength(50);

                entity.Property(e => e.PQTReqDate).HasColumnType("datetime");

                entity.Property(e => e.PQTReqQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PackQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PartRetire)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PcDocType).HasDefaultValueSql("((-1))");

                entity.Property(e => e.PcQuantity).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PickOty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PickStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PoTrgEntry).HasMaxLength(11);

                entity.Property(e => e.PostTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.Price).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PriceAfVAT).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PriceBefDi).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PriceEdit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Project).HasMaxLength(20);

                entity.Property(e => e.QtyToShip).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Quantity).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Rate).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ReleasQtty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RetCost).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RetirAPCFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RetirAPCSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RetireAPC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RetireQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SWW).HasMaxLength(16);

                entity.Property(e => e.SerialNum).HasMaxLength(17);

                entity.Property(e => e.ShipDate).HasColumnType("datetime");

                entity.Property(e => e.ShipFromCo).HasMaxLength(50);

                entity.Property(e => e.ShipFromDe).HasMaxLength(254);

                entity.Property(e => e.ShipToCode).HasMaxLength(50);

                entity.Property(e => e.ShipToDesc).HasMaxLength(254);

                entity.Property(e => e.Shortages).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SlpCode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.SpecPrice)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.StckAppD).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckAppDFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckAppDSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckAppFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckAppSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckDstFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckDstSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckDstSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckINMPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckSumApp).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StockPrice).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StockSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StockSumFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StockSumSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StockValue).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SubCatNum).HasMaxLength(50);

                entity.Property(e => e.Surpluses).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TargetType).HasDefaultValueSql("((-1))");

                entity.Property(e => e.TaxCode).HasMaxLength(8);

                entity.Property(e => e.TaxDistSFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxDistSSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxDistSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxOnly)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TaxPerUnit).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxRelev)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.TaxStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TaxType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Text).HasColumnType("ntext");

                entity.Property(e => e.ThirdParty)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ToDiff).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ToStock).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TotInclTax).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TotalFrgn).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TotalSumSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TranType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TransMod).HasDefaultValueSql("((0))");

                entity.Property(e => e.TreeType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.TrnsCode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.UomCode).HasMaxLength(20);

                entity.Property(e => e.UomCode2).HasMaxLength(20);

                entity.Property(e => e.UomEntry).HasDefaultValueSql("((0))");

                entity.Property(e => e.UomEntry2).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdInvntry)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.UseBaseUn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.VatAppld).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatAppldFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatAppldSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatDscntPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatGroup).HasMaxLength(8);

                entity.Property(e => e.VatGrpSrc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.VatPrcnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatSumFrgn).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatSumSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatWoDpm).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatWoDpmFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatWoDpmSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VendorNum).HasMaxLength(50);

                entity.Property(e => e.Volume).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Weight1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Weight2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WhsCode).HasMaxLength(8);

                entity.Property(e => e.Width1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Width2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WtCalced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.WtLiable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.isSrvCall)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.length2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.unitMsr).HasMaxLength(100);

                entity.Property(e => e.unitMsr2).HasMaxLength(100);
            });

            modelBuilder.Entity<DPI1>(entity =>
            {
                entity.HasKey(e => new { e.DocEntry, e.LineNum })
                    .HasName("DPI1_PRIMARY");

                entity.HasIndex(e => e.AcctCode)
                    .HasName("DPI1_ACCOUNT");

                entity.HasIndex(e => e.Currency)
                    .HasName("DPI1_CURRENCY");

                entity.HasIndex(e => e.LineStatus)
                    .HasName("DPI1_STATUS");

                entity.HasIndex(e => e.OwnerCode)
                    .HasName("DPI1_OWNER_CODE");

                entity.HasIndex(e => new { e.DocEntry, e.VisOrder })
                    .HasName("DPI1_VIS_ORDER");

                entity.HasIndex(e => new { e.BaseEntry, e.BaseType, e.BaseLine })
                    .HasName("DPI1_BASE_ENTRY");

                entity.HasIndex(e => new { e.ItemCode, e.WhsCode, e.OpenQty })
                    .HasName("DPI1_ITM_WHS_OQ");

                entity.Property(e => e.AcctCode).HasMaxLength(15);

                entity.Property(e => e.ActDelDate).HasColumnType("datetime");

                entity.Property(e => e.Address).HasMaxLength(254);

                entity.Property(e => e.AllocBinC).HasMaxLength(11);

                entity.Property(e => e.AssblValue).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BackOrdr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BaseAtCard).HasMaxLength(100);

                entity.Property(e => e.BaseCard).HasMaxLength(15);

                entity.Property(e => e.BaseOpnQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BasePrice)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('E')");

                entity.Property(e => e.BaseQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseRef).HasMaxLength(16);

                entity.Property(e => e.BaseType).HasDefaultValueSql("((-1))");

                entity.Property(e => e.BlockNum).HasMaxLength(100);

                entity.Property(e => e.CEECFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('S')");

                entity.Property(e => e.CFOPCode).HasMaxLength(6);

                entity.Property(e => e.CSTCode).HasMaxLength(6);

                entity.Property(e => e.CSTfCOFINS).HasMaxLength(2);

                entity.Property(e => e.CSTfIPI).HasMaxLength(2);

                entity.Property(e => e.CSTfPIS).HasMaxLength(2);

                entity.Property(e => e.ChgAsmBoMW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CiOppLineN).HasDefaultValueSql("((-1))");

                entity.Property(e => e.CodeBars).HasMaxLength(254);

                entity.Property(e => e.CogsAcct).HasMaxLength(15);

                entity.Property(e => e.CogsOcrCo2).HasMaxLength(8);

                entity.Property(e => e.CogsOcrCo3).HasMaxLength(8);

                entity.Property(e => e.CogsOcrCo4).HasMaxLength(8);

                entity.Property(e => e.CogsOcrCo5).HasMaxLength(8);

                entity.Property(e => e.CogsOcrCod).HasMaxLength(8);

                entity.Property(e => e.Commission).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ConsumeFCT)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CountryOrg).HasMaxLength(3);

                entity.Property(e => e.CredOrigin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Currency).HasMaxLength(3);

                entity.Property(e => e.DIOTNat).HasMaxLength(3);

                entity.Property(e => e.DedVatSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DedVatSumF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DedVatSumS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DefBreak).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DeferrTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DelivrdQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DescOW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DetailsOW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DiscPrcnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DistribExp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DistribIS)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DistribSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DocDate).HasColumnType("datetime");

                entity.Property(e => e.DropShip)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Dscription).HasMaxLength(100);

                entity.Property(e => e.DstrbSumFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DstrbSumSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EnSetCost)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.EquVatPer).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EquVatSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EquVatSumF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EquVatSumS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExLineNo).HasMaxLength(10);

                entity.Property(e => e.Excisable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ExciseAmt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpOpType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ExpType).HasMaxLength(4);

                entity.Property(e => e.ExpUUID).HasMaxLength(50);

                entity.Property(e => e.Factor1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Factor2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Factor3).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Factor4).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FisrtBin).HasMaxLength(228);

                entity.Property(e => e.Flags).HasDefaultValueSql("((0))");

                entity.Property(e => e.FreeChrgBP)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FreeTxt).HasMaxLength(100);

                entity.Property(e => e.FromWhsCod).HasMaxLength(8);

                entity.Property(e => e.GPTtlBasPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GTotal).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GTotalFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GTotalSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrossBuyPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrssProfFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrssProfSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrssProfit).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Height1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Height2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.INMPrice).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ISDistrb).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ISDistrbFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ISDistrbSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ImportLog).HasMaxLength(20);

                entity.Property(e => e.Incoterms).HasDefaultValueSql("((0))");

                entity.Property(e => e.InvQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.InvQtyOnly)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.InvntSttus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('O')");

                entity.Property(e => e.IsAqcuistn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsByPrdct)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ItemType).HasDefaultValueSql("((4))");

                entity.Property(e => e.ItmTaxType).HasMaxLength(2);

                entity.Property(e => e.LegalText).HasMaxLength(254);

                entity.Property(e => e.Length1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LicTradNum).HasMaxLength(32);

                entity.Property(e => e.LinManClsd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.LinePoPrss)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.LineStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('O')");

                entity.Property(e => e.LineTotal).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LineType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('R')");

                entity.Property(e => e.LineVat).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LineVatS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LineVatlF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LineVendor).HasMaxLength(15);

                entity.Property(e => e.LnExcised)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LogInstanc).HasDefaultValueSql("((0))");

                entity.Property(e => e.LstBINMPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LstByDsFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LstByDsSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LstByDsSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.MYFtype).HasMaxLength(2);

                entity.Property(e => e.NeedQty)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.NoInvtryMv)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.NumPerMsr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NumPerMsr2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ObjType)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('203')");

                entity.Property(e => e.OcrCode).HasMaxLength(8);

                entity.Property(e => e.OcrCode2).HasMaxLength(8);

                entity.Property(e => e.OcrCode3).HasMaxLength(8);

                entity.Property(e => e.OcrCode4).HasMaxLength(8);

                entity.Property(e => e.OcrCode5).HasMaxLength(8);

                entity.Property(e => e.OpenCreQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OpenInvQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OpenQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OpenRtnQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OpenSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OpenSumFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OpenSumSys).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OrderedQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OrigItem).HasMaxLength(50);

                entity.Property(e => e.PQTReqDate).HasColumnType("datetime");

                entity.Property(e => e.PQTReqQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PackQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PartRetire)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PcDocType).HasDefaultValueSql("((-1))");

                entity.Property(e => e.PcQuantity).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PickOty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PickStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PoTrgEntry).HasMaxLength(11);

                entity.Property(e => e.PostTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.Price).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PriceAfVAT).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PriceBefDi).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PriceEdit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Project).HasMaxLength(20);

                entity.Property(e => e.QtyToShip).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Quantity).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Rate).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ReleasQtty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RetCost).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RetirAPCFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RetirAPCSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RetireAPC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RetireQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SWW).HasMaxLength(16);

                entity.Property(e => e.SerialNum).HasMaxLength(17);

                entity.Property(e => e.ShipDate).HasColumnType("datetime");

                entity.Property(e => e.ShipFromCo).HasMaxLength(50);

                entity.Property(e => e.ShipFromDe).HasMaxLength(254);

                entity.Property(e => e.ShipToCode).HasMaxLength(50);

                entity.Property(e => e.ShipToDesc).HasMaxLength(254);

                entity.Property(e => e.Shortages).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SlpCode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.SpecPrice)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.StckAppD).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckAppDFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckAppDSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckAppFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckAppSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckDstFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckDstSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckDstSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckINMPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckSumApp).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StockPrice).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StockSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StockSumFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StockSumSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StockValue).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SubCatNum).HasMaxLength(50);

                entity.Property(e => e.Surpluses).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TargetType).HasDefaultValueSql("((-1))");

                entity.Property(e => e.TaxCode).HasMaxLength(8);

                entity.Property(e => e.TaxDistSFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxDistSSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxDistSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxOnly)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TaxPerUnit).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxRelev)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.TaxStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TaxType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Text).HasColumnType("ntext");

                entity.Property(e => e.ThirdParty)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ToDiff).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ToStock).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TotInclTax).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TotalFrgn).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TotalSumSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TranType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TransMod).HasDefaultValueSql("((0))");

                entity.Property(e => e.TreeType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.TrnsCode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.UomCode).HasMaxLength(20);

                entity.Property(e => e.UomCode2).HasMaxLength(20);

                entity.Property(e => e.UomEntry).HasDefaultValueSql("((0))");

                entity.Property(e => e.UomEntry2).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdInvntry)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.UseBaseUn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.VatAppld).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatAppldFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatAppldSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatDscntPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatGroup).HasMaxLength(8);

                entity.Property(e => e.VatGrpSrc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.VatPrcnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatSumFrgn).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatSumSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatWoDpm).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatWoDpmFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatWoDpmSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VendorNum).HasMaxLength(50);

                entity.Property(e => e.Volume).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Weight1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Weight2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WhsCode).HasMaxLength(8);

                entity.Property(e => e.Width1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Width2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WtCalced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.WtLiable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.isSrvCall)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.length2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.unitMsr).HasMaxLength(100);

                entity.Property(e => e.unitMsr2).HasMaxLength(100);
            });

            modelBuilder.Entity<INV1>(entity =>
            {
                entity.HasKey(e => new { e.DocEntry, e.LineNum })
                    .HasName("INV1_PRIMARY");

                entity.HasIndex(e => e.AcctCode)
                    .HasName("INV1_ACCOUNT");

                entity.HasIndex(e => e.Currency)
                    .HasName("INV1_CURRENCY");

                entity.HasIndex(e => e.LineStatus)
                    .HasName("INV1_STATUS");

                entity.HasIndex(e => e.OwnerCode)
                    .HasName("INV1_OWNER_CODE");

                entity.HasIndex(e => new { e.DocEntry, e.VisOrder })
                    .HasName("INV1_VIS_ORDER");

                entity.HasIndex(e => new { e.BaseEntry, e.BaseType, e.BaseLine })
                    .HasName("INV1_BASE_ENTRY");

                entity.HasIndex(e => new { e.ItemCode, e.WhsCode, e.OpenQty })
                    .HasName("INV1_ITM_WHS_OQ");

                entity.Property(e => e.AcctCode).HasMaxLength(15);

                entity.Property(e => e.ActDelDate).HasColumnType("datetime");

                entity.Property(e => e.Address).HasMaxLength(254);

                entity.Property(e => e.AllocBinC).HasMaxLength(11);

                entity.Property(e => e.AssblValue).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BackOrdr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BaseAtCard).HasMaxLength(100);

                entity.Property(e => e.BaseCard).HasMaxLength(15);

                entity.Property(e => e.BaseOpnQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BasePrice)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('E')");

                entity.Property(e => e.BaseQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseRef).HasMaxLength(16);

                entity.Property(e => e.BaseType).HasDefaultValueSql("((-1))");

                entity.Property(e => e.BlockNum).HasMaxLength(100);

                entity.Property(e => e.CEECFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('S')");

                entity.Property(e => e.CFOPCode).HasMaxLength(6);

                entity.Property(e => e.CSTCode).HasMaxLength(6);

                entity.Property(e => e.CSTfCOFINS).HasMaxLength(2);

                entity.Property(e => e.CSTfIPI).HasMaxLength(2);

                entity.Property(e => e.CSTfPIS).HasMaxLength(2);

                entity.Property(e => e.ChgAsmBoMW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CiOppLineN).HasDefaultValueSql("((-1))");

                entity.Property(e => e.CodeBars).HasMaxLength(254);

                entity.Property(e => e.CogsAcct).HasMaxLength(15);

                entity.Property(e => e.CogsOcrCo2).HasMaxLength(8);

                entity.Property(e => e.CogsOcrCo3).HasMaxLength(8);

                entity.Property(e => e.CogsOcrCo4).HasMaxLength(8);

                entity.Property(e => e.CogsOcrCo5).HasMaxLength(8);

                entity.Property(e => e.CogsOcrCod).HasMaxLength(8);

                entity.Property(e => e.Commission).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ConsumeFCT)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CountryOrg).HasMaxLength(3);

                entity.Property(e => e.CredOrigin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Currency).HasMaxLength(3);

                entity.Property(e => e.DIOTNat).HasMaxLength(3);

                entity.Property(e => e.DedVatSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DedVatSumF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DedVatSumS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DefBreak).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DeferrTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DelivrdQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DescOW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DetailsOW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DiscPrcnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DistribExp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DistribIS)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DistribSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DocDate).HasColumnType("datetime");

                entity.Property(e => e.DropShip)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Dscription).HasMaxLength(100);

                entity.Property(e => e.DstrbSumFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DstrbSumSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EnSetCost)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.EquVatPer).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EquVatSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EquVatSumF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EquVatSumS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExLineNo).HasMaxLength(10);

                entity.Property(e => e.Excisable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ExciseAmt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpOpType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ExpType).HasMaxLength(4);

                entity.Property(e => e.ExpUUID).HasMaxLength(50);

                entity.Property(e => e.Factor1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Factor2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Factor3).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Factor4).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FisrtBin).HasMaxLength(228);

                entity.Property(e => e.Flags).HasDefaultValueSql("((0))");

                entity.Property(e => e.FreeChrgBP)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FreeTxt).HasMaxLength(100);

                entity.Property(e => e.FromWhsCod).HasMaxLength(8);

                entity.Property(e => e.GPTtlBasPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GTotal).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GTotalFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GTotalSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrossBuyPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrssProfFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrssProfSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrssProfit).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Height1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Height2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.INMPrice).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ISDistrb).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ISDistrbFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ISDistrbSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ImportLog).HasMaxLength(20);

                entity.Property(e => e.Incoterms).HasDefaultValueSql("((0))");

                entity.Property(e => e.InvQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.InvQtyOnly)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.InvntSttus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('O')");

                entity.Property(e => e.IsAqcuistn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsByPrdct)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ItemType).HasDefaultValueSql("((4))");

                entity.Property(e => e.ItmTaxType).HasMaxLength(2);

                entity.Property(e => e.LegalText).HasMaxLength(254);

                entity.Property(e => e.Length1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LicTradNum).HasMaxLength(32);

                entity.Property(e => e.LinManClsd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.LinePoPrss)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.LineStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('O')");

                entity.Property(e => e.LineTotal).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LineType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('R')");

                entity.Property(e => e.LineVat).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LineVatS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LineVatlF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LineVendor).HasMaxLength(15);

                entity.Property(e => e.LnExcised)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LogInstanc).HasDefaultValueSql("((0))");

                entity.Property(e => e.LstBINMPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LstByDsFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LstByDsSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LstByDsSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.MYFtype).HasMaxLength(2);

                entity.Property(e => e.NeedQty)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.NoInvtryMv)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.NumPerMsr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NumPerMsr2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ObjType)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('13')");

                entity.Property(e => e.OcrCode).HasMaxLength(8);

                entity.Property(e => e.OcrCode2).HasMaxLength(8);

                entity.Property(e => e.OcrCode3).HasMaxLength(8);

                entity.Property(e => e.OcrCode4).HasMaxLength(8);

                entity.Property(e => e.OcrCode5).HasMaxLength(8);

                entity.Property(e => e.OpenCreQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OpenInvQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OpenQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OpenRtnQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OpenSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OpenSumFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OpenSumSys).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OrderedQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OrigItem).HasMaxLength(50);

                entity.Property(e => e.PQTReqDate).HasColumnType("datetime");

                entity.Property(e => e.PQTReqQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PackQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PartRetire)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PcDocType).HasDefaultValueSql("((-1))");

                entity.Property(e => e.PcQuantity).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PickOty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PickStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PoTrgEntry).HasMaxLength(11);

                entity.Property(e => e.PostTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.Price).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PriceAfVAT).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PriceBefDi).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PriceEdit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Project).HasMaxLength(20);

                entity.Property(e => e.QtyToShip).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Quantity).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Rate).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ReleasQtty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RetCost).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RetirAPCFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RetirAPCSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RetireAPC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RetireQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SWW).HasMaxLength(16);

                entity.Property(e => e.SerialNum).HasMaxLength(17);

                entity.Property(e => e.ShipDate).HasColumnType("datetime");

                entity.Property(e => e.ShipFromCo).HasMaxLength(50);

                entity.Property(e => e.ShipFromDe).HasMaxLength(254);

                entity.Property(e => e.ShipToCode).HasMaxLength(50);

                entity.Property(e => e.ShipToDesc).HasMaxLength(254);

                entity.Property(e => e.Shortages).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SlpCode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.SpecPrice)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.StckAppD).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckAppDFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckAppDSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckAppFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckAppSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckDstFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckDstSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckDstSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckINMPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckSumApp).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StockPrice).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StockSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StockSumFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StockSumSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StockValue).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SubCatNum).HasMaxLength(50);

                entity.Property(e => e.Surpluses).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TargetType).HasDefaultValueSql("((-1))");

                entity.Property(e => e.TaxCode).HasMaxLength(8);

                entity.Property(e => e.TaxDistSFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxDistSSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxDistSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxOnly)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TaxPerUnit).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxRelev)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.TaxStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TaxType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Text).HasColumnType("ntext");

                entity.Property(e => e.ThirdParty)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ToDiff).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ToStock).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TotInclTax).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TotalFrgn).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TotalSumSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TranType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TransMod).HasDefaultValueSql("((0))");

                entity.Property(e => e.TreeType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.TrnsCode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.UomCode).HasMaxLength(20);

                entity.Property(e => e.UomCode2).HasMaxLength(20);

                entity.Property(e => e.UomEntry).HasDefaultValueSql("((0))");

                entity.Property(e => e.UomEntry2).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdInvntry)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.UseBaseUn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.VatAppld).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatAppldFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatAppldSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatDscntPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatGroup).HasMaxLength(8);

                entity.Property(e => e.VatGrpSrc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.VatPrcnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatSumFrgn).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatSumSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatWoDpm).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatWoDpmFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatWoDpmSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VendorNum).HasMaxLength(50);

                entity.Property(e => e.Volume).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Weight1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Weight2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WhsCode).HasMaxLength(8);

                entity.Property(e => e.Width1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Width2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WtCalced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.WtLiable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.isSrvCall)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.length2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.unitMsr).HasMaxLength(100);

                entity.Property(e => e.unitMsr2).HasMaxLength(100);
            });

            modelBuilder.Entity<ITM1>(entity =>
            {
                entity.HasKey(e => new { e.ItemCode, e.PriceList })
                    .HasName("ITM1_PRIMARY");

                entity.HasIndex(e => e.Currency)
                    .HasName("ITM1_CURRENCY");

                entity.HasIndex(e => e.Ovrwritten)
                    .HasName("ITM1_MANUAL");

                entity.HasIndex(e => e.PriceList)
                    .HasName("ITM1_PRICE_LIST");

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.AddPrice1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.AddPrice2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Currency).HasMaxLength(3);

                entity.Property(e => e.Currency1).HasMaxLength(3);

                entity.Property(e => e.Currency2).HasMaxLength(3);

                entity.Property(e => e.Factor).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LogInstanc).HasDefaultValueSql("((0))");

                entity.Property(e => e.ObjType)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('4')");

                entity.Property(e => e.Ovrwrite1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Ovrwrite2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Ovrwritten)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Price).HasColumnType("numeric(19, 6)");
            });

            modelBuilder.Entity<JDT1>(entity =>
            {
                entity.HasKey(e => new { e.TransId, e.Line_ID })
                    .HasName("JDT1_PRIMARY");

                entity.HasIndex(e => e.DueDate)
                    .HasName("JDT1_DUEDATE");

                entity.HasIndex(e => e.FCCurrency)
                    .HasName("JDT1_CURRENCY");

                entity.HasIndex(e => e.ProfitCode)
                    .HasName("JDT1_PROFIT_ID");

                entity.HasIndex(e => e.RefDate)
                    .HasName("JDT1_REFDATE");

                entity.HasIndex(e => e.TransType)
                    .HasName("JDT1_TRANS_TYPE");

                entity.HasIndex(e => new { e.Account, e.IntrnMatch })
                    .HasName("JDT1_ACCOUNT");

                entity.HasIndex(e => new { e.CheckAbs, e.TransType })
                    .HasName("JDT1_JDT1CHECKA");

                entity.HasIndex(e => new { e.ShortName, e.Account })
                    .HasName("JDT1_INTRNMATCH");

                entity.HasIndex(e => new { e.ShortName, e.IntrnMatch })
                    .HasName("JDT1_SHORT_NAME");

                entity.HasIndex(e => new { e.TransType, e.CreatedBy, e.SourceLine })
                    .HasName("JDT1_JDT1BASEL");

                entity.Property(e => e.Account).HasMaxLength(15);

                entity.Property(e => e.AdjTran)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BPLName).HasMaxLength(100);

                entity.Property(e => e.BalDueCred).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BalDueDeb).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BalFcCred).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BalFcDeb).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BalScCred).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BalScDeb).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseRef).HasMaxLength(11);

                entity.Property(e => e.BaseSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.CenVatCom).HasDefaultValueSql("((-1))");

                entity.Property(e => e.Closed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ClsInTP).HasDefaultValueSql("((0))");

                entity.Property(e => e.ContraAct).HasMaxLength(15);

                entity.Property(e => e.Credit).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DebCred)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Debit).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.DunDate).HasColumnType("datetime");

                entity.Property(e => e.DunWizBlck)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DunnLevel).HasDefaultValueSql("((0))");

                entity.Property(e => e.EquVatRate).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EquVatSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpOPType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ExpUUID).HasMaxLength(50);

                entity.Property(e => e.ExtrMatch).HasDefaultValueSql("((0))");

                entity.Property(e => e.FCCredit).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FCCurrency).HasMaxLength(3);

                entity.Property(e => e.FCDebit).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrossValFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrossValue).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Indicator).HasMaxLength(2);

                entity.Property(e => e.InitRef2).HasMaxLength(100);

                entity.Property(e => e.InitRef3Ln).HasMaxLength(27);

                entity.Property(e => e.InterimTyp).HasDefaultValueSql("((0))");

                entity.Property(e => e.IntrnMatch).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsNet)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.LicTradNum).HasMaxLength(32);

                entity.Property(e => e.LineMemo).HasMaxLength(50);

                entity.Property(e => e.LineType).HasDefaultValueSql("((0))");

                entity.Property(e => e.LogInstanc).HasDefaultValueSql("((0))");

                entity.Property(e => e.LvlUpdDate).HasColumnType("datetime");

                entity.Property(e => e.MIEntry).HasDefaultValueSql("((0))");

                entity.Property(e => e.MIVEntry).HasDefaultValueSql("((0))");

                entity.Property(e => e.MYFtype).HasMaxLength(2);

                entity.Property(e => e.MatType).HasDefaultValueSql("((-1))");

                entity.Property(e => e.MatchRef).HasMaxLength(20);

                entity.Property(e => e.MthDate).HasColumnType("datetime");

                entity.Property(e => e.MultMatch).HasDefaultValueSql("((0))");

                entity.Property(e => e.ObjType)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('30')");

                entity.Property(e => e.OcrCode2).HasMaxLength(8);

                entity.Property(e => e.OcrCode3).HasMaxLength(8);

                entity.Property(e => e.OcrCode4).HasMaxLength(8);

                entity.Property(e => e.OcrCode5).HasMaxLength(8);

                entity.Property(e => e.Ordered)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PayBlock)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PaymentRef).HasMaxLength(27);

                entity.Property(e => e.ProfitCode).HasMaxLength(8);

                entity.Property(e => e.Project).HasMaxLength(20);

                entity.Property(e => e.PstngType).HasDefaultValueSql("((0))");

                entity.Property(e => e.Ref1).HasMaxLength(100);

                entity.Property(e => e.Ref2).HasMaxLength(100);

                entity.Property(e => e.Ref2Date).HasColumnType("datetime");

                entity.Property(e => e.Ref3Line).HasMaxLength(27);

                entity.Property(e => e.RefDate).HasColumnType("datetime");

                entity.Property(e => e.RelLineID).HasDefaultValueSql("((-1))");

                entity.Property(e => e.RelTransId).HasDefaultValueSql("((-1))");

                entity.Property(e => e.RelType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RevSource)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SLEDGERF)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SYSBaseSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SYSCred).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SYSDeb).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SYSEquSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SYSTVat).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SYSVatSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SequenceNr).HasDefaultValueSql("((0))");

                entity.Property(e => e.ShortName).HasMaxLength(15);

                entity.Property(e => e.StaCode).HasMaxLength(8);

                entity.Property(e => e.StornoAcc).HasMaxLength(15);

                entity.Property(e => e.SystemRate).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxCode).HasMaxLength(8);

                entity.Property(e => e.TaxDate).HasColumnType("datetime");

                entity.Property(e => e.TaxPostAcc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.TaxType).HasDefaultValueSql("((0))");

                entity.Property(e => e.ToMthSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TotalVat).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TransCode).HasMaxLength(4);

                entity.Property(e => e.TransType)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('-1')");

                entity.Property(e => e.U_B1SYS_WHT)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('E')");

                entity.Property(e => e.ValidFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('19000101')");

                entity.Property(e => e.ValidFrom2)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('19000101')");

                entity.Property(e => e.ValidFrom3)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('19000101')");

                entity.Property(e => e.ValidFrom4)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('19000101')");

                entity.Property(e => e.ValidFrom5)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('19000101')");

                entity.Property(e => e.VatAmount).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatDate).HasColumnType("datetime");

                entity.Property(e => e.VatGroup).HasMaxLength(8);

                entity.Property(e => e.VatLine)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.VatRate).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatRegNum).HasMaxLength(32);

                entity.Property(e => e.WTApplied).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTAppliedF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTAppliedS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTLiable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.WTLine)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.WTSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTSumFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTSumSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTaxCode).HasMaxLength(4);
            });

            modelBuilder.Entity<OADM>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("OADM_PRIMARY");

                entity.Property(e => e.Code).HasDefaultValueSql("((1))");

                entity.Property(e => e.According).HasDefaultValueSql("((1))");

                entity.Property(e => e.AcctMethod)
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('2')");

                entity.Property(e => e.ActSep)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('-')");

                entity.Property(e => e.ActSoftNam).HasMaxLength(100);

                entity.Property(e => e.AddDlnBlnc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.AddVat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.AdrsFromWH)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.AliasName).HasColumnType("ntext");

                entity.Property(e => e.AllowFuPos)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.AllowPostZ)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.AlphaDoc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.AltBOEPost)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.AlwBPNOwn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ApplicIFRS)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ApyBsActPL)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ApyBsActPV)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ApyBsActSP)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ApyDRinPEC)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ApyIBtoACT)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ApyPRinPEC)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ApyToNewBP)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.AttachPath).HasColumnType("ntext");

                entity.Property(e => e.AutoAddPkg)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.AutoAddUoM)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.AutoITW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.AutoResWhs)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.AutoVat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BSInstled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BTWCity).HasMaxLength(100);

                entity.Property(e => e.BTWDcPrvID).HasMaxLength(100);

                entity.Property(e => e.BTWDecProv)
                    .HasMaxLength(3)
                    .HasDefaultValueSql("('BPL')");

                entity.Property(e => e.BTWICP).HasDefaultValueSql("((1))");

                entity.Property(e => e.BTWName).HasMaxLength(100);

                entity.Property(e => e.BTWOB).HasDefaultValueSql("((1))");

                entity.Property(e => e.BTWPhone).HasMaxLength(100);

                entity.Property(e => e.BTWStreet).HasMaxLength(100);

                entity.Property(e => e.BTWZip).HasMaxLength(30);

                entity.Property(e => e.BackOrder)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BankCountr).HasMaxLength(3);

                entity.Property(e => e.BaseFld)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.BdgtAcctng)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BdgtDflt).HasDefaultValueSql("((1))");

                entity.Property(e => e.BdgtPDNDoc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.BdgtPORDoc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.BdgtPRQDOC)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BgtBlock)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BgtWarning)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.BinActivat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BoletoPath).HasColumnType("ntext");

                entity.Property(e => e.Bookpitype)
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('2')");

                entity.Property(e => e.BoxRptSeq).HasDefaultValueSql("((0))");

                entity.Property(e => e.BrachNum).HasMaxLength(4);

                entity.Property(e => e.BtchStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BuisnesDsc).HasMaxLength(50);

                entity.Property(e => e.CCMask)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.CaredType).HasMaxLength(2);

                entity.Property(e => e.CentPmtInc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CentPmtOut)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CfwAsnMust)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.ChBPSerie)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ChCtrAPAct)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ChCtrARAct)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ChItmSerie)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ChangeRdr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.ChkQtyINV)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CigCup)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ClnZeroPln)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CloseWipV)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ClosedQuot)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ClsNoConfi)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ClsZoDiffR)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.CmdDisBoth)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.CmpnyAddrF).HasMaxLength(254);

                entity.Property(e => e.Code1).HasMaxLength(8);

                entity.Property(e => e.Code2).HasMaxLength(8);

                entity.Property(e => e.Code3).HasMaxLength(8);

                entity.Property(e => e.Code4).HasMaxLength(8);

                entity.Property(e => e.Color).HasDefaultValueSql("((1))");

                entity.Property(e => e.CompType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('U')");

                entity.Property(e => e.CompnyAddr).HasMaxLength(254);

                entity.Property(e => e.CompnyName).HasMaxLength(100);

                entity.Property(e => e.ConfigPath).HasColumnType("ntext");

                entity.Property(e => e.ConsumeFCT)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.ConsumeMtd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('B')");

                entity.Property(e => e.ContInvnt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CostPrcLst).HasDefaultValueSql("((-1))");

                entity.Property(e => e.Country).HasMaxLength(3);

                entity.Property(e => e.CpyExhRate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CrdCommUse)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CreditDpst)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CreditLimt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CrtLineRFQ)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CrtfcateNO).HasMaxLength(20);

                entity.Property(e => e.CshDctFA)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CurOnRight)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CurrPeriod).HasMaxLength(10);

                entity.Property(e => e.CustIdNum)
                    .HasMaxLength(6)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CustmrDdct)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DRBlock1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DRBlock2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DRBlock3)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DRBlock4)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DRBlock5)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DTWPath).HasColumnType("ntext");

                entity.Property(e => e.DateFormat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DateSep)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('/')");

                entity.Property(e => e.Days).HasDefaultValueSql("((0))");

                entity.Property(e => e.DaysBack).HasDefaultValueSql("((7))");

                entity.Property(e => e.DaysFwrd).HasDefaultValueSql("((7))");

                entity.Property(e => e.DdAutoRun)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DdNextDue).HasColumnType("datetime");

                entity.Property(e => e.DdctExpire).HasColumnType("datetime");

                entity.Property(e => e.DdctFileNo).HasMaxLength(50);

                entity.Property(e => e.DdctOffice).HasMaxLength(100);

                entity.Property(e => e.DdctPercnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DeactivFA)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DecSep)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('.')");

                entity.Property(e => e.DefLengthU).HasDefaultValueSql("((2))");

                entity.Property(e => e.DefWeightU).HasDefaultValueSql("((2))");

                entity.Property(e => e.DeferrTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DeprecCalc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('M')");

                entity.Property(e => e.DfActCurr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.DfCustTerm).HasDefaultValueSql("((-1))");

                entity.Property(e => e.DfPVatExmp).HasMaxLength(8);

                entity.Property(e => e.DfPVatItem).HasMaxLength(8);

                entity.Property(e => e.DfPVatServ).HasMaxLength(8);

                entity.Property(e => e.DfSVatExmp).HasMaxLength(8);

                entity.Property(e => e.DfSVatItem).HasMaxLength(8);

                entity.Property(e => e.DfSVatServ).HasMaxLength(8);

                entity.Property(e => e.DfVendTerm).HasDefaultValueSql("((-1))");

                entity.Property(e => e.DflBCACode).HasMaxLength(3);

                entity.Property(e => e.DflBnkAcct).HasMaxLength(50);

                entity.Property(e => e.DflBnkCode).HasMaxLength(30);

                entity.Property(e => e.DflBranch).HasMaxLength(50);

                entity.Property(e => e.DflFTPSite).HasColumnType("ntext");

                entity.Property(e => e.DflIntrst).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DflJET).HasMaxLength(60);

                entity.Property(e => e.DflTaxCode).HasMaxLength(8);

                entity.Property(e => e.DflWTS).HasDefaultValueSql("((-1))");

                entity.Property(e => e.DflWebSite).HasColumnType("ntext");

                entity.Property(e => e.DfltByEml)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('E')");

                entity.Property(e => e.DfltCDP).HasDefaultValueSql("((-1))");

                entity.Property(e => e.DfltCDPV).HasDefaultValueSql("((-1))");

                entity.Property(e => e.DfltCustPM).HasMaxLength(15);

                entity.Property(e => e.DfltDunTrm).HasMaxLength(25);

                entity.Property(e => e.DfltSlp).HasDefaultValueSql("((-1))");

                entity.Property(e => e.DfltVendPM).HasMaxLength(15);

                entity.Property(e => e.DfltWhs).HasMaxLength(8);

                entity.Property(e => e.DftJPELine)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DftPVL).HasDefaultValueSql("((-1))");

                entity.Property(e => e.DftRCN).HasDefaultValueSql("((-6))");

                entity.Property(e => e.DftResWhs).HasMaxLength(8);

                entity.Property(e => e.DigCrtPath).HasColumnType("ntext");

                entity.Property(e => e.DirectRate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.DispPosDeb)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DllPath).HasColumnType("ntext");

                entity.Property(e => e.DlnLimit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DoBudget)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DoMngMth)
                    .HasMaxLength(11)
                    .HasDefaultValueSql("('D')");

                entity.Property(e => e.DotAsSep)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DpsitPrcnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DspBokpWin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DspFrznBP)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.DspFrznITM)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.EDProcess)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('I')");

                entity.Property(e => e.EDTestMode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.EDocGenTyp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.EDocSeqNum).HasDefaultValueSql("((1))");

                entity.Property(e => e.EOutputPth).HasColumnType("ntext");

                entity.Property(e => e.ERpPerType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('M')");

                entity.Property(e => e.ETRFaxNo).HasMaxLength(20);

                entity.Property(e => e.ETRMgrPhn).HasMaxLength(20);

                entity.Property(e => e.ETRPhoneNo).HasMaxLength(20);

                entity.Property(e => e.ETRTaxOffi).HasDefaultValueSql("((0))");

                entity.Property(e => e.ETRTaxPers)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EURepSqntl).HasDefaultValueSql("((0))");

                entity.Property(e => e.E_Mail).HasMaxLength(100);

                entity.Property(e => e.ElectrDocs)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.EmployerRf).HasMaxLength(32);

                entity.Property(e => e.EmptyPKL)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.EnableRO)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.EnbAdvATP)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.EnbApprDI)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.EnbDocOpt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.EnbNegPym)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.EnbSupplC)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.EnblCase)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.EnblLC)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.EnblSrvTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.EnterAsTab)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ExRtDefTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ExWTLiabl)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ExcNInvItm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ExcelPath).HasColumnType("ntext");

                entity.Property(e => e.ExpireDate).HasColumnType("datetime");

                entity.Property(e => e.Fax).HasMaxLength(20);

                entity.Property(e => e.FaxF).HasMaxLength(20);

                entity.Property(e => e.FcNoBlnc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('B')");

                entity.Property(e => e.FixAstMod)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('P')");

                entity.Property(e => e.FreeZoneNo).HasMaxLength(32);

                entity.Property(e => e.GBIntface)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.GBOpenFile)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.GLMethod)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('W')");

                entity.Property(e => e.GPPrcntSrv).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GTSInPath).HasColumnType("ntext");

                entity.Property(e => e.GTSMaxAmt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GTSOutPath).HasColumnType("ntext");

                entity.Property(e => e.GTSSep).HasMaxLength(10);

                entity.Property(e => e.GrossBySal)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.HQLocation)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('B')");

                entity.Property(e => e.HldCode).HasMaxLength(20);

                entity.Property(e => e.ICDifExPe1)
                    .HasColumnType("numeric(19, 6)")
                    .HasDefaultValueSql("((5))");

                entity.Property(e => e.ICDifExPe2)
                    .HasColumnType("numeric(19, 6)")
                    .HasDefaultValueSql("((5))");

                entity.Property(e => e.ICDifExPe3)
                    .HasColumnType("numeric(19, 6)")
                    .HasDefaultValueSql("((5))");

                entity.Property(e => e.INCSingToV)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.INVOBPrice)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IRSFileNo).HasMaxLength(9);

                entity.Property(e => e.ISRBillerI).HasMaxLength(9);

                entity.Property(e => e.ISRType).HasDefaultValueSql("((2))");

                entity.Property(e => e.IgnoreAdde)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IgrAllCash)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.InActMkt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.InActPln)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.InActRpt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.IncomeTax).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.IncresGlAc).HasMaxLength(15);

                entity.Property(e => e.InstFixAst)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.InstitCode).HasMaxLength(2);

                entity.Property(e => e.InvntSystm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.IsPAPrn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsReuseNFN)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsReuseNum)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsUpdNstdB)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IssuePriBy).HasDefaultValueSql("((0))");

                entity.Property(e => e.ItmCommUse)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.JEInFATran)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.JeUnGroup)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.LDiscTotal)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.LevelWarn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('W')");

                entity.Property(e => e.LogInstanc).HasDefaultValueSql("((0))");

                entity.Property(e => e.MBAOnAP)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.MBAOnAR)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.MBAOnPer)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.MDStyle)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('U')");

                entity.Property(e => e.MMLastImpD).HasColumnType("datetime");

                entity.Property(e => e.MainCurncy).HasMaxLength(3);

                entity.Property(e => e.Manager).HasMaxLength(100);

                entity.Property(e => e.Manager1).HasMaxLength(100);

                entity.Property(e => e.Manager1F).HasMaxLength(100);

                entity.Property(e => e.ManagerF).HasMaxLength(100);

                entity.Property(e => e.MapService).HasDefaultValueSql("((-1))");

                entity.Property(e => e.MaxCntRows).HasDefaultValueSql("((10000))");

                entity.Property(e => e.MaxDays4DD).HasDefaultValueSql("((0))");

                entity.Property(e => e.MaxHistory).HasDefaultValueSql("((99))");

                entity.Property(e => e.MaxINVRptR).HasDefaultValueSql("((85000))");

                entity.Property(e => e.MaxTaxDecr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.MaxTaxIncr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.MeasureDec).HasDefaultValueSql("((3))");

                entity.Property(e => e.MinAmnt347).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.MltpBrnchs)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Months).HasDefaultValueSql("((1))");

                entity.Property(e => e.MouseOnly)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.MultiCurr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('B')");

                entity.Property(e => e.MultiLang)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.MultiSched)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.NINum).HasMaxLength(20);

                entity.Property(e => e.NegAmount)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.NegTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.NewAcctDe)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.NewDPRCus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.NotifAlert)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.NotifEmail)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.NotifyRqr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ODWFreq).HasDefaultValueSql("((30))");

                entity.Property(e => e.ObligLimit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.OnHldPert).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OneBOneRec)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.OnlyPaidIn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.OpnClsRmrk)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.OrderBatch)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.OrderBlock)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OrderLimit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.OrderParty).HasMaxLength(30);

                entity.Property(e => e.OrgNumber).HasMaxLength(100);

                entity.Property(e => e.PAC)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('XML')");

                entity.Property(e => e.PACPasswrd).HasMaxLength(100);

                entity.Property(e => e.PACUsrName).HasMaxLength(100);

                entity.Property(e => e.PBSGroupNo).HasMaxLength(5);

                entity.Property(e => e.PBSNumber).HasMaxLength(8);

                entity.Property(e => e.PCN874RTyp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.PDDEnabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PDfltITWT).HasMaxLength(4);

                entity.Property(e => e.PDfltWT).HasMaxLength(4);

                entity.Property(e => e.PHandleWT)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.POrCByINC)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PStatAutCh)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.PStatDelay).HasDefaultValueSql("((1))");

                entity.Property(e => e.ParamPath).HasColumnType("ntext");

                entity.Property(e => e.PayOutVat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PayRefCalc).HasDefaultValueSql("((1))");

                entity.Property(e => e.PchName).HasMaxLength(20);

                entity.Property(e => e.PdnName).HasMaxLength(20);

                entity.Property(e => e.PercentDec).HasDefaultValueSql("((4))");

                entity.Property(e => e.Phone1).HasMaxLength(20);

                entity.Property(e => e.Phone1F).HasMaxLength(20);

                entity.Property(e => e.Phone2).HasMaxLength(20);

                entity.Property(e => e.Phone2F).HasMaxLength(20);

                entity.Property(e => e.PickLimit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PickParDlv)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PorConfrmd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.PorName).HasMaxLength(20);

                entity.Property(e => e.PostDiffR)
                    .HasColumnType("numeric(19, 6)")
                    .HasDefaultValueSql("((5))");

                entity.Property(e => e.PriceDec).HasDefaultValueSql("((2))");

                entity.Property(e => e.PriceProcM)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('U')");

                entity.Property(e => e.PriceSys)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.PrintHdrF).HasMaxLength(100);

                entity.Property(e => e.PrintHeadr).HasMaxLength(100);

                entity.Property(e => e.PrjBlock)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PrjMngmnt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Profession).HasMaxLength(50);

                entity.Property(e => e.QtyDec).HasDefaultValueSql("((3))");

                entity.Property(e => e.RateDec).HasDefaultValueSql("((4))");

                entity.Property(e => e.RdrConfrmd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.RefDNoEdit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.RefreshQty)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Reindex)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RepBusOthr).HasMaxLength(32);

                entity.Property(e => e.RepBusType)
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('2')");

                entity.Property(e => e.ReptCurrcy)
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.ReptMethod)
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('2')");

                entity.Property(e => e.RevOffice).HasMaxLength(100);

                entity.Property(e => e.RevisionPo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RndToTDec)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RoundMthd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RoundRmrk)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.RoundVat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RpcName).HasMaxLength(20);

                entity.Property(e => e.RpdName).HasMaxLength(20);

                entity.Property(e => e.RspOverAmt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('B')");

                entity.Property(e => e.SDfltITWT).HasMaxLength(4);

                entity.Property(e => e.SDfltWT).HasMaxLength(4);

                entity.Property(e => e.SEPACredID).HasMaxLength(35);

                entity.Property(e => e.SHandleWT)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SIPLDoc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SIPLReport)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SIPLSeting)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SaleProfit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.SalesLimit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SendAlert)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ServNature)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Serv_Pass).HasMaxLength(20);

                entity.Property(e => e.Serv_Usr).HasMaxLength(20);

                entity.Property(e => e.SetSriUniq)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SimReport)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SirenNo).HasMaxLength(9);

                entity.Property(e => e.SlpCommUse)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SnBDfltSB)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SnapShotId).HasDefaultValueSql("((0))");

                entity.Property(e => e.SopPath).HasColumnType("ntext");

                entity.Property(e => e.SplitFBSh)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SriUniqFld)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('3')");

                entity.Property(e => e.StartFrom)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.State).HasMaxLength(3);

                entity.Property(e => e.StockNoBas)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SumDec).HasDefaultValueSql("((2))");

                entity.Property(e => e.SysCNoEdit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.SysCurrncy).HasMaxLength(3);

                entity.Property(e => e.TaaSAutURL).HasMaxLength(250);

                entity.Property(e => e.TaaSEnable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.TaaSPass).HasMaxLength(20);

                entity.Property(e => e.TaaSPurcAc).HasMaxLength(15);

                entity.Property(e => e.TaaSSaleAc).HasMaxLength(15);

                entity.Property(e => e.TaaSURL).HasMaxLength(250);

                entity.Property(e => e.TaaSUser).HasMaxLength(50);

                entity.Property(e => e.TaxCodeCst).HasMaxLength(8);

                entity.Property(e => e.TaxCodeVnd).HasMaxLength(8);

                entity.Property(e => e.TaxDNoEdit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.TaxIdNum).HasMaxLength(32);

                entity.Property(e => e.TaxIdNum2).HasMaxLength(32);

                entity.Property(e => e.TaxIdNum3).HasMaxLength(32);

                entity.Property(e => e.TaxIdValid)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.TaxMethod)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TaxPayerRf).HasMaxLength(32);

                entity.Property(e => e.TaxPyerSta).HasMaxLength(2);

                entity.Property(e => e.TaxRateDet)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('P')");

                entity.Property(e => e.TaxRegime).HasMaxLength(100);

                entity.Property(e => e.TaxRndRule)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ThousSep)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("(',')");

                entity.Property(e => e.TimeFormat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.TreePricOn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.TxtSrch)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.UalKeepDay).HasDefaultValueSql("((30))");

                entity.Property(e => e.UalLastDel).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UseCode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.UseExtRpt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.UseMltDims)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.UsePaSys)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.UseProdPL)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.UseProdWip)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.UseShpdGd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.UseTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.VatCharge)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.VatPrcnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VendorDdct)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.WTAccAmtAR).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTAccumAmt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTLiable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.WTRndRule)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.WarnByWhs)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.WrkshtPath).HasColumnType("ntext");

                entity.Property(e => e.XmlPath).HasColumnType("ntext");

                entity.Property(e => e.ZeroLine)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.defTaxVend)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.free21)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.free22)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.free46)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.free69)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.free71)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.free72)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.free73)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.free74)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.free75)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.free76)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.free77)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.free78)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.free79)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.free80)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.free82)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.free83)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.free84)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.free85)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.free86)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.free88)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.free89)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.onHldLimt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.useDdctTrc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.useDocWrf)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");
            });

            modelBuilder.Entity<OADP>(entity =>
            {
                entity.HasKey(e => e.PrintId)
                    .HasName("OADP_PRIMARY");

                entity.Property(e => e.PrintId).HasMaxLength(4);

                entity.Property(e => e.AttachPDF)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.AttachPath).HasColumnType("ntext");

                entity.Property(e => e.B1Server).HasColumnType("ntext");

                entity.Property(e => e.BitmapPath).HasColumnType("ntext");

                entity.Property(e => e.DefirDemop).HasColumnType("ntext");

                entity.Property(e => e.DefirExpP).HasColumnType("ntext");

                entity.Property(e => e.DmePath).HasColumnType("ntext");

                entity.Property(e => e.DraftNote)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.ExportCode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ExportPDF)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ExtPath).HasColumnType("ntext");

                entity.Property(e => e.GBIPath).HasColumnType("ntext");

                entity.Property(e => e.IsTrustSrv)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.LogInstanc).HasDefaultValueSql("((0))");

                entity.Property(e => e.LogoFile).HasMaxLength(200);

                entity.Property(e => e.LogoImage).HasColumnType("image");

                entity.Property(e => e.MaxLineNum).HasDefaultValueSql("((99))");

                entity.Property(e => e.MaxWordLin).HasDefaultValueSql("((10))");

                entity.Property(e => e.MnhlNote)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.ObjList).HasDefaultValueSql("((13))");

                entity.Property(e => e.PreAttach).HasColumnType("ntext");

                entity.Property(e => e.PrintMeta)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PrintPDF)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PrintRcpt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PrnCompany)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PrtCancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.PrtUseSys)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RptList)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.SNType).HasDefaultValueSql("((2))");

                entity.Property(e => e.ShortRcpt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SnapShotId).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.V_Compress).HasDefaultValueSql("((100))");

                entity.Property(e => e.WordPath).HasColumnType("ntext");
            });

            modelBuilder.Entity<OCLG>(entity =>
            {
                entity.HasKey(e => e.ClgCode)
                    .HasName("OCLG_PRIMARY");

                entity.HasIndex(e => e.CardCode)
                    .HasName("OCLG_CRD_CODE");

                entity.HasIndex(e => new { e.OprId, e.OprLine })
                    .HasName("OCLG_OPPORT");

                entity.Property(e => e.ClgCode).ValueGeneratedNever();

                entity.Property(e => e.Action)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('C')");

                entity.Property(e => e.AddrName).HasMaxLength(50);

                entity.Property(e => e.AddrType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('S')");

                entity.Property(e => e.Attachment).HasColumnType("ntext");

                entity.Property(e => e.CardCode).HasMaxLength(15);

                entity.Property(e => e.CloseDate).HasColumnType("datetime");

                entity.Property(e => e.Closed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CntctDate).HasColumnType("datetime");

                entity.Property(e => e.CntctSbjct).HasDefaultValueSql("((-1))");

                entity.Property(e => e.CntctType).HasDefaultValueSql("((-1))");

                entity.Property(e => e.ContactPer).HasMaxLength(90);

                entity.Property(e => e.DataSource)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Details).HasMaxLength(100);

                entity.Property(e => e.DocEntry).HasMaxLength(50);

                entity.Property(e => e.DocNum).HasMaxLength(50);

                entity.Property(e => e.DocType)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('-1')");

                entity.Property(e => e.DurType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('M')");

                entity.Property(e => e.Duration).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EndType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Fax).HasMaxLength(20);

                entity.Property(e => e.Friday)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Instance).HasDefaultValueSql("((0))");

                entity.Property(e => e.Interval).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsRemoved)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.LastRemind).HasColumnType("datetime");

                entity.Property(e => e.Location).HasDefaultValueSql("((-1))");

                entity.Property(e => e.Monday)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.NextDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.Property(e => e.OrigDate).HasColumnType("datetime");

                entity.Property(e => e.Priority)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Recontact).HasColumnType("datetime");

                entity.Property(e => e.RecurPat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RemDate).HasColumnType("datetime");

                entity.Property(e => e.RemQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RemSented)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RemType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('M')");

                entity.Property(e => e.Reminder)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Saturday)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SeEndDat).HasColumnType("datetime");

                entity.Property(e => e.SeStartDat).HasColumnType("datetime");

                entity.Property(e => e.SlpCode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.SubOption)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Sunday)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Tel).HasMaxLength(50);

                entity.Property(e => e.Thursday)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Transfered)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Tuesday)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Wednesday)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.city).HasMaxLength(100);

                entity.Property(e => e.country).HasMaxLength(3);

                entity.Property(e => e.endDate).HasColumnType("datetime");

                entity.Property(e => e.inactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.parentType).HasMaxLength(20);

                entity.Property(e => e.personal)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.room).HasMaxLength(50);

                entity.Property(e => e.state).HasMaxLength(3);

                entity.Property(e => e.street).HasMaxLength(100);

                entity.Property(e => e.tentative)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");
            });

            modelBuilder.Entity<OCLS>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("OCLS_PRIMARY");

                entity.HasIndex(e => new { e.Type, e.Name })
                    .HasName("OCLS_type")
                    .IsUnique();

                entity.Property(e => e.Code).ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.DataSource)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Type).HasDefaultValueSql("((-1))");
            });

            modelBuilder.Entity<OCLT>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("OCLT_PRIMARY");

                entity.HasIndex(e => e.Name)
                    .HasName("OCLT_NAME")
                    .IsUnique();

                entity.Property(e => e.Code).ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.DataSource)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<OCRD>(entity =>
            {
                entity.HasKey(e => e.CardCode)
                    .HasName("OCRD_PRIMARY");

                entity.HasIndex(e => e.CardName)
                    .HasName("OCRD_CARD_NAME");

                entity.HasIndex(e => e.CardType)
                    .HasName("OCRD_CARD_TYPE");

                entity.HasIndex(e => e.CommGrCode)
                    .HasName("OCRD_COM_GROUP");

                entity.HasIndex(e => e.Currency)
                    .HasName("OCRD_CURRENCY");

                entity.HasIndex(e => e.DebPayAcct)
                    .HasName("OCRD_PAY_ACCT");

                entity.HasIndex(e => e.DocEntry)
                    .HasName("OCRD_ABS_ENTRY")
                    .IsUnique();

                entity.HasIndex(e => e.FatherCard)
                    .HasName("OCRD_FATHER");

                entity.HasIndex(e => e.GroupNum)
                    .HasName("OCRD_TERMS");

                entity.HasIndex(e => e.ListNum)
                    .HasName("OCRD_PRICE_LIST");

                entity.HasIndex(e => e.OwnerCode)
                    .HasName("OCRD_OWNER_CODE");

                entity.Property(e => e.CardCode).HasMaxLength(15);

                entity.Property(e => e.AccCritria)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.AddID).HasMaxLength(64);

                entity.Property(e => e.AddrType).HasMaxLength(100);

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Affiliate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.AgentCode).HasMaxLength(32);

                entity.Property(e => e.AliasName).HasColumnType("ntext");

                entity.Property(e => e.Attachment).HasColumnType("ntext");

                entity.Property(e => e.AutoCalBCG)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.AutoPost)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BCACode).HasMaxLength(3);

                entity.Property(e => e.BackOrder)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.BalTrnsfrd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Balance).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BalanceFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BalanceSys).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BankCode)
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('-1')");

                entity.Property(e => e.BankCountr).HasMaxLength(3);

                entity.Property(e => e.BankCtlKey).HasMaxLength(2);

                entity.Property(e => e.BillToDef).HasMaxLength(50);

                entity.Property(e => e.Block).HasMaxLength(100);

                entity.Property(e => e.BlockComm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BlockDunn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BoEDiscnt).HasMaxLength(15);

                entity.Property(e => e.BoEOnClct).HasMaxLength(15);

                entity.Property(e => e.BoEPrsnt).HasMaxLength(15);

                entity.Property(e => e.Box1099).HasMaxLength(20);

                entity.Property(e => e.Building).HasColumnType("ntext");

                entity.Property(e => e.Business).HasColumnType("ntext");

                entity.Property(e => e.CardFName).HasMaxLength(100);

                entity.Property(e => e.CardName).HasMaxLength(100);

                entity.Property(e => e.CardType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('C')");

                entity.Property(e => e.CardValid).HasColumnType("datetime");

                entity.Property(e => e.Cellular).HasMaxLength(50);

                entity.Property(e => e.CertBKeep)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CertWHT)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ChannlBP).HasMaxLength(15);

                entity.Property(e => e.ChecksBal).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.CmpPrivate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('C')");

                entity.Property(e => e.CntctPrsn).HasMaxLength(90);

                entity.Property(e => e.CollecAuth)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CommGrCode).HasDefaultValueSql("((0))");

                entity.Property(e => e.Commission).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ConCerti).HasMaxLength(20);

                entity.Property(e => e.ConnBP).HasMaxLength(15);

                entity.Property(e => e.Country).HasMaxLength(3);

                entity.Property(e => e.County).HasMaxLength(100);

                entity.Property(e => e.CrCardNum).HasMaxLength(64);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreditCard).HasDefaultValueSql("((-1))");

                entity.Property(e => e.CreditLine).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.CrtfcateNO).HasMaxLength(20);

                entity.Property(e => e.Currency).HasMaxLength(3);

                entity.Property(e => e.DME).HasMaxLength(5);

                entity.Property(e => e.DNoteBalFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DNoteBalSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DNotesBal).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DataSource)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.DateTill).HasColumnType("datetime");

                entity.Property(e => e.DatevFirst)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.DdctFileNo).HasMaxLength(9);

                entity.Property(e => e.DdctOffice).HasMaxLength(10);

                entity.Property(e => e.DdctPrcnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DdctStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DdgKey).HasDefaultValueSql("((-1))");

                entity.Property(e => e.DdtKey).HasDefaultValueSql("((-1))");

                entity.Property(e => e.DebPayAcct).HasMaxLength(15);

                entity.Property(e => e.DebtLine).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DeferrTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DflAccount).HasMaxLength(50);

                entity.Property(e => e.DflBranch).HasMaxLength(50);

                entity.Property(e => e.DflIBAN).HasMaxLength(50);

                entity.Property(e => e.DflSwift).HasMaxLength(50);

                entity.Property(e => e.DiscInRet)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DiscRel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('L')");

                entity.Property(e => e.Discount).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmClear).HasMaxLength(15);

                entity.Property(e => e.DpmIntAct).HasMaxLength(15);

                entity.Property(e => e.DscntObjct).HasDefaultValueSql("((-1))");

                entity.Property(e => e.DscntRel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('L')");

                entity.Property(e => e.DunTerm).HasMaxLength(25);

                entity.Property(e => e.DunnDate).HasColumnType("datetime");

                entity.Property(e => e.ECVatGroup).HasMaxLength(8);

                entity.Property(e => e.EDocGenTyp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.E_Mail).HasMaxLength(100);

                entity.Property(e => e.EdrsFromBP)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.EdrsToBP)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.EmplymntCt).HasMaxLength(2);

                entity.Property(e => e.Equ)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ExcptnlEvt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ExemptNo).HasMaxLength(50);

                entity.Property(e => e.ExpireDate).HasColumnType("datetime");

                entity.Property(e => e.ExpnPrfFnd).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExportCode).HasMaxLength(8);

                entity.Property(e => e.FatherCard).HasMaxLength(15);

                entity.Property(e => e.FatherType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('P')");

                entity.Property(e => e.Fax).HasMaxLength(20);

                entity.Property(e => e.FeeAcc).HasMaxLength(15);

                entity.Property(e => e.Free_Text).HasColumnType("ntext");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.FrozenComm).HasMaxLength(30);

                entity.Property(e => e.GTSBankAct).HasMaxLength(80);

                entity.Property(e => e.GTSBilAddr).HasMaxLength(80);

                entity.Property(e => e.GTSRegNum).HasMaxLength(20);

                entity.Property(e => e.GlblLocNum).HasMaxLength(50);

                entity.Property(e => e.GroupNum).HasDefaultValueSql("((-1))");

                entity.Property(e => e.HierchDdct)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.HldCode).HasMaxLength(20);

                entity.Property(e => e.HousBnkAct).HasMaxLength(50);

                entity.Property(e => e.HousBnkBrn).HasMaxLength(50);

                entity.Property(e => e.HousBnkCry).HasMaxLength(3);

                entity.Property(e => e.HousCtlKey).HasMaxLength(2);

                entity.Property(e => e.HouseBank)
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('-1')");

                entity.Property(e => e.HsBnkIBAN).HasMaxLength(50);

                entity.Property(e => e.HsBnkSwift).HasMaxLength(50);

                entity.Property(e => e.IBAN).HasMaxLength(50);

                entity.Property(e => e.IPACodePA).HasMaxLength(32);

                entity.Property(e => e.ISRBillId).HasMaxLength(9);

                entity.Property(e => e.ITWTCode).HasMaxLength(4);

                entity.Property(e => e.Indicator).HasMaxLength(2);

                entity.Property(e => e.Industry).HasColumnType("ntext");

                entity.Property(e => e.InstrucKey).HasMaxLength(30);

                entity.Property(e => e.InsurOp347)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IntrAcc).HasMaxLength(15);

                entity.Property(e => e.IntrntSite).HasMaxLength(100);

                entity.Property(e => e.IntrstRate).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.IsDomestic)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.IsResident)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.KBKCode).HasMaxLength(20);

                entity.Property(e => e.LetterNum).HasMaxLength(20);

                entity.Property(e => e.LicTradNum).HasMaxLength(32);

                entity.Property(e => e.LocMth)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.LogInstanc).HasDefaultValueSql("((0))");

                entity.Property(e => e.MailAddrTy).HasMaxLength(100);

                entity.Property(e => e.MailAddres).HasMaxLength(100);

                entity.Property(e => e.MailBlock).HasMaxLength(100);

                entity.Property(e => e.MailBuildi).HasColumnType("ntext");

                entity.Property(e => e.MailCity).HasMaxLength(100);

                entity.Property(e => e.MailCountr).HasMaxLength(3);

                entity.Property(e => e.MailCounty).HasMaxLength(100);

                entity.Property(e => e.MailStrNo).HasMaxLength(100);

                entity.Property(e => e.MailZipCod).HasMaxLength(20);

                entity.Property(e => e.MandateID).HasMaxLength(35);

                entity.Property(e => e.MaxAmount).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.MerchantID).HasMaxLength(15);

                entity.Property(e => e.MinIntrst).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.MivzExpSts)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('B')");

                entity.Property(e => e.NINum).HasMaxLength(20);

                entity.Property(e => e.NoDiscount)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Notes).HasMaxLength(100);

                entity.Property(e => e.OKATO).HasMaxLength(11);

                entity.Property(e => e.OKTMO).HasMaxLength(12);

                entity.Property(e => e.ObjType)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('2')");

                entity.Property(e => e.OpCode347)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.OrderBalFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OrderBalSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OrdersBal).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OtrCtlAcct).HasMaxLength(15);

                entity.Property(e => e.OwnerIdNum).HasMaxLength(15);

                entity.Property(e => e.PECAddr).HasMaxLength(254);

                entity.Property(e => e.Pager).HasMaxLength(30);

                entity.Property(e => e.PartDelivr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.Password).HasMaxLength(32);

                entity.Property(e => e.PaymBlock)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Phone1).HasMaxLength(20);

                entity.Property(e => e.Phone2).HasMaxLength(20);

                entity.Property(e => e.Picture).HasMaxLength(200);

                entity.Property(e => e.PlngGroup).HasMaxLength(10);

                entity.Property(e => e.PrevYearAc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Priority).HasDefaultValueSql("((-1))");

                entity.Property(e => e.Profession).HasMaxLength(50);

                entity.Property(e => e.ProjectCod).HasMaxLength(20);

                entity.Property(e => e.Protected)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PyBlckDesc).HasDefaultValueSql("((-1))");

                entity.Property(e => e.PymCode)
                    .HasMaxLength(15)
                    .HasDefaultValueSql("('-1')");

                entity.Property(e => e.QryGroup1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup10)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup11)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup12)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup13)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup14)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup15)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup16)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup17)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup18)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup19)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup20)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup21)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup22)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup23)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup24)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup25)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup26)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup27)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup28)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup29)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup3)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup30)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup31)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup32)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup33)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup34)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup35)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup36)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup37)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup38)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup39)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup4)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup40)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup41)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup42)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup43)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup44)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup45)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup46)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup47)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup48)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup49)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup5)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup50)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup51)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup52)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup53)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup54)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup55)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup56)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup57)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup58)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup59)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup6)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup60)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup61)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup62)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup63)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup64)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup7)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup8)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup9)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RateDifAct).HasMaxLength(15);

                entity.Property(e => e.RcpntID).HasMaxLength(50);

                entity.Property(e => e.RefDetails).HasMaxLength(20);

                entity.Property(e => e.RegNum).HasMaxLength(32);

                entity.Property(e => e.RelCode).HasMaxLength(2);

                entity.Property(e => e.RepAddID).HasMaxLength(28);

                entity.Property(e => e.RepCmpName).HasMaxLength(36);

                entity.Property(e => e.RepFName).HasMaxLength(20);

                entity.Property(e => e.RepFisCode).HasMaxLength(16);

                entity.Property(e => e.RepName).HasMaxLength(15);

                entity.Property(e => e.RepSName).HasMaxLength(36);

                entity.Property(e => e.ResidenNum)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.RoleTypCod).HasMaxLength(2);

                entity.Property(e => e.SCAdjust)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SPGCounter).HasDefaultValueSql("((0))");

                entity.Property(e => e.SPPCounter).HasDefaultValueSql("((0))");

                entity.Property(e => e.SefazCheck)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SelfInvoic)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SenderID).HasMaxLength(50);

                entity.Property(e => e.ShipToDef).HasMaxLength(50);

                entity.Property(e => e.SignDate).HasColumnType("datetime");

                entity.Property(e => e.SinglePaym)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SlpCode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.State1).HasMaxLength(3);

                entity.Property(e => e.State2).HasMaxLength(3);

                entity.Property(e => e.StreetNo).HasMaxLength(100);

                entity.Property(e => e.SurOver)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SysMatchNo).HasDefaultValueSql("((-1))");

                entity.Property(e => e.TaxIdIdent)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('3')");

                entity.Property(e => e.TaxRndRule)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('D')");

                entity.Property(e => e.ThreshOver)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.TpCusPres).HasDefaultValueSql("((9))");

                entity.Property(e => e.Transfered)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.TypWTReprt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('C')");

                entity.Property(e => e.TypeOfOp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UnpaidBoE).HasMaxLength(15);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UseShpdGd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.VATRegNum).HasMaxLength(32);

                entity.Property(e => e.ValidComm).HasMaxLength(30);

                entity.Property(e => e.ValidUntil).HasColumnType("datetime");

                entity.Property(e => e.VatGroup).HasMaxLength(8);

                entity.Property(e => e.VatIDNum).HasMaxLength(32);

                entity.Property(e => e.VatIdUnCmp).HasMaxLength(32);

                entity.Property(e => e.VatStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.VendorOcup).HasMaxLength(15);

                entity.Property(e => e.VerifNum).HasMaxLength(32);

                entity.Property(e => e.WHShaamGrp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.WTCode).HasMaxLength(4);

                entity.Property(e => e.WTLiable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.WTTaxCat).HasColumnType("ntext");

                entity.Property(e => e.ZipCode).HasMaxLength(20);

                entity.Property(e => e.chainStore)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.eCityTown).HasMaxLength(48);

                entity.Property(e => e.eCountry).HasMaxLength(3);

                entity.Property(e => e.eDistrict).HasMaxLength(3);

                entity.Property(e => e.eStreet).HasMaxLength(38);

                entity.Property(e => e.eStreetNum).HasMaxLength(4);

                entity.Property(e => e.eZipCode).HasMaxLength(10);

                entity.Property(e => e.free312)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.free313)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.frozenFor)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.frozenFrom).HasColumnType("datetime");

                entity.Property(e => e.frozenTo).HasColumnType("datetime");

                entity.Property(e => e.sEmployed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.validFor)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.validFrom).HasColumnType("datetime");

                entity.Property(e => e.validTo).HasColumnType("datetime");
            });

            modelBuilder.Entity<OCRG>(entity =>
            {
                entity.HasKey(e => e.GroupCode)
                    .HasName("OCRG_PRIMARY");

                entity.HasIndex(e => e.GroupName)
                    .HasName("OCRG_GROUP_NAME")
                    .IsUnique();

                entity.HasIndex(e => e.GroupType)
                    .HasName("OCRG_GROUP_TYPE");

                entity.Property(e => e.GroupCode).ValueGeneratedNever();

                entity.Property(e => e.DataSource)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DiscRel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('L')");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.GroupType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('C')");

                entity.Property(e => e.Locked)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");
            });

            modelBuilder.Entity<ODLN>(entity =>
            {
                entity.HasKey(e => e.DocEntry)
                    .HasName("ODLN_PRIMARY");

                entity.HasIndex(e => e.CardCode)
                    .HasName("ODLN_CUSTOMER");

                entity.HasIndex(e => e.FolSeries)
                    .HasName("ODLN_FOL_SERIES");

                entity.HasIndex(e => e.OwnerCode)
                    .HasName("ODLN_OWNER_CODE");

                entity.HasIndex(e => e.Series)
                    .HasName("ODLN_SERIES");

                entity.HasIndex(e => new { e.DocDate, e.PIndicator })
                    .HasName("ODLN_DATE_PIND");

                entity.HasIndex(e => new { e.DocStatus, e.CANCELED })
                    .HasName("ODLN_DOC_STATUS");

                entity.HasIndex(e => new { e.ESeries, e.EDocNum })
                    .HasName("ODLN_ESERIES");

                entity.HasIndex(e => new { e.FatherCard, e.FatherType })
                    .HasName("ODLN_FTHR_CARD");

                entity.HasIndex(e => new { e.NumAtCard, e.CardCode })
                    .HasName("ODLN_AT_CARD");

                entity.HasIndex(e => new { e.DocNum, e.Instance, e.Segment, e.DocSubType, e.PIndicator })
                    .HasName("ODLN_NUM");

                entity.Property(e => e.DocEntry).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(254);

                entity.Property(e => e.Address2).HasMaxLength(254);

                entity.Property(e => e.AgentCode).HasMaxLength(32);

                entity.Property(e => e.AltBaseTyp).HasDefaultValueSql("((-1))");

                entity.Property(e => e.AqcsTax).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.AqcsTaxFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.AqcsTaxSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.AssetDate).HasColumnType("datetime");

                entity.Property(e => e.AtDocType).HasMaxLength(2);

                entity.Property(e => e.Attachment).HasColumnType("ntext");

                entity.Property(e => e.AuthCode).HasMaxLength(250);

                entity.Property(e => e.AutoCrtFlw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BPChCode).HasMaxLength(15);

                entity.Property(e => e.BPLName).HasMaxLength(100);

                entity.Property(e => e.BPNameOW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BankCode).HasMaxLength(30);

                entity.Property(e => e.BaseAmnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseAmntFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseAmntSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseDisc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseDiscFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseDiscPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseDiscSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseType).HasDefaultValueSql("((-1))");

                entity.Property(e => e.BaseVtAt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseVtAtFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseVtAtSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BillToOW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BlkCredMmo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BlockDunn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BnkAccount).HasMaxLength(50);

                entity.Property(e => e.BnkBranch).HasMaxLength(50);

                entity.Property(e => e.BnkCntry).HasMaxLength(3);

                entity.Property(e => e.BoeReserev)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Box1099).HasMaxLength(20);

                entity.Property(e => e.BuildDesc).HasMaxLength(50);

                entity.Property(e => e.CANCELED)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CEECFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CancelDate).HasColumnType("datetime");

                entity.Property(e => e.CardCode).HasMaxLength(15);

                entity.Property(e => e.CardName).HasMaxLength(100);

                entity.Property(e => e.CashDiscFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.CashDiscPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.CashDiscSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.CashDiscnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.CdcOffset).HasDefaultValueSql("((0))");

                entity.Property(e => e.CertNum).HasMaxLength(31);

                entity.Property(e => e.CertifNum).HasMaxLength(50);

                entity.Property(e => e.CheckDigit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ClosingOpt).HasDefaultValueSql("((1))");

                entity.Property(e => e.ClsDate).HasColumnType("datetime");

                entity.Property(e => e.CntrlBnk).HasMaxLength(15);

                entity.Property(e => e.Comments).HasMaxLength(254);

                entity.Property(e => e.Confirmed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.CopyNumber).HasDefaultValueSql("((0))");

                entity.Property(e => e.CorrExt).HasMaxLength(25);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateTran)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CtlAccount).HasMaxLength(15);

                entity.Property(e => e.CurSource)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('C')");

                entity.Property(e => e.DataSource)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DateReport).HasColumnType("datetime");

                entity.Property(e => e.DeferrTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DiscPrcnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DiscSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DiscSumFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DiscSumSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DmpTransID).HasMaxLength(20);

                entity.Property(e => e.DocCur).HasMaxLength(3);

                entity.Property(e => e.DocDate).HasColumnType("datetime");

                entity.Property(e => e.DocDlvry)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DocDueDate).HasColumnType("datetime");

                entity.Property(e => e.DocManClsd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DocRate).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DocStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('O')");

                entity.Property(e => e.DocSubType)
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('--')");

                entity.Property(e => e.DocTaxID).HasMaxLength(32);

                entity.Property(e => e.DocTotal).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DocTotalFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DocTotalSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DocType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('I')");

                entity.Property(e => e.DpmAmnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAmntFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAmntSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAppVat).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAppVatF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAppVatS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAppl).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmApplFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmApplSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAsDscnt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DpmDrawn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DpmPrcnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('O')");

                entity.Property(e => e.DpmVat).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmVatFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmVatSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DutyStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.EComerGSTN).HasMaxLength(15);

                entity.Property(e => e.ECommerBP).HasMaxLength(15);

                entity.Property(e => e.EDocCancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.EDocCntnt).HasColumnType("ntext");

                entity.Property(e => e.EDocErrCod).HasMaxLength(50);

                entity.Property(e => e.EDocErrMsg).HasColumnType("ntext");

                entity.Property(e => e.EDocGenTyp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.EDocNum).HasMaxLength(50);

                entity.Property(e => e.EDocPrefix).HasMaxLength(10);

                entity.Property(e => e.EDocProces)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('C')");

                entity.Property(e => e.EDocStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('C')");

                entity.Property(e => e.EDocTest)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ElCoMsg).HasMaxLength(254);

                entity.Property(e => e.ElCoStatus).HasMaxLength(10);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.EndDlvDate).HasColumnType("datetime");

                entity.Property(e => e.EnvTypeNFe).HasDefaultValueSql("((-1))");

                entity.Property(e => e.EquVatSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EquVatSumF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EquVatSumS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExcDocDate).HasColumnType("datetime");

                entity.Property(e => e.ExcRefDate).HasColumnType("datetime");

                entity.Property(e => e.ExcRmvTime).HasMaxLength(8);

                entity.Property(e => e.Excised)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('O')");

                entity.Property(e => e.ExclTaxRep)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ExepAmnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExepAmntFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExepAmntSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpAnFrgn).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpAnSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpAnSys).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpAppl).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpApplFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpApplSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Exported)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ExptVAt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExptVAtFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExptVAtSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FatherCard).HasMaxLength(15);

                entity.Property(e => e.FatherType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('P')");

                entity.Property(e => e.Filler).HasMaxLength(8);

                entity.Property(e => e.FiscDocNum).HasMaxLength(100);

                entity.Property(e => e.Flags).HasDefaultValueSql("((0))");

                entity.Property(e => e.FlwRefDate).HasColumnType("datetime");

                entity.Property(e => e.FlwRefNum).HasMaxLength(100);

                entity.Property(e => e.FoCFrght).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FoCFrghtFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FoCFrghtSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FoCTax).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FoCTaxFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FoCTaxSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FolioPref).HasMaxLength(4);

                entity.Property(e => e.Footer).HasColumnType("ntext");

                entity.Property(e => e.FreeChrg).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FreeChrgFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FreeChrgSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FrmBpDate).HasColumnType("datetime");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.GSTTranTyp).HasMaxLength(2);

                entity.Property(e => e.GTSRlvnt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.GrosProfFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrosProfSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrosProfit).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrossBase).HasDefaultValueSql("((0))");

                entity.Property(e => e.Handwrtten)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Header).HasColumnType("ntext");

                entity.Property(e => e.ISRCodLine).HasMaxLength(53);

                entity.Property(e => e.IgnRelDoc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Indicator).HasMaxLength(2);

                entity.Property(e => e.Installmnt).HasDefaultValueSql("((1))");

                entity.Property(e => e.Instance).HasDefaultValueSql("((0))");

                entity.Property(e => e.InsurOp347)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.InterimTyp).HasDefaultValueSql("((0))");

                entity.Property(e => e.InvntDirec)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('X')");

                entity.Property(e => e.InvntSttus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('O')");

                entity.Property(e => e.IsAlt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsICT)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsPaytoBnk)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IsReuseNFN)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsReuseNum)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.JrnlMemo).HasMaxLength(50);

                entity.Property(e => e.KVVATCode).HasColumnType("ntext");

                entity.Property(e => e.LYPmtAt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LYPmtAtFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LYPmtAtSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LastPmnTyp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Letter)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LetterNum).HasMaxLength(20);

                entity.Property(e => e.LicTradNum).HasMaxLength(32);

                entity.Property(e => e.LogInstanc).HasDefaultValueSql("((0))");

                entity.Property(e => e.MInvDate).HasColumnType("datetime");

                entity.Property(e => e.MYFtype).HasMaxLength(2);

                entity.Property(e => e.ManualNum).HasMaxLength(20);

                entity.Property(e => e.Max1099).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.MaxDscn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Model)
                    .HasMaxLength(6)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NTSApprNo).HasMaxLength(50);

                entity.Property(e => e.NTSApprov)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.NTSeTaxNo).HasMaxLength(50);

                entity.Property(e => e.NbSbAmntFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NbSbVAtFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NetProc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.NfePrntFo).HasDefaultValueSql("((0))");

                entity.Property(e => e.NfeValue).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NnSbAmnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NnSbAmntSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NnSbVAt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NnSbVAtSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Notify)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NumAtCard).HasMaxLength(100);

                entity.Property(e => e.ObjType)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('15')");

                entity.Property(e => e.OnlineQuo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.OpenForLaC)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.Ordered)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.OriginType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('M')");

                entity.Property(e => e.PIndicator)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.POSEqNum).HasMaxLength(20);

                entity.Property(e => e.POSManufSN).HasMaxLength(20);

                entity.Property(e => e.PQTGrpHW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PTICode).HasMaxLength(5);

                entity.Property(e => e.PaidDpm).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidDpmF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidDpmS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidSumFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidSumSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidSys).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidToDate).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PartSupply)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.PayBlock)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PayDuMonth)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PayToCode).HasMaxLength(50);

                entity.Property(e => e.PaymentRef).HasMaxLength(27);

                entity.Property(e => e.PermitNo).HasMaxLength(20);

                entity.Property(e => e.PeyMethod).HasMaxLength(15);

                entity.Property(e => e.Pick)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PickRmrk).HasMaxLength(254);

                entity.Property(e => e.PickStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PoDropPrss)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PoPrss)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Posted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.PrintSEPA)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Printed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Project).HasMaxLength(20);

                entity.Property(e => e.Ref1).HasMaxLength(11);

                entity.Property(e => e.Ref2).HasMaxLength(11);

                entity.Property(e => e.RelatedTyp).HasDefaultValueSql("((-1))");

                entity.Property(e => e.ReopManCls)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ReopOriDoc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RepSection).HasMaxLength(3);

                entity.Property(e => e.ReqDate).HasColumnType("datetime");

                entity.Property(e => e.ReqName).HasMaxLength(155);

                entity.Property(e => e.ReqType).HasDefaultValueSql("((12))");

                entity.Property(e => e.Requester).HasMaxLength(25);

                entity.Property(e => e.Reserve)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ResidenNum)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.RetInvoice)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RevCreRefD).HasColumnType("datetime");

                entity.Property(e => e.RevCreRefN).HasMaxLength(100);

                entity.Property(e => e.RevRefDate).HasColumnType("datetime");

                entity.Property(e => e.RevRefNo).HasMaxLength(100);

                entity.Property(e => e.Revision)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RevisionPo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RoundDif).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RoundDifFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RoundDifSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Rounding)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SSIExmpt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Segment).HasDefaultValueSql("((0))");

                entity.Property(e => e.SeriesStr).HasMaxLength(3);

                entity.Property(e => e.ShipToCode).HasMaxLength(50);

                entity.Property(e => e.ShipToOW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ShowSCN)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SignDigest).HasColumnType("ntext");

                entity.Property(e => e.SignMsg).HasColumnType("ntext");

                entity.Property(e => e.SlpCode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.SpecDate).HasColumnType("datetime");

                entity.Property(e => e.SplitTax).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SplitTaxFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SplitTaxSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SrvGpPrcnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SrvTaxRule)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.StDlvDate).HasColumnType("datetime");

                entity.Property(e => e.StampNum).HasMaxLength(16);

                entity.Property(e => e.SubStr).HasMaxLength(3);

                entity.Property(e => e.SumAbsId).HasDefaultValueSql("((-1))");

                entity.Property(e => e.SumRptDate).HasColumnType("datetime");

                entity.Property(e => e.SummryType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SupplCode).HasMaxLength(254);

                entity.Property(e => e.Supplier).HasMaxLength(15);

                entity.Property(e => e.SysRate).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxDate).HasColumnType("datetime");

                entity.Property(e => e.TaxInvNo).HasMaxLength(100);

                entity.Property(e => e.TaxOnExAp).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxOnExApF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxOnExApS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxOnExp).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxOnExpFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxOnExpSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ToBinCode).HasMaxLength(228);

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.ToWhsCode).HasMaxLength(8);

                entity.Property(e => e.TotalExpFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TotalExpSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TotalExpns).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TrackNo).HasMaxLength(30);

                entity.Property(e => e.Transfered)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.TrnspCode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.TxInvRptDt).HasColumnType("datetime");

                entity.Property(e => e.TxInvRptNo).HasMaxLength(10);

                entity.Property(e => e.UpdCardBal)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.UpdInvnt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UseCorrVat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.UseShpdGd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.VATFirst)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.VATRegNum).HasMaxLength(32);

                entity.Property(e => e.VatDate).HasColumnType("datetime");

                entity.Property(e => e.VatJENum).HasDefaultValueSql("((-1))");

                entity.Property(e => e.VatPaid).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatPaidFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatPaidSys).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatPercent).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatSumFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatSumSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VclPlate).HasMaxLength(20);

                entity.Property(e => e.VersionNum).HasMaxLength(11);

                entity.Property(e => e.Volume).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTApplied).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTAppliedF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTAppliedS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTDetails).HasMaxLength(100);

                entity.Property(e => e.WTSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTSumFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTSumSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WddStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('-')");

                entity.Property(e => e.Weight).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.draftKey).HasDefaultValueSql("((-1))");

                entity.Property(e => e.isCrin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.isIns)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.selfInv)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.submitted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");
            });

            modelBuilder.Entity<ODPI>(entity =>
            {
                entity.HasKey(e => e.DocEntry)
                    .HasName("ODPI_PRIMARY");

                entity.HasIndex(e => e.CardCode)
                    .HasName("ODPI_CUSTOMER");

                entity.HasIndex(e => e.OwnerCode)
                    .HasName("ODPI_OWNER_CODE");

                entity.HasIndex(e => e.Series)
                    .HasName("ODPI_SERIES");

                entity.HasIndex(e => new { e.DocDate, e.PIndicator })
                    .HasName("ODPI_DATE_PIND");

                entity.HasIndex(e => new { e.DocStatus, e.CANCELED })
                    .HasName("ODPI_DOC_STATUS");

                entity.HasIndex(e => new { e.ESeries, e.EDocNum })
                    .HasName("ODPI_ESERIES");

                entity.HasIndex(e => new { e.FatherCard, e.FatherType })
                    .HasName("ODPI_FTHR_CARD");

                entity.HasIndex(e => new { e.NumAtCard, e.CardCode })
                    .HasName("ODPI_AT_CARD");

                entity.HasIndex(e => new { e.DocNum, e.Instance, e.Segment, e.DocSubType, e.PIndicator })
                    .HasName("ODPI_NUM")
                    .IsUnique();

                entity.Property(e => e.DocEntry).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(254);

                entity.Property(e => e.Address2).HasMaxLength(254);

                entity.Property(e => e.AgentCode).HasMaxLength(32);

                entity.Property(e => e.AltBaseTyp).HasDefaultValueSql("((-1))");

                entity.Property(e => e.AqcsTax).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.AqcsTaxFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.AqcsTaxSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.AssetDate).HasColumnType("datetime");

                entity.Property(e => e.AtDocType).HasMaxLength(2);

                entity.Property(e => e.Attachment).HasColumnType("ntext");

                entity.Property(e => e.AuthCode).HasMaxLength(250);

                entity.Property(e => e.AutoCrtFlw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BPChCode).HasMaxLength(15);

                entity.Property(e => e.BPLName).HasMaxLength(100);

                entity.Property(e => e.BPNameOW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BankCode).HasMaxLength(30);

                entity.Property(e => e.BaseAmnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseAmntFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseAmntSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseDisc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseDiscFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseDiscPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseDiscSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseType).HasDefaultValueSql("((-1))");

                entity.Property(e => e.BaseVtAt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseVtAtFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseVtAtSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BillToOW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BlkCredMmo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BlockDunn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BnkAccount).HasMaxLength(50);

                entity.Property(e => e.BnkBranch).HasMaxLength(50);

                entity.Property(e => e.BnkCntry).HasMaxLength(3);

                entity.Property(e => e.BoeReserev)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Box1099).HasMaxLength(20);

                entity.Property(e => e.BuildDesc).HasMaxLength(50);

                entity.Property(e => e.CANCELED)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CEECFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CancelDate).HasColumnType("datetime");

                entity.Property(e => e.CardCode).HasMaxLength(15);

                entity.Property(e => e.CardName).HasMaxLength(100);

                entity.Property(e => e.CashDiscFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.CashDiscPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.CashDiscSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.CashDiscnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.CdcOffset).HasDefaultValueSql("((0))");

                entity.Property(e => e.CertNum).HasMaxLength(31);

                entity.Property(e => e.CertifNum).HasMaxLength(50);

                entity.Property(e => e.CheckDigit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ClosingOpt).HasDefaultValueSql("((1))");

                entity.Property(e => e.ClsDate).HasColumnType("datetime");

                entity.Property(e => e.CntrlBnk).HasMaxLength(15);

                entity.Property(e => e.Comments).HasMaxLength(254);

                entity.Property(e => e.Confirmed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.CopyNumber).HasDefaultValueSql("((0))");

                entity.Property(e => e.CorrExt).HasMaxLength(25);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateTran)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CtlAccount).HasMaxLength(15);

                entity.Property(e => e.CurSource)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('C')");

                entity.Property(e => e.DataSource)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DateReport).HasColumnType("datetime");

                entity.Property(e => e.DeferrTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DiscPrcnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DiscSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DiscSumFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DiscSumSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DmpTransID).HasMaxLength(20);

                entity.Property(e => e.DocCur).HasMaxLength(3);

                entity.Property(e => e.DocDate).HasColumnType("datetime");

                entity.Property(e => e.DocDlvry)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DocDueDate).HasColumnType("datetime");

                entity.Property(e => e.DocManClsd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DocRate).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DocStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('O')");

                entity.Property(e => e.DocSubType)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('--')");

                entity.Property(e => e.DocTaxID).HasMaxLength(32);

                entity.Property(e => e.DocTotal).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DocTotalFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DocTotalSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DocType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('I')");

                entity.Property(e => e.DpmAmnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAmntFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAmntSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAppVat).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAppVatF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAppVatS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAppl).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmApplFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmApplSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAsDscnt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DpmDrawn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DpmPrcnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('O')");

                entity.Property(e => e.DpmVat).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmVatFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmVatSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DutyStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.EComerGSTN).HasMaxLength(15);

                entity.Property(e => e.ECommerBP).HasMaxLength(15);

                entity.Property(e => e.EDocCancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.EDocCntnt).HasColumnType("ntext");

                entity.Property(e => e.EDocErrCod).HasMaxLength(50);

                entity.Property(e => e.EDocErrMsg).HasColumnType("ntext");

                entity.Property(e => e.EDocGenTyp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.EDocNum).HasMaxLength(50);

                entity.Property(e => e.EDocPrefix).HasMaxLength(10);

                entity.Property(e => e.EDocProces)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('C')");

                entity.Property(e => e.EDocStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('C')");

                entity.Property(e => e.EDocTest)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ElCoMsg).HasMaxLength(254);

                entity.Property(e => e.ElCoStatus).HasMaxLength(10);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.EndDlvDate).HasColumnType("datetime");

                entity.Property(e => e.EnvTypeNFe).HasDefaultValueSql("((-1))");

                entity.Property(e => e.EquVatSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EquVatSumF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EquVatSumS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExcDocDate).HasColumnType("datetime");

                entity.Property(e => e.ExcRefDate).HasColumnType("datetime");

                entity.Property(e => e.ExcRmvTime).HasMaxLength(8);

                entity.Property(e => e.Excised)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('O')");

                entity.Property(e => e.ExclTaxRep)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ExepAmnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExepAmntFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExepAmntSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpAnFrgn).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpAnSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpAnSys).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpAppl).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpApplFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpApplSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Exported)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ExptVAt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExptVAtFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExptVAtSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FatherCard).HasMaxLength(15);

                entity.Property(e => e.FatherType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('P')");

                entity.Property(e => e.Filler).HasMaxLength(8);

                entity.Property(e => e.FiscDocNum).HasMaxLength(100);

                entity.Property(e => e.Flags).HasDefaultValueSql("((0))");

                entity.Property(e => e.FlwRefDate).HasColumnType("datetime");

                entity.Property(e => e.FlwRefNum).HasMaxLength(100);

                entity.Property(e => e.FoCFrght).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FoCFrghtFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FoCFrghtSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FoCTax).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FoCTaxFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FoCTaxSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FolioPref).HasMaxLength(4);

                entity.Property(e => e.Footer).HasColumnType("ntext");

                entity.Property(e => e.FreeChrg).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FreeChrgFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FreeChrgSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FrmBpDate).HasColumnType("datetime");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.GSTTranTyp).HasMaxLength(2);

                entity.Property(e => e.GTSRlvnt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.GrosProfFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrosProfSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrosProfit).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrossBase).HasDefaultValueSql("((0))");

                entity.Property(e => e.Handwrtten)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Header).HasColumnType("ntext");

                entity.Property(e => e.ISRCodLine).HasMaxLength(53);

                entity.Property(e => e.IgnRelDoc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Indicator).HasMaxLength(2);

                entity.Property(e => e.Installmnt).HasDefaultValueSql("((1))");

                entity.Property(e => e.InsurOp347)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.InterimTyp).HasDefaultValueSql("((0))");

                entity.Property(e => e.InvntDirec)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('X')");

                entity.Property(e => e.InvntSttus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('O')");

                entity.Property(e => e.IsAlt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsICT)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsPaytoBnk)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IsReuseNFN)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsReuseNum)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.JrnlMemo).HasMaxLength(50);

                entity.Property(e => e.KVVATCode).HasColumnType("ntext");

                entity.Property(e => e.LYPmtAt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LYPmtAtFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LYPmtAtSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LastPmnTyp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Letter)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LetterNum).HasMaxLength(20);

                entity.Property(e => e.LicTradNum).HasMaxLength(32);

                entity.Property(e => e.LogInstanc).HasDefaultValueSql("((0))");

                entity.Property(e => e.MInvDate).HasColumnType("datetime");

                entity.Property(e => e.MYFtype).HasMaxLength(2);

                entity.Property(e => e.ManualNum).HasMaxLength(20);

                entity.Property(e => e.Max1099).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.MaxDscn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Model)
                    .HasMaxLength(6)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NTSApprNo).HasMaxLength(50);

                entity.Property(e => e.NTSApprov)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.NTSeTaxNo).HasMaxLength(50);

                entity.Property(e => e.NbSbAmntFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NbSbVAtFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NetProc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.NfePrntFo).HasDefaultValueSql("((0))");

                entity.Property(e => e.NfeValue).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NnSbAmnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NnSbAmntSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NnSbVAt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NnSbVAtSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Notify)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NumAtCard).HasMaxLength(100);

                entity.Property(e => e.ObjType)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('203')");

                entity.Property(e => e.OnlineQuo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.OpenForLaC)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.Ordered)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.OriginType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('M')");

                entity.Property(e => e.PIndicator)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.POSEqNum).HasMaxLength(20);

                entity.Property(e => e.POSManufSN).HasMaxLength(20);

                entity.Property(e => e.PQTGrpHW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PTICode).HasMaxLength(5);

                entity.Property(e => e.PaidDpm).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidDpmF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidDpmS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidSumFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidSumSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidSys).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidToDate).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PartSupply)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.PayBlock)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PayDuMonth)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PayToCode).HasMaxLength(50);

                entity.Property(e => e.PaymentRef).HasMaxLength(27);

                entity.Property(e => e.PermitNo).HasMaxLength(20);

                entity.Property(e => e.PeyMethod).HasMaxLength(15);

                entity.Property(e => e.Pick)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PickRmrk).HasMaxLength(254);

                entity.Property(e => e.PickStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PoDropPrss)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PoPrss)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Posted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.PrintSEPA)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Printed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Project).HasMaxLength(20);

                entity.Property(e => e.Ref1).HasMaxLength(11);

                entity.Property(e => e.Ref2).HasMaxLength(11);

                entity.Property(e => e.RelatedTyp).HasDefaultValueSql("((-1))");

                entity.Property(e => e.ReopManCls)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ReopOriDoc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RepSection).HasMaxLength(3);

                entity.Property(e => e.ReqDate).HasColumnType("datetime");

                entity.Property(e => e.ReqName).HasMaxLength(155);

                entity.Property(e => e.ReqType).HasDefaultValueSql("((12))");

                entity.Property(e => e.Requester).HasMaxLength(25);

                entity.Property(e => e.Reserve)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ResidenNum)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.RetInvoice)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RevCreRefD).HasColumnType("datetime");

                entity.Property(e => e.RevCreRefN).HasMaxLength(100);

                entity.Property(e => e.RevRefDate).HasColumnType("datetime");

                entity.Property(e => e.RevRefNo).HasMaxLength(100);

                entity.Property(e => e.Revision)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RevisionPo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RoundDif).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RoundDifFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RoundDifSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Rounding)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SSIExmpt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SeriesStr).HasMaxLength(3);

                entity.Property(e => e.ShipToCode).HasMaxLength(50);

                entity.Property(e => e.ShipToOW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ShowSCN)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SignDigest).HasColumnType("ntext");

                entity.Property(e => e.SignMsg).HasColumnType("ntext");

                entity.Property(e => e.SlpCode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.SpecDate).HasColumnType("datetime");

                entity.Property(e => e.SplitTax).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SplitTaxFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SplitTaxSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SrvGpPrcnt)
                    .HasColumnType("numeric(19, 6)")
                    .HasDefaultValueSql("((100))");

                entity.Property(e => e.SrvTaxRule)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.StDlvDate).HasColumnType("datetime");

                entity.Property(e => e.StampNum).HasMaxLength(16);

                entity.Property(e => e.SubStr).HasMaxLength(3);

                entity.Property(e => e.SumAbsId).HasDefaultValueSql("((-1))");

                entity.Property(e => e.SumRptDate).HasColumnType("datetime");

                entity.Property(e => e.SummryType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SupplCode).HasMaxLength(254);

                entity.Property(e => e.Supplier).HasMaxLength(15);

                entity.Property(e => e.SysRate).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxDate).HasColumnType("datetime");

                entity.Property(e => e.TaxInvNo).HasMaxLength(100);

                entity.Property(e => e.TaxOnExAp).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxOnExApF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxOnExApS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxOnExp).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxOnExpFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxOnExpSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ToBinCode).HasMaxLength(228);

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.ToWhsCode).HasMaxLength(8);

                entity.Property(e => e.TotalExpFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TotalExpSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TotalExpns).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TrackNo).HasMaxLength(30);

                entity.Property(e => e.Transfered)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.TrnspCode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.TxInvRptDt).HasColumnType("datetime");

                entity.Property(e => e.TxInvRptNo).HasMaxLength(10);

                entity.Property(e => e.UpdCardBal)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.UpdInvnt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UseCorrVat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.UseShpdGd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.VATFirst)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.VATRegNum).HasMaxLength(32);

                entity.Property(e => e.VatDate).HasColumnType("datetime");

                entity.Property(e => e.VatJENum).HasDefaultValueSql("((-1))");

                entity.Property(e => e.VatPaid).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatPaidFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatPaidSys).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatPercent).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatSumFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatSumSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VclPlate).HasMaxLength(20);

                entity.Property(e => e.VersionNum).HasMaxLength(11);

                entity.Property(e => e.Volume).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTApplied).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTAppliedF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTAppliedS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTDetails).HasMaxLength(100);

                entity.Property(e => e.WTSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTSumFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTSumSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WddStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('-')");

                entity.Property(e => e.Weight).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.draftKey).HasDefaultValueSql("((-1))");

                entity.Property(e => e.isCrin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.isIns)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.selfInv)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.submitted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");
            });

            modelBuilder.Entity<ODSC>(entity =>
            {
                entity.HasKey(e => e.AbsEntry)
                    .HasName("ODSC_PRIMARY");

                entity.HasIndex(e => new { e.CountryCod, e.BankCode })
                    .HasName("ODSC_SECONDARY")
                    .IsUnique();

                entity.Property(e => e.AbsEntry).ValueGeneratedNever();

                entity.Property(e => e.AliasName).HasMaxLength(50);

                entity.Property(e => e.BankCode)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.BankName).HasMaxLength(250);

                entity.Property(e => e.BsDocDate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('C')");

                entity.Property(e => e.BsPstDate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('C')");

                entity.Property(e => e.BsValDate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('C')");

                entity.Property(e => e.CountryCod)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.DataSource)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DfltAcct).HasMaxLength(50);

                entity.Property(e => e.DfltBranch).HasMaxLength(50);

                entity.Property(e => e.IBAN).HasMaxLength(50);

                entity.Property(e => e.Locked)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PostOffice)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SwiftNum).HasMaxLength(50);
            });

            modelBuilder.Entity<OHEM>(entity =>
            {
                entity.HasKey(e => e.empID)
                    .HasName("OHEM_PRIMARY");

                entity.HasIndex(e => e.salesPrson)
                    .HasName("OHEM_OSLP");

                entity.HasIndex(e => e.userId)
                    .HasName("OHEM_OUSR");

                entity.HasIndex(e => new { e.firstName, e.middleName, e.lastName })
                    .HasName("OHEM_NAME");

                entity.Property(e => e.empID).ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.AddiAmnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.AddiCurr).HasMaxLength(3);

                entity.Property(e => e.AddiUnit)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AddrTypeH).HasMaxLength(100);

                entity.Property(e => e.AddrTypeW).HasMaxLength(100);

                entity.Property(e => e.BCodeDateV).HasMaxLength(20);

                entity.Property(e => e.BPLink).HasMaxLength(15);

                entity.Property(e => e.BirthPlace).HasMaxLength(100);

                entity.Property(e => e.CPF).HasMaxLength(100);

                entity.Property(e => e.CRC).HasMaxLength(20);

                entity.Property(e => e.CompanyNum).HasMaxLength(20);

                entity.Property(e => e.ContResp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CostCenter).HasMaxLength(8);

                entity.Property(e => e.DevBAOwner)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DirfDeclar)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DispComma)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DispMidNam)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.EmTaxCCode)
                    .HasMaxLength(9)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ExemptAmnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExemptCurr).HasMaxLength(3);

                entity.Property(e => e.ExemptUnit)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ExtEmpNo).HasMaxLength(20);

                entity.Property(e => e.FNameSP).HasMaxLength(50);

                entity.Property(e => e.FatherName).HasMaxLength(150);

                entity.Property(e => e.HeaInsCode).HasMaxLength(50);

                entity.Property(e => e.HeaInsName).HasMaxLength(50);

                entity.Property(e => e.HeaInsType)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.HomeBuild).HasColumnType("ntext");

                entity.Property(e => e.IDType).HasMaxLength(30);

                entity.Property(e => e.InTaxLiabi)
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.JTCode).HasMaxLength(5);

                entity.Property(e => e.LogInstanc).HasDefaultValueSql("((0))");

                entity.Property(e => e.ManualNUM).HasMaxLength(60);

                entity.Property(e => e.MunKey).HasMaxLength(20);

                entity.Property(e => e.NamePos)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.PRWebAccss)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PassIssue).HasColumnType("datetime");

                entity.Property(e => e.PassIssuer).HasMaxLength(254);

                entity.Property(e => e.PersGroup)
                    .HasMaxLength(5)
                    .HasDefaultValueSql("('-1')");

                entity.Property(e => e.PrePRWeb)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PymMeth)
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('05')");

                entity.Property(e => e.QualCode)
                    .HasMaxLength(3)
                    .HasDefaultValueSql("('000')");

                entity.Property(e => e.RelPartner)
                    .HasMaxLength(9)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.RepLegal)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SInsurNum).HasMaxLength(20);

                entity.Property(e => e.StatusOfE)
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.StatusOfP)
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('-1')");

                entity.Property(e => e.StreetNoH).HasMaxLength(100);

                entity.Property(e => e.StreetNoW).HasMaxLength(100);

                entity.Property(e => e.SurnameSP).HasMaxLength(50);

                entity.Property(e => e.TaxClass)
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.TaxOName).HasMaxLength(50);

                entity.Property(e => e.TaxONum).HasMaxLength(20);

                entity.Property(e => e.UF_CRC).HasMaxLength(3);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.WorkBuild).HasColumnType("ntext");

                entity.Property(e => e.attachment).HasColumnType("ntext");

                entity.Property(e => e.bankAcount).HasMaxLength(100);

                entity.Property(e => e.bankBranNo).HasMaxLength(30);

                entity.Property(e => e.bankBranch).HasMaxLength(100);

                entity.Property(e => e.bankCode).HasMaxLength(30);

                entity.Property(e => e.birthDate).HasColumnType("datetime");

                entity.Property(e => e.brthCountr).HasMaxLength(3);

                entity.Property(e => e.citizenshp).HasMaxLength(3);

                entity.Property(e => e.email).HasMaxLength(100);

                entity.Property(e => e.empCostCur).HasMaxLength(3);

                entity.Property(e => e.empCostUnt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('M')");

                entity.Property(e => e.emplCost).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.fax).HasMaxLength(20);

                entity.Property(e => e.firstName).HasMaxLength(50);

                entity.Property(e => e.govID).HasMaxLength(64);

                entity.Property(e => e.homeBlock).HasMaxLength(100);

                entity.Property(e => e.homeCity).HasMaxLength(100);

                entity.Property(e => e.homeCountr).HasMaxLength(3);

                entity.Property(e => e.homeCounty).HasMaxLength(100);

                entity.Property(e => e.homeState).HasMaxLength(3);

                entity.Property(e => e.homeStreet).HasMaxLength(100);

                entity.Property(e => e.homeTel).HasMaxLength(20);

                entity.Property(e => e.homeZip).HasMaxLength(20);

                entity.Property(e => e.jobTitle).HasMaxLength(20);

                entity.Property(e => e.lastName).HasMaxLength(50);

                entity.Property(e => e.martStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('S')");

                entity.Property(e => e.middleName).HasMaxLength(50);

                entity.Property(e => e.mobile).HasMaxLength(20);

                entity.Property(e => e.officeExt).HasMaxLength(20);

                entity.Property(e => e.officeTel).HasMaxLength(20);

                entity.Property(e => e.pager).HasMaxLength(20);

                entity.Property(e => e.passportEx).HasColumnType("datetime");

                entity.Property(e => e.passportNo).HasMaxLength(64);

                entity.Property(e => e.picture).HasMaxLength(200);

                entity.Property(e => e.remark).HasColumnType("ntext");

                entity.Property(e => e.salary).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.salaryCurr).HasMaxLength(3);

                entity.Property(e => e.salaryUnit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('M')");

                entity.Property(e => e.sex)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('M')");

                entity.Property(e => e.startDate).HasColumnType("datetime");

                entity.Property(e => e.termDate).HasColumnType("datetime");

                entity.Property(e => e.workBlock).HasMaxLength(100);

                entity.Property(e => e.workCity).HasMaxLength(100);

                entity.Property(e => e.workCountr).HasMaxLength(3);

                entity.Property(e => e.workCounty).HasMaxLength(100);

                entity.Property(e => e.workState).HasMaxLength(3);

                entity.Property(e => e.workStreet).HasMaxLength(100);

                entity.Property(e => e.workZip).HasMaxLength(20);
            });

            modelBuilder.Entity<OHPS>(entity =>
            {
                entity.HasKey(e => e.posID)
                    .HasName("OHPS_PRIMARY");

                entity.HasIndex(e => e.name)
                    .HasName("OHPS_NAME")
                    .IsUnique();

                entity.Property(e => e.posID).ValueGeneratedNever();

                entity.Property(e => e.LocFields)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.descriptio).HasColumnType("ntext");

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<OIDC>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("OIDC_PRIMARY");

                entity.Property(e => e.Code).HasMaxLength(2);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<OINV>(entity =>
            {
                entity.HasKey(e => e.DocEntry)
                    .HasName("OINV_PRIMARY");

                entity.HasIndex(e => e.CardCode)
                    .HasName("OINV_CUSTOMER");

                entity.HasIndex(e => e.FolSeries)
                    .HasName("OINV_FOL_SERIES");

                entity.HasIndex(e => e.OwnerCode)
                    .HasName("OINV_OWNER_CODE");

                entity.HasIndex(e => e.Series)
                    .HasName("OINV_SERIES");

                entity.HasIndex(e => new { e.DocDate, e.PIndicator })
                    .HasName("OINV_DATE_PIND");

                entity.HasIndex(e => new { e.DocStatus, e.CANCELED })
                    .HasName("OINV_DOC_STATUS");

                entity.HasIndex(e => new { e.ESeries, e.EDocNum })
                    .HasName("OINV_ESERIES");

                entity.HasIndex(e => new { e.FatherCard, e.FatherType })
                    .HasName("OINV_FTHR_CARD");

                entity.HasIndex(e => new { e.NumAtCard, e.CardCode })
                    .HasName("OINV_AT_CARD");

                entity.HasIndex(e => new { e.InvntSttus, e.CANCELED, e.isIns })
                    .HasName("OINV_STS_CNCL");

                entity.HasIndex(e => new { e.DocNum, e.Instance, e.Segment, e.DocSubType, e.PIndicator })
                    .HasName("OINV_NUM");

                entity.Property(e => e.DocEntry).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(254);

                entity.Property(e => e.Address2).HasMaxLength(254);

                entity.Property(e => e.AgentCode).HasMaxLength(32);

                entity.Property(e => e.AltBaseTyp).HasDefaultValueSql("((-1))");

                entity.Property(e => e.AqcsTax).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.AqcsTaxFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.AqcsTaxSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.AssetDate).HasColumnType("datetime");

                entity.Property(e => e.AtDocType).HasMaxLength(2);

                entity.Property(e => e.Attachment).HasColumnType("ntext");

                entity.Property(e => e.AuthCode).HasMaxLength(250);

                entity.Property(e => e.AutoCrtFlw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BPChCode).HasMaxLength(15);

                entity.Property(e => e.BPLName).HasMaxLength(100);

                entity.Property(e => e.BPNameOW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BankCode).HasMaxLength(30);

                entity.Property(e => e.BaseAmnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseAmntFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseAmntSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseDisc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseDiscFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseDiscPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseDiscSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseType).HasDefaultValueSql("((-1))");

                entity.Property(e => e.BaseVtAt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseVtAtFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseVtAtSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BillToOW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BlkCredMmo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BlockDunn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BnkAccount).HasMaxLength(50);

                entity.Property(e => e.BnkBranch).HasMaxLength(50);

                entity.Property(e => e.BnkCntry).HasMaxLength(3);

                entity.Property(e => e.BoeReserev)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Box1099).HasMaxLength(20);

                entity.Property(e => e.BuildDesc).HasMaxLength(50);

                entity.Property(e => e.CANCELED)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CEECFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CancelDate).HasColumnType("datetime");

                entity.Property(e => e.CardCode).HasMaxLength(15);

                entity.Property(e => e.CardName).HasMaxLength(100);

                entity.Property(e => e.CashDiscFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.CashDiscPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.CashDiscSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.CashDiscnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.CdcOffset).HasDefaultValueSql("((0))");

                entity.Property(e => e.CertNum).HasMaxLength(31);

                entity.Property(e => e.CertifNum).HasMaxLength(50);

                entity.Property(e => e.CheckDigit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ClosingOpt).HasDefaultValueSql("((1))");

                entity.Property(e => e.ClsDate).HasColumnType("datetime");

                entity.Property(e => e.CntrlBnk).HasMaxLength(15);

                entity.Property(e => e.Comments).HasMaxLength(254);

                entity.Property(e => e.Confirmed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.CopyNumber).HasDefaultValueSql("((0))");

                entity.Property(e => e.CorrExt).HasMaxLength(25);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateTran)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CtlAccount).HasMaxLength(15);

                entity.Property(e => e.CurSource)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('C')");

                entity.Property(e => e.DataSource)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DateReport).HasColumnType("datetime");

                entity.Property(e => e.DeferrTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DiscPrcnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DiscSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DiscSumFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DiscSumSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DmpTransID).HasMaxLength(20);

                entity.Property(e => e.DocCur).HasMaxLength(3);

                entity.Property(e => e.DocDate).HasColumnType("datetime");

                entity.Property(e => e.DocDlvry)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DocDueDate).HasColumnType("datetime");

                entity.Property(e => e.DocManClsd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DocRate).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DocStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('O')");

                entity.Property(e => e.DocSubType)
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('--')");

                entity.Property(e => e.DocTaxID).HasMaxLength(32);

                entity.Property(e => e.DocTotal).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DocTotalFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DocTotalSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DocType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('I')");

                entity.Property(e => e.DpmAmnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAmntFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAmntSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAppVat).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAppVatF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAppVatS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAppl).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmApplFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmApplSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAsDscnt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DpmDrawn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DpmPrcnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('O')");

                entity.Property(e => e.DpmVat).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmVatFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmVatSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DutyStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.EComerGSTN).HasMaxLength(15);

                entity.Property(e => e.ECommerBP).HasMaxLength(15);

                entity.Property(e => e.EDocCancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.EDocCntnt).HasColumnType("ntext");

                entity.Property(e => e.EDocErrCod).HasMaxLength(50);

                entity.Property(e => e.EDocErrMsg).HasColumnType("ntext");

                entity.Property(e => e.EDocGenTyp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.EDocNum).HasMaxLength(50);

                entity.Property(e => e.EDocPrefix).HasMaxLength(10);

                entity.Property(e => e.EDocProces)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('C')");

                entity.Property(e => e.EDocStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('C')");

                entity.Property(e => e.EDocTest)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ElCoMsg).HasMaxLength(254);

                entity.Property(e => e.ElCoStatus).HasMaxLength(10);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.EndDlvDate).HasColumnType("datetime");

                entity.Property(e => e.EnvTypeNFe).HasDefaultValueSql("((-1))");

                entity.Property(e => e.EquVatSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EquVatSumF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EquVatSumS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExcDocDate).HasColumnType("datetime");

                entity.Property(e => e.ExcRefDate).HasColumnType("datetime");

                entity.Property(e => e.ExcRmvTime).HasMaxLength(8);

                entity.Property(e => e.Excised)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('O')");

                entity.Property(e => e.ExclTaxRep)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ExepAmnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExepAmntFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExepAmntSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpAnFrgn).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpAnSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpAnSys).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpAppl).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpApplFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpApplSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Exported)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ExptVAt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExptVAtFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExptVAtSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FatherCard).HasMaxLength(15);

                entity.Property(e => e.FatherType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('P')");

                entity.Property(e => e.Filler).HasMaxLength(8);

                entity.Property(e => e.FiscDocNum).HasMaxLength(100);

                entity.Property(e => e.Flags).HasDefaultValueSql("((0))");

                entity.Property(e => e.FlwRefDate).HasColumnType("datetime");

                entity.Property(e => e.FlwRefNum).HasMaxLength(100);

                entity.Property(e => e.FoCFrght).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FoCFrghtFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FoCFrghtSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FoCTax).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FoCTaxFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FoCTaxSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FolioPref).HasMaxLength(4);

                entity.Property(e => e.Footer).HasColumnType("ntext");

                entity.Property(e => e.FreeChrg).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FreeChrgFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FreeChrgSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FrmBpDate).HasColumnType("datetime");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.GSTTranTyp).HasMaxLength(2);

                entity.Property(e => e.GTSRlvnt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.GrosProfFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrosProfSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrosProfit).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrossBase).HasDefaultValueSql("((0))");

                entity.Property(e => e.Handwrtten)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Header).HasColumnType("ntext");

                entity.Property(e => e.ISRCodLine).HasMaxLength(53);

                entity.Property(e => e.IgnRelDoc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Indicator).HasMaxLength(2);

                entity.Property(e => e.Installmnt).HasDefaultValueSql("((1))");

                entity.Property(e => e.Instance).HasDefaultValueSql("((0))");

                entity.Property(e => e.InsurOp347)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.InterimTyp).HasDefaultValueSql("((0))");

                entity.Property(e => e.InvntDirec)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('X')");

                entity.Property(e => e.InvntSttus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('O')");

                entity.Property(e => e.IsAlt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsICT)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsPaytoBnk)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IsReuseNFN)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsReuseNum)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.JrnlMemo).HasMaxLength(50);

                entity.Property(e => e.KVVATCode).HasColumnType("ntext");

                entity.Property(e => e.LYPmtAt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LYPmtAtFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LYPmtAtSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LastPmnTyp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Letter)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LetterNum).HasMaxLength(20);

                entity.Property(e => e.LicTradNum).HasMaxLength(32);

                entity.Property(e => e.LogInstanc).HasDefaultValueSql("((0))");

                entity.Property(e => e.MInvDate).HasColumnType("datetime");

                entity.Property(e => e.MYFtype).HasMaxLength(2);

                entity.Property(e => e.ManualNum).HasMaxLength(20);

                entity.Property(e => e.Max1099).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.MaxDscn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Model)
                    .HasMaxLength(6)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NTSApprNo).HasMaxLength(50);

                entity.Property(e => e.NTSApprov)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.NTSeTaxNo).HasMaxLength(50);

                entity.Property(e => e.NbSbAmntFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NbSbVAtFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NetProc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.NfePrntFo).HasDefaultValueSql("((0))");

                entity.Property(e => e.NfeValue).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NnSbAmnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NnSbAmntSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NnSbVAt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NnSbVAtSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Notify)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NumAtCard).HasMaxLength(100);

                entity.Property(e => e.ObjType)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('13')");

                entity.Property(e => e.OnlineQuo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.OpenForLaC)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.Ordered)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.OriginType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('M')");

                entity.Property(e => e.PIndicator)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.POSEqNum).HasMaxLength(20);

                entity.Property(e => e.POSManufSN).HasMaxLength(20);

                entity.Property(e => e.PQTGrpHW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PTICode).HasMaxLength(5);

                entity.Property(e => e.PaidDpm).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidDpmF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidDpmS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidSumFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidSumSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidSys).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidToDate).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PartSupply)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.PayBlock)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PayDuMonth)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PayToCode).HasMaxLength(50);

                entity.Property(e => e.PaymentRef).HasMaxLength(27);

                entity.Property(e => e.PermitNo).HasMaxLength(20);

                entity.Property(e => e.PeyMethod).HasMaxLength(15);

                entity.Property(e => e.Pick)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PickRmrk).HasMaxLength(254);

                entity.Property(e => e.PickStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PoDropPrss)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PoPrss)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Posted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.PrintSEPA)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Printed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Project).HasMaxLength(20);

                entity.Property(e => e.Ref1).HasMaxLength(11);

                entity.Property(e => e.Ref2).HasMaxLength(11);

                entity.Property(e => e.RelatedTyp).HasDefaultValueSql("((-1))");

                entity.Property(e => e.ReopManCls)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ReopOriDoc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RepSection).HasMaxLength(3);

                entity.Property(e => e.ReqDate).HasColumnType("datetime");

                entity.Property(e => e.ReqName).HasMaxLength(155);

                entity.Property(e => e.ReqType).HasDefaultValueSql("((12))");

                entity.Property(e => e.Requester).HasMaxLength(25);

                entity.Property(e => e.Reserve)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ResidenNum)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.RetInvoice)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RevCreRefD).HasColumnType("datetime");

                entity.Property(e => e.RevCreRefN).HasMaxLength(100);

                entity.Property(e => e.RevRefDate).HasColumnType("datetime");

                entity.Property(e => e.RevRefNo).HasMaxLength(100);

                entity.Property(e => e.Revision)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RevisionPo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RoundDif).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RoundDifFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RoundDifSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Rounding)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SSIExmpt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Segment).HasDefaultValueSql("((0))");

                entity.Property(e => e.SeriesStr).HasMaxLength(3);

                entity.Property(e => e.ShipToCode).HasMaxLength(50);

                entity.Property(e => e.ShipToOW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ShowSCN)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SignDigest).HasColumnType("ntext");

                entity.Property(e => e.SignMsg).HasColumnType("ntext");

                entity.Property(e => e.SlpCode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.SpecDate).HasColumnType("datetime");

                entity.Property(e => e.SplitTax).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SplitTaxFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SplitTaxSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SrvGpPrcnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SrvTaxRule)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.StDlvDate).HasColumnType("datetime");

                entity.Property(e => e.StampNum).HasMaxLength(16);

                entity.Property(e => e.SubStr).HasMaxLength(3);

                entity.Property(e => e.SumAbsId).HasDefaultValueSql("((-1))");

                entity.Property(e => e.SumRptDate).HasColumnType("datetime");

                entity.Property(e => e.SummryType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SupplCode).HasMaxLength(254);

                entity.Property(e => e.Supplier).HasMaxLength(15);

                entity.Property(e => e.SysRate).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxDate).HasColumnType("datetime");

                entity.Property(e => e.TaxInvNo).HasMaxLength(100);

                entity.Property(e => e.TaxOnExAp).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxOnExApF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxOnExApS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxOnExp).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxOnExpFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxOnExpSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ToBinCode).HasMaxLength(228);

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.ToWhsCode).HasMaxLength(8);

                entity.Property(e => e.TotalExpFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TotalExpSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TotalExpns).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TrackNo).HasMaxLength(30);

                entity.Property(e => e.Transfered)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.TrnspCode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.TxInvRptDt).HasColumnType("datetime");

                entity.Property(e => e.TxInvRptNo).HasMaxLength(10);

                entity.Property(e => e.UpdCardBal)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.UpdInvnt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UseCorrVat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.UseShpdGd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.VATFirst)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.VATRegNum).HasMaxLength(32);

                entity.Property(e => e.VatDate).HasColumnType("datetime");

                entity.Property(e => e.VatJENum).HasDefaultValueSql("((-1))");

                entity.Property(e => e.VatPaid).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatPaidFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatPaidSys).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatPercent).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatSumFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatSumSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VclPlate).HasMaxLength(20);

                entity.Property(e => e.VersionNum).HasMaxLength(11);

                entity.Property(e => e.Volume).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTApplied).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTAppliedF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTAppliedS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTDetails).HasMaxLength(100);

                entity.Property(e => e.WTSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTSumFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTSumSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WddStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('-')");

                entity.Property(e => e.Weight).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.draftKey).HasDefaultValueSql("((-1))");

                entity.Property(e => e.isCrin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.isIns)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.selfInv)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.submitted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");
            });

            modelBuilder.Entity<OITB>(entity =>
            {
                entity.HasKey(e => e.ItmsGrpCod)
                    .HasName("OITB_PRIMARY");

                entity.HasIndex(e => e.ItmsGrpNam)
                    .HasName("OITB_GROUP_NAME")
                    .IsUnique();

                entity.Property(e => e.ItmsGrpCod).ValueGeneratedNever();

                entity.Property(e => e.APCMAct).HasMaxLength(15);

                entity.Property(e => e.APCMEUAct).HasMaxLength(15);

                entity.Property(e => e.APCMFrnAct).HasMaxLength(15);

                entity.Property(e => e.ARCMAct).HasMaxLength(15);

                entity.Property(e => e.ARCMEUAct).HasMaxLength(15);

                entity.Property(e => e.ARCMExpAct).HasMaxLength(15);

                entity.Property(e => e.ARCMFrnAct).HasMaxLength(15);

                entity.Property(e => e.Alert)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BalInvntAc).HasMaxLength(15);

                entity.Property(e => e.BalanceAcc).HasMaxLength(15);

                entity.Property(e => e.CompoWH)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('B')");

                entity.Property(e => e.CostRvlAct).HasMaxLength(15);

                entity.Property(e => e.CstOffsAct).HasMaxLength(15);

                entity.Property(e => e.DataSource)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DecreasAc).HasMaxLength(15);

                entity.Property(e => e.DecresGlAc).HasMaxLength(15);

                entity.Property(e => e.EUExpensAc).HasMaxLength(15);

                entity.Property(e => e.EURevenuAc).HasMaxLength(15);

                entity.Property(e => e.ExchangeAc).HasMaxLength(15);

                entity.Property(e => e.ExmptIncom).HasMaxLength(15);

                entity.Property(e => e.ExpClrAct).HasMaxLength(15);

                entity.Property(e => e.ExpOfstAct).HasMaxLength(15);

                entity.Property(e => e.ExpensesAc).HasMaxLength(15);

                entity.Property(e => e.FrExpensAc).HasMaxLength(15);

                entity.Property(e => e.FrRevenuAc).HasMaxLength(15);

                entity.Property(e => e.FreeChrgPU).HasMaxLength(15);

                entity.Property(e => e.FreeChrgSA).HasMaxLength(15);

                entity.Property(e => e.ISvcCode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.IncreasAc).HasMaxLength(15);

                entity.Property(e => e.IncresGlAc).HasMaxLength(15);

                entity.Property(e => e.InvntSys)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ItemClass)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('2')");

                entity.Property(e => e.ItmsGrpNam)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Locked)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.MatGrp).HasDefaultValueSql("((-1))");

                entity.Property(e => e.MatType)
                    .HasMaxLength(3)
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.MinOrdrQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NCMCode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.NegStckAct).HasMaxLength(15);

                entity.Property(e => e.OSvcCode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.Object)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('52')");

                entity.Property(e => e.OrdrMulti).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PAReturnAc).HasMaxLength(15);

                entity.Property(e => e.PlaningSys)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PrcrmntMtd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('B')");

                entity.Property(e => e.PriceDifAc).HasMaxLength(15);

                entity.Property(e => e.ProductSrc)
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PurBalAct).HasMaxLength(15);

                entity.Property(e => e.PurchOfsAc).HasMaxLength(15);

                entity.Property(e => e.PurchaseAc).HasMaxLength(15);

                entity.Property(e => e.ReturnAc).HasMaxLength(15);

                entity.Property(e => e.RevRetAct).HasMaxLength(15);

                entity.Property(e => e.RevenuesAc).HasMaxLength(15);

                entity.Property(e => e.RuleCode).HasMaxLength(2);

                entity.Property(e => e.SaleCostAc).HasMaxLength(15);

                entity.Property(e => e.ServiceGrp).HasDefaultValueSql("((-1))");

                entity.Property(e => e.ShpdGdsAct).HasMaxLength(15);

                entity.Property(e => e.StkInTnAct).HasMaxLength(15);

                entity.Property(e => e.StkOffsAct).HasMaxLength(15);

                entity.Property(e => e.StockOffst).HasMaxLength(15);

                entity.Property(e => e.StokRvlAct).HasMaxLength(15);

                entity.Property(e => e.TransferAc).HasMaxLength(15);

                entity.Property(e => e.VarianceAc).HasMaxLength(15);

                entity.Property(e => e.VatRevAct).HasMaxLength(15);

                entity.Property(e => e.WhICenAct).HasMaxLength(15);

                entity.Property(e => e.WhOCenAct).HasMaxLength(15);

                entity.Property(e => e.WipAcct).HasMaxLength(15);

                entity.Property(e => e.WipOffset).HasMaxLength(15);

                entity.Property(e => e.WipVarAcct).HasMaxLength(15);

                entity.Property(e => e.createDate).HasColumnType("datetime");

                entity.Property(e => e.updateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<OITM>(entity =>
            {
                entity.HasKey(e => e.ItemCode)
                    .HasName("OITM_PRIMARY");

                entity.HasIndex(e => e.CommisGrp)
                    .HasName("OITM_COM_GROUP");

                entity.HasIndex(e => e.InvntItem)
                    .HasName("OITM_INVENTORY");

                entity.HasIndex(e => e.ItemName)
                    .HasName("OITM_ITEM_NAME");

                entity.HasIndex(e => e.PrchseItem)
                    .HasName("OITM_PURCHASE");

                entity.HasIndex(e => e.SellItem)
                    .HasName("OITM_SALE");

                entity.HasIndex(e => e.TreeType)
                    .HasName("OITM_TREE_TYPE");

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.AcqDate).HasColumnType("datetime");

                entity.Property(e => e.AssblValue).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.AssetAmnt1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.AssetAmnt2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.AssetClass).HasMaxLength(20);

                entity.Property(e => e.AssetGroup).HasMaxLength(15);

                entity.Property(e => e.AssetItem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.AssetRmk1).HasMaxLength(100);

                entity.Property(e => e.AssetRmk2).HasMaxLength(100);

                entity.Property(e => e.AssetSerNo).HasMaxLength(32);

                entity.Property(e => e.AsstStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Attachment).HasColumnType("ntext");

                entity.Property(e => e.AvgPrice).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BHeight1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BHeight2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BLength1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BVolume).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BWeight1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BWeight2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BWidth1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BWidth2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseUnit).HasMaxLength(20);

                entity.Property(e => e.BeverGrpC).HasMaxLength(2);

                entity.Property(e => e.BeverTM).HasDefaultValueSql("((-1))");

                entity.Property(e => e.BeverTblC).HasMaxLength(2);

                entity.Property(e => e.Blength2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BlncTrnsfr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BlockOut)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.BuyUnitMsr).HasMaxLength(100);

                entity.Property(e => e.ByWh)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Canceled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CapDate).HasColumnType("datetime");

                entity.Property(e => e.CardCode).HasMaxLength(15);

                entity.Property(e => e.Cession)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ChapterID).HasDefaultValueSql("((-1))");

                entity.Property(e => e.CntUnitMsr).HasMaxLength(100);

                entity.Property(e => e.CodeBars).HasMaxLength(254);

                entity.Property(e => e.CommisGrp).HasDefaultValueSql("((0))");

                entity.Property(e => e.CommisPcnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.CommisSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.CompoWH)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('B')");

                entity.Property(e => e.Consig).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Counted).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.CountryOrg).HasMaxLength(3);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CstGrpCode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.CustomPer).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DNFEntry).HasDefaultValueSql("((-1))");

                entity.Property(e => e.DataSource)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DeacAftUL)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DeprGroup).HasMaxLength(15);

                entity.Property(e => e.DfltWH).HasMaxLength(8);

                entity.Property(e => e.ECExpAcc).HasMaxLength(15);

                entity.Property(e => e.ECInAcct).HasMaxLength(15);

                entity.Property(e => e.EnAstSeri)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.EvalSystem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Excisable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ExitCur).HasMaxLength(3);

                entity.Property(e => e.ExitPrice).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExitWH).HasMaxLength(8);

                entity.Property(e => e.ExmptIncom).HasMaxLength(15);

                entity.Property(e => e.ExpensAcct).HasMaxLength(15);

                entity.Property(e => e.ExportCode).HasMaxLength(20);

                entity.Property(e => e.FREE)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.FREE1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FirmCode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.FixCurrCms).HasMaxLength(3);

                entity.Property(e => e.FrgnExpAcc).HasMaxLength(15);

                entity.Property(e => e.FrgnInAcct).HasMaxLength(15);

                entity.Property(e => e.FrgnName).HasMaxLength(100);

                entity.Property(e => e.FrozenComm).HasMaxLength(30);

                entity.Property(e => e.FuelCode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.GLMethod)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('W')");

                entity.Property(e => e.GLPickMeth)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.GSTRelevnt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.GstTaxCtg)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('R')");

                entity.Property(e => e.ISvcCode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.IWeight1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.IWeight2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.InCostRoll)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.IncomeAcct).HasMaxLength(15);

                entity.Property(e => e.IndirctTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.InventryNo).HasMaxLength(12);

                entity.Property(e => e.InvntItem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.InvntryUom).HasMaxLength(100);

                entity.Property(e => e.IsCommited).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.IssueMthd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ItemClass)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('2')");

                entity.Property(e => e.ItemName).HasMaxLength(100);

                entity.Property(e => e.ItemType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('I')");

                entity.Property(e => e.ItmsGrpCod).HasDefaultValueSql("((100))");

                entity.Property(e => e.LastPurCur).HasMaxLength(3);

                entity.Property(e => e.LastPurDat).HasColumnType("datetime");

                entity.Property(e => e.LastPurPrc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LinkRsc).HasMaxLength(50);

                entity.Property(e => e.LogInstanc).HasDefaultValueSql("((0))");

                entity.Property(e => e.LstEvlDate).HasColumnType("datetime");

                entity.Property(e => e.LstEvlPric).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LstSalDate).HasColumnType("datetime");

                entity.Property(e => e.ManBtchNum)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ManOutOnly)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ManSerNum)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.MatGrp).HasDefaultValueSql("((-1))");

                entity.Property(e => e.MatType)
                    .HasMaxLength(3)
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.MaxLevel).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.MgrByQty)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.MinLevel).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.MinOrdrQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.MngMethod)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('R')");

                entity.Property(e => e.NCMCode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.NoDiscount)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.NotifyASN).HasMaxLength(40);

                entity.Property(e => e.NumInBuy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NumInCnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NumInSale).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OSvcCode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.ObjType)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('4')");

                entity.Property(e => e.OnHand).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OnHldPert).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OnOrder).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OneBOneRec)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.OpenBlnc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OrdrMulti).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Phantom)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PicturName).HasMaxLength(200);

                entity.Property(e => e.PlaningSys)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PrchseItem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.PrcrmntMtd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('B')");

                entity.Property(e => e.PrdStdCst).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PricingPrc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ProAssNum).HasMaxLength(20);

                entity.Property(e => e.ProductSrc)
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PurFactor1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PurFactor2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PurFactor3).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PurFactor4).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PurFormula).HasMaxLength(40);

                entity.Property(e => e.PurPackMsr).HasMaxLength(30);

                entity.Property(e => e.PurPackUn).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.QryGroup1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup10)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup11)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup12)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup13)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup14)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup15)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup16)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup17)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup18)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup19)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup20)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup21)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup22)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup23)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup24)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup25)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup26)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup27)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup28)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup29)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup3)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup30)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup31)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup32)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup33)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup34)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup35)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup36)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup37)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup38)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup39)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup4)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup40)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup41)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup42)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup43)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup44)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup45)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup46)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup47)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup48)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup49)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup5)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup50)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup51)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup52)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup53)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup54)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup55)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup56)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup57)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup58)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup59)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup6)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup60)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup61)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup62)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup63)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup64)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup7)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup8)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QryGroup9)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.QueryGroup).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReorderPnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ReorderQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RetDate).HasColumnType("datetime");

                entity.Property(e => e.RetilrTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RuleCode).HasMaxLength(2);

                entity.Property(e => e.SACEntry).HasDefaultValueSql("((-1))");

                entity.Property(e => e.SHeight1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SHeight2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SLength1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SVolume).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SWW).HasMaxLength(16);

                entity.Property(e => e.SWeight1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SWeight2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SWidth1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SWidth2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SalFactor1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SalFactor2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SalFactor3).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SalFactor4).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SalFormula).HasMaxLength(40);

                entity.Property(e => e.SalPackMsr).HasMaxLength(30);

                entity.Property(e => e.SalPackUn).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SalUnitMsr).HasMaxLength(100);

                entity.Property(e => e.ScsCode).HasMaxLength(10);

                entity.Property(e => e.SellItem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.SerialNum).HasMaxLength(17);

                entity.Property(e => e.ServiceCtg).HasDefaultValueSql("((-1))");

                entity.Property(e => e.ServiceGrp).HasDefaultValueSql("((-1))");

                entity.Property(e => e.Slength2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SouVirAsst).HasMaxLength(50);

                entity.Property(e => e.SpProdType).HasMaxLength(2);

                entity.Property(e => e.SpcialDisc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Spec).HasMaxLength(30);

                entity.Property(e => e.StatAsset)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.StockValue).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SuppCatNum).HasMaxLength(50);

                entity.Property(e => e.TaxCodeAP).HasMaxLength(8);

                entity.Property(e => e.TaxCodeAR).HasMaxLength(8);

                entity.Property(e => e.TaxCtg).HasMaxLength(4);

                entity.Property(e => e.TaxType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.TrackSales)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Transfered)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.TreeQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TreeType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserText).HasColumnType("ntext");

                entity.Property(e => e.VATLiable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.ValidComm).HasMaxLength(30);

                entity.Property(e => e.VatGourpSa).HasMaxLength(8);

                entity.Property(e => e.VatGroupPu).HasMaxLength(8);

                entity.Property(e => e.VirtAstItm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.WTLiable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.WarrntTmpl).HasMaxLength(20);

                entity.Property(e => e.WasCounted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.WholSlsTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.frozenFor)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.frozenFrom).HasColumnType("datetime");

                entity.Property(e => e.frozenTo).HasColumnType("datetime");

                entity.Property(e => e.onHldLimt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.validFor)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.validFrom).HasColumnType("datetime");

                entity.Property(e => e.validTo).HasColumnType("datetime");
            });

            modelBuilder.Entity<OJDT>(entity =>
            {
                entity.HasKey(e => e.TransId)
                    .HasName("OJDT_PRIMARY");

                entity.HasIndex(e => e.RefDate)
                    .HasName("OJDT_REFDATE");

                entity.HasIndex(e => e.StornoToTr)
                    .HasName("OJDT_STORNO_TRA");

                entity.HasIndex(e => new { e.Series, e.Number })
                    .HasName("OJDT_SERIES")
                    .IsUnique();

                entity.HasIndex(e => new { e.StornoDate, e.AutoStorno })
                    .HasName("OJDT_STORNO");

                entity.HasIndex(e => new { e.TransType, e.CreatedBy })
                    .HasName("OJDT_TRANS_TYPE");

                entity.Property(e => e.TransId).ValueGeneratedNever();

                entity.Property(e => e.AdjTran)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Approver).HasMaxLength(155);

                entity.Property(e => e.AttNum).HasDefaultValueSql("((0))");

                entity.Property(e => e.AutoStorno)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.AutoVAT)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.AutoWT)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BaseAmnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseAmntFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseAmntSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseRef).HasMaxLength(11);

                entity.Property(e => e.BaseVtAt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseVtAtFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseVtAtSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BlockDunn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BtfStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('O')");

                entity.Property(e => e.CertifNum).HasMaxLength(50);

                entity.Property(e => e.Corisptivi)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Creator).HasMaxLength(155);

                entity.Property(e => e.DataSource)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DeferedTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DocType).HasMaxLength(60);

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.ECDPosTyp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ExclTaxRep)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.FcTotal).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FolioPref).HasMaxLength(4);

                entity.Property(e => e.GenRegNo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Indicator).HasMaxLength(2);

                entity.Property(e => e.Letter)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LocTotal).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LogInstanc).HasDefaultValueSql("((0))");

                entity.Property(e => e.Memo).HasMaxLength(50);

                entity.Property(e => e.ObjType)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('30')");

                entity.Property(e => e.OperatCode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OrignCurr).HasMaxLength(3);

                entity.Property(e => e.PCAddition)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PTICode).HasMaxLength(5);

                entity.Property(e => e.Printed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PrlLinked)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Project).HasMaxLength(20);

                entity.Property(e => e.Ref1).HasMaxLength(100);

                entity.Property(e => e.Ref2).HasMaxLength(100);

                entity.Property(e => e.Ref3).HasMaxLength(27);

                entity.Property(e => e.RefDate).HasColumnType("datetime");

                entity.Property(e => e.RefndRprt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RepSection).HasMaxLength(3);

                entity.Property(e => e.Report347)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ReportEU)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ResidenNum)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.RevSource)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RptMonth).HasColumnType("datetime");

                entity.Property(e => e.RptPeriod).HasMaxLength(5);

                entity.Property(e => e.SSIExmpt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SeriesStr).HasMaxLength(3);

                entity.Property(e => e.SignDigest).HasColumnType("ntext");

                entity.Property(e => e.SignMsg).HasColumnType("ntext");

                entity.Property(e => e.StampTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.StornoDate).HasColumnType("datetime");

                entity.Property(e => e.SubStr).HasMaxLength(3);

                entity.Property(e => e.SupplCode).HasMaxLength(254);

                entity.Property(e => e.SysTotal).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxDate).HasColumnType("datetime");

                entity.Property(e => e.TransCode).HasMaxLength(4);

                entity.Property(e => e.TransCurr).HasMaxLength(3);

                entity.Property(e => e.TransRate).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TransType)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('-1')");

                entity.Property(e => e.U_B1SYS_WHT)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('E')");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.VatDate).HasColumnType("datetime");

                entity.Property(e => e.VersionNum).HasMaxLength(11);

                entity.Property(e => e.WTApplied).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTAppliedF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTAppliedS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTSumFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTSumSC).HasColumnType("numeric(19, 6)");
            });

            modelBuilder.Entity<OOND>(entity =>
            {
                entity.HasKey(e => e.IndCode)
                    .HasName("OOND_PRIMARY");

                entity.HasIndex(e => e.IndName)
                    .HasName("OOND_IND_NAME")
                    .IsUnique();

                entity.Property(e => e.IndCode).ValueGeneratedNever();

                entity.Property(e => e.IndDesc).HasMaxLength(30);

                entity.Property(e => e.IndName)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<OQUT>(entity =>
            {
                entity.HasKey(e => e.DocEntry)
                    .HasName("OQUT_PRIMARY");

                entity.HasIndex(e => e.CardCode)
                    .HasName("OQUT_CUSTOMER");

                entity.HasIndex(e => e.OwnerCode)
                    .HasName("OQUT_OWNER_CODE");

                entity.HasIndex(e => e.Series)
                    .HasName("OQUT_SERIES");

                entity.HasIndex(e => new { e.DocDate, e.PIndicator })
                    .HasName("OQUT_DATE_PIND");

                entity.HasIndex(e => new { e.DocStatus, e.CANCELED })
                    .HasName("OQUT_DOC_STATUS");

                entity.HasIndex(e => new { e.ESeries, e.EDocNum })
                    .HasName("OQUT_ESERIES");

                entity.HasIndex(e => new { e.FatherCard, e.FatherType })
                    .HasName("OQUT_FTHR_CARD");

                entity.HasIndex(e => new { e.NumAtCard, e.CardCode })
                    .HasName("OQUT_AT_CARD");

                entity.HasIndex(e => new { e.DocNum, e.Instance, e.Segment, e.DocSubType, e.PIndicator })
                    .HasName("OQUT_NUM")
                    .IsUnique();

                entity.Property(e => e.DocEntry).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(254);

                entity.Property(e => e.Address2).HasMaxLength(254);

                entity.Property(e => e.AgentCode).HasMaxLength(32);

                entity.Property(e => e.AltBaseTyp).HasDefaultValueSql("((-1))");

                entity.Property(e => e.AqcsTax).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.AqcsTaxFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.AqcsTaxSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.AssetDate).HasColumnType("datetime");

                entity.Property(e => e.AtDocType).HasMaxLength(2);

                entity.Property(e => e.Attachment).HasColumnType("ntext");

                entity.Property(e => e.AuthCode).HasMaxLength(250);

                entity.Property(e => e.AutoCrtFlw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BPChCode).HasMaxLength(15);

                entity.Property(e => e.BPLName).HasMaxLength(100);

                entity.Property(e => e.BPNameOW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BankCode).HasMaxLength(30);

                entity.Property(e => e.BaseAmnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseAmntFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseAmntSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseDisc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseDiscFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseDiscPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseDiscSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseType).HasDefaultValueSql("((-1))");

                entity.Property(e => e.BaseVtAt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseVtAtFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseVtAtSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BillToOW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BlkCredMmo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BlockDunn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BnkAccount).HasMaxLength(50);

                entity.Property(e => e.BnkBranch).HasMaxLength(50);

                entity.Property(e => e.BnkCntry).HasMaxLength(3);

                entity.Property(e => e.BoeReserev)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Box1099).HasMaxLength(20);

                entity.Property(e => e.BuildDesc).HasMaxLength(50);

                entity.Property(e => e.CANCELED)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CEECFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CancelDate).HasColumnType("datetime");

                entity.Property(e => e.CardCode).HasMaxLength(15);

                entity.Property(e => e.CardName).HasMaxLength(100);

                entity.Property(e => e.CashDiscFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.CashDiscPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.CashDiscSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.CashDiscnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.CdcOffset).HasDefaultValueSql("((0))");

                entity.Property(e => e.CertNum).HasMaxLength(31);

                entity.Property(e => e.CertifNum).HasMaxLength(50);

                entity.Property(e => e.CheckDigit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ClosingOpt).HasDefaultValueSql("((1))");

                entity.Property(e => e.ClsDate).HasColumnType("datetime");

                entity.Property(e => e.CntrlBnk).HasMaxLength(15);

                entity.Property(e => e.Comments).HasMaxLength(254);

                entity.Property(e => e.Confirmed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.CopyNumber).HasDefaultValueSql("((0))");

                entity.Property(e => e.CorrExt).HasMaxLength(25);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateTran)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CtlAccount).HasMaxLength(15);

                entity.Property(e => e.CurSource)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('C')");

                entity.Property(e => e.DataSource)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DateReport).HasColumnType("datetime");

                entity.Property(e => e.DeferrTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DiscPrcnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DiscSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DiscSumFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DiscSumSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DmpTransID).HasMaxLength(20);

                entity.Property(e => e.DocCur).HasMaxLength(3);

                entity.Property(e => e.DocDate).HasColumnType("datetime");

                entity.Property(e => e.DocDlvry)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DocDueDate).HasColumnType("datetime");

                entity.Property(e => e.DocManClsd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DocRate).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DocStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('O')");

                entity.Property(e => e.DocSubType)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('--')");

                entity.Property(e => e.DocTaxID).HasMaxLength(32);

                entity.Property(e => e.DocTotal).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DocTotalFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DocTotalSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DocType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('I')");

                entity.Property(e => e.DpmAmnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAmntFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAmntSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAppVat).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAppVatF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAppVatS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAppl).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmApplFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmApplSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAsDscnt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DpmDrawn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DpmPrcnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('O')");

                entity.Property(e => e.DpmVat).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmVatFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmVatSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DutyStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.EComerGSTN).HasMaxLength(15);

                entity.Property(e => e.ECommerBP).HasMaxLength(15);

                entity.Property(e => e.EDocCancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.EDocCntnt).HasColumnType("ntext");

                entity.Property(e => e.EDocErrCod).HasMaxLength(50);

                entity.Property(e => e.EDocErrMsg).HasColumnType("ntext");

                entity.Property(e => e.EDocGenTyp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.EDocNum).HasMaxLength(50);

                entity.Property(e => e.EDocPrefix).HasMaxLength(10);

                entity.Property(e => e.EDocProces)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('C')");

                entity.Property(e => e.EDocStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('C')");

                entity.Property(e => e.EDocTest)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ElCoMsg).HasMaxLength(254);

                entity.Property(e => e.ElCoStatus).HasMaxLength(10);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.EndDlvDate).HasColumnType("datetime");

                entity.Property(e => e.EnvTypeNFe).HasDefaultValueSql("((-1))");

                entity.Property(e => e.EquVatSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EquVatSumF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EquVatSumS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExcDocDate).HasColumnType("datetime");

                entity.Property(e => e.ExcRefDate).HasColumnType("datetime");

                entity.Property(e => e.ExcRmvTime).HasMaxLength(8);

                entity.Property(e => e.Excised)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('O')");

                entity.Property(e => e.ExclTaxRep)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ExepAmnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExepAmntFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExepAmntSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpAnFrgn).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpAnSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpAnSys).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpAppl).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpApplFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpApplSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Exported)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ExptVAt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExptVAtFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExptVAtSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FatherCard).HasMaxLength(15);

                entity.Property(e => e.FatherType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('P')");

                entity.Property(e => e.Filler).HasMaxLength(8);

                entity.Property(e => e.FiscDocNum).HasMaxLength(100);

                entity.Property(e => e.Flags).HasDefaultValueSql("((0))");

                entity.Property(e => e.FlwRefDate).HasColumnType("datetime");

                entity.Property(e => e.FlwRefNum).HasMaxLength(100);

                entity.Property(e => e.FoCFrght).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FoCFrghtFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FoCFrghtSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FoCTax).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FoCTaxFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FoCTaxSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FolioPref).HasMaxLength(4);

                entity.Property(e => e.Footer).HasColumnType("ntext");

                entity.Property(e => e.FreeChrg).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FreeChrgFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FreeChrgSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FrmBpDate).HasColumnType("datetime");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.GSTTranTyp).HasMaxLength(2);

                entity.Property(e => e.GTSRlvnt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.GrosProfFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrosProfSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrosProfit).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrossBase).HasDefaultValueSql("((0))");

                entity.Property(e => e.Handwrtten)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Header).HasColumnType("ntext");

                entity.Property(e => e.ISRCodLine).HasMaxLength(53);

                entity.Property(e => e.IgnRelDoc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Indicator).HasMaxLength(2);

                entity.Property(e => e.Installmnt).HasDefaultValueSql("((1))");

                entity.Property(e => e.InsurOp347)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.InterimTyp).HasDefaultValueSql("((0))");

                entity.Property(e => e.InvntDirec)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('X')");

                entity.Property(e => e.InvntSttus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('O')");

                entity.Property(e => e.IsAlt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsICT)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsPaytoBnk)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IsReuseNFN)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsReuseNum)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.JrnlMemo).HasMaxLength(50);

                entity.Property(e => e.KVVATCode).HasColumnType("ntext");

                entity.Property(e => e.LYPmtAt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LYPmtAtFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LYPmtAtSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LastPmnTyp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Letter)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LetterNum).HasMaxLength(20);

                entity.Property(e => e.LicTradNum).HasMaxLength(32);

                entity.Property(e => e.LogInstanc).HasDefaultValueSql("((0))");

                entity.Property(e => e.MInvDate).HasColumnType("datetime");

                entity.Property(e => e.MYFtype).HasMaxLength(2);

                entity.Property(e => e.ManualNum).HasMaxLength(20);

                entity.Property(e => e.Max1099).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.MaxDscn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Model)
                    .HasMaxLength(6)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NTSApprNo).HasMaxLength(50);

                entity.Property(e => e.NTSApprov)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.NTSeTaxNo).HasMaxLength(50);

                entity.Property(e => e.NbSbAmntFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NbSbVAtFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NetProc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.NfePrntFo).HasDefaultValueSql("((0))");

                entity.Property(e => e.NfeValue).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NnSbAmnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NnSbAmntSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NnSbVAt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NnSbVAtSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Notify)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NumAtCard).HasMaxLength(100);

                entity.Property(e => e.ObjType)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('23')");

                entity.Property(e => e.OnlineQuo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.OpenForLaC)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.Ordered)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.OriginType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('M')");

                entity.Property(e => e.PIndicator)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.POSEqNum).HasMaxLength(20);

                entity.Property(e => e.POSManufSN).HasMaxLength(20);

                entity.Property(e => e.PQTGrpHW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PTICode).HasMaxLength(5);

                entity.Property(e => e.PaidDpm).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidDpmF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidDpmS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidSumFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidSumSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidSys).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidToDate).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PartSupply)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.PayBlock)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PayDuMonth)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PayToCode).HasMaxLength(50);

                entity.Property(e => e.PaymentRef).HasMaxLength(27);

                entity.Property(e => e.PermitNo).HasMaxLength(20);

                entity.Property(e => e.PeyMethod).HasMaxLength(15);

                entity.Property(e => e.Pick)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PickRmrk).HasMaxLength(254);

                entity.Property(e => e.PickStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PoDropPrss)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PoPrss)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Posted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.PrintSEPA)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Printed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Project).HasMaxLength(20);

                entity.Property(e => e.Ref1).HasMaxLength(11);

                entity.Property(e => e.Ref2).HasMaxLength(11);

                entity.Property(e => e.RelatedTyp).HasDefaultValueSql("((-1))");

                entity.Property(e => e.ReopManCls)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ReopOriDoc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RepSection).HasMaxLength(3);

                entity.Property(e => e.ReqDate).HasColumnType("datetime");

                entity.Property(e => e.ReqName).HasMaxLength(155);

                entity.Property(e => e.ReqType).HasDefaultValueSql("((12))");

                entity.Property(e => e.Requester).HasMaxLength(25);

                entity.Property(e => e.Reserve)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ResidenNum)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.RetInvoice)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RevCreRefD).HasColumnType("datetime");

                entity.Property(e => e.RevCreRefN).HasMaxLength(100);

                entity.Property(e => e.RevRefDate).HasColumnType("datetime");

                entity.Property(e => e.RevRefNo).HasMaxLength(100);

                entity.Property(e => e.Revision)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RevisionPo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RoundDif).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RoundDifFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RoundDifSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Rounding)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SSIExmpt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SeriesStr).HasMaxLength(3);

                entity.Property(e => e.ShipToCode).HasMaxLength(50);

                entity.Property(e => e.ShipToOW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ShowSCN)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SignDigest).HasColumnType("ntext");

                entity.Property(e => e.SignMsg).HasColumnType("ntext");

                entity.Property(e => e.SlpCode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.SpecDate).HasColumnType("datetime");

                entity.Property(e => e.SplitTax).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SplitTaxFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SplitTaxSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SrvGpPrcnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SrvTaxRule)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.StDlvDate).HasColumnType("datetime");

                entity.Property(e => e.StampNum).HasMaxLength(16);

                entity.Property(e => e.SubStr).HasMaxLength(3);

                entity.Property(e => e.SumAbsId).HasDefaultValueSql("((-1))");

                entity.Property(e => e.SumRptDate).HasColumnType("datetime");

                entity.Property(e => e.SummryType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SupplCode).HasMaxLength(254);

                entity.Property(e => e.Supplier).HasMaxLength(15);

                entity.Property(e => e.SysRate).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxDate).HasColumnType("datetime");

                entity.Property(e => e.TaxInvNo).HasMaxLength(100);

                entity.Property(e => e.TaxOnExAp).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxOnExApF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxOnExApS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxOnExp).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxOnExpFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxOnExpSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ToBinCode).HasMaxLength(228);

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.ToWhsCode).HasMaxLength(8);

                entity.Property(e => e.TotalExpFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TotalExpSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TotalExpns).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TrackNo).HasMaxLength(30);

                entity.Property(e => e.Transfered)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.TrnspCode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.TxInvRptDt).HasColumnType("datetime");

                entity.Property(e => e.TxInvRptNo).HasMaxLength(10);

                entity.Property(e => e.UpdCardBal)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.UpdInvnt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UseCorrVat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.UseShpdGd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.VATFirst)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.VATRegNum).HasMaxLength(32);

                entity.Property(e => e.VatDate).HasColumnType("datetime");

                entity.Property(e => e.VatJENum).HasDefaultValueSql("((-1))");

                entity.Property(e => e.VatPaid).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatPaidFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatPaidSys).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatPercent).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatSumFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatSumSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VclPlate).HasMaxLength(20);

                entity.Property(e => e.VersionNum).HasMaxLength(11);

                entity.Property(e => e.Volume).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTApplied).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTAppliedF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTAppliedS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTDetails).HasMaxLength(100);

                entity.Property(e => e.WTSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTSumFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTSumSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WddStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('-')");

                entity.Property(e => e.Weight).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.draftKey).HasDefaultValueSql("((-1))");

                entity.Property(e => e.isCrin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.isIns)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.selfInv)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.submitted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");
            });

            modelBuilder.Entity<ORDR>(entity =>
            {
                entity.HasKey(e => e.DocEntry)
                    .HasName("ORDR_PRIMARY");

                entity.HasIndex(e => e.CardCode)
                    .HasName("ORDR_CUSTOMER");

                entity.HasIndex(e => e.OwnerCode)
                    .HasName("ORDR_OWNER_CODE");

                entity.HasIndex(e => e.Series)
                    .HasName("ORDR_SERIES");

                entity.HasIndex(e => new { e.DocDate, e.PIndicator })
                    .HasName("ORDR_DATE_PIND");

                entity.HasIndex(e => new { e.DocStatus, e.CANCELED })
                    .HasName("ORDR_DOC_STATUS");

                entity.HasIndex(e => new { e.ESeries, e.EDocNum })
                    .HasName("ORDR_ESERIES");

                entity.HasIndex(e => new { e.FatherCard, e.FatherType })
                    .HasName("ORDR_FTHR_CARD");

                entity.HasIndex(e => new { e.NumAtCard, e.CardCode })
                    .HasName("ORDR_AT_CARD");

                entity.HasIndex(e => new { e.DocNum, e.Instance, e.Segment, e.DocSubType, e.PIndicator })
                    .HasName("ORDR_NUM")
                    .IsUnique();

                entity.Property(e => e.DocEntry).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(254);

                entity.Property(e => e.Address2).HasMaxLength(254);

                entity.Property(e => e.AgentCode).HasMaxLength(32);

                entity.Property(e => e.AltBaseTyp).HasDefaultValueSql("((-1))");

                entity.Property(e => e.AqcsTax).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.AqcsTaxFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.AqcsTaxSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.AssetDate).HasColumnType("datetime");

                entity.Property(e => e.AtDocType).HasMaxLength(2);

                entity.Property(e => e.Attachment).HasColumnType("ntext");

                entity.Property(e => e.AuthCode).HasMaxLength(250);

                entity.Property(e => e.AutoCrtFlw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BPChCode).HasMaxLength(15);

                entity.Property(e => e.BPLName).HasMaxLength(100);

                entity.Property(e => e.BPNameOW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BankCode).HasMaxLength(30);

                entity.Property(e => e.BaseAmnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseAmntFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseAmntSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseDisc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseDiscFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseDiscPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseDiscSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseType).HasDefaultValueSql("((-1))");

                entity.Property(e => e.BaseVtAt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseVtAtFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseVtAtSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BillToOW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BlkCredMmo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BlockDunn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BnkAccount).HasMaxLength(50);

                entity.Property(e => e.BnkBranch).HasMaxLength(50);

                entity.Property(e => e.BnkCntry).HasMaxLength(3);

                entity.Property(e => e.BoeReserev)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Box1099).HasMaxLength(20);

                entity.Property(e => e.BuildDesc).HasMaxLength(50);

                entity.Property(e => e.CANCELED)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CEECFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CancelDate).HasColumnType("datetime");

                entity.Property(e => e.CardCode).HasMaxLength(15);

                entity.Property(e => e.CardName).HasMaxLength(100);

                entity.Property(e => e.CashDiscFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.CashDiscPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.CashDiscSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.CashDiscnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.CdcOffset).HasDefaultValueSql("((0))");

                entity.Property(e => e.CertNum).HasMaxLength(31);

                entity.Property(e => e.CertifNum).HasMaxLength(50);

                entity.Property(e => e.CheckDigit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ClosingOpt).HasDefaultValueSql("((1))");

                entity.Property(e => e.ClsDate).HasColumnType("datetime");

                entity.Property(e => e.CntrlBnk).HasMaxLength(15);

                entity.Property(e => e.Comments).HasMaxLength(254);

                entity.Property(e => e.Confirmed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.CopyNumber).HasDefaultValueSql("((0))");

                entity.Property(e => e.CorrExt).HasMaxLength(25);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateTran)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CtlAccount).HasMaxLength(15);

                entity.Property(e => e.CurSource)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('C')");

                entity.Property(e => e.DataSource)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DateReport).HasColumnType("datetime");

                entity.Property(e => e.DeferrTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DiscPrcnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DiscSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DiscSumFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DiscSumSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DmpTransID).HasMaxLength(20);

                entity.Property(e => e.DocCur).HasMaxLength(3);

                entity.Property(e => e.DocDate).HasColumnType("datetime");

                entity.Property(e => e.DocDlvry)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DocDueDate).HasColumnType("datetime");

                entity.Property(e => e.DocManClsd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DocRate).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DocStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('O')");

                entity.Property(e => e.DocSubType)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('--')");

                entity.Property(e => e.DocTaxID).HasMaxLength(32);

                entity.Property(e => e.DocTotal).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DocTotalFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DocTotalSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DocType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('I')");

                entity.Property(e => e.DpmAmnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAmntFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAmntSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAppVat).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAppVatF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAppVatS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAppl).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmApplFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmApplSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAsDscnt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DpmDrawn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DpmPrcnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('O')");

                entity.Property(e => e.DpmVat).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmVatFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmVatSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DutyStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.EComerGSTN).HasMaxLength(15);

                entity.Property(e => e.ECommerBP).HasMaxLength(15);

                entity.Property(e => e.EDocCancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.EDocCntnt).HasColumnType("ntext");

                entity.Property(e => e.EDocErrCod).HasMaxLength(50);

                entity.Property(e => e.EDocErrMsg).HasColumnType("ntext");

                entity.Property(e => e.EDocGenTyp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.EDocNum).HasMaxLength(50);

                entity.Property(e => e.EDocPrefix).HasMaxLength(10);

                entity.Property(e => e.EDocProces)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('C')");

                entity.Property(e => e.EDocStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('C')");

                entity.Property(e => e.EDocTest)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ElCoMsg).HasMaxLength(254);

                entity.Property(e => e.ElCoStatus).HasMaxLength(10);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.EndDlvDate).HasColumnType("datetime");

                entity.Property(e => e.EnvTypeNFe).HasDefaultValueSql("((-1))");

                entity.Property(e => e.EquVatSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EquVatSumF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EquVatSumS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExcDocDate).HasColumnType("datetime");

                entity.Property(e => e.ExcRefDate).HasColumnType("datetime");

                entity.Property(e => e.ExcRmvTime).HasMaxLength(8);

                entity.Property(e => e.Excised)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('O')");

                entity.Property(e => e.ExclTaxRep)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ExepAmnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExepAmntFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExepAmntSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpAnFrgn).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpAnSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpAnSys).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpAppl).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpApplFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpApplSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Exported)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ExptVAt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExptVAtFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExptVAtSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FatherCard).HasMaxLength(15);

                entity.Property(e => e.FatherType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('P')");

                entity.Property(e => e.Filler).HasMaxLength(8);

                entity.Property(e => e.FiscDocNum).HasMaxLength(100);

                entity.Property(e => e.Flags).HasDefaultValueSql("((0))");

                entity.Property(e => e.FlwRefDate).HasColumnType("datetime");

                entity.Property(e => e.FlwRefNum).HasMaxLength(100);

                entity.Property(e => e.FoCFrght).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FoCFrghtFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FoCFrghtSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FoCTax).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FoCTaxFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FoCTaxSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FolioPref).HasMaxLength(4);

                entity.Property(e => e.Footer).HasColumnType("ntext");

                entity.Property(e => e.FreeChrg).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FreeChrgFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FreeChrgSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FrmBpDate).HasColumnType("datetime");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.GSTTranTyp).HasMaxLength(2);

                entity.Property(e => e.GTSRlvnt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.GrosProfFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrosProfSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrosProfit).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrossBase).HasDefaultValueSql("((0))");

                entity.Property(e => e.Handwrtten)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Header).HasColumnType("ntext");

                entity.Property(e => e.ISRCodLine).HasMaxLength(53);

                entity.Property(e => e.IgnRelDoc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Indicator).HasMaxLength(2);

                entity.Property(e => e.Installmnt).HasDefaultValueSql("((1))");

                entity.Property(e => e.InsurOp347)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.InterimTyp).HasDefaultValueSql("((0))");

                entity.Property(e => e.InvntDirec)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('X')");

                entity.Property(e => e.InvntSttus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('O')");

                entity.Property(e => e.IsAlt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsICT)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsPaytoBnk)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IsReuseNFN)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsReuseNum)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.JrnlMemo).HasMaxLength(50);

                entity.Property(e => e.KVVATCode).HasColumnType("ntext");

                entity.Property(e => e.LYPmtAt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LYPmtAtFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LYPmtAtSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LastPmnTyp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Letter)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LetterNum).HasMaxLength(20);

                entity.Property(e => e.LicTradNum).HasMaxLength(32);

                entity.Property(e => e.LogInstanc).HasDefaultValueSql("((0))");

                entity.Property(e => e.MInvDate).HasColumnType("datetime");

                entity.Property(e => e.MYFtype).HasMaxLength(2);

                entity.Property(e => e.ManualNum).HasMaxLength(20);

                entity.Property(e => e.Max1099).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.MaxDscn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Model)
                    .HasMaxLength(6)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NTSApprNo).HasMaxLength(50);

                entity.Property(e => e.NTSApprov)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.NTSeTaxNo).HasMaxLength(50);

                entity.Property(e => e.NbSbAmntFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NbSbVAtFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NetProc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.NfePrntFo).HasDefaultValueSql("((0))");

                entity.Property(e => e.NfeValue).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NnSbAmnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NnSbAmntSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NnSbVAt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NnSbVAtSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Notify)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NumAtCard).HasMaxLength(100);

                entity.Property(e => e.ObjType)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('17')");

                entity.Property(e => e.OnlineQuo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.OpenForLaC)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.Ordered)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.OriginType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('M')");

                entity.Property(e => e.PIndicator)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.POSEqNum).HasMaxLength(20);

                entity.Property(e => e.POSManufSN).HasMaxLength(20);

                entity.Property(e => e.PQTGrpHW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PTICode).HasMaxLength(5);

                entity.Property(e => e.PaidDpm).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidDpmF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidDpmS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidSumFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidSumSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidSys).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidToDate).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PartSupply)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.PayBlock)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PayDuMonth)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PayToCode).HasMaxLength(50);

                entity.Property(e => e.PaymentRef).HasMaxLength(27);

                entity.Property(e => e.PermitNo).HasMaxLength(20);

                entity.Property(e => e.PeyMethod).HasMaxLength(15);

                entity.Property(e => e.Pick)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PickRmrk).HasMaxLength(254);

                entity.Property(e => e.PickStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PoDropPrss)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PoPrss)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Posted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.PrintSEPA)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Printed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Project).HasMaxLength(20);

                entity.Property(e => e.Ref1).HasMaxLength(11);

                entity.Property(e => e.Ref2).HasMaxLength(11);

                entity.Property(e => e.RelatedTyp).HasDefaultValueSql("((-1))");

                entity.Property(e => e.ReopManCls)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ReopOriDoc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RepSection).HasMaxLength(3);

                entity.Property(e => e.ReqDate).HasColumnType("datetime");

                entity.Property(e => e.ReqName).HasMaxLength(155);

                entity.Property(e => e.ReqType).HasDefaultValueSql("((12))");

                entity.Property(e => e.Requester).HasMaxLength(25);

                entity.Property(e => e.Reserve)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ResidenNum)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.RetInvoice)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RevCreRefD).HasColumnType("datetime");

                entity.Property(e => e.RevCreRefN).HasMaxLength(100);

                entity.Property(e => e.RevRefDate).HasColumnType("datetime");

                entity.Property(e => e.RevRefNo).HasMaxLength(100);

                entity.Property(e => e.Revision)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RevisionPo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RoundDif).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RoundDifFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RoundDifSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Rounding)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SSIExmpt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SeriesStr).HasMaxLength(3);

                entity.Property(e => e.ShipToCode).HasMaxLength(50);

                entity.Property(e => e.ShipToOW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ShowSCN)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SignDigest).HasColumnType("ntext");

                entity.Property(e => e.SignMsg).HasColumnType("ntext");

                entity.Property(e => e.SlpCode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.SpecDate).HasColumnType("datetime");

                entity.Property(e => e.SplitTax).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SplitTaxFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SplitTaxSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SrvGpPrcnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SrvTaxRule)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.StDlvDate).HasColumnType("datetime");

                entity.Property(e => e.StampNum).HasMaxLength(16);

                entity.Property(e => e.SubStr).HasMaxLength(3);

                entity.Property(e => e.SumAbsId).HasDefaultValueSql("((-1))");

                entity.Property(e => e.SumRptDate).HasColumnType("datetime");

                entity.Property(e => e.SummryType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SupplCode).HasMaxLength(254);

                entity.Property(e => e.Supplier).HasMaxLength(15);

                entity.Property(e => e.SysRate).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxDate).HasColumnType("datetime");

                entity.Property(e => e.TaxInvNo).HasMaxLength(100);

                entity.Property(e => e.TaxOnExAp).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxOnExApF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxOnExApS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxOnExp).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxOnExpFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxOnExpSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ToBinCode).HasMaxLength(228);

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.ToWhsCode).HasMaxLength(8);

                entity.Property(e => e.TotalExpFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TotalExpSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TotalExpns).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TrackNo).HasMaxLength(30);

                entity.Property(e => e.Transfered)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.TrnspCode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.TxInvRptDt).HasColumnType("datetime");

                entity.Property(e => e.TxInvRptNo).HasMaxLength(10);

                entity.Property(e => e.UpdCardBal)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.UpdInvnt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UseCorrVat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.UseShpdGd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.VATFirst)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.VATRegNum).HasMaxLength(32);

                entity.Property(e => e.VatDate).HasColumnType("datetime");

                entity.Property(e => e.VatJENum).HasDefaultValueSql("((-1))");

                entity.Property(e => e.VatPaid).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatPaidFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatPaidSys).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatPercent).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatSumFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatSumSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VclPlate).HasMaxLength(20);

                entity.Property(e => e.VersionNum).HasMaxLength(11);

                entity.Property(e => e.Volume).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTApplied).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTAppliedF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTAppliedS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTDetails).HasMaxLength(100);

                entity.Property(e => e.WTSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTSumFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTSumSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WddStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('-')");

                entity.Property(e => e.Weight).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.draftKey).HasDefaultValueSql("((-1))");

                entity.Property(e => e.isCrin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.isIns)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.selfInv)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.submitted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");
            });

            modelBuilder.Entity<ORIN>(entity =>
            {
                entity.HasKey(e => e.DocEntry)
                    .HasName("ORIN_PRIMARY");

                entity.HasIndex(e => e.CardCode)
                    .HasName("ORIN_CUSTOMER");

                entity.HasIndex(e => e.FolSeries)
                    .HasName("ORIN_FOL_SERIES");

                entity.HasIndex(e => e.OwnerCode)
                    .HasName("ORIN_OWNER_CODE");

                entity.HasIndex(e => e.Series)
                    .HasName("ORIN_SERIES");

                entity.HasIndex(e => new { e.DocDate, e.PIndicator })
                    .HasName("ORIN_DATE_PIND");

                entity.HasIndex(e => new { e.DocStatus, e.CANCELED })
                    .HasName("ORIN_DOC_STATUS");

                entity.HasIndex(e => new { e.ESeries, e.EDocNum })
                    .HasName("ORIN_ESERIES");

                entity.HasIndex(e => new { e.FatherCard, e.FatherType })
                    .HasName("ORIN_FTHR_CARD");

                entity.HasIndex(e => new { e.NumAtCard, e.CardCode })
                    .HasName("ORIN_AT_CARD");

                entity.HasIndex(e => new { e.DocNum, e.Instance, e.Segment, e.DocSubType, e.PIndicator })
                    .HasName("ORIN_NUM");

                entity.Property(e => e.DocEntry).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(254);

                entity.Property(e => e.Address2).HasMaxLength(254);

                entity.Property(e => e.AgentCode).HasMaxLength(32);

                entity.Property(e => e.AltBaseTyp).HasDefaultValueSql("((-1))");

                entity.Property(e => e.AqcsTax).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.AqcsTaxFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.AqcsTaxSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.AssetDate).HasColumnType("datetime");

                entity.Property(e => e.AtDocType).HasMaxLength(2);

                entity.Property(e => e.Attachment).HasColumnType("ntext");

                entity.Property(e => e.AuthCode).HasMaxLength(250);

                entity.Property(e => e.AutoCrtFlw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BPChCode).HasMaxLength(15);

                entity.Property(e => e.BPLName).HasMaxLength(100);

                entity.Property(e => e.BPNameOW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BankCode).HasMaxLength(30);

                entity.Property(e => e.BaseAmnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseAmntFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseAmntSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseDisc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseDiscFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseDiscPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseDiscSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseType).HasDefaultValueSql("((-1))");

                entity.Property(e => e.BaseVtAt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseVtAtFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseVtAtSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BillToOW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BlkCredMmo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BlockDunn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BnkAccount).HasMaxLength(50);

                entity.Property(e => e.BnkBranch).HasMaxLength(50);

                entity.Property(e => e.BnkCntry).HasMaxLength(3);

                entity.Property(e => e.BoeReserev)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Box1099).HasMaxLength(20);

                entity.Property(e => e.BuildDesc).HasMaxLength(50);

                entity.Property(e => e.CANCELED)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CEECFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CancelDate).HasColumnType("datetime");

                entity.Property(e => e.CardCode).HasMaxLength(15);

                entity.Property(e => e.CardName).HasMaxLength(100);

                entity.Property(e => e.CashDiscFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.CashDiscPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.CashDiscSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.CashDiscnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.CdcOffset).HasDefaultValueSql("((0))");

                entity.Property(e => e.CertNum).HasMaxLength(31);

                entity.Property(e => e.CertifNum).HasMaxLength(50);

                entity.Property(e => e.CheckDigit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ClosingOpt).HasDefaultValueSql("((1))");

                entity.Property(e => e.ClsDate).HasColumnType("datetime");

                entity.Property(e => e.CntrlBnk).HasMaxLength(15);

                entity.Property(e => e.Comments).HasMaxLength(254);

                entity.Property(e => e.Confirmed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.CopyNumber).HasDefaultValueSql("((0))");

                entity.Property(e => e.CorrExt).HasMaxLength(25);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateTran)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CtlAccount).HasMaxLength(15);

                entity.Property(e => e.CurSource)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('C')");

                entity.Property(e => e.DataSource)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DateReport).HasColumnType("datetime");

                entity.Property(e => e.DeferrTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DiscPrcnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DiscSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DiscSumFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DiscSumSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DmpTransID).HasMaxLength(20);

                entity.Property(e => e.DocCur).HasMaxLength(3);

                entity.Property(e => e.DocDate).HasColumnType("datetime");

                entity.Property(e => e.DocDlvry)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DocDueDate).HasColumnType("datetime");

                entity.Property(e => e.DocManClsd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DocRate).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DocStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('O')");

                entity.Property(e => e.DocSubType)
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('--')");

                entity.Property(e => e.DocTaxID).HasMaxLength(32);

                entity.Property(e => e.DocTotal).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DocTotalFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DocTotalSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DocType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('I')");

                entity.Property(e => e.DpmAmnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAmntFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAmntSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAppVat).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAppVatF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAppVatS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAppl).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmApplFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmApplSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmAsDscnt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DpmDrawn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DpmPrcnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('O')");

                entity.Property(e => e.DpmVat).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmVatFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DpmVatSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DutyStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.EComerGSTN).HasMaxLength(15);

                entity.Property(e => e.ECommerBP).HasMaxLength(15);

                entity.Property(e => e.EDocCancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.EDocCntnt).HasColumnType("ntext");

                entity.Property(e => e.EDocErrCod).HasMaxLength(50);

                entity.Property(e => e.EDocErrMsg).HasColumnType("ntext");

                entity.Property(e => e.EDocGenTyp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.EDocNum).HasMaxLength(50);

                entity.Property(e => e.EDocPrefix).HasMaxLength(10);

                entity.Property(e => e.EDocProces)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('C')");

                entity.Property(e => e.EDocStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('C')");

                entity.Property(e => e.EDocTest)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ElCoMsg).HasMaxLength(254);

                entity.Property(e => e.ElCoStatus).HasMaxLength(10);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.EndDlvDate).HasColumnType("datetime");

                entity.Property(e => e.EnvTypeNFe).HasDefaultValueSql("((-1))");

                entity.Property(e => e.EquVatSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EquVatSumF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EquVatSumS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExcDocDate).HasColumnType("datetime");

                entity.Property(e => e.ExcRefDate).HasColumnType("datetime");

                entity.Property(e => e.ExcRmvTime).HasMaxLength(8);

                entity.Property(e => e.Excised)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('O')");

                entity.Property(e => e.ExclTaxRep)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ExepAmnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExepAmntFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExepAmntSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpAnFrgn).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpAnSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpAnSys).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpAppl).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpApplFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpApplSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Exported)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ExptVAt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExptVAtFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExptVAtSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FatherCard).HasMaxLength(15);

                entity.Property(e => e.FatherType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('P')");

                entity.Property(e => e.Filler).HasMaxLength(8);

                entity.Property(e => e.FiscDocNum).HasMaxLength(100);

                entity.Property(e => e.Flags).HasDefaultValueSql("((0))");

                entity.Property(e => e.FlwRefDate).HasColumnType("datetime");

                entity.Property(e => e.FlwRefNum).HasMaxLength(100);

                entity.Property(e => e.FoCFrght).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FoCFrghtFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FoCFrghtSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FoCTax).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FoCTaxFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FoCTaxSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FolioPref).HasMaxLength(4);

                entity.Property(e => e.Footer).HasColumnType("ntext");

                entity.Property(e => e.FreeChrg).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FreeChrgFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FreeChrgSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FrmBpDate).HasColumnType("datetime");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.GSTTranTyp).HasMaxLength(2);

                entity.Property(e => e.GTSRlvnt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.GrosProfFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrosProfSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrosProfit).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrossBase).HasDefaultValueSql("((0))");

                entity.Property(e => e.Handwrtten)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Header).HasColumnType("ntext");

                entity.Property(e => e.ISRCodLine).HasMaxLength(53);

                entity.Property(e => e.IgnRelDoc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Indicator).HasMaxLength(2);

                entity.Property(e => e.Installmnt).HasDefaultValueSql("((1))");

                entity.Property(e => e.Instance).HasDefaultValueSql("((0))");

                entity.Property(e => e.InsurOp347)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.InterimTyp).HasDefaultValueSql("((0))");

                entity.Property(e => e.InvntDirec)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('X')");

                entity.Property(e => e.InvntSttus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('O')");

                entity.Property(e => e.IsAlt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsICT)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsPaytoBnk)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IsReuseNFN)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsReuseNum)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.JrnlMemo).HasMaxLength(50);

                entity.Property(e => e.KVVATCode).HasColumnType("ntext");

                entity.Property(e => e.LYPmtAt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LYPmtAtFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LYPmtAtSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LastPmnTyp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Letter)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LetterNum).HasMaxLength(20);

                entity.Property(e => e.LicTradNum).HasMaxLength(32);

                entity.Property(e => e.LogInstanc).HasDefaultValueSql("((0))");

                entity.Property(e => e.MInvDate).HasColumnType("datetime");

                entity.Property(e => e.MYFtype).HasMaxLength(2);

                entity.Property(e => e.ManualNum).HasMaxLength(20);

                entity.Property(e => e.Max1099).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.MaxDscn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Model)
                    .HasMaxLength(6)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NTSApprNo).HasMaxLength(50);

                entity.Property(e => e.NTSApprov)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.NTSeTaxNo).HasMaxLength(50);

                entity.Property(e => e.NbSbAmntFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NbSbVAtFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NetProc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.NfePrntFo).HasDefaultValueSql("((0))");

                entity.Property(e => e.NfeValue).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NnSbAmnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NnSbAmntSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NnSbVAt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NnSbVAtSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Notify)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NumAtCard).HasMaxLength(100);

                entity.Property(e => e.ObjType)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('14')");

                entity.Property(e => e.OnlineQuo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.OpenForLaC)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.Ordered)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.OriginType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('M')");

                entity.Property(e => e.PIndicator)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.POSEqNum).HasMaxLength(20);

                entity.Property(e => e.POSManufSN).HasMaxLength(20);

                entity.Property(e => e.PQTGrpHW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PTICode).HasMaxLength(5);

                entity.Property(e => e.PaidDpm).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidDpmF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidDpmS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidSumFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidSumSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidSys).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PaidToDate).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PartSupply)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.PayBlock)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PayDuMonth)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PayToCode).HasMaxLength(50);

                entity.Property(e => e.PaymentRef).HasMaxLength(27);

                entity.Property(e => e.PermitNo).HasMaxLength(20);

                entity.Property(e => e.PeyMethod).HasMaxLength(15);

                entity.Property(e => e.Pick)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PickRmrk).HasMaxLength(254);

                entity.Property(e => e.PickStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PoDropPrss)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PoPrss)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Posted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.PrintSEPA)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Printed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Project).HasMaxLength(20);

                entity.Property(e => e.Ref1).HasMaxLength(11);

                entity.Property(e => e.Ref2).HasMaxLength(11);

                entity.Property(e => e.RelatedTyp).HasDefaultValueSql("((-1))");

                entity.Property(e => e.ReopManCls)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ReopOriDoc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RepSection).HasMaxLength(3);

                entity.Property(e => e.ReqDate).HasColumnType("datetime");

                entity.Property(e => e.ReqName).HasMaxLength(155);

                entity.Property(e => e.ReqType).HasDefaultValueSql("((12))");

                entity.Property(e => e.Requester).HasMaxLength(25);

                entity.Property(e => e.Reserve)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ResidenNum)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.RetInvoice)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RevCreRefD).HasColumnType("datetime");

                entity.Property(e => e.RevCreRefN).HasMaxLength(100);

                entity.Property(e => e.RevRefDate).HasColumnType("datetime");

                entity.Property(e => e.RevRefNo).HasMaxLength(100);

                entity.Property(e => e.Revision)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RevisionPo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RoundDif).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RoundDifFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RoundDifSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Rounding)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SSIExmpt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Segment).HasDefaultValueSql("((0))");

                entity.Property(e => e.SeriesStr).HasMaxLength(3);

                entity.Property(e => e.ShipToCode).HasMaxLength(50);

                entity.Property(e => e.ShipToOW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ShowSCN)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SignDigest).HasColumnType("ntext");

                entity.Property(e => e.SignMsg).HasColumnType("ntext");

                entity.Property(e => e.SlpCode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.SpecDate).HasColumnType("datetime");

                entity.Property(e => e.SplitTax).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SplitTaxFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SplitTaxSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SrvGpPrcnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SrvTaxRule)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.StDlvDate).HasColumnType("datetime");

                entity.Property(e => e.StampNum).HasMaxLength(16);

                entity.Property(e => e.SubStr).HasMaxLength(3);

                entity.Property(e => e.SumAbsId).HasDefaultValueSql("((-1))");

                entity.Property(e => e.SumRptDate).HasColumnType("datetime");

                entity.Property(e => e.SummryType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SupplCode).HasMaxLength(254);

                entity.Property(e => e.Supplier).HasMaxLength(15);

                entity.Property(e => e.SysRate).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxDate).HasColumnType("datetime");

                entity.Property(e => e.TaxInvNo).HasMaxLength(100);

                entity.Property(e => e.TaxOnExAp).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxOnExApF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxOnExApS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxOnExp).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxOnExpFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxOnExpSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ToBinCode).HasMaxLength(228);

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.ToWhsCode).HasMaxLength(8);

                entity.Property(e => e.TotalExpFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TotalExpSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TotalExpns).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TrackNo).HasMaxLength(30);

                entity.Property(e => e.Transfered)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.TrnspCode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.TxInvRptDt).HasColumnType("datetime");

                entity.Property(e => e.TxInvRptNo).HasMaxLength(10);

                entity.Property(e => e.UpdCardBal)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.UpdInvnt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UseCorrVat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.UseShpdGd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.VATFirst)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.VATRegNum).HasMaxLength(32);

                entity.Property(e => e.VatDate).HasColumnType("datetime");

                entity.Property(e => e.VatJENum).HasDefaultValueSql("((-1))");

                entity.Property(e => e.VatPaid).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatPaidFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatPaidSys).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatPercent).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatSumFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatSumSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VclPlate).HasMaxLength(20);

                entity.Property(e => e.VersionNum).HasMaxLength(11);

                entity.Property(e => e.Volume).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTApplied).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTAppliedF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTAppliedS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTDetails).HasMaxLength(100);

                entity.Property(e => e.WTSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTSumFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WTSumSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WddStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('-')");

                entity.Property(e => e.Weight).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.draftKey).HasDefaultValueSql("((-1))");

                entity.Property(e => e.isCrin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.isIns)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.selfInv)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.submitted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");
            });

            modelBuilder.Entity<OSLP>(entity =>
            {
                entity.HasKey(e => e.SlpCode)
                    .HasName("OSLP_PRIMARY");

                entity.HasIndex(e => e.GroupCode)
                    .HasName("OSLP_COM_GROUP");

                entity.HasIndex(e => e.SlpName)
                    .HasName("OSLP_SLP_NAME")
                    .IsUnique();

                entity.Property(e => e.SlpCode).ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.Commission).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DataSource)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Fax).HasMaxLength(20);

                entity.Property(e => e.GroupCode).HasDefaultValueSql("((0))");

                entity.Property(e => e.Locked)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Memo).HasMaxLength(50);

                entity.Property(e => e.Mobil).HasMaxLength(50);

                entity.Property(e => e.SlpName)
                    .IsRequired()
                    .HasMaxLength(155);

                entity.Property(e => e.Telephone).HasMaxLength(20);
            });

            modelBuilder.Entity<OUDP>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("OUDP_PRIMARY");

                entity.HasIndex(e => e.Name)
                    .HasName("OUDP_NAME")
                    .IsUnique();

                entity.Property(e => e.Code).ValueGeneratedNever();

                entity.Property(e => e.Father).HasMaxLength(20);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Remarks).HasMaxLength(100);
            });

            modelBuilder.Entity<QUT1>(entity =>
            {
                entity.HasKey(e => new { e.DocEntry, e.LineNum })
                    .HasName("QUT1_PRIMARY");

                entity.HasIndex(e => e.AcctCode)
                    .HasName("QUT1_ACCOUNT");

                entity.HasIndex(e => e.Currency)
                    .HasName("QUT1_CURRENCY");

                entity.HasIndex(e => e.LineStatus)
                    .HasName("QUT1_STATUS");

                entity.HasIndex(e => e.OwnerCode)
                    .HasName("QUT1_OWNER_CODE");

                entity.HasIndex(e => new { e.DocEntry, e.VisOrder })
                    .HasName("QUT1_VIS_ORDER");

                entity.HasIndex(e => new { e.BaseEntry, e.BaseType, e.BaseLine })
                    .HasName("QUT1_BASE_ENTRY");

                entity.HasIndex(e => new { e.ItemCode, e.WhsCode, e.OpenQty })
                    .HasName("QUT1_ITM_WHS_OQ");

                entity.Property(e => e.AcctCode).HasMaxLength(15);

                entity.Property(e => e.ActDelDate).HasColumnType("datetime");

                entity.Property(e => e.Address).HasMaxLength(254);

                entity.Property(e => e.AllocBinC).HasMaxLength(11);

                entity.Property(e => e.AssblValue).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BackOrdr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BaseAtCard).HasMaxLength(100);

                entity.Property(e => e.BaseCard).HasMaxLength(15);

                entity.Property(e => e.BaseOpnQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BasePrice)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('E')");

                entity.Property(e => e.BaseQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseRef).HasMaxLength(16);

                entity.Property(e => e.BaseType).HasDefaultValueSql("((-1))");

                entity.Property(e => e.BlockNum).HasMaxLength(100);

                entity.Property(e => e.CEECFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('S')");

                entity.Property(e => e.CFOPCode).HasMaxLength(6);

                entity.Property(e => e.CSTCode).HasMaxLength(6);

                entity.Property(e => e.CSTfCOFINS).HasMaxLength(2);

                entity.Property(e => e.CSTfIPI).HasMaxLength(2);

                entity.Property(e => e.CSTfPIS).HasMaxLength(2);

                entity.Property(e => e.ChgAsmBoMW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CiOppLineN).HasDefaultValueSql("((-1))");

                entity.Property(e => e.CodeBars).HasMaxLength(254);

                entity.Property(e => e.CogsAcct).HasMaxLength(15);

                entity.Property(e => e.CogsOcrCo2).HasMaxLength(8);

                entity.Property(e => e.CogsOcrCo3).HasMaxLength(8);

                entity.Property(e => e.CogsOcrCo4).HasMaxLength(8);

                entity.Property(e => e.CogsOcrCo5).HasMaxLength(8);

                entity.Property(e => e.CogsOcrCod).HasMaxLength(8);

                entity.Property(e => e.Commission).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ConsumeFCT)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CountryOrg).HasMaxLength(3);

                entity.Property(e => e.CredOrigin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Currency).HasMaxLength(3);

                entity.Property(e => e.DIOTNat).HasMaxLength(3);

                entity.Property(e => e.DedVatSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DedVatSumF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DedVatSumS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DefBreak).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DeferrTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DelivrdQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DescOW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DetailsOW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DiscPrcnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DistribExp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DistribIS)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DistribSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DocDate).HasColumnType("datetime");

                entity.Property(e => e.DropShip)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Dscription).HasMaxLength(100);

                entity.Property(e => e.DstrbSumFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DstrbSumSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EnSetCost)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.EquVatPer).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EquVatSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EquVatSumF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EquVatSumS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExLineNo).HasMaxLength(10);

                entity.Property(e => e.Excisable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ExciseAmt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpOpType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ExpType).HasMaxLength(4);

                entity.Property(e => e.ExpUUID).HasMaxLength(50);

                entity.Property(e => e.Factor1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Factor2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Factor3).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Factor4).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FisrtBin).HasMaxLength(228);

                entity.Property(e => e.Flags).HasDefaultValueSql("((0))");

                entity.Property(e => e.FreeChrgBP)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FreeTxt).HasMaxLength(100);

                entity.Property(e => e.FromWhsCod).HasMaxLength(8);

                entity.Property(e => e.GPTtlBasPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GTotal).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GTotalFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GTotalSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrossBuyPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrssProfFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrssProfSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrssProfit).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Height1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Height2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.INMPrice).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ISDistrb).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ISDistrbFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ISDistrbSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ImportLog).HasMaxLength(20);

                entity.Property(e => e.Incoterms).HasDefaultValueSql("((0))");

                entity.Property(e => e.InvQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.InvQtyOnly)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.InvntSttus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('O')");

                entity.Property(e => e.IsAqcuistn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsByPrdct)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ItemType).HasDefaultValueSql("((4))");

                entity.Property(e => e.ItmTaxType).HasMaxLength(2);

                entity.Property(e => e.LegalText).HasMaxLength(254);

                entity.Property(e => e.Length1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LicTradNum).HasMaxLength(32);

                entity.Property(e => e.LinManClsd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.LinePoPrss)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.LineStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('O')");

                entity.Property(e => e.LineTotal).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LineType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('R')");

                entity.Property(e => e.LineVat).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LineVatS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LineVatlF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LineVendor).HasMaxLength(15);

                entity.Property(e => e.LnExcised)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LogInstanc).HasDefaultValueSql("((0))");

                entity.Property(e => e.LstBINMPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LstByDsFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LstByDsSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LstByDsSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.MYFtype).HasMaxLength(2);

                entity.Property(e => e.NeedQty)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.NoInvtryMv)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.NumPerMsr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NumPerMsr2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ObjType)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('23')");

                entity.Property(e => e.OcrCode).HasMaxLength(8);

                entity.Property(e => e.OcrCode2).HasMaxLength(8);

                entity.Property(e => e.OcrCode3).HasMaxLength(8);

                entity.Property(e => e.OcrCode4).HasMaxLength(8);

                entity.Property(e => e.OcrCode5).HasMaxLength(8);

                entity.Property(e => e.OpenCreQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OpenInvQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OpenQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OpenRtnQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OpenSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OpenSumFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OpenSumSys).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OrderedQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OrigItem).HasMaxLength(50);

                entity.Property(e => e.PQTReqDate).HasColumnType("datetime");

                entity.Property(e => e.PQTReqQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PackQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PartRetire)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PcDocType).HasDefaultValueSql("((-1))");

                entity.Property(e => e.PcQuantity).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PickOty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PickStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PoTrgEntry).HasMaxLength(11);

                entity.Property(e => e.PostTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.Price).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PriceAfVAT).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PriceBefDi).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PriceEdit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Project).HasMaxLength(20);

                entity.Property(e => e.QtyToShip).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Quantity).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Rate).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ReleasQtty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RetCost).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RetirAPCFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RetirAPCSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RetireAPC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RetireQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SWW).HasMaxLength(16);

                entity.Property(e => e.SerialNum).HasMaxLength(17);

                entity.Property(e => e.ShipDate).HasColumnType("datetime");

                entity.Property(e => e.ShipFromCo).HasMaxLength(50);

                entity.Property(e => e.ShipFromDe).HasMaxLength(254);

                entity.Property(e => e.ShipToCode).HasMaxLength(50);

                entity.Property(e => e.ShipToDesc).HasMaxLength(254);

                entity.Property(e => e.Shortages).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SlpCode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.SpecPrice)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.StckAppD).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckAppDFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckAppDSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckAppFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckAppSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckDstFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckDstSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckDstSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckINMPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckSumApp).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StockPrice).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StockSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StockSumFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StockSumSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StockValue).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SubCatNum).HasMaxLength(50);

                entity.Property(e => e.Surpluses).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TargetType).HasDefaultValueSql("((-1))");

                entity.Property(e => e.TaxCode).HasMaxLength(8);

                entity.Property(e => e.TaxDistSFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxDistSSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxDistSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxOnly)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TaxPerUnit).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxRelev)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.TaxStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TaxType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Text).HasColumnType("ntext");

                entity.Property(e => e.ThirdParty)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ToDiff).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ToStock).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TotInclTax).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TotalFrgn).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TotalSumSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TranType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TransMod).HasDefaultValueSql("((0))");

                entity.Property(e => e.TreeType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.TrnsCode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.UomCode).HasMaxLength(20);

                entity.Property(e => e.UomCode2).HasMaxLength(20);

                entity.Property(e => e.UomEntry).HasDefaultValueSql("((0))");

                entity.Property(e => e.UomEntry2).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdInvntry)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.UseBaseUn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.VatAppld).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatAppldFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatAppldSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatDscntPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatGroup).HasMaxLength(8);

                entity.Property(e => e.VatGrpSrc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.VatPrcnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatSumFrgn).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatSumSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatWoDpm).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatWoDpmFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatWoDpmSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VendorNum).HasMaxLength(50);

                entity.Property(e => e.Volume).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Weight1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Weight2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WhsCode).HasMaxLength(8);

                entity.Property(e => e.Width1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Width2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WtCalced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.WtLiable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.isSrvCall)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.length2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.unitMsr).HasMaxLength(100);

                entity.Property(e => e.unitMsr2).HasMaxLength(100);
            });

            modelBuilder.Entity<RDR1>(entity =>
            {
                entity.HasKey(e => new { e.DocEntry, e.LineNum })
                    .HasName("RDR1_PRIMARY");

                entity.HasIndex(e => e.AcctCode)
                    .HasName("RDR1_ACCOUNT");

                entity.HasIndex(e => e.Currency)
                    .HasName("RDR1_CURRENCY");

                entity.HasIndex(e => e.LineStatus)
                    .HasName("RDR1_STATUS");

                entity.HasIndex(e => e.OwnerCode)
                    .HasName("RDR1_OWNER_CODE");

                entity.HasIndex(e => new { e.DocEntry, e.VisOrder })
                    .HasName("RDR1_VIS_ORDER");

                entity.HasIndex(e => new { e.BaseEntry, e.BaseType, e.BaseLine })
                    .HasName("RDR1_BASE_ENTRY");

                entity.HasIndex(e => new { e.ItemCode, e.WhsCode, e.OpenQty })
                    .HasName("RDR1_ITM_WHS_OQ");

                entity.HasIndex(e => new { e.ItemCode, e.WhsCode, e.ShipDate })
                    .HasName("RDR1_ITM_WHS_SH");

                entity.Property(e => e.AcctCode).HasMaxLength(15);

                entity.Property(e => e.ActDelDate).HasColumnType("datetime");

                entity.Property(e => e.Address).HasMaxLength(254);

                entity.Property(e => e.AllocBinC).HasMaxLength(11);

                entity.Property(e => e.AssblValue).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BackOrdr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BaseAtCard).HasMaxLength(100);

                entity.Property(e => e.BaseCard).HasMaxLength(15);

                entity.Property(e => e.BaseOpnQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BasePrice)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('E')");

                entity.Property(e => e.BaseQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseRef).HasMaxLength(16);

                entity.Property(e => e.BaseType).HasDefaultValueSql("((-1))");

                entity.Property(e => e.BlockNum).HasMaxLength(100);

                entity.Property(e => e.CEECFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('S')");

                entity.Property(e => e.CFOPCode).HasMaxLength(6);

                entity.Property(e => e.CSTCode).HasMaxLength(6);

                entity.Property(e => e.CSTfCOFINS).HasMaxLength(2);

                entity.Property(e => e.CSTfIPI).HasMaxLength(2);

                entity.Property(e => e.CSTfPIS).HasMaxLength(2);

                entity.Property(e => e.ChgAsmBoMW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CiOppLineN).HasDefaultValueSql("((-1))");

                entity.Property(e => e.CodeBars).HasMaxLength(254);

                entity.Property(e => e.CogsAcct).HasMaxLength(15);

                entity.Property(e => e.CogsOcrCo2).HasMaxLength(8);

                entity.Property(e => e.CogsOcrCo3).HasMaxLength(8);

                entity.Property(e => e.CogsOcrCo4).HasMaxLength(8);

                entity.Property(e => e.CogsOcrCo5).HasMaxLength(8);

                entity.Property(e => e.CogsOcrCod).HasMaxLength(8);

                entity.Property(e => e.Commission).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ConsumeFCT)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CountryOrg).HasMaxLength(3);

                entity.Property(e => e.CredOrigin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Currency).HasMaxLength(3);

                entity.Property(e => e.DIOTNat).HasMaxLength(3);

                entity.Property(e => e.DedVatSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DedVatSumF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DedVatSumS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DefBreak).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DeferrTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DelivrdQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DescOW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DetailsOW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DiscPrcnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DistribExp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DistribIS)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DistribSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DocDate).HasColumnType("datetime");

                entity.Property(e => e.DropShip)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Dscription).HasMaxLength(100);

                entity.Property(e => e.DstrbSumFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DstrbSumSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EnSetCost)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.EquVatPer).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EquVatSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EquVatSumF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EquVatSumS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExLineNo).HasMaxLength(10);

                entity.Property(e => e.Excisable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ExciseAmt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpOpType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ExpType).HasMaxLength(4);

                entity.Property(e => e.ExpUUID).HasMaxLength(50);

                entity.Property(e => e.Factor1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Factor2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Factor3).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Factor4).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FisrtBin).HasMaxLength(228);

                entity.Property(e => e.Flags).HasDefaultValueSql("((0))");

                entity.Property(e => e.FreeChrgBP)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FreeTxt).HasMaxLength(100);

                entity.Property(e => e.FromWhsCod).HasMaxLength(8);

                entity.Property(e => e.GPTtlBasPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GTotal).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GTotalFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GTotalSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrossBuyPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrssProfFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrssProfSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrssProfit).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Height1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Height2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.INMPrice).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ISDistrb).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ISDistrbFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ISDistrbSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ImportLog).HasMaxLength(20);

                entity.Property(e => e.Incoterms).HasDefaultValueSql("((0))");

                entity.Property(e => e.InvQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.InvQtyOnly)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.InvntSttus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('O')");

                entity.Property(e => e.IsAqcuistn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsByPrdct)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ItemType).HasDefaultValueSql("((4))");

                entity.Property(e => e.ItmTaxType).HasMaxLength(2);

                entity.Property(e => e.LegalText).HasMaxLength(254);

                entity.Property(e => e.Length1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LicTradNum).HasMaxLength(32);

                entity.Property(e => e.LinManClsd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.LinePoPrss)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.LineStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('O')");

                entity.Property(e => e.LineTotal).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LineType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('R')");

                entity.Property(e => e.LineVat).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LineVatS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LineVatlF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LineVendor).HasMaxLength(15);

                entity.Property(e => e.LnExcised)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LogInstanc).HasDefaultValueSql("((0))");

                entity.Property(e => e.LstBINMPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LstByDsFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LstByDsSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LstByDsSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.MYFtype).HasMaxLength(2);

                entity.Property(e => e.NeedQty)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.NoInvtryMv)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.NumPerMsr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NumPerMsr2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ObjType)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('17')");

                entity.Property(e => e.OcrCode).HasMaxLength(8);

                entity.Property(e => e.OcrCode2).HasMaxLength(8);

                entity.Property(e => e.OcrCode3).HasMaxLength(8);

                entity.Property(e => e.OcrCode4).HasMaxLength(8);

                entity.Property(e => e.OcrCode5).HasMaxLength(8);

                entity.Property(e => e.OpenCreQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OpenInvQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OpenQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OpenRtnQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OpenSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OpenSumFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OpenSumSys).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OrderedQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OrigItem).HasMaxLength(50);

                entity.Property(e => e.PQTReqDate).HasColumnType("datetime");

                entity.Property(e => e.PQTReqQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PackQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PartRetire)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PcDocType).HasDefaultValueSql("((-1))");

                entity.Property(e => e.PcQuantity).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PickOty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PickStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PoTrgEntry).HasMaxLength(11);

                entity.Property(e => e.PostTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.Price).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PriceAfVAT).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PriceBefDi).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PriceEdit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Project).HasMaxLength(20);

                entity.Property(e => e.QtyToShip).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Quantity).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Rate).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ReleasQtty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RetCost).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RetirAPCFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RetirAPCSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RetireAPC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RetireQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SWW).HasMaxLength(16);

                entity.Property(e => e.SerialNum).HasMaxLength(17);

                entity.Property(e => e.ShipDate).HasColumnType("datetime");

                entity.Property(e => e.ShipFromCo).HasMaxLength(50);

                entity.Property(e => e.ShipFromDe).HasMaxLength(254);

                entity.Property(e => e.ShipToCode).HasMaxLength(50);

                entity.Property(e => e.ShipToDesc).HasMaxLength(254);

                entity.Property(e => e.Shortages).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SlpCode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.SpecPrice)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.StckAppD).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckAppDFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckAppDSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckAppFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckAppSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckDstFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckDstSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckDstSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckINMPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckSumApp).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StockPrice).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StockSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StockSumFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StockSumSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StockValue).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SubCatNum).HasMaxLength(50);

                entity.Property(e => e.Surpluses).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TargetType).HasDefaultValueSql("((-1))");

                entity.Property(e => e.TaxCode).HasMaxLength(8);

                entity.Property(e => e.TaxDistSFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxDistSSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxDistSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxOnly)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TaxPerUnit).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxRelev)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.TaxStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TaxType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Text).HasColumnType("ntext");

                entity.Property(e => e.ThirdParty)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ToDiff).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ToStock).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TotInclTax).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TotalFrgn).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TotalSumSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TranType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TransMod).HasDefaultValueSql("((0))");

                entity.Property(e => e.TreeType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.TrnsCode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.UomCode).HasMaxLength(20);

                entity.Property(e => e.UomCode2).HasMaxLength(20);

                entity.Property(e => e.UomEntry).HasDefaultValueSql("((0))");

                entity.Property(e => e.UomEntry2).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdInvntry)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.UseBaseUn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.VatAppld).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatAppldFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatAppldSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatDscntPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatGroup).HasMaxLength(8);

                entity.Property(e => e.VatGrpSrc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.VatPrcnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatSumFrgn).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatSumSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatWoDpm).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatWoDpmFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatWoDpmSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VendorNum).HasMaxLength(50);

                entity.Property(e => e.Volume).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Weight1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Weight2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WhsCode).HasMaxLength(8);

                entity.Property(e => e.Width1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Width2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WtCalced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.WtLiable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.isSrvCall)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.length2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.unitMsr).HasMaxLength(100);

                entity.Property(e => e.unitMsr2).HasMaxLength(100);
            });

            modelBuilder.Entity<RIN1>(entity =>
            {
                entity.HasKey(e => new { e.DocEntry, e.LineNum })
                    .HasName("RIN1_PRIMARY");

                entity.HasIndex(e => e.AcctCode)
                    .HasName("RIN1_ACCOUNT");

                entity.HasIndex(e => e.Currency)
                    .HasName("RIN1_CURRENCY");

                entity.HasIndex(e => e.LineStatus)
                    .HasName("RIN1_STATUS");

                entity.HasIndex(e => e.OwnerCode)
                    .HasName("RIN1_OWNER_CODE");

                entity.HasIndex(e => new { e.DocEntry, e.VisOrder })
                    .HasName("RIN1_VIS_ORDER");

                entity.HasIndex(e => new { e.BaseEntry, e.BaseType, e.BaseLine })
                    .HasName("RIN1_BASE_ENTRY");

                entity.HasIndex(e => new { e.ItemCode, e.WhsCode, e.OpenQty })
                    .HasName("RIN1_ITM_WHS_OQ");

                entity.Property(e => e.AcctCode).HasMaxLength(15);

                entity.Property(e => e.ActDelDate).HasColumnType("datetime");

                entity.Property(e => e.Address).HasMaxLength(254);

                entity.Property(e => e.AllocBinC).HasMaxLength(11);

                entity.Property(e => e.AssblValue).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BackOrdr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BaseAtCard).HasMaxLength(100);

                entity.Property(e => e.BaseCard).HasMaxLength(15);

                entity.Property(e => e.BaseOpnQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BasePrice)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('E')");

                entity.Property(e => e.BaseQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.BaseRef).HasMaxLength(16);

                entity.Property(e => e.BaseType).HasDefaultValueSql("((-1))");

                entity.Property(e => e.BlockNum).HasMaxLength(100);

                entity.Property(e => e.CEECFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('S')");

                entity.Property(e => e.CFOPCode).HasMaxLength(6);

                entity.Property(e => e.CSTCode).HasMaxLength(6);

                entity.Property(e => e.CSTfCOFINS).HasMaxLength(2);

                entity.Property(e => e.CSTfIPI).HasMaxLength(2);

                entity.Property(e => e.CSTfPIS).HasMaxLength(2);

                entity.Property(e => e.ChgAsmBoMW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CiOppLineN).HasDefaultValueSql("((-1))");

                entity.Property(e => e.CodeBars).HasMaxLength(254);

                entity.Property(e => e.CogsAcct).HasMaxLength(15);

                entity.Property(e => e.CogsOcrCo2).HasMaxLength(8);

                entity.Property(e => e.CogsOcrCo3).HasMaxLength(8);

                entity.Property(e => e.CogsOcrCo4).HasMaxLength(8);

                entity.Property(e => e.CogsOcrCo5).HasMaxLength(8);

                entity.Property(e => e.CogsOcrCod).HasMaxLength(8);

                entity.Property(e => e.Commission).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ConsumeFCT)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CountryOrg).HasMaxLength(3);

                entity.Property(e => e.CredOrigin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Currency).HasMaxLength(3);

                entity.Property(e => e.DIOTNat).HasMaxLength(3);

                entity.Property(e => e.DedVatSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DedVatSumF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DedVatSumS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DefBreak).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DeferrTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DelivrdQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DescOW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DetailsOW)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DiscPrcnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DistribExp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DistribIS)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.DistribSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DocDate).HasColumnType("datetime");

                entity.Property(e => e.DropShip)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Dscription).HasMaxLength(100);

                entity.Property(e => e.DstrbSumFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.DstrbSumSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EnSetCost)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.EquVatPer).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EquVatSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EquVatSumF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.EquVatSumS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExLineNo).HasMaxLength(10);

                entity.Property(e => e.Excisable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ExciseAmt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ExpOpType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ExpType).HasMaxLength(4);

                entity.Property(e => e.ExpUUID).HasMaxLength(50);

                entity.Property(e => e.Factor1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Factor2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Factor3).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Factor4).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.FisrtBin).HasMaxLength(228);

                entity.Property(e => e.Flags).HasDefaultValueSql("((0))");

                entity.Property(e => e.FreeChrgBP)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FreeTxt).HasMaxLength(100);

                entity.Property(e => e.FromWhsCod).HasMaxLength(8);

                entity.Property(e => e.GPTtlBasPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GTotal).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GTotalFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GTotalSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrossBuyPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrssProfFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrssProfSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.GrssProfit).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Height1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Height2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.INMPrice).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ISDistrb).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ISDistrbFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ISDistrbSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ImportLog).HasMaxLength(20);

                entity.Property(e => e.Incoterms).HasDefaultValueSql("((0))");

                entity.Property(e => e.InvQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.InvQtyOnly)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.InvntSttus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('O')");

                entity.Property(e => e.IsAqcuistn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsByPrdct)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ItemType).HasDefaultValueSql("((4))");

                entity.Property(e => e.ItmTaxType).HasMaxLength(2);

                entity.Property(e => e.LegalText).HasMaxLength(254);

                entity.Property(e => e.Length1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LicTradNum).HasMaxLength(32);

                entity.Property(e => e.LinManClsd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.LinePoPrss)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.LineStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('O')");

                entity.Property(e => e.LineTotal).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LineType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('R')");

                entity.Property(e => e.LineVat).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LineVatS).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LineVatlF).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LineVendor).HasMaxLength(15);

                entity.Property(e => e.LnExcised)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LogInstanc).HasDefaultValueSql("((0))");

                entity.Property(e => e.LstBINMPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LstByDsFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LstByDsSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.LstByDsSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.MYFtype).HasMaxLength(2);

                entity.Property(e => e.NeedQty)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.NoInvtryMv)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.NumPerMsr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.NumPerMsr2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ObjType)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('14')");

                entity.Property(e => e.OcrCode).HasMaxLength(8);

                entity.Property(e => e.OcrCode2).HasMaxLength(8);

                entity.Property(e => e.OcrCode3).HasMaxLength(8);

                entity.Property(e => e.OcrCode4).HasMaxLength(8);

                entity.Property(e => e.OcrCode5).HasMaxLength(8);

                entity.Property(e => e.OpenCreQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OpenInvQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OpenQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OpenRtnQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OpenSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OpenSumFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OpenSumSys).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OrderedQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.OrigItem).HasMaxLength(50);

                entity.Property(e => e.PQTReqDate).HasColumnType("datetime");

                entity.Property(e => e.PQTReqQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PackQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PartRetire)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PcDocType).HasDefaultValueSql("((-1))");

                entity.Property(e => e.PcQuantity).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PickOty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PickStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PoTrgEntry).HasMaxLength(11);

                entity.Property(e => e.PostTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.Price).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PriceAfVAT).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PriceBefDi).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.PriceEdit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Project).HasMaxLength(20);

                entity.Property(e => e.QtyToShip).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Quantity).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Rate).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ReleasQtty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RetCost).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RetirAPCFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RetirAPCSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RetireAPC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.RetireQty).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SWW).HasMaxLength(16);

                entity.Property(e => e.SerialNum).HasMaxLength(17);

                entity.Property(e => e.ShipDate).HasColumnType("datetime");

                entity.Property(e => e.ShipFromCo).HasMaxLength(50);

                entity.Property(e => e.ShipFromDe).HasMaxLength(254);

                entity.Property(e => e.ShipToCode).HasMaxLength(50);

                entity.Property(e => e.ShipToDesc).HasMaxLength(254);

                entity.Property(e => e.Shortages).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SlpCode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.SpecPrice)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.StckAppD).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckAppDFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckAppDSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckAppFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckAppSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckDstFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckDstSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckDstSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckINMPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StckSumApp).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StockPrice).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StockSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StockSumFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StockSumSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.StockValue).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.SubCatNum).HasMaxLength(50);

                entity.Property(e => e.Surpluses).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TargetType).HasDefaultValueSql("((-1))");

                entity.Property(e => e.TaxCode).HasMaxLength(8);

                entity.Property(e => e.TaxDistSFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxDistSSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxDistSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxOnly)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TaxPerUnit).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TaxRelev)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.TaxStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TaxType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Text).HasColumnType("ntext");

                entity.Property(e => e.ThirdParty)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ToDiff).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.ToStock).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TotInclTax).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TotalFrgn).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TotalSumSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.TranType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TransMod).HasDefaultValueSql("((0))");

                entity.Property(e => e.TreeType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.TrnsCode).HasDefaultValueSql("((-1))");

                entity.Property(e => e.UomCode).HasMaxLength(20);

                entity.Property(e => e.UomCode2).HasMaxLength(20);

                entity.Property(e => e.UomEntry).HasDefaultValueSql("((0))");

                entity.Property(e => e.UomEntry2).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdInvntry)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.UseBaseUn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.VatAppld).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatAppldFC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatAppldSC).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatDscntPr).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatGroup).HasMaxLength(8);

                entity.Property(e => e.VatGrpSrc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.VatPrcnt).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatSum).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatSumFrgn).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatSumSy).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatWoDpm).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatWoDpmFc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VatWoDpmSc).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.VendorNum).HasMaxLength(50);

                entity.Property(e => e.Volume).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Weight1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Weight2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WhsCode).HasMaxLength(8);

                entity.Property(e => e.Width1).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.Width2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.WtCalced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.WtLiable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.isSrvCall)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.length2).HasColumnType("numeric(19, 6)");

                entity.Property(e => e.unitMsr).HasMaxLength(100);

                entity.Property(e => e.unitMsr2).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
