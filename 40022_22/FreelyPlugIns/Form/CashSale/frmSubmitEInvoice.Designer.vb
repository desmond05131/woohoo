<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSubmitEInvoice
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSubmitEInvoice))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl5 = New DevExpress.XtraEditors.PanelControl()
        Me.gcCSTable = New DevExpress.XtraGrid.GridControl()
        Me.bsCSPendingEInvoice = New System.Windows.Forms.BindingSource(Me.components)
        Me.gvCSPendingEInvoice = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colDocNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDocDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDebtorCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDebtorName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNetTotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOutstanding = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSubmitEInvoice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.chkIsSubmitEInvoice = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.colEInvoiceStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIsSelected = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.chkIsSelected = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.colItemGenerateEInvoice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.chkHasItemGenerateEInvoice = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.btnUnselectAll = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSelectAll = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.btnSubmitEInvoice = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.btnInquiry = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.UcDebtorSelector1 = New AutoCount.Controls.FilterUI.UCDebtorSelector()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.UcDateSelector1 = New AutoCount.Controls.FilterUI.UCDateSelector()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelHeader1 = New AutoCount.Controls.PanelHeader()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.bsReportCriteria = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl5.SuspendLayout()
        CType(Me.gcCSTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsCSPendingEInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvCSPendingEInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkIsSubmitEInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkIsSelected, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkHasItemGenerateEInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsReportCriteria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.PanelControl1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(998, 699)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.PanelControl5)
        Me.PanelControl1.Controls.Add(Me.PanelControl4)
        Me.PanelControl1.Controls.Add(Me.PanelControl3)
        Me.PanelControl1.Controls.Add(Me.PanelControl2)
        Me.PanelControl1.Location = New System.Drawing.Point(12, 12)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(974, 675)
        Me.PanelControl1.TabIndex = 4
        '
        'PanelControl5
        '
        Me.PanelControl5.Controls.Add(Me.gcCSTable)
        Me.PanelControl5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl5.Location = New System.Drawing.Point(2, 283)
        Me.PanelControl5.Margin = New System.Windows.Forms.Padding(0)
        Me.PanelControl5.Name = "PanelControl5"
        Me.PanelControl5.Size = New System.Drawing.Size(970, 390)
        Me.PanelControl5.TabIndex = 3
        '
        'gcCSTable
        '
        Me.gcCSTable.DataSource = Me.bsCSPendingEInvoice
        Me.gcCSTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcCSTable.Location = New System.Drawing.Point(2, 2)
        Me.gcCSTable.MainView = Me.gvCSPendingEInvoice
        Me.gcCSTable.Name = "gcCSTable"
        Me.gcCSTable.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.chkIsSelected, Me.chkIsSubmitEInvoice, Me.chkHasItemGenerateEInvoice})
        Me.gcCSTable.Size = New System.Drawing.Size(966, 386)
        Me.gcCSTable.TabIndex = 0
        Me.gcCSTable.UseEmbeddedNavigator = True
        Me.gcCSTable.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvCSPendingEInvoice})
        '
        'bsCSPendingEInvoice
        '
        Me.bsCSPendingEInvoice.DataSource = GetType(FreelyCreative.StockItemInquiry.CSCreateEntity)
        '
        'gvCSPendingEInvoice
        '
        Me.gvCSPendingEInvoice.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colDocNo, Me.colDocDate, Me.colDebtorCode, Me.colDebtorName, Me.colNetTotal, Me.colOutstanding, Me.colSubmitEInvoice, Me.colEInvoiceStatus, Me.colIsSelected, Me.colItemGenerateEInvoice})
        Me.gvCSPendingEInvoice.GridControl = Me.gcCSTable
        Me.gvCSPendingEInvoice.Name = "gvCSPendingEInvoice"
        '
        'colDocNo
        '
        Me.colDocNo.FieldName = "DocNo"
        Me.colDocNo.Name = "colDocNo"
        Me.colDocNo.OptionsColumn.AllowEdit = False
        Me.colDocNo.Visible = True
        Me.colDocNo.VisibleIndex = 1
        Me.colDocNo.Width = 101
        '
        'colDocDate
        '
        Me.colDocDate.FieldName = "DocDate"
        Me.colDocDate.Name = "colDocDate"
        Me.colDocDate.OptionsColumn.AllowEdit = False
        Me.colDocDate.Visible = True
        Me.colDocDate.VisibleIndex = 2
        Me.colDocDate.Width = 101
        '
        'colDebtorCode
        '
        Me.colDebtorCode.FieldName = "DebtorCode"
        Me.colDebtorCode.Name = "colDebtorCode"
        Me.colDebtorCode.OptionsColumn.AllowEdit = False
        Me.colDebtorCode.Visible = True
        Me.colDebtorCode.VisibleIndex = 3
        Me.colDebtorCode.Width = 101
        '
        'colDebtorName
        '
        Me.colDebtorName.FieldName = "DebtorName"
        Me.colDebtorName.Name = "colDebtorName"
        Me.colDebtorName.OptionsColumn.AllowEdit = False
        Me.colDebtorName.Visible = True
        Me.colDebtorName.VisibleIndex = 4
        Me.colDebtorName.Width = 101
        '
        'colNetTotal
        '
        Me.colNetTotal.FieldName = "NetTotal"
        Me.colNetTotal.Name = "colNetTotal"
        Me.colNetTotal.OptionsColumn.AllowEdit = False
        Me.colNetTotal.Visible = True
        Me.colNetTotal.VisibleIndex = 5
        Me.colNetTotal.Width = 101
        '
        'colOutstanding
        '
        Me.colOutstanding.FieldName = "Outstanding"
        Me.colOutstanding.Name = "colOutstanding"
        Me.colOutstanding.OptionsColumn.AllowEdit = False
        Me.colOutstanding.Visible = True
        Me.colOutstanding.VisibleIndex = 6
        Me.colOutstanding.Width = 93
        '
        'colSubmitEInvoice
        '
        Me.colSubmitEInvoice.Caption = "Submit E-Invoice?"
        Me.colSubmitEInvoice.ColumnEdit = Me.chkIsSubmitEInvoice
        Me.colSubmitEInvoice.FieldName = "SubmitEInvoice"
        Me.colSubmitEInvoice.Name = "colSubmitEInvoice"
        Me.colSubmitEInvoice.OptionsColumn.AllowEdit = False
        Me.colSubmitEInvoice.ToolTip = "Submit E-Invoice?"
        Me.colSubmitEInvoice.Visible = True
        Me.colSubmitEInvoice.VisibleIndex = 7
        Me.colSubmitEInvoice.Width = 100
        '
        'chkIsSubmitEInvoice
        '
        Me.chkIsSubmitEInvoice.AutoHeight = False
        Me.chkIsSubmitEInvoice.Name = "chkIsSubmitEInvoice"
        Me.chkIsSubmitEInvoice.ValueChecked = "T"
        Me.chkIsSubmitEInvoice.ValueGrayed = ""
        Me.chkIsSubmitEInvoice.ValueUnchecked = "F"
        '
        'colEInvoiceStatus
        '
        Me.colEInvoiceStatus.FieldName = "EInvoiceStatus"
        Me.colEInvoiceStatus.Name = "colEInvoiceStatus"
        Me.colEInvoiceStatus.OptionsColumn.AllowEdit = False
        Me.colEInvoiceStatus.Visible = True
        Me.colEInvoiceStatus.VisibleIndex = 8
        Me.colEInvoiceStatus.Width = 100
        '
        'colIsSelected
        '
        Me.colIsSelected.ColumnEdit = Me.chkIsSelected
        Me.colIsSelected.FieldName = "IsSelected"
        Me.colIsSelected.Name = "colIsSelected"
        Me.colIsSelected.OptionsColumn.AllowSize = False
        Me.colIsSelected.OptionsColumn.ShowCaption = False
        Me.colIsSelected.Visible = True
        Me.colIsSelected.VisibleIndex = 0
        Me.colIsSelected.Width = 39
        '
        'chkIsSelected
        '
        Me.chkIsSelected.AutoHeight = False
        Me.chkIsSelected.Name = "chkIsSelected"
        '
        'colItemGenerateEInvoice
        '
        Me.colItemGenerateEInvoice.Caption = "E-Invoice Item?"
        Me.colItemGenerateEInvoice.ColumnEdit = Me.chkHasItemGenerateEInvoice
        Me.colItemGenerateEInvoice.FieldName = "ItemGenerateEInvoice"
        Me.colItemGenerateEInvoice.Name = "colItemGenerateEInvoice"
        Me.colItemGenerateEInvoice.OptionsColumn.AllowEdit = False
        Me.colItemGenerateEInvoice.ToolTip = "Has Item Must Generate E-Invoice?"
        Me.colItemGenerateEInvoice.Visible = True
        Me.colItemGenerateEInvoice.VisibleIndex = 9
        Me.colItemGenerateEInvoice.Width = 104
        '
        'chkHasItemGenerateEInvoice
        '
        Me.chkHasItemGenerateEInvoice.AutoHeight = False
        Me.chkHasItemGenerateEInvoice.Name = "chkHasItemGenerateEInvoice"
        '
        'PanelControl4
        '
        Me.PanelControl4.AutoSize = True
        Me.PanelControl4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PanelControl4.Controls.Add(Me.btnUnselectAll)
        Me.PanelControl4.Controls.Add(Me.btnSelectAll)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl4.Location = New System.Drawing.Point(2, 233)
        Me.PanelControl4.Margin = New System.Windows.Forms.Padding(0)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(970, 50)
        Me.PanelControl4.TabIndex = 2
        '
        'btnUnselectAll
        '
        Me.btnUnselectAll.ImageOptions.Image = Global.FreelyCreative.StockItemInquiry.My.Resources.Resources.cancel_32x32
        Me.btnUnselectAll.Location = New System.Drawing.Point(102, 5)
        Me.btnUnselectAll.Name = "btnUnselectAll"
        Me.btnUnselectAll.Size = New System.Drawing.Size(107, 38)
        Me.btnUnselectAll.TabIndex = 9
        Me.btnUnselectAll.Text = "Unselect All"
        '
        'btnSelectAll
        '
        Me.btnSelectAll.ImageOptions.Image = Global.FreelyCreative.StockItemInquiry.My.Resources.Resources.apply_32x322
        Me.btnSelectAll.Location = New System.Drawing.Point(5, 5)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(91, 38)
        Me.btnSelectAll.TabIndex = 8
        Me.btnSelectAll.Text = "Select All"
        '
        'PanelControl3
        '
        Me.PanelControl3.AutoSize = True
        Me.PanelControl3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PanelControl3.Controls.Add(Me.btnSubmitEInvoice)
        Me.PanelControl3.Controls.Add(Me.btnClose)
        Me.PanelControl3.Controls.Add(Me.btnInquiry)
        Me.PanelControl3.Controls.Add(Me.GroupControl1)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl3.Location = New System.Drawing.Point(2, 86)
        Me.PanelControl3.Margin = New System.Windows.Forms.Padding(0)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(970, 147)
        Me.PanelControl3.TabIndex = 1
        '
        'btnSubmitEInvoice
        '
        Me.btnSubmitEInvoice.ImageOptions.Image = Global.FreelyCreative.StockItemInquiry.My.Resources.Resources.send_32x32
        Me.btnSubmitEInvoice.Location = New System.Drawing.Point(366, 98)
        Me.btnSubmitEInvoice.Name = "btnSubmitEInvoice"
        Me.btnSubmitEInvoice.Size = New System.Drawing.Size(137, 42)
        Me.btnSubmitEInvoice.TabIndex = 9
        Me.btnSubmitEInvoice.Text = "Submit e-Invoice"
        '
        'btnClose
        '
        Me.btnClose.ImageOptions.Image = Global.FreelyCreative.StockItemInquiry.My.Resources.Resources.close_32x32
        Me.btnClose.Location = New System.Drawing.Point(102, 98)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(91, 42)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "Close"
        '
        'btnInquiry
        '
        Me.btnInquiry.ImageOptions.Image = Global.FreelyCreative.StockItemInquiry.My.Resources.Resources.database_32x32
        Me.btnInquiry.Location = New System.Drawing.Point(5, 98)
        Me.btnInquiry.Name = "btnInquiry"
        Me.btnInquiry.Size = New System.Drawing.Size(91, 42)
        Me.btnInquiry.TabIndex = 2
        Me.btnInquiry.Text = "Inquiry"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.UcDebtorSelector1)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.UcDateSelector1)
        Me.GroupControl1.Location = New System.Drawing.Point(5, 3)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(498, 89)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Basic Filter"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(14, 58)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Debtor:"
        '
        'UcDebtorSelector1
        '
        Me.UcDebtorSelector1.Location = New System.Drawing.Point(99, 55)
        Me.UcDebtorSelector1.Margin = New System.Windows.Forms.Padding(5)
        Me.UcDebtorSelector1.Name = "UcDebtorSelector1"
        Me.UcDebtorSelector1.Size = New System.Drawing.Size(394, 20)
        Me.UcDebtorSelector1.TabIndex = 2
        Me.UcDebtorSelector1.UseSearchLookup = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(14, 33)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Date Range:"
        '
        'UcDateSelector1
        '
        Me.UcDateSelector1.Location = New System.Drawing.Point(99, 29)
        Me.UcDateSelector1.Margin = New System.Windows.Forms.Padding(4)
        Me.UcDateSelector1.Name = "UcDateSelector1"
        Me.UcDateSelector1.Size = New System.Drawing.Size(394, 20)
        Me.UcDateSelector1.TabIndex = 0
        '
        'PanelControl2
        '
        Me.PanelControl2.AutoSize = True
        Me.PanelControl2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PanelControl2.Controls.Add(Me.PanelHeader1)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(2, 2)
        Me.PanelControl2.Margin = New System.Windows.Forms.Padding(0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(970, 84)
        Me.PanelControl2.TabIndex = 0
        '
        'PanelHeader1
        '
        Me.PanelHeader1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelHeader1.Header = "Cash Sale: Submit e-Invoice"
        Me.PanelHeader1.Hint = "Manage and submit e-Invoices for Cash Sale documents."
        Me.PanelHeader1.Location = New System.Drawing.Point(2, 2)
        Me.PanelHeader1.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelHeader1.Name = "PanelHeader1"
        Me.PanelHeader1.Size = New System.Drawing.Size(966, 80)
        Me.PanelHeader1.TabIndex = 0
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(998, 699)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.PanelControl1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(978, 679)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'bsReportCriteria
        '
        Me.bsReportCriteria.DataSource = GetType(FreelyCreative.StockItemInquiry.DocumentReportingModel.DocumentReportCriteria)
        '
        'frmSubmitEInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(998, 699)
        Me.Controls.Add(Me.LayoutControl1)
        Me.IconOptions.Image = CType(resources.GetObject("frmSubmitEInvoice.IconOptions.Image"), System.Drawing.Image)
        Me.Name = "frmSubmitEInvoice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cash Sale: Submit e-Invoice"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl5.ResumeLayout(False)
        CType(Me.gcCSTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsCSPendingEInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvCSPendingEInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkIsSubmitEInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkIsSelected, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkHasItemGenerateEInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsReportCriteria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Private WithEvents btnInquiry As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Private WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl5 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents UcDebtorSelector1 As AutoCount.Controls.FilterUI.UCDebtorSelector
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents UcDateSelector1 As AutoCount.Controls.FilterUI.UCDateSelector
    Friend WithEvents gcCSTable As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvCSPendingEInvoice As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents btnSelectAll As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents bsCSPendingEInvoice As BindingSource
    Friend WithEvents colDocNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDocDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDebtorCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDebtorName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNetTotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSubmitEInvoice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOutstanding As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents btnSubmitEInvoice As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Private WithEvents btnUnselectAll As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents colIsSelected As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents chkIsSelected As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents chkIsSubmitEInvoice As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelHeader1 As AutoCount.Controls.PanelHeader
    Friend WithEvents bsReportCriteria As BindingSource
    Friend WithEvents colItemGenerateEInvoice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents chkHasItemGenerateEInvoice As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents colEInvoiceStatus As DevExpress.XtraGrid.Columns.GridColumn
End Class
