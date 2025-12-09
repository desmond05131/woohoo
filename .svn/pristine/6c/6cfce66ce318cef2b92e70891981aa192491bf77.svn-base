Namespace Freely.Standard.PlugIns
    Public Class FreelyPlugInsHelper
        '2022/03/04 Lai Added New Document.

        Public Const ColName_CompanyName As String = "CompanyName"


        Dim _FreelyDocument As Freely.Document.FreelyDocument
        Dim _UserSession As AutoCount.Authentication.UserSession
        Dim _DBSetting As AutoCount.Data.DBSetting
        Public ReadOnly Property FreelyDocument As Freely.Document.FreelyDocument
            Get
                Return _FreelyDocument
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

  
        Public Sub New(ByVal AUserSession As AutoCount.Authentication.UserSession)
            _UserSession = AUserSession
            _DBSetting = _UserSession.DBSetting
            _FreelyDocument = New Freely.Document.FreelyDocument(Me.DBSetting)
            InitFreelyConstMessage()
        End Sub

        Private Sub InitFreelyConstMessage()
            Dim assemblyType As Type
            assemblyType = GetType(FreelyPlugIns)

            Dim AFreelyClass As New Freely.Application.FreelyMessageCommand
            AFreelyClass.CompanyName = Me.GetCompanyProfile()
            AFreelyClass.SQLConnString = Me.DBSetting.ConnectionString
            AFreelyClass.UserID = AutoCount.Authentication.UserSession.CurrentUserSession.LoginUserID
            AFreelyClass.LongTitleName = FreelyPlugIns.ProductName
            AFreelyClass.ShortTitleName = FreelyPlugIns.ProductName
            AFreelyClass.ProgramName = FreelyPlugIns.ProductName
            AFreelyClass.ProgramVersion = assemblyType.Assembly.GetName.Version.ToString()
            Dim AConstMsg As New Freely.Application.FreelyConstMessage(AFreelyClass)
        End Sub

        Public Function RegisterAutoCountDocument(scripts As String, YourClassType As Type) As Boolean
            Try
                AutoCount.Scripting.ScriptManager.GetOrCreate(_DBSetting).RegisterByType(scripts, YourClassType)
                Return True
            Catch ex As Exception
                Freely.Standard.MessageBox.FreelyMessageBox.ShowErrorMessage(ex.Message)

            End Try
            Return False
        End Function

        Public Function GetCompanyProfile(Optional ByVal AFieldName As String = ColName_CompanyName) As String
            Using sqlConn As New SqlClient.SqlConnection(Me.DBSetting.ConnectionString)
                sqlConn.Open()
                Using sqlCmd As New SqlClient.SqlCommand(String.Format("Select {0} From Profile WHERE 1=1", AFieldName), sqlConn)
                    Using dtMaster As New DataTable
                        dtMaster.Load(sqlCmd.ExecuteReader)
                        For Each drProfile As DataRow In dtMaster.Rows
                            Return IIf(drProfile.Item(AFieldName) Is DBNull.Value, String.Empty, drProfile.Item(AFieldName))
                        Next
                    End Using
                End Using
            End Using
            Return String.Empty
        End Function

        Public Function IsAutoCountUDFListFound(ByVal AListName As String) As Boolean
            Try
                Dim AListMaster As New AutoCount.UDF.UDFList(Me.DBSetting)
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
        Public Sub AddAutoCountDocumentFormat(ByVal ADocumentType As String, ByVal ADocumentName As String, ByVal ADocumentFormat As String)
            _FreelyDocument.GenerateNewDocumentType(ADocumentType, ADocumentName, ADocumentFormat)
        End Sub
        Public Function AddAutoCountUDFList(ByVal AListName As String, ByVal AListItems As String()) As Boolean
            Try
                Dim AListMaster As New AutoCount.UDF.UDFList(Me.DBSetting)
                If Not IsAutoCountUDFListFound(AListName) Then
                    Dim AList As New AutoCount.UDF.List
                    AList.Name = AListName
                    AList.SetItems(AListItems)
                    AListMaster.Add(AList)
                    AListMaster.Save()
                End If
            Catch ex As Exception
                Throw ex
            End Try
            Return False
        End Function
        Public Sub GenerateUDFFIeld(ByVal TableName As String, ByVal RequiredUDF As String, ByVal UDFDisplayText As String, ByVal UType As AutoCount.UDF.UDFType, ByVal Size As Integer, Optional ByVal ACustomData As AutoCount.UDF.SystemUDF = Nothing, Optional ByVal isUDFList As Boolean = False, Optional ByVal UDFListName As String = "")
            Dim AUDFTable As AutoCount.UDF.UDFTable = New AutoCount.UDF.UDFTable(TableName, Me.DBSetting)
            Dim drRow As DataRow = AUDFTable.Table.Rows.Find(New Object() {TableName, RequiredUDF})
            If drRow Is Nothing Then
                Dim AField As AutoCount.UDF.Field = New AutoCount.UDF.Field()
                AField.Name = RequiredUDF
                AField.Caption = UDFDisplayText
                AField.Type = UType

                If (UType = AutoCount.UDF.UDFType.Text) Then
                    AField.TextProperties.Size = Size
                    AField.TextProperties.Unique = False
                    AField.TextProperties.Required = False
                    If isUDFList Then
                        AField.TextProperties.ListName = UDFListName
                    End If
                ElseIf (UType = AutoCount.UDF.UDFType.Decimal) Then
                    AField.DecimalProperties.Scale = Size
                ElseIf (UType = AutoCount.UDF.UDFType.System) Then
                    If ACustomData IsNot Nothing Then
                        AField.SystemProperties.CustomDataType = ACustomData.CustomDataType
                        AField.SystemProperties.DefaultValue = ACustomData.DefaultValue
                        AField.SystemProperties.Required = ACustomData.Required
                        AField.SystemProperties.ShowLabel = ACustomData.ShowLabel
                        AField.SystemProperties.Unique = ACustomData.Unique
                    End If
                End If

                Try
                    AUDFTable.Add(AField)
                    AUDFTable.Save()
                Catch ex As Exception
                    Throw ex

                End Try
            Else
                For iUDF As Integer = 0 To AUDFTable.Count - 1
                    Dim sTable As String = IIf(AUDFTable.Item(iUDF).myRow.Item("TableName") Is DBNull.Value, String.Empty, AUDFTable.Item(iUDF).myRow.Item("TableName"))
                    Dim sFieldName As String = IIf(AUDFTable.Item(iUDF).myRow.Item("FieldName") Is DBNull.Value, String.Empty, AUDFTable.Item(iUDF).myRow.Item("FieldName"))
                    If sTable.Length > 0 And sFieldName.Length > 0 Then
                        If sTable.ToUpper = TableName.ToUpper And RequiredUDF.ToUpper = sFieldName.ToUpper Then
                            Dim AType As AutoCount.UDF.UDFType = AUDFTable.Item(iUDF).Type
                            Dim bUpdate As Boolean = False
                            If AType <> UType Then
                                AUDFTable.Item(iUDF).Type = UType
                                bUpdate = True
                            End If
                            If bUpdate Then
                                Try

                                    AUDFTable.Save()
                                Catch ex As Exception
                                    Throw ex
                                End Try
                            End If
                        End If
                    End If
                Next
            End If
        End Sub
    End Class
End Namespace