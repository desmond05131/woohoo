Public Class ExcelClass
    Public Shared Function GetDataConnectionString(ByVal DataFile As String, Optional ByVal bFirstRowAsHeader As Boolean = True) As String
        If IO.Path.GetExtension(DataFile).ToUpper = ".XLS" Or IO.Path.GetExtension(DataFile).ToUpper = ".XLSX" Then
            Return String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;HDR={1};IMEX=2'", DataFile, IIf(bFirstRowAsHeader, "YES", "NO"))
        Else
            Return ""
        End If
    End Function
    Public Shared Function ReturnDataTable(ByVal Directory As String) As DataTable
        Try
            Using OleConn As New OleDb.OleDbConnection(Directory)
                OleConn.Open()
                Dim dt As New DataTable
                dt = OleConn.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables, Nothing)
                If dt IsNot Nothing Then
                    Return dt
                End If
                OleConn.Close()
            End Using
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
        End Try
        Return New DataTable
    End Function
    Public Shared Function ReturnExcelByTableName(ByVal sExcelConn As String, ByVal TableName As String) As DataSet
        Using OleConn As New OleDb.OleDbConnection(sExcelConn)
            OleConn.Open()
            Using dsExcel As New DataSet
                Dim sSql As String = String.Format("Select * From [{0}]", TableName) 'A3:V9999
                Using OleComm As New OleDb.OleDbCommand(sSql, OleConn)
                    Using DataTable As New DataTable
                        DataTable.Load(OleComm.ExecuteReader)
                        dsExcel.Tables.Add(DataTable)
                        Return dsExcel
                    End Using
                End Using
            End Using
            OleConn.Close()
        End Using
    End Function
End Class
