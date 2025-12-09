<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPlugInGeneralSetup
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.pcFooter = New DevExpress.XtraEditors.PanelControl()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.sqlConn = New System.Data.SqlClient.SqlConnection()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.chkIsExchange = New DevExpress.XtraEditors.CheckEdit()
        Me.lblOutgoingServer = New DevExpress.XtraEditors.LabelControl()
        Me.btnTest = New DevExpress.XtraEditors.SimpleButton()
        Me.txtOutGoing = New DevExpress.XtraEditors.TextEdit()
        Me.txtName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.txtPort = New DevExpress.XtraEditors.TextEdit()
        Me.txtSubject = New DevExpress.XtraEditors.TextEdit()
        Me.chkUseSSL = New DevExpress.XtraEditors.CheckEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.chkUsePassword = New DevExpress.XtraEditors.CheckEdit()
        Me.txtDomainName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.txtTimeOut = New DevExpress.XtraEditors.TextEdit()
        Me.lpProtocolType = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtUserName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.txtPassword = New DevExpress.XtraEditors.TextEdit()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabPage3 = New DevExpress.XtraTab.XtraTabPage()
        Me.btnDataBase = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl16 = New DevExpress.XtraEditors.LabelControl()
        Me.txtDBase = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.txtServer = New DevExpress.XtraEditors.TextEdit()
        Me.btnServer = New DevExpress.XtraEditors.SimpleButton()
        Me.chkUserSA = New DevExpress.XtraEditors.CheckEdit()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.txtSAPasswrd = New DevExpress.XtraEditors.TextEdit()
        Me.txtSAID = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.txtPasswrd = New DevExpress.XtraEditors.TextEdit()
        Me.txtUserID = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.btnEdit = New DevExpress.XtraEditors.ButtonEdit()
        Me.PanelHeader1 = New AutoCount.Controls.PanelHeader()
        Me.dsGeneral = New System.Data.DataSet()
        Me.dtGeneralSetup = New System.Data.DataTable()
        Me.dtEamil = New System.Data.DataTable()
        Me.dcEmailAcc = New System.Data.DataColumn()
        Me.dcEmailPasswd = New System.Data.DataColumn()
        Me.dcEmailOutgoing = New System.Data.DataColumn()
        Me.dcEmailPort = New System.Data.DataColumn()
        Me.dcEmailTimeOut = New System.Data.DataColumn()
        Me.dcEmailDomainName = New System.Data.DataColumn()
        Me.dcEmailDefaulSub = New System.Data.DataColumn()
        Me.dcEmailDefaultName = New System.Data.DataColumn()
        Me.dcEmailSecurity = New System.Data.DataColumn()
        Me.dcEmailSSL = New System.Data.DataColumn()
        Me.dcEmailUsePass = New System.Data.DataColumn()
        Me.dcEmailSec = New System.Data.DataColumn()
        Me.dcEmailPerson = New System.Data.DataColumn()
        Me.DataColumn1 = New System.Data.DataColumn()
        Me.DataColumn4 = New System.Data.DataColumn()
        Me.DataColumn5 = New System.Data.DataColumn()
        Me.dtEmailAcc = New System.Data.DataTable()
        Me.EmailAcc = New System.Data.DataColumn()
        Me.dtSecurityProtocol = New System.Data.DataTable()
        Me.dcType = New System.Data.DataColumn()
        Me.dcDescription = New System.Data.DataColumn()
        Me.dtReport = New System.Data.DataTable()
        Me.DataColumn2 = New System.Data.DataColumn()
        Me.DataColumn3 = New System.Data.DataColumn()
        Me.bsEmailAcc = New System.Windows.Forms.BindingSource(Me.components)
        Me.bsGeneral = New System.Windows.Forms.BindingSource(Me.components)
        Me.bsEmail = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsXML = New System.Data.DataSet()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.pcFooter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pcFooter.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.chkIsExchange.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOutGoing.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPort.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSubject.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkUseSSL.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkUsePassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDomainName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTimeOut.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lpProtocolType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUserName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage3.SuspendLayout()
        CType(Me.txtDBase.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtServer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkUserSA.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSAPasswrd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSAID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPasswrd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUserID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtGeneralSetup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtEamil, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtEmailAcc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtSecurityProtocol, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtReport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsEmailAcc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsXML, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pcFooter
        '
        Me.pcFooter.Controls.Add(Me.btnSave)
        Me.pcFooter.Controls.Add(Me.btnClose)
        Me.pcFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pcFooter.Location = New System.Drawing.Point(0, 472)
        Me.pcFooter.Name = "pcFooter"
        Me.pcFooter.Size = New System.Drawing.Size(712, 36)
        Me.pcFooter.TabIndex = 1
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(544, 6)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(625, 6)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "Close"
        '
        'sqlConn
        '
        Me.sqlConn.FireInfoMessageEventOnUserErrors = False
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LayoutControl1)
        Me.PanelControl1.Controls.Add(Me.PanelHeader1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(712, 472)
        Me.PanelControl1.TabIndex = 6
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.XtraTabControl1)
        Me.PanelControl2.Location = New System.Drawing.Point(12, 12)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(684, 380)
        Me.PanelControl2.TabIndex = 12
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(2, 2)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(680, 376)
        Me.XtraTabControl1.TabIndex = 0
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2, Me.XtraTabPage3})
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.LabelControl9)
        Me.XtraTabPage2.Controls.Add(Me.LabelControl3)
        Me.XtraTabPage2.Controls.Add(Me.chkIsExchange)
        Me.XtraTabPage2.Controls.Add(Me.lblOutgoingServer)
        Me.XtraTabPage2.Controls.Add(Me.btnTest)
        Me.XtraTabPage2.Controls.Add(Me.txtOutGoing)
        Me.XtraTabPage2.Controls.Add(Me.txtName)
        Me.XtraTabPage2.Controls.Add(Me.LabelControl1)
        Me.XtraTabPage2.Controls.Add(Me.LabelControl8)
        Me.XtraTabPage2.Controls.Add(Me.txtPort)
        Me.XtraTabPage2.Controls.Add(Me.txtSubject)
        Me.XtraTabPage2.Controls.Add(Me.chkUseSSL)
        Me.XtraTabPage2.Controls.Add(Me.LabelControl7)
        Me.XtraTabPage2.Controls.Add(Me.chkUsePassword)
        Me.XtraTabPage2.Controls.Add(Me.txtDomainName)
        Me.XtraTabPage2.Controls.Add(Me.LabelControl2)
        Me.XtraTabPage2.Controls.Add(Me.LabelControl6)
        Me.XtraTabPage2.Controls.Add(Me.txtTimeOut)
        Me.XtraTabPage2.Controls.Add(Me.lpProtocolType)
        Me.XtraTabPage2.Controls.Add(Me.txtUserName)
        Me.XtraTabPage2.Controls.Add(Me.LabelControl5)
        Me.XtraTabPage2.Controls.Add(Me.LabelControl4)
        Me.XtraTabPage2.Controls.Add(Me.txtPassword)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.PageVisible = False
        Me.XtraTabPage2.Size = New System.Drawing.Size(698, 372)
        Me.XtraTabPage2.Text = "Email Setting"
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl9.Appearance.ForeColor = System.Drawing.Color.DodgerBlue
        Me.LabelControl9.Appearance.Options.UseFont = True
        Me.LabelControl9.Appearance.Options.UseForeColor = True
        Me.LabelControl9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelControl9.Location = New System.Drawing.Point(356, 80)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(127, 13)
        Me.LabelControl9.TabIndex = 74
        Me.LabelControl9.Text = "Turn off Gmail less secure."
        Me.LabelControl9.ToolTip = "For Gmail account only."
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(70, 28)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(59, 13)
        Me.LabelControl3.TabIndex = 60
        Me.LabelControl3.Text = "User Name :"
        '
        'chkIsExchange
        '
        Me.chkIsExchange.Location = New System.Drawing.Point(354, 182)
        Me.chkIsExchange.Name = "chkIsExchange"
        Me.chkIsExchange.Properties.Caption = "Is Microsoft Exchange?"
        Me.chkIsExchange.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        Me.chkIsExchange.Properties.ValueChecked = "T"
        Me.chkIsExchange.Properties.ValueGrayed = "F"
        Me.chkIsExchange.Properties.ValueUnchecked = "F"
        Me.chkIsExchange.Size = New System.Drawing.Size(143, 19)
        Me.chkIsExchange.TabIndex = 72
        '
        'lblOutgoingServer
        '
        Me.lblOutgoingServer.Location = New System.Drawing.Point(43, 80)
        Me.lblOutgoingServer.Name = "lblOutgoingServer"
        Me.lblOutgoingServer.Size = New System.Drawing.Size(86, 13)
        Me.lblOutgoingServer.TabIndex = 52
        Me.lblOutgoingServer.Text = "Outgoing Server :"
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(511, 24)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(124, 23)
        Me.btnTest.TabIndex = 73
        Me.btnTest.Text = "Test Account Setting..."
        '
        'txtOutGoing
        '
        Me.txtOutGoing.Location = New System.Drawing.Point(137, 77)
        Me.txtOutGoing.Name = "txtOutGoing"
        Me.txtOutGoing.Size = New System.Drawing.Size(211, 20)
        Me.txtOutGoing.TabIndex = 53
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(137, 207)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(211, 20)
        Me.txtName.TabIndex = 71
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(102, 106)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(27, 13)
        Me.LabelControl1.TabIndex = 54
        Me.LabelControl1.Text = "Port :"
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(57, 210)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(72, 13)
        Me.LabelControl8.TabIndex = 70
        Me.LabelControl8.Text = "Default Name :"
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(137, 103)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Properties.Mask.EditMask = "d"
        Me.txtPort.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtPort.Size = New System.Drawing.Size(100, 20)
        Me.txtPort.TabIndex = 55
        '
        'txtSubject
        '
        Me.txtSubject.Location = New System.Drawing.Point(137, 233)
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Size = New System.Drawing.Size(211, 20)
        Me.txtSubject.TabIndex = 69
        '
        'chkUseSSL
        '
        Me.chkUseSSL.EditValue = "T"
        Me.chkUseSSL.Location = New System.Drawing.Point(354, 26)
        Me.chkUseSSL.Name = "chkUseSSL"
        Me.chkUseSSL.Properties.Caption = "Use SSL"
        Me.chkUseSSL.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        Me.chkUseSSL.Properties.ValueChecked = "T"
        Me.chkUseSSL.Properties.ValueGrayed = "F"
        Me.chkUseSSL.Properties.ValueUnchecked = "F"
        Me.chkUseSSL.Size = New System.Drawing.Size(75, 19)
        Me.chkUseSSL.TabIndex = 56
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(45, 236)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(81, 13)
        Me.LabelControl7.TabIndex = 68
        Me.LabelControl7.Text = "Default Subject :"
        '
        'chkUsePassword
        '
        Me.chkUsePassword.EditValue = "T"
        Me.chkUsePassword.Location = New System.Drawing.Point(354, 51)
        Me.chkUsePassword.Name = "chkUsePassword"
        Me.chkUsePassword.Properties.Caption = "Use Password"
        Me.chkUsePassword.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        Me.chkUsePassword.Properties.ValueChecked = "T"
        Me.chkUsePassword.Properties.ValueGrayed = "F"
        Me.chkUsePassword.Properties.ValueUnchecked = "F"
        Me.chkUsePassword.Size = New System.Drawing.Size(100, 19)
        Me.chkUsePassword.TabIndex = 57
        '
        'txtDomainName
        '
        Me.txtDomainName.Location = New System.Drawing.Point(137, 181)
        Me.txtDomainName.Name = "txtDomainName"
        Me.txtDomainName.Size = New System.Drawing.Size(211, 20)
        Me.txtDomainName.TabIndex = 67
        Me.txtDomainName.ToolTip = "For Microsoft Exchange only."
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(79, 132)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl2.TabIndex = 58
        Me.LabelControl2.Text = "Time Out :"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(57, 184)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(72, 13)
        Me.LabelControl6.TabIndex = 66
        Me.LabelControl6.Text = "Domain Name :"
        '
        'txtTimeOut
        '
        Me.txtTimeOut.Location = New System.Drawing.Point(137, 129)
        Me.txtTimeOut.Name = "txtTimeOut"
        Me.txtTimeOut.Properties.Mask.EditMask = "d"
        Me.txtTimeOut.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtTimeOut.Size = New System.Drawing.Size(100, 20)
        Me.txtTimeOut.TabIndex = 59
        '
        'lpProtocolType
        '
        Me.lpProtocolType.Location = New System.Drawing.Point(137, 155)
        Me.lpProtocolType.Name = "lpProtocolType"
        Me.lpProtocolType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lpProtocolType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Type", "Type", 47, DevExpress.Utils.FormatType.Numeric, "", True, DevExpress.Utils.HorzAlignment.Center, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", "Description", 63, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.lpProtocolType.Properties.DisplayMember = "Description"
        Me.lpProtocolType.Properties.NullText = ""
        Me.lpProtocolType.Properties.ValueMember = "Type"
        Me.lpProtocolType.Size = New System.Drawing.Size(211, 20)
        Me.lpProtocolType.TabIndex = 65
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(137, 25)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(211, 20)
        Me.txtUserName.TabIndex = 61
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(14, 158)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(115, 13)
        Me.LabelControl5.TabIndex = 64
        Me.LabelControl5.Text = "Security Protocol Type :"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(76, 54)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl4.TabIndex = 62
        Me.LabelControl4.Text = "Password :"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(137, 51)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Properties.UseSystemPasswordChar = True
        Me.txtPassword.Size = New System.Drawing.Size(211, 20)
        Me.txtPassword.TabIndex = 63
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(674, 348)
        Me.XtraTabPage1.Text = "General"
        '
        'XtraTabPage3
        '
        Me.XtraTabPage3.Controls.Add(Me.btnDataBase)
        Me.XtraTabPage3.Controls.Add(Me.LabelControl16)
        Me.XtraTabPage3.Controls.Add(Me.txtDBase)
        Me.XtraTabPage3.Controls.Add(Me.LabelControl15)
        Me.XtraTabPage3.Controls.Add(Me.txtServer)
        Me.XtraTabPage3.Controls.Add(Me.btnServer)
        Me.XtraTabPage3.Controls.Add(Me.chkUserSA)
        Me.XtraTabPage3.Controls.Add(Me.LabelControl13)
        Me.XtraTabPage3.Controls.Add(Me.LabelControl14)
        Me.XtraTabPage3.Controls.Add(Me.txtSAPasswrd)
        Me.XtraTabPage3.Controls.Add(Me.txtSAID)
        Me.XtraTabPage3.Controls.Add(Me.LabelControl12)
        Me.XtraTabPage3.Controls.Add(Me.LabelControl11)
        Me.XtraTabPage3.Controls.Add(Me.txtPasswrd)
        Me.XtraTabPage3.Controls.Add(Me.txtUserID)
        Me.XtraTabPage3.Controls.Add(Me.LabelControl10)
        Me.XtraTabPage3.Controls.Add(Me.btnEdit)
        Me.XtraTabPage3.Name = "XtraTabPage3"
        Me.XtraTabPage3.Size = New System.Drawing.Size(698, 372)
        Me.XtraTabPage3.Text = "XML Setup"
        '
        'btnDataBase
        '
        Me.btnDataBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDataBase.Location = New System.Drawing.Point(291, 176)
        Me.btnDataBase.Name = "btnDataBase"
        Me.btnDataBase.Size = New System.Drawing.Size(89, 23)
        Me.btnDataBase.TabIndex = 79
        Me.btnDataBase.Text = "Get Database"
        '
        'LabelControl16
        '
        Me.LabelControl16.Location = New System.Drawing.Point(46, 180)
        Me.LabelControl16.Name = "LabelControl16"
        Me.LabelControl16.Size = New System.Drawing.Size(59, 13)
        Me.LabelControl16.TabIndex = 78
        Me.LabelControl16.Text = "Data Base : "
        '
        'txtDBase
        '
        Me.txtDBase.Location = New System.Drawing.Point(111, 177)
        Me.txtDBase.Name = "txtDBase"
        Me.txtDBase.Size = New System.Drawing.Size(155, 20)
        Me.txtDBase.TabIndex = 77
        '
        'LabelControl15
        '
        Me.LabelControl15.Location = New System.Drawing.Point(36, 154)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl15.TabIndex = 76
        Me.LabelControl15.Text = "Server Name :"
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(111, 151)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(155, 20)
        Me.txtServer.TabIndex = 75
        '
        'btnServer
        '
        Me.btnServer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnServer.Location = New System.Drawing.Point(291, 150)
        Me.btnServer.Name = "btnServer"
        Me.btnServer.Size = New System.Drawing.Size(89, 23)
        Me.btnServer.TabIndex = 74
        Me.btnServer.Text = "Get Server"
        '
        'chkUserSA
        '
        Me.chkUserSA.EditValue = "T"
        Me.chkUserSA.Location = New System.Drawing.Point(272, 99)
        Me.chkUserSA.Name = "chkUserSA"
        Me.chkUserSA.Properties.Caption = "Use AutoCount Defaul sa?"
        Me.chkUserSA.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        Me.chkUserSA.Properties.ValueChecked = "T"
        Me.chkUserSA.Properties.ValueGrayed = "F"
        Me.chkUserSA.Properties.ValueUnchecked = "F"
        Me.chkUserSA.Size = New System.Drawing.Size(157, 19)
        Me.chkUserSA.TabIndex = 73
        '
        'LabelControl13
        '
        Me.LabelControl13.Location = New System.Drawing.Point(46, 128)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(59, 13)
        Me.LabelControl13.TabIndex = 69
        Me.LabelControl13.Text = "Password  : "
        '
        'LabelControl14
        '
        Me.LabelControl14.Location = New System.Drawing.Point(70, 102)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl14.TabIndex = 68
        Me.LabelControl14.Text = "sa ID : "
        '
        'txtSAPasswrd
        '
        Me.txtSAPasswrd.Location = New System.Drawing.Point(111, 125)
        Me.txtSAPasswrd.Name = "txtSAPasswrd"
        Me.txtSAPasswrd.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtSAPasswrd.Size = New System.Drawing.Size(155, 20)
        Me.txtSAPasswrd.TabIndex = 67
        '
        'txtSAID
        '
        Me.txtSAID.Location = New System.Drawing.Point(111, 99)
        Me.txtSAID.Name = "txtSAID"
        Me.txtSAID.Size = New System.Drawing.Size(155, 20)
        Me.txtSAID.TabIndex = 66
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(46, 76)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(59, 13)
        Me.LabelControl12.TabIndex = 65
        Me.LabelControl12.Text = "Password  : "
        '
        'LabelControl11
        '
        Me.LabelControl11.Location = New System.Drawing.Point(59, 50)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl11.TabIndex = 64
        Me.LabelControl11.Text = "User ID : "
        '
        'txtPasswrd
        '
        Me.txtPasswrd.Location = New System.Drawing.Point(111, 73)
        Me.txtPasswrd.Name = "txtPasswrd"
        Me.txtPasswrd.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPasswrd.Size = New System.Drawing.Size(155, 20)
        Me.txtPasswrd.TabIndex = 63
        '
        'txtUserID
        '
        Me.txtUserID.Location = New System.Drawing.Point(111, 47)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(155, 20)
        Me.txtUserID.TabIndex = 62
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(57, 23)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl10.TabIndex = 61
        Me.LabelControl10.Text = "XML File : "
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(111, 20)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.btnEdit.Size = New System.Drawing.Size(351, 20)
        Me.btnEdit.TabIndex = 0
        '
        'PanelHeader1
        '
        Me.PanelHeader1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelHeader1.Header = "Freely General Setup"
        Me.PanelHeader1.Hint = "This Setup Using By Freely Administrator."
        Me.PanelHeader1.Location = New System.Drawing.Point(2, 2)
        Me.PanelHeader1.Name = "PanelHeader1"
        Me.PanelHeader1.Size = New System.Drawing.Size(708, 64)
        Me.PanelHeader1.TabIndex = 7
        '
        'dsGeneral
        '
        Me.dsGeneral.DataSetName = "NewDataSet"
        Me.dsGeneral.Tables.AddRange(New System.Data.DataTable() {Me.dtGeneralSetup, Me.dtEamil, Me.dtEmailAcc, Me.dtSecurityProtocol, Me.dtReport})
        '
        'dtGeneralSetup
        '
        Me.dtGeneralSetup.TableName = "GeneralSetup"
        '
        'dtEamil
        '
        Me.dtEamil.Columns.AddRange(New System.Data.DataColumn() {Me.dcEmailAcc, Me.dcEmailPasswd, Me.dcEmailOutgoing, Me.dcEmailPort, Me.dcEmailTimeOut, Me.dcEmailDomainName, Me.dcEmailDefaulSub, Me.dcEmailDefaultName, Me.dcEmailSecurity, Me.dcEmailSSL, Me.dcEmailUsePass, Me.dcEmailSec, Me.dcEmailPerson, Me.DataColumn1, Me.DataColumn4, Me.DataColumn5})
        Me.dtEamil.TableName = "dtEamil"
        '
        'dcEmailAcc
        '
        Me.dcEmailAcc.Caption = "EmailAcc"
        Me.dcEmailAcc.ColumnName = "EmailAcc"
        '
        'dcEmailPasswd
        '
        Me.dcEmailPasswd.Caption = "EmailPasswd"
        Me.dcEmailPasswd.ColumnName = "EmailPasswd"
        '
        'dcEmailOutgoing
        '
        Me.dcEmailOutgoing.Caption = "EmailOutgoing"
        Me.dcEmailOutgoing.ColumnName = "EmailOutgoing"
        '
        'dcEmailPort
        '
        Me.dcEmailPort.Caption = "EmailPort"
        Me.dcEmailPort.ColumnName = "EmailPort"
        '
        'dcEmailTimeOut
        '
        Me.dcEmailTimeOut.Caption = "EmailTimeOut"
        Me.dcEmailTimeOut.ColumnName = "EmailTimeOut"
        '
        'dcEmailDomainName
        '
        Me.dcEmailDomainName.Caption = "EmailDomainName"
        Me.dcEmailDomainName.ColumnName = "EmailDomainName"
        '
        'dcEmailDefaulSub
        '
        Me.dcEmailDefaulSub.Caption = "EmailDefaulSub"
        Me.dcEmailDefaulSub.ColumnName = "EmailDefaulSub"
        '
        'dcEmailDefaultName
        '
        Me.dcEmailDefaultName.Caption = "EmailDefaultName"
        Me.dcEmailDefaultName.ColumnName = "EmailDefaultName"
        '
        'dcEmailSecurity
        '
        Me.dcEmailSecurity.Caption = "EmailSecurity"
        Me.dcEmailSecurity.ColumnName = "EmailSecurity"
        '
        'dcEmailSSL
        '
        Me.dcEmailSSL.Caption = "EmailSSL"
        Me.dcEmailSSL.ColumnName = "EmailSSL"
        Me.dcEmailSSL.DefaultValue = "T"
        '
        'dcEmailUsePass
        '
        Me.dcEmailUsePass.Caption = "EmailUsePass"
        Me.dcEmailUsePass.ColumnName = "EmailUsePass"
        Me.dcEmailUsePass.DefaultValue = "T"
        '
        'dcEmailSec
        '
        Me.dcEmailSec.Caption = "EmailSec"
        Me.dcEmailSec.ColumnName = "EmailSec"
        Me.dcEmailSec.DataType = GetType(Long)
        '
        'dcEmailPerson
        '
        Me.dcEmailPerson.Caption = "EmailPerson"
        Me.dcEmailPerson.ColumnName = "EmailPerson"
        Me.dcEmailPerson.DataType = GetType(Long)
        '
        'DataColumn1
        '
        Me.DataColumn1.Caption = "EmailIsExchange"
        Me.DataColumn1.ColumnName = "EmailIsExchange"
        Me.DataColumn1.DefaultValue = "N"
        '
        'DataColumn4
        '
        Me.DataColumn4.Caption = "DefaultReport"
        Me.DataColumn4.ColumnName = "DefaultReport"
        '
        'DataColumn5
        '
        Me.DataColumn5.Caption = "EmailMsg"
        Me.DataColumn5.ColumnName = "EmailMsg"
        '
        'dtEmailAcc
        '
        Me.dtEmailAcc.Columns.AddRange(New System.Data.DataColumn() {Me.EmailAcc})
        Me.dtEmailAcc.TableName = "dtEmailAcc"
        '
        'EmailAcc
        '
        Me.EmailAcc.Caption = "EmailAcc"
        Me.EmailAcc.ColumnName = "EmailAcc"
        '
        'dtSecurityProtocol
        '
        Me.dtSecurityProtocol.Columns.AddRange(New System.Data.DataColumn() {Me.dcType, Me.dcDescription})
        Me.dtSecurityProtocol.TableName = "dtSecurityProtocol"
        '
        'dcType
        '
        Me.dcType.Caption = "Type"
        Me.dcType.ColumnName = "Type"
        Me.dcType.DataType = GetType(Integer)
        '
        'dcDescription
        '
        Me.dcDescription.Caption = "Description"
        Me.dcDescription.ColumnName = "Description"
        '
        'dtReport
        '
        Me.dtReport.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn2, Me.DataColumn3})
        Me.dtReport.TableName = "dtReport"
        '
        'DataColumn2
        '
        Me.DataColumn2.Caption = "ReportName"
        Me.DataColumn2.ColumnName = "ReportName"
        '
        'DataColumn3
        '
        Me.DataColumn3.Caption = "ReportType"
        Me.DataColumn3.ColumnName = "ReportType"
        '
        'bsEmailAcc
        '
        Me.bsEmailAcc.DataMember = "dtEmailAcc"
        Me.bsEmailAcc.DataSource = Me.dsGeneral
        '
        'bsGeneral
        '
        Me.bsGeneral.DataMember = "GeneralSetup"
        Me.bsGeneral.DataSource = Me.dsGeneral
        '
        'bsEmail
        '
        Me.bsEmail.DataMember = "dtEamil"
        Me.bsEmail.DataSource = Me.dsGeneral
        '
        'dsXML
        '
        Me.dsXML.DataSetName = "NewDataSet"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.PanelControl2)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(2, 66)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(708, 404)
        Me.LayoutControl1.TabIndex = 13
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(708, 404)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.PanelControl2
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(688, 384)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'frmPlugInGeneralSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(712, 508)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.pcFooter)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximumSize = New System.Drawing.Size(728, 547)
        Me.MinimumSize = New System.Drawing.Size(728, 39)
        Me.Name = "frmPlugInGeneralSetup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Freely General Setup"
        CType(Me.pcFooter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pcFooter.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage2.ResumeLayout(False)
        Me.XtraTabPage2.PerformLayout()
        CType(Me.chkIsExchange.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOutGoing.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPort.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSubject.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkUseSSL.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkUsePassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDomainName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTimeOut.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lpProtocolType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUserName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage3.ResumeLayout(False)
        Me.XtraTabPage3.PerformLayout()
        CType(Me.txtDBase.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtServer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkUserSA.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSAPasswrd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSAID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPasswrd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUserID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtGeneralSetup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtEamil, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtEmailAcc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtSecurityProtocol, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtReport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsEmailAcc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsEmail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsXML, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pcFooter As DevExpress.XtraEditors.PanelControl
    Friend WithEvents sqlConn As System.Data.SqlClient.SqlConnection

    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelHeader1 As AutoCount.Controls.PanelHeader
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkIsExchange As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents btnTest As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtSubject As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDomainName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lpProtocolType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtUserName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtTimeOut As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkUsePassword As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkUseSSL As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtPort As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtOutGoing As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblOutgoingServer As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dsGeneral As DataSet
    Friend WithEvents dtGeneralSetup As DataTable
    Friend WithEvents dtEamil As DataTable
    Friend WithEvents dcEmailAcc As DataColumn
    Friend WithEvents dcEmailPasswd As DataColumn
    Friend WithEvents dcEmailOutgoing As DataColumn
    Friend WithEvents dcEmailPort As DataColumn
    Friend WithEvents dcEmailTimeOut As DataColumn
    Friend WithEvents dcEmailDomainName As DataColumn
    Friend WithEvents dcEmailDefaulSub As DataColumn
    Friend WithEvents dcEmailDefaultName As DataColumn
    Friend WithEvents dcEmailSecurity As DataColumn
    Friend WithEvents dcEmailSSL As DataColumn
    Friend WithEvents dcEmailUsePass As DataColumn
    Friend WithEvents dcEmailSec As DataColumn
    Friend WithEvents dcEmailPerson As DataColumn
    Friend WithEvents DataColumn1 As DataColumn
    Friend WithEvents DataColumn4 As DataColumn
    Friend WithEvents DataColumn5 As DataColumn
    Friend WithEvents dtEmailAcc As DataTable
    Friend WithEvents EmailAcc As DataColumn
    Friend WithEvents dtSecurityProtocol As DataTable
    Friend WithEvents dcType As DataColumn
    Friend WithEvents dcDescription As DataColumn
    Friend WithEvents dtReport As DataTable
    Friend WithEvents DataColumn2 As DataColumn
    Friend WithEvents DataColumn3 As DataColumn
    Friend WithEvents bsEmailAcc As BindingSource
    Friend WithEvents bsGeneral As BindingSource
    Friend WithEvents bsEmail As BindingSource
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage3 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnEdit As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents dsXML As DataSet
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPasswrd As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtUserID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents chkUserSA As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtSAPasswrd As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSAID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnServer As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl16 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDBase As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtServer As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnDataBase As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
End Class
