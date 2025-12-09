Namespace Freely.Utli.PivotGrid

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DialogSaveLayout
        Inherits DevExpress.XtraEditors.XtraForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
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
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.pcBottom = New DevExpress.XtraEditors.PanelControl()
            Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
            Me.btnApply = New DevExpress.XtraEditors.SimpleButton()
            Me.txtTitle = New DevExpress.XtraEditors.TextEdit()
            Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
            Me.pcMain = New DevExpress.XtraEditors.PanelControl()
            Me.gcSaveLayout = New DevExpress.XtraGrid.GridControl()
            Me.bsLayout = New System.Windows.Forms.BindingSource(Me.components)
            Me.dsSaveLayout = New System.Data.DataSet()
            Me.dtSave = New System.Data.DataTable()
            Me.DataColumn1 = New System.Data.DataColumn()
            Me.gvSaveLayout = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.colTitle = New DevExpress.XtraGrid.Columns.GridColumn()
            CType(Me.pcBottom, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pcBottom.SuspendLayout()
            CType(Me.txtTitle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.pcMain, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pcMain.SuspendLayout()
            CType(Me.gcSaveLayout, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsLayout, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dsSaveLayout, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dtSave, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.gvSaveLayout, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'pcBottom
            '
            Me.pcBottom.Controls.Add(Me.btnClose)
            Me.pcBottom.Controls.Add(Me.btnApply)
            Me.pcBottom.Controls.Add(Me.txtTitle)
            Me.pcBottom.Controls.Add(Me.LabelControl1)
            Me.pcBottom.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pcBottom.Location = New System.Drawing.Point(0, 222)
            Me.pcBottom.Name = "pcBottom"
            Me.pcBottom.Size = New System.Drawing.Size(514, 100)
            Me.pcBottom.TabIndex = 0
            '
            'btnClose
            '
            Me.btnClose.Location = New System.Drawing.Point(253, 44)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(75, 23)
            Me.btnClose.TabIndex = 3
            Me.btnClose.Text = "Close"
            '
            'btnApply
            '
            Me.btnApply.Location = New System.Drawing.Point(172, 43)
            Me.btnApply.Name = "btnApply"
            Me.btnApply.Size = New System.Drawing.Size(75, 23)
            Me.btnApply.TabIndex = 2
            Me.btnApply.Text = "Apply"
            '
            'txtTitle
            '
            Me.txtTitle.Location = New System.Drawing.Point(134, 17)
            Me.txtTitle.Name = "txtTitle"
            Me.txtTitle.Size = New System.Drawing.Size(267, 20)
            Me.txtTitle.TabIndex = 1
            '
            'LabelControl1
            '
            Me.LabelControl1.Location = New System.Drawing.Point(58, 20)
            Me.LabelControl1.Name = "LabelControl1"
            Me.LabelControl1.Size = New System.Drawing.Size(70, 13)
            Me.LabelControl1.TabIndex = 0
            Me.LabelControl1.Text = "Layout Name :"
            '
            'pcMain
            '
            Me.pcMain.Controls.Add(Me.gcSaveLayout)
            Me.pcMain.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pcMain.Location = New System.Drawing.Point(0, 0)
            Me.pcMain.Name = "pcMain"
            Me.pcMain.Size = New System.Drawing.Size(514, 222)
            Me.pcMain.TabIndex = 1
            '
            'gcSaveLayout
            '
            Me.gcSaveLayout.DataSource = Me.bsLayout
            Me.gcSaveLayout.Dock = System.Windows.Forms.DockStyle.Fill
            Me.gcSaveLayout.Location = New System.Drawing.Point(2, 2)
            Me.gcSaveLayout.MainView = Me.gvSaveLayout
            Me.gcSaveLayout.Name = "gcSaveLayout"
            Me.gcSaveLayout.Size = New System.Drawing.Size(510, 218)
            Me.gcSaveLayout.TabIndex = 0
            Me.gcSaveLayout.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvSaveLayout})
            '
            'bsLayout
            '
            Me.bsLayout.DataMember = "Save"
            Me.bsLayout.DataSource = Me.dsSaveLayout
            '
            'dsSaveLayout
            '
            Me.dsSaveLayout.DataSetName = "NewDataSet"
            Me.dsSaveLayout.Tables.AddRange(New System.Data.DataTable() {Me.dtSave})
            '
            'dtSave
            '
            Me.dtSave.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1})
            Me.dtSave.TableName = "Save"
            '
            'DataColumn1
            '
            Me.DataColumn1.ColumnName = "Title"
            '
            'gvSaveLayout
            '
            Me.gvSaveLayout.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colTitle})
            Me.gvSaveLayout.GridControl = Me.gcSaveLayout
            Me.gvSaveLayout.Name = "gvSaveLayout"
            Me.gvSaveLayout.OptionsBehavior.Editable = False
            Me.gvSaveLayout.OptionsView.ShowGroupPanel = False
            '
            'colTitle
            '
            Me.colTitle.FieldName = "Title"
            Me.colTitle.Name = "colTitle"
            Me.colTitle.Visible = True
            Me.colTitle.VisibleIndex = 0
            '
            'DialogSaveLayout
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(514, 322)
            Me.Controls.Add(Me.pcMain)
            Me.Controls.Add(Me.pcBottom)
            Me.Name = "DialogSaveLayout"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "DialogSaveLayout"
            CType(Me.pcBottom, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pcBottom.ResumeLayout(False)
            Me.pcBottom.PerformLayout()
            CType(Me.txtTitle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.pcMain, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pcMain.ResumeLayout(False)
            CType(Me.gcSaveLayout, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsLayout, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dsSaveLayout, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dtSave, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.gvSaveLayout, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents pcBottom As DevExpress.XtraEditors.PanelControl
        Friend WithEvents pcMain As DevExpress.XtraEditors.PanelControl
        Friend WithEvents gcSaveLayout As DevExpress.XtraGrid.GridControl
        Friend WithEvents gvSaveLayout As DevExpress.XtraGrid.Views.Grid.GridView
        Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
        Friend WithEvents txtTitle As DevExpress.XtraEditors.TextEdit
        Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnApply As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents dsSaveLayout As System.Data.DataSet
        Friend WithEvents dtSave As System.Data.DataTable
        Friend WithEvents DataColumn1 As System.Data.DataColumn
        Friend WithEvents bsLayout As System.Windows.Forms.BindingSource
        Friend WithEvents colTitle As DevExpress.XtraGrid.Columns.GridColumn
    End Class
End Namespace
