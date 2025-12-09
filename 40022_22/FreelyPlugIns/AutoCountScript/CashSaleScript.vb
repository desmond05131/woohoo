Imports System.Reflection
Imports AutoCount.Authentication
Imports DevExpress.XtraEditors

Public Class CashSaleScript
    Private ReadOnly _helper As New PriceHistoryHelper()

#Region "Untick submit einvoice checkbox in cash sale window"
    Public Sub OnFormInitialize(e As AutoCount.Invoicing.Sales.CashSale.FormCashSaleEntry.FormInitializeEventArgs)
        Try
            SetSubmitEInvoiceFalse(e)
        Catch ex As Exception
            XtraMessageBox.Show($"[CashSaleScript] Error setting SubmitEInvoice: {ex.Message}", "Autosoft Solution Sdn Bhd", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Public Sub OnFormShow(e As AutoCount.Invoicing.Sales.CashSale.FormCashSaleEntry.FormShowEventArgs)
        Try
            SetSubmitEInvoiceFalse(e)
            _helper.AddStockItemMaintenanceRibbon(e.Form, e.UserSession, e.DBSetting, e.EditWindowMode)
        Catch ex As Exception
            XtraMessageBox.Show($"[CashSaleScript] Error setting SubmitEInvoice: {ex.Message}", "Autosoft Solution Sdn Bhd", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Public Sub OnSwitchToEditMode(e As AutoCount.Invoicing.Sales.CashSale.FormCashSaleEntry.FormEventArgs)
        ' Find the ribbon group again
        Dim ribbonCtrl = e.Form.Ribbon
        Dim newGroup = ribbonCtrl.Pages("Home").Groups _
            .FirstOrDefault(Function(g) g.Name = "ribbonPageGroupStockItemMaintenance")

        If newGroup IsNot Nothing Then
            newGroup.Visible = (e.EditWindowMode <> AutoCount.Document.EditWindowMode.View)
        End If
    End Sub

    Public Sub OnMasterColumnChanged(e As AutoCount.Invoicing.Sales.CashSale.CashSaleMasterColumnChangedEventArgs)
        Try
            Select Case e.ChangedColumnName
                Case "DebtorCode", "DocDate"
                    SetSubmitEInvoiceFalse(e)
            End Select

            'If e.ChangedColumnName = "DebtorCode" Then
            '    Dim debtorCode = e.MasterRecord.DebtorCode
            '    If debtorCode IsNot Nothing Then
            '        SetSubmitEInvoiceFalse(e)
            '    End If
            'End If
        Catch ex As Exception
            XtraMessageBox.Show($"[CashSaleScript] Error setting SubmitEInvoice: {ex.Message}", "Autosoft Solution Sdn Bhd", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub SetSubmitEInvoiceFalse(e As Object)
        Try
            ' Detect the event type and extract MasterRecord
            Dim masterRecord As AutoCount.Invoicing.Sales.CashSale.CashSale = Nothing

            Dim objType = e.GetType()
            Dim field = objType.GetField("myCashSale", BindingFlags.NonPublic Or BindingFlags.Instance)
            masterRecord = TryCast(field?.GetValue(e), AutoCount.Invoicing.Sales.CashSale.CashSale)

            If masterRecord Is Nothing Then Exit Sub

            ' ✔ Only apply default for NEW document
            If masterRecord.DocumentState = AutoCount.Invoicing.InvoicingDocumentState.New Then
                masterRecord.SubmitEInvoice = False

                Dim rowField = masterRecord.GetType().GetField("myRow", BindingFlags.NonPublic Or BindingFlags.Instance)
                Dim row = TryCast(rowField?.GetValue(masterRecord), DataRow)

                If row IsNot Nothing Then
                    row("SubmitEInvoice") = AutoCount.Converter.BooleanToText(False)
                End If
            End If

        Catch ex As Exception
            XtraMessageBox.Show($"[CashSaleScript] Error setting SubmitEInvoice: {ex.Message}",
                            "Autosoft Solution Sdn Bhd", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub SetSubmitEInvoiceFalseORI(CSType As Object)
        Try
            Dim objType = CSType.GetType()

            Dim cashSaleField = objType.GetField("myCashSale", BindingFlags.NonPublic Or BindingFlags.Instance)
            Dim cashSale = TryCast(cashSaleField?.GetValue(CSType), AutoCount.Invoicing.Sales.CashSale.CashSale)

            If cashSale IsNot Nothing Then
                cashSale.SubmitEInvoice = False

                Dim myRowField = cashSale.GetType().GetField("myRow", BindingFlags.NonPublic Or BindingFlags.Instance)
                Dim myRow = TryCast(myRowField?.GetValue(cashSale), System.Data.DataRow)
                If myRow IsNot Nothing Then
                    myRow("SubmitEInvoice") = AutoCount.Converter.BooleanToText(False)
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show($"[CashSaleScript] Error setting SubmitEInvoice: {ex.Message}", "Autosoft Solution Sdn Bhd", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
#End Region

    '<--- btn pending einvoice submission --->
    Public Sub OnFormInitialize(e As AutoCount.Invoicing.Sales.CashSale.FormCashSaleCmd.FormInitializeEventArgs)
        Dim btnViewFlow = e.PanelAction.Controls _
            .OfType(Of DevExpress.XtraEditors.SimpleButton)() _
            .FirstOrDefault(Function(b) b.Name = "btnViewFlow")

        If btnViewFlow IsNot Nothing Then
            Dim btnPendingEInvoice As New DevExpress.XtraEditors.SimpleButton With {
                .Name = "btnPendingEInvoice",
                .Text = "Pending E-Invoice Submission",
                .Width = btnViewFlow.Width + 30,
                .Height = btnViewFlow.Height,
                .Location = New System.Drawing.Point(
                    btnViewFlow.Location.X + btnViewFlow.Width + 5, ' right next to btnViewFlow
                    btnViewFlow.Location.Y
                    )
            }

            btnPendingEInvoice.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
            btnPendingEInvoice.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            btnPendingEInvoice.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            btnPendingEInvoice.Appearance.Options.UseTextOptions = True

            e.PanelAction.Controls.Add(btnPendingEInvoice)

            AddHandler btnPendingEInvoice.Click,
                    Sub(sender As Object, args As EventArgs)
                        Dim session = UserSession.CurrentUserSession
                        Dim frm = frmSubmitEInvoice.Instance(session)
                        frm.Show()
                        frm.BringToFront()
                        frm.Focus()
                    End Sub
        End If
    End Sub
End Class

#Region "original code"
'Dim cashSaleField = GetType(AutoCount.Invoicing.Sales.CashSale.FormCashSaleEntry.FormShowEventArgs) _
'            .GetField("myCashSale", BindingFlags.NonPublic Or BindingFlags.Instance)
'Dim cashSale = TryCast(cashSaleField?.GetValue(e), AutoCount.Invoicing.Sales.CashSale.CashSale)

'If cashSale IsNot Nothing Then
'   cashSale.SubmitEInvoice = False

'   Dim myRowField = cashSale.GetType().GetField("myRow", BindingFlags.NonPublic Or BindingFlags.Instance)
'   Dim myRow = TryCast(myRowField?.GetValue(cashSale), System.Data.DataRow)
'   If myRow IsNot Nothing Then
'       myRow("SubmitEInvoice") = AutoCount.Converter.BooleanToText(False)
'   End If
'End If
#End Region
