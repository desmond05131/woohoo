Namespace Freely.Standard.DataAdapter
    Public Class FreelyDataAdapter
        Inherits Object

        Dim _UserSession As AutoCount.Authentication.UserSession
        Dim _DBSetting As AutoCount.Data.DBSetting
        Dim sqlConn As SqlClient.SqlConnection
        Dim _TableName As String = ""
        Dim adpMaster As SqlClient.SqlDataAdapter
        Dim _ResultDataSet As New DataSet
        Dim _DocType As String = ""
        Public Property SQLCommandText As String = ""
        Public Property FreelyLog As New FreelyLog
        Public ReadOnly Property TableName As String
            Get
                Return _TableName
            End Get
        End Property
        Public ReadOnly Property ResultDataSet As DataSet
            Get
                Return _ResultDataSet
            End Get
        End Property
        '2022/03/30 Yit Fit Request Direct Get DataTable Name
        Public ReadOnly Property ResultDataTable As DataTable
            Get
                If _ResultDataSet.Tables.Count > 0 Then
                    Return _ResultDataSet.Tables(0)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public ReadOnly Property DBSetting As AutoCount.Data.DBSetting
            Get
                Return _DBSetting
            End Get
        End Property
        Public ReadOnly Property UserSession As AutoCount.Authentication.UserSession
            Get
                Return _UserSession
            End Get
        End Property
        Public Sub New(ByVal AUserSession As AutoCount.Authentication.UserSession, ByVal ATableName As String, ByVal ACommandText As String, ByVal AParamLists As SqlClient.SqlParameter())
            '2022/03/22 lai added new parameterlist this value
            _UserSession = AUserSession
            _DBSetting = _UserSession.DBSetting
            _SQLCommandText = ACommandText
            sqlConn = New SqlClient.SqlConnection(_DBSetting.ConnectionString)
            sqlConn.Open()
            _TableName = ATableName
            Init(AParamLists)
        End Sub

        Public Sub New(ByVal AUserSession As AutoCount.Authentication.UserSession, ByVal ATableName As String)
            _UserSession = AUserSession
            _DBSetting = _UserSession.DBSetting
            sqlConn = New SqlClient.SqlConnection(_DBSetting.ConnectionString)
            sqlConn.Open()
            _TableName = ATableName
            Init(Nothing)
        End Sub
        Public Sub New(ByVal ATableName As String)
            _UserSession = AutoCount.Authentication.UserSession.CurrentUserSession
            _DBSetting = _UserSession.DBSetting
            sqlConn = New SqlClient.SqlConnection(_DBSetting.ConnectionString)
            sqlConn.Open()
            _TableName = ATableName
            Init(Nothing)
        End Sub
        Public Property DocType As String
            Get
                Return _DocType
            End Get
            Set(value As String)
                If (value.Length > 2) Then
                    Throw New Exception("Base on autocount rules DocType Only Length = 2")
                End If
                _DocType = value
            End Set
        End Property

        Private Sub Init(ByVal AParamLists As SqlClient.SqlParameter(), Optional ByVal NeedFillData As Boolean = True)
            Try
                '2022/03/22 lai added new parameterlist this value

                If _TableName.Length = 0 Then Throw New Exception("Invalid Table Name")
                If _SQLCommandText.Length > 0 Then
                    adpMaster = New SqlClient.SqlDataAdapter(_SQLCommandText, sqlConn)
                Else
                    adpMaster = New SqlClient.SqlDataAdapter(String.Format("Select * From {0}", TableName), sqlConn)
                End If
                If AParamLists IsNot Nothing Then
                    For Each sqlParam As SqlClient.SqlParameter In AParamLists
                        adpMaster.SelectCommand.Parameters.Add(sqlParam)
                    Next
                End If
                Dim ABuilder As New SqlClient.SqlCommandBuilder(adpMaster)
                ABuilder.ConflictOption = ConflictOption.OverwriteChanges

                adpMaster.UpdateCommand = ABuilder.GetUpdateCommand
                adpMaster.DeleteCommand = ABuilder.GetDeleteCommand
                adpMaster.InsertCommand = ABuilder.GetInsertCommand
                adpMaster.FillSchema(_ResultDataSet, SchemaType.Source)

                If NeedFillData Then
                    RefreshData()
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Function Commit(Optional ByVal WithAutoTrail As Boolean = False) As Boolean
            Try
                If WithAutoTrail Then
                    CommitAuditTrail(Me._ResultDataSet.Tables(0))
                End If
                adpMaster.Update(Me._ResultDataSet.Tables(0))
                Return True
            Catch ex As Exception
                Throw ex
            End Try
            Return False
        End Function
        Public Function Commit(ByVal ADataTable As DataTable, Optional ByVal WithAutoTrail As Boolean = False) As Boolean
            Try
                If WithAutoTrail Then
                    CommitAuditTrail(ADataTable)
                End If
                adpMaster.Update(ADataTable)
                Return True
            Catch ex As Exception
                Throw ex
            End Try
            Return False
        End Function
        Private Sub CommitAuditTrail(ByVal ADataTable As DataTable)
            Dim sMasterAudit As String = ""
            Try
                If FreelyLog Is Nothing Then
                    Throw New Exception("Freely Not Allow Null")
                End If
                If Not ADataTable.Columns.Contains("DocKey") Then
                    Throw New Exception("Table Dont Contain DocKey Not Allow Be Audit Trail")
                End If
                For Each drDetail As DataRow In ADataTable.Rows
                    If drDetail.RowState = DataRowState.Unchanged Then Continue For
                    Dim sDetail As String = ""

                    Dim sDeleteDescription As String = ""
                    If drDetail.RowState = DataRowState.Deleted Then
                        For Each drCol As DataColumn In ADataTable.Columns
                            Dim objOrinal As Object = drDetail.Item(drCol.ColumnName, DataRowVersion.Original)
                            sDetail = sDetail & String.Format("[{0}] Original Value: {1}", drCol.ColumnName, objOrinal.ToString) & vbCrLf
                        Next
                        If sDetail.Length > 0 Then
                            If FreelyLog.DeleteDescription.Length > 0 Then
                                If FreelyLog.ColumnsForDisplay.Count > 0 Then
                                    Dim sValue As New List(Of String)
                                    For index As Integer = 0 To FreelyLog.ColumnsForDisplay.Count - 1
                                        sValue.Add(drDetail.Item(FreelyLog.ColumnsForDisplay(index), DataRowVersion.Original).ToString)
                                    Next
                                    sDeleteDescription = String.Format(FreelyLog.DeleteDescription, sValue.ToArray)
                                Else
                                    sDeleteDescription = FreelyLog.DeleteDescription
                                End If
                            Else
                                sDeleteDescription = String.Format("{0} Record Delete.", TableName)
                            End If
                            '2022/03/30 lai fixed DataTable Row(0) bug
                            AutoCount.AuditTrail.Logger.Log(Me.UserSession, DocType, Convert.ToInt64(drDetail.Item("DocKey", DataRowVersion.Original)),
                                            AutoCount.AuditTrail.EventType.Delete,
                                             sDeleteDescription,
                                            sDetail)
                        End If

                    ElseIf drDetail.RowState = DataRowState.Added Then
                        For Each drCol As DataColumn In ADataTable.Columns
                            Dim objOrinal As Object = drDetail.Item(drCol.ColumnName)
                            sDetail = sDetail & String.Format("[{0}] Value: {1}", drCol.ColumnName, objOrinal.ToString) & vbCrLf
                        Next

                        Dim sAddDescription As String = ""
                        If FreelyLog.AddDescription.Length > 0 Then
                            If FreelyLog.ColumnsForDisplay.Count > 0 Then
                                Dim sValue As New List(Of String)
                                For index As Integer = 0 To FreelyLog.ColumnsForDisplay.Count - 1
                                    '2022/03/22 lai fixed bug here
                                    sValue.Add(drDetail.Item(FreelyLog.ColumnsForDisplay(index)).ToString)
                                Next
                                sAddDescription = String.Format(FreelyLog.AddDescription, sValue.ToArray)

                            Else
                                sAddDescription = FreelyLog.AddDescription
                            End If
                        Else
                            sAddDescription = String.Format("{0} Record Added.", TableName)
                        End If
                        If sDetail.Length > 0 Then
                            '2022/03/30 lai fixed DataTable Row(0) bug
                            AutoCount.AuditTrail.Logger.Log(Me.UserSession, DocType, Convert.ToInt64(drDetail.Item("DocKey")),
                                          AutoCount.AuditTrail.EventType.New,
                                           sAddDescription,
                                          sDetail)
                        End If
                    Else
                        For Each drCol As DataColumn In ADataTable.Columns
                            If drCol.ColumnName = "LastModifiedUserID" Then Continue For
                            If drCol.ColumnName = "LastModified" Then Continue For

                            If drCol.DataType = GetType(Decimal) Then
                                Dim iCurent As Decimal = IIf(drDetail.Item(drCol.ColumnName, DataRowVersion.Current) Is DBNull.Value, 0, drDetail.Item(drCol.ColumnName, DataRowVersion.Current))
                                Dim iOriginal As Decimal = IIf(drDetail.Item(drCol.ColumnName, DataRowVersion.Original) Is DBNull.Value, 0, drDetail.Item(drCol.ColumnName, DataRowVersion.Original))

                                If iCurent.ToString("n4") <> iOriginal.ToString("n4") Then
                                    sDetail = sDetail & String.Format("Column [{0}] Value From {1}->{2}", drCol.ColumnName, iOriginal, iCurent) + vbCrLf
                                End If
                            Else
                                Dim objCurrent As Object = drDetail.Item(drCol.ColumnName, DataRowVersion.Current)
                                Dim objOrinal As Object = drDetail.Item(drCol.ColumnName, DataRowVersion.Original)


                                If objCurrent.ToString <> objOrinal.ToString Then
                                    sDetail = sDetail & String.Format("Column [{0}] Value From {1}->{2}", drCol.ColumnName, objOrinal.ToString, objCurrent.ToString) + vbCrLf
                                End If
                            End If
                        Next
                        If sDetail.Length > 0 Then

                            Dim sEditDescription As String = ""
                            If FreelyLog.EditDescription.Length > 0 Then
                                If FreelyLog.ColumnsForDisplay.Count > 0 Then
                                    Dim sValue As New List(Of String)
                                    For index As Integer = 0 To FreelyLog.ColumnsForDisplay.Count - 1
                                        sValue.Add(drDetail.Item(FreelyLog.ColumnsForDisplay(index), DataRowVersion.Original).ToString)
                                    Next
                                    sEditDescription = String.Format(FreelyLog.EditDescription, sValue.ToArray)

                                Else
                                    sEditDescription = FreelyLog.EditDescription
                                End If
                            Else
                                sEditDescription = String.Format("{0} Record Edit.", TableName)
                            End If
                            '2022/03/30 lai fixed DataTable Row(0) bug
                            AutoCount.AuditTrail.Logger.Log(Me.UserSession, DocType, Convert.ToInt64(drDetail.Item("DocKey")),
                                          AutoCount.AuditTrail.EventType.Edit,
                                          sEditDescription, sDetail)
                        End If
                    End If
                Next
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Sub RefreshData()
            Me._ResultDataSet.Tables(0).Clear()
            adpMaster.Fill(Me._ResultDataSet.Tables(0))
        End Sub

        Public Overrides Function ToString() As String
            Return _TableName
        End Function
    End Class
End Namespace
