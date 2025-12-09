
'Namespace Freely.Adapter
'Lai Disable On 2022/03/22 already moved to Freely.Standard.DataAdapter
'    Public Class FreelyDataAdapter
'        Private _SQLTableName As String = String.Empty
'        Private _DBSetting As AutoCount.Data.DBSetting = Nothing
'        Private _SQLConn As SqlClient.SqlConnection = Nothing
'        Private _ResultDataSet As DataSet = Nothing
'        Private _SQLAdapter As SqlClient.SqlDataAdapter = Nothing

'        Public ReadOnly Property CreatedBy As String
'            Get
'                Return "Lai Wei Loong 2014"
'            End Get
'        End Property
'        Public ReadOnly Property DataAdapter As SqlClient.SqlDataAdapter
'            Get
'                Return _SQLAdapter
'            End Get

'        End Property
'        Public ReadOnly Property ResultDateSet As DataSet
'            Get
'                Return _ResultDataSet
'            End Get
'        End Property
'        Public ReadOnly Property SQLTableName As String
'            Get
'                Return _SQLTableName
'            End Get
'        End Property

'        Public ReadOnly Property DBSetting As AutoCount.Data.DBSetting
'            Get
'                Return _DBSetting
'            End Get
'        End Property

'        Public Sub New(ByVal AConn As AutoCount.Data.DBSetting, ByVal ASQLTableName As String)
'            _SQLTableName = ASQLTableName
'            _DBSetting = AConn
'            Init()
'        End Sub
'        Public Function Save() As Integer
'            Try
'                Return _SQLAdapter.Update(Me._ResultDataSet)
'            Catch ex As Exception
'                Throw ex
'            End Try
'        End Function
'        Public Sub Fill(Optional ByVal AWhereCondition As String = "")
'            Try
'                Dim sSQL As String = String.Format("Select * From {0} WHERE 1=1 ", SQLTableName)
'                If AWhereCondition.Length > 0 Then
'                    sSQL = sSQL & " AND " & AWhereCondition
'                End If

'                Dim sSQLSelect As New SqlClient.SqlCommand(sSQL, Me._SQLConn)
'                _SQLAdapter.SelectCommand = sSQLSelect
'                _SQLAdapter.Fill(Me._ResultDataSet)
'            Catch ex As Exception
'                Throw ex
'            End Try
'        End Sub
'        Public Sub Init()
'            Try
'                _SQLConn = New SqlClient.SqlConnection(_DBSetting.ConnectionString)
'                _SQLConn.Open()
'                _ResultDataSet = New DataSet
'                If _SQLTableName.Length = 0 Then Return
'                _SQLAdapter = New SqlClient.SqlDataAdapter(String.Format("Select * From {0}", SQLTableName), _SQLConn)

'                Dim ACommndBuilder As New SqlClient.SqlCommandBuilder(_SQLAdapter)
'                ACommndBuilder.ConflictOption = ConflictOption.OverwriteChanges

'                _SQLAdapter.DeleteCommand = ACommndBuilder.GetDeleteCommand()
'                _SQLAdapter.UpdateCommand = ACommndBuilder.GetUpdateCommand
'                _SQLAdapter.InsertCommand = ACommndBuilder.GetInsertCommand()

'                _SQLAdapter.FillSchema(_ResultDataSet, SchemaType.Source)
'            Catch ex As Exception
'                Throw ex
'            End Try
'        End Sub

'    End Class
'End Namespace