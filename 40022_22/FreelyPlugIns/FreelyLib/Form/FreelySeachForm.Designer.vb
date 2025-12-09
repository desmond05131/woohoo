Namespace Freely.FormUI
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FreelySeachForm
        Inherits DevExpress.XtraEditors.XtraForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.pcFooter = New DevExpress.XtraEditors.PanelControl()
            Me.lblUnCheckAll = New DevExpress.XtraEditors.LabelControl()
            Me.lblSelectAll = New DevExpress.XtraEditors.LabelControl()
            Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
            Me.btnApply = New DevExpress.XtraEditors.SimpleButton()
            Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
            Me.gcFilter = New DevExpress.XtraGrid.GridControl()
            Me.bsFilter = New System.Windows.Forms.BindingSource(Me.components)
            Me.bsMaster = New System.Data.DataSet()
            Me.dtFilterMaster = New System.Data.DataTable()
            Me.dcSelect = New System.Data.DataColumn()
            Me.gvFilter = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.colIsSelect = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.chkSelect = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
            CType(Me.pcFooter, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pcFooter.SuspendLayout()
            CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl1.SuspendLayout()
            CType(Me.gcFilter, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsFilter, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsMaster, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dtFilterMaster, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.gvFilter, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.chkSelect, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'pcFooter
            '
            Me.pcFooter.Controls.Add(Me.lblUnCheckAll)
            Me.pcFooter.Controls.Add(Me.lblSelectAll)
            Me.pcFooter.Controls.Add(Me.btnClose)
            Me.pcFooter.Controls.Add(Me.btnApply)
            Me.pcFooter.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pcFooter.Location = New System.Drawing.Point(0, 248)
            Me.pcFooter.Name = "pcFooter"
            Me.pcFooter.Size = New System.Drawing.Size(545, 46)
            Me.pcFooter.TabIndex = 0
            '
            'lblUnCheckAll
            '
            Me.lblUnCheckAll.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
            Me.lblUnCheckAll.Appearance.ForeColor = System.Drawing.Color.Blue
            Me.lblUnCheckAll.Cursor = System.Windows.Forms.Cursors.Hand
            Me.lblUnCheckAll.Location = New System.Drawing.Point(76, 21)
            Me.lblUnCheckAll.Name = "lblUnCheckAll"
            Me.lblUnCheckAll.Size = New System.Drawing.Size(71, 13)
            Me.lblUnCheckAll.TabIndex = 3
            Me.lblUnCheckAll.Text = "Un-Check All"
            '
            'lblSelectAll
            '
            Me.lblSelectAll.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
            Me.lblSelectAll.Appearance.ForeColor = System.Drawing.Color.Blue
            Me.lblSelectAll.Cursor = System.Windows.Forms.Cursors.Hand
            Me.lblSelectAll.Location = New System.Drawing.Point(12, 21)
            Me.lblSelectAll.Name = "lblSelectAll"
            Me.lblSelectAll.Size = New System.Drawing.Size(52, 13)
            Me.lblSelectAll.TabIndex = 2
            Me.lblSelectAll.Text = "Select All"
            '
            'btnClose
            '
            Me.btnClose.Location = New System.Drawing.Point(458, 11)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(75, 23)
            Me.btnClose.TabIndex = 1
            Me.btnClose.Text = "Close"
            '
            'btnApply
            '
            Me.btnApply.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.btnApply.Appearance.Options.UseFont = True
            Me.btnApply.Location = New System.Drawing.Point(377, 11)
            Me.btnApply.Name = "btnApply"
            Me.btnApply.Size = New System.Drawing.Size(75, 23)
            Me.btnApply.TabIndex = 0
            Me.btnApply.Text = "Apply"
            '
            'PanelControl1
            '
            Me.PanelControl1.Controls.Add(Me.gcFilter)
            Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
            Me.PanelControl1.Name = "PanelControl1"
            Me.PanelControl1.Size = New System.Drawing.Size(545, 248)
            Me.PanelControl1.TabIndex = 1
            '
            'gcFilter
            '
            Me.gcFilter.DataSource = Me.bsFilter
            Me.gcFilter.Dock = System.Windows.Forms.DockStyle.Fill
            Me.gcFilter.Location = New System.Drawing.Point(2, 2)
            Me.gcFilter.MainView = Me.gvFilter
            Me.gcFilter.Name = "gcFilter"
            Me.gcFilter.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.chkSelect})
            Me.gcFilter.Size = New System.Drawing.Size(541, 244)
            Me.gcFilter.TabIndex = 0
            Me.gcFilter.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvFilter})
            '
            'bsFilter
            '
            Me.bsFilter.DataMember = "Master"
            Me.bsFilter.DataSource = Me.bsMaster
            '
            'bsMaster
            '
            Me.bsMaster.DataSetName = "NewDataSet"
            Me.bsMaster.Tables.AddRange(New System.Data.DataTable() {Me.dtFilterMaster})
            '
            'dtFilterMaster
            '
            Me.dtFilterMaster.Columns.AddRange(New System.Data.DataColumn() {Me.dcSelect})
            Me.dtFilterMaster.TableName = "Master"
            '
            'dcSelect
            '
            Me.dcSelect.Caption = "Select"
            Me.dcSelect.ColumnName = "IsSelect"
            Me.dcSelect.DefaultValue = "N"
            '
            'gvFilter
            '
            Me.gvFilter.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colIsSelect})
            Me.gvFilter.GridControl = Me.gcFilter
            Me.gvFilter.Name = "gvFilter"
            Me.gvFilter.OptionsBehavior.AllowIncrementalSearch = True
            Me.gvFilter.OptionsView.ShowAutoFilterRow = True
            Me.gvFilter.OptionsView.ShowGroupPanel = False
            '
            'colIsSelect
            '
            Me.colIsSelect.ColumnEdit = Me.chkSelect
            Me.colIsSelect.FieldName = "IsSelect"
            Me.colIsSelect.Name = "colIsSelect"
            Me.colIsSelect.Visible = True
            Me.colIsSelect.VisibleIndex = 0
            '
            'chkSelect
            '
            Me.chkSelect.AutoHeight = False
            Me.chkSelect.Caption = "Check"
            Me.chkSelect.Name = "chkSelect"
            Me.chkSelect.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
            Me.chkSelect.ValueChecked = "Y"
            Me.chkSelect.ValueGrayed = "N"
            Me.chkSelect.ValueUnchecked = "N"
            '
            'FreelySeachForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(545, 294)
            Me.Controls.Add(Me.PanelControl1)
            Me.Controls.Add(Me.pcFooter)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
            Me.Name = "FreelySeachForm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Search"
            CType(Me.pcFooter, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pcFooter.ResumeLayout(False)
            Me.pcFooter.PerformLayout()
            CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl1.ResumeLayout(False)
            CType(Me.gcFilter, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsFilter, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsMaster, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dtFilterMaster, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.gvFilter, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.chkSelect, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents pcFooter As DevExpress.XtraEditors.PanelControl
        Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
        Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnApply As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents bsMaster As System.Data.DataSet
        Friend WithEvents dtFilterMaster As System.Data.DataTable
        Friend WithEvents dcSelect As System.Data.DataColumn
        Friend WithEvents gcFilter As DevExpress.XtraGrid.GridControl
        Friend WithEvents gvFilter As DevExpress.XtraGrid.Views.Grid.GridView
        Friend WithEvents bsFilter As System.Windows.Forms.BindingSource
        Friend WithEvents colIsSelect As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents chkSelect As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Friend WithEvents lblUnCheckAll As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblSelectAll As DevExpress.XtraEditors.LabelControl
    End Class
End Namespace