Imports System.Data.SqlClient
Imports System.Linq.Expressions
Imports AutoCount
Imports AutoCount.Authentication
Imports DevExpress.XtraEditors

Public Class DocumentReportingCommand
    Implements IDisposable
    Private disposedValue As Boolean

    Private _UserSession As UserSession
    Private _ReportCriteria As DocumentReportingModel.DocumentReportCriteria
    'Private _ResultDataSet As DataSet
    Private _CSCreateEntity As List(Of CSCreateEntity)

    Public ReadOnly Property UserSession As UserSession
        Get
            Return _UserSession
        End Get
    End Property
    Public ReadOnly Property ReportCriteria As DocumentReportingModel.DocumentReportCriteria
        Get
            Return _ReportCriteria
        End Get
    End Property
    Public ReadOnly Property CSCreateEntity As List(Of CSCreateEntity)
        Get
            Return _CSCreateEntity
        End Get
    End Property

    Public Sub New(AUserSesison As UserSession)
        _UserSession = AUserSesison

        Init()
    End Sub
    Private Sub Init()
        _ReportCriteria = New DocumentReportingModel.DocumentReportCriteria
    End Sub

    Public Function Inquiry() As List(Of CSCreateEntity)
        Try
            '_ResultDataSet = New DataSet("Result")
            _CSCreateEntity = New List(Of CSCreateEntity)

            Dim CSRecordList = GetCSRecords()
            Return CSRecordList
        Catch ex As Exception
            Return New List(Of CSCreateEntity)
        End Try
    End Function

    Public Function GetCSRecords() As List(Of CSCreateEntity)
        Const MAX_RECORDS As Integer = 1000
        Dim result As New List(Of CSCreateEntity)

        Try
            Using conn As New SqlConnection(Me._UserSession.DBSetting.ConnectionString)
                conn.Open()

                Dim totalCount As Integer = GetFilteredRecordCount(conn)
                If totalCount >= MAX_RECORDS Then
                    Dim dialogResult As DialogResult = XtraMessageBox.Show($"Too many records found ({totalCount}). {vbCrLf}Only the most recent {MAX_RECORDS} records will be shown.",
                                        "Autosoft Solution Sdn Bhd", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)

                    If dialogResult = DialogResult.Cancel Then
                        Exit Function
                    End If
                End If

                Dim sql As String = $"SELECT TOP {MAX_RECORDS} CS.*,
                                      CASE WHEN EXISTS (
                                          SELECT 1
                                          FROM CSDTL d
                                          INNER JOIN Item i ON d.ItemCode = i.ItemCode
                                          WHERE d.DocKey = CS.DocKey AND i.MustGenerateEInvoice = 1
                                      ) THEN CAST (1 AS bit) ELSE CAST(0 AS bit) END AS ItemGenerateEInvoice
                                      FROM CS
                                      WHERE (SubmitEInvoice = 'F'
                                         OR (SubmitEInvoice = 'T' AND EInvoiceStatus = 'Invalid'))"

                Using cmd As New SqlCommand(sql, conn)
                    cmd.CommandTimeout = 120 '<--- default is 30 seconds
                    ToFilteringCommand(cmd)
                    cmd.CommandText &= " ORDER BY DocDate DESC"

                    Using reader = cmd.ExecuteReader()
                        Dim docKeys As New List(Of Long)

                        While reader.Read()
                            Dim entity As New CSCreateEntity With {
                                    .DocKey = Convert.ToInt64(reader("DocKey")),
                                    .DocNo = reader("DocNo").ToString(),
                                    .DocDate = Convert.ToDateTime(reader("DocDate")).ToString("dd/MM/yyyy"),
                                    .DebtorCode = reader("DebtorCode").ToString(),
                                    .DebtorName = reader("DebtorName").ToString(),
                                    .NetTotal = Convert.ToDecimal(reader("NetTotal")),
                                    .SubmitEInvoice = reader("SubmitEInvoice").ToString(),
                                    .EInvoiceStatus = reader("EInvoiceStatus").ToString(),
                                    .IsSelected = False,
                                    .ItemGenerateEInvoice = Convert.ToBoolean(reader("ItemGenerateEInvoice"))
                                }

                            result.Add(entity)
                            docKeys.Add(entity.DocKey)
                        End While

                        Dim outstandingDict = GetOutstandingInBatch(docKeys)
                        For Each cs In result
                            cs.Outstanding = If(outstandingDict.ContainsKey(cs.DocKey), outstandingDict(cs.DocKey), 0)
                        Next
                    End Using
                End Using
            End Using

            Return result
        Catch ex As Exception
            XtraMessageBox.Show($"Exception on GetCSRecord: {ex.Message}", "Autosoft Solution", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function
    Private Sub ToFilteringCommand(sqlCmd As SqlCommand)
        If Me._ReportCriteria.DateRangeFilter.Type <> AutoCount.SearchFilter.FilterType.None Then
            sqlCmd.CommandText &= " AND " & Me._ReportCriteria.DateRangeFilter.BuildSQL(sqlCmd)
        End If

        If Me._ReportCriteria.DebtorFilter.Type <> AutoCount.SearchFilter.FilterType.None Then
            sqlCmd.CommandText &= " AND " & Me._ReportCriteria.DebtorFilter.BuildSQL(sqlCmd)
        End If
    End Sub
    Private Function GetOutstandingInBatch(docKeys As List(Of Long)) As Dictionary(Of Long, Decimal)
        Dim dict As New Dictionary(Of Long, Decimal)

        Using sqlConn As New SqlClient.SqlConnection(Me.UserSession.DBSetting.ConnectionString)
            sqlConn.Open()

            Const batchSize As Integer = 1000

            For i As Integer = 0 To docKeys.Count - 1 Step batchSize
                Dim batch = docKeys.Skip(i).Take(batchSize).ToList()
                Dim inClause = String.Join(",", batch)

                Dim queryStr As String = $"SELECT SourceKey, Outstanding FROM ARInvoice WHERE SourceKey IN ({inClause})"

                Using sqlCmd As New SqlClient.SqlCommand(queryStr, sqlConn)
                    sqlCmd.CommandTimeout = 120

                    Using reader = sqlCmd.ExecuteReader()
                        While reader.Read()
                            Dim key = Convert.ToInt32(reader("SourceKey"))
                            Dim val = If(IsDBNull(reader("Outstanding")), 0D, Convert.ToDecimal(reader("Outstanding")))
                            dict(key) = val
                        End While
                    End Using
                End Using
            Next
        End Using

        Return dict
    End Function
    Private Function GetFilteredRecordCount(conn As SqlConnection) As Integer
        Dim totalCount As Integer = 0

        Dim totalCountSql As String = "SELECT COUNT(*) FROM CS WHERE SubmitEInvoice = 'F'"

        Using countCmd As New SqlCommand(totalCountSql, conn)
            ToFilteringCommand(countCmd)
            totalCount = Convert.ToInt32(countCmd.ExecuteScalar())
        End Using

        Return totalCount
    End Function


    Public Function UpdateSubmitEInvoiceFlag(records As List(Of CSCreateEntity)) As List(Of CSCreateEntity)
        Dim remainSelected As New List(Of CSCreateEntity)

        If records Is Nothing OrElse records.Count = 0 Then Return remainSelected '<--- function exits early, just like Sub

        Dim CashSalecmd As AutoCount.Invoicing.Sales.CashSale.CashSaleCommand = AutoCount.Invoicing.Sales.CashSale.CashSaleCommand.Create(_UserSession, _UserSession.DBSetting)
        Dim myGeneralSetting = AutoCount.Settings.GeneralSetting.GetOrCreate(_UserSession.DBSetting)
        Dim isAlwaysUseToday As Boolean = myGeneralSetting.AlwaysUseTodayDateAsEInvoiceIssueDate

        Dim warningRecords As New List(Of String)
        Dim flaggedRecords As New List(Of AutoCount.Invoicing.Sales.CashSale.CashSale)
        Dim normalRecords As New List(Of AutoCount.Invoicing.Sales.CashSale.CashSale)
        Dim failedRecords As New List(Of String)

        For Each rec As CSCreateEntity In records
            Try
                Dim cashSale As AutoCount.Invoicing.Sales.CashSale.CashSale =
                        TryCast(CashSalecmd.Edit(rec.DocNo), AutoCount.Invoicing.Sales.CashSale.CashSale)

                If cashSale IsNot Nothing Then
                    Dim docDate As DateTime = cashSale.DocDate.Value
                    Dim serverToday As DateTime = _UserSession.DBSetting.GetServerTime().Date
                    Dim daysDiff As Integer = (serverToday - docDate).Days

                    If daysDiff > 3 AndAlso Not isAlwaysUseToday Then
                        warningRecords.Add($"{cashSale.DocNo} (DocDate: {docDate:dd/MM/yyyy})")
                        flaggedRecords.Add(cashSale)
                    Else
                        normalRecords.Add(cashSale)
                    End If
                End If
            Catch ex As Exception
                failedRecords.Add($"{rec.DocNo}: {ex.Message}")
            End Try
        Next

        If flaggedRecords.Count > 0 Then
            Dim msg As String = "The following document(s) have invalid e-Invoice Issue Date" & vbCrLf &
                            String.Join(vbCrLf, warningRecords) & vbCrLf & vbCrLf &
                            "If you proceed, the e-Invoice status for these documents will be 'Invalid'" & vbCrLf &
                            "Do you want to proceed to submit all e-invoices?"
            Dim result = XtraMessageBox.Show(msg, "Autosoft: Invalid e-Invoice Issue Date", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)

            If result = DialogResult.Cancel Then
                remainSelected.AddRange(records)
                Return remainSelected
            End If
        End If

        Dim allCashSales = normalRecords.Concat(flaggedRecords).ToList()

        For Each cs In allCashSales
            Try
                cs.SubmitEInvoice = True

                Dim myRowField = cs.GetType().GetField("myRow", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
                Dim myRow = TryCast(myRowField?.GetValue(cs), DataRow)
                If myRow IsNot Nothing Then
                    myRow("SubmitEInvoice") = AutoCount.Converter.BooleanToText(True)
                End If
                cs.Save()

            Catch ex As Exception
                failedRecords.Add($"{cs.DocNo}: {ex.Message}")
            End Try
        Next

        If failedRecords.Count > 0 Then
            Dim failMsg As String = $"Failed to submit {failedRecords.Count} record(s):{vbCrLf}" &
                                String.Join(vbCrLf, failedRecords)
            XtraMessageBox.Show(failMsg, "Autosoft: Submit E-Invoice", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Dim failedDocNos = failedRecords.Select(Function(f) f.Split(":"c)(0)).ToList()
            remainSelected.AddRange(records.
                                    Where(Function(r) failedDocNos.Contains(r.DocNo)).
                                    Select(Function(r) New CSCreateEntity With {
                                        .DocNo = r.DocNo,
                                        .IsSelected = True
                                               }))
        End If

        Return remainSelected
    End Function

    Public Function GetCSRecordsLINQ() As List(Of CSCreateEntity)
        Const MAX_RECORDS As Integer = 1000

        Try
            Using db As New CSEntity(_UserSession)

                Dim query = (From cs In db.CS
                             Where cs.SubmitEInvoice = "F"
                             Order By cs.DocDate Descending
                             Select cs.DocKey, cs.DocNo, cs.DocDate, cs.DebtorCode, cs.DebtorName, cs.NetTotal, cs.SubmitEInvoice).ToList()

                Dim totalCount As Integer = query.Count()
                If totalCount > MAX_RECORDS Then
                    XtraMessageBox.Show($"Too many records found ({totalCount}). {vbCrLf}Only the most recent {MAX_RECORDS} records will be shown.",
                                        "Autosoft Solution Sdn Bhd", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                query = query.Take(MAX_RECORDS).ToList()
                Dim csList = query.ToList()

                Dim docKeys = csList.Select(Function(c) c.DocKey).ToList()
                Dim outstandingDict = GetOutstandingInBatch(docKeys)

                Dim result = csList.Select(Function(cs)
                                               Dim outstandingAmt As Decimal = 0
                                               If outstandingDict.ContainsKey(cs.DocKey) Then
                                                   outstandingAmt = outstandingDict(cs.DocKey)
                                               End If

                                               Return New CSCreateEntity With {
                                               .DocKey = cs.DocKey,
                                               .DocNo = cs.DocNo,
                                               .DocDate = cs.DocDate.ToString("dd/MM/yyyy"),
                                               .DebtorCode = cs.DebtorCode,
                                               .DebtorName = cs.DebtorName,
                                               .NetTotal = cs.NetTotal,
                                               .Outstanding = outstandingAmt,
                                               .SubmitEInvoice = cs.SubmitEInvoice
                                           }
                                           End Function).ToList()

                Return result
            End Using
        Catch ex As Exception
            AppMessage.ShowErrorMessage("Error during inquiry: " + ex.Message)
            Return Nothing
        End Try
    End Function

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects)
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override finalizer
            ' TODO: set large fields to null
            disposedValue = True
        End If
    End Sub

    ' ' TODO: override finalizer only if 'Dispose(disposing As Boolean)' has code to free unmanaged resources
    ' Protected Overrides Sub Finalize()
    '     ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
    '     Dispose(disposing:=False)
    '     MyBase.Finalize()
    ' End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
        Dispose(disposing:=True)
        GC.SuppressFinalize(Me)
    End Sub
End Class
