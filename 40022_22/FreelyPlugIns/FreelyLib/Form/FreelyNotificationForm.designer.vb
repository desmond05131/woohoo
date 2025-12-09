Namespace Freely.FormUI.Notification
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FreelyNotificationForm
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
            Me.lifeTimer = New System.Windows.Forms.Timer()
            Me.lblHeader = New DevExpress.XtraEditors.LabelControl()
            Me.pcMain = New DevExpress.XtraEditors.PanelControl()
            Me.gcHeader = New DevExpress.XtraEditors.GroupControl()
            Me.TabMaster = New DevExpress.XtraTab.XtraTabControl()
            Me.PageSingleLine = New DevExpress.XtraTab.XtraTabPage()
            Me.lblMessage = New DevExpress.XtraEditors.LabelControl()
            Me.PageGrid = New DevExpress.XtraTab.XtraTabPage()
            Me.gcData = New DevExpress.XtraGrid.GridControl()
            Me.gvView = New DevExpress.XtraGrid.Views.Grid.GridView()
            CType(Me.pcMain, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pcMain.SuspendLayout()
            CType(Me.gcHeader, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.gcHeader.SuspendLayout()
            CType(Me.TabMaster, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabMaster.SuspendLayout()
            Me.PageSingleLine.SuspendLayout()
            Me.PageGrid.SuspendLayout()
            CType(Me.gcData, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.gvView, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lifeTimer
            '
            Me.lifeTimer.Interval = 2500
            '
            'lblHeader
            '
            Me.lblHeader.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.lblHeader.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.lblHeader.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            Me.lblHeader.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
            Me.lblHeader.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
            Me.lblHeader.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblHeader.Location = New System.Drawing.Point(2, 2)
            Me.lblHeader.Name = "lblHeader"
            Me.lblHeader.Size = New System.Drawing.Size(288, 49)
            Me.lblHeader.TabIndex = 0
            Me.lblHeader.Text = "Welcome"
            '
            'pcMain
            '
            Me.pcMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
            Me.pcMain.Controls.Add(Me.gcHeader)
            Me.pcMain.Controls.Add(Me.lblHeader)
            Me.pcMain.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pcMain.Location = New System.Drawing.Point(0, 0)
            Me.pcMain.Name = "pcMain"
            Me.pcMain.Size = New System.Drawing.Size(292, 266)
            Me.pcMain.TabIndex = 1
            '
            'gcHeader
            '
            Me.gcHeader.Controls.Add(Me.TabMaster)
            Me.gcHeader.Dock = System.Windows.Forms.DockStyle.Fill
            Me.gcHeader.Location = New System.Drawing.Point(2, 51)
            Me.gcHeader.Name = "gcHeader"
            Me.gcHeader.Size = New System.Drawing.Size(288, 213)
            Me.gcHeader.TabIndex = 1
            Me.gcHeader.Text = "Notification Message"
            '
            'TabMaster
            '
            Me.TabMaster.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabMaster.Location = New System.Drawing.Point(2, 21)
            Me.TabMaster.Name = "TabMaster"
            Me.TabMaster.SelectedTabPage = Me.PageSingleLine
            Me.TabMaster.Size = New System.Drawing.Size(284, 190)
            Me.TabMaster.TabIndex = 0
            Me.TabMaster.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.PageSingleLine, Me.PageGrid})
            '
            'PageSingleLine
            '
            Me.PageSingleLine.Controls.Add(Me.lblMessage)
            Me.PageSingleLine.Name = "PageSingleLine"
            Me.PageSingleLine.Size = New System.Drawing.Size(278, 162)
            Me.PageSingleLine.Text = "Single Line"
            '
            'lblMessage
            '
            Me.lblMessage.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Underline)
            Me.lblMessage.Appearance.ForeColor = System.Drawing.Color.Blue
            Me.lblMessage.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
            Me.lblMessage.Cursor = System.Windows.Forms.Cursors.Hand
            Me.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblMessage.Location = New System.Drawing.Point(0, 0)
            Me.lblMessage.Name = "lblMessage"
            Me.lblMessage.Size = New System.Drawing.Size(278, 162)
            Me.lblMessage.TabIndex = 0
            '
            'PageGrid
            '
            Me.PageGrid.Controls.Add(Me.gcData)
            Me.PageGrid.Name = "PageGrid"
            Me.PageGrid.Size = New System.Drawing.Size(278, 162)
            Me.PageGrid.Text = "Grid"
            '
            'gcData
            '
            Me.gcData.Dock = System.Windows.Forms.DockStyle.Fill
            Me.gcData.Location = New System.Drawing.Point(0, 0)
            Me.gcData.MainView = Me.gvView
            Me.gcData.Name = "gcData"
            Me.gcData.Size = New System.Drawing.Size(278, 162)
            Me.gcData.TabIndex = 0
            Me.gcData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvView})
            '
            'gvView
            '
            Me.gvView.GridControl = Me.gcData
            Me.gvView.Name = "gvView"
            Me.gvView.OptionsBehavior.Editable = False
            Me.gvView.OptionsView.ShowGroupPanel = False
            '
            'FreelyNotificationForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(292, 266)
            Me.Controls.Add(Me.pcMain)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Name = "FreelyNotificationForm"
            Me.Text = "Freely Notification Form"
            Me.TopMost = True
            CType(Me.pcMain, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pcMain.ResumeLayout(False)
            CType(Me.gcHeader, System.ComponentModel.ISupportInitialize).EndInit()
            Me.gcHeader.ResumeLayout(False)
            CType(Me.TabMaster, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabMaster.ResumeLayout(False)
            Me.PageSingleLine.ResumeLayout(False)
            Me.PageGrid.ResumeLayout(False)
            CType(Me.gcData, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.gvView, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents lifeTimer As System.Windows.Forms.Timer
        Friend WithEvents lblHeader As DevExpress.XtraEditors.LabelControl
        Friend WithEvents pcMain As DevExpress.XtraEditors.PanelControl
        Friend WithEvents gcHeader As DevExpress.XtraEditors.GroupControl
        Friend WithEvents TabMaster As DevExpress.XtraTab.XtraTabControl
        Friend WithEvents PageSingleLine As DevExpress.XtraTab.XtraTabPage
        Friend WithEvents PageGrid As DevExpress.XtraTab.XtraTabPage
        Friend WithEvents lblMessage As DevExpress.XtraEditors.LabelControl
        Friend WithEvents gcData As DevExpress.XtraGrid.GridControl
        Friend WithEvents gvView As DevExpress.XtraGrid.Views.Grid.GridView
    End Class
End Namespace
