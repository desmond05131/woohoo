Imports System.ComponentModel

Namespace Freely.Controls.Excel
    Public Enum ExcelFormat
        xls = 0
        xlsx = 1
        csv = 2
    End Enum
    <ToolboxBitmap(GetType(Label))>
    Public Class FreelyExcelClass
        Inherits System.ComponentModel.Component
        Implements IListSource

        Private _ExcelConnectingBuilder As New ExcelConnectingBuilder
        Private _ExcelString As String = String.Empty
        Private _ExcelConnection As OleDb.OleDbConnection
        Private _FileName As String = String.Empty
        Private _bOpen As Boolean = False
        Private _DataSource As Object
        Private _ExcelSheetCount As Integer = 0
        '   Private _BindingSource As ExcelBindingSource


        <Description("Fire When Excel Connection Opne Or Close"), Category("Freely Excel")>
        Public Event ExcelConnectionOpenClose(ByVal sender As Object, ByVal Staus As Boolean)
        <Description("Fire When Excel File Name Changed"), Category("Freely Excel")>
        Public Event ExcelFileNameChanged(ByVal sender As Object, ByVal FileName As String)

        <Description("Define The Excel Path"), Category("Freely Excel"), _
        Editor(GetType(ExcelOpenFileDialog), GetType(System.Drawing.Design.UITypeEditor))>
        Public Property FileName As String
            Get
                Return _FileName
            End Get
            Set(ByVal value As String)
                _FileName = value
                Select Case IO.Path.GetExtension(_FileName).ToUpper
                    Case ".xlsx".ToUpper : Me.ExcelFormat = Freely.Controls.Excel.ExcelFormat.xlsx
                        _ExcelConnection = New OleDb.OleDbConnection(ExcelConnectionString)
                    Case ".xls".ToUpper : Me.ExcelFormat = Freely.Controls.Excel.ExcelFormat.xls
                        _ExcelConnection = New OleDb.OleDbConnection(ExcelConnectionString)
                    Case ".csv".ToUpper : Me.ExcelFormat = Freely.Controls.Excel.ExcelFormat.csv
                End Select
                RaiseEvent ExcelFileNameChanged(Me, _FileName)
            End Set
        End Property
        <Description("Define the Connection"), Category("Freely Excel Connection")>
        Public Property Open() As Boolean
            Get
                Return _bOpen
            End Get
            Set(ByVal value As Boolean)
                _bOpen = value
                Try
                    If _bOpen Then
                        If _ExcelConnection IsNot Nothing Then
                            _ExcelConnection.Open()
                        End If
                        RaiseEvent ExcelConnectionOpenClose(Me, True)
                    Else
                        If _ExcelConnection IsNot Nothing Then
                            _ExcelConnection.Close()
                            _ExcelSheetCount = 0
                        End If

                        RaiseEvent ExcelConnectionOpenClose(Me, False)
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Set
        End Property

        'Public Property ExcelSheetBinding As ExcelBindingSource
        '    Get
        '        Return _BindingSource
        '    End Get
        '    Set(ByVal value As ExcelBindingSource)
        '        _BindingSource = value
        '    End Set
        'End Property

        Public Property DataSouce As Object

        <Description("This Component Created By Lai Wei Loong"), Category("Author"), Browsable(True)>
        Public ReadOnly Property Author
            Get
                Return "Lai Wei Loong 2013"
            End Get
        End Property
        <Description("This Component Created By Lai Wei Loong"), Category("Author"), Browsable(True)>
        Public ReadOnly Property Company
            Get
                Return "Freely"
            End Get
        End Property

        <Description("Define The Excel Format"), Category("Freely Excel"), Browsable(True)>
        Public Property ExcelFormat As ExcelFormat = Freely.Controls.Excel.ExcelFormat.xls

        <Description("Excel Sheet Table List"), Category("Freely Excel Connection")>
        Public ReadOnly Property ExcelSheetName As DataTable
            Get
                Return GetExcelSheetName()
            End Get
        End Property
        Public ReadOnly Property ExcelSheetCount As Integer
            Get
                Return _ExcelSheetCount
            End Get
        End Property

        <Description("Excel Ole DB Connection String"), Category("Freely Excel Connection")>
        Public ReadOnly Property ExcelConnection As OleDb.OleDbConnection
            Get
                Return _ExcelConnection
            End Get
        End Property
        <Description("Excel Connection String"), Category("Freely Excel Connection")>
        Public ReadOnly Property ExcelConnectionString As String
            Get
                _ExcelConnectingBuilder = New ExcelConnectingBuilder(Me.FileName)
                _ExcelString = _ExcelConnectingBuilder.ExcelConnectionString
                Return _ExcelString
            End Get
        End Property

        Public Function GetTableByName(ByVal AName As String) As DataSet
            Using dsExcel As New DataSet
                If Me.ExcelFormat <> Freely.Controls.Excel.ExcelFormat.csv Then
                    Dim sSQL As String = String.Format("SELECT * FROM [{0}]", AName)
                    Using oleComm As New OleDb.OleDbCommand(sSQL, Me.ExcelConnection)
                        Using ADatatable As New DataTable
                            ADatatable.Load(oleComm.ExecuteReader)
                            dsExcel.Tables.Add(ADatatable)
                            Return dsExcel
                        End Using
                    End Using
                End If
            End Using
            Return New DataSet
        End Function

        Public Function GetExcelSheetName() As DataTable
            Try
                Dim ADt As New DataTable("ExcelSheetTable")
                ADt = ExcelConnection.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables, Nothing)
                ADt.TableName = "ExcelSheetTable"
                If ADt IsNot Nothing Then
                    _ExcelSheetCount = ADt.Rows.Count
                    If ADt.Rows.Count > 0 Then
                        Return ADt
                    End If
                End If
            Catch ex As Exception

            End Try
            Return New DataTable
        End Function



        Public Sub New()
            If Me.Open = True Then Me.Open = False
        End Sub

        Public ReadOnly Property ContainsListCollection As Boolean Implements System.ComponentModel.IListSource.ContainsListCollection
            Get
                Return True
            End Get
        End Property

        Public Function GetList() As System.Collections.IList Implements System.ComponentModel.IListSource.GetList
            Dim ADataSet As New DataSet
            Dim dtTable As DataTable = GetExcelSheetName()

            If dtTable.Rows.Count = 0 Then
                dtTable = New DataTable("ExcelSheetTable")
            End If
            ADataSet.Tables.Add(dtTable.Copy)
            DataSouce = ADataSet
            Dim listSource As IListSource = TryCast(ADataSet, IListSource)
            Return listSource.GetList()
        End Function
    End Class


    Public Class ExcelConnectingBuilder
        Private _ExtendedProperties As New List(Of String)
        Private _ExtendedPropertyString As String = String.Empty
        Public Property Provider As String = "Microsoft.ACE.OLEDB.12.0"

        ''' <summary>
        ''' Define Excel File Path
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DataSource As String = String.Empty
        Public Property ExtendedProperty As New ExcelConnectingExtendedProperties


        Public ReadOnly Property ExtendedProperties As List(Of String)
            Get
                _ExtendedProperties = New List(Of String)
                _ExtendedProperties.Add(ExtendedProperty.ExcelVersion)
                _ExtendedProperties.Add(ExtendedProperty.HDR)
                Return _ExtendedProperties
            End Get
        End Property
        Public ReadOnly Property ExtendedPropertyString As String
            Get
                Dim s As String = String.Empty
                For Each sProperty As String In ExtendedProperties
                    s = s & String.Format("{0};", sProperty)
                Next
                _ExtendedPropertyString = s
                Return _ExtendedPropertyString
            End Get
        End Property
        Public ReadOnly Property ExcelConnectionString()
            Get
                Return String.Format("Provider={0};Data Source={1};Extended Properties='{2}';", _Provider, _DataSource, ExtendedPropertyString)
            End Get
        End Property
        Public Sub New(ByVal ADataSource As String)
            _DataSource = ADataSource
        End Sub

        Public Sub New()

        End Sub
        'Public Shared Function GetExcelConnectionString(ByVal AExcelFile As String, Optional ByVal bFirstRowAsHeader As Boolean = True) As String
        '    'HDR = Mean Need First Row as Header 
        '    Return String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;HDR={1}';", AExcelFile, IIf(bFirstRowAsHeader, "YES", "NO"))
        'End Function
    End Class

    Public Class ExcelConnectingExtendedProperties
        Public Property ExcelVersion As String = "Excel 12.0"
        ''' <summary>
        ''' HDR = Mean Need First Row as Header 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property HDR As String = "HRD=YES"
    End Class

    Public Class ExcelOpenFileDialog
        Inherits System.Drawing.Design.UITypeEditor

        Private ADialog As New OpenFileDialog

        Public Overrides Function EditValue(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal provider As System.IServiceProvider, ByVal value As Object) As Object
            If Not (context Is Nothing) And (Not context.Instance Is Nothing) Then
                If TryCast(value, String) <> "" Then ADialog.FileName = TryCast(value, String)
                With ADialog
                    .ValidateNames = True
                    .CheckFileExists = True
                    .Filter = "Excel 2007 (*.xlsx) |*.xlsx|Excel 2003 (*.xls)|*.xls|CSV (*.csv)|*.csv|All Files(*.*)|*.*"
                    .ShowDialog()
                    value = ADialog.FileName
                End With

                Return MyBase.EditValue(context, provider, value)
            End If
            Return TryCast(value, String)

        End Function
        Public Overrides Function GetEditStyle(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.Drawing.Design.UITypeEditorEditStyle
            If Not (context Is Nothing) And (Not context.Instance Is Nothing) Then
                Return System.Drawing.Design.UITypeEditorEditStyle.Modal
            End If
            Return MyBase.GetEditStyle(context)
        End Function
    End Class

    'Public Class ExcelSheetBindingSouce
    '    Implements IListSource
    '    Public Property DataTable As New DataTable

    '    Public ReadOnly Property ContainsListCollection As Boolean Implements System.ComponentModel.IListSource.ContainsListCollection
    '        Get
    '            Return True
    '        End Get
    '    End Property

    '    Public Function GetList() As System.Collections.IList Implements System.ComponentModel.IListSource.GetList

    '        Dim dtTable As DataTable = DataTable()
    '        Dim listSource As IListSource = TryCast(dtTable, IListSource)
    '        Return listSource.GetList()

    '    End Function
    'End Class

End Namespace
