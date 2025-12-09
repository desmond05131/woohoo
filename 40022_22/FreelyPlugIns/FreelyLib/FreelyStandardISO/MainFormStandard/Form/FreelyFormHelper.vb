
Namespace Freely.Standard.Forms
    Public Class FreelyFormHelper
        Private Const Application_Default_InitControlFormUtil As Boolean = True
        Private Const Application_Default_AutoCloseLookUpWithEndEdit As Boolean = True


        Dim _UserSession As AutoCount.Authentication.UserSession
        Dim _DBSetting As AutoCount.Data.DBSetting
        Dim _ListOfFreelyDataAdapter As List(Of DataAdapter.FreelyDataAdapter)
        Dim _FreelyForm As System.Windows.Forms.Form
        Dim _ListOfAccessRight As List(Of AccessRight.FreelyAccessRight)
        Dim _EditMode As AutoCount.Document.EditWindowMode = AutoCount.Document.EditWindowMode.View
        Dim _DocumentNoRunningHelper As AutoCount.Document.DocumentNumber
        Dim _DecimalSetting As AutoCount.Settings.DecimalSetting
        Dim _SerialNumberHelper As AutoCount.SerialNumber.SerialNumberHelper
        Dim _DocType As String = ""
        Dim _DefaultCloseButtonName As String() = {"btnClose"}
        Dim _FreelyStandardFormTools As FreelyStandardFormTools
        Dim _FreelyLookupBuilder As LookUpBuilder.FreelyLookupBuilder

        Dim _ItemUOMBuilder As AutoCount.XtraUtils.LookupEditBuilder.ItemUOMLookupEditBuilder
        'Lai 2022/04/26 Added RefreshMain Form Function this will trigger main form Refresh.
        Public Property ParentForm As System.Windows.Forms.Form
        Public ReadOnly Property FreelyLookupBuilder As LookUpBuilder.FreelyLookupBuilder
            Get
                Return _FreelyLookupBuilder
            End Get
        End Property
        Public ReadOnly Property FreelyStandardFormTools As FreelyStandardFormTools
            Get
                Return _FreelyStandardFormTools
            End Get
        End Property

        Public ReadOnly Property FreelyForm As System.Windows.Forms.Form
            Get
                Return _FreelyForm
            End Get
        End Property
        Public ReadOnly Property DocType As String
            Get
                Return _DocType
            End Get
        End Property
        Public ReadOnly Property EditMode As AutoCount.Document.EditWindowMode
            Get
                Return _EditMode
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

        Public ReadOnly Property FreelyDataAdapters As List(Of DataAdapter.FreelyDataAdapter)
            Get
                Return _ListOfFreelyDataAdapter
            End Get
        End Property
        Public ReadOnly Property AccessRights As List(Of AccessRight.FreelyAccessRight)
            Get
                Return _ListOfAccessRight
            End Get
        End Property
        Public Sub New(ByVal sender As Object, ByVal ADocType As String,
                       ByVal AUserSession As AutoCount.Authentication.UserSession,
                       Optional ByVal NeedInitControlFormUtil As Boolean = Application_Default_InitControlFormUtil,
                       Optional ByVal AutoCloseLookUpWithEndEdit As Boolean = Application_Default_AutoCloseLookUpWithEndEdit)

            _DocType = ADocType
            _UserSession = AUserSession
            _DBSetting = _UserSession.DBSetting
            _ListOfFreelyDataAdapter = New List(Of DataAdapter.FreelyDataAdapter)
            _ListOfAccessRight = New List(Of AccessRight.FreelyAccessRight)
            _DecimalSetting = AutoCount.Settings.DecimalSetting.GetOrCreate(Me.DBSetting)
            '2022/04/26 lai added new form Tools
            _FreelyStandardFormTools = New FreelyStandardFormTools
            _FreelyLookupBuilder = New LookUpBuilder.FreelyLookupBuilder(Me.UserSession)

            '--Lai Enhance Here To handle User Control also can use.
            If sender IsNot Nothing Then
                If TypeOf sender Is System.Windows.Forms.Form Then
                    _FreelyForm = sender
                    If TryCast(Me.FreelyForm, [Interface].IFreelyFormController) IsNot Nothing Then
                        TryCast(Me.FreelyForm, [Interface].IFreelyFormController).AccessRights = _ListOfAccessRight
                        TryCast(Me.FreelyForm, [Interface].IFreelyFormController).UserSession = AUserSession
                        TryCast(Me.FreelyForm, [Interface].IFreelyFormController).DBSetting = AUserSession.DBSetting
                    End If
                Else
                    _FreelyForm = TryCast(sender, System.Windows.Forms.UserControl).ParentForm
                    If TryCast(Me.FreelyForm, [Interface].IFreelyFormController) IsNot Nothing Then
                        TryCast(sender, [Interface].IFreelyFormController).AccessRights = _ListOfAccessRight
                        TryCast(sender, [Interface].IFreelyFormController).UserSession = AUserSession
                        TryCast(sender, [Interface].IFreelyFormController).DBSetting = AUserSession.DBSetting
                    End If
                End If
            End If

            _DocumentNoRunningHelper = AutoCount.Document.DocumentNumber.Create(_UserSession, _UserSession.DBSetting)
            _SerialNumberHelper = New AutoCount.SerialNumber.SerialNumberHelper(Me._UserSession, _DBSetting, _DocType)
            If NeedInitControlFormUtil Then InitFormControlUtil()
            If AutoCloseLookUpWithEndEdit Then InitAutoCountLookupWIthEndEdit()

            '2022/03/24 lai add default Standard for Form contorl.
            InitFormSetting()
        End Sub
        Private Sub InitAutoCountLookupWIthEndEdit()
            Try
                Dim ALookupList As New List(Of DevExpress.XtraEditors.LookUpEdit)
                FindControl(_FreelyForm, GetType(DevExpress.XtraEditors.LookUpEdit), ALookupList)
                If ALookupList.Count > 0 Then
                    LookupCloseWithEndEdit(ALookupList.ToArray)
                End If
            Catch ex As Exception
                Throw New Exception(String.Format("Exception on InitAutoCountLookupWIthEndEdit : {0}", ex.Message))
            End Try
        End Sub
        Private Sub FindControl(ByVal AControl As Control, ByVal AObjectType As Type, ByVal AObjectList As List(Of DevExpress.XtraEditors.LookUpEdit))
            For Each tempControl In AControl.Controls
                If tempControl.Controls.Count > 0 Then
                    FindControl(tempControl, AObjectType, AObjectList)
                End If
                If tempControl.GetType Is AObjectType Then
                    AObjectList.Add(tempControl)
                End If
                System.Windows.Forms.Application.DoEvents()
            Next
        End Sub

        Private Sub InitFormSetting()
            If Me.FreelyForm IsNot Nothing Then
                Me.FreelyForm.AutoScaleMode = AutoScaleMode.Dpi
                Me.FreelyForm.StartPosition = FormStartPosition.CenterScreen
                Try
                    'Setup this is for when user click close will auto close the form.
                    'if is nothing system auto set btnClose to close.
                    For Each s As String In _DefaultCloseButtonName
                        Dim objClose As Object() = Me.FreelyForm.Controls.Find(s, True)
                        If objClose.Length > 0 Then
                            Me.FreelyForm.CancelButton = objClose(0)
                        End If
                    Next
                Catch ex As Exception
                    Throw ex
                End Try
            End If
        End Sub
        Public Sub SetupCusomizationFieldName(ByVal AGridView As DevExpress.XtraGrid.Views.Grid.GridView)
            For Each dc As DevExpress.XtraGrid.Columns.GridColumn In AGridView.Columns
                If dc.Caption.ToString.Length = 0 Then
                    dc.CustomizationCaption = dc.FieldName
                    dc.Caption = dc.FieldName
                End If
            Next
        End Sub
        Public Function AddRecord() As Boolean
            If TryCast(Me.FreelyForm, [Interface].IFreelyFormController) IsNot Nothing Then
                _EditMode = AutoCount.Document.EditWindowMode.New
                Return IsAllow(GetAccessRightCommandID(Enumeration.FreelyEnum.AccessRightActionEnum.Add))
            End If
            Return True
        End Function

        Public Function GetNextDocKey() As Long
            Return _SerialNumberHelper.GetNextDocKey
        End Function

        Public Sub DocumentSetReadOnlyMode(ByVal AReadOnly As Boolean)
            AutoCount.Utils.ControlUtils.SetReadOnly(Me.FreelyForm.Controls, AReadOnly)
        End Sub
        Public Function AddDetailRecord() As Boolean
            If TryCast(Me.FreelyForm, [Interface].IFreelyFormController) IsNot Nothing Then
                Return IsAllow(GetAccessRightCommandID(Enumeration.FreelyEnum.AccessRightActionEnum.AddDetail))
            End If
            Return True
        End Function
        Public Function EditRecord() As Boolean
            If TryCast(Me.FreelyForm, [Interface].IFreelyFormController) IsNot Nothing Then
                _EditMode = AutoCount.Document.EditWindowMode.Edit
                Return IsAllow(GetAccessRightCommandID(Enumeration.FreelyEnum.AccessRightActionEnum.Edit))
            End If
            Return True
        End Function
        Public Function EditDetailRecord() As Boolean
            If TryCast(Me.FreelyForm, [Interface].IFreelyFormController) IsNot Nothing Then
                Return IsAllow(GetAccessRightCommandID(Enumeration.FreelyEnum.AccessRightActionEnum.EditDetail))
            End If
            Return True
        End Function
        Public Function DeleteRecord() As Boolean
            If TryCast(Me.FreelyForm, [Interface].IFreelyFormController) IsNot Nothing Then
                Return IsAllow(GetAccessRightCommandID(Enumeration.FreelyEnum.AccessRightActionEnum.Delete))
            End If
            Return True
        End Function
        Public Function DeleteDetailRecord() As Boolean
            If TryCast(Me.FreelyForm, [Interface].IFreelyFormController) IsNot Nothing Then
                Return IsAllow(GetAccessRightCommandID(Enumeration.FreelyEnum.AccessRightActionEnum.DeleteDetail))
            End If
            Return True
        End Function
        Public Function ViewRecord() As Boolean
            If TryCast(Me.FreelyForm, [Interface].IFreelyFormController) IsNot Nothing Then
                _EditMode = AutoCount.Document.EditWindowMode.View
                Return IsAllow(GetAccessRightCommandID(Enumeration.FreelyEnum.AccessRightActionEnum.View))
            End If
            Return True
        End Function
        Public Function SaveRecord() As Boolean
            If TryCast(Me.FreelyForm, [Interface].IFreelyFormController) IsNot Nothing Then
                'Allow Edit Mean Allow Save
                Return IsAllow(GetAccessRightCommandID(Enumeration.FreelyEnum.AccessRightActionEnum.Edit))
            End If
            Return True
        End Function
        Public Function IsAllow(ByVal AAccessRightAction As Enumeration.FreelyEnum.AccessRightActionEnum) As Boolean
            '2022/03/22 Lai Added New Function
            Dim AAccessRightCmdID As String = GetAccessRightCommandID(AAccessRightAction)
            Return AutoCount.Authentication.AccessRight.Create(Me.DBSetting, _UserSession.LoginUserID).IsAccessible(AAccessRightCmdID)
        End Function
        Public Function IsAllow(ByVal AAccessRightCmdID As String) As Boolean
            If AAccessRightCmdID Is Nothing OrElse AAccessRightCmdID.Length = 0 Then Return True
            Return AutoCount.Authentication.AccessRight.Create(Me.DBSetting, _UserSession.LoginUserID).IsAccessible(AAccessRightCmdID)
        End Function

        Dim _UOMFilterColumnName As String = ""
        Dim _ItemCodeUOMFilterColumnName As String = ""

        Public Sub FilterItemUOM(ByVal AGridView As DevExpress.XtraGrid.Views.Grid.GridView,
                                 ByVal AUOMLookupEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit,
                                 Optional ByVal AItemCodeColumnName As String = "ItemCode",
                                 Optional ByVal AUOMColumnName As String = "UOM")
            If AGridView Is Nothing Then Return
            If AUOMLookupEdit Is Nothing Then Return

            RemoveHandler AGridView.FocusedColumnChanged, AddressOf UOMFocusedColumnChanged
            RemoveHandler AGridView.FocusedRowChanged, AddressOf UOMFocusedRowChanged

            AddHandler AGridView.FocusedColumnChanged, AddressOf UOMFocusedColumnChanged
            AddHandler AGridView.FocusedRowChanged, AddressOf UOMFocusedRowChanged


            _ItemUOMBuilder = New AutoCount.XtraUtils.LookupEditBuilder.ItemUOMLookupEditBuilder
            _ItemUOMBuilder.BuildLookupEdit(AUOMLookupEdit, _UserSession)

            AGridView.Tag = New GridView.FreelyGridViewFilter With {.ColumnItemCode = AItemCodeColumnName, .ColumnUOM = AUOMColumnName}
            _ItemCodeUOMFilterColumnName = AItemCodeColumnName
            _UOMFilterColumnName = AUOMColumnName
        End Sub
        Private Sub onGridViewFilterItemUOM(ByVal AGridView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal AFilterColumn As GridView.FreelyGridViewFilter)
            If AGridView.FocusedColumn IsNot Nothing Then
                If (AGridView.FocusedColumn.FieldName = _UOMFilterColumnName) Then
                    Dim drItem As DataRow = AGridView.GetDataRow(AGridView.FocusedRowHandle)
                    If drItem IsNot Nothing Then
                        _ItemUOMBuilder.FilterItemCode(drItem.Item(_ItemCodeUOMFilterColumnName).ToString)
                    End If
                End If
            End If
        End Sub

        Private Sub UOMFocusedColumnChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs)
            onGridViewFilterItemUOM(sender, TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).Tag)
        End Sub

        Private Sub UOMFocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)
            onGridViewFilterItemUOM(sender, TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).Tag)
        End Sub
        '2022/03/24 Lai Added New Freely Default Grid View Standard
        Public Sub InitFreelyDefaultGrid(ByVal AFreelyGridViewInitializes As List(Of FreelyGridViewInitialize))
            Try
                For Each views As FreelyGridViewInitialize In AFreelyGridViewInitializes
                    '--------Grid View Default Behavior-------
                    views.GridView.OptionsBehavior.Editable = views.Editable
                    views.GridView.OptionsBehavior.AllowIncrementalSearch = True
                    '--------Grid View Default Behavior-------

                    '--------Grid View Default View-------
                    views.GridView.OptionsView.ShowAutoFilterRow = views.ShowAutoFilterRow
                    views.GridView.OptionsView.ShowGroupPanel = False
                    views.GridView.OptionsView.EnableAppearanceEvenRow = True
                    '--------Grid View Default View-------
                    If views.GridView.GridControl IsNot Nothing Then
                        views.GridView.GridControl.UseEmbeddedNavigator = views.EnableNavigator
                        If views.EnableNavigator Then
                            views.GridView.GridControl.EmbeddedNavigator.Buttons.Append.Visible = False
                            views.GridView.GridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
                            views.GridView.GridControl.EmbeddedNavigator.Buttons.Edit.Visible = False
                            views.GridView.GridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = False
                            views.GridView.GridControl.EmbeddedNavigator.Buttons.Remove.Visible = False
                        End If
                    End If

                    If views.UseLayoutManager Then
                        Dim AUlti As New Freely.Utli.FreelyUtli(_UserSession, Me.DBSetting)
                        AUlti.AddLayoutManager(views.GridView, views.Form.Name)

                        SetupCusomizationFieldName(views.GridView)
                    End If
                    If views.UDFTableName.Length > 0 Then
                        Dim AUDF As New AutoCount.UDF.UDFUIUtil(_UserSession, _DBSetting)
                        AUDF.SetupGrid(views.GridView, views.UDFTableName)
                    End If
                Next
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        ''' <summary>
        ''' This is Generate AUtocount Document No format function.
        ''' You May Select From SQL [DocNoFormat] DocType AND Name as reference.
        ''' </summary>       
        ''' <param name="ADocumentName">
        '''  please reffer to autocount document no Name
        ''' Example : IV Default
        ''' </param>  
        ''' <param name="NeedIncNo">
        ''' Mean Will Inc autocount Next document No.
        ''' </param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetAutoCountNextDocumentNo(ByVal ADocumentName As String, Optional NeedIncNo As Boolean = False) As String
            Try
                If NeedIncNo Then
                    Return _DocumentNoRunningHelper.IncreaseNextNumber(Me.DocType, ADocumentName, Today)
                Else
                    Dim sAutoCountDocumentNo As String = _DocumentNoRunningHelper.GetDocumentNumber(Me.DocType, ADocumentName, Today)
                    Return String.Format("Next Posible No : {0}", sAutoCountDocumentNo)
                End If
            Catch ex As Exception
                Throw ex
            End Try
            Return ""
        End Function

        Public Sub DesignReport(Optional ByVal AUpdateTableName As String = "")
            Try
                Dim sReportType As String = TryCast(Me.FreelyForm, [Interface].IFreelyFormController).ReportType
                If sReportType Is Nothing OrElse sReportType.Length = 0 Then Throw New Exception("Invalid Report Type")
                Dim sPreviewCmdID As String = GetAccessRightCommandID(Enumeration.FreelyEnum.AccessRightActionEnum.PreviewReport)
                Dim sExportCmdID As String = GetAccessRightCommandID(Enumeration.FreelyEnum.AccessRightActionEnum.ExportReport)


                Dim AReportOption As New AutoCount.Report.BasicReportOption
                Dim reportInfo As AutoCount.Report.ReportInfo = New AutoCount.Report.ReportInfo(
                                                                                       sReportType,
                                                                                         sPreviewCmdID,
                                                                                    sExportCmdID,
                                                                                    "")

                reportInfo.DocType = AutoCount.Document.DocumentType.DeliveryReturn
                reportInfo.DocKey = -1
                If AUpdateTableName.Length > 0 Then
                    reportInfo.UpdatePrintCountTableName = AUpdateTableName
                End If



                Dim ds As AutoCount.Report.DocumentReportDataSet = TryCast(Me.FreelyForm, [Interface].IFreelyFormController).ReturnDataset(-1)

                AutoCount.Report.ReportTool.DesignReport(sReportType,
                                                              ds,
                                                              _UserSession)


            Catch ex As Exception
                Freely.Standard.MessageBox.FreelyMessageBox.ShowErrorMessage(String.Format("Excpetion On  Form Design Data: {0} ", ex.Message))

            End Try
        End Sub
        Public Sub PreviewReport(ByVal ADocKey As Long, Optional ByVal AUpdateTableName As String = "")
            Try
                If TryCast(Me.FreelyForm, [Interface].IFreelyFormController) IsNot Nothing Then
                    Dim sReportType As String = TryCast(Me.FreelyForm, [Interface].IFreelyFormController).ReportType
                    If sReportType Is Nothing OrElse sReportType.Length = 0 Then Throw New Exception("Invalid Report Type")
                    Dim sPreviewCmdID As String = GetAccessRightCommandID(Enumeration.FreelyEnum.AccessRightActionEnum.PreviewReport)
                    Dim sExportCmdID As String = GetAccessRightCommandID(Enumeration.FreelyEnum.AccessRightActionEnum.ExportReport)

                    Dim AReportOption As New AutoCount.Report.BasicReportOption
                    Dim reportInfo As AutoCount.Report.ReportInfo = New AutoCount.Report.ReportInfo(
                                                                                           sReportType,
                                                                                            sPreviewCmdID,
                                                                                            sExportCmdID,
                                                                                            "")

                    reportInfo.DocType = AutoCount.Document.DocumentType.DeliveryReturn
                    reportInfo.DocKey = ADocKey
                    If AUpdateTableName.Length > 0 Then
                        reportInfo.UpdatePrintCountTableName = AUpdateTableName
                    End If

                    Dim ds As AutoCount.Report.DocumentReportDataSet = TryCast(Me.FreelyForm, [Interface].IFreelyFormController).ReturnDataset(ADocKey)
                    AutoCount.Report.ReportTool.PreviewReport(sReportType,
                                                                  ds,
                                                                  _UserSession,
                                                                  True, False, AReportOption, reportInfo)
                Else
                    Throw New Exception("Unknown Report Format")
                End If
            Catch ex As Exception
                Freely.Standard.MessageBox.FreelyMessageBox.ShowErrorMessage(String.Format("Excpetion On  Form Preview Data: {0} ", ex.Message))

            End Try
        End Sub

        Public Sub PrintReport(ByVal ADocKey As Long, Optional ByVal AUpdateTableName As String = "")
            Try
                If TryCast(Me.FreelyForm, [Interface].IFreelyFormController) IsNot Nothing Then
                    Dim sReportType As String = TryCast(Me.FreelyForm, [Interface].IFreelyFormController).ReportType
                    If sReportType Is Nothing OrElse sReportType.Length = 0 Then Throw New Exception("Invalid Report Type")
                    Dim sPreviewCmdID As String = GetAccessRightCommandID(Enumeration.FreelyEnum.AccessRightActionEnum.PreviewReport)
                    Dim sExportCmdID As String = GetAccessRightCommandID(Enumeration.FreelyEnum.AccessRightActionEnum.ExportReport)

                    Dim AReportOption As New AutoCount.Report.BasicReportOption
                    Dim reportInfo As AutoCount.Report.ReportInfo = New AutoCount.Report.ReportInfo(
                                                                                           sReportType,
                                                                                            sPreviewCmdID,
                                                                                            sExportCmdID,
                                                                                            "")

                    reportInfo.DocType = AutoCount.Document.DocumentType.DeliveryReturn
                    reportInfo.DocKey = ADocKey
                    If AUpdateTableName.Length > 0 Then
                        reportInfo.UpdatePrintCountTableName = AUpdateTableName
                    End If

                    Dim ds As AutoCount.Report.DocumentReportDataSet = TryCast(Me.FreelyForm, [Interface].IFreelyFormController).ReturnDataset(ADocKey)
                    AutoCount.Report.ReportTool.PrintReport(sReportType,
                                                              ds,
                                                              _UserSession,
                                                               False,
                                                               AReportOption,
                                                               reportInfo)

                Else
                    Throw New Exception("Unknow Report Format")
                End If
            Catch ex As Exception
                Freely.Standard.MessageBox.FreelyMessageBox.ShowErrorMessage(String.Format("Excpetion On  Form Preview Data: {0} ", ex.Message))
            End Try
        End Sub

        Public Function Commit(Optional ByVal WithAutoTrail As Boolean = False) As Boolean
            Try
                For iAdapter As Integer = 0 To _ListOfFreelyDataAdapter.Count - 1
                    _ListOfFreelyDataAdapter(iAdapter).Commit(WithAutoTrail)
                Next
                Return True
            Catch ex As Exception
                Throw ex
            End Try
            Return False
        End Function

        Public Function RefreshData() As Boolean
            Try
                For iAdapter As Integer = 0 To _ListOfFreelyDataAdapter.Count - 1
                    _ListOfFreelyDataAdapter(iAdapter).RefreshData()
                Next
                Return True
            Catch ex As Exception
                Throw ex
            End Try
            Return False
        End Function

        Public Sub InitFormControlUtil()
            If Me.FreelyForm IsNot Nothing Then
                Dim AFormUlti As New AutoCount.XtraUtils.FormControlUtil(Me.DBSetting, False)
                AFormUlti.AddField("Qty", AutoCount.XtraUtils.FormControlUtil.QUANTITY_FIELD)
                AFormUlti.AddField("BookQty", AutoCount.XtraUtils.FormControlUtil.QUANTITY_FIELD)
                AFormUlti.AddField("LossDamageQty", AutoCount.XtraUtils.FormControlUtil.QUANTITY_FIELD)
                AFormUlti.AddField("Variance", AutoCount.XtraUtils.FormControlUtil.QUANTITY_FIELD)
                AFormUlti.AddField("IVQty", AutoCount.XtraUtils.FormControlUtil.QUANTITY_FIELD)
                AFormUlti.AddField("AdjQtyNegative", AutoCount.XtraUtils.FormControlUtil.QUANTITY_FIELD)
                AFormUlti.AddField("AdjQtyPositive", AutoCount.XtraUtils.FormControlUtil.QUANTITY_FIELD)
                AFormUlti.AddField("UnitPrice", AutoCount.XtraUtils.FormControlUtil.PRICE_FIELD)
                AFormUlti.AddField("SubTotal", AutoCount.XtraUtils.FormControlUtil.PRICE_FIELD)
                AFormUlti.AddField("Total", AutoCount.XtraUtils.FormControlUtil.PRICE_FIELD)
                AFormUlti.AddField("TotalPaymentAmt", AutoCount.XtraUtils.FormControlUtil.PRICE_FIELD)
                AFormUlti.AddField("DiscountAmt", AutoCount.XtraUtils.FormControlUtil.PRICE_FIELD)
                AFormUlti.AddField("DocDate", AutoCount.XtraUtils.FormControlUtil.DATE_FIELD)
                AFormUlti.AddField("ING_CsgnTo", AutoCount.XtraUtils.FormControlUtil.DATE_FIELD)
                AFormUlti.AddField("ING_CsgnFrom", AutoCount.XtraUtils.FormControlUtil.DATE_FIELD)
                AFormUlti.AddField("CreatedTimeStamp", AutoCount.XtraUtils.FormControlUtil.DATETIME_FIELD)
                AFormUlti.AddField("LastModified", AutoCount.XtraUtils.FormControlUtil.DATETIME_FIELD)
                AFormUlti.AddField("PostDateTime", AutoCount.XtraUtils.FormControlUtil.DATETIME_FIELD)
                AFormUlti.AddField("AdjTotal", AutoCount.XtraUtils.FormControlUtil.PRICE_FIELD)
                AFormUlti.InitControls(Me.FreelyForm)
            End If
        End Sub

        Private Function GetAccessRightCommandID(ByVal AAccessRightAction As Enumeration.FreelyEnum.AccessRightActionEnum) As String
            Dim AccessRightCmd As List(Of AccessRight.FreelyAccessRight) = TryCast(Me.FreelyForm, [Interface].IFreelyFormController).AccessRights.Where(Function(element)
                                                                                                                                                            Return element.AccessRightAction = AAccessRightAction
                                                                                                                                                        End Function).ToList()
            If AccessRightCmd.Count > 0 Then
                Return AccessRightCmd(0).AccessRightCommandID
            Else
                Return ""
            End If
        End Function
        Public Function GetFreelyAdapter(ByVal ATableName As String) As DataAdapter.FreelyDataAdapter
            Return _ListOfFreelyDataAdapter.Where(Function(element)
                                                      Return element.TableName.ToUpper = ATableName.ToUpper
                                                  End Function).First()

        End Function

        'Lai 2022/04/26 Added RefreshMain Form Function
        Public Sub RefreshMainForm(ByVal AMainForm As Object)
            Try
                If ParentForm Is Nothing Then
                    Throw New Exception("Parent Form Not Found!")
                End If
                Dim AFreelyController As Freely.Interface.IFreelyFormController = TryCast(ParentForm, Freely.Interface.IFreelyFormController)
                If AFreelyController Is Nothing Then
                    Throw New Exception("Invalid Freely Controller!")
                End If
                AFreelyController.FormAction(Enumeration.FreelyEnum.FormActionEnum.RefreshAction)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        'This Function For lookup form Closed direct Effect OnChanged
        Public Sub LookupCloseWithEndEdit(ByVal ALookups As DevExpress.XtraEditors.LookUpEdit())
            For Each objLookup As DevExpress.XtraEditors.LookUpEdit In ALookups
                LookupCloseWithEndEdit(objLookup)
            Next
        End Sub
        Public Sub LookupCloseWithEndEdit(ByVal ALookup As DevExpress.XtraEditors.LookUpEdit)
            RemoveHandler ALookup.EditValueChanged, AddressOf OnLookupEditValueChanged
            AddHandler ALookup.EditValueChanged, AddressOf OnLookupEditValueChanged
        End Sub
        Private Sub OnLookupEditValueChanged(sender As Object, e As EventArgs)
            If (TypeOf sender Is DevExpress.XtraEditors.BaseEdit) Then
                TryCast(sender, DevExpress.XtraEditors.BaseEdit).DoValidate()
            End If
            _FreelyForm.BeginInvoke(New FreelyInvoicingEvents.EndDocumentEditMethodInvoker(AddressOf EndDocumentEdit))
        End Sub

        Private Function EndDocumentEdit() As Boolean
            Try
                Dim activeControl As Control = _FreelyForm.ActiveControl
                While activeControl IsNot Nothing AndAlso Not TypeOf activeControl Is DevExpress.XtraEditors.BaseEdit
                    activeControl = activeControl.Parent
                End While
                If (TypeOf activeControl Is DevExpress.XtraEditors.BaseEdit AndAlso Not TryCast(activeControl, DevExpress.XtraEditors.BaseEdit).DoValidate()) Then
                    Return False
                End If
                If activeControl Is Nothing Then Return False
                Dim ABindingManager As BindingManagerBase = TryCast(activeControl, DevExpress.XtraEditors.BaseEdit).BindingManager
                If ABindingManager IsNot Nothing Then
                    Dim ACurrencyManager As CurrencyManager = DirectCast(ABindingManager, CurrencyManager)
                    ACurrencyManager.EndCurrentEdit()
                    ACurrencyManager.Refresh()
                End If
                Return True
            Catch ex As Exception
                Throw ex
            End Try
            Return False
        End Function
    End Class
    Public Class FreelyInvoicingEvents
        Public Delegate Function EndDocumentEditMethodInvoker() As Boolean
    End Class
End Namespace
