Namespace Freely.Utli.PivotGrid


    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DialogLoadLayout
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
            Me.pcMain = New DevExpress.XtraEditors.PanelControl()
            Me.gcLoadLayout = New DevExpress.XtraGrid.GridControl()
            Me.bsLayout = New System.Windows.Forms.BindingSource(Me.components)
            Me.dsSaveLayout = New System.Data.DataSet()
            Me.dtSave = New System.Data.DataTable()
            Me.DataColumn1 = New System.Data.DataColumn()
            Me.gvLoadLayout = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.colTitle = New DevExpress.XtraGrid.Columns.GridColumn()
            CType(Me.pcMain, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pcMain.SuspendLayout()
            CType(Me.gcLoadLayout, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsLayout, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dsSaveLayout, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dtSave, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.gvLoadLayout, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'pcMain
            '
            Me.pcMain.Controls.Add(Me.gcLoadLayout)
            Me.pcMain.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pcMain.Location = New System.Drawing.Point(0, 0)
            Me.pcMain.Name = "pcMain"
            Me.pcMain.Size = New System.Drawing.Size(514, 322)
            Me.pcMain.TabIndex = 0
            '
            'gcLoadLayout
            '
            Me.gcLoadLayout.DataSource = Me.bsLayout
            Me.gcLoadLayout.Dock = System.Windows.Forms.DockStyle.Fill
            Me.gcLoadLayout.Location = New System.Drawing.Point(2, 2)
            Me.gcLoadLayout.MainView = Me.gvLoadLayout
            Me.gcLoadLayout.Name = "gcLoadLayout"
            Me.gcLoadLayout.Size = New System.Drawing.Size(510, 318)
            Me.gcLoadLayout.TabIndex = 0
            Me.gcLoadLayout.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvLoadLayout})
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
            'gvLoadLayout
            '
            Me.gvLoadLayout.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colTitle})
            Me.gvLoadLayout.GridControl = Me.gcLoadLayout
            Me.gvLoadLayout.Name = "gvLoadLayout"
            Me.gvLoadLayout.OptionsBehavior.Editable = False
            Me.gvLoadLayout.OptionsView.ShowGroupPanel = False
            '
            'colTitle
            '
            Me.colTitle.FieldName = "Title"
            Me.colTitle.Name = "colTitle"
            Me.colTitle.Visible = True
            Me.colTitle.VisibleIndex = 0
            '
            'DialogLoadLayout
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(514, 322)
            Me.Controls.Add(Me.pcMain)
            Me.Name = "DialogLoadLayout"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "DialogLoadLayout"
            CType(Me.pcMain, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pcMain.ResumeLayout(False)
            CType(Me.gcLoadLayout, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsLayout, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dsSaveLayout, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dtSave, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.gvLoadLayout, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents pcMain As DevExpress.XtraEditors.PanelControl
        Friend WithEvents gcLoadLayout As DevExpress.XtraGrid.GridControl
        Friend WithEvents gvLoadLayout As DevExpress.XtraGrid.Views.Grid.GridView
        Friend WithEvents dsSaveLayout As System.Data.DataSet
        Friend WithEvents dtSave As System.Data.DataTable
        Friend WithEvents DataColumn1 As System.Data.DataColumn
        Friend WithEvents bsLayout As System.Windows.Forms.BindingSource
        Friend WithEvents colTitle As DevExpress.XtraGrid.Columns.GridColumn
    End Class
End Namespace