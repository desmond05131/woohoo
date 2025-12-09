<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcFilter
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.lblMultiSelectPart = New DevExpress.XtraEditors.LabelControl()
        Me.lblToPart = New DevExpress.XtraEditors.LabelControl()
        Me.luToPart = New DevExpress.XtraEditors.LookUpEdit()
        Me.luFromPart = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblFromPart = New DevExpress.XtraEditors.LabelControl()
        Me.comboType = New DevExpress.XtraEditors.ComboBoxEdit()
        CType(Me.luToPart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.luFromPart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.comboType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblMultiSelectPart
        '
        Me.lblMultiSelectPart.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Underline)
        Me.lblMultiSelectPart.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.lblMultiSelectPart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblMultiSelectPart.Location = New System.Drawing.Point(137, 6)
        Me.lblMultiSelectPart.Name = "lblMultiSelectPart"
        Me.lblMultiSelectPart.Size = New System.Drawing.Size(109, 13)
        Me.lblMultiSelectPart.TabIndex = 37
        Me.lblMultiSelectPart.Text = "0 Record was Selected"
        '
        'lblToPart
        '
        Me.lblToPart.Location = New System.Drawing.Point(258, 6)
        Me.lblToPart.Name = "lblToPart"
        Me.lblToPart.Size = New System.Drawing.Size(10, 13)
        Me.lblToPart.TabIndex = 36
        Me.lblToPart.Text = "to"
        '
        'luToPart
        '
        Me.luToPart.Location = New System.Drawing.Point(272, 3)
        Me.luToPart.Name = "luToPart"
        Me.luToPart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.luToPart.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerPartNo", "Customer Part No", 95, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ItemCode", "Item Code", 73, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description ", "Description ", 66, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near)})
        Me.luToPart.Properties.DisplayMember = "CustomerPartNo"
        Me.luToPart.Properties.NullText = ""
        Me.luToPart.Properties.PopupFormMinSize = New System.Drawing.Size(400, 0)
        Me.luToPart.Properties.ValueMember = "CustomerPartNo"
        Me.luToPart.Size = New System.Drawing.Size(89, 20)
        Me.luToPart.TabIndex = 35
        '
        'luFromPart
        '
        Me.luFromPart.EnterMoveNextControl = True
        Me.luFromPart.Location = New System.Drawing.Point(167, 4)
        Me.luFromPart.Name = "luFromPart"
        Me.luFromPart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.luFromPart.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerPartNo", "Customer Part No", 70, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ItemCode", "Item Code", 70, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description ", "Description", 130, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near)})
        Me.luFromPart.Properties.DisplayMember = "CustomerPartNo"
        Me.luFromPart.Properties.NullText = ""
        Me.luFromPart.Properties.PopupFormMinSize = New System.Drawing.Size(400, 0)
        Me.luFromPart.Properties.ValueMember = "CustomerPartNo"
        Me.luFromPart.Size = New System.Drawing.Size(86, 20)
        Me.luFromPart.TabIndex = 34
        '
        'lblFromPart
        '
        Me.lblFromPart.Location = New System.Drawing.Point(137, 7)
        Me.lblFromPart.Name = "lblFromPart"
        Me.lblFromPart.Size = New System.Drawing.Size(22, 13)
        Me.lblFromPart.TabIndex = 33
        Me.lblFromPart.Text = "from"
        '
        'comboType
        '
        Me.comboType.EditValue = "No Filter"
        Me.comboType.Location = New System.Drawing.Point(3, 3)
        Me.comboType.Name = "comboType"
        Me.comboType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.comboType.Properties.Items.AddRange(New Object() {"No Filter", "Filter By Range", "Filter By Multi-Select"})
        Me.comboType.Properties.NullText = "No Filter"
        Me.comboType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.comboType.Size = New System.Drawing.Size(128, 20)
        Me.comboType.TabIndex = 32
        '
        'UcFilter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblMultiSelectPart)
        Me.Controls.Add(Me.lblToPart)
        Me.Controls.Add(Me.luToPart)
        Me.Controls.Add(Me.luFromPart)
        Me.Controls.Add(Me.lblFromPart)
        Me.Controls.Add(Me.comboType)
        Me.Name = "UcFilter"
        Me.Size = New System.Drawing.Size(367, 28)
        CType(Me.luToPart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.luFromPart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.comboType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblMultiSelectPart As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblToPart As DevExpress.XtraEditors.LabelControl
    Friend WithEvents luToPart As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents luFromPart As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblFromPart As DevExpress.XtraEditors.LabelControl
    Friend WithEvents comboType As DevExpress.XtraEditors.ComboBoxEdit
End Class
