
Public Class frmPlugInGeneralSetup
    Dim DBSetting As AutoCount.Data.DBSetting
    Dim UserSession As AutoCount.Authentication.UserSession
    Dim SqlAdp As SqlClient.SqlDataAdapter
    Private Const PlugIn_EmailSetting As String = "PlugIn_EmailSetting"

    Dim _ApplicationSetting As ApplicationSetting

    Public Sub New(ByVal UserSession As AutoCount.Authentication.UserSession)
        Me.UserSession = UserSession
        Me.DBSetting = UserSession.DBSetting
        InitializeComponent()

        _ApplicationSetting = New ApplicationSetting(DBSetting, Me.dtGeneralSetup)
    End Sub

    Private Sub frmPlugInGeneralSetup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            TryCast(sender, System.Windows.Forms.Form).KeyPreview = True
            Me.dtGeneralSetup = _ApplicationSetting.ApplicationSettingTable
            Me.bsGeneral.DataSource = Me.dtGeneralSetup

            sqlConn.ConnectionString = Me.DBSetting.ConnectionString
            sqlConn.Open()
            'RefreshEmail()
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub RefreshEmail()
        SqlAdp = New SqlClient.SqlDataAdapter(String.Format("SELECT * FROM {0}", PlugIn_EmailSetting), sqlConn)

        Dim SqlBuilder As New SqlClient.SqlCommandBuilder(SqlAdp)
        SqlBuilder.ConflictOption = ConflictOption.OverwriteChanges

        SqlAdp.InsertCommand = SqlBuilder.GetInsertCommand
        SqlAdp.UpdateCommand = SqlBuilder.GetUpdateCommand
        SqlAdp.DeleteCommand = SqlBuilder.GetDeleteCommand

        SqlAdp.Fill(dtEamil)

        SecurityProtocolToTable(GetType(System.Net.SecurityProtocolType), Me.dtSecurityProtocol)
        If dtEamil.Rows.Count = 0 Then
            Me.bsEmail.AddNew()
        End If
        If chkIsExchange.CheckState = CheckState.Checked Then
            txtDomainName.Enabled = True
        Else
            txtDomainName.Enabled = False
        End If
        If chkUserSA.CheckState = CheckState.Checked Then
            txtSAID.Enabled = False
            txtSAPasswrd.Enabled = False
        Else
            txtSAID.Enabled = True
            txtSAPasswrd.Enabled = True
        End If
    End Sub
    Public Sub SecurityProtocolToTable(ByVal oType As Type, ByVal oDataTable As DataTable)
        Dim ProtocolValue As Array = [Enum].GetValues(oType)
        Dim ProtocolName() As String = [Enum].GetNames(oType)

        Dim i As Integer
        For i = 0 To ProtocolName.Length - 1
            Dim dr As DataRow = oDataTable.NewRow
            dr(0) = CInt(ProtocolValue(i))
            dr(1) = ProtocolName(i)
            oDataTable.Rows.Add(dr)
        Next
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If Me.dsGeneral.HasChanges Then
            If DevExpress.XtraEditors.XtraMessageBox.Show("Record has change are you sure wan to Exit?", Freely.Application.FreelyConstMessage.ShortTitleName, MessageBoxButtons.OKCancel) = DialogResult.OK Then
                Me.Close()
            Else
                Return
            End If
        End If
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Me.bsGeneral.EndEdit()
            _ApplicationSetting.Save()

            If XtraTabPage2.PageVisible = True Then
                SqlAdp.Update(dtEamil)
            End If
            If XtraTabPage3.PageVisible = True Then
                SaveXML()
            End If
            DevExpress.XtraEditors.XtraMessageBox.Show(Freely.Application.FreelyConstMessage.sRecordSave, Freely.Application.FreelyConstMessage.ShortTitleName, MessageBoxButtons.OK)
            Me.Close()

        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, Freely.Application.FreelyConstMessage.ShortTitleName, MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub chkIsExchange_CheckedChanged(sender As Object, e As EventArgs) Handles chkIsExchange.CheckedChanged
        If chkIsExchange.CheckState = CheckState.Checked Then
            txtDomainName.Enabled = True
        Else
            txtDomainName.Enabled = False
        End If
    End Sub

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click
        Try
            Dim oEmail As New EmailClass(Me.DBSetting, dtEamil)
            If oEmail IsNot Nothing Then
                oEmail.SendEmail(txtUserName.Text, "Testing Email Subject", "Testing Email 1 2 3...", Nothing, Nothing, False, True)
                DevExpress.XtraEditors.XtraMessageBox.Show("Email Sent Successfully!")
            End If
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LabelControl9_Click(sender As Object, e As EventArgs) Handles LabelControl9.Click
        Dim sInfo As New ProcessStartInfo("https://myaccount.google.com/lesssecureapps")
        Process.Start(sInfo)
    End Sub

    Private Sub btnEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles btnEdit.ButtonClick
        Try
            dsXML.Clear()
            Dim opDialog As New OpenFileDialog
            opDialog.Filter = "XML File|*.config|All File|*.*"
            If opDialog.ShowDialog() = DialogResult.OK Then
                Dim sDirectory As String = opDialog.FileName.ToString
                btnEdit.Text = sDirectory.ToString
                dsXML.ReadXml(btnEdit.Text)
                If dsXML.Tables.Contains("add") Then
                    For Each dr As DataRow In dsXML.Tables("add").Rows
                        If dr.Item("key").ToString = "UserID" Then
                            txtUserID.Text = dr.Item("value")
                        ElseIf dr.Item("key").ToString = "Password" Then
                            txtPasswrd.Text = dr.Item("value")
                        ElseIf dr.Item("key").ToString = "SAUserID" Then
                            txtSAID.Text = dr.Item("value")
                        ElseIf dr.Item("key").ToString = "SAPassword" Then
                            txtSAPasswrd.Text = dr.Item("value")
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub chkUserSA_CheckedChanged(sender As Object, e As EventArgs) Handles chkUserSA.CheckedChanged
        If chkUserSA.CheckState = CheckState.Checked Then
            txtSAID.Enabled = False
            txtSAPasswrd.Enabled = False
            txtSAID.Text = "sa"
            txtSAPasswrd.Text = "oCt2005-ShenZhou6_A2006"
        Else
            txtSAID.Text = String.Empty
            txtSAPasswrd.Text = String.Empty
            txtSAID.Enabled = True
            txtSAPasswrd.Enabled = True
        End If
    End Sub
    Private Sub btnServer_Click(sender As Object, e As EventArgs) Handles btnServer.Click
        Dim GetServer As New AutoCount.Data.FormAvailableSQLServers
        If GetServer.ShowDialog() = DialogResult.OK Then
            txtServer.Text = GetServer.SelectedServerName
        End If
    End Sub

    Private Sub btnDataBase_Click(sender As Object, e As EventArgs) Handles btnDataBase.Click
        If txtSAID.ToString.Length > 0 And txtSAPasswrd.ToString.Length > 0 Then
            Dim GetDatabase As New AutoCount.Data.FormAvailableSQLDatabase(txtServer.Text.ToString, txtSAPasswrd.Text.ToString)
            If GetDatabase.ShowDialog = DialogResult.OK Then
                txtDBase.Text = GetDatabase.SelectedDatabaseName
            End If
        End If
    End Sub
    Public Sub SaveXML()
        If txtUserID.Text.ToString.Length > 0 And txtPasswrd.Text.ToString.Length > 0 And txtSAID.Text.ToString.Length > 0 And txtSAPasswrd.Text.ToString.Length > 0 And txtServer.Text.ToString.Length > 0 And txtDBase.Text.ToString.Length > 0 Then
            If dsXML.Tables.Contains("add") Then
                For Each dr As DataRow In dsXML.Tables("add").Rows
                    If dr.Item("key").ToString = "UserID" Then
                        dr.Item("value") = txtUserID.Text
                    ElseIf dr.Item("key").ToString = "Password" Then
                        dr.Item("value") = txtPasswrd.Text
                    ElseIf dr.Item("key").ToString = "SAUserID" Then
                        dr.Item("value") = txtSAID.Text
                    ElseIf dr.Item("key").ToString = "SAPassword" Then
                        dr.Item("value") = txtSAPasswrd.Text
                    ElseIf dr.Item("name").ToString = "FreelyConnectionString" Then
                        dr.Item("connectionString") = String.Format("Data Source='{0}';Initial Catalog='{1}';Persist Security Info=True;User ID='{2}';Password='{3}'", txtServer.Text.ToString, txtDBase.Text.ToString, txtSAID.Text.ToString, txtSAPasswrd.Text.ToString)
                    End If
                Next
            End If
            dsXML.WriteXml(btnEdit.Text)
        End If
    End Sub
End Class