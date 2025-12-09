''' <summary>
''' How To Use
'''  Dim AFreelyDataSet As New FreelyStandardUDFListDataSet(AutoCount.Authentication.UserSession.CurrentUserSession)
'''  Dim dtSampleList As DataTable = AFreelyDataSet.FreelyUDFDataset.Tables(FreelyStandardUDFListDataSet.ListName_MIJobCard)
'''  Me.lpYourLookUp.Properties.DataSource = dtSampleList
'''  Me.lpYourLookUp.Properties.NullText = ""
'''  Me.lpYourLookUp.Properties.DisplayMember = FreelyStandardUDFListDataSet.ListName_MIJobCard
'''  Me.lpYourLookUp.Properties.ValueMember = FreelyStandardUDFListDataSet.ListName_MIJobCard
''' </summary>
''' <remarks></remarks>
Public Class FreelyStandardUDFListDataSet

    'Declare You UDF Dataset List Here
    '----Example----
    Public Const ListName_MIJobCard As String = "MIJobCard"
    '----Example----
    Public Const Dataset_Name As String = "FreelyDataSet"

    Dim _UserSession As AutoCount.Authentication.UserSession
    Dim _DBSetting As AutoCount.Data.DBSetting
    Dim _ListName As List(Of String)
    Dim _FreelyUDFDataSet As DataSet
    '--Implement The UDFList Here
    Dim _UDFListTypes As String() = {ListName_MIJobCard}

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

    Public Sub New(ByVal AUserSession As AutoCount.Authentication.UserSession)
        _UserSession = AUserSession
        _DBSetting = _UserSession.DBSetting
    End Sub
    Public ReadOnly Property FreelyUDFType As List(Of String)
        Get
            _ListName = New List(Of String)
            For Each s As String In _UDFListTypes
                _ListName.Add(s)
            Next
            Return _ListName
        End Get
    End Property

    Public ReadOnly Property FreelyUDFDataset As DataSet
        Get
            Return GetUDFDataSet()
        End Get
    End Property

    Private Function GetUDFDataSet() As DataSet
        _FreelyUDFDataSet = New DataSet(Dataset_Name)
        For Each s As String In FreelyUDFType
            Dim dtTable As DataTable = GetUDFListTable(s)
            If dtTable IsNot Nothing Then
                _FreelyUDFDataSet.Tables.Add(dtTable)
            End If
        Next
        Return _FreelyUDFDataSet
    End Function
    Public Function GetUDFListTable(ByVal AListName As String) As DataTable
        Return InnerUDFListTable(AListName, GetType(String))
    End Function
    Public Function GetUDFListTable(ByVal AListName As String, ByVal ADataType As Type) As DataTable
        Return InnerUDFListTable(AListName, ADataType)
    End Function
    Private Function InnerUDFListTable(ByVal AListName As String, ByVal ADataType As Type) As DataTable
        Dim AListMaster As New AutoCount.UDF.UDFList(Me.DBSetting)
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
End Class
