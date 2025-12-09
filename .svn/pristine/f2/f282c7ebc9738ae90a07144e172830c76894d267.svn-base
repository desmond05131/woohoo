Imports AutoCount.SearchFilter

Public Class DocumentReportingModel
    Public Class DocumentReportCriteria
        Public Property DateRangeFilter As AutoCount.SearchFilter.Filter
        Public Property DebtorFilter As AutoCount.SearchFilter.Filter

        Public Sub New()
            ReInitFilter()
        End Sub
        Public Sub ReInitFilter()
            If DateRangeFilter Is Nothing Then
                DateRangeFilter = New AutoCount.SearchFilter.Filter("CS", "DocDate", "DocDate", FilterControlType.Date)
            End If

            If DebtorFilter Is Nothing Then
                DebtorFilter = New Filter("CS", "DebtorCode", "DebtorCode", FilterControlType.Debtor)
            End If
        End Sub
    End Class
End Class
