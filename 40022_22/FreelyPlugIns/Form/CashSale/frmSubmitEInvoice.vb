Imports AutoCount
Imports AutoCount.Authentication
Imports AutoCount.Data
Imports AutoCount.Data.EntityFramework
Imports DevExpress.Xpo
Imports DevExpress.XtraEditors
Imports FreelyCreative.StockItemInquiry.Freely

Partial Public Class frmSubmitEInvoice
    Inherits DevExpress.XtraEditors.XtraForm

#Region "frm open once"
    Private Shared _instance As frmSubmitEInvoice

    Public Shared Function Instance(userSession As UserSession) As frmSubmitEInvoice
        If _instance Is Nothing OrElse _instance.IsDisposed Then
            _instance = New frmSubmitEInvoice(userSession)
        End If
        Return _instance
    End Function

    Private Sub frmSubmitEInvoice_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        _instance = Nothing
    End Sub
#End Region

    Private _UserSession As UserSession
    Private _DocumentReportingCommand As DocumentReportingCommand
    Private _ReportCriteria As DocumentReportingModel.DocumentReportCriteria

    Public ReadOnly Property UserSession As UserSession
        Get
            Return _UserSession
        End Get
    End Property
    Public ReadOnly Property ReportCriteria As DocumentReportingModel.DocumentReportCriteria
        Get
            Return ReportCriteria
        End Get
    End Property

    Private Sub New(userSession As UserSession)

        ' This call is required by the designer.
        ' Add any initialization after the InitializeComponent() call.
        InitializeComponent()
        _UserSession = userSession

        Init()
    End Sub

    Private Sub Init() '<--- for non UI logic, do not depend on UI being rendered
        InitReportCriteria()
    End Sub
    Private Sub InitReportCriteria()
        _DocumentReportingCommand = New DocumentReportingCommand(_UserSession)
        Me.UcDateSelector1.Initialize(Me.UserSession.DBSetting, Me._DocumentReportingCommand.ReportCriteria.DateRangeFilter)
        Me.UcDebtorSelector1.Initialize(Me.UserSession, Me._DocumentReportingCommand.ReportCriteria.DebtorFilter)

        Me.bsReportCriteria.DataSource = Me._DocumentReportingCommand.ReportCriteria
        Me.bsReportCriteria.EndEdit()
    End Sub

    Private Sub FormSetup() '<--- happens after form is constructed and visible, to configure the UI
        SetupGridView()
    End Sub
    Private Sub SetupGridView()
        Try
            Dim AIng As New Utli.FreelyUtli(_UserSession, _UserSession.DBSetting)
            AIng.AddLayoutManager(gvCSPendingEInvoice, Me.Name)
        Catch ex As Exception
            XtraMessageBox.Show($"Layout failed: {ex.Message}", "Autosoft Solution", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmSubmitEInvoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Init()
        FormSetup()
    End Sub

    Private Sub btnInquiry_Click(sender As Object, e As EventArgs) Handles btnInquiry.Click
        Try
            InquiryData()
        Catch ex As Exception
            XtraMessageBox.Show($"Error during inquiry: {ex.Message}", "Autosoft Solution", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub InquiryData()
        Try
            'Me.gcCSTable.DataSource = Me._DocumentReportingCommand.Inquiry()
            Dim records As List(Of CSCreateEntity) = Me._DocumentReportingCommand.Inquiry()

            For Each r In records
                r.IsSelected = False
            Next

            Dim bs As New BindingSource()
            bs.DataSource = records
            Me.gcCSTable.DataSource = bs

            Me.gvCSPendingEInvoice.RefreshData()
        Catch ex As Exception
            XtraMessageBox.Show($"Error during inquiry: {ex.Message}", "Autosoft Solution", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub gvCSPendingEInvoice_DoubleClick(sender As Object, e As EventArgs) Handles gvCSPendingEInvoice.DoubleClick
        Dim view = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If view Is Nothing Then Exit Sub

        Dim rowHandle = view.FocusedRowHandle
        If rowHandle < 0 Then Exit Sub

        Dim selectedRecord As CSCreateEntity = CType(view.GetRow(rowHandle), CSCreateEntity)

        If selectedRecord IsNot Nothing Then
            Dim session = UserSession.CurrentUserSession
            AutoCount.Invoicing.Sales.CashSale.FormCashSaleCmd.ViewDocument(session, selectedRecord.DocKey)
        End If
    End Sub
    Private Sub btnSelectAll_Click(sender As Object, e As EventArgs) Handles btnSelectAll.Click
        Dim bs = CType(gcCSTable.DataSource, BindingSource)

        For Each row As CSCreateEntity In bs.List
            row.IsSelected = True
        Next

        gvCSPendingEInvoice.RefreshData()
    End Sub
    Private Sub btnUnselectAll_Click(sender As Object, e As EventArgs) Handles btnUnselectAll.Click
        Dim bs = CType(gcCSTable.DataSource, BindingSource)

        For Each row As CSCreateEntity In bs.List
            row.IsSelected = False
        Next

        gvCSPendingEInvoice.RefreshData()
    End Sub

    Private Sub btnSubmitEInvoice_Click(sender As Object, e As EventArgs) Handles btnSubmitEInvoice.Click
        Dim bs = CType(gcCSTable.DataSource, BindingSource)

        If bs Is Nothing OrElse bs.List.Count = 0 Then
            XtraMessageBox.Show($"No record available", "Autosoft Solution: Submit E-Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim selected As List(Of CSCreateEntity) = bs.List.Cast(Of CSCreateEntity)().
                                                  Where(Function(x) x.IsSelected).ToList()

        If selected.Count = 0 Then
            XtraMessageBox.Show($"Please select at least one record", "Autosoft Solution: Submit E-Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If XtraMessageBox.Show($"Submit E-Invoice for {selected.Count} record(s)?",
                           "Confirm Submission",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Dim remainSelected As List(Of CSCreateEntity) = _DocumentReportingCommand.UpdateSubmitEInvoiceFlag(selected)
        btnInquiry.PerformClick() '<-- Refresh the grid by running inquiry again

        Dim bsRefreshed = CType(gcCSTable.DataSource, BindingSource)
        If remainSelected IsNot Nothing AndAlso remainSelected.Count > 0 Then
            For Each row As CSCreateEntity In bsRefreshed.List
                If remainSelected.Any(Function(r) r.DocNo = row.DocNo) Then
                    row.IsSelected = True
                End If
            Next
            gvCSPendingEInvoice.RefreshData()
        End If
    End Sub
End Class