Namespace Freely.Script

    Public Class FreelyScripting
        Public Property DocumentList As List(Of Script)

        Public Sub New()
            DocumentList = New List(Of Script)
        End Sub

        Public Sub RegisterScript()
            For Each AList As Script In DocumentList
                Select Case AList.DocumentType
                    Case Freely.Enumeration.FreelyEnum.EnumDocType.DODoc
                        If AList.ItemCodeChangeBaseOnItemUDF Then
                            AutoCount.Scripting.ScriptManager.GetOrCreate(AutoCount.Authentication.UserSession.CurrentUserSession.DBSetting).RegisterByType("DO", GetType(ItemScriptingFunction))
                        End If
                    Case Freely.Enumeration.FreelyEnum.EnumDocType.SODoc
                        If AList.ItemCodeChangeBaseOnItemUDF Then
                            AutoCount.Scripting.ScriptManager.GetOrCreate(AutoCount.Authentication.UserSession.CurrentUserSession.DBSetting).RegisterByType("SO", GetType(ItemScriptingFunction))
                        End If
                    Case Freely.Enumeration.FreelyEnum.EnumDocType.IVDoc
                        If AList.ItemCodeChangeBaseOnItemUDF Then
                            AutoCount.Scripting.ScriptManager.GetOrCreate(AutoCount.Authentication.UserSession.CurrentUserSession.DBSetting).RegisterByType("IV", GetType(ItemScriptingFunction))
                        End If
                    Case Freely.Enumeration.FreelyEnum.EnumDocType.PODoc
                        If AList.ItemCodeChangeBaseOnItemUDF Then
                            AutoCount.Scripting.ScriptManager.GetOrCreate(AutoCount.Authentication.UserSession.CurrentUserSession.DBSetting).RegisterByType("PO", GetType(ItemScriptingFunction))
                        End If
                    Case Freely.Enumeration.FreelyEnum.EnumDocType.QTDoc
                        If AList.ItemCodeChangeBaseOnItemUDF Then
                            AutoCount.Scripting.ScriptManager.GetOrCreate(AutoCount.Authentication.UserSession.CurrentUserSession.DBSetting).RegisterByType("QT", GetType(ItemScriptingFunction))
                        End If
                End Select
            Next
        End Sub
    End Class

    Friend Class ItemScriptingFunction



        Dim _ColumnEffect As String() = {"ItemCode"}
        Public Sub OnDetailColumnChanged(ByVal e As AutoCount.Invoicing.Sales.Quotation.QuotationDetailColumnChangedEventArgs)
            For Each sCol As String In _ColumnEffect
                If e.ChangedColumnName.ToUpper = sCol.ToUpper Then
                    Dim sItemCode As String = IIf(e.CurrentDetailRecord.DataRow.Item("ItemCode") Is DBNull.Value, String.Empty, e.CurrentDetailRecord.DataRow.Item("ItemCode"))
                    If sItemCode.Length > 0 Then GetItemUDF(sItemCode, e.CurrentDetailRecord.DataRow)
                End If
            Next
        End Sub
        Public Sub OnDetailColumnChanged(ByVal e As AutoCount.Invoicing.Purchase.PurchaseOrder.PurchaseOrderDetailColumnChangedEventArgs)
            For Each sCol As String In _ColumnEffect
                If e.ChangedColumnName.ToUpper = sCol.ToUpper Then
                    Dim sItemCode As String = IIf(e.CurrentDetailRecord.DataRow.Item("ItemCode") Is DBNull.Value, String.Empty, e.CurrentDetailRecord.DataRow.Item("ItemCode"))
                    If sItemCode.Length > 0 Then GetItemUDF(sItemCode, e.CurrentDetailRecord.DataRow)
                End If
            Next
        End Sub

        Public Sub OnDetailColumnChanged(ByVal e As AutoCount.Invoicing.Sales.Invoice.InvoiceDetailColumnChangedEventArgs)
            For Each sCol As String In _ColumnEffect
                If e.ChangedColumnName.ToUpper = sCol.ToUpper Then
                    Dim sItemCode As String = IIf(e.CurrentDetailRecord.DataRow.Item("ItemCode") Is DBNull.Value, String.Empty, e.CurrentDetailRecord.DataRow.Item("ItemCode"))
                    If sItemCode.Length > 0 Then GetItemUDF(sItemCode, e.CurrentDetailRecord.DataRow)
                End If
            Next
        End Sub


        Public Sub OnDetailColumnChanged(ByVal e As AutoCount.Invoicing.Sales.DeliveryOrder.DeliveryOrderDetailColumnChangedEventArgs)
            For Each sCol As String In _ColumnEffect
                If e.ChangedColumnName.ToUpper = sCol.ToUpper Then
                    Dim sItemCode As String = IIf(e.CurrentDetailRecord.DataRow.Item("ItemCode") Is DBNull.Value, String.Empty, e.CurrentDetailRecord.DataRow.Item("ItemCode"))
                    If sItemCode.Length > 0 Then GetItemUDF(sItemCode, e.CurrentDetailRecord.DataRow)
                End If
            Next
        End Sub

        Public Sub OnDetailColumnChanged(ByVal e As AutoCount.Invoicing.Sales.SalesOrder.SalesOrderDetailColumnChangedEventArgs)
            For Each sCol As String In _ColumnEffect
                If e.ChangedColumnName.ToUpper = sCol.ToUpper Then


                    Dim sItemCode As String = IIf(e.CurrentDetailRecord.DataRow.Item("ItemCode") Is DBNull.Value, String.Empty, e.CurrentDetailRecord.DataRow.Item("ItemCode"))
                    If sItemCode.Length > 0 Then GetItemUDF(sItemCode, e.CurrentDetailRecord.DataRow)
                End If
            Next
        End Sub

        Private Sub GetItemUDF(ByVal AItemCode As String, ByVal ADataRow As DataRow)
            Using sqlConn As New SqlClient.SqlConnection(AutoCount.Authentication.UserSession.CurrentUserSession.DBSetting.ConnectionString)
                sqlConn.Open()
                Using sqlCmd As New SqlClient.SqlCommand("Select * From Item where ItemCode=@ItemCode", sqlConn)
                    sqlCmd.Parameters.AddWithValue("ItemCode", AItemCode)
                    Using sqlUDF As New SqlClient.SqlCommand("Select * From UDF where TableName=@TableName", sqlConn)
                        sqlUDF.Parameters.AddWithValue("TableName", "Item")
                        Using dtUDF As New DataTable
                            Using dtItem As New DataTable
                                dtItem.Load(sqlCmd.ExecuteReader)
                                dtUDF.Load(sqlUDF.ExecuteReader)
                                Try
                                    For Each drUDF As DataRow In dtUDF.Rows
                                        Dim sField As String = IIf(drUDF.Item("FieldName") Is DBNull.Value, String.Empty, drUDF.Item("FieldName"))
                                        If sField.Length > 0 Then
                                            Dim UDFFIeld As String = String.Format("UDF_{0}", sField)
                                            If Not dtItem.Columns.Contains(UDFFIeld) Then Continue For
                                            If Not ADataRow.Table.Columns.Contains(UDFFIeld) Then Continue For
                                            For Each drItem As DataRow In dtItem.Rows
                                                ADataRow.Item(UDFFIeld) = drItem.Item(UDFFIeld)
                                            Next

                                        End If
                                    Next
                                Catch ex As Exception
                                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message)
                                End Try


                            End Using
                        End Using
                    End Using
                End Using
            End Using
        End Sub
    End Class

    Public Class Script
        Public Property DocumentType As Enumeration.FreelyEnum.EnumDocType
        Public Property ItemCodeChangeBaseOnItemUDF As Boolean = False
        Public Property SpecialUDFMapping As New SpecialUDFMapping
    End Class

    Public Class SpecialUDFMapping
        Public Property UseSourceTableMapping As Boolean = False
        Public Property SourceTable As List(Of String)
    End Class


    Public Class AutoCount18LicenseDLL
        Dim sLicenseDLL As String() = New String() {"Licensing.Net.dll", "FreelyLicenseKey.dll"}
        Dim objDLL As System.Reflection.Assembly = Nothing
        Dim objType As System.Type = Nothing

        Dim _LicenseDLL As List(Of String)
        Public ReadOnly Property LicenseDLL As List(Of String)
            Get
                Return _LicenseDLL
            End Get
        End Property
        Public ReadOnly Property AssemblyInformation As System.Reflection.Assembly
            Get
                Return objDLL
            End Get
        End Property

        Public Sub New(ByVal AAssembly As System.Reflection.Assembly)
            _LicenseDLL = New List(Of String)
            For Each s As String In sLicenseDLL
                _LicenseDLL.Add(s)
            Next

            objDLL = AAssembly
        End Sub

        Public ReadOnly Property [Namespace] As String
            Get
                Return "FreelyFunc"
            End Get
        End Property
        Public ReadOnly Property CreatedBy As String
            Get
                Return "Lai Wei Loong 2014"
            End Get
        End Property
        ''' <summary>
        ''' this Function Is Create To Manually Generate DLL.    
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub RegisterDLL()

            For Each sLicense As String In Me.LicenseDLL
                System.Console.WriteLine(String.Format("Start Searching Embedded Resource : [{0}]", sLicense))
                Using objLicensingDLL As System.IO.Stream = GetType(FreelyScripting).Assembly.GetManifestResourceStream((Me.Namespace & ".") + sLicense)
                    System.Console.WriteLine(String.Format("Start Searching Embedded Resource  With NameSpace: [{0}]", (Me.Namespace & ".") + sLicense))
                    If objLicensingDLL Is Nothing Then
                        '    System.Windows.Forms.MessageBox.Show(sLicense + " Is Null")
                        System.Console.WriteLine(sLicense + " Is Null")
                        Continue For
                    End If
                    System.Console.WriteLine(String.Format("Start Searching Embedded Resource  With NameSpace: [{0}] Found", (Me.Namespace & ".") + sLicense))
                    Dim objDLLByte As Byte() = Nothing
                    objDLLByte = New Byte(System.Convert.ToInt32(objLicensingDLL.Length) - 1) {}
                    objLicensingDLL.Read(objDLLByte, 0, System.Convert.ToInt32(objLicensingDLL.Length))
                    System.Reflection.Assembly.Load(objDLLByte)

                    Dim sIOPath As String = GetType(FreelyScripting).Assembly.Location
                    System.Console.WriteLine(String.Format("IO Path : ", sIOPath))
                    If Not System.IO.File.Exists(System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, sLicense)) Then
                        System.IO.File.WriteAllBytes(System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, sLicense), objDLLByte)
                        System.Console.WriteLine("DLL : " & System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, sLicense) + " Generate Successfully")
                    End If
                End Using
            Next

        End Sub
    End Class
End Namespace

