Namespace Freely.Registry

    Public Class FreelyRegistry
        Const _RegistryTable As String = "PlugIn_Freely_Registry"
        Dim _AConn As AutoCount.Data.DBSetting


        Public Sub New(ByVal AConn As AutoCount.Data.DBSetting)
            _AConn = AConn
            If Not IsRegistryTableExists() Then CreateRegistryTable()
        End Sub
        Public Shared Function GetRegistryValue(ByVal ARegistryValue As String) As String
            Dim AKeyCmd As New Registry.FreelyRegistry(AutoCount.Authentication.UserSession.CurrentUserSession.DBSetting)
            Dim AKey As Registry.FreelyRegistryKey = AKeyCmd.GetRegistryKey(ARegistryValue)
            If AKey.HasValue Then
                Return AKey.RegistryValue
            Else
                Return String.Empty
            End If
        End Function
        Private Function IsRegistryTableExists() As Boolean
            Try
                Using sqlConn As New SqlClient.SqlConnection(_AConn.ConnectionString)
                    sqlConn.Open()
                    Using sqlCmd As New SqlClient.SqlCommand("SELECT * FROM sys.objects WHERE object_id =OBJECT_ID(@ObjectID) and Type =@Type", sqlConn)
                        sqlCmd.Parameters.AddWithValue("ObjectID", _RegistryTable)
                        sqlCmd.Parameters.AddWithValue("Type", "U")
                        Using dtTable As New DataTable
                            dtTable.Load(sqlCmd.ExecuteReader)
                            Return dtTable.Rows.Count > 0
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
            End Try
            Return False
        End Function

        Private Sub CreateRegistryTable()
            Try
                Using sqlConn As New SqlClient.SqlConnection(_AConn.ConnectionString)
                    sqlConn.Open()
                    Using sqlCmd As New SqlClient.SqlCommand(String.Format("CREATE TABLE [dbo].[{0}]( [RegID] [nvarchar](50) NOT NULL,[RegType] [nvarchar](50)  NULL,[RegValue] [nvarchar](255)  NULL CONSTRAINT [PK_{0}] PRIMARY KEY CLUSTERED([RegID] ASC)) ", _RegistryTable), sqlConn)
                        sqlCmd.ExecuteNonQuery()
                    End Using
                End Using
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
            End Try

        End Sub
        Public Function DeleteRegistryKey(ByVal AKey As FreelyRegistryKey) As Boolean
            If AKey Is Nothing Then Return False
            If Not AKey.HasValue Then Return False

            Try
                Using sqlConn As New SqlClient.SqlConnection(_AConn.ConnectionString)
                    sqlConn.Open()

                    Using sqlDelete As New SqlClient.SqlCommand(String.Format("Delete From {0} Where RegID=@RegID", _RegistryTable), sqlConn)
                        sqlDelete.Parameters.AddWithValue("RegID", AKey.RegistryID)
                        sqlDelete.ExecuteNonQuery()
                        Return True
                    End Using
                End Using

            Catch ex As Exception

            End Try
            Return False
        End Function

        Public Function GetRegistryKey(ByVal ARegistryID As String) As FreelyRegistryKey
            Using sqlConn As New SqlClient.SqlConnection(_AConn.ConnectionString)
                sqlConn.Open()
                Using sqlCmd As New SqlClient.SqlCommand(String.Format("Select * From {0} Where RegID=@RegID", _RegistryTable), sqlConn)
                    sqlCmd.Parameters.AddWithValue("RegID", ARegistryID)
                    Using dtTable As New DataTable
                        dtTable.Load(sqlCmd.ExecuteReader)
                        For Each drRow As DataRow In dtTable.Rows
                            Return New FreelyRegistryKey(drRow)
                        Next
                        Return New FreelyRegistryKey(Nothing)
                    End Using
                End Using
            End Using
        End Function

        Public Function SaveRegistryKey(ByVal AKey As FreelyRegistryKey) As Boolean
            If AKey Is Nothing Then Return False
            If Not AKey.HasValue Then Return False

            Try
                Using sqlConn As New SqlClient.SqlConnection(_AConn.ConnectionString)
                    sqlConn.Open()
                    Using sqlCmd As New SqlClient.SqlCommand(String.Format("Select * From {0}", _RegistryTable), sqlConn)
                        Using dtTable As New DataTable
                            dtTable.Load(sqlCmd.ExecuteReader)

                            If dtTable.Select(String.Format("RegID='{0}'", AKey.RegistryID)).Length = 0 Then

                                Using sqlInsert As New SqlClient.SqlCommand(String.Format("Insert Into {0} (  RegID, RegType, RegValue) VALUES (@RegID,@RegType,@RegValue)", _RegistryTable), sqlConn)
                                    sqlInsert.Parameters.AddWithValue("RegID", AKey.RegistryID)
                                    sqlInsert.Parameters.AddWithValue("RegType", AKey.RegistryType)
                                    sqlInsert.Parameters.AddWithValue("RegValue", AKey.RegistryValue)
                                    sqlInsert.ExecuteNonQuery()
                                End Using

                            Else
                                Using sqlUpdate As New SqlClient.SqlCommand(String.Format("Update {0} SET RegType=@RegType , RegValue=@RegValue Where RegID=@RegID", _RegistryTable), sqlConn)
                                    sqlUpdate.Parameters.AddWithValue("RegID", AKey.RegistryID)
                                    sqlUpdate.Parameters.AddWithValue("RegType", AKey.RegistryType)
                                    sqlUpdate.Parameters.AddWithValue("RegValue", AKey.RegistryValue)
                                    sqlUpdate.ExecuteNonQuery()
                                End Using
                            End If

                            Return True
                        End Using
                    End Using
                End Using
            Catch ex As Exception

            End Try
            Return False
        End Function
    End Class

    Public Class FreelyRegistryKey
        Const _RegistryTable As String = "PlugIn_Freely_Registry"
        Private _RegID As String = String.Empty
        Private _RegistryType As Enumeration.FreelyEnum.FreelyRegistryType = Freely.Enumeration.FreelyEnum.FreelyRegistryType.String
        Private _RegistryValue As String = String.Empty

        Private _HasValue As Boolean = False
        Private _drRow As DataRow = Nothing

        Public ReadOnly Property RegistryID As String
            Get
                Return _RegID
            End Get
        End Property
        Public ReadOnly Property HasValue As Boolean
            Get
                Return _HasValue
            End Get
        End Property

        Public Property RegistryType As Freely.Enumeration.FreelyEnum.FreelyRegistryType
            Get
                Return _RegistryType
            End Get
            Set(ByVal value As Freely.Enumeration.FreelyEnum.FreelyRegistryType)
                _RegistryType = value
                _drRow.Item("RegType") = _RegistryType
            End Set
        End Property

        Public Property RegistryValue As String
            Get
                Return _RegistryValue
            End Get
            Set(ByVal value As String)
                _RegistryValue = value
                If _drRow IsNot Nothing Then
                    _drRow.Item("RegValue") = _RegistryValue
                End If
            End Set
        End Property

        Friend Sub New(ByVal ADataRow As DataRow)
            '  RegID, RegType, RegValue
            If ADataRow IsNot Nothing Then
                Me._drRow = ADataRow
                _RegID = IIf(ADataRow.Item("RegID") Is DBNull.Value, String.Empty, ADataRow.Item("RegID"))
                Dim sValue As String = IIf(ADataRow.Item("RegType") Is DBNull.Value, String.Empty, ADataRow.Item("RegType"))
                If sValue.Length = 0 Then
                    _RegistryType = Freely.Enumeration.FreelyEnum.FreelyRegistryType.String
                Else
                    _RegistryType = Convert.ToInt32(sValue)
                End If


                _RegistryValue = IIf(ADataRow.Item("RegValue") Is DBNull.Value, String.Empty, ADataRow.Item("RegValue"))
                _HasValue = True
            Else

                _HasValue = False
            End If
        End Sub

        Public Shared Function Create(ByVal ARegID As String, ByVal ARegType As Freely.Enumeration.FreelyEnum.FreelyRegistryType, ByVal ARegValue As String) As FreelyRegistryKey

            Dim ADataTable As New DataTable("RegistryKey")

            ADataTable.Columns.Add(New DataColumn("RegID", GetType(String)))
            ADataTable.Columns.Add(New DataColumn("RegType", GetType(Integer)))
            ADataTable.Columns.Add(New DataColumn("RegValue", GetType(String)))

            Dim drNew As DataRow = ADataTable.NewRow()
            drNew.Item("RegID") = ARegID
            drNew.Item("RegType") = ARegType
            drNew.Item("RegValue") = ARegValue
            Return New FreelyRegistryKey(drNew)

        End Function
    End Class

End Namespace


