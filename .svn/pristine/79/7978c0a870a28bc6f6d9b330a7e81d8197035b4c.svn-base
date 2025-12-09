Imports AutoCount.Data
Imports System.Security.Cryptography
Imports AutoCount.LicenseControl
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports AutoCount.Report

Public Class frmMain
    Dim AConn As DBSetting
    Dim UserSession As AutoCount.Authentication.UserSession
    Public Sub New(ByVal UserSession As AutoCount.Authentication.UserSession)
        Me.UserSession = UserSession
        AConn = UserSession.DBSetting
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        Dim frmCancelSO As New AutoCount.Invoicing.Sales.Quotation.FormQuotationCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmCancelSO.Show()
    End Sub
    Private Sub SimpleButton4_Click_2(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Dim frmSalesAnalaysis As New AutoCount.Invoicing.Sales.MultiDimensionalSalesAnalysis.FormMultiDimensionalSalesAnalysis(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmSalesAnalaysis.Show()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSalesOrder_Click_1(sender As System.Object, e As System.EventArgs)
        Dim frmSalesOrder As New AutoCount.Invoicing.Sales.SalesOrder.FormSalesOrderCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmSalesOrder.Show()
    End Sub

    Private Sub btnDO_Click(sender As System.Object, e As System.EventArgs)
        Dim frmSalesOrder As New AutoCount.Invoicing.Sales.DeliveryOrder.FormDeliveryOrderCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmSalesOrder.Show()
    End Sub

    Private Sub bnInvoice_Click(sender As System.Object, e As System.EventArgs)
        Dim frmSalesOrder As New AutoCount.Invoicing.Sales.Invoice.FormInvoiceCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmSalesOrder.Show()
    End Sub

    Private Sub btnCN_Click(sender As System.Object, e As System.EventArgs)
        Dim frmSalesOrder As New AutoCount.Invoicing.Sales.CreditNote.FormCreditNoteCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmSalesOrder.Show()
    End Sub

    Private Sub btnCS_Click(sender As System.Object, e As System.EventArgs)
        Dim frmSalesOrder As New AutoCount.Invoicing.Sales.CashSale.FormCashSaleCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmSalesOrder.Show()
    End Sub

    Private Sub btnPurchaseReturn_Click(sender As System.Object, e As System.EventArgs)
        Dim frmSalesOrder As New AutoCount.Invoicing.Purchase.PurchaseReturn.FormPurchaseReturnCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmSalesOrder.Show()
    End Sub

    Private Sub btnPurchasOrder_Click(sender As System.Object, e As System.EventArgs)
        Dim frmSalesOrder As New AutoCount.Invoicing.Purchase.PurchaseOrder.FormPurchaseOrderCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmSalesOrder.Show()
    End Sub

    Private Sub btnGrn_Click(sender As System.Object, e As System.EventArgs)
        Dim frmSalesOrder As New AutoCount.Invoicing.Purchase.GoodsReceivedNote.FormGoodsReceivedNoteCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmSalesOrder.Show()
    End Sub

    Private Sub btnCashPurchase_Click(sender As System.Object, e As System.EventArgs)
        Dim frmSalesOrder As New AutoCount.Invoicing.Purchase.CashPurchase.FormCashPurchaseCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmSalesOrder.Show()
    End Sub

    Private Sub btnPI_Click(sender As System.Object, e As System.EventArgs)
        Dim frmSalesOrder As New AutoCount.Invoicing.Purchase.PurchaseInvoice.FormPurchaseInvoiceCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmSalesOrder.Show()
    End Sub

    Private Sub btnARInvoice_Click(sender As System.Object, e As System.EventArgs) Handles btnARInvoice.Click
        Dim frmARInvoice As New AutoCount.ARAP.ARInvoice.FormARInvoiceCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmARInvoice.Show()
    End Sub

    Private Sub btnARDN_Click(sender As System.Object, e As System.EventArgs) Handles btnARDN.Click
        Dim frmARDN As New AutoCount.ARAP.ARDN.FormARDNCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmARDN.Show()
    End Sub

    Private Sub btnARCN_Click(sender As System.Object, e As System.EventArgs) Handles btnARCN.Click
        Dim frmARCN As New AutoCount.ARAP.ARCN.FormARCNCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmARCN.Show()
    End Sub

    Private Sub btnAPDN_Click(sender As System.Object, e As System.EventArgs) Handles btnAPDN.Click
        Dim frmARCN As New AutoCount.ARAP.APDN.FormAPDNCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmARCN.Show()
    End Sub

    Private Sub btnAPCN_Click(sender As System.Object, e As System.EventArgs) Handles btnAPCN.Click
        Dim frmARCN As New AutoCount.ARAP.APCN.FormAPCNCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmARCN.Show()
    End Sub

    Private Sub btnAPInvoice_Click(sender As System.Object, e As System.EventArgs) Handles btnAPInvoice.Click
        Dim frmARCN As New AutoCount.ARAP.APInvoice.FormAPInvoiceCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmARCN.Show()
    End Sub

    Private Sub btnCashBook_Click(sender As System.Object, e As System.EventArgs) Handles btnCashBook.Click
        Dim frmCashBook As New AutoCount.GL.CashBook.FormCashBookCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmCashBook.Show()
    End Sub

    Private Sub btnDebitNote_Click(sender As System.Object, e As System.EventArgs)
        Dim frmDebitNote As New AutoCount.Invoicing.Sales.DebitNote.FormDebitNoteCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmDebitNote.Show()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
        Dim frmCancelSO As New AutoCount.Invoicing.Sales.CancelSO.FormCancelSOCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmCancelSO.Show()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs)
        Dim frmDeliveryReturn As New AutoCount.Invoicing.Sales.DeliveryReturn.FormDeliveryReturnCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmDeliveryReturn.Show()
    End Sub

    Private Sub btnRQ_Click(sender As System.Object, e As System.EventArgs) Handles btnRQ.Click
        Dim frmRequestQuotation As New AutoCount.Invoicing.Purchase.RequestQuotation.FormRequestQuotationCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmRequestQuotation.Show()
    End Sub

    Private Sub btnCancelPO_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelPO.Click
        Dim frmCancelPO As New AutoCount.Invoicing.Purchase.CancelPO.FormCancelPOCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmCancelPO.Show()
    End Sub

    Private Sub btnGoodReturn_Click(sender As System.Object, e As System.EventArgs) Handles btnGoodReturn.Click
        Dim frmGoodsReturn As New AutoCount.Invoicing.Purchase.GoodsReturn.FormGoodsReturnCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmGoodsReturn.Show()
    End Sub

    Private Sub btnStockAdjustment_Click(sender As System.Object, e As System.EventArgs) Handles btnStockAdjustment.Click
        Dim frmStockAdjust As New AutoCount.Stock.StockAdjustment.FormStockAdjustmentCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmStockAdjust.Show()
    End Sub

    Private Sub SimpleButton2_Click(sender As System.Object, e As System.EventArgs) Handles btnStockISS.Click
        Dim frmStockIssue As New AutoCount.Stock.StockIssue.FormStockIssueCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmStockIssue.Show()
    End Sub

    Private Sub btnStockReceive_Click(sender As System.Object, e As System.EventArgs) Handles btnStockReceive.Click
        Dim frmStockReceive As New AutoCount.Stock.StockReceive.FormStockReceiveCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmStockReceive.Show()
    End Sub

    Private Sub btnStockTransfer_Click(sender As System.Object, e As System.EventArgs) Handles btnStockTransfer.Click
        Dim frmStockTransfer As New AutoCount.Stock.StockTransfer.FormStockTransferCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmStockTransfer.Show()
    End Sub

    Private Sub btnStockWriteOff_Click(sender As System.Object, e As System.EventArgs) Handles btnStockWriteOff.Click
        Dim frmStockTransfer As New AutoCount.Stock.StockWriteOff.FormStockWriteOffCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmStockTransfer.Show()
    End Sub

    Private Sub btnDebtor_Click(sender As System.Object, e As System.EventArgs) Handles btnDebtor.Click
        Dim frmDebtor As New AutoCount.ARAP.Debtor.FormDebtorCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmDebtor.Show()
    End Sub

    Private Sub btnCreditor_Click(sender As System.Object, e As System.EventArgs) Handles btnCreditor.Click
        Dim frmDebtor As New AutoCount.ARAP.Creditor.FormCreditorCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmDebtor.Show()
    End Sub

    Private Sub btnItem_Click(sender As System.Object, e As System.EventArgs) Handles btnItem.Click
        Dim frmItemMaster As New AutoCount.Stock.Item.FormItemCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmItemMaster.Show()
    End Sub

    Private Sub btnAccessRight_Click(sender As System.Object, e As System.EventArgs) Handles btnAccessRight.Click

        Dim AccessRight As New AutoCount.GeneralMaint.UserMaintenance.FormUserMaintenance(AutoCount.Authentication.UserSession.CurrentUserSession)
        AccessRight.Show()
    End Sub

    Private Sub btnUDF_Click(sender As System.Object, e As System.EventArgs) Handles btnUDF.Click
        Dim AUDF As New AutoCount.UDF.UI.FormUDFCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        AUDF.Show()
    End Sub

    Private Sub btnGeneralSetup_Click(sender As System.Object, e As System.EventArgs) Handles btnGeneralSetup.Click
        Dim frmPlugInGeneral As New frmPlugInGeneralSetup(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmPlugInGeneral.Show()
    End Sub

    Private Sub SimpleButton1_Click(sender As System.Object, e As System.EventArgs) Handles SimpleButton1.Click
        Dim frmCall As New CallLicenseForm(Me.UserSession)
    End Sub
    Private Sub btnSO_Click(sender As Object, e As EventArgs) Handles btnSO.Click
        Dim frmSalesOrder As New AutoCount.Invoicing.Sales.SalesOrder.FormSalesOrderCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmSalesOrder.Show()
    End Sub

    Private Sub btnDO_Click_1(sender As Object, e As EventArgs) Handles btnDO.Click
        Dim frmSalesOrder As New AutoCount.Invoicing.Sales.DeliveryOrder.FormDeliveryOrderCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmSalesOrder.Show()
    End Sub

    Private Sub btnIV_Click(sender As Object, e As EventArgs) Handles btnIV.Click
        Dim frmSalesOrder As New AutoCount.Invoicing.Sales.Invoice.FormInvoiceCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmSalesOrder.Show()
    End Sub

    Private Sub btnCN_Click_1(sender As Object, e As EventArgs) Handles btnCN.Click
        Dim frmSalesOrder As New AutoCount.Invoicing.Sales.CreditNote.FormCreditNoteCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmSalesOrder.Show()
    End Sub

    Private Sub btnSC_Click(sender As Object, e As EventArgs) Handles btnSC.Click
        Dim frmSalesOrder As New AutoCount.Invoicing.Sales.CashSale.FormCashSaleCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmSalesOrder.Show()
    End Sub

    Private Sub SimpleButton14_Click(sender As Object, e As EventArgs) Handles btnPRR.Click
        Dim frmSalesOrder As New AutoCount.Invoicing.Purchase.PurchaseReturn.FormPurchaseReturnCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmSalesOrder.Show()
    End Sub

    Private Sub btnPO_Click(sender As Object, e As EventArgs) Handles btnPO.Click
        Dim frmSalesOrder As New AutoCount.Invoicing.Purchase.PurchaseOrder.FormPurchaseOrderCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmSalesOrder.Show()
    End Sub

    Private Sub btnGRN_Click_1(sender As Object, e As EventArgs) Handles btnGRN.Click
        Dim frmSalesOrder As New AutoCount.Invoicing.Purchase.GoodsReceivedNote.FormGoodsReceivedNoteCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmSalesOrder.Show()
    End Sub

    Private Sub btnCP_Click(sender As Object, e As EventArgs) Handles btnCP.Click
        Dim frmSalesOrder As New AutoCount.Invoicing.Purchase.CashPurchase.FormCashPurchaseCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmSalesOrder.Show()
    End Sub

    Private Sub btnPI_Click_1(sender As Object, e As EventArgs) Handles btnPI.Click
        Dim frmSalesOrder As New AutoCount.Invoicing.Purchase.PurchaseInvoice.FormPurchaseInvoiceCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmSalesOrder.Show()
    End Sub

    Private Sub btnDN_Click(sender As Object, e As EventArgs) Handles btnDN.Click
        Dim frmDebitNote As New AutoCount.Invoicing.Sales.DebitNote.FormDebitNoteCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmDebitNote.Show()
    End Sub

    Private Sub btnSCO_Click(sender As Object, e As EventArgs) Handles btnSCO.Click
        Dim frmCancelSO As New AutoCount.Invoicing.Sales.CancelSO.FormCancelSOCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmCancelSO.Show()
    End Sub

    Private Sub btnDR_Click(sender As Object, e As EventArgs) Handles btnDR.Click
        Dim frmDeliveryReturn As New AutoCount.Invoicing.Sales.DeliveryReturn.FormDeliveryReturnCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmDeliveryReturn.Show()
    End Sub

    Private Sub btnQT_Click(sender As Object, e As EventArgs) Handles btnQT.Click
        Dim frmDeliveryReturn As New AutoCount.Invoicing.Sales.Quotation.FormQuotationCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmDeliveryReturn.Show()
    End Sub

    Private Sub SimpleButton7_Click_2(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        Dim frmStockinqury As New AutoCount.Stock.ItemInquiry.FormItemInquiry(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmStockinqury.Show()
    End Sub

    Private Sub SimpleButton8_Click_1(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        Dim frmJournalEntry As New AutoCount.GL.JournalEntry.FormJournalEntryCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmJournalEntry.Show()
    End Sub

    Private Sub Plugins_Click(sender As Object, e As EventArgs) Handles Plugins.Click

    End Sub
    Private Sub SimpleButton11_Click(sender As Object, e As EventArgs) Handles SimpleButton11.Click
        Dim frmContra As New AutoCount.ARAP.Contra.FormContraCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmContra.Show()
    End Sub
    Private Sub SimpleButton3_Click_1(sender As System.Object, e As System.EventArgs) Handles SimpleButton3.Click
        Dim AFrom As New AutoCount.GeneralMaint.DocumentNoFormat.FormDocumentNoMaintenance(AutoCount.Authentication.UserSession.CurrentUserSession)
        AFrom.Show()
    End Sub
    Private Sub SimpleButton9_Click(sender As Object, e As EventArgs) Handles SimpleButton9.Click
        Dim frmARRefund As New AutoCount.ARAP.ARRefund.FormARRefundCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmARRefund.Show()
    End Sub
    Private Sub SimpleButton5_Click_1(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        Dim frmARDeposit As New AutoCount.ARAP.ARDeposit.FormARDepositCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmARDeposit.Show()
    End Sub
    Private Sub SimpleButton10_Click_1(sender As Object, e As EventArgs) Handles SimpleButton10.Click
        Dim frmAPRefund As New AutoCount.ARAP.APRefund.FormAPRefundCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmAPRefund.Show()
    End Sub

    Private Sub SimpleButton12_Click_1(sender As Object, e As EventArgs) Handles SimpleButton12.Click
        Dim frmAPDeposit As New AutoCount.ARAP.APDeposit.FormAPDepositCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmAPDeposit.Show()
    End Sub
    Private Sub SimpleButton13_Click(sender As Object, e As EventArgs) Handles SimpleButton13.Click
        Dim frmARPayment As New AutoCount.ARAP.ARPayment.FormARPaymentCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmARPayment.Show()
    End Sub
    Private Sub SimpleButton6_Click_2(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        Dim frmAPPayment As New AutoCount.ARAP.APPayment.FormAPPaymentCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmAPPayment.Show()
    End Sub
    Private Sub SimpleButton14_Click_1(sender As Object, e As EventArgs) Handles SimpleButton14.Click
        Dim frmItemGroup As New AutoCount.Stock.ItemGroup.FormItemGroupMaintenance(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmItemGroup.Show()
    End Sub

    Private Sub SimpleButton18_Click(sender As Object, e As EventArgs) Handles SimpleButton18.Click
        Dim frmAss As New AutoCount.Manufacturing.StockAssemblyOrder.FormStockAssemblyOrderCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmAss.Show()
    End Sub

    Private Sub SimpleButton17_Click(sender As Object, e As EventArgs) Handles SimpleButton17.Click
        Dim frmAss As New AutoCount.Manufacturing.StockAssembly.FormStockAssemblyCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmAss.Show()
    End Sub

    Private Sub SimpleButton15_Click(sender As Object, e As EventArgs) Handles SimpleButton15.Click
        Dim frmItemBOm As New AutoCount.Stock.Item.FormItemBom(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmItemBOm.Show()
    End Sub
    Private Sub SimpleButton21_Click(sender As Object, e As EventArgs) Handles SimpleButton21.Click
        Dim frmItemPackage As New AutoCount.Stock.ItemPackage.FormItemPackageMaintainanceCmd(AutoCount.Authentication.UserSession.CurrentUserSession)
        frmItemPackage.Show()
    End Sub

    Private Sub SimpleButton20_Click(sender As Object, e As EventArgs) Handles SimpleButton20.Click
        Dim FormItemTypeMaint As New AutoCount.Stock.ItemType.FormItemTypeMaint(AutoCount.Authentication.UserSession.CurrentUserSession)
        FormItemTypeMaint.Show()
    End Sub
End Class