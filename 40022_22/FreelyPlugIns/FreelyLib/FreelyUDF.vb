
Imports AutoCount.Data

Namespace Freely
    Public Class UDF
        Public Enum IngUDFType
            [Text] = 0
            [Decimal] = 1
            [Integer] = 2
            [Boolean] = 4
            [Date] = 3
            [Memo] = 5
            [ImageLink] = 6
            [RichText] = 7
            [System] = 8
            [BigInt] = 9
            [Binary] = 10
        End Enum


        Public Class FreelyUDFTable
            Dim AConn As AutoCount.Data.DBSetting = Nothing
            Dim _Table As DataTable
            Public ReadOnly Property Table As DataTable
                Get
                    Return _Table
                End Get
            End Property

            Private _TableName As String = String.Empty
            Private ListOfFreelyField As List(Of FreelyField)
            Public ReadOnly Property TableName As String
                Get
                    Return _TableName
                End Get
            End Property
            Public Sub New(ByVal TableName As String, ByVal DBConn As DBSetting)
                AConn = DBConn
                _TableName = TableName
                ListOfFreelyField = New List(Of FreelyField)

                _Table = New DataTable("FreelyUDF")
                Dim dcCol As DataColumn
                dcCol = New DataColumn
                dcCol.ColumnName = "TableName"
                dcCol.DataType = GetType(String)
                dcCol.DefaultValue = _TableName
                _Table.Columns.Add(dcCol)


                dcCol = New DataColumn
                dcCol.ColumnName = "FieldName"
                dcCol.DataType = GetType(String)
                _Table.Columns.Add(dcCol)


                dcCol = New DataColumn
                dcCol.ColumnName = "FieldType"
                dcCol.DataType = GetType(Integer)
                _Table.Columns.Add(dcCol)

                dcCol = New DataColumn
                dcCol.ColumnName = "Caption"
                dcCol.DataType = GetType(String)
                _Table.Columns.Add(dcCol)

                dcCol = New DataColumn
                dcCol.ColumnName = "Size"
                dcCol.DataType = GetType(Integer)
                _Table.Columns.Add(dcCol)

                dcCol = New DataColumn
                dcCol.ColumnName = "Scale"
                dcCol.DataType = GetType(Integer)
                _Table.Columns.Add(dcCol)

                Dim dcPrimary(2) As DataColumn
                dcPrimary(0) = _Table.Columns("TableName")
                dcPrimary(1) = _Table.Columns("FieldName")
                _Table.PrimaryKey = dcPrimary
                Using sqlConn As New SqlClient.SqlConnection(DBConn.ConnectionString)
                    sqlConn.Open()
                    Using sqlCmd As New SqlClient.SqlCommand("Select *  FROM INFORMATION_SCHEMA.COLUMNS WHERE     (TABLE_NAME = @TableName) AND (SUBSTRING(COLUMN_NAME, 0, 5) = 'ING_')", sqlConn)
                        sqlCmd.Parameters.AddWithValue("TableName", _TableName)
                        Using dtTable As New DataTable
                            dtTable.Load(sqlCmd.ExecuteReader)
                            For Each drRow As DataRow In dtTable.Rows
                                Dim drUDF As DataRow = _Table.NewRow
                                drUDF.Item("FieldName") = drRow.Item("COLUMN_NAME").ToString.ToUpper.Replace("ING_", String.Empty)
                                drUDF.Item("Caption") = drRow.Item("COLUMN_NAME")
                                drUDF.Item("Size") = drRow.Item("CHARACTER_MAXIMUM_LENGTH")
                                Select Case drRow.Item("DATA_TYPE").ToString.ToUpper
                                    Case "varbinary".ToUpper : drUDF.Item("FieldType") = UDF.IngUDFType.Binary
                                    Case "bigint".ToUpper : drUDF.Item("FieldType") = UDF.IngUDFType.BigInt
                                    Case "Int".ToUpper, "smallint".ToUpper : drUDF.Item("FieldType") = UDF.IngUDFType.Integer
                                    Case "Image".ToUpper : drUDF.Item("FieldType") = UDF.IngUDFType.ImageLink
                                    Case "money".ToUpper, "decimal".ToUpper : drUDF.Item("FieldType") = UDF.IngUDFType.Decimal
                                    Case "text".ToUpper : drUDF.Item("FieldType") = UDF.IngUDFType.Text
                                    Case "varchar".ToUpper, "nchar".ToUpper, "char".ToUpper, "nvarchar".ToUpper : drUDF.Item("FieldType") = UDF.IngUDFType.Text
                                    Case "ntext".ToUpper : drUDF.Item("FieldType") = UDF.IngUDFType.Memo
                                End Select
                                _Table.Rows.Add(drUDF)
                            Next
                        End Using
                    End Using
                End Using
                _Table.AcceptChanges()
            End Sub

            Public Sub Add(ByVal AField As FreelyField)
                Dim drUDF As DataRow = _Table.NewRow
                drUDF.Item("FieldName") = AField.Name
                drUDF.Item("Caption") = AField.Caption
                Select Case AField.UDFType
                    Case UDF.IngUDFType.Text
                        drUDF.Item("Size") = AField.TextProperties.Size
                    Case UDF.IngUDFType.Decimal
                        drUDF.Item("Size") = AField.DecimalProperties.Length
                        drUDF.Item("Scale") = AField.DecimalProperties.Scale
                    Case UDF.IngUDFType.Integer
                        drUDF.Item("Size") = AField.TextProperties.Size
                    Case Else
                        drUDF.Item("Size") = AField.TextProperties.Size
                End Select
                _Table.Rows.Add(drUDF)
                ListOfFreelyField.Add(AField)
            End Sub

            Public Sub Save()
                Try


                    Using sqlConn As New SqlClient.SqlConnection(Me.AConn.ConnectionString)
                        sqlConn.Open()

                        For Each IngField As FreelyField In ListOfFreelyField
                            Using sqlCmd As New SqlClient.SqlCommand()
                                sqlCmd.Connection = sqlConn

                                Select Case IngField.UDFType
                                    Case UDF.IngUDFType.Binary
                                        sqlCmd.CommandText = String.Format("ALTER TABLE {0} ADD {2}{1} varbinary({3}) ",
                                                                           Me._TableName,
                                                                           IngField.Name,
                                                                           IngField.FieldPrefix,
                                                                           IIf(IngField.BinaryProperties.Size = -1, "MAX", IngField.BinaryProperties.Size))
                                    Case UDF.IngUDFType.BigInt
                                        sqlCmd.CommandText = String.Format("ALTER TABLE {0} ADD {2}{1} BigInt ", Me._TableName, IngField.Name, IngField.FieldPrefix)
                                    Case UDF.IngUDFType.Memo
                                        sqlCmd.CommandText = String.Format("ALTER TABLE {0} ADD {2}{1} ntext ", Me._TableName, IngField.Name, IngField.FieldPrefix)
                                    Case UDF.IngUDFType.Text
                                        sqlCmd.CommandText = String.Format("ALTER TABLE {0} ADD {3}{1} NVARCHAR({2})", Me._TableName, IngField.Name,
                                                                           IIf(IngField.TextProperties.Size = -1, "MAX", IngField.TextProperties.Size),
                                                                           IngField.FieldPrefix)
                                    Case UDF.IngUDFType.Integer
                                        sqlCmd.CommandText = String.Format("ALTER TABLE {0} ADD {2}{1} int", Me._TableName, IngField.Name, IngField.FieldPrefix)
                                    Case UDF.IngUDFType.Decimal
                                        sqlCmd.CommandText = String.Format("ALTER TABLE {0} ADD {4}{1} Decimal({2},{3})",
                                                                           Me._TableName, IngField.Name,
                                                                           IngField.DecimalProperties.Length,
                                                                           IngField.DecimalProperties.Scale,
                                                                            IngField.FieldPrefix)
                                    Case UDF.IngUDFType.Date
                                        sqlCmd.CommandText = String.Format("ALTER TABLE {0} ADD {2}{1} DateTime", Me._TableName, IngField.Name, IngField.FieldPrefix)
                                    Case UDF.IngUDFType.Boolean
                                        sqlCmd.CommandText = String.Format("ALTER TABLE {0} ADD {2}{1} d_Boolean", Me._TableName, IngField.Name, IngField.FieldPrefix)
                                End Select
                                sqlCmd.ExecuteScalar()
                            End Using
                        Next
                    End Using
                Catch ex As Exception
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
                End Try
            End Sub

        End Class


        Public Class FreelyField
            Private _sFieldPrefix As String = "ING_"
            Public Property Name As String
            Public Property Caption As String
            Public Property FieldPrefix As String = _sFieldPrefix

            Public Property UDFType As Freely.UDF.IngUDFType
            Public Property TextProperties As New FreelyTextProperties
            Public Property DecimalProperties As New FreelyDecimalProperties
            Public Property BinaryProperties As New FreelyBinaryProperties

        End Class
        Public Class FreelyDecimalProperties
            Public Property Scale As Integer = 2
            Public Property Length As Integer = 18
        End Class
        Public Class FreelyTextProperties

            Public Property Size As Integer = 50
            Public Property Unique As Boolean = False
            Public Property Required As Boolean = False
        End Class

        Public Class FreelyBinaryProperties

            Public Property Size As Integer = 50
            Public Property Unique As Boolean = False
            Public Property Required As Boolean = False
        End Class
    End Class

    Public Class UDFList
        Private _AConn As AutoCount.Data.DBSetting
        Private _UDFList As AutoCount.UDF.UDFList
        Private _UDFListName As New List(Of String)
        Private _UDFListRecord As DataTable
        Private _DataSet As DataSet
        Public ReadOnly Property DBConn As AutoCount.Data.DBSetting
            Get
                Return _AConn
            End Get
        End Property
        Public ReadOnly Property UDFList As AutoCount.UDF.UDFList
            Get
                Return _UDFList
            End Get
        End Property

        Public ReadOnly Property UDFListName As List(Of String)
            Get
                Return _UDFListName
            End Get

        End Property

        Public ReadOnly Property UDFListRecord As DataTable
            Get
                Return _UDFListRecord
            End Get

        End Property

        Public ReadOnly Property UDFDataset As DataSet
            Get
                Return GetUDFDataSet()
            End Get
        End Property
        Public Sub New(ByVal ADBConn As AutoCount.Data.DBSetting)
            _AConn = ADBConn
            _UDFList = New AutoCount.UDF.UDFList(_AConn)
            RefreshUDFList()            
        End Sub

        Private Function GetUDFDataSet() As DataSet
            _DataSet = New DataSet("FreelyUDFList")
            For Each s As String In UDFListName
                Dim dtTable As DataTable = GetUDFListTable(s)
                If dtTable IsNot Nothing Then
                    _DataSet.Tables.Add(dtTable)
                End If
            Next
            Return _DataSet
        End Function

        Public Function GetUDFListTable(ByVal AListName As String) As DataTable
            Dim AListMaster As New AutoCount.UDF.UDFList(DBConn)
            Dim AList As New AutoCount.UDF.List

            Dim ADataTable As New DataTable

            AList = AListMaster.Item(AListName)
            If AList IsNot Nothing Then
                ADataTable = New DataTable(AListName)
                Dim ACol As New DataColumn(AListName, GetType(String))
                ADataTable.Columns.Add(ACol)

                For Each s As String In AList.GetItems
                    Dim drNew As DataRow = ADataTable.NewRow
                    drNew.Item(0) = s
                    ADataTable.Rows.Add(drNew)
                Next
            End If
            Return ADataTable
        End Function

        Public Sub RefreshUDFList()
            Try
                Using sqlConn As New SqlClient.SqlConnection(_AConn.ConnectionString)
                    sqlConn.Open()
                    Using sqlCmd As New SqlClient.SqlCommand("Select * From UDFList", sqlConn)
                        Using dtRecord As New DataTable
                            dtRecord.Load(sqlCmd.ExecuteReader)
                            _UDFListRecord = dtRecord
                            _UDFListName = New List(Of String)
                            For Each drRow As DataRow In _UDFListRecord.Rows
                                _UDFListName.Add(drRow.Item("Name").ToString)
                            Next

                            GetUDFDataSet()
                        End Using
                    End Using
                End Using
            Catch ex As Exception

            End Try
        End Sub
        Public Function IsFoundUDFList(ByVal AListName As String) As Boolean
            Try
                Dim AListMaster As New AutoCount.UDF.UDFList(_AConn)

                For Each s As String In AListMaster.GetNames
                    Select Case s.ToLower
                        Case AListName.ToLower
                            Return True
                    End Select
                Next
            Catch ex As Exception
                Throw ex
            End Try
            Return False
        End Function

        Public Sub AddUDFList(ByVal AUDFListName As String, ByVal ParamArray AItems As String())
            Dim AList As New AutoCount.UDF.List
            AList.Name = AUDFListName
            AList.SetItems(AItems)
            _UDFList.Add(AList)
            _UDFList.Save()
        End Sub
    End Class
End Namespace

