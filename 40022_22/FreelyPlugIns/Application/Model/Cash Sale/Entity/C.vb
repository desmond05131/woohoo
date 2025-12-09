Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("CS")>
Partial Public Class C
    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DocKey As Long

    <Required>
    <StringLength(30)>
    Public Property DocNo As String

    Public Property DocDate As Date

    <Required>
    <StringLength(12)>
    Public Property DebtorCode As String

    <StringLength(100)>
    Public Property DebtorName As String

    <StringLength(40)>
    Public Property Ref As String

    <StringLength(80)>
    Public Property Description As String

    <Required>
    <StringLength(30)>
    Public Property DisplayTerm As String

    <StringLength(12)>
    Public Property SalesAgent As String

    <StringLength(40)>
    Public Property InvAddr1 As String

    <StringLength(40)>
    Public Property InvAddr2 As String

    <StringLength(40)>
    Public Property InvAddr3 As String

    <StringLength(40)>
    Public Property InvAddr4 As String

    <StringLength(25)>
    Public Property Phone1 As String

    <StringLength(25)>
    Public Property Fax1 As String

    <StringLength(40)>
    Public Property Attention As String

    <StringLength(20)>
    Public Property BranchCode As String

    <StringLength(40)>
    Public Property DeliverAddr1 As String

    <StringLength(40)>
    Public Property DeliverAddr2 As String

    <StringLength(40)>
    Public Property DeliverAddr3 As String

    <StringLength(40)>
    Public Property DeliverAddr4 As String

    <StringLength(25)>
    Public Property DeliverPhone1 As String

    <StringLength(25)>
    Public Property DeliverFax1 As String

    <StringLength(40)>
    Public Property DeliverContact As String

    <StringLength(60)>
    Public Property SalesExemptionNo As String

    Public Property SalesExemptionExpiryDate As Date?

    Public Property Total As Decimal?

    Public Property Footer1Param As Decimal?

    Public Property Footer1Amt As Decimal?

    Public Property Footer1LocalAmt As Decimal?

    <StringLength(14)>
    Public Property Footer1TaxCode As String

    Public Property Footer2Param As Decimal?

    Public Property Footer2Amt As Decimal?

    Public Property Footer2LocalAmt As Decimal?

    <StringLength(14)>
    Public Property Footer2TaxCode As String

    Public Property Footer3Param As Decimal?

    Public Property Footer3Amt As Decimal?

    Public Property Footer3LocalAmt As Decimal?

    <StringLength(14)>
    Public Property Footer3TaxCode As String

    <Required>
    <StringLength(5)>
    Public Property CurrencyCode As String

    Public Property CurrencyRate As Decimal

    Public Property NetTotal As Decimal?

    Public Property LocalNetTotal As Decimal?

    Public Property AnalysisNetTotal As Decimal?

    Public Property LocalAnalysisNetTotal As Decimal?

    Public Property LocalTotalCost As Decimal?

    Public Property Tax As Decimal?

    Public Property LocalTax As Decimal?

    Public Property TotalBonusPoint As Decimal?

    <Required>
    <StringLength(1)>
    Public Property PostToStock As String

    <Required>
    <StringLength(1)>
    Public Property PostToGL As String

    Public Property ReferDocKey As Long?

    Public Property ReferPaymentDocKey As Long?

    <Required>
    <StringLength(1)>
    Public Property Transferable As String

    <StringLength(2)>
    Public Property ToDocType As String

    Public Property ToDocKey As Long?

    Public Property Note As String

    <StringLength(40)>
    Public Property Remark1 As String

    <StringLength(40)>
    Public Property Remark2 As String

    <StringLength(40)>
    Public Property Remark3 As String

    <StringLength(40)>
    Public Property Remark4 As String

    Public Property PrintCount As Short

    <Required>
    <StringLength(1)>
    Public Property Cancelled As String

    Public Property LastModified As Date

    <Required>
    <StringLength(10)>
    Public Property LastModifiedUserID As String

    Public Property CreatedTimeStamp As Date

    <Required>
    <StringLength(10)>
    Public Property CreatedUserID As String

    Public Property ExternalLink As String

    <StringLength(30)>
    Public Property RefDocNo As String

    <Required>
    <StringLength(1)>
    Public Property CanSync As String

    Public Property LastUpdate As Integer

    <StringLength(20)>
    Public Property MemberNo As String

    Public Property ToDtlKey As Long?

    <StringLength(1)>
    Public Property FullTransferOption As String

    <StringLength(20)>
    Public Property ShipVia As String

    <StringLength(40)>
    Public Property ShipInfo As String

    <Required>
    <StringLength(1)>
    Public Property ReallocatePurchaseByProject As String

    Public Property ReallocatePurchaseByProjectJEDocKey As Long?

    <StringLength(30)>
    Public Property RefNo2 As String

    Public Property PaymentMode As Byte?

    Public Property CashPayment As Decimal?

    <StringLength(10)>
    Public Property CCApprovalCode As String

    <StringLength(8)>
    Public Property SalesLocation As String

    Public Property Footer1Tax As Decimal?

    Public Property Footer1LocalTax As Decimal?

    Public Property Footer2Tax As Decimal?

    Public Property Footer2LocalTax As Decimal?

    Public Property Footer3Tax As Decimal?

    Public Property Footer3LocalTax As Decimal?

    Public Property ExTax As Decimal?

    Public Property LocalExTax As Decimal?

    <StringLength(25)>
    Public Property YourPONo As String

    Public Property YourPODate As Date?

    Public Property Guid As Guid

    <StringLength(10)>
    Public Property ReallocatePurchaseByProjectNo As String

    Public Property ToTaxCurrencyRate As Decimal

    Public Property RoundAdj As Decimal?

    Public Property FinalTotal As Decimal?

    <StringLength(1)>
    Public Property CalcDiscountOnUnitPrice As String

    <StringLength(20)>
    Public Property TaxDocNo As String

    Public Property TotalExTax As Decimal?

    Public Property TaxableAmt As Decimal?

    <Required>
    <StringLength(1)>
    Public Property InclusiveTax As String

    Public Property Footer1TaxRate As Decimal?

    Public Property Footer2TaxRate As Decimal?

    Public Property Footer3TaxRate As Decimal?

    Public Property TaxDate As Date?

    <Required>
    <StringLength(1)>
    Public Property IsRoundAdj As String

    Public Property RoundingMethod As Integer

    Public Property LocalTaxableAmt As Decimal?

    Public Property TaxCurrencyTax As Decimal?

    Public Property TaxCurrencyTaxableAmt As Decimal?

    <StringLength(8)>
    Public Property MultiPrice As String

    Public Property WithholdingTax As Decimal?

    Public Property LocalWithholdingTax As Decimal?

    Public Property TaxCurrencyWithholdingTax As Decimal?

    Public Property WithholdingVAT As Decimal?

    Public Property LocalWithholdingVAT As Decimal?

    Public Property TaxCurrencyWithholdingVAT As Decimal?

    Public Property WHTPostingDate As Date?

    Public Property TaxEntityID As Integer?

    <Required>
    <StringLength(1)>
    Public Property SubmitEInvoice As String

    <StringLength(100)>
    Public Property EInvoiceStatus As String

    Public Property EInvoiceAIPSubmissionDateTime As Date?

    <StringLength(100)>
    Public Property EInvoiceUuid As String

    Public Property EInvoiceValidatedDateTime As Date?

    <StringLength(255)>
    Public Property EInvoiceValidationLink As String

    Public Property EInvoiceError As String

    Public Property EInvoiceCancelDateTime As Date?

    <StringLength(100)>
    Public Property EInvoiceTraceId As String

    <StringLength(100)>
    Public Property EInvoiceCancelReason As String

    Public Property DeliveryTaxEntityID As Integer?

    <StringLength(1000)>
    Public Property ReferenceNumberOfCustomsFormNo1And9 As String

    <StringLength(3)>
    Public Property Incoterms As String

    <StringLength(300)>
    Public Property FreeTradeAgreementInformation As String

    <StringLength(300)>
    Public Property AuthorisationNumberForCertifiedExporter As String

    <StringLength(1000)>
    Public Property ReferenceNumberOfCustomsFormNo2 As String

    Public Property FreightAllowanceChargeAmt As Decimal?

    <StringLength(100)>
    Public Property FreightAllowanceChargeReason As String

    <StringLength(30)>
    Public Property CIDocNo As String

    Public Property CIDocKey As Long?

    Public Property EInvoiceIssueDateTime As Date?

    <Required>
    <StringLength(1)>
    Public Property ConsolidatedEInvoice As String

    Public Property Freely_Signature As Byte()

    <StringLength(50)>
    Public Property UDF_AndDocNo As String

    <StringLength(100)>
    Public Property EInvoiceSubmissionUuid As String

    Public Property WithholdingTaxVersion As Integer

    Public Property WithholdingTaxRoundingMethod As Integer

    Public Property SGEInvoiceATDocKey As Long?

    <StringLength(100)>
    Public Property SGEInvoiceATDocNo As String

    Public Property EInvoiceSubmissionDateTime As Date?
End Class
