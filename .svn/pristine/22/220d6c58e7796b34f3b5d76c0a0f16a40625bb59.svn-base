
Public Class ApplicationSetting

    Dim _DBSetting As AutoCount.Data.DBSetting
    Dim _ApplicationSettingTable As DataTable
    Dim _AUISetting As DataTable
    Public ReadOnly Property ApplicationSettingTable As DataTable
        Get
            Return _ApplicationSettingTable
        End Get
    End Property
    Public ReadOnly Property UISetting As DataTable
        Get
            Return _AUISetting
        End Get
    End Property
    Public ReadOnly Property DBSetting As AutoCount.Data.DBSetting
        Get
            Return _DBSetting
        End Get
    End Property
    Public Sub New(ByVal ADBSetting As AutoCount.Data.DBSetting, ByVal AUISetting As DataTable)
        _DBSetting = ADBSetting
        _AUISetting = AUISetting
        Init()
    End Sub
    Public Sub New(ByVal ADBSetting As AutoCount.Data.DBSetting)
        _DBSetting = ADBSetting
        Init()
    End Sub
    Private Sub InitFreelyRegistry()
        Dim sSQL As New System.Text.StringBuilder

        sSQL.AppendLine("  IF Not EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlugIn_Freely_Registry]') AND type in (N'U')) ")
        sSQL.AppendLine(" BEGIN ")
        sSQL.AppendLine("CREATE TABLE [dbo].[PlugIn_Freely_Registry](")
        sSQL.AppendLine("	[RegID] [nvarchar](50) NOT NULL,")
        sSQL.AppendLine("	[RegType] [nvarchar](50) NULL,")
        sSQL.AppendLine("	[RegValue] [nvarchar](255) NULL,")
        sSQL.AppendLine(" CONSTRAINT [PK_PlugIn_Freely_Registry] PRIMARY KEY CLUSTERED ")
        sSQL.AppendLine("(")
        sSQL.AppendLine("	[RegID] ASC")
        sSQL.AppendLine(")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]")
        sSQL.AppendLine(") ON [PRIMARY]")
        sSQL.AppendLine(" END ")


        sSQL.AppendLine("IF NOT EXISTS(SELECT * FROM   INFORMATION_SCHEMA.COLUMNS WHERE  TABLE_NAME = 'PlugIn_Freely_Registry' AND COLUMN_NAME = 'RegMemo') ")
        sSQL.AppendLine("BEGIN ")
        sSQL.AppendLine("ALTER TABLE PlugIn_Freely_Registry ADD RegMemo nText")
        sSQL.AppendLine("END")

        sSQL.AppendLine("IF NOT EXISTS(SELECT * FROM   INFORMATION_SCHEMA.COLUMNS WHERE  TABLE_NAME = 'PlugIn_Freely_Registry' AND COLUMN_NAME = 'Type') ")
        sSQL.AppendLine("BEGIN ")
        sSQL.AppendLine("ALTER TABLE PlugIn_Freely_Registry ADD Type nvarchar(15)")
        sSQL.AppendLine("END")

        sSQL.AppendLine("IF NOT EXISTS(SELECT * FROM   INFORMATION_SCHEMA.COLUMNS WHERE  TABLE_NAME = 'PlugIn_Freely_Registry' AND COLUMN_NAME = 'RegDateTime') ")
        sSQL.AppendLine("BEGIN ")
        sSQL.AppendLine("ALTER TABLE PlugIn_Freely_Registry ADD RegDateTime DateTime")
        sSQL.AppendLine("END")

        sSQL.AppendLine("IF NOT EXISTS(SELECT * FROM   INFORMATION_SCHEMA.COLUMNS WHERE  TABLE_NAME = 'PlugIn_Freely_Registry' AND COLUMN_NAME = 'RegDecimal') ")
        sSQL.AppendLine("BEGIN ")
        sSQL.AppendLine("ALTER TABLE PlugIn_Freely_Registry ADD RegDecimal Decimal(18,4)")
        sSQL.AppendLine("END")

        sSQL.AppendLine("IF NOT EXISTS(SELECT * FROM   INFORMATION_SCHEMA.COLUMNS WHERE  TABLE_NAME = 'PlugIn_Freely_Registry' AND COLUMN_NAME = 'RegKey') ")
        sSQL.AppendLine("BEGIN ")
        sSQL.AppendLine("ALTER TABLE PlugIn_Freely_Registry ADD RegKey BigInt")
        sSQL.AppendLine("END")
        Try
            Using sqlConn As New SqlClient.SqlConnection(Me.DBSetting.ConnectionString)
                sqlConn.Open()
                Using sqlCmd As New SqlClient.SqlCommand(sSQL.ToString, sqlConn)
                    sqlCmd.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Init()
        Try
            Using sqlConn As New SqlClient.SqlConnection(Me.DBSetting.ConnectionString)
                sqlConn.Open()
                InitFreelyRegistry()
                Using sqlCmd As New SqlClient.SqlCommand("Select * From PlugIn_Freely_Registry", sqlConn)
                    Using dtRegistry As New DataTable
                        dtRegistry.Load(sqlCmd.ExecuteReader)
                        _ApplicationSettingTable = New DataTable("ApplicationSetting")

                        If UISetting IsNot Nothing Then
                            For Each dcUI As DataColumn In UISetting.Columns
                                Select Case dcUI.DataType
                                    Case GetType(String) : _ApplicationSettingTable.Columns.Add(New DataColumn(dcUI.ColumnName, GetType(String)))
                                    Case GetType(Integer) : _ApplicationSettingTable.Columns.Add(New DataColumn(dcUI.ColumnName, GetType(Integer)))
                                    Case GetType(DateTime) : _ApplicationSettingTable.Columns.Add(New DataColumn(dcUI.ColumnName, GetType(DateTime)))
                                    Case GetType(Decimal) : _ApplicationSettingTable.Columns.Add(New DataColumn(dcUI.ColumnName, GetType(Decimal)))
                                End Select
                            Next
                        End If
                        For Each drRegistry As DataRow In dtRegistry.Rows
                            Dim sType As String = drRegistry.Item("Type").ToString
                            Dim sRegID As String = drRegistry.Item("RegID").ToString
                            Dim sRegType As String = drRegistry.Item("RegType").ToString

                            If _ApplicationSettingTable.Columns.Contains(sRegID) Then Continue For
                            Select Case sType.ToUpper
                                Case "INT64".ToUpper : _ApplicationSettingTable.Columns.Add(New DataColumn(sRegID, GetType(Long)))
                                Case "String".ToUpper : _ApplicationSettingTable.Columns.Add(New DataColumn(sRegID, GetType(String)))
                                Case "DateTime".ToUpper : _ApplicationSettingTable.Columns.Add(New DataColumn(sRegID, GetType(DateTime)))
                                Case "Decimal".ToUpper : _ApplicationSettingTable.Columns.Add(New DataColumn(sRegID, GetType(Decimal)))
                                Case "Integer".ToUpper : _ApplicationSettingTable.Columns.Add(New DataColumn(sRegID, GetType(Integer)))
                                Case "Memo".ToUpper
                                    Dim dc As DataColumn = New DataColumn(sRegID, GetType(String))
                                    dc.ExtendedProperties("IsMemo") = "T"
                                    _ApplicationSettingTable.Columns.Add(dc)
                                Case Else
                                    If sRegType = "5" Then
                                        _ApplicationSettingTable.Columns.Add(New DataColumn(sRegID, GetType(String)))
                                    End If
                            End Select
                        Next
                        Dim drNew As DataRow = _ApplicationSettingTable.NewRow
                        For Each drRegistry As DataRow In dtRegistry.Rows
                            Dim sType As String = drRegistry.Item("Type").ToString
                            Dim sRegID As String = drRegistry.Item("RegID").ToString
                            Dim sRegType As String = drRegistry.Item("RegType").ToString
                            Select Case sType.ToUpper
                                Case "INT64" : drNew.Item(sRegID) = drRegistry.Item("RegKey")
                                Case "String".ToUpper : drNew.Item(sRegID) = drRegistry.Item("RegValue")
                                Case "DateTime".ToUpper : drNew.Item(sRegID) = drRegistry.Item("RegDateTime")
                                Case "Decimal".ToUpper : drNew.Item(sRegID) = drRegistry.Item("RegDecimal")
                                Case "Integer".ToUpper : drNew.Item(sRegID) = drRegistry.Item("RegKey")
                                Case "Memo".ToUpper : drNew.Item(sRegID) = drRegistry.Item("RegMemo")
                                Case Else
                                    If sRegType = "5" Then
                                        drNew.Item(sRegID) = drRegistry.Item("RegValue")
                                    End If
                            End Select
                        Next
                        _ApplicationSettingTable.Rows.Add(drNew)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub Save()
        Dim sSQL As String = "SELECT * FROM PlugIn_Freely_Registry"
        Using sqlConn As New SqlClient.SqlConnection(Me.DBSetting.ConnectionString)
            sqlConn.Open()
            Using sqlCmd As New SqlClient.SqlCommand(sSQL, sqlConn)
                Dim dtRecord As New DataTable
                dtRecord.Load(sqlCmd.ExecuteReader)
                For Each drRegistry As DataRow In Me.ApplicationSettingTable.Rows
                    For Each dcRegID As DataColumn In Me.ApplicationSettingTable.Columns
                        Try
                            Dim sRegID As String = dcRegID.ColumnName
                            Dim bIsMemo As Boolean = False
                            If dcRegID.ExtendedProperties.Count > 0 Then
                                bIsMemo = dcRegID.ExtendedProperties("IsMemo").ToString = "T"
                            End If
                            If sRegID = "RCID" Then Continue For
                            If dtRecord.Select(String.Format("RegID='{0}'", sRegID)).Length = 0 Then
                                Dim sInsert As String = String.Format("INSERT INTO  PlugIn_Freely_Registry (RegID, RegValue, RegKey,Type,RegDecimal,RegDateTime,RegMemo) VALUES(@RegId,@RegValue,@RegKey,@Type,@RegDecimal,@RegDateTime,@RegMemo)")
                                Using sqlCmdInsert As New SqlClient.SqlCommand(sInsert, sqlConn)
                                    sqlCmdInsert.Parameters.AddWithValue("RegID", sRegID)

                                    Select Case dcRegID.DataType
                                        Case GetType(String)
                                            If Not bIsMemo Then
                                                sqlCmdInsert.Parameters.AddWithValue("RegDateTime", DBNull.Value)
                                                sqlCmdInsert.Parameters.AddWithValue("RegKey", DBNull.Value)
                                                sqlCmdInsert.Parameters.AddWithValue("RegDecimal", DBNull.Value)
                                                sqlCmdInsert.Parameters.AddWithValue("RegMemo", DBNull.Value)
                                                sqlCmdInsert.Parameters.AddWithValue("RegValue", drRegistry.Item(sRegID).ToString)
                                                sqlCmdInsert.Parameters.AddWithValue("Type", "String")
                                            Else
                                                sqlCmdInsert.Parameters.AddWithValue("RegDateTime", DBNull.Value)
                                                sqlCmdInsert.Parameters.AddWithValue("RegKey", DBNull.Value)
                                                sqlCmdInsert.Parameters.AddWithValue("RegDecimal", DBNull.Value)
                                                sqlCmdInsert.Parameters.AddWithValue("RegValue", DBNull.Value)
                                                sqlCmdInsert.Parameters.AddWithValue("RegMemo", drRegistry.Item(sRegID).ToString)
                                                sqlCmdInsert.Parameters.AddWithValue("Type", "Memo")
                                            End If

                                        Case GetType(Integer)
                                            sqlCmdInsert.Parameters.AddWithValue("RegDateTime", DBNull.Value)
                                            sqlCmdInsert.Parameters.AddWithValue("RegValue", DBNull.Value)
                                            sqlCmdInsert.Parameters.AddWithValue("RegDecimal", DBNull.Value)
                                            sqlCmdInsert.Parameters.AddWithValue("RegKey", drRegistry.Item(sRegID))
                                            sqlCmdInsert.Parameters.AddWithValue("RegMemo", DBNull.Value)
                                            sqlCmdInsert.Parameters.AddWithValue("Type", "Integer")
                                        Case GetType(Decimal)
                                            sqlCmdInsert.Parameters.AddWithValue("RegDateTime", DBNull.Value)
                                            sqlCmdInsert.Parameters.AddWithValue("RegValue", DBNull.Value)
                                            sqlCmdInsert.Parameters.AddWithValue("RegKey", DBNull.Value)
                                            sqlCmdInsert.Parameters.AddWithValue("RegDecimal", drRegistry.Item(sRegID))
                                            sqlCmdInsert.Parameters.AddWithValue("RegMemo", DBNull.Value)
                                            sqlCmdInsert.Parameters.AddWithValue("Type", "Decimal")
                                        Case GetType(DateTime)
                                            sqlCmdInsert.Parameters.AddWithValue("RegDecimal", DBNull.Value)
                                            sqlCmdInsert.Parameters.AddWithValue("RegValue", DBNull.Value)
                                            sqlCmdInsert.Parameters.AddWithValue("RegKey", DBNull.Value)
                                            sqlCmdInsert.Parameters.AddWithValue("RegDateTime", drRegistry.Item(sRegID))
                                            sqlCmdInsert.Parameters.AddWithValue("RegMemo", DBNull.Value)
                                            sqlCmdInsert.Parameters.AddWithValue("Type", "DateTime")
                                    End Select
                                    sqlCmdInsert.ExecuteNonQuery()
                                End Using
                            Else
                                Dim sInsert As String = String.Format("UPDATE PlugIn_Freely_Registry SET RegKey=@RegKey,RegValue=@RegValue,RegDecimal=@RegDecimal,RegDateTime=@RegDateTime,RegMemo=@RegMemo ,Type=@Type WHERE REGID=@REGID")
                                Using sqlCmdUpdate As New SqlClient.SqlCommand(sInsert, sqlConn)
                                    sqlCmdUpdate.Parameters.AddWithValue("RegID", sRegID)
                                    Select Case dcRegID.DataType
                                        Case GetType(String)
                                            If Not bIsMemo Then
                                                sqlCmdUpdate.Parameters.AddWithValue("RegDateTime", DBNull.Value)
                                                sqlCmdUpdate.Parameters.AddWithValue("RegKey", DBNull.Value)
                                                sqlCmdUpdate.Parameters.AddWithValue("RegDecimal", DBNull.Value)
                                                sqlCmdUpdate.Parameters.AddWithValue("RegMemo", DBNull.Value)
                                                sqlCmdUpdate.Parameters.AddWithValue("RegValue", drRegistry.Item(sRegID).ToString)
                                                sqlCmdUpdate.Parameters.AddWithValue("Type", "String")
                                            Else
                                                sqlCmdUpdate.Parameters.AddWithValue("RegDateTime", DBNull.Value)
                                                sqlCmdUpdate.Parameters.AddWithValue("RegKey", DBNull.Value)
                                                sqlCmdUpdate.Parameters.AddWithValue("RegDecimal", DBNull.Value)
                                                sqlCmdUpdate.Parameters.AddWithValue("RegValue", DBNull.Value)
                                                sqlCmdUpdate.Parameters.AddWithValue("RegMemo", drRegistry.Item(sRegID).ToString)
                                                sqlCmdUpdate.Parameters.AddWithValue("Type", "Memo")
                                            End If
                                        Case GetType(Integer)
                                            sqlCmdUpdate.Parameters.AddWithValue("RegDateTime", DBNull.Value)
                                            sqlCmdUpdate.Parameters.AddWithValue("RegValue", DBNull.Value)
                                            sqlCmdUpdate.Parameters.AddWithValue("RegDecimal", DBNull.Value)
                                            sqlCmdUpdate.Parameters.AddWithValue("RegKey", drRegistry.Item(sRegID))
                                            sqlCmdUpdate.Parameters.AddWithValue("RegMemo", DBNull.Value)
                                            sqlCmdUpdate.Parameters.AddWithValue("Type", "Integer")
                                        Case GetType(Decimal)
                                            sqlCmdUpdate.Parameters.AddWithValue("RegDateTime", DBNull.Value)
                                            sqlCmdUpdate.Parameters.AddWithValue("RegValue", DBNull.Value)
                                            sqlCmdUpdate.Parameters.AddWithValue("RegKey", DBNull.Value)
                                            sqlCmdUpdate.Parameters.AddWithValue("RegMemo", DBNull.Value)
                                            sqlCmdUpdate.Parameters.AddWithValue("RegDecimal", drRegistry.Item(sRegID))
                                            sqlCmdUpdate.Parameters.AddWithValue("Type", "Decimal")
                                        Case GetType(DateTime)
                                            sqlCmdUpdate.Parameters.AddWithValue("RegDecimal", DBNull.Value)
                                            sqlCmdUpdate.Parameters.AddWithValue("RegValue", DBNull.Value)
                                            sqlCmdUpdate.Parameters.AddWithValue("RegKey", DBNull.Value)
                                            sqlCmdUpdate.Parameters.AddWithValue("RegMemo", DBNull.Value)
                                            sqlCmdUpdate.Parameters.AddWithValue("RegDateTime", drRegistry.Item(sRegID))
                                            sqlCmdUpdate.Parameters.AddWithValue("Type", "DateTime")
                                    End Select
                                    sqlCmdUpdate.ExecuteNonQuery()
                                End Using
                            End If
                        Catch ex As Exception
                            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
                        End Try
                    Next
                Next
            End Using
        End Using
    End Sub


    Public Shared Function GetRegistryValue(ByVal ARegistryID As String) As Object
        Try
            If AutoCount.Authentication.UserSession.CurrentUserSession.DBSetting Is Nothing Then Return Nothing
            Dim ASetting As New ApplicationSetting(AutoCount.Authentication.UserSession.CurrentUserSession.DBSetting)
            If ASetting.ApplicationSettingTable.Columns.Contains(ARegistryID) Then
                For Each drSetting As DataRow In ASetting.ApplicationSettingTable.Rows
                    Return drSetting.Item(ARegistryID)
                Next
            End If
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
        End Try
        Return String.Empty
    End Function
End Class