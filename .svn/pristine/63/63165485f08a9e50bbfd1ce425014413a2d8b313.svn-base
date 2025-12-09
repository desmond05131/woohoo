Imports System
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity
Imports System.Linq
Imports AutoCount.Authentication

Partial Public Class CSEntity
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=CSEntity")
    End Sub

    Public Sub New(userSession As UserSession)
        MyBase.New(userSession.DBSetting.ConnectionString)
    End Sub

    Public Overridable Property CS As DbSet(Of C)
    Public Overridable Property CSDTLs As DbSet(Of CSDTL)

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.Total) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.Footer1Param) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.Footer1Amt) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.Footer1LocalAmt) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.Footer2Param) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.Footer2Amt) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.Footer2LocalAmt) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.Footer3Param) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.Footer3Amt) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.Footer3LocalAmt) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.CurrencyRate) _
            .HasPrecision(19, 12)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.NetTotal) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.LocalNetTotal) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.AnalysisNetTotal) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.LocalAnalysisNetTotal) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.LocalTotalCost) _
            .HasPrecision(25, 8)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.Tax) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.LocalTax) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.TotalBonusPoint) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.PostToStock) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.PostToGL) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.Transferable) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.ToDocType) _
            .IsUnicode(False)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.Cancelled) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.CanSync) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.FullTransferOption) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.ReallocatePurchaseByProject) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.CashPayment) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.Footer1Tax) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.Footer1LocalTax) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.Footer2Tax) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.Footer2LocalTax) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.Footer3Tax) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.Footer3LocalTax) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.ExTax) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.LocalExTax) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.ToTaxCurrencyRate) _
            .HasPrecision(19, 12)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.RoundAdj) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.FinalTotal) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.CalcDiscountOnUnitPrice) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.TotalExTax) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.TaxableAmt) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.InclusiveTax) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.Footer1TaxRate) _
            .HasPrecision(18, 6)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.Footer2TaxRate) _
            .HasPrecision(18, 6)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.Footer3TaxRate) _
            .HasPrecision(18, 6)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.IsRoundAdj) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.LocalTaxableAmt) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.TaxCurrencyTax) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.TaxCurrencyTaxableAmt) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.WithholdingTax) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.LocalWithholdingTax) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.TaxCurrencyWithholdingTax) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.WithholdingVAT) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.LocalWithholdingVAT) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.TaxCurrencyWithholdingVAT) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.SubmitEInvoice) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.EInvoiceStatus) _
            .IsUnicode(False)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.EInvoiceUuid) _
            .IsUnicode(False)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.EInvoiceValidationLink) _
            .IsUnicode(False)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.EInvoiceError) _
            .IsUnicode(False)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.EInvoiceTraceId) _
            .IsUnicode(False)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.EInvoiceCancelReason) _
            .IsUnicode(False)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.ReferenceNumberOfCustomsFormNo1And9) _
            .IsUnicode(False)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.Incoterms) _
            .IsUnicode(False)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.FreeTradeAgreementInformation) _
            .IsUnicode(False)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.AuthorisationNumberForCertifiedExporter) _
            .IsUnicode(False)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.ReferenceNumberOfCustomsFormNo2) _
            .IsUnicode(False)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.FreightAllowanceChargeAmt) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.FreightAllowanceChargeReason) _
            .IsUnicode(False)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.ConsolidatedEInvoice) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of C)() _
            .Property(Function(e) e.EInvoiceSubmissionUuid) _
            .IsUnicode(False)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.MainItem) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.Qty) _
            .HasPrecision(25, 8)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.Rate) _
            .HasPrecision(25, 8)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.SmallestQty) _
            .HasPrecision(25, 8)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.TransferedQty) _
            .HasPrecision(25, 8)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.FOCQty) _
            .HasPrecision(25, 8)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.FOCTransferedQty) _
            .HasPrecision(25, 8)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.SmallestUnitPrice) _
            .HasPrecision(25, 8)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.UnitPrice) _
            .HasPrecision(25, 8)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.DiscountAmt) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.Tax) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.SubTotal) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.LocalSubTotal) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.LocalTotalCost) _
            .HasPrecision(25, 8)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.LocalFOCTotalCost) _
            .HasPrecision(25, 8)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.BonusPoint) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.Transferable) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.PrintOut) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.DtlType) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.CalcByPercent) _
            .HasPrecision(18, 6)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.AddToSubTotal) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.FromDocType) _
            .IsUnicode(False)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.FullTransferOption) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.SubQty) _
            .HasPrecision(25, 8)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.IsCalcBonusPoint) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.SubTotalExTax) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.LocalTax) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.TaxableAmt) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.TaxAdjustment) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.LocalSubTotalExTax) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.ExtraDiscountAmt) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.TaxRate) _
            .HasPrecision(18, 6)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.LocalTaxAdjustment) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.LocalTaxableAmt) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.TaxCurrencyTax) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.TaxCurrencyTaxableAmt) _
            .HasPrecision(19, 2)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.ATC) _
            .IsUnicode(False)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.Classification) _
            .IsUnicode(False)

        modelBuilder.Entity(Of CSDTL)() _
            .Property(Function(e) e.OriginCountryCode) _
            .IsUnicode(False)
    End Sub
End Class
